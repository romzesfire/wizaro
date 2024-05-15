import React, {useState} from 'react';
import {PanelMenu} from "primereact/panelmenu";
import {Button} from 'primereact/button';
import {Divider} from 'primereact/divider';
import '../Styles/Footer.css'

export default function Footer() {
    return (
        <div className="footer-main">
            <div className="contain-footer">
                <div className="col-footer">
                    <h1>О нас</h1>
                    <ul>
                        <li>О нас</li>
                        <li>Контакты</li>
                        <li>Пользовательское соглашение</li>
                    </ul>
                </div>
                <div className="col-footer">
                    <h1>Товары и услуги</h1>
                    <ul>
                        <li>Товары</li>
                        <li>Услуги</li>
                        <li>Доставка и оплата</li>
                    </ul>
                </div>
                <div className="col-footer">
                    <h1>Поддержка</h1>
                    <ul>
                        <li>Напишите нам</li>
                    </ul>
                </div>
                <div className="clearfix"></div>
            </div>
        </div>);
}