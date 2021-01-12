﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Capgemini.Domain.Entidades
{
    public class Importacao : Entidade<Guid>
    {
        public DateTime DtImportacao { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

    }
}
