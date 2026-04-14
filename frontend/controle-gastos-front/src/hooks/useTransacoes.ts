import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { transacaoService } from "../services/transacaoService";
import type { CreateTransacaoDTO } from "../types/transacao";

export function useTransacoes() {
  return useQuery({
    queryKey: ["transacoes"],
    queryFn: transacaoService.getAll,
  });
}

export function useCreateTransacao() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (payload: CreateTransacaoDTO) => transacaoService.create(payload),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["transacoes"] });
    },
  });
}
