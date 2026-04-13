import { api } from "../api/axios";

export const pessoaService = {
    getAll: async () => {
        const response = await api.get("/pessoas");
        return response.data;
    },
    
    create: async (pessoa: { nome: string }) => {
        const response = await api.post("/pessoas", pessoa);
        return response.data;
    },
};