using System.IO.Abstractions.TestingHelpers;
using AzDev.Models.Inventory;

namespace AzDev.Tests;

public class ProjectTests
{
        [Fact]
        public void CanCreateFromFileSystem()
        {
                var cd = Directory.GetCurrentDirectory();
                var split = Path.DirectorySeparatorChar;
                var projectName = "Test.AutoRest";
                var path = $"{cd}{split}{projectName}";
                var readme = $"{path}{split}README.md";
                var fs = new MockFileSystem(new Dictionary<string, MockFileData>
                {
                        { readme, new MockFileData(
                                @"### AutoRest Configuration
``` yaml
title: Test
input-file:
    - $(repo)/specification/test.json
```
"
                        )}
                });

                var project = Project.FromFileSystem(fs, path);
                Assert.Equal(path, project.Path);
                Assert.Equal(projectName, project.Name);
        }

        [Fact]
        public void AutoRestVersion_Defaults_To_v4_When_Omitted()
        {
                var cd = Directory.GetCurrentDirectory();
                var split = Path.DirectorySeparatorChar;
                var projectName = "Test2.AutoRest";
                var path = $"{cd}{split}{projectName}";
                var readme = $"{path}{split}README.md";
                var fs = new MockFileSystem(new Dictionary<string, MockFileData>
                {
                        { readme, new MockFileData(
                                @"### AutoRest Configuration
``` yaml
title: Test
input-file:
    - $(repo)/specification/test.json
```
"
                        )}
                });

                var project = Project.FromFileSystem(fs, path);
                var arp = Assert.IsType<AutoRestProject>(project);
                Assert.Equal("v4", arp.AutoRestVersion);
                Assert.Equal("v4", project.SubType);
        }

        [Fact]
        public void AutoRestVersion_Recognizes_v3_And_v4()
        {
                var cd = Directory.GetCurrentDirectory();
                var split = Path.DirectorySeparatorChar;
                var projectName = "Test3.AutoRest";
                var path = $"{cd}{split}{projectName}";
                var readme = $"{path}{split}README.md";
                var fs = new MockFileSystem(new Dictionary<string, MockFileData>
                {
                        { readme, new MockFileData(
                                @"### AutoRest Configuration
``` yaml
use-extension:
    ""@autorest/powershell"": ""3.x""
input-file:
    - $(repo)/specification/test.json
```
"
                        )}
                });

                var project = Project.FromFileSystem(fs, path);
                var arp = Assert.IsType<AutoRestProject>(project);
                Assert.Equal("v3", arp.AutoRestVersion);
                Assert.Equal("v3", project.SubType);

                // Now switch to 4.x
                fs.File.WriteAllText(readme,
                        @"### AutoRest Configuration
``` yaml
use-extension:
    ""@autorest/powershell"": ""4.x""
input-file:
    - $(repo)/specification/test.json
```
");
                // reconstruct to reload
                project = Project.FromFileSystem(fs, path);
                arp = Assert.IsType<AutoRestProject>(project);
                Assert.Equal("v4", arp.AutoRestVersion);
                Assert.Equal("v4", project.SubType);
        }

        [Fact]
        public void AutoRestVersion_Invalid_Value()
        {
                var cd = Directory.GetCurrentDirectory();
                var split = Path.DirectorySeparatorChar;
                var projectName = "Test4.AutoRest";
                var path = $"{cd}{split}{projectName}";
                var readme = $"{path}{split}README.md";
                var fs = new MockFileSystem(new Dictionary<string, MockFileData>
                {
                        { readme, new MockFileData(
                                @"### AutoRest Configuration
``` yaml
use-extension:
    ""@autorest/powershell"": ""5.x""
input-file:
    - $(repo)/specification/test.json
```
"
                        )}
                });

                var project = Project.FromFileSystem(fs, path);
                var arp = Assert.IsType<AutoRestProject>(project);
                Assert.Equal("Invalid", arp.AutoRestVersion);
                Assert.Equal("Invalid", project.SubType);
        }
}
