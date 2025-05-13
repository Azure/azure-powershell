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
        IFileSystem mockFs = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { @"C:\manifest.json", new MockFileData(@"[
                {
                    ""PackageName"": ""Azure.Core"",
                    ""PackageVersion"": ""1.44.1"",
                    ""TargetFramework"": ""netstandard2.0"",
                    ""WindowsPowerShell"": true,
                    ""PowerShell7Plus"": true
                }
            ]") },
            { @"C:\lib\netstandard2.0\Azure.Core.dll", new MockFileData(@"") },
            { @"C:\runtime.cs", new MockFileData(@"
            #region Generated
            #endregion
            ") },
            { @"C:\CgManifest.json", new MockFileData(@"{
                ""registrations"": []
            }") }
        });
        var mockNugetService = new Mock<INugetService>();
        mockNugetService.Setup(x => x.DownloadAssembly("Azure.Core", "1.44.1", "netstandard2.0", @"C:\lib", false))
            .Returns(@"C:\lib\netstandard2.0\Azure.Core.dll");
        var mockAssemblyMetadataService = new Mock<IAssemblyMetadataService>();
        mockAssemblyMetadataService.Setup(x => x.ParseAssemblyMetadata(@"C:\lib\netstandard2.0\Azure.Core.dll"))
            .Returns(new RuntimeAssembly
            {
                Name = "Azure.Core",
                Version = new Version(1, 44, 1),
                TargetFramework = "netstandard2.0"
            });
        var assemblyService = new DefaultAssemblyService(mockFs, mockNugetService.Object, NoopLogger.Instance, mockAssemblyMetadataService.Object);

        assemblyService.UpdateAssembly(@"C:\manifest.json", @"C:\lib", @"C:\runtime.cs", @"C:\CgManifest.json");
        mockNugetService.Verify(x => x.DownloadAssembly("Azure.Core", "1.44.1", "netstandard2.0", @"C:\lib", false), Times.Once);
        mockAssemblyMetadataService.Verify(x => x.ParseAssemblyMetadata(@"C:\lib\netstandard2.0\Azure.Core.dll"), Times.Once);
    }
}