import type { Pessoa } from "../../../types/pessoa";
import { Button } from "../../../components/Button";

interface Props {
  pessoas: Pessoa[];
  onEdit: (pessoa: Pessoa) => void;
  onDelete: (id: number) => void;
}

export default function PessoaTable({ pessoas, onEdit, onDelete }: Props) {
  return (
    <table style={{ width: "100%", borderCollapse: "collapse", fontSize: 14 }}>
      <thead>
        <tr style={{ background: "#f4f4f4" }}>
          <th style={{ textAlign: "left", padding: "10px 12px", borderBottom: "2px solid #ddd" }}>Nome</th>
          <th style={{ textAlign: "left", padding: "10px 12px", borderBottom: "2px solid #ddd" }}>Idade</th>
          <th style={{ textAlign: "left", padding: "10px 12px", borderBottom: "2px solid #ddd" }}>Ações</th>
        </tr>
      </thead>
      <tbody>
        {pessoas.length === 0 && (
          <tr>
            <td colSpan={3} style={{ textAlign: "center", padding: 20, color: "#999" }}>
              Nenhuma pessoa cadastrada.
            </td>
          </tr>
        )}
        {pessoas.map((p) => (
          <tr key={p.id} style={{ borderBottom: "1px solid #eee" }}>
            <td style={{ padding: "10px 12px" }}>{p.nome}</td>
            <td style={{ padding: "10px 12px" }}>{p.idade}</td>
            <td style={{ padding: "10px 12px", display: "flex", gap: 8 }}>
              <Button variant="secondary" onClick={() => onEdit(p)}>Editar</Button>
              <Button variant="danger" onClick={() => onDelete(p.id)}>Excluir</Button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}