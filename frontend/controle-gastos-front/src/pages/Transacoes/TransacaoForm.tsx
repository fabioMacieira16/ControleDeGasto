import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import toast from "react-hot-toast";
import { TipoTransacao } from "../../types/transacao";
import { FinalidadeCategoria } from "../../types/categoria";
import type { Categoria } from "../../types/categoria";
import type { Pessoa } from "../../types/pessoa";
import { useCreateTransacao } from "../../hooks/useTransacoes";
import { useCategorias } from "../../hooks/useCategorias";
import { usePessoas } from "../../hooks/usePessoas";
import { Input } from "../../components/Input";
import { Select } from "../../components/Select";
import { Button } from "../../components/Button";

const schema = z.object({
  descricao: z.string().min(1, "Descrição obrigatória").max(200),
  valor: z.number().positive("Valor deve ser positivo"),
  tipo: z.number().min(1, "Tipo obrigatório"),
  categoriaId: z.number().min(1, "Categoria obrigatória"),
  pessoaId: z.number().min(1, "Pessoa obrigatória"),
});

type FormData = z.infer<typeof schema>;

interface Props {
  onClose: () => void;
}

export default function TransacaoForm({ onClose }: Props) {
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors, isSubmitting },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });

  const createMutation = useCreateTransacao();
  const { data: categorias = [] } = useCategorias();
  const { data: pessoas = [] } = usePessoas();

  const tipoSelecionado = Number(watch("tipo"));
  const pessoaIdSelecionado = Number(watch("pessoaId"));

  const pessoaSelecionada = (pessoas as Pessoa[]).find((p) => p.id === pessoaIdSelecionado);
  const ehMenorDeIdade = pessoaSelecionada ? pessoaSelecionada.idade < 18 : false;

  // Filtra opções de tipo: menores de 18 não podem lançar RECEITA
  const tipoOptions = [
    { value: TipoTransacao.DESPESA, label: "Despesa" },
    ...(ehMenorDeIdade ? [] : [{ value: TipoTransacao.RECEITA, label: "Receita" }]),
  ];

  // Filtra categorias compatíveis com o tipo selecionado
  const categoriasFiltradas = (categorias as Categoria[]).filter((c) => {
    if (!tipoSelecionado) return true;
    if (c.finalidade === FinalidadeCategoria.AMBAS) return true;
    if (tipoSelecionado === TipoTransacao.DESPESA) return c.finalidade === FinalidadeCategoria.DESPESA;
    if (tipoSelecionado === TipoTransacao.RECEITA) return c.finalidade === FinalidadeCategoria.RECEITA;
    return true;
  });

  const pessoaOptions = (pessoas as Pessoa[]).map((p) => ({
    value: p.id,
    label: `${p.nome} (${p.idade} anos)`,
  }));

  const categoriaOptions = categoriasFiltradas.map((c) => ({
    value: c.id,
    label: c.descricao,
  }));

  async function onSubmit(data: FormData) {
    try {
      await createMutation.mutateAsync(data);
      toast.success("Transação criada com sucesso!");
      onClose();
    } catch {
      toast.error("Erro ao criar transação.");
    }
  }

  return (
    <form onSubmit={handleSubmit(onSubmit)} style={{ display: "flex", flexDirection: "column", gap: 16 }}>
      <Input
        id="descricao"
        label="Descrição"
        {...register("descricao")}
        error={errors.descricao?.message}
      />

      <Input
        id="valor"
        label="Valor (R$)"
        type="number"
        step="0.01"
        min="0.01"
        {...register("valor", { setValueAs: (v: string) => Number(v) })}
        error={errors.valor?.message}
      />

      <Select
        id="pessoaId"
        label="Pessoa"
        options={pessoaOptions}
        {...register("pessoaId", { setValueAs: (v: string) => Number(v) })}
        error={errors.pessoaId?.message}
      />

      <Select
        id="tipo"
        label="Tipo"
        options={tipoOptions}
        {...register("tipo", { setValueAs: (v: string) => Number(v) })}
        error={errors.tipo?.message}
      />

      {ehMenorDeIdade && (
        <p style={{ color: "#e65100", fontSize: 13, margin: 0 }}>
          ⚠️ Menores de 18 anos só podem registrar despesas.
        </p>
      )}

      <Select
        id="categoriaId"
        label="Categoria"
        options={categoriaOptions}
        {...register("categoriaId", { setValueAs: (v: string) => Number(v) })}
        error={errors.categoriaId?.message}
      />

      <div style={{ display: "flex", gap: 8, justifyContent: "flex-end" }}>
        <Button type="button" variant="secondary" onClick={onClose}>
          Cancelar
        </Button>
        <Button type="submit" disabled={isSubmitting}>
          Criar
        </Button>
      </div>
    </form>
  );
}
