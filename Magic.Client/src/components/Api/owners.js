import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'

export const ownersApi = createApi({
    baseQuery: fetchBaseQuery({
        baseUrl: '/api/Owners/'
    }),
    reducerPath: 'OwnersApi',
    tagTypes: ['Owners'],
    endpoints: (builder) => ({
        getAllOwners: builder.query({
            query: () => 'All',
            providesTags: ['Owners']
        }),
        createOwner: builder.mutation({
            query: ({body}) => ({
                url: `Create`,
                method: 'POST',
                body: body
            }),
            invalidatesTags: ['Owners']
        }),
        updateOwner: builder.mutation({
            query: ({id, body}) => ({
                url: `Update/${id}`,
                method: 'PUT',
                body: body
            }),
            invalidatesTags: ['Owners']
        }),
        deleteOwner: builder.mutation({
            query(id) {
                return {
                    url: `${id}`,
                    method: 'DELETE',
                }
            },
            invalidatesTags: ['Owners']
        })
    })
})
export const {
    useGetAllOwnersQuery,
    useCreateOwnerMutation,
    useUpdateOwnerMutation,
    useDeleteOwnerMutation
} = ownersApi