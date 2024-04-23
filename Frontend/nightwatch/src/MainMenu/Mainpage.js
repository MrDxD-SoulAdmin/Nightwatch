import React, { useEffect, useState } from 'react';
import MovieCall from '../BackendCall/MovieCall';
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
            <div className="newmovie">
                <h2>New movies!</h2>
                {Moviedata.map((movie, ind) => {
                    return (
                        <div key={ind}>
                            <img src={movie.thumbnailPath} alt={movie.title} />
                            <h3>{movie.title}</h3>
                        </div>
                    )
                })}
            </div>
            <div className="movies">
                <h2>Action</h2>
                <h2>Sci-Fi</h2>
                <h2>Horror</h2>
                <h2>Comedy</h2>
                <h2>Mystic/Fantasy</h2>
            </div>
        </div>
    )
}