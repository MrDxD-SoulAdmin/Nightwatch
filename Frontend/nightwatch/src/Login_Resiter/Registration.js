import UserCall from "../BackendCall/UserCall";
import "./Registration.css"
//import React, { useState } from "react";

export function Register() {
    //const [Filedata, setFiledata] = useState(null);
    const UserRegs = () => {

        const email = document.getElementById("email").value;
        const password = document.getElementById("password").value;
        const username = document.getElementById("username").value;
        const birthofdate = document.getElementById("birthofdate").value;

        UserCall.UserRegister(email, username, password, birthofdate)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                if (!data.message) {
                    localStorage.setItem("Userdata", JSON.stringify(data));
                    window.location.href = "/NightWatch";
                    alert("Registration Success!");
                } else {
                    alert(data.message);
                }
            });
    }

    return (
        <div class="Register_From_Container">
            <div class="Register_From">
                <h2>Sign Up</h2>
                <div class="Input">
                    <i class="fa fa-user"></i>
                    <input type="text" placeholder="E-mail" class="Inputs" autocomplete="off" id="email" />
                </div>
                <div className="Input">
                    <i class="fa fa-user"></i>
                    <input type="text" placeholder="Username" class="Inputs" autocomplete="off" id="username" />
                </div>
                <div class="Input">
                    <i class="fa fa-user"></i>
                    <input type="password" placeholder="Password" class="Inputs" autocomplete="off" id="password" />
                </div>
                <div className="Input">
                    <i class="fa fa-user"></i>
                    <input type="Date" class="Inputs" autocomplete="off" id="birthofdate" />
                </div>
                {/* <div className="Input">
                    <i class="fa fa-user"></i>
                    <input type="file" class="Inputs" autocomplete="off" id="Profilepicture" />
                </div> */}
                <div class="SButton" id="Reg_Button">
                    <button onClick={UserRegs} id="RB">Registretion</button>
                </div>
            </div>
        </div>
    )
}