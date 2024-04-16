import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

const OccasionCategories = () => {
    const [categories, setCategories] = useState([]);

    useEffect(() => {
        
        axios.get('http://localhost:5158/api/OccasionCategories')
            .then(response => {
                setCategories(response.data);
            })
            .catch(error => {
                console.error('Error fetching occasion categories:', error);
                
            });
    }, []);

    return (
        <div>
            <h1>Occasion Categories</h1>
            <ul>
                {categories.map(category => (
                    <li key={category.id}>
                        {/* put mora odgovarati ruti */}
                        <Link to={`/occasions/${category.id}`}>{category.categoryName}</Link>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default OccasionCategories;