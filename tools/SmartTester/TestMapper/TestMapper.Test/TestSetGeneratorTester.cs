using System;
using Xunit;
using TestMapper;
using System.Collections.Generic;

namespace TestMapper.Test
{
    public class TestSetGeneratorTester
    {
        #region GetTestSet Function Tests
        [Fact]
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
            HashSet<String> expected = new HashSet<String>() { };
            HashSet<String> actual = new HashSet<String>();

            //act
            actual = TestSetGenerator.GetTestSet(paths, map);

            //assert            
            Assert.True(expected.SetEquals(actual));

        }

        [Fact]
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
        public void GetTestSet_MapNullArgument_ShouldThrowArgumentNullException()
        {
            //arrange
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
        public void GetTests_MultiplePathsAndMultipleMappingsWithSomeMatchingPaths_ReturnsAllTests()
        {
            //arrange
            HashSet<string> paths = new HashSet<string>()
            {
                "src/path1",
                "src/path2",
                "random3"
            };
            string mapFilePath = @"C:\Users\t-netron\Documents\Visual Studio 2017\Projects\TestSetGenerator.Test\map1.json";
            HashSet<string> expected = new HashSet<string>()
            {
                "test1.dll",
                "test2.dll",
                "test3.dll"
            };
            IEnumerable<string> actual;

            //act
            actual = TestSetGenerator.GetTests(paths, mapFilePath);

            //assert            
            Assert.True(expected.SetEquals(actual));
        }
        [Fact]
        public void GetTests_MultiplePathsAndMultipleMappingsWithMatchingPaths_ReturnsMatchingTests()
        {
            //arrange
            HashSet<string> paths = new HashSet<string>()
            {
                "src/path2",
                "path3"
            };
            string mapFilePath = @"C:\Users\t-netron\Documents\Visual Studio 2017\Projects\TestSetGenerator.Test\map1.json";
            HashSet<string> expected = new HashSet<string>()
            {
                "test2.dll",
                "test3.dll"
            };
            IEnumerable<string> actual;

            //act
            actual = TestSetGenerator.GetTests(paths, mapFilePath);

            //assert            
            Assert.True(expected.SetEquals(actual));
        }
        [Fact]
        public void GetTests_FilesNull_ThrowNullException()
        {
            //arrange           
            string mapFilePath = @"C:\Users\t-netron\Documents\Visual Studio 2017\Projects\TestSetGenerator.Test\map1.json";

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
        [Fact]
        public void GetTests_EmptyListOfFiles_ShouldReturnEmptySet()
        {
            //arrange
            HashSet<string> paths = new HashSet<string>() { };
            string mapFilePath = @"C:\Users\t-netron\Documents\Visual Studio 2017\Projects\TestSetGenerator.Test\map1.json";

            HashSet<string> expected = new HashSet<string>() { };
            IEnumerable<string> actual;

            //act
            actual = TestSetGenerator.GetTests(paths, mapFilePath);

            //assert            
            Assert.True(expected.SetEquals(actual));
        }
        [Fact]
        public void GetTests_InvalidPath_ThrowNotNullException()
        {
            //arrange
            HashSet<string> paths = new HashSet<string>()
            {
                "src/path1",
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
            string mapFilePath = @"C:\Users\t-netron\Documents\Visual Studio 2017\Projects\TestSetGenerator.Test\map.json";
            HashSet<string> expected = new HashSet<string>()
            {
                ".\\src\\ServiceManagement\\Common\\Commands.Common.Test\\bin\\Debug\\Microsoft.WindowsAzure.Commands.Common.Test.dll",
                ".\\src\\ServiceManagement\\Services\\Commands.Test\\bin\\Debug\\Microsoft.WindowsAzure.Commands.Test.dll",
                ".\\src\\ServiceManagement\\StorSimple\\Commands.StorSimple.Test\\bin\\Debug\\Microsoft.WindowsAzure.Commands.StorSimple.Test.dll",
                ".\\src\\ServiceManagement\\RemoteApp\\Commands.RemoteApp.Test\\bin\\Debug\\Microsoft.Azure.Commands.RemoteApp.Tests.dll",
                ".\\src\\ServiceManagement\\Common\\Commands.ScenarioTest\\bin\\Debug\\Microsoft.WindowsAzure.Commands.ScenarioTest.dll",
                ".\\src\\ServiceManagement\\RecoveryServices\\Commands.RecoveryServices.Test\\bin\\Debug\\Microsoft.Azure.Commands.RecoveryServices.Test.dll",
                ".\\src\\ServiceManagement\\Network\\Commands.Network.Test\\bin\\Debug\\Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.dll",
                ".\\src\\ResourceManager\\UsageAggregates\\Commands.UsageAggregates.Test\\bin\\Debug\\Microsoft.Azure.Commands.UsageAggregates.Test.dll",
                ".\\src\\ResourceManager\\LogicApp\\Commands.LogicApp.Test\\bin\\Debug\\Microsoft.Azure.Commands.LogicApp.Test.dll"
            };
            IEnumerable<string> actual;

            //act
            actual = TestSetGenerator.GetTests(paths, mapFilePath);

            //assert            
            Assert.True(expected.SetEquals(actual));
        }
        [Fact]
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
            string mapFilePath = @"C:\Users\t-netron\Documents\Visual Studio 2017\Projects\TestSetGenerator.Test\map.json";
            int expectedNumberFiles = 50;

            HashSet<string> actual;

            //act
            actual = (HashSet<string>)(TestSetGenerator.GetTests(paths, mapFilePath));

            //assert            
            Assert.True(expectedNumberFiles == actual.Count);
        }
        #endregion

    }
}
