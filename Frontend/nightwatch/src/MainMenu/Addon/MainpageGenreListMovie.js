import React, { useEffect, useState } from 'react';
import MovieCall from '../../BackendCall/MovieCall';
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
            <h2>{Genre}</h2>
        </div>
        <div className="GenredMovie">
            {Moviedata.map((movie, ind) => {
                return (
                    <div key={ind}>
                        <img src={movie.thumbnailPath} alt={movie.title} width={100} />
                        <h3>{movie.title}</h3>
                    </div>
                )
            })}
        </div>
    </>
    )

}