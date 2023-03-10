using System;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace StudioAssemblyResolver.PathResolver
{
    public abstract class AbstractRegistryPathResolver : IPathResolver
    {
        internal string InstallLocation64Bit = @"SOFTWARE\Wow6432Node\SDL";
        internal const string InstallLocation32Bit = @"SOFTWARE\SDL";
        internal const string InstallLocationKey = "InstallLocation";

        public abstract string GetStudioVersion();

        public string Resolve()
        {
            string path = null;

            try
            {
                var studioVersion = GetStudioVersion();

                var regex = new Regex("\\d+");
                var match = regex.Match(studioVersion);

                var registryPath = int.TryParse(match.ToString(), out var versionNo) && versionNo > 16
                    ? $"SOFTWARE\\Wow6432Node\\Trados\\{studioVersion}"
                    : Environment.Is64BitOperatingSystem
                        ? $@"{InstallLocation64Bit}\{studioVersion}"
                        : $@"{InstallLocation32Bit}\{studioVersion}";
                

                var registryKey = Registry.LocalMachine.OpenSubKey(registryPath);
                if (registryKey != null) path = registryKey.GetValue(InstallLocationKey,false) as string;
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return path;
        }
    }
}
