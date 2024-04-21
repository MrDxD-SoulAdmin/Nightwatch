import BaseCall from "./BaseCall";

export default class MovieCall extends BaseCall{
    static GetMovies(){
        return this.Get("/movie/getAllMovies");
    }
}