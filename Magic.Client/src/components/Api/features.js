import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'

export const featuresApi = createApi({
    baseQuery: fetchBaseQuery({
        baseUrl: '/api/Features/'
    }),
    reducerPath: 'FeaturesApi',
    tagTypes: ['Features'],
    endpoints: (builder) => ({
        getAllFeatures: builder.query({
            query: () => 'All',
            providesTags: ['Features']
        }),
        createFeature: builder.mutation({
            query: ({body}) => ({
                url: `Create`,
                method: 'POST',
                body: body
            }),
            invalidatesTags: ['Features']
        }),
        updateFeature: builder.mutation({
            query: ({id, body}) => ({
                url: `Update/${id}`,
                method: 'PUT',
                body: body
            }),
            invalidatesTags: ['Features']
        }),
        deleteFeature: builder.mutation({
            query(id) {
                return {
                    url: `${id}`,
                    method: 'DELETE',
                }
            },
            invalidatesTags: ['Features']
        })
    })
})
export const {
    useGetAllFeaturesQuery,
    useCreateFeatureMutation,
    useUpdateFeatureMutation,
    useDeleteFeatureMutation
} = featuresApi