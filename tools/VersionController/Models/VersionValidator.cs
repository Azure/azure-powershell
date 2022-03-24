using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text.RegularExpressions;

namespace VersionController.Models
{
    public class VersionValidator
    {
        private VersionFileHelper _fileHelper;
        private VersionMetadataHelper _metadataHelper;

        private string _localVersion, _galleryVersion;
        private bool _isPreview, _isNewModule;

        public VersionValidator(VersionFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
            _metadataHelper = new VersionMetadataHelper(_fileHelper);
        }

        /// <summary>
        /// Validate all necessary version bumps for a module.
        /// </summary>
        public void ValidateAllVersionBumps()
        {
            var moduleName = _fileHelper.ModuleName;
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            try
            {
                Console.WriteLine("Validating version bump for " + moduleName + "...");
                CreateTempModuleManifest();
                _localVersion = GetLocalVersion();
                if (ValidateLocalVersionUpdate())
                {
                    ValidateVersionBump();
                    ValidateChangeLog();
                    var releaseNotes = GetReleaseNotes();
                    ValidateOutputModuleManifest(releaseNotes);
                    ValidateRollupModuleManifest();
                    ValidateAssemblyInfo();
                    ValidateSerialization();
                    Console.WriteLine("Successfully validated version bump for " + moduleName + "\n");
                }
                else
                {
                    Console.WriteLine("The version of " + moduleName + " has not been updated.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when validating version bump for " + moduleName + ":\n" + ex.Message + "\n");
            }
            finally
            {
                DeleteTempModuleManifest();
                DeleteGalleryModule();
            }
        }

        private void CreateTempModuleManifest()
        {
            var moduleName = _fileHelper.ModuleName;
            var projectModuleManifestPath = _fileHelper.ProjectModuleManifestPath;
            var outputModuleManifestPath = _fileHelper.OutputModuleManifestPath;
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            var tempModuleManifestPath = Path.Combine(outputModuleDirectory, moduleName + "-temp.psd1");
            File.Copy(outputModuleManifestPath, tempModuleManifestPath);
            var projectModuleManifestContents = File.ReadAllLines(projectModuleManifestPath);
            File.WriteAllLines(outputModuleManifestPath, projectModuleManifestContents);
        }

        private void DeleteTempModuleManifest()
        {
            var moduleName = _fileHelper.ModuleName;
            var outputModuleManifestPath = _fileHelper.OutputModuleManifestPath;
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            var tempModuleManifestPath = Path.Combine(outputModuleDirectory, moduleName + "-temp.psd1");
            var tempModuleManifestContents = File.ReadAllLines(tempModuleManifestPath);
            File.WriteAllLines(outputModuleManifestPath, tempModuleManifestContents);
            File.Delete(tempModuleManifestPath);
        }

        /// <summary>
        /// Assigns the version of the local (in the output directory) module manifest.
        /// </summary>
        /// <returns>Version of the local module manifest.</returns>
        private string GetLocalVersion()
        {
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            var moduleFileName = _fileHelper.ModuleFileName;

            string localVersion = string.Empty;
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory " + outputModuleDirectory + " -FileName " + moduleFileName);
                powershell.AddScript("$ModuleMetadata.ModuleVersion;$ModuleMetadata.PrivateData.PSData.Prerelease");
                var cmdletResult = powershell.Invoke();
                localVersion = cmdletResult[0]?.ToString();
                _isPreview = !string.IsNullOrEmpty(cmdletResult[1]?.ToString());
            }

            if (localVersion == null)
            {
                throw new Exception("Unable to obtain the version from the locally built module manifest file.");
            }

            return localVersion;
        }

        /// <summary>
        /// Validate that the local version is greater than the version on the gallery.
        /// This will let us know if we should continue with validation of the module.
        /// </summary>
        /// <returns>True if the local version is greater than the gallery version, false otherwise.</returns>
        private bool ValidateLocalVersionUpdate()
        {
            var moduleName = _fileHelper.ModuleName;
            var url = @"https://www.powershellgallery.com/packages/" + moduleName;
            if (!DoesUrlExists(url))
            {
                Console.WriteLine("Validated that " + moduleName + " is a new module.");
                _galleryVersion = _localVersion;
                _isNewModule = true;
                return true;
            }

            url += @"/" + _localVersion;
            if (!DoesUrlExists(url))
            {
                SaveGalleryModule();
                _galleryVersion = Path.GetFileName(_fileHelper.GalleryModuleVersionDirectory);
                Console.WriteLine("Validated version is being updated from " + _galleryVersion + " to " + _localVersion + ".");
                return true;
            }

            return false;
        }

