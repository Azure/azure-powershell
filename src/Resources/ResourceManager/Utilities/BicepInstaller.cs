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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.Common.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Handles automatically downloading and installing Bicep when it cannot be found on the PATH,
    /// mirroring the behavior of the Azure CLI's Bicep auto-install support.
    /// </summary>
    internal class BicepInstaller
    {
        private const string DownloadUrlTemplate = "https://downloads.bicep.azure.com/{0}/bicep-{1}{2}";

        /// <summary>
        /// Prefix used for the per-version cache subdirectories created when a 'bicep.version'
        /// constraint is in effect, e.g. "bin/bicep-0.26.0/".
        /// </summary>
        private const string VersionedDirectoryPrefix = "bicep-";

        private readonly IBicepDownloader downloader;
        private readonly IDataStore dataStore;
        private readonly IProcessInvoker processInvoker;
        private readonly string profileDirectory;

        public static BicepInstaller Create()
            => new BicepInstaller(BicepDownloader.Create(), FileUtilities.DataStore, ProcessInvoker.Create(), AzureSession.Instance.ProfileDirectory);

        public BicepInstaller(IBicepDownloader downloader, IDataStore dataStore, IProcessInvoker processInvoker, string profileDirectory)
        {
            this.downloader = downloader;
            this.dataStore = dataStore;
            this.processInvoker = processInvoker;
            this.profileDirectory = profileDirectory;
        }

        /// <summary>
        /// The directory Bicep is installed to: "{ProfileDirectory}/bin". This is used only for the unpinned
        /// (no 'bicep.version' constraint) case; pinned versions are cached separately, see
        /// <see cref="GetVersionedInstallationDirectory"/>.
        /// </summary>
        public string GetInstallationDirectory()
            => Path.Combine(profileDirectory, "bin");

        /// <summary>
        /// The full path to the unpinned Bicep executable.
        /// </summary>
        public string GetInstallationPath()
            => Path.Combine(GetInstallationDirectory(), IsWindows() ? "bicep.exe" : "bicep");

        /// <summary>
        /// The cache directory for a specific installed Bicep version, e.g. "{bin}/bicep-0.26.0/".
        /// Multiple pinned versions are cached side-by-side so that switching between projects
        /// pinned to different versions does not require re-downloading each time.
        /// </summary>
        public string GetVersionedInstallationDirectory(BicepSemanticVersion version)
            => Path.Combine(GetInstallationDirectory(), VersionedDirectoryPrefix + version.ToString());

        /// <summary>
        /// The full path to the Bicep executable for a specific version.
        /// </summary>
        public string GetVersionedInstallationPath(BicepSemanticVersion version)
            => Path.Combine(GetVersionedInstallationDirectory(version), IsWindows() ? "bicep.exe" : "bicep");

        /// <summary>
        /// Enumerates the versions currently cached under the installation directory, by
        /// scanning for "bicep-{version}" subdirectories.
        /// </summary>
        public IReadOnlyList<BicepSemanticVersion> GetInstalledVersions()
        {
            var versions = new List<BicepSemanticVersion>();

            var baseDirectory = GetInstallationDirectory();
            if (!dataStore.DirectoryExists(baseDirectory))
            {
                return versions;
            }

            foreach (var directory in dataStore.GetDirectories(baseDirectory))
            {
                var name = Path.GetFileName(directory);
                if (name == null || !name.StartsWith(VersionedDirectoryPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                BicepSemanticVersion version;
                if (BicepSemanticVersion.TryParse(name.Substring(VersionedDirectoryPrefix.Length), out version))
                {
                    versions.Add(version);
                }
            }

            return versions;
        }

        /// <summary>
        /// Parses a GitHub release tag (e.g. "v0.26.54") into a <see cref="BicepSemanticVersion"/>.
        /// Unlike a 'bicep.version' config value, release tags are always "v"-prefixed, so that
        /// prefix is stripped here rather than in <see cref="BicepSemanticVersion"/> itself (which
        /// otherwise mirrors the Bicep compiler's own, stricter parsing).
        /// </summary>
        private static bool TryParseReleaseTag(string tag, out BicepSemanticVersion version)
        {
            version = null;
            if (string.IsNullOrEmpty(tag))
            {
                return false;
            }

            var trimmed = tag.StartsWith("v", StringComparison.OrdinalIgnoreCase) ? tag.Substring(1) : tag;
            return BicepSemanticVersion.TryParse(trimmed, out version);
        }

        /// <summary>
        /// Returns the highest cached installed version that satisfies the given constraint, or
        /// null if none of the currently-cached versions satisfy it.
        /// </summary>
        public BicepSemanticVersion FindSatisfyingInstalledVersion(BicepVersionConstraint constraint)
        {
            BicepSemanticVersion best = null;
            foreach (var version in GetInstalledVersions())
            {
                if (constraint.IsSatisfiedBy(version) && (best == null || version.CompareTo(best) > 0))
                {
                    best = version;
                }
            }

            return best;
        }

        /// <summary>
        /// Returns the path to a working Bicep installation, downloading and installing it first if necessary.
        /// </summary>
        public string EnsureInstalled(BicepUtility.OutputCallback writeVerbose = null)
        {
            var installationPath = GetInstallationPath();
            if (dataStore.FileExists(installationPath))
            {
                return installationPath;
            }

            writeVerbose?.Invoke(Properties.Resources.BicepAutoInstallStarting);

            string releaseTag;
            try
            {
                releaseTag = downloader.GetLatestReleaseTag();
            }
            catch (Exception ex)
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BicepDownloadFailed, ex.Message));
            }

            DownloadAndInstall(releaseTag, installationPath);

            writeVerbose?.Invoke(string.Format(Properties.Resources.BicepAutoInstallComplete, releaseTag));

            return installationPath;
        }

        /// <summary>
        /// Returns the path to a Bicep installation satisfying the given 'bicep.version' constraint,
        /// downloading and caching a matching version first if necessary. If <paramref name="constraint"/>
        /// is null, this delegates to the unpinned <see cref="EnsureInstalled(BicepUtility.OutputCallback)"/> behavior.
        /// </summary>
        public string EnsureInstalled(BicepVersionConstraint constraint, BicepUtility.OutputCallback writeVerbose = null)
        {
            if (constraint == null)
            {
                return EnsureInstalled(writeVerbose);
            }

            var existingVersion = FindSatisfyingInstalledVersion(constraint);
            if (existingVersion != null)
            {
                return GetVersionedInstallationPath(existingVersion);
            }

            writeVerbose?.Invoke(Properties.Resources.BicepAutoInstallStarting);

            IReadOnlyList<string> availableTags;
            try
            {
                availableTags = downloader.GetAvailableReleaseTags();
            }
            catch (Exception ex)
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BicepDownloadFailed, ex.Message));
            }

            string selectedTag = null;
            BicepSemanticVersion selectedVersion = null;
            foreach (var tag in availableTags)
            {
                BicepSemanticVersion candidate;
                if (!TryParseReleaseTag(tag, out candidate) || !constraint.IsSatisfiedBy(candidate))
                {
                    continue;
                }

                if (selectedVersion == null || candidate.CompareTo(selectedVersion) > 0)
                {
                    selectedVersion = candidate;
                    selectedTag = tag;
                }
            }

            if (selectedVersion == null)
            {
                throw new AzPSApplicationException(string.Format(
                    Properties.Resources.BicepVersionNoMatchingReleaseFound,
                    constraint,
                    string.Join(", ", availableTags)));
            }

            var installationPath = GetVersionedInstallationPath(selectedVersion);
            DownloadAndInstall(selectedTag, installationPath);

            writeVerbose?.Invoke(string.Format(Properties.Resources.BicepAutoInstallComplete, selectedTag));

            return installationPath;
        }

        /// <summary>
        /// Installs a specific Bicep version (or the latest available version, if
        /// <paramref name="version"/> is null or empty) into the version-specific cache,
        /// backing the 'Install-AzBicep' cmdlet. If the requested version is already cached,
        /// this is a no-op .
        /// </summary>
        /// <returns>The installed (or already-cached) version.</returns>
        public BicepSemanticVersion InstallVersion(string version, BicepUtility.OutputCallback writeVerbose = null)
        {
            string releaseTag;
            BicepSemanticVersion targetVersion;

            if (string.IsNullOrEmpty(version))
            {
                try
                {
                    releaseTag = downloader.GetLatestReleaseTag();
                }
                catch (Exception ex)
                {
                    throw new AzPSApplicationException(string.Format(Properties.Resources.BicepDownloadFailed, ex.Message));
                }

                if (releaseTag == null || !TryParseReleaseTag(releaseTag, out targetVersion))
                {
                    throw new AzPSApplicationException(string.Format(Properties.Resources.BicepVersionNoMatchingReleaseFound, "latest", releaseTag));
                }
            }
            else
            {
                if (!BicepSemanticVersion.TryParse(version, out targetVersion))
                {
                    throw new AzPSApplicationException(string.Format(Properties.Resources.BicepVersionInvalidFormat, version));
                }

                IReadOnlyList<string> availableTags;
                try
                {
                    availableTags = downloader.GetAvailableReleaseTags();
                }
                catch (Exception ex)
                {
                    throw new AzPSApplicationException(string.Format(Properties.Resources.BicepDownloadFailed, ex.Message));
                }

                releaseTag = null;
                foreach (var tag in availableTags)
                {
                    BicepSemanticVersion candidate;
                    if (TryParseReleaseTag(tag, out candidate) && candidate.CompareTo(targetVersion) == 0)
                    {
                        releaseTag = tag;
                        break;
                    }
                }

                if (releaseTag == null)
                {
                    throw new AzPSApplicationException(string.Format(
                        Properties.Resources.BicepVersionNoMatchingReleaseFound,
                        targetVersion,
                        string.Join(", ", availableTags)));
                }
            }

            var installationPath = GetVersionedInstallationPath(targetVersion);
            if (dataStore.FileExists(installationPath))
            {
                writeVerbose?.Invoke(string.Format(Properties.Resources.BicepVersionAlreadyInstalled, targetVersion));
                return targetVersion;
            }

            writeVerbose?.Invoke(Properties.Resources.BicepAutoInstallStarting);
            DownloadAndInstall(releaseTag, installationPath);
            writeVerbose?.Invoke(string.Format(Properties.Resources.BicepAutoInstallComplete, releaseTag));

            return targetVersion;
        }

        /// <summary>
        /// Removes the entire managed Bicep installation directory (all cached versions),
        /// backing the 'Uninstall-AzBicep' cmdlet.
        /// </summary>
        /// <returns>True if anything was removed; false if there was no managed installation to remove.</returns>
        public bool UninstallAll(BicepUtility.OutputCallback writeVerbose = null)
        {
            var baseDirectory = GetInstallationDirectory();
            if (!dataStore.DirectoryExists(baseDirectory))
            {
                writeVerbose?.Invoke(Properties.Resources.BicepUninstallNothingInstalled);
                return false;
            }

            dataStore.DeleteDirectory(baseDirectory);
            writeVerbose?.Invoke(string.Format(Properties.Resources.BicepUninstallComplete, baseDirectory));
            return true;
        }

        /// <summary>
        /// Downloads the given release tag's asset for the current platform and writes it to
        /// <paramref name="installationPath"/>, creating the containing directory if needed and
        /// marking the file executable on non-Windows platforms.
        /// </summary>
        private void DownloadAndInstall(string releaseTag, string installationPath)
        {
            var installationDirectory = Path.GetDirectoryName(installationPath);
            if (!dataStore.DirectoryExists(installationDirectory))
            {
                dataStore.CreateDirectory(installationDirectory);
            }

            var targetPlatform = GetTargetPlatform();
            var extension = IsWindows() ? ".exe" : string.Empty;

            byte[] fileContents;
            try
            {
                var downloadUrl = string.Format(DownloadUrlTemplate, releaseTag, targetPlatform, extension);
                fileContents = downloader.DownloadFile(downloadUrl);
            }
            catch (Exception ex)
            {
                throw new AzPSApplicationException(string.Format(Properties.Resources.BicepDownloadFailed, ex.Message));
            }

            dataStore.WriteFile(installationPath, fileContents);

            if (!IsWindows())
            {
                processInvoker.Invoke(new ProcessInput { Executable = "chmod", Arguments = $"+x \"{installationPath}\"" });
            }
        }

        private static bool IsWindows()
            => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        /// <summary>
        /// Maps the current OS/architecture to a Bicep release asset platform suffix (e.g. "win-x64")
        /// </summary>
        private string GetTargetPlatform()
        {
            var isArm64 = RuntimeInformation.ProcessArchitecture == Architecture.Arm64;

            if (IsWindows())
            {
                return isArm64 ? "win-arm64" : "win-x64";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return isArm64 ? "osx-arm64" : "osx-x64";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (isArm64)
                {
                    return "linux-arm64";
                }

                return HasMuslLibraryOnly() ? "linux-musl-x64" : "linux-x64";
            }

            throw new AzPSApplicationException(Properties.Resources.BicepUnsupportedPlatform);
        }

        /// <summary>
        /// Detects Alpine/musl-based Linux (musl present, glibc absent).
        /// </summary>
        private bool HasMuslLibraryOnly()
            => dataStore.FileExists("/lib/ld-musl-x86_64.so.1") && !dataStore.FileExists("/lib/x86_64-linux-gnu/libc.so.6");
    }
}
