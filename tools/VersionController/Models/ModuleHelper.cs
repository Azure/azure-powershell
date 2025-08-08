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
            string findModuleScript;
                
            if (!string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("DEFAULT_PS_REPOSITORY_URL")))
            {
                string repository = System.Environment.GetEnvironmentVariable("DEFAULT_PS_REPOSITORY_NAME");
                findModuleScript = "$AccessTokenSecureString = $env:SYSTEM_ACCESS_TOKEN | ConvertTo-SecureString -AsPlainText -Force;$credentialsObject = [pscredential]::new('ONEBRANCH_TOKEN', $AccessTokenSecureString);";
                findModuleScript += releaseType == ReleaseType.STS 
                    ? $"Find-PSResource -Name {moduleName} -Repository {repository} -Version * -Credential $credentialsObject" 
                    : $"Find-PSResource -Name Az -Repository {repository} -Version * -Credential $credentialsObject";
            }
            else
            {
                string repository = "PSGallery";
                findModuleScript = releaseType == ReleaseType.STS ? $"Find-PSResource -Name {moduleName} -Repository {repository} -Version *" : $"Find-PSResource -Name Az -Repository {repository} -Version *";
            }
            string filterRequiredReleaseTypeScript = releaseType == ReleaseType.STS ? "" : "| Where-Object {([System.Version]($_.Version)).Major % 2 -eq 0}";
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
        internal static List<AzurePSVersion> GetAllVersionsFromGallery(string moduleName)
        {
            HashSet<AzurePSVersion> galleryVersion = new HashSet<AzurePSVersion>();
            using (PowerShell powershell = PowerShell.Create())
            {
                string findModuleScript;
                
                if (!string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("DEFAULT_PS_REPOSITORY_URL")))
                {
                    string repository = System.Environment.GetEnvironmentVariable("DEFAULT_PS_REPOSITORY_NAME");
                    findModuleScript = @"
$AccessTokenSecureString = $env:SYSTEM_ACCESS_TOKEN | ConvertTo-SecureString -AsPlainText -Force;
$credentialsObject = [pscredential]::new('ONEBRANCH_TOKEN', $AccessTokenSecureString);
Find-PSResource -Name " + moduleName + " -Repository " + repository + " -Credential $credentialsObject -Prerelease";
                }
                else
                {
                    string repository = "PSGallery";
                    findModuleScript = $"Find-PSResource -Name {moduleName} -Repository {repository} -Prerelease";
                }

                System.Console.WriteLine($"Find module script: {findModuleScript}");
                
                powershell.AddScript(findModuleScript);
                var cmdletResult = powershell.Invoke();
                System.Console.WriteLine($"Cmdlet result count: {cmdletResult.Count}");
                foreach (var versionInformation in cmdletResult)
                {
                    System.Console.WriteLine(versionInformation);
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
