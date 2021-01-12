using Com.Capgemini.Domain.Entidades;
using Com.Capgemini.Domain.Interfaces.Repositories;
using Com.Capgemini.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Importacao ObterPorId(Guid id) =>
            _dbSet.Find(id);

        public Importacao ObterPorId(Guid id, List<string> includes)
        {
            var dados = _dbSet.AsQueryable();
            foreach (var x in includes)
            {
                dados.Include(x);
            }
            return _dbSet.Find(id);
        }
        public IQueryable<Importacao> ObterTodos() =>
            _dbSet.AsQueryable();

        public IQueryable<Importacao> ObterTodos(params string[] includes)
        {
            var dados = _dbSet.AsQueryable();

            foreach(var x in includes)
            {
                dados.Include(x);
            }
            return dados;
        }
    }
}
