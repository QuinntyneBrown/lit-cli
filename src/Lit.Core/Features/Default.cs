using CommandLine;
using Lit.Core.Scaffolds;
using Lit.Core.Services;
using MediatR;
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
            private readonly ITemplateLocator _templateLocator;

            public Handler(ICommandService commandService, IFileSystem fileSystem, ITemplateLocator templateLocator)
            {
                _commandService = commandService;
                _fileSystem = fileSystem;
                _templateLocator = templateLocator;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var appDirectory = $"{request.Directory}{Path.DirectorySeparatorChar}{request.Name}";

                _commandService.Start($"mkdir {appDirectory}", request.Directory);

                _commandService.Start("npm init", appDirectory);

                _commandService.Start("npm install webpack-cli webpack @webpack-cli/generators style-loader --save-dev", appDirectory);

                _commandService.Start("npm install lit@2.0.0-rc.2 rxjs --save", appDirectory);

                _commandService.Start("npx webpack init", appDirectory);

                _fileSystem.WriteAllLines($"{appDirectory}{Path.DirectorySeparatorChar}tsconfig.json", new TSConfigBuilder().Build(_templateLocator));

                _fileSystem.WriteAllLines($"{appDirectory}{Path.DirectorySeparatorChar}webpack.config.js", new WebpackConfigBuilder().Build(_templateLocator));

                _fileSystem.WriteAllLines($"{appDirectory}{Path.DirectorySeparatorChar}index.html", new IndexBuilder().Build(_templateLocator));

                _commandService.Start("lit g c app", $"{appDirectory}{Path.DirectorySeparatorChar}src");

                _commandService.Start("code .", appDirectory);

                _commandService.Start("npm run serve", appDirectory);

                return new();
            }
        }
    }
}
