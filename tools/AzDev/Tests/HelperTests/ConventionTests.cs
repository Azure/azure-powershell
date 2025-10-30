using System.IO.Abstractions.TestingHelpers;
using AzDev.Models.Inventory;
using AzDev.Services;

namespace AzDev.Tests;

public class ConventionTests
{
    [Fact]
    public void CanDetectLegacyHelperProject()
    {
        var path = "C:/path/to/project/Project.helper";
        Assert.True(Conventions.IsLegacyHelperProject(path, out var reason));
        Assert.NotNull(reason);

        path = "C:/path/to/project/Project.helpers";
        Assert.True(Conventions.IsLegacyHelperProject(path, out reason));
        Assert.NotNull(reason);

        path = "C:/path/to/project/Compute";
        Assert.False(Conventions.IsLegacyHelperProject(path, out reason));
        Assert.NotNull(reason);
    }

    [Fact]
    public void CanDetectTestProject()
    {
        var path = "C:/path/to/project/Project.test";
        Assert.True(Conventions.IsTestProject(path, out var reason));
        Assert.NotNull(reason);

        path = "C:/path/to/project/Compute";
        Assert.False(Conventions.IsTestProject(path, out reason));
        Assert.NotNull(reason);
    }

    [Fact]
    public void CanDetectTrack1SdkProject()
    {
        var path = "C:/path/to/project/Project.management.sdk";
        Assert.True(Conventions.IsTrack1SdkProject(path, out var reason));
        Assert.NotNull(reason);

        path = "C:/path/to/project/Compute";
        Assert.False(Conventions.IsTrack1SdkProject(path, out reason));
        Assert.NotNull(reason);
    }

    [Fact]
    public void CanDetectAutorestBasedProject()
    {
        var path = "C:/path/to/project/Project.autorest";
        Assert.True(Conventions.IsAutorestBasedProject(path, out var reason));
        Assert.NotNull(reason);

        path = "C:/path/to/project/Compute";
        Assert.False(Conventions.IsAutorestBasedProject(path, out reason));
        Assert.NotNull(reason);
    }

