using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nouran.Cities.GetAll
{
    public interface IContract : IQueryContract<IEnumerable<Model>>
    {
        const string ROUTE_URL = "Cities";
    }

    public record Model(string Name);
}