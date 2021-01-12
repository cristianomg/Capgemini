using Com.Capgemini.Domain.Entidades;
using Com.Capgemini.Domain.Interfaces.Repositories;
using Com.Capgemini.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.Capgemini.Infra.Repositories
{
    public class ImportacaoRepository : IImportacaoRepository
    {
        private readonly DbSet<Importacao> _dbSet;
        public ImportacaoRepository(CapgeminiContext context)
        {
            _dbSet = context.Set<Importacao>();
        }
        public void Atualizar(Importacao importacao) =>
            _dbSet.Update(importacao);

        public void Deletar(Importacao importacao) =>
            _dbSet.Remove(importacao);

        public Importacao Inserir(Importacao importacao) =>
            _dbSet.Add(importacao).Entity;

        public async Task<Importacao> ObterPorId(Guid id) =>
            await _dbSet.FindAsync(id);


        public async Task<IEnumerable<Importacao>> ObterTodos() =>
            await _dbSet.ToListAsync();
    }
}
