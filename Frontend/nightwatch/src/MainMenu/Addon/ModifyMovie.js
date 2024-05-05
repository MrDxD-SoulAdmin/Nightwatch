import React, { useEffect, useState } from 'react';
import MovieCall from '../../BackendCall/MovieCall';
import "./ModifyMovie.css";
export function ModifyMovie({ Movie, Invisible }) {
    const [ActMovie, setActMovie] = useState(Movie);

    useEffect(() => {
        function handleKeyDown(e) {
            //27 is the key code for Escape
            if (e.keyCode === 27) {
                Invisible(false);
            }
        }

        document.addEventListener('keydown', handleKeyDown);

        return function cleanup() {
            document.removeEventListener('keydown', handleKeyDown);
        };
    }, [Invisible]);

    function Submit() {
        const movieId = ActMovie.movieId;
        const title = document.getElementById('title').value;
        const length = document.getElementById('Length').value;
        const ageRating = document.getElementById('AgeRating').value;
        const relased = document.getElementById('Relased').value;
        const filePath = document.getElementById('FilePath').value;
        const tumbnailPath = document.getElementById('TumbnailPath').value;
        const description = document.getElementById('Description').value;
        MovieCall.ModifyMovie(movieId,title, length, ageRating, relased, filePath, tumbnailPath, description)
        .then(data => {
            if (data.status === 200) {
                alert("Modified successfully");
                Invisible(true);
            } else {
                alert("Modify is not Success!");
            }
        });
    }
    console.log(Movie);
    return (
        <div className="Modify_From_Container">
            <div className="Modify_From">
                <h2>Modify Movie</h2>
                <label className='Label_M'>Title</label>
                <div className="Input_M">
                    <i className="fa fa-user"></i>
                    <input type="text" placeholder="Title" className="Inputs" autoComplete="off" id="title" defaultValue={ActMovie.title} />
                </div>
                <label className='Label_M'>Length</label>
                <div className="Input_M">
                    <i className="fa fa-user"></i>
                    <input type="time" placeholder="Length" className="Inputs" autoComplete="off" id="Length" defaultValue={ActMovie.length} />
                </div>
                <label className='Label_M'>AgeRating</label>
                <div className="Input_M">
                    <i className="fa fa-user"></i>
                    <input type="text" placeholder="AgeRating" className="Inputs" autoComplete="off" id="AgeRating" defaultValue={ActMovie.ageRating} />
                </div>
                <label className='Label_M'>Relased</label>
                <div className="Input_M">
                    <i className="fa fa-user"></i>
                    <input type="date" placeholder="Relased" className="Inputs" autoComplete="off" id="Relased" defaultValue={ActMovie.relasedOn} />
                </div>
                <label className='Label_M'>File Path</label>
                <div className="Input_M">
                    <i className="fa fa-user"></i>
                    <input type="text" placeholder="File Path" className="Inputs" autoComplete="off" id="FilePath" defaultValue={ActMovie.filePath} />
                </div>
                <label className='Label_M'>Tumbnail Path</label>
                <div className="Input_M">
                    <i className="fa fa-user"></i>
                    <input type="text" placeholder="Tumbnail Path" className="Inputs" autoComplete="off" id="TumbnailPath" defaultValue={ActMovie.thumbnailPath} />
                </div>
                <label className='Label_M'>Description</label>
                <div className="Input_M">
                    <i className="fa fa-user"></i>
                    <input type="text" placeholder="Description" className="Inputs" autoComplete="off" id="Description" defaultValue={ActMovie.description??""} />
                </div>
                <div className="SButton" id="Modify_Button">
                    <button onClick={() => Submit()} id="RB">Modify</button>
                </div>
            </div>
        </div>
    )
}
