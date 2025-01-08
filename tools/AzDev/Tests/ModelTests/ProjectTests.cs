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
                @""
            )}
        });

        var project = Project.FromFileSystem(fs, path);
        Assert.Equal(path, project.Path);
        Assert.Equal(projectName, project.Name);
    }
}
