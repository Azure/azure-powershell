using System.IO.Abstractions.TestingHelpers;
using AzDev.Models.Inventory;
using AzDev.Services;

namespace AzDev.Tests;

public class ModuleTests
{
    [Fact]
    public void CanCreateFromFileSystem()
    {
        var cd = Directory.GetCurrentDirectory();
        var split = Path.DirectorySeparatorChar;
        var moduleName = "Test";
        var path = $"{cd}{split}{moduleName}";
        var projectName = "Test.AutoRest";
                var fs = new MockFileSystem(new Dictionary<string, MockFileData>
                {
                        { $"{path}{split}{projectName}{split}Test.csproj", new MockFileData(@"") },
                        { $"{path}{split}{projectName}{split}README.md", new MockFileData(
                                @"### AutoRest Configuration
``` yaml
title: Test
input-file:
    - $(repo)/specification/test.json
```
") }
                });

        var module = Module.FromFileSystem(fs, new NoopLogger(), path);
        Assert.Equal(path, module.Path);
        Assert.Equal(moduleName, module.Name);
        Assert.Single(module.Projects);
    }

    [Fact]
    public void CanRecognizeBothProjectTypes()
    {
        var cd = Directory.GetCurrentDirectory();
        var split = Path.DirectorySeparatorChar;
        var moduleName = "Test";
        var path = $"{cd}{split}{moduleName}";
        var sdkProjectName = "Beta";
        var generatedProjectName = "Alpha.AutoRest";
                var fs = new MockFileSystem(new Dictionary<string, MockFileData>
                {
                        { $"{path}{split}{generatedProjectName}{split}Alpha.csproj", new MockFileData(@"") },
                        { $"{path}{split}{generatedProjectName}{split}README.md", new MockFileData(
                                @"### AutoRest Configuration
``` yaml
title: Test
input-file:
    - $(repo)/specification/test.json
```
") },
                        { $"{path}{split}{sdkProjectName}{split}Beta.csproj", new MockFileData(@"") },
                });

        var module = Module.FromFileSystem(fs, new NoopLogger(), path);
        Assert.Equal(2, module.Projects.Count());
        Assert.Equal(ProjectType.AutoRestBased, module.Projects.ElementAt(0).Type);
        Assert.Equal(ProjectType.Other, module.Projects.ElementAt(1).Type);
    }
}
