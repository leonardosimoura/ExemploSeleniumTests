using SeleniumVSTS.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeleniumVSTS.UI.Interfaces
{
    public interface IProdutoRepository
    {
        void Adicionar(ProdutoViewModel produto);
        void Atualizar(ProdutoViewModel produto);
        void Remover(ProdutoViewModel produto);
        IEnumerable<ProdutoViewModel> Selecionar();
        ProdutoViewModel ObterPorId(Guid id);
    }
}
