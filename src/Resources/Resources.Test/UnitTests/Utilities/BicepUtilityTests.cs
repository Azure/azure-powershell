// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using FluentAssertions;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    public class BicepUtilityTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestIsBicepFile()
        {
            Assert.True(BicepUtility.IsBicepFile("test.bicep"));
            Assert.False(BicepUtility.IsBicepFile("test.json"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestIsBicepparamFile()
        {
            Assert.True(BicepUtility.IsBicepparamFile("test.bicepparam"));
            Assert.False(BicepUtility.IsBicepparamFile("test.json"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildParams_returns_valid_parameter_output()
        {
            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.22.6 (d62b94db31)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "build-params \"foo.bicepparam\" --stdout")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "{\"parametersJson\":\"{\\n  \\\"$schema\\\": \\\"https://schema.management.azure.com/schemas/2019-04-01/deploymentParameters.json#\\\",\\n  \\\"contentVersion\\\": \\\"1.0.0.0\\\",\\n  \\\"parameters\\\": {\\n    \\\"tag1\\\": {\\n      \\\"value\\\": \\\"日本語テスト_param\\\"\\n    }\\n  }\\n}\",\"templateJson\":\"{\\n  \\\"$schema\\\": \\\"https://schema.management.azure.com/schemas/2018-05-01/subscriptionDeploymentTemplate.json#\\\",\\n  \\\"contentVersion\\\": \\\"1.0.0.0\\\",\\n  \\\"metadata\\\": {\\n    \\\"_generator\\\": {\\n      \\\"name\\\": \\\"bicep\\\",\\n      \\\"version\\\": \\\"0.22.6.54827\\\",\\n      \\\"templateHash\\\": \\\"6645562165406558166\\\"\\n    }\\n  },\\n  \\\"parameters\\\": {\\n    \\\"tag1\\\": {\\n      \\\"type\\\": \\\"string\\\"\\n    }\\n  },\\n  \\\"variables\\\": {\\n    \\\"tag2\\\": \\\"日本語テスト_var\\\"\\n  },\\n  \\\"resources\\\": [\\n    {\\n      \\\"type\\\": \\\"Microsoft.Resources/resourceGroups\\\",\\n      \\\"apiVersion\\\": \\\"2022-09-01\\\",\\n      \\\"name\\\": \\\"rg-bicepparam-test\\\",\\n      \\\"location\\\": \\\"japaneast\\\",\\n      \\\"tags\\\": {\\n        \\\"tagName1\\\": \\\"[parameters('tag1')]\\\",\\n        \\\"tagName2\\\": \\\"[variables('tag2')]\\\",\\n        \\\"tagName3\\\": \\\"日本語テスト_literal\\\"\\n      },\\n      \\\"properties\\\": {}\\n    }\\n  ]\\n}\",\"templateSpecId\":null}" });
            invokerMock.Setup(x => x.CheckExecutableExists("bicep"))
                .Returns(true);

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicepparam"))
                .Returns(true);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            var output = bicepUtility.BuildBicepParamFile("foo.bicepparam", new Dictionary<string, object>());
            var parameters = TemplateUtility.ParseTemplateParameterJson(output.parametersJson);

            parameters["tag1"].Value.Should().Be("日本語テスト_param");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildParams_fails_for_non_zero_exit_code()
        {
            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.22.6 (d62b94db31)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "build-params \"foo.bicepparam\" --stdout")))
                .Returns(new ProcessOutput { ExitCode = 1, Stderr = "Oops something went wrong!", Stdout = "" });
            invokerMock.Setup(x => x.CheckExecutableExists("bicep"))
                .Returns(true);

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicepparam"))
                .Returns(true);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            FluentActions.Invoking(() => bicepUtility.BuildBicepParamFile("foo.bicepparam", new Dictionary<string, object>()))
                .Should().Throw<AzPSApplicationException>().WithMessage("Oops something went wrong!");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildParams_fails_for_old_bicep_version()
        {
            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.15.1 (d62b94db31)" });
            invokerMock.Setup(x => x.CheckExecutableExists("bicep"))
                .Returns(true);

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicepparam"))
                .Returns(true);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            FluentActions.Invoking(() => bicepUtility.BuildBicepParamFile("foo.bicepparam", new Dictionary<string, object>()))
                .Should().Throw<AzPSApplicationException>().WithMessage("Please use bicep 0.16.1 or higher.");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildParams_falls_back_to_auto_install_when_bicep_missing_from_path()
        {
            var fakeProfileDirectory = "/fake/profile";
            var installedBicepPath = Path.Combine(fakeProfileDirectory, "bin", RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "bicep.exe" : "bicep");

            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.CheckExecutableExists("bicep"))
                .Returns(false);
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == installedBicepPath && p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.22.6 (d62b94db31)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == installedBicepPath && p.Arguments == "build-params \"foo.bicepparam\" --stdout")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "{\"parametersJson\":\"{}\",\"templateJson\":\"{}\",\"templateSpecId\":null}" });

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicepparam"))
                .Returns(true);

            var downloaderMock = new Mock<IBicepDownloader>();
            downloaderMock.Setup(x => x.GetLatestReleaseTag()).Returns("v0.22.6");
            downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(new byte[] { 1 });
            var installerDataStoreMock = new Mock<IDataStore>();
            installerDataStoreMock.Setup(x => x.FileExists(It.IsAny<string>())).Returns(false);
            installerDataStoreMock.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(true);
            var bicepInstaller = new BicepInstaller(downloaderMock.Object, installerDataStoreMock.Object, Mock.Of<IProcessInvoker>(), fakeProfileDirectory);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object, bicepInstaller);

            FluentActions.Invoking(() => bicepUtility.BuildBicepParamFile("foo.bicepparam", new Dictionary<string, object>()))
                .Should().NotThrow();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildParams_fails_for_missing_bicep_when_auto_install_fails()
        {
            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.CheckExecutableExists("bicep"))
                .Returns(false);

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicepparam"))
                .Returns(true);

            var downloaderMock = new Mock<IBicepDownloader>();
            downloaderMock.Setup(x => x.GetLatestReleaseTag()).Throws(new System.Exception("network error"));
            var installerDataStoreMock = new Mock<IDataStore>();
            installerDataStoreMock.Setup(x => x.FileExists(It.IsAny<string>())).Returns(false);
            installerDataStoreMock.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(true);
            var bicepInstaller = new BicepInstaller(downloaderMock.Object, installerDataStoreMock.Object, Mock.Of<IProcessInvoker>(), "/installed");

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object, bicepInstaller);

            FluentActions.Invoking(() => bicepUtility.BuildBicepParamFile("foo.bicepparam", new Dictionary<string, object>()))
                .Should().Throw<AzPSApplicationException>().WithMessage("Failed to automatically download Bicep: *");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildParams_fails_for_missing_param_file()
        {
            var invokerMock = new Mock<IProcessInvoker>();
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicepparam"))
                .Returns(false);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            FluentActions.Invoking(() => bicepUtility.BuildBicepParamFile("foo.bicepparam", new Dictionary<string, object>()))
                .Should().Throw<AzPSArgumentException>().WithMessage("Invalid Bicepparam file path.");
        }

        private static string NewRoot() => Path.Combine(Path.GetTempPath(), "bicep-util-" + System.Guid.NewGuid().ToString("N"));

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildBicepFile_uses_PATH_executable_when_its_version_satisfies_pinned_constraint()
        {
            var root = NewRoot();
            var entrypoint = Path.Combine(root, "main.bicep");
            var configPath = Path.Combine(root, "bicepconfig.json");

            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.CheckExecutableExists("bicep")).Returns(true);
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == "bicep" && p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.30.1 (abc123)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == $"build {GetQuoted(entrypoint)} --stdout")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "{}" });

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(entrypoint)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ \"bicep\": { \"version\": \">=0.26.0\" } }");

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            bicepUtility.BuildBicepFile(entrypoint);

            invokerMock.Verify(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == $"build {GetQuoted(entrypoint)} --stdout" && p.Executable == "bicep")), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildBicepFile_ignores_PATH_executable_and_uses_managed_install_when_its_version_does_not_satisfy_pinned_constraint()
        {
            var root = NewRoot();
            var entrypoint = Path.Combine(root, "main.bicep");
            var configPath = Path.Combine(root, "bicepconfig.json");
            var fakeProfileDirectory = "/fake/profile";
            var cachedDirectory = Path.Combine(fakeProfileDirectory, "bin", "bicep-0.30.1");
            var cachedPath = Path.Combine(cachedDirectory, RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "bicep.exe" : "bicep");

            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.CheckExecutableExists("bicep")).Returns(true);
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == "bicep" && p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.20.0 (abc123)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == cachedPath && p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.30.1 (abc123)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == cachedPath && p.Arguments == $"build {GetQuoted(entrypoint)} --stdout")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "{}" });

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(entrypoint)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ \"bicep\": { \"version\": \">=0.26.0\" } }");
            dataStoreMock.Setup(x => x.DirectoryExists(Path.Combine(fakeProfileDirectory, "bin"))).Returns(true);
            dataStoreMock.Setup(x => x.GetDirectories(Path.Combine(fakeProfileDirectory, "bin"))).Returns(new[] { cachedDirectory });

            var bicepInstaller = new BicepInstaller(Mock.Of<IBicepDownloader>(), dataStoreMock.Object, Mock.Of<IProcessInvoker>(), fakeProfileDirectory);
            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object, bicepInstaller);

            bicepUtility.BuildBicepFile(entrypoint);

            invokerMock.Verify(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == cachedPath && p.Arguments == $"build {GetQuoted(entrypoint)} --stdout")), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildBicepFile_downloads_matching_version_when_pinned_and_PATH_executable_is_missing()
        {
            var root = NewRoot();
            var entrypoint = Path.Combine(root, "main.bicep");
            var configPath = Path.Combine(root, "bicepconfig.json");
            var fakeProfileDirectory = "/fake/profile";
            var installedDirectory = Path.Combine(fakeProfileDirectory, "bin", "bicep-0.26.0");
            var installedPath = Path.Combine(installedDirectory, RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "bicep.exe" : "bicep");

            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.CheckExecutableExists("bicep")).Returns(false);
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == installedPath && p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.26.0 (abc123)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == installedPath && p.Arguments == $"build {GetQuoted(entrypoint)} --stdout")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "{}" });

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(entrypoint)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ \"bicep\": { \"version\": \"0.26.0\" } }");
            dataStoreMock.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(false);

            var downloaderMock = new Mock<IBicepDownloader>();
            downloaderMock.Setup(x => x.GetAvailableReleaseTags()).Returns(new[] { "v0.26.0", "v0.24.0" });
            downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(new byte[] { 1 });

            var bicepInstaller = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), fakeProfileDirectory);
            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object, bicepInstaller);

            bicepUtility.BuildBicepFile(entrypoint);

            invokerMock.Verify(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == installedPath && p.Arguments == $"build {GetQuoted(entrypoint)} --stdout")), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildBicepFile_only_resolves_executable_path_once_across_repeated_calls_on_the_same_instance()
        {
            // BicepUtility caches the resolved executable path/version in instance fields, so a single
            // cmdlet invocation calling BuildBicepFile/BuildBicepParamFile repeatedly skips re-resolving.
            var root = NewRoot();
            var entrypoint = Path.Combine(root, "main.bicep");
            var configPath = Path.Combine(root, "bicepconfig.json");

            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.CheckExecutableExists("bicep")).Returns(true);
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == "bicep" && p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.30.1 (abc123)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == $"build {GetQuoted(entrypoint)} --stdout")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "{}" });

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(entrypoint)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ \"bicep\": { \"version\": \">=0.26.0\" } }");

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            bicepUtility.BuildBicepFile(entrypoint);
            bicepUtility.BuildBicepFile(entrypoint);

            // PATH-check, "bicep -v", and config-file read together resolve the executable path/version;
            // if caching works, each happens only once despite BuildBicepFile being called twice.
            invokerMock.Verify(x => x.CheckExecutableExists("bicep"), Times.Once);
            invokerMock.Verify(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == "bicep" && p.Arguments == "-v")), Times.Once);
            dataStoreMock.Verify(x => x.ReadFileAsText(configPath), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildBicepFile_ignores_PATH_executable_and_uses_managed_install_when_its_version_output_is_unparsable()
        {
            // If "bicep -v" produces no recognizable version (e.g. corrupted build),
            // PathExecutableSatisfiesConstraint must treat it as "not satisfied" and fall
            // through to the managed/cached install, rather than throwing.
            var root = NewRoot();
            var entrypoint = Path.Combine(root, "main.bicep");
            var configPath = Path.Combine(root, "bicepconfig.json");
            var fakeProfileDirectory = "/fake/profile";
            var cachedDirectory = Path.Combine(fakeProfileDirectory, "bin", "bicep-0.30.1");
            var cachedPath = Path.Combine(cachedDirectory, RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "bicep.exe" : "bicep");

            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.CheckExecutableExists("bicep")).Returns(true);
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == "bicep" && p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "not a version string at all" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == cachedPath && p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.30.1 (abc123)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == cachedPath && p.Arguments == $"build {GetQuoted(entrypoint)} --stdout")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "{}" });

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(entrypoint)).Returns(true);
            dataStoreMock.Setup(x => x.FileExists(configPath)).Returns(true);
            dataStoreMock.Setup(x => x.ReadFileAsText(configPath)).Returns("{ \"bicep\": { \"version\": \">=0.26.0\" } }");
            dataStoreMock.Setup(x => x.DirectoryExists(Path.Combine(fakeProfileDirectory, "bin"))).Returns(true);
            dataStoreMock.Setup(x => x.GetDirectories(Path.Combine(fakeProfileDirectory, "bin"))).Returns(new[] { cachedDirectory });

            var bicepInstaller = new BicepInstaller(Mock.Of<IBicepDownloader>(), dataStoreMock.Object, Mock.Of<IProcessInvoker>(), fakeProfileDirectory);
            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object, bicepInstaller);

            bicepUtility.BuildBicepFile(entrypoint);

            invokerMock.Verify(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == cachedPath && p.Arguments == $"build {GetQuoted(entrypoint)} --stdout")), Times.Once);
        }

        private static string GetQuoted(string path) => $"\"{path}\"";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WithSource_adds_with_source_to_CLI()
        {
            var invokerMock = new Mock<IProcessInvoker>(MockBehavior.Strict);
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.23.1 (b02de2da48)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "publish \"foo.bicep\" --target \"br:example.azurecr.io/hello/world:v1\" --with-source")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "" });

            invokerMock.Setup(x => x.CheckExecutableExists("bicep"))
                .Returns(true);

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicep"))
                .Returns(true);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            bicepUtility.PublishFile("foo.bicep", "br:example.azurecr.io/hello/world:v1", null, withSource: true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WithSource_fails_for_old_bicep_version()
        {
            var invokerMock = new Mock<IProcessInvoker>(MockBehavior.Strict);
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.15.1 (d62b94db31)" });
            invokerMock.Setup(x => x.CheckExecutableExists("bicep"))
                .Returns(true);

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicep"))
                .Returns(true);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            FluentActions.Invoking(() => bicepUtility.PublishFile("foo.bicep", "br:example.azurecr.io/hello/world:v1", null, withSource: true))
                .Should().Throw<AzPSApplicationException>().WithMessage("Please use bicep 0.23.1 or higher.");
        }
    }
}
