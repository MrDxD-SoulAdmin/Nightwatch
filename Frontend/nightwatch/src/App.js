import './App.css';
import React from 'react';
import { BrowserRouter, Routes, Route } from'react-router-dom';
import { Login } from './Login_Resiter/Login';
import { Register } from './Login_Resiter/Registration';
import { Home } from './MainMenu/Home';
import { Mainpage } from './MainMenu/Mainpage';
import { Movies } from './MainMenu/Movie/Movies';
import { Users } from './MainMenu/Users/Users';

function App() {

  return (
    <BrowserRouter>
      <Routes>
          <Route index element={<Login />} />
          <Route path="/user/register" element={<Register />} />
          <Route path="NightWatch" element={<Home />}> 
            <Route index element={<Mainpage />} />
            <Route path="Movies" element={<Movies />} />
            <Route path="Users" element={<Users />} />
            <Route path="*" element={<Mainpage />} />
          </Route>
          <Route path="*" element={<Login />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
