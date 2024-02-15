import React from 'react';
import ReactDOM from 'react-dom/client';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import reportWebVitals from './reportWebVitals';
import './index.css';
import Layout from './Pages/Layout/Layout.jsx';
import Registration from './Pages/Registration.jsx';
import Login from './Pages/Login.jsx';
import User from './Pages/User.jsx';
import Home from './Pages/Home.jsx';
import { AuthProvider } from './Components/AuthContext.jsx';
import CreatePoem from './Pages/CreatePoem.jsx';


const router = createBrowserRouter([

  {
    path: '/',
    element: <Layout />,
    // errorElement: <ErrorPage />,
    children: [
      {
        path: '/',
        element: <Home />,
      },
      {
        path: '/Register',
        element: <Registration />,
      },
      {
        path: '/Login',
        element: <Login />,
      },
      {
        path: '/User',
        element: <User />,
      },
      {
        path: '/CreatePoem',
        element: <CreatePoem />,
      }
    ]
  }
]);

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <AuthProvider>
      <RouterProvider router={router}>
        {router.route}
      </RouterProvider>
    </AuthProvider>
  </React.StrictMode>
);


reportWebVitals();