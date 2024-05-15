import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'

export const buildsApi = createApi({
    baseQuery: fetchBaseQuery({
        baseUrl: '/api/Builds/'
    }),
    reducerPath: 'BuildsApi',
    tagTypes: ['Builds'],
    endpoints: (build) => ({
        getOrderedBuildNames: build.query({
            query: () => 'Names',
            providesTags: (result) =>
                result ? result.map((build) => ({type: 'Builds', build})) : []
        })
    })
})
export const {useGetOrderedBuildNamesQuery} = buildsApi