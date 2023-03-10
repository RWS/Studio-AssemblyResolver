using System;
using System.IO;

namespace RWS_StudioAssemblyResolver.PathResolver.Implementation
{
    internal class DefaultStudio2014PathResolver : IPathResolver
    {
        public string Resolve()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"SDL\SDL Trados Studio\Studio3\");
        }
    }
}
