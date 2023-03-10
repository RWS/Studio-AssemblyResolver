using System;
using System.IO;

namespace RWS_StudioAssemblyResolver.PathResolver.Implementation
{
    public class DefaultStudio2022PathResolver : IPathResolver
    {
        public string Resolve() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Trados\Trados Studio\Studio17\");
    }
}
