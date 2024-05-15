import {Carousel} from 'primereact/carousel';
import {Image} from 'primereact/image';
import img2 from '../../img/t2.png';
import img1 from '../../img/t1.png';
import {Button} from 'primereact/button';
import button from "bootstrap/js/src/button";

const carouselData = [
    {
        image: img1,
        buttonText: "Подробнее...",
        buttonFunction: () => {
        }
    },
    {
        image: img2,
        buttonText: "Подробнее...",
        buttonFunction: () => {
        }
    },
    {
        image: img1,
        buttonText: "Подробнее...",
        buttonFunction: () => {
        }
    },
    {
        image: img2,
        buttonText: "Подробнее...",
        buttonFunction: () => {
        }
    },
    {
        image: img1,
        buttonText: "Подробнее...",
        buttonFunction: () => {
        }
    },
    {
        image: img2,
        buttonText: "Подробнее...",
        buttonFunction: () => {
        }
    },
    {
        image: img1,
        buttonText: "Подробнее...",
        buttonFunction: () => {
        }
    },
    {
        image: img2,
        buttonText: "Подробнее...",
        buttonFunction: () => {
        }
    },
    {
        image: img1,
        buttonText: "Подробнее...",
        buttonFunction: () => {
        }
    },
    {
        image: img2,
        buttonText: "Подробнее...",
        buttonFunction: () => {
        }
    }
];

export function CarouselCard() {
    const template = (data) => {
        return (
            <div className='carousel-data-container'>
                <div className='carousel-data-container-inner'>
                    <img className='carousel-image-container' alt="" src={data.image}/>
                    {data.buttonText ?
                        <div className='carousel-button-container'>
                            <Button className='carousel-button' onClick={data.buttonFunction}>
                                {data.buttonText}
                            </Button>
                        </div> : ""}
                </div>
            </div>)
    }

    return (
        <div className='carousel-main-container'>
            <Carousel className='carousel-main' autoplayInterval={5500} circular={true} value={carouselData} numVisible={1} numScroll={1} itemTemplate={template}/>
        </div>
    );
}