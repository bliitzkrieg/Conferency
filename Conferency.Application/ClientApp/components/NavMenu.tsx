import * as React from 'react';
import { Link } from 'react-router';

export class NavMenu extends React.Component<void, void> {
    public render() {
        return <nav>
            <Link to={ '/' } activeClassName='active'>
                Home
             </Link>
             <Link to={ '/counter' } activeClassName='active'>
                Talks
             </Link>
             <Link to={ '/fetchdata' } activeClassName='active'>
                Speakers
            </Link>
             <Link to={ '/conferences' } activeClassName='active'>
                Conferences
            </Link>
        </nav>
    }
}
