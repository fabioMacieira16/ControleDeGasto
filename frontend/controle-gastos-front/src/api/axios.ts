import axios from "axios";

export const api = axios.create({
  baseURL: "http://localhost:5173/api", 
});
 
//interceptador das request 
api.interceptors.request.use((config => {
    return config;
}), (error) => {
    return Promise.reject(error);
});

//interceptador das response
api.interceptors.response.use(
    (response) => response,
    (error) => {
        //tratamento global de erro
        console.error("Erro na Api: ", error.response?.data || error.message)
        
        return Promise.reject(error);
    }
);