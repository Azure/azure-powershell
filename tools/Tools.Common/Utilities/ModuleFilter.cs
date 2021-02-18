using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Tools.Common.Utilities
{
    public class ModuleFilter
    {
        public static bool IsAzureStackModule(String fileName)
        {
            bool isAzureStackModule = false;
            if (fileName.Contains("Stack"))
            {
                isAzureStackModule = true;
            }
            var executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
            var versionControllerDirectory = Directory.GetParent(executingAssemblyPath).FullName;
            var whiteListFile = Path.Combine(versionControllerDirectory, "AllowList.csv");
            if (File.Exists(whiteListFile))
            {
                var lines = File.ReadAllLines(whiteListFile).Skip(1).Where(c => !string.IsNullOrEmpty(c));
                foreach (var line in lines)
                {
                    var cols = line.Split(',').Select(c => c.StartsWith("\"") ? c.Substring(1) : c)
                                              .Select(c => c.EndsWith("\"") ? c.Substring(0, c.Length - 1) : c)
                                              .Select(c => c.Trim()).ToArray();
                    if (cols.Length >= 1)
                    {
                        if (fileName.Contains(cols[0]))
                        {
                            isAzureStackModule = false;
                            break;
                        }
                    }
                }
            }
            return isAzureStackModule;
        }
    }
}
