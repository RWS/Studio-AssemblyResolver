namespace RWS_StudioAssemblyResolver.PathResolver
{
    public interface IPathSpecification
    {
        bool IsSatisfiedBy(string path);
    }
}
