import { useQuery } from "@tanstack/react-query";
import { relatorioService } from "../services/relatorioService";

export function useRelatorioPessoas() {
  return useQuery({
    queryKey: ["relatorio-pessoas"],
    queryFn: relatorioService.getPessoas,
  });
}
