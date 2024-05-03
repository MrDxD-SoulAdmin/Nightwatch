import React, { useState } from 'react';
import MovieCall from '../../BackendCall/MovieCall';
export function ModifyMovie({ Movie, Invisible }) {
    const [ActMovie, setActMovie] = useState(Movie);

    function Submit() {
        const movieId = ActMovie.movieId;
        const title = document.getElementById('title').value();
        const length = document.getElementById('Length').value();
        const ageRating = document.getElementById('AgeRating').value();
        const relased = document.getElementById('Relased').value();
        const filePath = document.getElementById('FilePath').value();
        const tumbnailPath = document.getElementById('TumbnailPath').value();
        const description = document.getElementById('Description').value();
        MovieCall.ModifyMovie(movieId,title, length, ageRating, relased, filePath, tumbnailPath, description)
        .then(data => {
            if (data.status === 200) {
                alert("Modified successfully");
            } else {
                alert("Modify is not Success!");
            }
        });
    }
    return (
        <div class="Modify_From_Container">
            <div class="Modify_From">
                <h2>Modify Movie</h2>
                <div class="Input">
                    <i class="fa fa-user"></i>
                    <input type="text" placeholder="Title" class="Inputs" autocomplete="off" id="title" value={ActMovie.title} />
                </div>
                <div class="Input">
                    <i class="fa fa-user"></i>
                    <input type="time" placeholder="Length" class="Inputs" autocomplete="off" id="Length" value={ActMovie.length} />
                </div>
                <div class="Input">
                    <i class="fa fa-user"></i>
                    <input type="text" placeholder="AgeRating" class="Inputs" autocomplete="off" id="AgeRating" value={ActMovie.ageRating} />
                </div>
                <div class="Input">
                    <i class="fa fa-user"></i>
                    <input type="date" placeholder="Relased" class="Inputs" autocomplete="off" id="Relased" value={ActMovie.relased} />
                </div>
                <div class="Input">
                    <i class="fa fa-user"></i>
                    <input type="text" placeholder="File Path" class="Inputs" autocomplete="off" id="FilePath" value={ActMovie.filePath} />
                </div>
                <div class="Input">
                    <i class="fa fa-user"></i>
                    <input type="text" placeholder="Tumbnail Path" class="Inputs" autocomplete="off" id="TumbnailPath" value={ActMovie.tumbnailPath} />
                </div>
                <div class="Input">
                    <i class="fa fa-user"></i>
                    <input type="text" placeholder="Description" class="Inputs" autocomplete="off" id="Description" value={ActMovie.description} />
                </div>
                <div class="SButton" id="Modify_Button">
                    <button onClick={() => Submit()} id="RB">Modify</button>
                </div>
            </div>
        </div>
    )
}
