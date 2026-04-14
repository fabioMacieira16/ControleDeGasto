import { api } from "../api/axios";
import type { CreatePessoaDTO } from "../types/pessoa";

export const pessoaService = {
  getAll: async () => {
    const { data } = await api.get("/pessoas");
    return data;
  },

  getById: async (id: number) => {
    const { data } = await api.get(`/pessoas/${id}`);
    return data;
  },

  create: async (payload: CreatePessoaDTO) => {
    const { data } = await api.post("/pessoas", payload);
    return data;
  },

  update: async (id: number, payload: CreatePessoaDTO) => {
    const { data } = await api.put(`/pessoas/${id}`, payload);
    return data;
  },

  delete: async (id: number) => {
    await api.delete(`/pessoas/${id}`);
  },
};