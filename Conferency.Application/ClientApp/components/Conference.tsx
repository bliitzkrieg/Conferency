import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import { ConferenceItem } from './ConferenceItem';
import * as ConferenceState from '../store/Conference';

// At runtime, Redux will merge together...
type ConferenceProps =
    ConferenceState.ConferenceState     // ... state we've requested from the Redux store
    & typeof ConferenceState.actionCreators
    & { params: { id: string }, requestConference: Function };

class Conference extends React.Component<ConferenceProps, void> {

    componentWillMount() {
        const id: number = +this.props.params.id;
        this.props.requestConference(id);
    }

    componentWillReceiveProps(nextProps: ConferenceProps) {
        const id: number = +this.props.params.id;
        this.props.requestConference(id);
    }

    public render() {
        return <div>
            <h1>Conference</h1>
            { this.renderConferenceItem() }
        </div>;
    }

    private renderConferenceItem() {
        if (this.props.conference) {
            return (<ConferenceItem conference={this.props.conference} />);
        }

        return (<div>Loading...</div>);
    }
}

export default connect(
    (state: ApplicationState) => state.conference, // Selects which state properties are merged into the component's props
    ConferenceState.actionCreators                 // Selects which action creators are merged into the component's props
)(Conference);
