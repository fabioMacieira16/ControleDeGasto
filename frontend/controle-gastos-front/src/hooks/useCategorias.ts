import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { categoriaService } from "../services/categoriaService";
import type { CreateCategoriaDTO } from "../types/categoria";

export function useCategorias() {
  return useQuery({
    queryKey: ["categorias"],
    queryFn: categoriaService.getAll,
  });
}

export function useCreateCategoria() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (payload: CreateCategoriaDTO) => categoriaService.create(payload),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["categorias"] });
    },
  });
}
