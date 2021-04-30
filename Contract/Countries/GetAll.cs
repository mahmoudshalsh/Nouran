using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nouran.Countries.GetAll
{
    public interface IContract : IQueryContract<IEnumerable<Model>>
    {
        const string ROUTE_URL = "Countries";
    }

    public record Model(string Name);
}