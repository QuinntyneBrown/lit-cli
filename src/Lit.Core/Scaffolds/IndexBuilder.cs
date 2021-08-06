using Lit.Core.Services;

namespace Lit.Core.Scaffolds
{
    public class IndexBuilder
    {
        public string[] Build(ITemplateLocator templateLocator)
            => templateLocator.Get(nameof(IndexBuilder));
    }
}
