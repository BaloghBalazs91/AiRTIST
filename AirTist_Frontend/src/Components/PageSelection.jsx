import { React, useState } from "react";
import { Link } from 'react-router-dom';
import '../index.css';

const PageSelection = ({ userRole, setLastClickedButton, lastClickedButton }) => {


    const handleClick = (label) => {
        setLastClickedButton(label);
    };

    const roleToLinksMap = {
        "Admin": [
            { link: '/CreatePoem', label: 'Create a Poem' },
            { link: '/MyPoems', label: 'My Poems' },
            { link: '/TopPoems', label: 'TOP Poems' },
            { link: '/BrowsPoems', label: 'Brows Poems' }
        ],
        "User": [
            { link: '/CreatePoem', label: 'Create a Poem' },
            { link: '/MyPoems', label: 'My Poems' },
            { link: '/TopPoems', label: 'TOP Poems' },
            { link: '/BrowsPoems', label: 'Brows Poems' },
        ]
    };


    return (
        <ul className="pageSelection">
            {userRole && roleToLinksMap[userRole] && roleToLinksMap[userRole].map(({ link, label }) => (
                <li key={link}>
                    <Link to={link}>
                        <button onClick={() => handleClick(label)} className={lastClickedButton === label ? 'activeBtn' : 'pageBtn'}>{label}</button>
                    </Link>
                </li>
            ))}
        </ul>
    );
}

export default PageSelection;
