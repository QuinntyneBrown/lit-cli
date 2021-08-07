using Lit.Core.Models;
using Lit.Core.Services;

namespace Lit.Core.Scaffolds
{
    public class PackageBuilder
    {
        private string Name { get; }
        public PackageBuilder(string name)
        {
            Name = name;
        }
        public string[] Build(ITemplateLocator templateLocator, ITemplateProcessor templateProcessor)
        {
            var template = templateLocator.Get(nameof(PackageBuilder));


            var tokens = new TokensBuilder()
                .With(nameof(Name), (Token)Name)
                .Build();

            return templateProcessor.Process(template, tokens);
        }
    }
}
