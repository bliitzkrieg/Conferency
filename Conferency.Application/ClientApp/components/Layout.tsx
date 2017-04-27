import * as React from 'react';
import { NavMenu } from './NavMenu';

export interface LayoutProps {
    body: React.ReactElement<any>;
}

export class Layout extends React.Component<LayoutProps, void> {
    public render() {
        return <div className='container'>
                <header>
                    <div className='brand'><a href="/">Conferency</a></div>
                    <NavMenu />
                </header>
                <main>
                    { this.props.body }
                </main>
            </div>;
    }
}
