import * as React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home';
import Talks from './components/Talks';
import Talk from './components/Talk';
import CreateTalk from './components/CreateTalk';

export default <Route component={ Layout }>
    <Route path='/' components={{ body: Home }} />
    <Route path='/talks' components={{ body: Talks }} />
    <Route path='/talk/:slug/:id' components={{ body: Talk }} />
    <Route path='/create' components={{ body: CreateTalk }} />
</Route>;

// Enable Hot Module Replacement (HMR)
if (module.hot) {
    module.hot.accept();
}
