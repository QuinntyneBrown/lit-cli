using Lit.Core.Services;

namespace Lit.Core.Scaffolds
{
    public class LibIndexBuilder
    {
        public string[] Build(ITemplateLocator templateLocator)
            => templateLocator.Get(nameof(LibIndexBuilder));
    }
}
