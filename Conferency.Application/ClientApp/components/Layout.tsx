import * as React from 'react';
import { Link } from 'react-router';
import { NavMenu } from './NavMenu';

export interface LayoutProps {
    body: React.ReactElement<any>;
}

export class Layout extends React.Component<LayoutProps, void> {
    public render() {
        return <div className='container'>
                <header>
                    <div className='brand'><Link to={ '/' } activeClassName='active'>Conferency</Link></div>
                    <NavMenu />
                </header>
                <main>
                    { this.props.body }
                </main>
            </div>;
    }
}
