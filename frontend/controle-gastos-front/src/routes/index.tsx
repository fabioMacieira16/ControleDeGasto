import { BrowserRouter, Routes, Route } from "react-router-dom";
import Dashboard from "../pages/Dashboard/index";
import PessoasList from "../pages/Pessoas/PessoasList";
import CategoriasList from "../pages/Categorias/CategoriasList";
import TransacoesList from "../pages/Transacoes/TransacoesList";
import RelatorioPessoas from "../pages/Relatorios/RelatorioPessoas";

export function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/pessoas" element={<PessoasList />} />
        <Route path="/categorias" element={<CategoriasList />} />
        <Route path="/transacoes" element={<TransacoesList />} />
        <Route path="/relatorios" element={<RelatorioPessoas />} />
      </Routes>
    </BrowserRouter>
  );
}
