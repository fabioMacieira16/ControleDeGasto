import { BrowserRouter, Routes, Route } from "react-router-dom";
import Dashboard from "../pages/Dashboard";
import PessoaList from "../pages/Pessoas/PessoaList";
import CategoriaList from "../pages/Categorias/CategoriaList";
import TransacaoList from "../pages/Transacoes/TransacaoList";
import RelatorioPessoas from "../pages/Relatorios/RelatorioPessoas";

export function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/pessoas" element={<PessoaList />} />
        <Route path="/categorias" element={<CategoriaList />} />
        <Route path="/transacoes" element={<TransacaoList />} />
        <Route path="/relatorios/pessoas" element={<RelatorioPessoas />} />
      </Routes>
    </BrowserRouter>
  );
}
