using System.Collections.Generic;

namespace Com.Capgemini.Domain.Dtos
{
    public class DtoErroImportacao
    {
        public int Linha { get; set; }
        public IEnumerable<string> Columas { get; set; }
    }
}
