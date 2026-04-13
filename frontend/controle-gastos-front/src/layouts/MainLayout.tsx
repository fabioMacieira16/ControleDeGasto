import type { ReactNode } from "react";
import { Link } from "react-router-dom";

interface Props {
  children: ReactNode;
}

export function MainLayout({ children }: Props) {
  return (
    <div style={{ display: "flex" }}>
      <aside style={{ width: 220, background: "#f4f4f4", padding: 20 }}>
        <h3>Menu</h3>
        <nav>
          <ul>
            <li>
              <Link to="/">Dashboard</Link>
            </li>
            <li>
              <Link to="/pessoas">Pessoas</Link>
            </li>
            <li>
              <Link to="/categorias">Categorias</Link>
            </li>
            <li>
              <Link to="/transacoes">Transações</Link>
            </li>
            <li>
              <Link to="/relatorios">Relatórios</Link>
            </li>
          </ul>
        </nav>
      </aside>
      <main style={{ flex: 1, padding: 20 }}>{children}</main>
    </div>
  );
}
