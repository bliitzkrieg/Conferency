import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as TalksState from '../store/Talks';

// At runtime, Redux will merge together...
type CreateTalkProps =
    TalksState.TalksState
    & typeof TalksState.actionCreators
    & { createTalk: Function; }

class CreateTalk extends React.Component<CreateTalkProps, {}> {

    private createTalk(): void {
        this.props.createTalk({ Name: 'test', Url: 'https://www.youtube.com/watch?v=nYvNqKrl69s', Tags: ['React', 'ReactConf2017'] });
    }

    public render() {
        return <div>
            <h1>Create Talk</h1>
            <button onClick={ this.createTalk.bind(this) } >Create</button>
        </div>;
    }
}

export default connect(
    (state: ApplicationState) => state.talks, // Selects which state properties are merged into the component's props
    TalksState.actionCreators                 // Selects which action creators are merged into the component's props
)(CreateTalk);
