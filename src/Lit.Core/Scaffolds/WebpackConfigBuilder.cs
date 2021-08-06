using Lit.Core.Services;

namespace Lit.Core.Scaffolds
{
    public class WebpackConfigBuilder
    {
        public string[] Build(ITemplateLocator templateLocator)
            => templateLocator.Get(nameof(WebpackConfigBuilder));
    }
}
