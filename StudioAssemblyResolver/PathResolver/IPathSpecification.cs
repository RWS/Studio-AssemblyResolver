namespace Rws.StudioAssemblyResolver.PathResolver
{
    public interface IPathSpecification
    {
        bool IsSatisfiedBy(string path);
    }
}
