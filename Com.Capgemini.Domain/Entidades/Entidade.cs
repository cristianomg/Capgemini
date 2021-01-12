using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Capgemini.Domain.Entidades
{
    public abstract class Entidade<T>
    {
        public T Id { get; set; }
    }
}
