import * as React from 'react';
import { Link } from 'react-router';

export class NavMenu extends React.Component<void, void> {
    public render() {
        return <nav>
             <Link to={ '/counter' } activeClassName='active'>
                Counter
             </Link>
             <Link to={ '/fetchdata' } activeClassName='active'>
                Fetch Data
            </Link>
             <Link to={ '/talks' } activeClassName='active'>
                Talks
            </Link>
        </nav>
    }
}
