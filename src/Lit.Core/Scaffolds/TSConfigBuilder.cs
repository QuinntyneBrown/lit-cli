using Lit.Core.Services;

namespace Lit.Core.Scaffolds
{
    public class TSConfigBuilder
    {
        public string[] Build(ITemplateLocator templateLocator)
            => templateLocator.Get(nameof(TSConfigBuilder));
    }
}
