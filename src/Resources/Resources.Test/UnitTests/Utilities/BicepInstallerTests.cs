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

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using FluentAssertions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    public class BicepInstallerTests
    {
        private const string FakeProfileDirectory = "/fake/profile";

        private static string ExpectedFileName => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "bicep.exe" : "bicep";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetInstallationPath_combines_profile_directory_bin_and_platform_specific_file_name()
        {
            var installer = new BicepInstaller(
                Mock.Of<IBicepDownloader>(),
                Mock.Of<IDataStore>(),
                Mock.Of<IProcessInvoker>(),
                FakeProfileDirectory);

            installer.GetInstallationDirectory().Should().Be(Path.Combine(FakeProfileDirectory, "bin"));
            installer.GetInstallationPath().Should().Be(Path.Combine(FakeProfileDirectory, "bin", ExpectedFileName));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnsureInstalled_returns_existing_path_without_downloading_when_already_installed()
        {
            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();
            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            var expectedPath = Path.Combine(FakeProfileDirectory, "bin", ExpectedFileName);
            dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(true);

            var result = installer.EnsureInstalled();

            result.Should().Be(expectedPath);
            downloaderMock.Verify(x => x.GetLatestReleaseTag(), Times.Never);
            downloaderMock.Verify(x => x.DownloadFile(It.IsAny<string>()), Times.Never);
            dataStoreMock.Verify(x => x.WriteFile(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnsureInstalled_downloads_and_writes_file_when_not_already_installed()
        {
            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();
            var processInvokerMock = new Mock<IProcessInvoker>();

            var expectedPath = Path.Combine(FakeProfileDirectory, "bin", ExpectedFileName);
            var installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            var fakeBytes = Encoding.UTF8.GetBytes("fake-bicep-binary");

            dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(false);
            dataStoreMock.Setup(x => x.DirectoryExists(installationDirectory)).Returns(false);
            downloaderMock.Setup(x => x.GetLatestReleaseTag()).Returns("v0.26.54");
            downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(fakeBytes);

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, processInvokerMock.Object, FakeProfileDirectory);

            var verboseMessages = new List<string>();
            var result = installer.EnsureInstalled(msg => verboseMessages.Add(msg));

            result.Should().Be(expectedPath);
            dataStoreMock.Verify(x => x.CreateDirectory(installationDirectory), Times.Once);
            dataStoreMock.Verify(x => x.WriteFile(expectedPath, fakeBytes), Times.Once);
            verboseMessages.Should().Contain(Properties.Resources.BicepAutoInstallStarting);
            verboseMessages.Should().Contain(string.Format(Properties.Resources.BicepAutoInstallComplete, "v0.26.54"));

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                processInvokerMock.Verify(x => x.Invoke(It.Is<ProcessInput>(p => p.Executable == "chmod")), Times.Once);
            }
            else
            {
                processInvokerMock.Verify(x => x.Invoke(It.IsAny<ProcessInput>()), Times.Never);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnsureInstalled_does_not_recreate_directory_when_it_already_exists()
        {
            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();

            var installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            var expectedPath = Path.Combine(installationDirectory, ExpectedFileName);

            dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(false);
            dataStoreMock.Setup(x => x.DirectoryExists(installationDirectory)).Returns(true);
            downloaderMock.Setup(x => x.GetLatestReleaseTag()).Returns("v0.26.54");
            downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(new byte[] { 1, 2, 3 });

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            installer.EnsureInstalled();

            dataStoreMock.Verify(x => x.CreateDirectory(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnsureInstalled_builds_download_url_from_latest_release_tag()
        {
            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();

            dataStoreMock.Setup(x => x.FileExists(It.IsAny<string>())).Returns(false);
            dataStoreMock.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(true);
            downloaderMock.Setup(x => x.GetLatestReleaseTag()).Returns("v0.26.54");
            downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(new byte[] { 1 });

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            installer.EnsureInstalled();

            var expectedExtension = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ".exe" : "";
            string expectedPlatform;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                expectedPlatform = RuntimeInformation.ProcessArchitecture == Architecture.Arm64 ? "win-arm64" : "win-x64";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                expectedPlatform = RuntimeInformation.ProcessArchitecture == Architecture.Arm64 ? "osx-arm64" : "osx-x64";
            }
            else
            {
                expectedPlatform = RuntimeInformation.ProcessArchitecture == Architecture.Arm64 ? "linux-arm64" : "linux-x64";
            }

            var expectedUrl = $"https://downloads.bicep.azure.com/v0.26.54/bicep-{expectedPlatform}{expectedExtension}";
            downloaderMock.Verify(x => x.DownloadFile(expectedUrl), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnsureInstalled_selects_musl_asset_when_musl_present_without_glibc()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
            {
                return;
            }

            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();

            dataStoreMock.Setup(x => x.FileExists(It.IsAny<string>())).Returns(false);
            dataStoreMock.Setup(x => x.FileExists("/lib/ld-musl-x86_64.so.1")).Returns(true);
            dataStoreMock.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(true);
            downloaderMock.Setup(x => x.GetLatestReleaseTag()).Returns("v0.26.54");
            downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(new byte[] { 1 });

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            installer.EnsureInstalled();

            downloaderMock.Verify(x => x.DownloadFile("https://downloads.bicep.azure.com/v0.26.54/bicep-linux-musl-x64"), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnsureInstalled_throws_when_download_fails()
        {
            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();

            dataStoreMock.Setup(x => x.FileExists(It.IsAny<string>())).Returns(false);
            dataStoreMock.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(true);
            downloaderMock.Setup(x => x.GetLatestReleaseTag()).Throws(new Exception("network error"));

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            Assert.Throws<AzPSApplicationException>(() => installer.EnsureInstalled());
            dataStoreMock.Verify(x => x.WriteFile(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetInstalledVersions_returns_empty_when_installation_directory_does_not_exist()
        {
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(false);

            var installer = new BicepInstaller(Mock.Of<IBicepDownloader>(), dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            installer.GetInstalledVersions().Should().BeEmpty();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetInstalledVersions_parses_versioned_subdirectories_and_ignores_others()
        {
            var installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.DirectoryExists(installationDirectory)).Returns(true);
            dataStoreMock.Setup(x => x.GetDirectories(installationDirectory)).Returns(new[]
            {
                Path.Combine(installationDirectory, "bicep-0.26.0"),
                Path.Combine(installationDirectory, "bicep-0.30.1"),
                Path.Combine(installationDirectory, "not-a-version-dir"),
            });

            var installer = new BicepInstaller(Mock.Of<IBicepDownloader>(), dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            var versions = installer.GetInstalledVersions();

            versions.Should().HaveCount(2);
            versions.Should().Contain(v => v.ToString() == "0.26.0");
            versions.Should().Contain(v => v.ToString() == "0.30.1");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnsureInstalled_with_constraint_reuses_cached_version_without_downloading()
        {
            var installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            var cachedDirectory = Path.Combine(installationDirectory, "bicep-0.26.0");
            var expectedPath = Path.Combine(cachedDirectory, ExpectedFileName);

            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.DirectoryExists(installationDirectory)).Returns(true);
            dataStoreMock.Setup(x => x.GetDirectories(installationDirectory)).Returns(new[] { cachedDirectory });

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);
            var constraint = BicepVersionConstraint.Parse(">=0.26.0", "bicepconfig.json");

            var result = installer.EnsureInstalled(constraint);

            result.Should().Be(expectedPath);
            downloaderMock.Verify(x => x.GetAvailableReleaseTags(), Times.Never);
            downloaderMock.Verify(x => x.DownloadFile(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnsureInstalled_with_constraint_downloads_highest_matching_release_when_not_cached()
        {
            var installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            var expectedDirectory = Path.Combine(installationDirectory, "bicep-0.30.1");
            var expectedPath = Path.Combine(expectedDirectory, ExpectedFileName);
            var fakeBytes = Encoding.UTF8.GetBytes("fake-bicep-binary");

            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(false);
            downloaderMock.Setup(x => x.GetAvailableReleaseTags()).Returns(new[] { "v0.32.0", "v0.30.1", "v0.25.0" });
            downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(fakeBytes);

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);
            var constraint = BicepVersionConstraint.Parse("<=0.30.1", "bicepconfig.json");

            var result = installer.EnsureInstalled(constraint);

            result.Should().Be(expectedPath);
            dataStoreMock.Verify(x => x.CreateDirectory(expectedDirectory), Times.Once);
            dataStoreMock.Verify(x => x.WriteFile(expectedPath, fakeBytes), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnsureInstalled_with_constraint_throws_when_no_release_satisfies_it()
        {
            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(false);
            downloaderMock.Setup(x => x.GetAvailableReleaseTags()).Returns(new[] { "v0.25.0", "v0.24.0" });

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);
            var constraint = BicepVersionConstraint.Parse(">=0.26.0", "bicepconfig.json");

            FluentActions.Invoking(() => installer.EnsureInstalled(constraint))
                .Should().Throw<AzPSApplicationException>().WithMessage("*>=0.26.0*");
            dataStoreMock.Verify(x => x.WriteFile(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnsureInstalled_with_null_constraint_falls_back_to_unpinned_behavior()
        {
            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();

            var expectedPath = Path.Combine(FakeProfileDirectory, "bin", ExpectedFileName);
            dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(true);

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            var result = installer.EnsureInstalled((BicepVersionConstraint)null);

            result.Should().Be(expectedPath);
            downloaderMock.Verify(x => x.GetAvailableReleaseTags(), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InstallVersion_with_no_version_downloads_latest_when_not_cached()
        {
            var installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            var expectedDirectory = Path.Combine(installationDirectory, "bicep-0.26.54");
            var expectedPath = Path.Combine(expectedDirectory, ExpectedFileName);
            var fakeBytes = Encoding.UTF8.GetBytes("fake-bicep-binary");

            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(false);
            dataStoreMock.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(false);
            downloaderMock.Setup(x => x.GetLatestReleaseTag()).Returns("v0.26.54");
            downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(fakeBytes);

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            var result = installer.InstallVersion(null);

            result.ToString().Should().Be("0.26.54");
            dataStoreMock.Verify(x => x.WriteFile(expectedPath, fakeBytes), Times.Once);
            downloaderMock.Verify(x => x.GetAvailableReleaseTags(), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InstallVersion_with_no_version_skips_download_when_latest_already_cached()
        {
            var installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            var cachedDirectory = Path.Combine(installationDirectory, "bicep-0.26.54");
            var expectedPath = Path.Combine(cachedDirectory, ExpectedFileName);

            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(true);
            downloaderMock.Setup(x => x.GetLatestReleaseTag()).Returns("v0.26.54");

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            var verboseMessages = new List<string>();
            var result = installer.InstallVersion(null, msg => verboseMessages.Add(msg));

            result.ToString().Should().Be("0.26.54");
            dataStoreMock.Verify(x => x.WriteFile(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Never);
            verboseMessages.Should().Contain(string.Format(Properties.Resources.BicepVersionAlreadyInstalled, result));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InstallVersion_with_specific_version_downloads_matching_release_tag()
        {
            var installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            var expectedDirectory = Path.Combine(installationDirectory, "bicep-0.30.1");
            var expectedPath = Path.Combine(expectedDirectory, ExpectedFileName);
            var fakeBytes = Encoding.UTF8.GetBytes("fake-bicep-binary");

            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(false);
            dataStoreMock.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(false);
            downloaderMock.Setup(x => x.GetAvailableReleaseTags()).Returns(new[] { "v0.32.0", "v0.30.1", "v0.25.0" });
            downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(fakeBytes);

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            var result = installer.InstallVersion("0.30.1");

            result.ToString().Should().Be("0.30.1");
            dataStoreMock.Verify(x => x.WriteFile(expectedPath, fakeBytes), Times.Once);
            downloaderMock.Verify(x => x.GetLatestReleaseTag(), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InstallVersion_with_specific_version_skips_download_when_already_cached()
        {
            var installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            var cachedDirectory = Path.Combine(installationDirectory, "bicep-0.30.1");
            var expectedPath = Path.Combine(cachedDirectory, ExpectedFileName);

            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(true);

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            var result = installer.InstallVersion("0.30.1");

            result.ToString().Should().Be("0.30.1");
            dataStoreMock.Verify(x => x.WriteFile(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Never);
            downloaderMock.Verify(x => x.GetAvailableReleaseTags(), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InstallVersion_throws_when_requested_version_has_no_matching_release()
        {
            var downloaderMock = new Mock<IBicepDownloader>();
            var dataStoreMock = new Mock<IDataStore>();
            downloaderMock.Setup(x => x.GetAvailableReleaseTags()).Returns(new[] { "v0.25.0", "v0.24.0" });

            var installer = new BicepInstaller(downloaderMock.Object, dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            FluentActions.Invoking(() => installer.InstallVersion("0.99.0"))
                .Should().Throw<AzPSApplicationException>().WithMessage("*0.99.0*");
            dataStoreMock.Verify(x => x.WriteFile(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InstallVersion_throws_for_invalid_version_format()
        {
            var installer = new BicepInstaller(Mock.Of<IBicepDownloader>(), Mock.Of<IDataStore>(), Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            FluentActions.Invoking(() => installer.InstallVersion("not-a-version"))
                .Should().Throw<AzPSApplicationException>().WithMessage("*not-a-version*");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UninstallAll_deletes_installation_directory_when_it_exists()
        {
            var installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.DirectoryExists(installationDirectory)).Returns(true);

            var installer = new BicepInstaller(Mock.Of<IBicepDownloader>(), dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            var result = installer.UninstallAll();

            result.Should().BeTrue();
            dataStoreMock.Verify(x => x.DeleteDirectory(installationDirectory), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UninstallAll_returns_false_and_does_not_delete_when_nothing_installed()
        {
            var installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.DirectoryExists(installationDirectory)).Returns(false);

            var installer = new BicepInstaller(Mock.Of<IBicepDownloader>(), dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            var verboseMessages = new List<string>();
            var result = installer.UninstallAll(msg => verboseMessages.Add(msg));

            result.Should().BeFalse();
            dataStoreMock.Verify(x => x.DeleteDirectory(It.IsAny<string>()), Times.Never);
            verboseMessages.Should().Contain(Properties.Resources.BicepUninstallNothingInstalled);
        }
    }
}
