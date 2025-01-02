using System;
using System.Collections.Generic;
using System.Linq;

namespace AzDev.Services
{
    internal static class CsprojReader
    {
        private static IDictionary<string, Csproj> _cache = new Dictionary<string, Csproj>();

        public static Csproj Parse(string content)
        {
            if (_cache.TryGetValue(content, out var result))
            {
                return result;
            }

            var lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var packageReferences = new List<string>();
            var projectReferences = new List<string>();

            foreach (var line in lines)
            {
                if (line.Contains("<PackageReference"))
                {
                    var start = line.IndexOf("Include=\"") + "Include=\"".Length;
                    var end = line.IndexOf("\"", start);
                    packageReferences.Add(line.Substring(start, end - start));
                }
                else if (line.Contains("<ProjectReference"))
                {
                    var start = line.IndexOf("Include=\"") + "Include=\"".Length;
                    var end = line.IndexOf("\"", start);
                    projectReferences.Add(line.Substring(start, end - start));
                }
            }

            Csproj csproj = new Csproj
            {
                PackageReferences = packageReferences,
                ProjectReferences = projectReferences
            };
            _cache[content] = csproj;
            return csproj;
        }
    }

    internal class Csproj
    {
        public IEnumerable<string> PackageReferences { get; internal set; } = Enumerable.Empty<string>();
        public IEnumerable<string> ProjectReferences { get; internal set; } = Enumerable.Empty<string>();
    }
}