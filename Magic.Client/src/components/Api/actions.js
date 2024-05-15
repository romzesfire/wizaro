import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'

export const actionsApi = createApi({
    baseQuery: fetchBaseQuery({
        baseUrl: '/api/Actions/'
    }),
    reducerPath: 'ActionsApi',
    tagTypes: ['Actions'],
    endpoints: (build) => ({
        getActions: build.query({
            query: (arg) => {
                const {testId} = arg
                return "Get/" + testId;
            },
            providesTags: (result) =>
                result ? result.actions.map(({id}) => ({type: 'Actions', id})) : [],
            transformResponse: (response, meta, arg) => {
                let actions = []
                for (let i = 0; i < response.actions.length; ++i) {
                    actions.push({no: i + 1, action: response.actions[i]})
                }
                response.actions = actions
                return response
            }
        })
    })
})
export const {useGetActionsQuery} = actionsApi