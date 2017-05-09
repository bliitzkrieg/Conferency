import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';
import { Talk } from './Talk';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface TalksState {
    isLoading: boolean;
    talks: Talk[];
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestTalksAction {
    type: 'REQUEST_TALKS'
}

interface ReceiveTalksAction {
    type: 'RECEIVE_TALKS',
    talks: Talk[]
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestTalksAction | ReceiveTalksAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestTalks: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        if (getState().talks.talks.length === 0) {
            let fetchTask = fetch(`/api/Talks`)
                .then(response => response.json() as Promise<Talk[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_TALKS', talks: data });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_TALKS' });    
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: TalksState = { talks: [], isLoading: false };

export const reducer: Reducer<TalksState> = (state: TalksState, action: KnownAction) => {
    switch (action.type) {
        case 'REQUEST_TALKS':
            return {
                talks: state.talks,
                isLoading: true
            };
        case 'RECEIVE_TALKS':
            return {
                talks: action.talks,
                isLoading: false
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
