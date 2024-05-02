import BaseCall from "./BaseCall";

export default class MovieCall extends BaseCall{
    static GetMovies(){
        return this.Get("/movie/getAllMovies");
    }
    static GetNewMovies(){
        return this.Get("/movie/getNewMovies");
    }
    static GetMovieGenre(genre){
        return this.Get("/movie/GetMoviesWhereGenre?genre="+genre);
    }
    static GetAllMovieGenre(genre){
        return this.Get("/movie/GetAllMoviesWhereGenre?genre="+genre);
    }
    static DeleteMovie(movieid){
        return this.Delete("/movie/DeleteMovie/"+movieid);
    }
}