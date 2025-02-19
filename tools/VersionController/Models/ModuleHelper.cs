using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using Tools.Common.Models;

namespace VersionController.Netcore.Models
{
    internal class ModuleHelper
    {
        /// <summary>
        /// Get the version of latest Az.Accounts in LTS status from PSGallery
        /// </summary>
        /// <returns></returns>
        internal static string GetLatestVersionFromPSGallery(string moduleName, ReleaseType releaseType = ReleaseType.STS)
        {

            string version = null;
            string findModuleScript = releaseType == ReleaseType.STS ? $"Find-Module {moduleName} -Repository PSGallery -AllVersions" : "Find-Module Az -Repository PSGallery -AllVersions";
            string filterRequiredReleaseTypeScript = releaseType == ReleaseType.STS ? "" : "| Where-Object {([System.Version]($_.Version)).Major%2 -eq 0}";
            string sortModuleScript = "| Sort-Object {[System.Version]$_.Version} -Descending";
            string getLastModuleVersionScript = releaseType == ReleaseType.STS ? 
                $"({findModuleScript}{filterRequiredReleaseTypeScript}{sortModuleScript})[0].Version" :
                $"(({findModuleScript}{filterRequiredReleaseTypeScript}{sortModuleScript})[0].Dependencies | Where-Object {{$_.Name -eq '{moduleName}'}})[1]";
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript(getLastModuleVersionScript);
                var cmdletResult = powershell.Invoke();
                version = cmdletResult[0]?.ToString();
            }
            return version;
        }

        /// <summary>
        /// Get version from PSGallery and merge into one list.
        /// </summary>
        /// <returns>A list of version</returns>
        internal static List<AzurePSVersion> GetAllVersionsFromGallery(string moduleName, string psRepository)
        {
            HashSet<AzurePSVersion> galleryVersion = new HashSet<AzurePSVersion>();
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript($"Find-Module -Name {moduleName} -Repository {psRepository} -AllowPrerelease -AllVersions");
                var cmdletResult = powershell.Invoke();
                foreach (var versionInformation in cmdletResult)
                {
                    if (versionInformation.Properties["Version"]?.Value != null)
                    {
                        galleryVersion.Add(new AzurePSVersion(versionInformation.Properties["Version"]?.Value?.ToString()));
                    }
                }
            }
            return galleryVersion.ToList();
        }


        /// <summary>
        /// Under the same Major version, check if there exist preview version in gallery that has greater version.
        /// </summary>
        /// <returns>True if exist a version, false otherwise.</returns>
        internal static AzurePSVersion GetLatestVersionFromGalleryUnderSameMajorVersion(AzurePSVersion bumpedVersion, List<AzurePSVersion> galleryVersion, bool IsPreview)
        {
            var maxVersionInGallery = new AzurePSVersion(0, 0, 0);

            foreach (var version in galleryVersion)
            {
                if (version.Major == bumpedVersion.Major && (version.IsPreview == IsPreview) && version > maxVersionInGallery)
                {
                    maxVersionInGallery = version;
                }
            }
            return maxVersionInGallery;
        }
    }
}
