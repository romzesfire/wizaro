import "./Styles/Root.css"
import {PrimeReactProvider} from 'primereact/api';
import "./Styles/General.css"
import {store} from "./Api/store";
import {Outlet} from "react-router-dom";
import {Provider} from "react-redux";
import NavMenu from "./Menu/NavMenu";
import {classNames} from "primereact/utils";
import 'primeicons/primeicons.css';
import React from "react";
import Footer from "./Menu/Footer";


export function Root() {
    return (
        <PrimeReactProvider>
            <Provider store={store}>
                <NavMenu/>
                <Outlet/>
                <Footer/>
            </Provider>
        </PrimeReactProvider>
    )
}