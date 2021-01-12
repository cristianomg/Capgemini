using Com.Capgemini.Domain.Dtos;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Com.Capgemini.Domain.Interfaces.Services
{
    public interface IImportacaoService
    {
        Task<IEnumerable<DtoErroImportacao>> Importar(MemoryStream memo);
    }
}
