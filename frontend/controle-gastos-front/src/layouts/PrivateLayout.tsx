import type { ReactNode } from "react";
import { Navigate } from "react-router-dom";

interface Props {
  children: ReactNode;
  isAuthenticated?: boolean;
}

/**
 * PrivateLayout — envolve rotas que exigem autenticação.
 * Redireciona para "/" caso não autenticado.
 * Por padrão, isAuthenticated=true enquanto não há sistema de login.
 */
export function PrivateLayout({ children, isAuthenticated = true }: Props) {
  if (!isAuthenticated) {
    return <Navigate to="/" replace />;
  }

  return <>{children}</>;
}
