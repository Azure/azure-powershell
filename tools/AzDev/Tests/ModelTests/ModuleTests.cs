using System.IO.Abstractions.TestingHelpers;
using AzDev.Models.Inventory;

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
            { $"{path}{split}{projectName}{split}Test.csproj", new MockFileData(
                @""
            )}
        });

        var module = Module.FromFileSystem(fs, path);
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
            { $"{path}{split}{generatedProjectName}{split}Alpha.csproj", new MockFileData(
                @""
            )},
            { $"{path}{split}{sdkProjectName}{split}Beta.csproj", new MockFileData(
                @""
            )},
        });

        var module = Module.FromFileSystem(fs, path);
        Assert.Equal(2, module.Projects.Count());
        Assert.Equal(ProjectType.AutoRestBased, module.Projects.ElementAt(0).Type);
        Assert.Equal(ProjectType.Other, module.Projects.ElementAt(1).Type);
    }
}
