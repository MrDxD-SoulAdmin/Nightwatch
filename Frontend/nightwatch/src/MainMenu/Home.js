import React from 'react';
import { Link, Outlet } from 'react-router-dom';
export function Home(){
    return(
        <div className="ConstH">
            <h1>Home Page</h1>
            <div className="navbar">
                <nav>
                    <ul>
                        <li><Link to={"/NightWatch"}>Home</Link></li>
                        <li><Link to={"/NightWatch/Movies"}>Movies</Link></li>
                        <li><Link to={"/NightWatch/Users"}>Users</Link></li>                        
                    </ul>
                </nav>
            </div>
            <Outlet />

        </div>
    )
}