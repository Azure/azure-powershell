// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Tools.Common.Loaders
{
    public class SharedAssemblyLoader
    {
        private const string NetStandard20 = "netstandard2.0";
        private static readonly IEnumerable<string> Frameworks = new string[] { NetStandard20 };
        public static HashSet<string> ProcessedFolderSet = new HashSet<string>();

        public static void Load(string directory)
        {
            directory = Path.GetFullPath(directory);
            if (!ProcessedFolderSet.Contains(directory))
            {
                ProcessedFolderSet.Add(directory);
                PreloadSharedAssemblies(directory);
            }
        }

        private static void PreloadSharedAssemblies(string directory)
        {
            var libFolder = Path.Combine(directory, "Az.Accounts", "lib");
            foreach (string framework in Frameworks)
            {
                var sharedAssemblyFolder = Path.Combine(libFolder, framework);
                if (Directory.Exists(sharedAssemblyFolder))
                {
                    foreach (var file in Directory.EnumerateFiles(sharedAssemblyFolder, "*.dll"))
                    {
                        try
                        {
                            if (ShouldSkipLoading(file, out var reason))
                            {
                                Console.WriteLine($"PreloadSharedAssemblies: skipping {file}, reason: {reason}.");
                                continue;
                            }
                            Console.WriteLine($"PreloadSharedAssemblies: Starting to load assembly {file}.");
                            Assembly.LoadFrom(file);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"PreloadSharedAssemblies: Failed (but could be IGNORED) to load assembly {Path.GetFileNameWithoutExtension(file)} with {e}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"PreloadSharedAssemblies: Could not find directory {sharedAssemblyFolder}.");
                }
            }
        }

        private static bool ShouldSkipLoading(string path, out string reason)
        {
            reason = "";
            if (Path.GetFileNameWithoutExtension(path).StartsWith("msalruntime", StringComparison.InvariantCultureIgnoreCase))
            {
                reason = $"skip native library";
                return true;
            }
            return false;
        }
    }
}
