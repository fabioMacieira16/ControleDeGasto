import { api } from "../api/axios";
import type { CreateCategoriaDTO } from "../types/categoria";

export const categoriaService = {
  getAll: async () => {
    const { data } = await api.get("/categorias");
    return data;
  },

  create: async (payload: CreateCategoriaDTO) => {
    const { data } = await api.post("/categorias", payload);
    return data;
  },
};
