using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.AssemblyResolver.PathResolver.Implementation
{
    public class DefaultStudio2022PathResolver : IPathResolver
    {
        public string Resolve() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Trados\Trados Studio\Studio17\");
    }
}
