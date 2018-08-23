using SeleniumVSTS.UI.Interfaces;
using SeleniumVSTS.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeleniumVSTS.UI.Imp
{
    public class ProdutoFakeRepository : IProdutoRepository
    {
        private readonly List<ProdutoViewModel> _produtos;

        public ProdutoFakeRepository()
        {
            _produtos = new List<ProdutoViewModel>();
        }

        public void Adicionar(ProdutoViewModel produto)
        {
            _produtos.Add(produto);
        }

        public void Atualizar(ProdutoViewModel produto)
        {
            _produtos.RemoveAll(p => p.ProdutoId == produto.ProdutoId);
            Adicionar(produto);
        }

        public ProdutoViewModel ObterPorId(Guid id)
        {
            return _produtos.FirstOrDefault(f => f.ProdutoId == id);
        }

        public void Remover(ProdutoViewModel produto)
        {
            _produtos.RemoveAll(p => p.ProdutoId == produto.ProdutoId);
        }

        public IEnumerable<ProdutoViewModel> Selecionar()
        {
            return _produtos;
        }
    }
}
