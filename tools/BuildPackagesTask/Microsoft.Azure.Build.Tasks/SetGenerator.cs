//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.WindowsAzure.Build.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Static class used to generate a set of tests.
    /// </summary>
    public static class SetGenerator
    {
        /// <summary>
        /// Max Number of files allowed by GitHubAPI
        /// See:https://developer.github.com/v3/pulls/#list-pull-requests-files
        /// </summary>
        public const int MaxFilesPossible = 300;

        /// <summary>
        /// Static method used to generate a set of tests to be run based on
        /// a set of paths
        /// </summary>
        /// <param name="files">This is a set of paths.</param>
        /// <param name="pathToTestsMappings">This is the map that contains
        /// the mapping between files and test DLLs.</param>
        /// <returns>Set of tests to be run</returns>
        public static HashSet<string> Generate(HashSet<string> filesChangedSet, Dictionary<string, string[]> mappingsDictionary)
        {
            //validate arguments
            if (mappingsDictionary == null)
            {
                throw new ArgumentNullException("The mappings dictionary cannot be null.");
            }

            if (!mappingsDictionary.Any())
            {
                throw new ArgumentException("The mappings dictionary does not contain any elements.");
            }

            if (filesChangedSet == null)
            {
                throw new ArgumentNullException("The set of files changed cannot be null.");
            }

            var outputSet = new HashSet<string>();
            var filesFoundCount = 0;
            var useFullMapping = false;
            if (filesChangedSet.Count >= MaxFilesPossible || filesChangedSet.Count == 0)
            {
                useFullMapping = true;
            }
            else
            {
                foreach (var fileChanged in filesChangedSet)
                {
                    if (fileChanged == null)
                    {
                        throw new ArgumentNullException("One or more of the elements in the set of changed files is null.");
                    }

                    var foundMapping = false;
                    foreach (var pair in mappingsDictionary)
                    {
                        if (fileChanged.StartsWith(pair.Key))
                        {
                            foundMapping = true;
                            outputSet.UnionWith(pair.Value);
                            break;
                        }
                    }

                    if (!foundMapping)
                    {
                        useFullMapping = true;
                        outputSet = new HashSet<string>();
                        break;
                    }
                }
            }

            if (useFullMapping)
            {
                foreach (var pair in mappingsDictionary)
                {
                    outputSet.UnionWith(pair.Value);
                }
            }

            foreach (var fileChanged in filesChangedSet)
            {
                if (fileChanged == null)
                {
                    throw new ArgumentNullException("One or more of the elements in the set of changed files is null.");
                }

                foreach (var pair in mappingsDictionary)
                {
                    if (fileChanged.StartsWith(pair.Key))
                    {
                        filesFoundCount++;
                        outputSet.UnionWith(pair.Value);
                    }
                }
            }

            return outputSet;
        }
        /// <summary>
        /// Generate set according to module names
        /// </summary>
        /// <param name="moduleNames"></param>
        /// <param name="mappingsDictionary"></param>
        /// <returns></returns>
        public static HashSet<string> Generate(string[] moduleNames, Dictionary<string, string[]> mappingsDictionary)
        {
            var outputSet = new HashSet<string>();

            foreach (var module in moduleNames)
            {
                var key = $"src/{module}/";
                if (mappingsDictionary.ContainsKey(key))
                {
                    var lines = mappingsDictionary[key];
                    foreach (var line in lines)
                    {
                        if (line.Contains($"/src/{module}/") || line.Contains($"\\src\\{module}\\") || line.Equals($"Az.{module}"))
                        {
                            outputSet.Add(line);
                        }
                    }
                }
            }

            return outputSet;
        }

    }
}
