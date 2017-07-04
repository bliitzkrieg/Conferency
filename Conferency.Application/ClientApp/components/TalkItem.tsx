import * as React from 'react';
import { Talk } from '../store/Talk';
import * as moment from 'moment';
import { Link } from 'react-router';
 
export interface TalkProps {
    talk: Talk;
}

export class TalkItem extends React.Component<TalkProps, void> {

    public render() {
        const url = `/talk/some-slug/${this.props.talk.id}`;

        const date = moment(this.props.talk.createdAt).format("dddd, MMMM Do YYYY");

        return <div className="conference-item">
            <div className="conference-item-photo"></div>
            <div className="conference-item-details">
                <Link to={ url } activeClassName='active'>
                    {this.props.talk.name}
                </Link>
                <a href={this.props.talk.url}>Video</a>
                <div>{this.props.talk.talkTags ? this.props.talk.talkTags.length : 0} tags</div>
                <div>{ date }</div>
            </div>
        </div>
    }
}