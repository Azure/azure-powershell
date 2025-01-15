using System.IO.Abstractions.TestingHelpers;
using AzDev.Models.Inventory;
using AzDev.Services;

namespace AzDev.Tests;

public class CsprojReaderTests
{
    [Fact]
    public void CanParse()
    {
        var emptyProject = @"c:/repo/src/MyProject/MyProject.csproj";
        var projectWithPackageReferences = @"c:/repo/src/MyProject/Package.csproj";
        var projectWithProjectReferences = @"c:/repo/src/MyProject/Project.csproj";
        var projectWithBothReferences = @"c:/repo/src/MyProject/Both.csproj";
        var fs = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            {
                emptyProject, new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>
                        </PropertyGroup>
                    </Project>"
                )
            },
            {
                projectWithPackageReferences, new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>
                        </PropertyGroup>
                        <ItemGroup>
                            <PackageReference Include=""Newtonsoft.Json"" Version=""12.0.3"" />
                            <PackageReference Include=""System.Text.Json"" Version=""4.7.2"" />
                        </ItemGroup>
                    </Project>"
                )
            },
            {
                projectWithProjectReferences, new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>
                        </PropertyGroup>
                        <ItemGroup>
                            <ProjectReference Include=""..\MyProject\MyProject.csproj"" />
                            <ProjectReference Include=""..\OtherProject\OtherProject.csproj"" />
                        </ItemGroup>
                    </Project>"
                )
            },
            {
                projectWithBothReferences, new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>
                        </PropertyGroup>
                        <ItemGroup>
                            <PackageReference Include=""Newtonsoft.Json"" Version=""12.0.3"" />
                            <PackageReference Include=""System.Text.Json"" Version=""4.7.2"" />
                            <ProjectReference Include=""..\MyProject\MyProject.csproj"" />
                            <ProjectReference Include=""..\OtherProject\OtherProject.csproj"" />
                        </ItemGroup>
                    </Project>"
                )
            }
        });

        var project = CsprojReader.Parse(fs.File.ReadAllText(emptyProject));
        Assert.Empty(project.PackageReferences);
        Assert.Empty(project.ProjectReferences);

        project = CsprojReader.Parse(fs.File.ReadAllText(projectWithPackageReferences));
        Assert.Equal(2, project.PackageReferences.Count());
        Assert.Contains("Newtonsoft.Json", project.PackageReferences);
        Assert.Contains("System.Text.Json", project.PackageReferences);
        Assert.Empty(project.ProjectReferences);

        project = CsprojReader.Parse(fs.File.ReadAllText(projectWithProjectReferences));
        Assert.Empty(project.PackageReferences);
        Assert.Equal(2, project.ProjectReferences.Count());
        Assert.Contains(@"..\MyProject\MyProject.csproj", project.ProjectReferences);
        Assert.Contains(@"..\OtherProject\OtherProject.csproj", project.ProjectReferences);

        project = CsprojReader.Parse(fs.File.ReadAllText(projectWithBothReferences));
        Assert.Equal(2, project.PackageReferences.Count());
        Assert.Contains("Newtonsoft.Json", project.PackageReferences);
        Assert.Contains("System.Text.Json", project.PackageReferences);
        Assert.Equal(2, project.ProjectReferences.Count());
        Assert.Contains(@"..\MyProject\MyProject.csproj", project.ProjectReferences);
        Assert.Contains(@"..\OtherProject\OtherProject.csproj", project.ProjectReferences);
    }
}