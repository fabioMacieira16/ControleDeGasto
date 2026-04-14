import { useState } from "react";
import { usePessoas, useDeletePessoa } from "../../hooks/usePessoas";
import PessoaTable from "./components/PessoaTable";
import PessoaForm from "./PessoaForm";

export default function PessoasList() {
  const { data, isLoading } = usePessoas();
  const deleteMutation = useDeletePessoa();

  const [selected, setSelected] = useState<any>(null);
  const [openForm, setOpenForm] = useState(false);

  function handleDelete(id: number) {
    if (confirm("Deseja excluir?")) {
      deleteMutation.mutate(id);
    }
  }

  function handleEdit(pessoa: any) {
    setSelected(pessoa);
    setOpenForm(true);
  }

  function handleCreate() {
    setSelected(null);
    setOpenForm(true);
  }

  if (isLoading) return <p>Carregando...</p>;

  return (
    <div>
      <h1>Pessoas</h1>

      <button onClick={handleCreate}>Nova Pessoa</button>

      {openForm && (
        <PessoaForm
          pessoa={selected}
          onClose={() => setOpenForm(false)}
        />
      )}

      <PessoaTable
        pessoas={data || []}
        onEdit={handleEdit}
        onDelete={handleDelete}
      />
    </div>
  );
}