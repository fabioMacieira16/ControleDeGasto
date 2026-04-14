import { useRelatorioPessoas } from "../../hooks/useRelatorio";
import type { RelatorioGeral, RelatorioPessoa } from "../../types/relatorio";
import { Table } from "../../components/Table";
import { formatCurrency } from "../../utils/formatCurrency";

export default function RelatorioPessoas() {
  const { data, isLoading, isError } = useRelatorioPessoas();
  const relatorio = data as RelatorioGeral | undefined;

  const columns = [
    { header: "Pessoa", render: (r: RelatorioPessoa) => r.nomePessoa },
    {
      header: "Receitas",
      render: (r: RelatorioPessoa) => (
        <span style={{ color: "#2e7d32" }}>{formatCurrency(r.totalReceitas)}</span>
      ),
    },
    {
      header: "Despesas",
      render: (r: RelatorioPessoa) => (
        <span style={{ color: "#c62828" }}>{formatCurrency(r.totalDespesas)}</span>
      ),
    },
    {
      header: "Saldo",
      render: (r: RelatorioPessoa) => (
        <span style={{ color: r.saldo >= 0 ? "#2e7d32" : "#c62828", fontWeight: 600 }}>
          {formatCurrency(r.saldo)}
        </span>
      ),
    },
  ];

  if (isLoading) return <p>Carregando relatório...</p>;
  if (isError) return <p style={{ color: "#d32f2f" }}>Erro ao carregar relatório.</p>;

  return (
    <div>
      <h1 style={{ marginBottom: 20 }}>Relatório por Pessoa</h1>

      <Table
        columns={columns}
        data={relatorio?.pessoas ?? []}
        keyExtractor={(r: RelatorioPessoa) => r.pessoaId}
      />

      {relatorio && (
        <div
          style={{
            marginTop: 24,
            padding: "16px 20px",
            background: "#f4f4f4",
            borderRadius: 8,
            display: "flex",
            gap: 40,
          }}
        >
          <div>
            <strong>Total Receitas:</strong>{" "}
            <span style={{ color: "#2e7d32" }}>{formatCurrency(relatorio.totalReceitasGeral)}</span>
          </div>
          <div>
            <strong>Total Despesas:</strong>{" "}
            <span style={{ color: "#c62828" }}>{formatCurrency(relatorio.totalDespesasGeral)}</span>
          </div>
          <div>
            <strong>Saldo Geral:</strong>{" "}
            <span style={{ color: relatorio.saldoGeral >= 0 ? "#2e7d32" : "#c62828", fontWeight: 700 }}>
              {formatCurrency(relatorio.saldoGeral)}
            </span>
          </div>
        </div>
      )}
    </div>
  );
}