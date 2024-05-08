import "./login.css";
import React from "react";
import UserCall from "../BackendCall/UserCall";
import { Link } from "react-router-dom";

export function Login() {

    const UserLog = () => {

        const email = document.getElementById("email").value;
        const password = document.getElementById("password").value;
        UserCall.UserLogin(email, password)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                if (!data.message) {
                    localStorage.setItem("Userdata", JSON.stringify(data));
                    window.location.href = "/NightWatch";
                    //alert("Működik!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                } else {
                    alert(data.message);
                }
            });
    }

    function Entered(event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            UserLog();
        }
    }
    return (
    <div className="cont">
        <div class="Login_From_Container">
            <div class="Login_From">
                <h2>Sign In</h2>
                <div class="Input_L">
                    <i class="fa fa-user"></i>
                    <input type="text" placeholder="E-mail" class="Inputs" autocomplete="off" id="email" />
                </div>
                <div class="Input_L">
                    <i class="fa fa-user"></i>
                    <input type="password" placeholder="Password" class="Inputs" autocomplete="off" id="password" onKeyDown={Entered}/>
                </div>
                <div class="SButton" id="Login_Button">
                    <button onClick={UserLog} id="LB">Login</button>
                </div>
                <div class="footer">
                    <Link to={"/user/register"}>Sign Up</Link>
                </div>
            </div>
        </div>
    </div>
    )
}
