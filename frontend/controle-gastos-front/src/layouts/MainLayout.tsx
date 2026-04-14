import type { ReactNode } from "react";
import { Link, useLocation } from "react-router-dom";

interface Props {
  children: ReactNode;
}

const navItems = [
  { to: "/", label: "Dashboard" },
  { to: "/pessoas", label: "Pessoas" },
  { to: "/categorias", label: "Categorias" },
  { to: "/transacoes", label: "Transações" },
  { to: "/relatorios", label: "Relatórios" },
];

export function MainLayout({ children }: Props) {
  const { pathname } = useLocation();

  return (
    <div style={{ display: "flex", minHeight: "100vh", fontFamily: "sans-serif" }}>
      <aside
        style={{
          width: 220,
          background: "#1e1e2e",
          color: "#fff",
          padding: "24px 0",
          flexShrink: 0,
        }}
      >
        <div style={{ padding: "0 20px 24px", borderBottom: "1px solid #333" }}>
          <h2 style={{ margin: 0, fontSize: 16, color: "#90caf9" }}>💰 Controle de Gastos</h2>
        </div>
        <nav style={{ marginTop: 16 }}>
          <ul style={{ listStyle: "none", padding: 0, margin: 0 }}>
            {navItems.map((item) => {
              const active = pathname === item.to;
              return (
                <li key={item.to}>
                  <Link
                    to={item.to}
                    style={{
                      display: "block",
                      padding: "10px 20px",
                      color: active ? "#90caf9" : "#ccc",
                      textDecoration: "none",
                      background: active ? "rgba(144,202,249,0.1)" : "transparent",
                      borderLeft: active ? "3px solid #90caf9" : "3px solid transparent",
                      fontWeight: active ? 600 : 400,
                    }}
                  >
                    {item.label}
                  </Link>
                </li>
              );
            })}
          </ul>
        </nav>
      </aside>

      <div style={{ flex: 1, display: "flex", flexDirection: "column" }}>
        <header
          style={{
            background: "#fff",
            borderBottom: "1px solid #e0e0e0",
            padding: "14px 24px",
            fontWeight: 600,
            fontSize: 15,
            color: "#333",
          }}
        >
          {navItems.find((item) => item.to === pathname)?.label ?? "Controle de Gastos"}
        </header>
        <main style={{ flex: 1, padding: 24, background: "#f9f9f9" }}>{children}</main>
      </div>
    </div>
  );
}
