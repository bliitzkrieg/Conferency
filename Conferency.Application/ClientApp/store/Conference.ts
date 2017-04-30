import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface ConferenceState {
    isLoading: boolean;
    conference: Conference;
}

export interface Conference {
    id: number;
    name: string;
    location: string;
    website: string;
    photo: string;
    conferenceSpeakers: any;
    talks: any;
    hosted: string;
    modifiedAt: string;
    createdAt: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestConferenceAction {
    type: 'REQUEST_CONFERENCE'
}

interface ReceiveConferenceAction {
    type: 'RECEIVE_CONFERENCE',
    conference: Conference
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestConferenceAction | ReceiveConferenceAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestConference: (id: Number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        if (!getState().conference.conference) {
            let fetchTask = fetch(`/api/Conferences/${ id }`)
                .then(response => response.json() as Promise<Conference>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_CONFERENCE', conference: data });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_CONFERENCE' });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: ConferenceState = { conference: undefined, isLoading: false };

export const reducer: Reducer<ConferenceState> = (state: ConferenceState, action: KnownAction) => {
    switch (action.type) {
        case 'REQUEST_CONFERENCE':
            return {
                conference: state.conference,
                isLoading: true
            };
        case 'RECEIVE_CONFERENCE':
            return {
                conference: action.conference,
                isLoading: false
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
