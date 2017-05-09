import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import { TalkItem } from './TalkItem';
import * as TalkState from '../store/Talk';

// At runtime, Redux will merge together...
type TalkProps =
    TalkState.TalkState     // ... state we've requested from the Redux store
    & typeof TalkState.actionCreators
    & { params: { id: string }, requestTalk: Function };

class Talk extends React.Component<TalkProps, void> {

    componentWillMount() {
        const id: number = +this.props.params.id;
        this.props.requestTalk(id);
    }

    componentWillReceiveProps(nextProps: TalkProps) {
        const id: number = +this.props.params.id;
        this.props.requestTalk(id);
    }

    public render() {
        return <div>
            <h1>Talk</h1>
            { this.renderTalkItem() }
        </div>;
    }

    private renderTalkItem() {
        if (this.props.talk) {
            return (<TalkItem talk={ this.props.talk } />);
        }

        return (<div>Loading...</div>);
    }
}

export default connect(
    (state: ApplicationState) => state.talk, // Selects which state properties are merged into the component's props
    TalkState.actionCreators                 // Selects which action creators are merged into the component's props
)(Talk);
