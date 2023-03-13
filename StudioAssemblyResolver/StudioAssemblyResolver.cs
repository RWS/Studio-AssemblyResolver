using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Rws.StudioAssemblyResolver.PathResolver;
using Rws.StudioAssemblyResolver.PathResolver.Implementation;

namespace Rws.StudioAssemblyResolver
{
    public class StudioAssemblyResolver
    {
        private readonly IEnumerable<IPathResolver> _resolvers;

        internal StudioAssemblyResolver(IEnumerable<IPathResolver> resolvers)
        {
            this._resolvers = resolvers;
        }

        internal StudioAssemblyResolver()
        {
            this._resolvers = Enumerable.Empty<IPathResolver>();
        }

        public void Resolve()
        {
            global::Rws.StudioAssemblyResolver.AssemblyResolver.StudioPath = TryGetStudioPath();
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += currentDomain_AssemblyResolve;
        }

        private string TryGetStudioPath()
        {
            return new CascadePathResolver
            {
                Specification = new DefaultPathSpecification(),
                Nodes = _resolvers.Concat(new IPathResolver[]
                {
                    new DefaultStudio2022PathResolver(),
                    new RegistryStudio2022PathResolver(),
                    new DefaultStudio2021PathResolver(),
                    new RegistryStudio2021PathResolver(),
                    new DefaultStudio2019PathResolver(),
                    new RegistryStudio2019PathResolver(),
                    new DefaultStudio2017PathResolver(),
                    new RegistryStudio2017PathResolver(),
                    new DefaultStudio2015PathResolver(),
                    new RegistryStudio2015PathResolver(),
                    new DefaultStudio2014PathResolver(),
                    new RegistryStudio2014PathResolver(),
                    new DefaultStudio2011PathResolver(),
                    new RegistryStudio2014PathResolver()
                })
            }.Resolve();
        }

        private Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (string.IsNullOrEmpty(global::Rws.StudioAssemblyResolver.AssemblyResolver.StudioPath)) return null;
            var folderPath = Path.GetDirectoryName(global::Rws.StudioAssemblyResolver.AssemblyResolver.StudioPath);
            if (folderPath == null) return null;
            var assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
            if (!File.Exists(assemblyPath)) return null;
            var assembly = Assembly.LoadFrom(assemblyPath);
            return assembly;
        }
    }
}
