﻿using System;
using System.IO;

namespace Rws.StudioAssemblyResolver.PathResolver.Implementation
{
    public class DefaultStudio2024PathResolver : IPathResolver
    {
        public string Resolve() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Trados\Trados Studio\Studio18\");
    }
}
