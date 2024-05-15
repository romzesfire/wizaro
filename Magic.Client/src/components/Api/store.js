import {configureStore} from '@reduxjs/toolkit'
import {setupListeners} from '@reduxjs/toolkit/query'
import {runsApi} from './runs'
import {labsApi} from './labs'
import {testsApi} from "./tests";
import {buildsApi} from "./builds";
import filterReducer from "./functions/filter";
import {actionsApi} from "./actions";
import {featuresApi} from "./features";
import {ownersApi} from "./owners";

export const store = configureStore({
        reducer: {
            // Add the generated reducer as a specific top-level slice
            [runsApi.reducerPath]: runsApi.reducer,
            [actionsApi.reducerPath]: actionsApi.reducer,
            [labsApi.reducerPath]: labsApi.reducer,
            [buildsApi.reducerPath]: buildsApi.reducer,
            [featuresApi.reducerPath]: featuresApi.reducer,
            [testsApi.reducerPath]: testsApi.reducer,
            [ownersApi.reducerPath]: ownersApi.reducer,
            dataFilter: filterReducer
        },
        // Adding the api middleware enables caching, invalidation, polling,
        // and other useful features of `rtk-query`.
        middleware: (getDefaultMiddleware) =>
            getDefaultMiddleware()
                .concat(featuresApi.middleware)
                .concat(runsApi.middleware)
                .concat(labsApi.middleware)
                .concat(buildsApi.middleware)
                .concat(testsApi.middleware)
                .concat(actionsApi.middleware)
                .concat(ownersApi.middleware)
    }
)

// optional, but required for refetchOnFocus/refetchOnReconnect behaviors
// see `setupListeners` docs - takes an optional callback as the 2nd arg for customization
setupListeners(store.dispatch)