import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface ConferencesState {
    isLoading: boolean;
    conferences: Conference[];
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

interface RequestConferencesAction {
    type: 'REQUEST_CONFERENCES'
}

interface ReceiveConferencesAction {
    type: 'RECEIVE_CONFERENCES',
    conferences: Conference[]
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestConferencesAction | ReceiveConferencesAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestConferences: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        if (getState().conferences.conferences.length === 0) {
            let fetchTask = fetch(`/api/Conferences`)
                .then(response => response.json() as Promise<Conference[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_CONFERENCES', conferences: data });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_CONFERENCES' });    
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: ConferencesState = { conferences: [], isLoading: false };

export const reducer: Reducer<ConferencesState> = (state: ConferencesState, action: KnownAction) => {
    switch (action.type) {
        case 'REQUEST_CONFERENCES':
             return {
                conferences: state.conferences,
                isLoading: true
            };
        case 'RECEIVE_CONFERENCES':
            return {
                conferences: action.conferences,
                isLoading: false
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
