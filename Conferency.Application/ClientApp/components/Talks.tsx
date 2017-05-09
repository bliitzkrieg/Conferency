import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import { TalkItem } from './TalkItem';
import * as TalksState from '../store/Talks';

// At runtime, Redux will merge together...
type TalkProps =
    TalksState.TalksState     // ... state we've requested from the Redux store
    & typeof TalksState.actionCreators
    & { requestTalks: Function; }

class Talks extends React.Component<TalkProps, void> {

    componentWillMount() {
        this.props.requestTalks();
    }

    public render() {
        return <div>
            <h1>Talks</h1>
            <div className="conference-list">
                {this.renderTalks() }
            </div>
        </div>;
    }

    private renderTalks() {
        return this.props.talks.map(talk =>
            <TalkItem key={ talk.id } talk={ talk } />);
    }
}

export default connect(
    (state: ApplicationState) => state.talks, // Selects which state properties are merged into the component's props
    TalksState.actionCreators                 // Selects which action creators are merged into the component's props
)(Talks);
