import React, {useState, useEffect} from 'react'
import "../components/Styles/BgAnimation.css"
import {CarouselCard} from './MainPageComponents/CarouselMain.js';
import {Card} from 'primereact/card';
import {PanelMenu} from 'primereact/panelmenu';
import '../components/Styles/CardAnimation.css'
import {AnimatedCard} from "./MainPageComponents/AnimatedCard";
import scorpio from '../img/scorpio.png'
import {Button} from "primereact/button";
import { Divider } from 'primereact/divider';

function MainPage(props) {
    const footer = (
        <div className='footer-card-quote quote-text'>
            Уинстон Грэхем
        </div>)
    return (
        <div>
            <div className='main-bg-image'>
                <h4 className='main-text-header'>Приоткрой завесу судьбы</h4>
                <h5 className='main-text-description'>Простой расклад от опытного таролога по супернизкой
                    цене!</h5>
            </div>
            <div className='main-shadow'/>
            <div className='center-body-container'>
                <div className='options-container-main'>
                    <div className='options-container'>
                        <h4 className='options-text-header'>Что мы предлагаем</h4>
                        <h5 className='options-text-description'>Некоторые направления нашей работы</h5>
                    </div>
                    <div className='responsive-card-list'>
                        <Card id='first-card-main' className='responsive-card'>
                            <p>Таро</p>
                        </Card>
                        <Card id='second-card-main' className='responsive-card'>
                            <p>Астрология</p>
                        </Card>
                        <Card id='third-card-main' className='responsive-card'>
                            <p>Амулеты</p>
                        </Card>
                    </div>
                </div>
            </div>
            <Divider/>
            <div className='title-center-container'>
            </div>
            <div className='blog-container-main'>
                <div className='blog-img-container'>

                </div>
            </div>
        </div>
    )
}

export default MainPage