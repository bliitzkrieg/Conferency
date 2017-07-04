import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface TalkState {
    isLoading: boolean;
    talk: Talk;
}

export interface Talk {
    id: number;
    name: string;
    url: string;
    talkTags: any;
    presented: string;
    modifiedAt: string;
    createdAt: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestTalkAction {
    type: 'REQUEST_TALK'
}

interface ReceiveTalkAction {
    type: 'RECEIVE_TALK',
    talk: Talk
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestTalkAction | ReceiveTalkAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestTalk: (id: Number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        if (!getState().talk.talk) {
            let fetchTask = fetch(`/api/Talks/${ id }`)
                .then(response => response.json() as Promise<Talk>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_TALK', talk: data });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_TALK' });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: TalkState = { talk: undefined, isLoading: false };

export const reducer: Reducer<TalkState> = (state: TalkState, action: KnownAction) => {
    switch (action.type) {
        case 'REQUEST_TALK':
            return {
                talk: state.talk,
                isLoading: true
            };
        case 'RECEIVE_TALK':
            return {
                talk: action.talk,
                isLoading: false
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
