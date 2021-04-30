using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nouran
{
    public interface IQueryContract<T>
    {
        Task<T> Retrieve();
    }
}
