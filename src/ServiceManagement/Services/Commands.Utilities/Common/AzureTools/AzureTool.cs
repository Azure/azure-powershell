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
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using Microsoft.WindowsAzure.Commands.Common.Properties;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools
{
    public class AzureTool
    {
        public static void Validate()
        {
            // This instantiation will throw if user is running with incompatible Microsoft Azure SDK version.
            GetAzureSdkBinDirectory();
            GetComputeEmulatorDirectory();
        }

        public static bool IgnoreMissingSDKError { get; set; }

        public static string GetAzureSdkVersion()
        {
            string versionKeyValue = GetSdkVersionRegistryValue();

            Debug.Assert(versionKeyValue.StartsWith("v", StringComparison.OrdinalIgnoreCase), "Unexpected SDK version registry value");
            string version = versionKeyValue.Remove(0, 1);

            // Add build version if it does not exist. For example, if the version is 1.7
            // this code changes it to be 1.7.0
            if (version.Split('.').Length == 2)
            {
                version = version + ".0";
            }
            return version;
        }

        public static string GetAzureSdkBinDirectory()
        {
            string versionKeyValue = GetSdkVersionRegistryValue();
            string keyName = Path.Combine(Resources.AzureSdkRegistryKeyName, versionKeyValue);
            string sdkDirectory = (string)Registry.GetValue(Path.Combine(Registry.LocalMachine.Name, keyName), Resources.AzureSdkInstallPathRegistryKeyValue, null);
            return Path.Combine(sdkDirectory, Resources.RoleBinFolderName);
        }

        public static string GetComputeEmulatorDirectory()
        {
            var emulatorPath = Registry.GetValue(Path.Combine(Registry.LocalMachine.Name, Resources.AzureEmulatorRegistryKey), Resources.AzureSdkInstallPathRegistryKeyValue, null);
            if (emulatorPath == null)
            {
                throw new Exception(Resources.AzureEmulatorNotInstalledMessage);
            }
            return Path.Combine((string)emulatorPath, Resources.AzureEmulatorDirectory);
        }      
        
        public static string GetStorageEmulatorDirectory()
        {
            string installDirectory = string.Empty;
            using (RegistryKey storageEmulatorKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                .OpenSubKey(Resources.StorageEmulatorRegistryKey))
            {
                if (storageEmulatorKey != null)
                {
                    installDirectory = (string)storageEmulatorKey.GetValue(Resources.StorageEmulatorInstallPathRegistryKeyValue, string.Empty);
                }
            }
            return installDirectory;
        }

        private static string GetSdkVersionRegistryValue()
        {
            string version = string.Empty; 
            string min = Resources.MinSupportAzureSdkVersion;
            string max = Resources.MaxSupportAzureSdkVersion;
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(Resources.AzureSdkRegistryKeyName))
                {
                    if (key == null)
                    {
                        throw new InvalidOperationException(Resources.AzureToolsNotInstalledMessage);
                    }
                    version = key.GetSubKeyNames()
                        .Where(n => (n.CompareTo(min) == 1 && n.CompareTo(max) == -1) || n.CompareTo(min) == 0 || n.CompareTo(max) == 0)
                        .Max<string>();

                    if (string.IsNullOrEmpty(version) && key.GetSubKeyNames().Length > 0)
                    {
                        throw new InvalidOperationException(string.Format(Resources.AzureSdkVersionNotSupported, min, max));
                    }
                    else if (string.IsNullOrEmpty(version) && key.GetSubKeyNames().Length == 0)
                    {
                        throw new InvalidOperationException(Resources.AzureToolsNotInstalledMessage);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                //temporary workaround: catch exception and fall back to v2.4
                if (IgnoreMissingSDKError)
                {
                    version = "v2.4";
                }
                else
                {
                    throw;
                }
            }
            return version;
        }
    }
}