    [Fact]
    public void CanDetectWrapperProject()
    {
        var cd = Directory.GetCurrentDirectory();
        var split = Path.DirectorySeparatorChar;
        var moduleName = "Test";
        var modulePath = $"{cd}{split}{moduleName}";
        var wrapperProjPath = $"{modulePath}{split}Test";
        var autorestProjPath = $"{modulePath}{split}Test.AutoRest";
        var fs = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            {
                $"{autorestProjPath}{split}README.md", new MockFileData(
                    @""
                )
            },
            {
                $"{wrapperProjPath}{split}Test.csproj", new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>
                        </PropertyGroup>
                    </Project>"
                )
            }
        });

        Assert.True(Conventions.IsWrapperProject(fs, wrapperProjPath, out var reason), $"Reason: {reason}");
        Assert.True(Conventions.IsAutorestBasedProject(autorestProjPath, out reason), $"Reason: {reason}");
    }

    [Fact]
    public void CanDetectWrapperProjectNegative()
    {
        var cd = Directory.GetCurrentDirectory();
        var split = Path.DirectorySeparatorChar;
        var moduleName = "Test";
        var modulePath = $"{cd}{split}{moduleName}";
        var wrapperProjPath = $"{modulePath}{split}Test";
        var autorestProjPath = $"{modulePath}{split}Test.AutoRest";
        var fs = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            {
                $"{autorestProjPath}{split}README.md", new MockFileData(
                    @""
                )
            },
            {
                $"{wrapperProjPath}{split}Test.csproj", new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>'
                            <PackageReference Include=""Microsoft.Azure.Management.Compute"" Version=""1.0.0"" />
                        </PropertyGroup>
                    </Project>"
                )
            }
        });

        Assert.False(Conventions.IsWrapperProject(fs, wrapperProjPath, out var reason), $"Reason: {reason}");
    }

    [Fact]
    public void CanDetectSdkBasedProject()
    {
        var cd = Directory.GetCurrentDirectory();
        var split = Path.DirectorySeparatorChar;
        var moduleName = "Test";
        var modulePath = $"{cd}{split}{moduleName}";
        var wrapperProjPath = $"{modulePath}{split}Test";
        var autorestProjPath = $"{modulePath}{split}Test.AutoRest";
        var track1SdkBasedProjPath = $"{modulePath}{split}Test.Management";
        var newSdkBasedProjPath = $"{modulePath}{split}Test2";
        var helperSdkBasedProjPath = $"{modulePath}{split}Test3";
        var track1DataPlaneSdkBasedProjPath = $"{modulePath}{split}Test.DataPlane";
        var track2DataPlaneSdkBasedProjPath = $"{modulePath}{split}Test.DataPlane2";
        var otherProjPath = $"{modulePath}{split}Test.Other";
        var fs = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            {
                $"{autorestProjPath}{split}README.md", new MockFileData(
                    @""
                )
            },
            {
                $"{wrapperProjPath}{split}Test.csproj", new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>'
                        </PropertyGroup>
                    </Project>"
                )
            },
            {
                $"{track1SdkBasedProjPath}{split}Test.Management.csproj", new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>
                            <PackageReference Include=""Microsoft.Azure.Management.Compute"" Version=""1.0.0"" />
                        </PropertyGroup>
                    </Project>"
                )
            },
            {
                $"{otherProjPath}{split}Other.csproj", new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>
                            <PackageReference Include=""Newtonsoft.Json"" Version=""1.0.0"" />
                        </PropertyGroup>
                    </Project>"
                )
            },
            {
                $"{newSdkBasedProjPath}{split}Test2.csproj", new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>
                            <ProjectReference Include=""..\NetAppFiles.Management.Sdk\NetAppFiles.Management.Sdk.csproj"" />
                        </PropertyGroup>
                    </Project>"
                )
            },
            {
                $"{track1DataPlaneSdkBasedProjPath}{split}Test.DataPlane.csproj", new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>
                            <PackageReference Include=""Microsoft.Azure.KeyVault"" Version=""1.0.0"" />
                        </PropertyGroup>
                    </Project>"
                )
            },
            {
                $"{track2DataPlaneSdkBasedProjPath}{split}Test.DataPlane2.csproj", new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>
                            <PackageReference Include=""Azure.Security.KeyVault"" Version=""1.0.0"" />
                        </PropertyGroup>
                    </Project>"
                )
            },
            {
                $"{helperSdkBasedProjPath}{split}Test3.csproj", new MockFileData(
                    @"<Project Sdk=""Microsoft.NET.Sdk"">
                        <PropertyGroup>
                            <TargetFramework>netstandard2.0</TargetFramework>
                            <ProjectReference Include=""..\Ssh.Helpers\Ssh.Helpers.csproj"" />
                        </PropertyGroup>
                    </Project>"
                )
            }
        });
        Assert.True(Conventions.IsSdkBasedProject(fs, track1SdkBasedProjPath, out var reason), $"Reason: {reason}");
        Assert.True(Conventions.IsSdkBasedProject(fs, newSdkBasedProjPath, out reason), $"Reason: {reason}");
        Assert.True(Conventions.IsSdkBasedProject(fs, helperSdkBasedProjPath, out reason), $"Reason: {reason}");
        Assert.True(Conventions.IsSdkBasedProject(fs, track1DataPlaneSdkBasedProjPath, out reason), $"Reason: {reason}");
        Assert.True(Conventions.IsSdkBasedProject(fs, track2DataPlaneSdkBasedProjPath, out reason), $"Reason: {reason}");
        Assert.False(Conventions.IsSdkBasedProject(fs, wrapperProjPath, out reason), $"Reason: {reason}");
        Assert.False(Conventions.IsSdkBasedProject(fs, autorestProjPath, out reason), $"Reason: {reason}");
        Assert.False(Conventions.IsSdkBasedProject(fs, otherProjPath, out reason), $"Reason: {reason}");
    }

    [Fact]
    public void CanDeductModuleType()
    {
        Project autorestProj = new AutoRestProject() {Type = ProjectType.AutoRestBased};
        Project sdkProj = new SdkBasedProject() {Type = ProjectType.SdkBased};
        Module hybridModule = new Module() {Projects = new List<Project> {autorestProj, sdkProj}};
        Assert.Equal(ModuleType.Hybrid, Conventions.DeductModuleType(hybridModule.Projects, out _));

        Project wrapperProj = new WrapperProject() {Type = ProjectType.Wrapper};
        Module wrapperModule = new Module() {Projects = new List<Project> {wrapperProj, autorestProj}};
        Assert.Equal(ModuleType.AutoRestBased, Conventions.DeductModuleType(wrapperModule.Projects, out _));

        Project legacyHelperProj = new SdkBasedProject() {Type = ProjectType.LegacyHelper};
        Project track1SdkProj = new SdkBasedProject() {Type = ProjectType.Track1Sdk};
        Module sdkModule = new Module() {Projects = new List<Project> {sdkProj, legacyHelperProj}};
        Assert.Equal(ModuleType.SdkBased, Conventions.DeductModuleType(sdkModule.Projects, out _));
        sdkModule = new Module() {Projects = new List<Project> {sdkProj, track1SdkProj}};
        Assert.Equal(ModuleType.SdkBased, Conventions.DeductModuleType(sdkModule.Projects, out _));
    }

    [Theory]
    [InlineData("", "v4")] // empty defaults to v4
    [InlineData("3.0.0", "v3")]
    [InlineData("3.9.1", "v3")]
    [InlineData("3.10.1-nightly.20240801", "v3")]
    [InlineData("4.0.0", "v4")]
    [InlineData("4.8.2", "v4")]
    [InlineData("preview", "Invalid")]
    [InlineData("5.0.0", "Invalid")]
    public void MapAutoRestPowerShellVersion_BasicCases(string input, string expected)
    {
        var actual = Conventions.MapAutoRestPowerShellVersion(input);
        Assert.Equal(expected, actual);
    }
}
