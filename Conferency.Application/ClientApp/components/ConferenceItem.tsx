import * as React from 'react';
import { Conference } from '../store/Conferences';
import * as moment from 'moment';

export interface ConferenceProps {
    conference: Conference;
}

export class ConferenceItem extends React.Component<ConferenceProps, void> {

    public render() {
        const url = `/conferences/${ this.props.conference.id }`;
        const style = {
            backgroundImage: `url(${ this.props.conference.photo || "http://placehold.it/350x150" })`
        };
        const date = moment(this.props.conference.hosted).format("dddd, MMMM Do YYYY");

        return <div className="conference-item">
            <div className="conference-item-photo" style={style}></div>
            <div className="conference-item-details">
                <a href={ url }>{ this.props.conference.name }</a>
                <div>{ this.props.conference.location }</div>
                <a href={ this.props.conference.website }>Website</a>
                <div>{ this.props.conference.talks ? this.props.conference.talks.length : 0 } talks</div>
                <div>{ this.props.conference.conferenceSpeakers ? this.props.conference.conferenceSpeakers.length : 0 } speakers</div>
                <div>{ date }</div>
            </div>
        </div>
    }
}