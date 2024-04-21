import BaseCall from "./BaseCall";

export default class GenreCall extends BaseCall{
    static GetGenres(){
        return this.Get("/genre/getAllGenre");
    }
}