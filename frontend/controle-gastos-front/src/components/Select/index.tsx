import type { SelectHTMLAttributes } from "react";

interface Option {
  value: string | number;
  label: string;
}

interface Props extends SelectHTMLAttributes<HTMLSelectElement> {
  label: string;
  options: Option[];
  error?: string;
}

export function Select({ label, options, error, id, ...rest }: Props) {
  return (
    <div style={{ display: "flex", flexDirection: "column", gap: 4 }}>
      <label htmlFor={id} style={{ fontWeight: 600, fontSize: 14 }}>
        {label}
      </label>
      <select
        id={id}
        style={{
          padding: "6px 10px",
          border: `1px solid ${error ? "#d32f2f" : "#ccc"}`,
          borderRadius: 4,
          fontSize: 14,
          background: "#fff",
        }}
        {...rest}
      >
        <option value="">Selecione...</option>
        {options.map((opt) => (
          <option key={opt.value} value={opt.value}>
            {opt.label}
          </option>
        ))}
      </select>
      {error && <span style={{ color: "#d32f2f", fontSize: 12 }}>{error}</span>}
    </div>
  );
}