        private bool DoesUrlExists(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Head;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                if (response == null || response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw ex;
                }
            }

            return false;
        }

        /// <summary>
        /// Validate that the correct version bump was applied from the
        /// previous (gallery) module version to the module version found locally.
        /// </summary>
        private void ValidateVersionBump()
        {
            var moduleName = _fileHelper.ModuleName;

            // Don't validate a version bump for new module
            if (_isNewModule)
            {
                Console.WriteLine("Skipping version bump validation for " + moduleName + " since it is a new module.");
                return;
            }

            Version version = _metadataHelper.GetVersionBumpUsingGallery();
            if (string.Equals(moduleName, "Az.Accounts"))
            {
                var commonCodeVersion = _metadataHelper.GetVersionBumpForCommonCode();
                if (commonCodeVersion == Version.MAJOR)
                {
                    version = Version.MAJOR;
                }
                else if (commonCodeVersion == Version.MINOR && version == Version.PATCH)
                {
                    version = Version.MINOR;
                }
            }

            var splitVersion = _galleryVersion.Split('.').Select(v => int.Parse(v)).ToArray();

            // PATCH update for preview modules (0.x.x or x.x.x-preview)
            if (splitVersion[0] == 0 || _isPreview)
            {
                version = Version.PATCH;
            }

            if (version == Version.MAJOR)
            {
                splitVersion[0]++;
                splitVersion[1] = 0;
                splitVersion[2] = 0;
            }
            else if (version == Version.MINOR)
            {
                splitVersion[1]++;
                splitVersion[2] = 0;
            }
            else
            {
                splitVersion[2]++;
            }

            var tempVersion = string.Join(".", splitVersion);
            if (!string.Equals(_localVersion, tempVersion))
            {
                throw new Exception("Incorrect version bump. The local version is " + _localVersion + ", but should have been " + tempVersion);
            }

            Console.WriteLine("Validated correct version bump to version " + _localVersion);
        }

        /// <summary>
        /// Validate that the change log has an entry for the new version.
        /// </summary>
        private void ValidateChangeLog()
        {
            var changeLogPath = _fileHelper.ChangeLogPath;
            var file = File.ReadAllLines(changeLogPath);
            var idx = 0;
            while (idx < file.Length && !file[idx].Equals("## Version " + _localVersion))
            {
                idx++;
            }

            if (idx == file.Length)
            {
                throw new Exception("Unable to find entry in the change log for version " + _localVersion);
            }

            Console.WriteLine("Validated new entry in change log.");
        }

        /// <summary>
        /// Get the releases notes for the upcoming release from a change log.
        /// </summary>
        /// <returns></returns>
        private string GetReleaseNotes()
        {
            var changeLogPath = _fileHelper.ChangeLogPath;
            var file = File.ReadAllLines(changeLogPath);
            var idx = 0;
            while (idx < file.Length && !file[idx].Equals("## Version " + _localVersion))
            {
                idx++;
            }

            var releaseNotes = new List<string>();
            while (++idx < file.Length && !file[idx].Contains("## Version"))
            {
                releaseNotes.Add(file[idx]);
            }

            return string.Join("\r\n", releaseNotes.Where(l => !string.IsNullOrWhiteSpace(l)).ToList());
        }

        /// <summary>
        /// Validate that the output module manifest file was updated with the correct
        /// version and the correct release notes from the change log.
        /// </summary>
        /// <param name="releaseNotes"></param>
        private void ValidateOutputModuleManifest(string releaseNotes)
        {
            var outputModuleManifestPath = _fileHelper.OutputModuleManifestPath;
            var moduleName = _fileHelper.ModuleName;
            string manifestVersion = string.Empty;
            string manifestReleaseNotes = string.Empty;
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process;");
                powershell.AddScript("$manifest = Test-ModuleManifest -Path " + outputModuleManifestPath + ";$manifest.Version;$manifest.ReleaseNotes");
                var cmdletResult = powershell.Invoke();
                manifestVersion = cmdletResult[0].ToString();
                manifestReleaseNotes = cmdletResult[1].ToString();
            }

            if (_localVersion != manifestVersion)
            {
                throw new Exception("The local version " + _localVersion + " of " + moduleName + " is not the same as the module manifest version " + manifestVersion);
            }

            if (releaseNotes != manifestReleaseNotes)
            {
                throw new Exception("The release notes for " + moduleName + " have not been updated in the module manifest file");
            }

