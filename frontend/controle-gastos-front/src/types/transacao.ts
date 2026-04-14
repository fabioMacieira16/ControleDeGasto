export enum TipoTransacao {
  DESPESA = 1,
  RECEITA = 2,
}

export const TipoLabel: Record<TipoTransacao, string> = {
  [TipoTransacao.DESPESA]: "Despesa",
  [TipoTransacao.RECEITA]: "Receita",
};

export interface Transacao {
  id: number;
  descricao: string;
  valor: number;
  tipo: TipoTransacao;
  categoriaId: number;
  categoriaDescricao: string;
  pessoaId: number;
  pessoaNome: string;
}

export interface CreateTransacaoDTO {
  descricao: string;
  valor: number;
  tipo: TipoTransacao;
  categoriaId: number;
  pessoaId: number;
}
