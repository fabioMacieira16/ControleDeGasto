import { useState } from "react";
import toast from "react-hot-toast";
import { usePessoas, useDeletePessoa } from "../../hooks/usePessoas";
import type { Pessoa } from "../../types/pessoa";
import PessoaTable from "./components/PessoaTable";
import PessoaForm from "./PessoaForm";
import { Modal } from "../../components/Modal";
import { Button } from "../../components/Button";

export default function PessoasList() {
  const { data, isLoading, isError } = usePessoas();
  const deleteMutation = useDeletePessoa();

  const [selected, setSelected] = useState<Pessoa | null>(null);
  const [openForm, setOpenForm] = useState(false);

  function handleDelete(id: number) {
    if (!window.confirm("Deseja excluir esta pessoa?")) return;
    deleteMutation.mutate(id, {
      onSuccess: () => toast.success("Pessoa excluída com sucesso!"),
      onError: () => toast.error("Erro ao excluir pessoa."),
    });
  }

  function handleEdit(pessoa: Pessoa) {
    setSelected(pessoa);
    setOpenForm(true);
  }

  function handleCreate() {
    setSelected(null);
    setOpenForm(true);
  }

  if (isLoading) return <p>Carregando pessoas...</p>;
  if (isError) return <p style={{ color: "#d32f2f" }}>Erro ao carregar pessoas.</p>;

  return (
    <div>
      <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center", marginBottom: 20 }}>
        <h1 style={{ margin: 0 }}>Pessoas</h1>
        <Button onClick={handleCreate}>Nova Pessoa</Button>
      </div>

      <PessoaTable
        pessoas={data ?? []}
        onEdit={handleEdit}
        onDelete={handleDelete}
      />

      {openForm && (
        <Modal
          title={selected ? "Editar Pessoa" : "Nova Pessoa"}
          onClose={() => setOpenForm(false)}
        >
          <PessoaForm pessoa={selected} onClose={() => setOpenForm(false)} />
        </Modal>
      )}
    </div>
  );
}