            Console.WriteLine("Validated version change and updated release notes in " + moduleName + ".");
        }

        /// <summary>
        /// Validate that the current module version was updated in Az.psd1.
        /// </summary>
        private void ValidateRollupModuleManifest()
        {
            var rollupModuleManifestPath = _fileHelper.RollupModuleManifestPath;
            var moduleName = _fileHelper.ModuleName;
            if (_isPreview)
            {
                Console.WriteLine("Skipping Az bump validation since " + moduleName + " is a preview module.");
                return;
            }

            var file = File.ReadAllLines(rollupModuleManifestPath);
            var pattern = @"ModuleName(\s*)=(\s*)(['\""])" + moduleName + @"(['\""])(\s*);(\s*)RequiredVersion(\s*)=(\s*)(['\""])" + _localVersion + @"(['\""])";
            if (!file.Where(l => Regex.IsMatch(l, pattern)).Any())
            {
                throw new Exception("The Az.psd1 module manifest file has not updated required module " + moduleName + " to version " + _localVersion);
            }

            Console.WriteLine("Validated change in RequiredModules for Az.psd1.");
        }

        /// <summary>
        /// Validate that all AssemblyInfo.cs files were updated properly.
        /// </summary>
        private void ValidateAssemblyInfo()
        {
            var assemblyInfoPaths = _fileHelper.AssemblyInfoPaths;
            foreach (var assemblyInfoPath in assemblyInfoPaths)
            {
                var file = File.ReadAllLines(assemblyInfoPath);
                var pattern = @"AssemblyVersion\(([\""])" + _localVersion + @"([\""])\)";
                if (!file.Where(l => Regex.IsMatch(l, pattern)).Any())
                {
                    throw new Exception("The AssemblyVersion has not been updated to version " + _localVersion + " for " + assemblyInfoPath);
                }

                pattern = @"AssemblyFileVersion\(([\""])" + _localVersion + @"([\""])\)";
                if (!file.Where(l => Regex.IsMatch(l, pattern)).Any())
                {
                    throw new Exception("The AssemblyFileVersion has not been updated to version " + _localVersion + " for " + assemblyInfoPath);
                }
            }

            Console.WriteLine("Validated version change in AssemblyInfo.cs files.");
        }

        /// <summary>
        /// Validate that the serialized module metadata was updated.
        /// </summary>
        private void ValidateSerialization()
        {
            Version version = _metadataHelper.GetVersionBumpUsingSerialized();
            if (version != Version.PATCH)
            {
                throw new Exception("The JSON containing the serialized module metadata has not been re-serialized.");
            }

            var outputModuleManifestPath = _fileHelper.OutputModuleManifestPath;
            var serializedCmdletsDirectory = _fileHelper.SerializedCmdletsDirectory;
            IList<string> nestedModules = null;
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process;");
                powershell.AddScript("(Test-ModuleManifest -Path " + outputModuleManifestPath + ").NestedModules");
                var cmdletResult = powershell.Invoke();
                nestedModules = cmdletResult.Select(c => c.ToString()).ToList();
            }

            foreach (var nestedModule in nestedModules)
            {
                var serializedCmdletName = nestedModule + ".dll.json";
                var serializedCmdletFile = Directory.GetFiles(serializedCmdletsDirectory, serializedCmdletName).FirstOrDefault();
                var file = File.ReadAllLines(serializedCmdletFile);
                var pattern = nestedModule + @"(\s*),(\s*)Version(\s*)=(\s*)" + _localVersion;
                if (!file.Where(l => Regex.IsMatch(l, pattern)).Any())
                {
                    throw new Exception("The assembly version has not been updated in the serialized module metadata JSON file.");
                }
            }

            Console.WriteLine("Validated serialization of module metadata.");
        }

        /// <summary>
        /// Download the module (and its dependencies) from the PowerShell Gallery and
        /// place them in the output module folder.
        /// </summary>
        private void SaveGalleryModule()
        {
            var moduleName = _fileHelper.ModuleName;
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            Console.WriteLine("Saving " + moduleName + " from the PowerShell Gallery. This will take a few seconds.");
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddScript("Save-Module -Name " + moduleName + " -Repository PSGallery -Path " + outputModuleDirectory);
                var cmdletResult = powershell.Invoke();
            }
        }

        /// <summary>
        /// Remove the module folders previously downloaded from the PowerShell Gallery.
        /// </summary>
        private void DeleteGalleryModule()
        {
            var outputModuleDirectory = _fileHelper.OutputModuleDirectory;
            var directories = Directory.GetDirectories(outputModuleDirectory, "Az*.*", SearchOption.TopDirectoryOnly);
            foreach (var directory in directories)
            {
                try
                {
                    Directory.Delete(directory, true);
                }
                catch (Exception ex)
                {
                    var blank = ex.Message;
                }
            }
        }
    }
}
