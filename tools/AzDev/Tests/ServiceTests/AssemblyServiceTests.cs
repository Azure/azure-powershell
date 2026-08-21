using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using AzDev.Models.Assembly;
using AzDev.Services;
using AzDev.Services.Assembly;
using Moq;
using Xunit.Sdk;

namespace AzDev.Tests;

public class AssemblyServiceTests
{
    [Fact]
    public void DownloadAndInspectAssembly()
    {
        var root = Directory.GetCurrentDirectory();
        var s = Path.DirectorySeparatorChar;
        var manifestPath = $"{root}{s}manifest.json";
        var libPath = $"{root}{s}lib";
        var runtimePath = $"{root}{s}runtime.cs";
        var cgManifestPath = $"{root}{s}CgManifest.json";
        var dllPath = $"{root}{s}lib{s}netstandard2.0{s}Azure.Core.dll";

        IFileSystem mockFs = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { manifestPath, new MockFileData(@"[
                {
                    ""PackageName"": ""Azure.Core"",
                    ""PackageVersion"": ""1.44.1"",
                    ""TargetFramework"": ""netstandard2.0"",
                    ""WindowsPowerShell"": true,
                    ""PowerShell7Plus"": true
                }
            ]") },
            { dllPath, new MockFileData(@"") },
            { runtimePath, new MockFileData(@"
            #region Generated
            #endregion
            ") },
            { cgManifestPath, new MockFileData(@"{
                ""registrations"": []
            }") }
        });
        var mockNugetService = new Mock<INugetService>();
        mockNugetService.Setup(x => x.DownloadAssembly("Azure.Core", "1.44.1", "netstandard2.0", libPath, false))
            .Returns(dllPath);
        var mockAssemblyMetadataService = new Mock<IAssemblyMetadataService>();
        mockAssemblyMetadataService.Setup(x => x.ParseAssemblyMetadata(dllPath))
            .Returns(new RuntimeAssembly
            {
                Name = "Azure.Core",
                Version = new Version(1, 44, 1),
                TargetFramework = "netstandard2.0"
            });
        var assemblyService = new DefaultAssemblyService(mockFs, mockNugetService.Object, NoopLogger.Instance, mockAssemblyMetadataService.Object);

        assemblyService.UpdateAssembly(manifestPath, libPath, runtimePath, cgManifestPath);
        mockNugetService.Verify(x => x.DownloadAssembly("Azure.Core", "1.44.1", "netstandard2.0", libPath, false), Times.Once);
        mockAssemblyMetadataService.Verify(x => x.ParseAssemblyMetadata(dllPath), Times.Once);
    }
}