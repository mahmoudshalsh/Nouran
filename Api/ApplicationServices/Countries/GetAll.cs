using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nouran.Domain.Entities;
using Nouran.Infrastructure.Persistence;

namespace Nouran.Countries.GetAll
{
    [ApiController]
    public class Controller : ControllerBase, IContract
    {
        readonly IMediator mediator;

        public Controller(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(IContract.ROUTE_URL)]
        public async Task<IEnumerable<Model>> Retrieve()
            => await mediator.Send(new Request());
    }

    public record Request : IRequest<IEnumerable<Model>>;

    public class RequestHandler : IRequestHandler<Request, IEnumerable<Model>>
    {
        readonly DbContext context;
        readonly IMapper mapper;

        public RequestHandler(NouranDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Model>> Handle(Request request, CancellationToken cancellationToken)
        {
            var set = context.Set<Country>();
            return await Task.FromResult(mapper.Map<IEnumerable<Model>>(set));
        }
    }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Country, Model>()
                .ConstructUsing(e => new Model(e.Title));
        }
    }
}
