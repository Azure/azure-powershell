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

using System;
using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    public class TestSetGeneratorTester
    {
        /// <summary>
        /// Trait name.
        /// </summary>
        public const string CheckIn = "CheckIn";

        /// <summary>
        /// Trait value.
        /// </summary>
        public const string AcceptanceType = "AcceptanceType";        

        /// <summary>
        /// File path of TestMappings.
        /// </summary>
        public static string MapFilePath
        {
            get
            {
                string mapName = "TestMappings.json";
                var assemblyLocation = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                var azurePSPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(assemblyLocation))))));
                return Path.Combine(azurePSPath, mapName);
            }
        }

        #region GetTestSet Function Tests
        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTestSet_OnePathAndOneMappingWithMatchingPath_ReturnsTestSetMatchingPath()
        {
            //declarations
            HashSet<String> paths = new HashSet<String>()
            {
                "src/path1/fullpath"
            };

            Dictionary<String, String[]> map = new Dictionary<String, String[]>()
            {
                { "src/path1", new String[] { "test1.dll" } }
            };

            HashSet<String> expected = new HashSet<String>()
            {
                "test1.dll"
            };

            HashSet<String> actual = new HashSet<String>();

            //act
            actual = TestSetGenerator.GetTestSet(paths, map);

            //assert            
            Assert.True(expected.SetEquals(actual));

        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTestSet_OnePathAndMultipleMappingsWithNonMatchingPaths_ReturnsAllTests()
        {
            //arrange
            HashSet<String> paths = new HashSet<String>()
            {
                "src/random"
            };

            Dictionary<String, String[]> map = new Dictionary<String, String[]>()
            {
                { "src/path1", new String[] { "test1.dll" } },
                { "src/path2", new String[] { "test2.dll" } },
                { "src/path3", new String[] { "test2.dll" , "test3.dll"} }

            };

            HashSet<String> expected = new HashSet<String>()
            {
                "test1.dll",
                "test2.dll",
                "test3.dll"
            };

            HashSet<String> actual = new HashSet<String>();

            //act
            actual = TestSetGenerator.GetTestSet(paths, map);

            //assert            
            Assert.True(expected.SetEquals(actual));

        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTestSet_MultiplePathsAndMultipleMappingsWithMatchingPaths_ReturnsAllTests()
        {
            //arrange
            HashSet<String> paths = new HashSet<String>()
            {
                "src/path1/fullpath1",
                "src/path2/fullpath2",
                "path3"
            };

            Dictionary<String, String[]> map = new Dictionary<String, String[]>()
            {
                { "src/path1", new String[] { "test1.dll" } },
                { "src/path2", new String[] { } },
                { "path3", new String[] { "test2.dll" , "test3.dll"} }

            };

            HashSet<String> expected = new HashSet<String>()
            {
                "test1.dll",
                "test2.dll",
                "test3.dll"
            };

            HashSet<String> actual = new HashSet<String>();

            //act
            actual = TestSetGenerator.GetTestSet(paths, map);

            //assert            
            Assert.True(expected.SetEquals(actual));

        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTestSet_MultiplePathsAndMultipleMappingsWitNonhMatchingPaths_ReturnsAllTests()
        {
            //arrange
            HashSet<String> paths = new HashSet<String>()
            {
                "random1",
                "random2",
                "random3"
            };

            Dictionary<String, String[]> map = new Dictionary<String, String[]>()
            {
                { "src/path1", new String[] { "test1.dll" } },
                { "src/path2", new String[] { } },
                { "path3", new String[] { "test2.dll" , "test3.dll"} }

            };

            HashSet<String> expected = new HashSet<String>()
            {
                "test1.dll",
                "test2.dll",
                "test3.dll"
            };

            HashSet<String> actual = new HashSet<String>();

            //act
            actual = TestSetGenerator.GetTestSet(paths, map);

            //assert            
            Assert.True(expected.SetEquals(actual));

        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTestSet_MultiplePathsAndMultipleMappingsWithSomeMatchingPaths_ReturnsAllTests()
        {
            //arrange
            HashSet<String> paths = new HashSet<String>()
            {
                "src/path1",
                "random2",
                "random3"
            };

            Dictionary<String, String[]> map = new Dictionary<String, String[]>()
            {
                { "src/path1", new String[] { "test1.dll" } },
                { "src/path2", new String[] { } },
                { "path3", new String[] { "test2.dll" , "test3.dll"} }

            };

            HashSet<String> expected = new HashSet<String>()
            {
                "test1.dll",
                "test2.dll",
                "test3.dll"
            };

            HashSet<String> actual = new HashSet<String>();

            //act
            actual = TestSetGenerator.GetTestSet(paths, map);

            //assert            
            Assert.True(expected.SetEquals(actual));

        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTestSet_NoPathsProvided_ReturnsAllTests()
        {
            //arrange
            HashSet<String> paths = new HashSet<String>() { };
            Dictionary<String, String[]> map = new Dictionary<String, String[]>()
            {
                { "src/path1", new String[] { "test1.dll" } },
                { "src/path2", new String[] { } },
                { "path3", new String[] { "test2.dll" , "test3.dll"} }

            };

            int expectedNumberFiles = 3;
            HashSet<string> actual;

            //act
            actual = TestSetGenerator.GetTestSet(paths, map);

            //assert            
            Assert.True(expectedNumberFiles == actual.Count);
        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTestSet_NoMappingsProvided_ShouldThrowArgumentException()
        {
            //arrange
            HashSet<String> paths = new HashSet<String>()
            {
                "random1",
                "random2",
                "random3"
            };

            Dictionary<String, String[]> map = new Dictionary<String, String[]>();

            //act
            try
            {
                TestSetGenerator.GetTestSet(paths, map);
            }
            catch (ArgumentException e)
            {
                // assert  
                Assert.Contains(e.Message, "Map does not contain any element.");
                return;
            }

            throw new Exception("No exception was thrown.");
        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTestSet_PathsNullArgument_ShouldThrowArgumentNullException()
        {
            //arrange
            Dictionary<String, String[]> map = new Dictionary<String, String[]>()
            {
                { "src/path1", new String[] { "test1.dll" } },
                { "src/path2", new String[] { } },
                { "path3", new String[] { "test2.dll" , "test3.dll"} }

            };

            //act
            try
            {
                TestSetGenerator.GetTestSet(null, map);
            }
            catch (ArgumentNullException e)
            {
                // assert  
                Assert.Contains("Paths set should never be null.", e.Message);
                return;
            }

            throw new Exception("No exception was thrown.");
        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTestSet_MapNullArgument_ShouldThrowArgumentNullException()
        {
            //arrange
            HashSet<String> paths = new HashSet<String>()
            {
                "random1",
                "random2",
                "random3"
            };

            //act
            try
            {
                TestSetGenerator.GetTestSet(paths, null);
            }
            catch (ArgumentNullException e)
            {
                // assert  
                Assert.Contains("Mapping should never be null.", e.Message);
                return;
            }

            throw new Exception("No exception was thrown.");
        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTestSet_SomePathIsNull_ShouldThrowArgumentNullException()
        {
            //arrange
            HashSet<String> paths = new HashSet<String>()
            {
                null,
                "random2",
                "random3"
            };

            Dictionary<String, String[]> map = new Dictionary<String, String[]>()
            {
                { "src/path1", new String[] { "test1.dll" } },
                { "src/path2", new String[] { } },
                { "path3", new String[] { "test2.dll" , "test3.dll"} }

            };

            //act
            try
            {
                TestSetGenerator.GetTestSet(paths, map);
            }
            catch (ArgumentNullException e)
            {
                // assert  
                Assert.Contains("One or more of the paths provided are null.", e.Message);
                return;
            }

            throw new Exception("No exception was thrown.");
        }
        #endregion
        #region GetTests Function Tests
        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTests_MultiplePathsAndMultipleMappingsWithSomeMatchingPaths_ReturnsAllTests()
        {
            //arrange
            HashSet<string> paths = new HashSet<string>()
            {
                "src/ResourceManager/StreamAnalytics/",
                "src/path2",
                "random3"
            };

            string mapFilePath = MapFilePath;
            HashSet<string> expected = new HashSet<string>()
            {
                "test1.dll",
                "test2.dll",
                "test3.dll"
            };

            int expectedNumberFiles = 53;
            HashSet<string> actual;

            //act
            actual = (HashSet<string>)(TestSetGenerator.GetTests(paths, mapFilePath));

            //assert            
            Assert.True(expectedNumberFiles <= actual.Count);
        }

        [Fact(Skip = "https://github.com/Azure/azure-powershell/issues/4723")]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTests_MultiplePathsAndMultipleMappingsWithMatchingPaths_ReturnsMatchingTests()
        {
            //arrange
            HashSet<string> paths = new HashSet<string>()
            {
                "src/ResourceManager/StreamAnalytics/file",
                "src/ResourceManager/Websites/"
            };

            string mapFilePath = MapFilePath;
            int expectedNumberFiles = 2;
            HashSet<string> actual;

            //act
            actual = (HashSet<string>)(TestSetGenerator.GetTests(paths, mapFilePath));

            //assert            
            Assert.True(expectedNumberFiles == actual.Count);
        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTests_FilesNull_ThrowNullException()
        {
            //arrange           
            string mapFilePath =  MapFilePath;

            try
            {
                TestSetGenerator.GetTests(null, mapFilePath);
            }
            catch (ArgumentNullException e)
            {
                // assert  
                Assert.Contains("The files should never be null.", e.Message);
                return;
            }

            throw new Exception("No exception was thrown.");
        }

        [Fact(Skip = "https://github.com/Azure/azure-powershell/issues/4723")]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTests_EmptyListOfFiles_ShouldReturnAllTests()
        {
            //arrange
            HashSet<string> paths = new HashSet<string>() { };
            string mapFilePath = MapFilePath;
            int expectedNumberFiles = 53;
            HashSet<string> actual;

            //act
            actual = (HashSet<string>)(TestSetGenerator.GetTests(paths, mapFilePath));

            //assert            
            Assert.True(expectedNumberFiles <= actual.Count);
        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTests_InvalidPath_ThrowNotNullException()
        {
            //arrange
            HashSet<string> paths = new HashSet<string>()
            {
                "src /path1",
                "src/path2",
                "random3"
            };

            string mapFilePath = @"random";

            try
            {
                TestSetGenerator.GetTests(paths, mapFilePath);
            }
            catch (System.IO.FileNotFoundException e)
            {
                // assert  
                Assert.Contains("The filepath provided for the map could not be found.", e.Message);
                return;
            }

            throw new Exception("No exception was thrown.");
        }

        [Fact]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTests_WithActualMappings_FilesFound_ReturnsMatchingTests()
        {
            //arrange
            HashSet<string> paths = new HashSet<string>()
            {
                ".github",
                "documentation",
                "src/ServiceManagement/file",
                "src/ResourceManager/LogicApp/file",
                "src/ResourceManager/UsageAggregates/file"

            };

            string mapFilePath = MapFilePath;
            HashSet<string> expected = new HashSet<string>()
            {
                @".\src\ServiceManagement\Common\Commands.Common.Test\bin\Debug\Microsoft.WindowsAzure.Commands.Common.Test.dll",
                @".\src\ServiceManagement\Services\Commands.Test\bin\Debug\Microsoft.WindowsAzure.Commands.Test.dll",
                @".\src\ServiceManagement\StorSimple\Commands.StorSimple.Test\bin\Debug\Microsoft.WindowsAzure.Commands.StorSimple.Test.dll",
                @".\src\ServiceManagement\Common\Commands.ScenarioTest\bin\Debug\Microsoft.WindowsAzure.Commands.ScenarioTest.dll",
                @".\src\ServiceManagement\RecoveryServices\Commands.RecoveryServices.Test\bin\Debug\Microsoft.Azure.Commands.RecoveryServices.Test.dll",
                @".\src\ServiceManagement\Network\Commands.Network.Test\bin\Debug\Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.dll",
                @".\src\ResourceManager\UsageAggregates\Commands.UsageAggregates.Test\bin\Debug\Microsoft.Azure.Commands.UsageAggregates.Test.dll",
                @".\src\ResourceManager\LogicApp\Commands.LogicApp.Test\bin\Debug\Microsoft.Azure.Commands.LogicApp.Test.dll"
            };

            IEnumerable<string> actual;

            //act
            actual = TestSetGenerator.GetTests(paths, mapFilePath);

            //assert            
            Assert.True(expected.SetEquals(actual));
        }

        [Fact(Skip = "https://github.com/Azure/azure-powershell/issues/4723")]
        [Trait(AcceptanceType, CheckIn)]
        public void GetTests_WithActualMappings_FilesNotFound_ReturnsAllTests()
        {
            //arrange
            HashSet<string> paths = new HashSet<string>()
            {
                ".github",
                "documentation",
                "random1",
                "random2",
                "random3"

            };

            string mapFilePath = MapFilePath;
            int expectedNumberFiles = 53;
            HashSet<string> actual;

            //act
            actual = (HashSet<string>)(TestSetGenerator.GetTests(paths, mapFilePath));

            //assert            
            Assert.True(expectedNumberFiles <= actual.Count);
        }
        #endregion

    }
}
