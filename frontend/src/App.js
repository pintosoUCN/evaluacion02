import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import Products from './Products';

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/Products" element={<Products />} />
        <Route
          path="/"
          element={<Navigate to="/Products" replace />} 
        />
      </Routes>
    </Router>
  );
};

export default App;
