using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace TestMapper
{
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
            HashSet<string> paths = (HashSet<string>)files;
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

            if (!files.Any())
            {
                return testSet;
            }

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

            if (numberPathsProvided != numberPathsFound || !werePathsProvided)
            {
                //Since some path was not found  in the mapping or no paths were provided
                //all tests should be added to the test set si
                foreach (KeyValuePair<string, string[]> entry in pathToTestsMappings)
                {
                    testSet.UnionWith(entry.Value);
                }
            }

            return testSet;

        }
    }
}
