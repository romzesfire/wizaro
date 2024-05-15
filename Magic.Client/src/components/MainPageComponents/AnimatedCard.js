import img1 from '../../img/t1.png';
import {Button} from 'primereact/button';
import button from "bootstrap/js/src/button";
import React from "react";

export function AnimatedCard(props) {
    return (
        <div>
            <img className='card-main-image' alt="" src={props.image}/>
        </div>
    );
}