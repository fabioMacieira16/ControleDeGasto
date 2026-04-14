import { api } from "../api/axios";

export const relatorioService = {
  getPessoas: async () => {
    const { data } = await api.get("/relatorios/pessoas");
    return data;
  },
};
