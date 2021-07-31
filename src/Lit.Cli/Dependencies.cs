using Lit.Core;
using Lit.Core.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Lit.Cli
{
    public static class Dependencies
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddMediatR(typeof(Constants));
            services.AddSingleton<ICommandService, CommandService>();
            services.AddSingleton<IFileSystem, FileSystem>();
            services.AddSingleton<ITemplateLocator, TemplateLocator>();
            services.AddSingleton<ITemplateProcessor, LiquidTemplateProcessor>();
            services.AddSingleton<INamingConventionConverter, NamingConventionConverter>();
            services.AddSingleton<ISettingsProvider, SettingsProvider>();
            services.AddSingleton<ITenseConverter, TenseConverter>();
            services.AddSingleton<IContext, Context>();
        }
    }
}
