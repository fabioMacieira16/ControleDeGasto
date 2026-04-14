import type { InputHTMLAttributes } from "react";

interface Props extends InputHTMLAttributes<HTMLInputElement> {
  label: string;
  error?: string;
}

export function Input({ label, error, id, ...rest }: Props) {
  return (
    <div style={{ display: "flex", flexDirection: "column", gap: 4 }}>
      <label htmlFor={id} style={{ fontWeight: 600, fontSize: 14 }}>
        {label}
      </label>
      <input
        id={id}
        style={{
          padding: "6px 10px",
          border: `1px solid ${error ? "#d32f2f" : "#ccc"}`,
          borderRadius: 4,
          fontSize: 14,
        }}
        {...rest}
      />
      {error && <span style={{ color: "#d32f2f", fontSize: 12 }}>{error}</span>}
    </div>
  );
}
