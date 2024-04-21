import BaseCall from "./BaseCall";

export default class UserCall extends BaseCall{
    static GetUsers(){
        return this.Get("/user/getAllUsers");
    }
    static UserLogin(email, password){
        return this.Post("/user/login",{Email: email, Password: password});
    }
    static UserRegister(email,username,password,Dob,Profilpic){
        return this.Post("/user/register",{Email: email, Username: username, Password: password, dateofbirth: Dob, Profilpic: Profilpic});
    }
}