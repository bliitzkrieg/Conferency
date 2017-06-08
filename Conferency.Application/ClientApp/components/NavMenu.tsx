import * as React from 'react';
import { Link } from 'react-router';

export class NavMenu extends React.Component<void, void> {
    public render() {
        return <nav>
             <Link to={ '/create' } activeClassName='active'>
                Create
            </Link>
             <Link to={ '/talks' } activeClassName='active'>
                Talks
            </Link>
        </nav>
    }
}
