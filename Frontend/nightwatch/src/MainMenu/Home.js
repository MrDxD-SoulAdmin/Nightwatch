import React, { useState } from 'react';
import { Link, Outlet } from 'react-router-dom';
import "./Home.css";
export function Home(){
    const [Actuser] = useState(JSON.parse(localStorage.getItem('Userdata')));
    
    return(
        <div className="ConstH">
            <div>
                <nav  className="Menu">
                <h1>NightWatch</h1>
                    <ul className='Links'>
                        <li><Link to={"/NightWatch"}>Home</Link></li>
                        <li><Link to={"/NightWatch/Movies"}>Movies</Link></li>
                        <li><Link to={"/NightWatch/Users"}>Users</Link></li>   
                        <li className='Profil'>
                        <img src={"https://localhost:7293" + Actuser.profilePath} alt="Profile" />
                            <div className='InvisibleMenu'>
                                <ul className='Links'>
                                    <li><Link to={ "/"}> Profil </Link></li>
                                    <li><Link to={ "/"}> Settings </Link></li>
                                    <li><Link to={ "/"}> Sign Out </Link></li>
                                </ul>
                            </div>
                        </li>                  
                    </ul>
                </nav>
            </div>
            <Outlet />

        </div>
    )
}