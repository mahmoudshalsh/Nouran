using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Nouran.Cities.GetAll
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
        {
            return await mediator.Send(new Request());
        }
    }
    
    public record Request : IRequest<IEnumerable<Model>>;
    
    public class RequestHandler : IRequestHandler<Request, IEnumerable<Model>>
    {
        readonly IMapper mapper;
        
        public RequestHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<IEnumerable<Model>> Handle(Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class Mapper : Profile
    {
        public Mapper()
        {
        }
    }
}