import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'

export const labsApi = createApi({
    baseQuery: fetchBaseQuery({
        baseUrl: '/api/Labs/'
    }),
    reducerPath: 'LabsApi',
    tagTypes: ['Labs', 'GroupedLabs'],
    endpoints: (builder) => ({
        getGroupedLabs: builder.query({
            query: () => 'Grouped',
            providesTags: ['GroupedLabs']
        }),
        getAllLabs: builder.query({
            query: () => 'All',
            providesTags: ['Labs']
        }),
        updateLab: builder.mutation({
            query: ({id, body}) => ({
                url: `Update/${id}`,
                method: 'PUT',
                body: body
            }),
            invalidatesTags: ['Labs', 'GroupedLabs']
        }),
        deleteLab: builder.mutation({
            query({id, key}) {
                return {
                    url: `?id=${id}&securityKey=${key}`,
                    method: 'DELETE',
                }
            },
            invalidatesTags: ['Labs', 'GroupedLabs']
        })
    })
})
export const {useGetAllLabsQuery, useGetGroupedLabsQuery, useUpdateLabMutation, useDeleteLabMutation} = labsApi