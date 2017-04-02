import * as React from 'react';
import { Link } from 'react-router';

export class NavMenu extends React.Component<void, void> {
    public render() {
        return <nav>
            <Link to={ '/' } activeClassName='active'>
                <span className='glyphicon glyphicon-home'></span> Home
             </Link>
             <Link to={ '/counter' } activeClassName='active'>
                <span className='glyphicon glyphicon-education'></span> Talks
             </Link>
             <Link to={ '/fetchdata' } activeClassName='active'>
                <span className='glyphicon glyphicon-th-list'></span> Speakers
            </Link>
             <Link to={ '/conferences' } activeClassName='active'>
                <span className='glyphicon glyphicon-th-list'></span> Conferences
            </Link>
        </nav>
    }
}
