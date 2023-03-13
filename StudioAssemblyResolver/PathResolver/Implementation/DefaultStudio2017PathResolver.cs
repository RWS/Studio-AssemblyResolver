using System;
using System.IO;

namespace Rws.StudioAssemblyResolver.PathResolver.Implementation
{
    internal class DefaultStudio2017PathResolver: IPathResolver
    {
        public string Resolve()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"SDL\SDL Trados Studio\Studio5\");
        }
    }
}
