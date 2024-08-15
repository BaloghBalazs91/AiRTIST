import React, { createContext, useContext, useState } from 'react';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [loggedIn, setLoggedIn] = useState(false);
  const [userID, setUserID] = useState(null);

  const login = (Id) => {
    setLoggedIn(true);
    setUserID(localStorage.getItem('Id'));
    console.log('Logging in with ID:', userID);
  };

  const logout = () => {
    setLoggedIn(false);
    setUserID(null); 
  };

  return (
    <AuthContext.Provider value={{ loggedIn, userID, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);
