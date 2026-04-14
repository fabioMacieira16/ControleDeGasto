import { api } from "../api/axios";
import type { CreateTransacaoDTO } from "../types/transacao";

export const transacaoService = {
  getAll: async () => {
    const { data } = await api.get("/transacoes");
    return data;
  },

  create: async (payload: CreateTransacaoDTO) => {
    const { data } = await api.post("/transacoes", payload);
    return data;
  },
};
