import React from 'react';
import './Home.css';
import logo from './Pictures/AiRTIST_logo.png';

const Home = () => {


    return (
        <div className='home'>
            <img src={logo} alt="logo" className='homeLogo' />
            <div className='homeText'>

                <div className='text-section'>
                    <h3>The Future is Here!</h3>
                    <p>Experience the power of artificial intelligence with our poetry generator application. Whether you're commemorating a special occasion or simply seeking inspiration for a cozy Saturday evening, our AI-powered poet is at your service.
                    </p>

                    <h3>Personalized Poetry for Every Occasion</h3>
                    <p>From birthdays to Christmas, anniversaries to graduations, our application crafts heartfelt verses tailored to any event. Even if you don't consider yourself a poet, now you can compete with literary giants like Shakespeare, Dickinson, and Neruda.
                    </p>
                </div>

                <div className='text-section'>
                    <img src='https://kep.index.hu/1/0/4796/47963/479637/47963718_635b69fb1229db8087c6da14ecc3fec9_wm.jpg' />
                </div>

                <div className='text-section'>
                    <h3>Unleash Your Creativity</h3>
                    <p>Modify generated verses to suit your preferences with our customization feature. Delve into a world of poetic possibilities as you browse through existing poems by theme or explore the highest-rated creations for inspiration.
                    </p>

                    <h3>Share the Gift of Poetry</h3>
                    <p>Surprise your loved ones with a unique and thoughtful gift by presenting them with a personalized poem. Whether it's a digital creation or printed masterpiece, our AI poet ensures that every verse is imbued with sincerity and sentiment.
                    </p>
                </div>

            </div>
        </div>
    )
}
export default Home;