import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'

export const runsApi = createApi({
    baseQuery: fetchBaseQuery({
        baseUrl: '/api/Runs'
    }),
    reducerPath: 'RunsApi',
    tagTypes: ['Runs'],
    endpoints: (build) => ({
        getRuns: build.query({
            query: (arg) => {
                const {labId, buildNumber, scopeName, limit, offset} = arg
                let url = "";
                const params = new URLSearchParams(
                    {
                        offset: offset,
                        limit: limit
                    });
                if (labId) {
                    params.append("labId", labId);
                    url = '/Lab';
                } else if (buildNumber) {
                    params.append("buildNumber", buildNumber);
                    url = '/Build';
                } else if (scopeName) {
                    params.append("scopeName", scopeName);
                    url = '/Scope';
                } else {
                    url = '/All';
                }
                return `${url}?${params.toString()}`
            },
            providesTags: (result) =>
                result ? result.runs.map(({id}) => ({type: 'Runs', id})) : []
        }),
        getRunById: build.query({
            query: (arg) => {
                const {runId} = arg
                const params = new URLSearchParams(
                    {
                        id: runId
                    });
                return `?${params.toString()}`
            }
        }),
        getGroupedRunById: build.query({
            query: (arg) => {
                const {runId} = arg
                const params = new URLSearchParams(
                    {
                        id: runId
                    });
                return `/Grouped?${params.toString()}`
            }
        })
    })
})
export const {useGetRunsQuery, useGetRunByIdQuery, useGetGroupedRunByIdQuery} = runsApi