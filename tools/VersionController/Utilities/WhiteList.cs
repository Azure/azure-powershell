using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VersionController.Netcore.Utilities
{
    class WhiteList
    {
        public static bool Contains(String fileName)
        {
            var executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
            var versionControllerDirectory = Directory.GetParent(executingAssemblyPath).FullName;
            var whiteListFile = Path.Combine(versionControllerDirectory, "WhiteList.csv");
            if (File.Exists(whiteListFile))
            {
                var lines = File.ReadAllLines(whiteListFile).Skip(1).Where(c => !string.IsNullOrEmpty(c));
                foreach (var line in lines)
                {
                    var cols = line.Split(",").Select(c => c.StartsWith("\"") ? c.Substring(1) : c)
                                              .Select(c => c.EndsWith("\"") ? c.Substring(0, c.Length - 1) : c)
                                              .Select(c => c.Trim()).ToArray();
                    if (cols.Length >= 1)
                    {
                        if (fileName.Contains(cols[0]))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
