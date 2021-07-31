using CommandLine;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Lit.Core.Features
{
    internal class New
    {
        [Verb("new")]
        internal class Request : IRequest<Unit> {

        }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                return new();
            }
        }
    }
}
