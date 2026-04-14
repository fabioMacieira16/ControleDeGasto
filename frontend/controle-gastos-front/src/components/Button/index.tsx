import type { ButtonHTMLAttributes } from "react";

interface Props extends ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: "primary" | "danger" | "secondary";
}

export function Button({ variant = "primary", children, style, ...rest }: Props) {
  const colors: Record<string, string> = {
    primary: "#1976d2",
    danger: "#d32f2f",
    secondary: "#616161",
  };

  return (
    <button
      style={{
        background: colors[variant],
        color: "#fff",
        border: "none",
        borderRadius: 4,
        padding: "6px 16px",
        cursor: "pointer",
        fontWeight: 600,
        ...style,
      }}
      {...rest}
    >
      {children}
    </button>
  );
}
