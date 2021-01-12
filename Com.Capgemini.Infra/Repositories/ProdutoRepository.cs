using Com.Capgemini.Domain.Entidades;
using Com.Capgemini.Domain.Interfaces.Repositories;
using Com.Capgemini.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.Capgemini.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DbSet<Produto> _dbSet;
        public ProdutoRepository(CapgeminiContext context)
        {
            _dbSet = context.Set<Produto>();
        }
        public void Atualizar(Produto produto) =>
            _dbSet.Update(produto);

        public void Atualizar(List<Produto> produtos) =>
            _dbSet.UpdateRange(produtos);

        public void Deletar(Produto produto) =>
            _dbSet.Remove(produto);

        public Produto Inserir(Produto produto) =>
            _dbSet.Add(produto).Entity;

        public async Task Inserir(List<Produto> produtos)
            => await _dbSet.AddRangeAsync(produtos);

        public async Task<Produto> ObterPorId(Guid id) =>
            await _dbSet.FindAsync(id);


        public async Task<IEnumerable<Produto>> ObterTodos() =>
            await _dbSet.ToListAsync();
    }
}
