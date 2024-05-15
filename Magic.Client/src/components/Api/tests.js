import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'

export const testsApi = createApi({
    baseQuery: fetchBaseQuery({
        baseUrl: '/api/Tests/'
    }),
    reducerPath: 'TestsApi',
    tagTypes: ['AllTests', 'Suites', 'SuiteTests', 'Test', 'TestsFeatures', 'TestsByTags'],
    endpoints: (builder) => ({
        getTests: builder.query({
            query: (args) => {
                const {substring, limit, offset, ownerIds} = args
                const params = new URLSearchParams(
                    {
                        offset: offset,
                        limit: limit
                    });
                if (substring && substring !== "") {
                    params.append("substring", substring)
                }
                if (ownerIds) {
                    for (let i = 0; i < ownerIds.length; ++i) {
                        params.append("ownerIds", ownerIds[i])
                    }
                }
                return `?${params.toString()}`
            },
            providesTags: ['AllTests']
        }),
        getAllSuites: builder.query({
            query: () => 'Suites',
            providesTags: ['Suites']
        }),
        getTestById: builder.query({
            query: (id) => `${id}`,
            providesTags: ['Test']
        }),
        getTestsBySuite: builder.query({
            query: (suite) => `${suite}`,
            providesTags: ['SuiteTests']
        }),
        getTestsByTags: builder.query({
            query: (tags) => {
                let url = "Tags";
                const params = new URLSearchParams();
                for (let i = 0; i < tags.length; ++i) {
                    params.append("tagIds", tags[i]);
                }
                url = `${url}?${params.toString()}`
                return url
            },
            providesTags: ['TestsByTags']
        }),
        setTestsFeatures: builder.mutation({
            query: (body) => ({
                url: `TestsFeatures`,
                method: 'PATCH',
                body: body
            })
        }),
        addTestsFeatures: builder.mutation({
            query: (body) => ({
                url: `TestsFeatures`,
                method: 'PUT',
                body: body
            })
        }),
        getTestHistory: builder.query({
            query: (arg) => {
                const {testId, limit, offset, substring} = arg
                let url = "History";
                const params = new URLSearchParams(
                    {
                        offset: offset,
                        limit: limit,
                        testId: testId
                    });

                if (substring)
                    params.append("substring", substring)

                url = `${url}?${params.toString()}`
                return url
            }
        }),
        getTestDurationHistory: builder.query({
            query: (arg) => {
                const {testId, labId} = arg
                let url = "History/Duration";
                const params = new URLSearchParams(
                    {
                        testId: testId,
                        count: "100",
                    });
                if (labId)
                    params.append("labId", labId)
                url = `${url}?${params.toString()}`
                return url
            }
        }),
        assignOwners: builder.mutation({
            query: (body) => ({
                url: `Owners/Assign`,
                method: 'PATCH',
                body: body
            }),
            invalidatesTags: ['AllTests', 'Suites', 'SuiteTests', 'Test', 'TestsFeatures', 'TestsByTags']
        }),
        clearOwners: builder.mutation({
            query: (body) => ({
                url: `Owners/Clear`,
                method: 'PATCH',
                body: body
            }),
            invalidatesTags: ['AllTests', 'Suites', 'SuiteTests', 'Test', 'TestsFeatures', 'TestsByTags']
        }),
    }),
});
export const {
    useGetTestsQuery,
    useGetAllSuitesQuery,
    useGetTestByIdQuery,
    useGetTestsBySuiteQuery,
    useGetTestsByTagsQuery,
    useGetTestHistoryQuery,
    useGetTestDurationHistoryQuery,
    useSetTestsFeaturesMutation,
    useAddTestsFeaturesMutation,
    useAssignOwnersMutation,
    useClearOwnersMutation
} = testsApi