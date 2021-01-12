import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:44304/api',
});

export default api;
