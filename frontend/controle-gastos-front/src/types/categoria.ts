export enum FinalidadeCategoria {
  DESPESA = 1,
  RECEITA = 2,
  AMBAS = 3,
}

export const FinalidadeLabel: Record<FinalidadeCategoria, string> = {
  [FinalidadeCategoria.DESPESA]: "Despesa",
  [FinalidadeCategoria.RECEITA]: "Receita",
  [FinalidadeCategoria.AMBAS]: "Ambas",
};

export interface Categoria {
  id: number;
  descricao: string;
  finalidade: FinalidadeCategoria;
}

export interface CreateCategoriaDTO {
  descricao: string;
  finalidade: FinalidadeCategoria;
}
