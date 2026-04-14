interface Props {
  pessoas: any[];
  onEdit: (pessoa: any) => void;
  onDelete: (id: number) => void;
}

export default function PessoaTable({ pessoas, onEdit, onDelete }: Props) {
  return (
    <table border={1}>
      <thead>
        <tr>
          <th>Nome</th>
          <th>Idade</th>
          <th>Ações</th>
        </tr>
      </thead>

      <tbody>
        {pessoas.map((p) => (
          <tr key={p.id}>
            <td>{p.nome}</td>
            <td>{p.idade}</td>
            <td>
              <button onClick={() => onEdit(p)}>Editar</button>
              <button onClick={() => onDelete(p.id)}>Excluir</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}