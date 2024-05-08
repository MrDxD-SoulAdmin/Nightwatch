import React, { useEffect, useState } from 'react';
import "./Movies.css"
import MovieCall from '../../BackendCall/MovieCall';
import { ModifyMovie } from '../Addon/ModifyMovie';
import { useLocation } from 'react-router-dom';
export function Movies() {
    const { state } = useLocation();
    console.log(state);
    const [Moviedata, setMoviedata] = useState([]);
    const [Genredata, SetGenredata] = useState(state?.Genre);
    const [PanelData, setPanelData] = useState("");
    const [Movie, setMovie] = useState("");

    useEffect(() => {
    GetMoviesByGenre(Genredata);
    }, [Genredata]);
    function GetMoviesByGenre(g) {
        MovieCall.GetAllMovieGenre(g)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                setMoviedata(data);
            });
    }
    function ModButt(movieid) {
        setMovie(Moviedata.find(x => x.movieId === movieid));
        setPanelData("Edit");
    }
    function DelButt(movieid) {
        MovieCall.DeleteMovie(movieid)
            .then(data => {
                if (data.status === 200) {
                    alert("Sikeres Törlés!");
                    GetMoviesByGenre(Genredata);
                } else {
                    alert("Sikertelen Törlés!");
                }
            });
    }
    function Reload(Changed = false) {
        setPanelData("");
        if (Changed) {
            GetMoviesByGenre(Genredata);
        }
        
    }
    function GetPanel() {
        switch (PanelData) {
            case "Edit":

                return <ModifyMovie Movie={Movie} Invisible={Reload} />

            default:
                return null;
        }
    }
    return (
        <div>
            <h1>Movies</h1>
            <div>
                <nav className='GenreMenu'>
                    <ul className='List'>
                        <li className={Genredata === "Action"?"Isselected":""} onClick={() => SetGenredata("Action")}>Action</li>
                        <li className={Genredata === "Sci-Fi"?"Isselected":""} onClick={() => SetGenredata("Sci-Fi")}>Sci-Fi</li>
                        <li className={Genredata === "Horror"?"Isselected":""}onClick={() => SetGenredata("Horror")}>Horror</li>
                        <li className={Genredata === "Comedy"?"Isselected":""}onClick={() => SetGenredata("Comedy")}>Comedy</li>
                        <li className={Genredata === "Mystic/Fantasy"?"Isselected":""}onClick={() => SetGenredata("Mystic/Fantasy")}>Mystic/Fantasy</li>
                    </ul>
                </nav>
            </div>
            <div className='MovieList'>
                {Moviedata.map((movie, ind) => {
                    return (
                        <div key={ind} className='MovieL'>
                            <img className='simg' src={movie.thumbnailPath} alt={movie.title} />
                            <h3>{movie.title}</h3>
                            <button id="del" onClick={() => DelButt(movie.movieId)}>Delete</button>
                            <button id='edit' onClick={() => ModButt(movie.movieId)}>Modify</button>
                            <button id='like'>Like</button>
                            <button id='dislike'>Disklie</button>
                        </div>
                    )
                })}
            </div>
            {GetPanel()}
        </div>
    )
}