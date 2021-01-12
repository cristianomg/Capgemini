using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Capgemini.Domain.Dtos
{
    public class DtoErroImportacao
    {
        public int Linha { get; set; }
        public IEnumerable<string> Columas { get; set; }
    }
}
