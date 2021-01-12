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
        void Inserir(List<Produto> produtos);
        Produto ObterPorId(Guid id);
        IEnumerable<Produto> ObterTodos();
    }
}
