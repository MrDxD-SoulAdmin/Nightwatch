import React, { useEffect, useState } from 'react';
import MovieCall from '../BackendCall/MovieCall';
import { MainpageGenreListMovie } from './Addon/MainpageGenreListMovie';
import "./Mainpage.css";
export function Mainpage() {
    const [Moviedata, setMoviedata] = useState([]);
    useEffect(() => {
        MovieCall.GetNewMovies()
            .then(response => response.json())
            .then(data => {
                console.log(data);
                setMoviedata(data);
            });
    }, []);


    return (
        <div className='ConstMP'>
            <h2 className='Head'>New movies:</h2>
            <div className="movieStyle">
                {Moviedata.map((movie, ind) => {
                    return (
                        <div key={ind} className='movielist'>
                            <img className='simg' src={movie.thumbnailPath} alt={movie.title} />
                            <h3>{movie.title}</h3>
                        </div>
                    )
                })}
            </div>
            <div className="movies">
                <div>
                    <MainpageGenreListMovie Genre={"Action"} />
                </div>
                <div>

                    <MainpageGenreListMovie Genre={"Sci-Fi"} />
                </div>
                <div>

                    <MainpageGenreListMovie Genre={"Horror"} />
                </div>
                <div>
                    <MainpageGenreListMovie Genre={"Comedy"} />
                </div>
                <div>

                    <MainpageGenreListMovie Genre={"Mystic/Fantasy"} />
                </div>
            </div>
        </div>
    )
}