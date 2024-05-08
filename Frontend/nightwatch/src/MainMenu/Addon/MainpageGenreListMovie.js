import React, { useEffect, useState } from 'react';
import MovieCall from '../../BackendCall/MovieCall';
import { Link } from 'react-router-dom';
export function MainpageGenreListMovie({ Genre }) {
    const [Moviedata, setMoviedata] = useState([]);

    useEffect(() => {
        MovieCall.GetMovieGenre(Genre)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                setMoviedata(data);
            });
    }, [Genre]);

    return (<>
        <div>
            <Link className='Genres' to="/NightWatch/Movies" state={{Genre}} >{Genre}</Link>
        </div>
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
    </>
    )

}