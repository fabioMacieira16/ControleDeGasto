import { useState } from "react";
import { useCategorias } from "../../hooks/useCategorias";
import { FinalidadeLabel } from "../../types/categoria";
import type { Categoria } from "../../types/categoria";
import { Table } from "../../components/Table";
import { Modal } from "../../components/Modal";
import { Button } from "../../components/Button";
import CategoriaForm from "./CategoriaForm";

export default function CategoriasList() {
  const { data, isLoading, isError } = useCategorias();
  const [openForm, setOpenForm] = useState(false);

  const columns = [
    { header: "Descrição", render: (c: Categoria) => c.descricao },
    { header: "Finalidade", render: (c: Categoria) => FinalidadeLabel[c.finalidade] },
  ];

  if (isLoading) return <p>Carregando categorias...</p>;
  if (isError) return <p style={{ color: "#d32f2f" }}>Erro ao carregar categorias.</p>;

  return (
    <div>
      <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center", marginBottom: 20 }}>
        <h1 style={{ margin: 0 }}>Categorias</h1>
        <Button onClick={() => setOpenForm(true)}>Nova Categoria</Button>
      </div>

      <Table
        columns={columns}
        data={data ?? []}
        keyExtractor={(c: Categoria) => c.id}
      />

      {openForm && (
        <Modal title="Nova Categoria" onClose={() => setOpenForm(false)}>
          <CategoriaForm onClose={() => setOpenForm(false)} />
        </Modal>
      )}
    </div>
  );
}