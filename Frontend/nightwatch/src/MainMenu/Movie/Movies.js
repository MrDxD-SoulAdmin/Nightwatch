import React, { useState } from 'react';
import "./Movies.css"
import MovieCall from '../../BackendCall/MovieCall';
export function Movies() {
    const [Moviedata, setMoviedata] = useState([]);
    const [Genredata, SetGenredata] = useState("");
    function GetMoviesByGenre(g) {
        MovieCall.GetAllMovieGenre(g)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                setMoviedata(data);
                SetGenredata(g);
            });
    }
    function ModButt(){
        
    }
    function DelButt(movieid){
        MovieCall.DeleteMovie(movieid)
            .then(data => {
                if (data.status === 200) {
                    alert("Sikeres Törlés!");
                    GetMoviesByGenre(Genredata);
                }else{
                    alert("Sikertelen Törlés!");
                }
            });
    }
    return (
        <div>
            <h1>Movies</h1>
            <div>
                <nav className='GenreMenu'>
                    <ul className='List'>
                        <li onClick={() => GetMoviesByGenre("Action")}>Action</li>
                        <li onClick={() => GetMoviesByGenre("Sci-Fi")}>Sci-Fi</li>
                        <li onClick={() => GetMoviesByGenre("Horror")}>Horror</li>
                        <li onClick={() => GetMoviesByGenre("Comedy")}>Comedy</li>
                        <li onClick={() => GetMoviesByGenre("Mystic/Fantasy")}>Mystic/Fantasy</li>
                        <li id='add' >Add New Movie</li>
                    </ul>
                </nav>
            </div>
            <div className='MovieList'>
                {Moviedata.map((movie, ind) => {
                    return (
                        <div key={ind} className='MovieL'>
                            <img className='simg' src={movie.thumbnailPath?"https://localhost:7293" + movie.thumbnailPath:""} alt={movie.title} />
                            <h3>{movie.title}</h3>
                            <button onClick={() => DelButt(movie.movieId)}>Delete</button>s
                            <button onClick={ModButt}>Modify</button>
                        </div>
                    )
                })}
            </div>
        </div>
    )
}