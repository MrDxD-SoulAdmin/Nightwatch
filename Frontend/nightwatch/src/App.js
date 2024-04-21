import './App.css';
//import { Login } from './Login_Resiter/Login';
import { Register } from './Login_Resiter/Registration';


function App() {
  /*const GetUsers = () => {
    UserCall.GetUsers()
     .then(response => response.json())
     .then(data => console.log(data));
  };
  const GetMovies = () => {
    MovieCall.GetMovies()
     .then(response => response.json())
     .then(data => console.log(data));
  };
  const GetGenres = () => {
    GenreCall.GetGenres()
     .then(response => response.json())
     .then(data => console.log(data));
  };*/


  return (
    //<Login></Login>
    <Register></Register>
  );
}

export default App;
