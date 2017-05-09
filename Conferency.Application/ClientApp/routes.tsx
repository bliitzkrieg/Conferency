import * as React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home';
import FetchData from './components/FetchData';
import Counter from './components/Counter';
import Talks from './components/Talks';
import Talk from './components/Talk';

export default <Route component={ Layout }>
    <Route path='/' components={{ body: Home }} />
    <Route path='/counter' components={{ body: Counter }} />
    <Route path='/fetchdata' components={{ body: FetchData }}>
        <Route path='(:startDateIndex)' /> { /* Optional route segment that does not affect NavMenu highlighting */ }
    </Route>
    <Route path='/talks' components={{ body: Talks }} />
    <Route path='/talk/:slug/:id' components={{ body: Talk }} /> 
</Route>;

// Enable Hot Module Replacement (HMR)
if (module.hot) {
    module.hot.accept();
}
