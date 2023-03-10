using System.Collections.Generic;
using System.Linq;

namespace RWS_StudioAssemblyResolver.PathResolver.Implementation
{
    internal class CascadePathResolver : IPathResolver
    {
        public IEnumerable<IPathResolver> Nodes;
        public IPathSpecification Specification;
       
        public string Resolve()
        {
            foreach (var node in Nodes.Select(pathResolver => pathResolver.Resolve()))
            {
                if (Specification.IsSatisfiedBy(node)) return node;
            }
            return string.Empty;
        }
    }
}
