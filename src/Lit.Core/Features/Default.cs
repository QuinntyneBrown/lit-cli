using CommandLine;
using Lit.Core.Services;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Lit.Core.Features
{
    internal class Default
    {
        [Verb("default")]
        internal class Request : IRequest<Unit> {
            [Option('n', Required = false)]
            public string Name { get; set; } = "App";

            [Option('d', Required = false)]
            public string Directory { get; set; } = System.Environment.CurrentDirectory;
        }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            private readonly ICommandService _commandService;
            private readonly IFileSystem _fileSystem;

            public Handler(ICommandService commandService, IFileSystem fileSystem)
            {
                _commandService = commandService;
                _fileSystem = fileSystem;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var appDirectory = $"{request.Directory}{Path.DirectorySeparatorChar}{request.Name}";

                _commandService.Start($"mkdir {appDirectory}", request.Directory);

                _commandService.Start("npm init", appDirectory);

                _commandService.Start("npm install webpack-cli webpack @webpack-cli/generators style-loader --save-dev", appDirectory);

                _commandService.Start("npm install lit@2.0.0-rc.2 rxjs --save", appDirectory);

                _commandService.Start("npx webpack init", appDirectory);

                return new();
            }
        }
    }
}
