import React from "react";

export function Quote(props) {
    return (
        <div className='quote-card-container'>
            <div id="ct">
                <div className="corner " id="left_top"></div>
                <div className="corner" id="left_bottom"></div>
                <div className="corner" id="right_top"></div>
                <div className="corner" id="right_bottom"></div>
                <span className='quote'>Уинстон Грэхем</span>
                <blockquote>
                    <p className='quote'><i>&ldquo;Мы все заложники судьбы просто потому, что живем на этом
                        свете.&rdquo; </i></p>
                </blockquote>
            </div>
        </div>
    );
}