using Com.Capgemini.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.Capgemini.Domain.Interfaces.Repositories
{
    public interface IImportacaoRepository
    {
        void Atualizar(Importacao importacao);
        void Deletar(Importacao importacao);
        Importacao Inserir(Importacao importacao);
        Task<Importacao> ObterPorId(Guid id);
        Task<IEnumerable<Importacao>> ObterTodos();
    }
}
