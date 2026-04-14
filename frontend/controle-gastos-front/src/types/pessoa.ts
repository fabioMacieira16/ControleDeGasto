export interface Pessoa {
  id: number;
  nome: string;
  idade: number;
}

export interface CreatePessoaDTO {
  nome: string;
  idade: number;
}