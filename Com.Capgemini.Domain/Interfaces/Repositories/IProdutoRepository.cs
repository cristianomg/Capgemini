using Com.Capgemini.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.Capgemini.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        void Atualizar(Produto produto);
        void Atualizar(List<Produto> produtos);
        void Deletar(Produto produto);
        Produto Inserir(Produto produto);
        Task Inserir(List<Produto> produtos);
        Task<Produto> ObterPorId(Guid id);
        Task<IEnumerable<Produto>> ObterTodos();
    }
}
