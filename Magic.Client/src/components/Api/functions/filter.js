import {createSlice} from '@reduxjs/toolkit'

const filterSlice = createSlice({
    name: 'filter',
    initialState: {
        builds: [],
        allBuilds: [],
        stateBuilds: 0
    },
    reducers: {
        setBuilds(state, action) {
            state.allBuilds = action.payload
            state.builds = action.payload
            state.stateBuilds = 1
        },
        filterBuilds(state, action) {
            let builds = state.allBuilds.filter(b => b.includes(action.payload))
            state.builds = builds
        }
    },
})
export const selectState = (state) => state.dataFilter
export const {
    setBuilds,
    filterBuilds
} = filterSlice.actions
export default filterSlice.reducer
