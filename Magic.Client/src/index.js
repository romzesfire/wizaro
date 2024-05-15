import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import {createRoot} from 'react-dom/client';
import '@reduxjs/toolkit'
import reportWebVitals from './reportWebVitals';
import {ErrorPage} from "./components/Errors/ErrorPage";
import {createBrowserRouter, Navigate, RouterProvider} from "react-router-dom";
import {Root} from "./components/Root.js";
import StartFakeLogin from "./components/MainPage";

const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

const router = createBrowserRouter([
    {
        path: "/",
        element: <Root/>,
        errorElement: <ErrorPage/>,
        children: [
            {
                path: "",
                element: <StartFakeLogin/>
            }
        ]
    }]);

root.render(
    <React.StrictMode>
        <RouterProvider router={router}/>
    </React.StrictMode>
);

reportWebVitals();
