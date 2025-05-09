import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5178/api',
});

export default API;
