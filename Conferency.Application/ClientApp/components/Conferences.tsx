import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import { ConferenceItem } from './ConferenceItem';
import * as ConferencesState from '../store/Conferences';

// At runtime, Redux will merge together...
type ConferenceProps =
    ConferencesState.ConferencesState     // ... state we've requested from the Redux store
    & typeof ConferencesState.actionCreators
    & { requestConferences: Function; }

class Conferences extends React.Component<ConferenceProps, void> {

    componentWillMount() {
        this.props.requestConferences();
    }

    public render() {
        return <div>
            <h1>Conferences</h1>
            <div className="conference-list">
                { this.renderConferences() }
            </div>
        </div>;
    }

    private renderConferences() {
        return this.props.conferences.map(conference =>
            <ConferenceItem key={ conference.id } conference={ conference } />);
    }
}

export default connect(
    (state: ApplicationState) => state.conferences, // Selects which state properties are merged into the component's props
    ConferencesState.actionCreators                 // Selects which action creators are merged into the component's props
)(Conferences);
