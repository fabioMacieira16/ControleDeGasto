import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { pessoaService } from "../services/pessoaService";

export function usePessoas() {
  return useQuery({
    queryKey: ["pessoas"],
    queryFn: pessoaService.getAll,
  });
}

export function useCreatePessoa() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: pessoaService.create,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["pessoas"] });
    },
  });
}

export function useUpdatePessoa() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: ({ id, data }: any) =>
      pessoaService.update(id, data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["pessoas"] });
    },
  });
}

export function useDeletePessoa() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: pessoaService.delete,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["pessoas"] });
    },
  });
}