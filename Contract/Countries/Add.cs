using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;

namespace Nouran.Countries.Add
{
    public interface IContract : ICommandContract<Command>
    {
        const string ROUTE_URL = "Countries";
    }

    public record Command(string Title);
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.Title).NotEmpty();
        }
    }
}