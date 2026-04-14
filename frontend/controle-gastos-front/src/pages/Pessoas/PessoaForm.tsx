import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import toast from "react-hot-toast";
import type { Pessoa } from "../../types/pessoa";
import { useCreatePessoa, useUpdatePessoa } from "../../hooks/usePessoas";
import { Input } from "../../components/Input";
import { Button } from "../../components/Button";

const schema = z.object({
  nome: z.string().min(1, "Nome obrigatório").max(200, "Máximo 200 caracteres"),
  idade: z.coerce.number({ invalid_type_error: "Idade obrigatória" }).min(0, "Idade inválida"),
});

type FormData = z.infer<typeof schema>;

interface Props {
  pessoa?: Pessoa | null;
  onClose: () => void;
}

export default function PessoaForm({ pessoa, onClose }: Props) {
  const {
    register,
    handleSubmit,
    formState: { errors, isSubmitting },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
    defaultValues: pessoa ?? {},
  });

  const createMutation = useCreatePessoa();
  const updateMutation = useUpdatePessoa();

  async function onSubmit(data: FormData) {
    try {
      if (pessoa) {
        await updateMutation.mutateAsync({ id: pessoa.id, data });
        toast.success("Pessoa atualizada com sucesso!");
      } else {
        await createMutation.mutateAsync(data);
        toast.success("Pessoa criada com sucesso!");
      }
      onClose();
    } catch {
      toast.error("Erro ao salvar pessoa.");
    }
  }

  return (
    <form onSubmit={handleSubmit(onSubmit)} style={{ display: "flex", flexDirection: "column", gap: 16 }}>
      <Input
        id="nome"
        label="Nome"
        {...register("nome")}
        error={errors.nome?.message}
      />

      <Input
        id="idade"
        label="Idade"
        type="number"
        min="0"
        {...register("idade")}
        error={errors.idade?.message}
      />

      <div style={{ display: "flex", gap: 8, justifyContent: "flex-end" }}>
        <Button type="button" variant="secondary" onClick={onClose}>
          Cancelar
        </Button>
        <Button type="submit" disabled={isSubmitting}>
          {pessoa ? "Atualizar" : "Criar"}
        </Button>
      </div>
    </form>
  );
}