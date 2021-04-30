using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentValidation;

namespace Nouran.Cities.Add
{
    public interface IContract : ICommandContract<Command>
    {
        const string ROUTE_URL = "Cities";
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