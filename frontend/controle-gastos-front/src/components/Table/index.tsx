import type { ReactNode } from "react";

interface Column<T> {
  header: string;
  render: (row: T) => ReactNode;
}

interface Props<T> {
  columns: Column<T>[];
  data: T[];
  keyExtractor: (row: T) => string | number;
}

export function Table<T>({ columns, data, keyExtractor }: Props<T>) {
  if (data.length === 0) {
    return (
      <p style={{ color: "#999", textAlign: "center", padding: 20 }}>
        Nenhum registro encontrado.
      </p>
    );
  }

  return (
    <table style={{ width: "100%", borderCollapse: "collapse", fontSize: 14 }}>
      <thead>
        <tr style={{ background: "#f4f4f4" }}>
          {columns.map((col, i) => (
            <th
              key={i}
              style={{
                textAlign: "left",
                padding: "10px 12px",
                borderBottom: "2px solid #ddd",
                whiteSpace: "nowrap",
              }}
            >
              {col.header}
            </th>
          ))}
        </tr>
      </thead>
      <tbody>
        {data.map((row) => (
          <tr key={keyExtractor(row)} style={{ borderBottom: "1px solid #eee" }}>
            {columns.map((col, i) => (
              <td key={i} style={{ padding: "10px 12px" }}>
                {col.render(row)}
              </td>
            ))}
          </tr>
        ))}
      </tbody>
    </table>
  );
}
