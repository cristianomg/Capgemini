﻿using Com.Capgemini.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Capgemini.Domain.Interfaces.Repositories
{
    public interface IImportacaoRepository
    {
        void Atualizar(Importacao importacao);
        void Deletar(Importacao importacao);
        Importacao Inserir(Importacao importacao);
        Importacao ObterPorId(Guid id);
        Importacao ObterPorId(Guid id, List<string> includes);
        IQueryable<Importacao> ObterTodos();
        IQueryable<Importacao> ObterTodos(params string[] includes);
    }
}
