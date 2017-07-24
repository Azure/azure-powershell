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
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Static class used to generate a set of tests.
    /// </summary>
    public static class TestSetGenerator
    {
        /// <summary>
        /// Static method used to generate a set of tests to be run based on
        /// a Json file which maps files to test Dlls.
        /// </summary>
        /// <param name="files">This is a set of paths.</param>
        /// <param name="mapFilePath">This is the filepath of the map that contains
        /// the mapping between files and test DLLs.</param>
        /// <returns>Set of tests to be run</returns>
        public static IEnumerable<string> GetTests(IEnumerable<string> files, string mapFilePath)
        {
            if (mapFilePath == null)
            {
                throw new ArgumentNullException("The filepath of the map should never be null.");
            }

            if (files == null)
            {
                throw new ArgumentNullException("The files should never be null.");
            }

            // more descriptive when the path is incorrect
            HashSet<string> paths = new HashSet<string>(files);
            Dictionary<string, string[]> pathToTestsMappings;
            try
            {
                pathToTestsMappings = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(File.ReadAllText(mapFilePath));
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The filepath provided for the map could not be found. Please provide a valid filepath.");
            }

            return TestSetGenerator.GetTestSet(paths, pathToTestsMappings);
        }
        /// <summary>
        /// Static method used to generate a set of tests to be run based on
        /// a set of paths
        /// </summary>
        /// <param name="files">This is a set of paths.</param>
        /// <param name="pathToTestsMappings">This is the map that contains
        /// the mapping between files and test DLLs.</param>
        /// <returns>Set of tests to be run</returns>
        public static HashSet<string> GetTestSet(HashSet<string> files, Dictionary<string, string[]> pathToTestsMappings)
        {
            //validate arguments
            if (pathToTestsMappings == null)
            {
                throw new ArgumentNullException("Mapping should never be null.");
            }

            if (!pathToTestsMappings.Any())
            {
                throw new ArgumentException("Map does not contain any element.");
            }

            if (files == null)
            {
                throw new ArgumentNullException("Paths set should never be null.");
            }

            HashSet<string> testSet = new HashSet<string>();
            //pathsProvided and pathsFound variables are used to identify if any path provided 
            //in the paths set was not found in the path-to-tests mapping
            int numberPathsProvided = files.Count;
            int numberPathsFound = 0;
            //werePathsProvided is used to identify if the whether paths set is emtpy or not
            bool werePathsProvided = false;

            foreach (string fullPath in files)
            {
                if (fullPath == null)
                {
                    throw new ArgumentNullException("One or more of the paths provided are null.");
                }

                werePathsProvided = true;

                foreach (KeyValuePair<string, string[]> entry in pathToTestsMappings)
                {
                    if (fullPath.StartsWith(entry.Key))
                    {
                        numberPathsFound += 1;
                        testSet.UnionWith(entry.Value);
                    }
                }
            }

            if (numberPathsProvided != numberPathsFound || !werePathsProvided || files.Count >= 300)
            {
                //Since some path was not found  in the mapping or no paths were provided
                //or the maximum number of files provided by GitHub API was 
                //reached(https://developer.github.com/v3/pulls/#list-pull-requests-files)
                //all tests should be added to the test set
                //NOTE:The last case is a safe choice because some critical path could
                //have not been included in the list of files.
                foreach (KeyValuePair<string, string[]> entry in pathToTestsMappings)
                {
                    testSet.UnionWith(entry.Value);
                }
            }

            return testSet;
        }
        /// <summary>
        /// Static method overload used to get all test assemblies using mapping 
        /// between paths and test dlls.
        /// </summary>
        /// <param name="mapFilePath"></param>
        /// <returns>A list of test dlls.</returns>
        public static IEnumerable<string> GetTests(string mapFilePath)
        {
            HashSet<string> tests = new HashSet<string>();

            if (mapFilePath == null)
            {
                throw new ArgumentNullException("The filepath of the map should never be null.");
            }

            Dictionary<string, string[]> pathToTestsMappings;
            try
            {
                pathToTestsMappings = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(File.ReadAllText(mapFilePath));
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The filepath provided for the map could not be found. Please provide a valid filepath.");
            }

            foreach (KeyValuePair<string, string[]> entry in pathToTestsMappings)
            {
                tests.UnionWith(entry.Value);
            }

            return tests;
        }
    }
}
