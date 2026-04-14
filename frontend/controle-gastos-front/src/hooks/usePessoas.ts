import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { pessoaService } from "../services/pessoaService";
import type { CreatePessoaDTO } from "../types/pessoa";

export function usePessoas() {
  return useQuery({
    queryKey: ["pessoas"],
    queryFn: pessoaService.getAll,
  });
}

export function useCreatePessoa() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (payload: CreatePessoaDTO) => pessoaService.create(payload),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["pessoas"] });
    },
  });
}

export function useUpdatePessoa() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: ({ id, data }: { id: number; data: CreatePessoaDTO }) =>
      pessoaService.update(id, data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["pessoas"] });
    },
  });
}

export function useDeletePessoa() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (id: number) => pessoaService.delete(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["pessoas"] });
    },
  });
}