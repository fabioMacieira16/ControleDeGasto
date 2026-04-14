import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { useCreatePessoa, useUpdatePessoa } from "../../hooks/usePessoas";

const schema = z.object({
  nome: z.string().min(1, "Nome obrigatório").max(200),
  idade: z.number().min(0, "Idade inválida"),
});

type FormData = z.infer<typeof schema>;

interface Props {
  pessoa?: any;
  onClose: () => void;
}

export default function PessoaForm({ pessoa, onClose }: Props) {
  const { register, handleSubmit, formState: { errors } } = useForm<FormData>({
    resolver: zodResolver(schema),
    defaultValues: pessoa || {},
  });

  const createMutation = useCreatePessoa();
  const updateMutation = useUpdatePessoa();

  async function onSubmit(data: FormData) {
    if (pessoa) {
      await updateMutation.mutateAsync({ id: pessoa.id, data });
    } else {
      await createMutation.mutateAsync(data);
    }

    onClose();
  }

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div>
        <label>Nome</label>
        <input {...register("nome")} />
        {errors.nome && <p>{errors.nome.message}</p>}
      </div>

      <div>
        <label>Idade</label>
        <input type="number" {...register("idade", { valueAsNumber: true })} />
        {errors.idade && <p>{errors.idade.message}</p>}
      </div>

      <button type="submit">
        {pessoa ? "Atualizar" : "Criar"}
      </button>
    </form>
  );
}