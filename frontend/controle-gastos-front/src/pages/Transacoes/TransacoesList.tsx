import { useState } from "react";
import { useTransacoes } from "../../hooks/useTransacoes";
import type { Transacao } from "../../types/transacao";
import { TipoLabel } from "../../types/transacao";
import { Table } from "../../components/Table";
import { Modal } from "../../components/Modal";
import { Button } from "../../components/Button";
import { formatCurrency } from "../../utils/formatCurrency";
import TransacaoForm from "./TransacaoForm";

export default function TransacoesList() {
  const { data, isLoading, isError } = useTransacoes();
  const [openForm, setOpenForm] = useState(false);

  const columns = [
    { header: "Descrição", render: (t: Transacao) => t.descricao },
    { header: "Valor", render: (t: Transacao) => formatCurrency(t.valor) },
    { header: "Tipo", render: (t: Transacao) => TipoLabel[t.tipo] },
    { header: "Categoria", render: (t: Transacao) => t.categoriaDescricao },
    { header: "Pessoa", render: (t: Transacao) => t.pessoaNome },
  ];

  if (isLoading) return <p>Carregando transações...</p>;
  if (isError) return <p style={{ color: "#d32f2f" }}>Erro ao carregar transações.</p>;

  return (
    <div>
      <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center", marginBottom: 20 }}>
        <h1 style={{ margin: 0 }}>Transações</h1>
        <Button onClick={() => setOpenForm(true)}>Nova Transação</Button>
      </div>

      <Table
        columns={columns}
        data={data ?? []}
        keyExtractor={(t: Transacao) => t.id}
      />

      {openForm && (
        <Modal title="Nova Transação" onClose={() => setOpenForm(false)}>
          <TransacaoForm onClose={() => setOpenForm(false)} />
        </Modal>
      )}
    </div>
  );
}