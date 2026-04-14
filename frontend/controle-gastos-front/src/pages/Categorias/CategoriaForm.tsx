import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import toast from "react-hot-toast";
import { FinalidadeCategoria } from "../../types/categoria";
import { useCreateCategoria } from "../../hooks/useCategorias";
import { Input } from "../../components/Input";
import { Select } from "../../components/Select";
import { Button } from "../../components/Button";

const schema = z.object({
  descricao: z.string().min(1, "Descrição obrigatória").max(200),
  finalidade: z.number().min(1, "Finalidade obrigatória"),
});

type FormData = z.infer<typeof schema>;

interface Props {
  onClose: () => void;
}

const finalidadeOptions = [
  { value: FinalidadeCategoria.DESPESA, label: "Despesa" },
  { value: FinalidadeCategoria.RECEITA, label: "Receita" },
  { value: FinalidadeCategoria.AMBAS, label: "Ambas" },
];

export default function CategoriaForm({ onClose }: Props) {
  const {
    register,
    handleSubmit,
    formState: { errors, isSubmitting },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });

  const createMutation = useCreateCategoria();

  async function onSubmit(data: FormData) {
    try {
      await createMutation.mutateAsync(data);
      toast.success("Categoria criada com sucesso!");
      onClose();
    } catch {
      toast.error("Erro ao criar categoria.");
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

      <Select
        id="finalidade"
        label="Finalidade"
        options={finalidadeOptions}
        {...register("finalidade", { setValueAs: (v: string) => Number(v) })}
        error={errors.finalidade?.message}
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
