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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Management.Compute.Models;
using ConfigurationSet = Microsoft.WindowsAzure.Commands.ServiceManagement.Model.ConfigurationSet;
using DataVirtualHardDisk = Microsoft.WindowsAzure.Commands.ServiceManagement.Model.DataVirtualHardDisk;
using OSVirtualHardDisk = Microsoft.WindowsAzure.Commands.ServiceManagement.Model.OSVirtualHardDisk;
using RoleInstance = Microsoft.WindowsAzure.Management.Compute.Models.RoleInstance;
using CSM = Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using MCM = Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers
{
    public static class PersistentVMHelper
    {
        public static void SaveStateToFile(PersistentVM role, string filePath)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role", Resources.MissingPersistentVMRole);
            }
            
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            XmlAttributes ignoreAttrib = new XmlAttributes();
            ignoreAttrib.XmlIgnore = true;
            overrides.Add(typeof(DataVirtualHardDisk), "MediaLink", ignoreAttrib);
            overrides.Add(typeof(DataVirtualHardDisk), "SourceMediaLink", ignoreAttrib);
            overrides.Add(typeof(OSVirtualHardDisk), "MediaLink", ignoreAttrib);
            overrides.Add(typeof(CSM.DebugSettings), "ConsoleScreenshotBlobUri", ignoreAttrib);
            overrides.Add(typeof(CSM.DebugSettings), "SerialOutputBlobUri", ignoreAttrib);

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(PersistentVM), overrides, new Type[] { typeof(NetworkConfigurationSet) }, null, null);
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, role);
            }
        }

        public static PersistentVM LoadStateFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException(Resources.MissingPersistentVMFile, "filePath");
            }

            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            XmlAttributes ignoreAttrib = new XmlAttributes();
            ignoreAttrib.XmlIgnore = true;
            overrides.Add(typeof(DataVirtualHardDisk), "MediaLink", ignoreAttrib);
            overrides.Add(typeof(DataVirtualHardDisk), "SourceMediaLink", ignoreAttrib);
            overrides.Add(typeof(OSVirtualHardDisk), "MediaLink", ignoreAttrib);
            overrides.Add(typeof(OSVirtualHardDisk), "SourceImageName", ignoreAttrib);
            overrides.Add(typeof(CSM.DebugSettings), "ConsoleScreenshotBlobUri", ignoreAttrib);
            overrides.Add(typeof(CSM.DebugSettings), "SerialOutputBlobUri", ignoreAttrib);

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(PersistentVM), overrides, new Type[] { typeof(NetworkConfigurationSet) }, null, null);

            PersistentVM role = null;
            
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                role = serializer.Deserialize(stream) as PersistentVM;
            }

            return role;
        }

        // Returns a RoleNamesCollection based on instances in the roleInstanceList
        // whose RoleInstance.RoleName matches the roleName passed in.  Wildcards
        // are handled for the roleName passed in.
        // This function also verifies that the RoleInstance exists before adding the
        // RoleName to the RoleNamesCollection.
        public static RoleNamesCollection GetRoleNames(IList<RoleInstance> roleInstanceList, string roleName)
        {
            var roleNamesCollection = new RoleNamesCollection();
            if (!string.IsNullOrEmpty(roleName))
            {
                if (WildcardPattern.ContainsWildcardCharacters(roleName))
                {
                    WildcardOptions wildcardOptions = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
                    WildcardPattern wildcardPattern = new WildcardPattern(roleName, wildcardOptions);

                    foreach (var role in roleInstanceList)
                        if (!string.IsNullOrEmpty(role.RoleName) && wildcardPattern.IsMatch(role.RoleName))
                        {
                            roleNamesCollection.Add(role.RoleName);
                        }
                }
                else
                {
                    var roleInstance = roleInstanceList.Where(r => r.RoleName != null).
                        FirstOrDefault(r => r.RoleName.Equals(roleName, StringComparison.InvariantCultureIgnoreCase));
                    if (roleInstance != null)
                    {
                        roleNamesCollection.Add(roleName);
                    }
                }
            }
            return roleNamesCollection;
        }

        // Return the list of role names that match any of the given query.
        public static RoleNamesCollection GetRoleNames(IList<RoleInstance> roleInstanceList, string[] roleNameQueries)
        {
            List<string> distinctRoleNameList = new List<string>();

            foreach (var roleNameQuery in roleNameQueries)
            {
                var unionResult = distinctRoleNameList.Union(GetRoleNames(roleInstanceList, roleNameQuery));
                distinctRoleNameList = unionResult.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            }

            var roleNamesCollection = new RoleNamesCollection();

            foreach (var roleName in distinctRoleNameList)
            {
                roleNamesCollection.Add(roleName);
            }

            return roleNamesCollection;
        }

        public static Collection<ConfigurationSet> MapConfigurationSets(IList<Management.Compute.Models.ConfigurationSet> configurationSets)
        {
            var result = new Collection<ConfigurationSet>();
            var n = configurationSets.Where(c => c.ConfigurationSetType == "NetworkConfiguration").Select(Mapper.Map<Model.NetworkConfigurationSet>).ToList();
            var w = configurationSets.Where(c => c.ConfigurationSetType == ConfigurationSetTypes.WindowsProvisioningConfiguration).Select(Mapper.Map<WindowsProvisioningConfigurationSet>).ToList();
            var l = configurationSets.Where(c => c.ConfigurationSetType == ConfigurationSetTypes.LinuxProvisioningConfiguration).Select(Mapper.Map<LinuxProvisioningConfigurationSet>).ToList();
            n.ForEach(result.Add);
            w.ForEach(result.Add);
            l.ForEach(result.Add);
            return result;
        }

        public static  IList<MCM.ConfigurationSet> MapConfigurationSets(Collection<ConfigurationSet> configurationSets)
        {
            var result = new Collection<Management.Compute.Models.ConfigurationSet>();
            foreach (var networkConfig in configurationSets.OfType<NetworkConfigurationSet>())
            {
                result.Add(Mapper.Map<Management.Compute.Models.ConfigurationSet>(networkConfig));
            }

            foreach (var windowsConfig in configurationSets.OfType<WindowsProvisioningConfigurationSet>())
            {
                var newWinCfg = Mapper.Map<Management.Compute.Models.ConfigurationSet>(windowsConfig);
                if (windowsConfig.WinRM != null)
                {
                    newWinCfg.WindowsRemoteManagement = new WindowsRemoteManagementSettings();

                    // AutoMapper doesn't work for WinRM.Listeners -> WindowsRemoteManagement.Listeners
                    if (windowsConfig.WinRM.Listeners != null)
                    {
                        foreach (var s in windowsConfig.WinRM.Listeners)
                        {
                            newWinCfg.WindowsRemoteManagement.Listeners.Add(new WindowsRemoteManagementListener
                            {
                                ListenerType = (VirtualMachineWindowsRemoteManagementListenerType)Enum.Parse(typeof(VirtualMachineWindowsRemoteManagementListenerType), s.Protocol, true),
                                CertificateThumbprint = s.CertificateThumbprint
                            });
                        }
                    }
                }

                result.Add(newWinCfg);
            }

            foreach (var linuxConfig in configurationSets.OfType<LinuxProvisioningConfigurationSet>())
            {
                result.Add(Mapper.Map<Management.Compute.Models.ConfigurationSet>(linuxConfig));
            }

            return result;
        }

        public static string GetPublicIPName(Microsoft.WindowsAzure.Management.Compute.Models.Role vmRole)
        {
            string name = null;

            if (vmRole != null && vmRole.ConfigurationSets != null && vmRole.ConfigurationSets.Any())
            {
                var networkCfg = vmRole.ConfigurationSets
                                       .Where(c => string.Equals(c.ConfigurationSetType, ConfigurationSetTypes.NetworkConfiguration, StringComparison.OrdinalIgnoreCase))
                                       .SingleOrDefault();

                if (networkCfg != null)
                {
                    var publicIp = networkCfg.PublicIPs.FirstOrDefault();
                    name = publicIp == null ? null : publicIp.Name;
                }
            }

            return name;
        }

        public static MCM.VMImageInput MapVMImageInput(CSM.VMImageInput vmImageInput)
        {
            var result = new MCM.VMImageInput();

            if (vmImageInput == null)
            {
                return null;
            }

            if (vmImageInput.OSDiskConfiguration != null)
            {
                result.OSDiskConfiguration = new MCM.OSDiskConfiguration()
                    {
                        ResizedSizeInGB = vmImageInput.OSDiskConfiguration.ResizedSizeInGB
                    };
            }

            if (vmImageInput.DataDiskConfigurations != null)
            {
                result.DataDiskConfigurations = new Collection<MCM.DataDiskConfiguration>();
                foreach (var dataDiskConfig in vmImageInput.DataDiskConfigurations)
                {
                    result.DataDiskConfigurations.Add(
                        new MCM.DataDiskConfiguration()
                        {
                            DiskName = dataDiskConfig.Name,
                            ResizedSizeInGB = dataDiskConfig.ResizedSizeInGB
                        });
                }
            }
            return result;
        }

        public static string ConvertCustomDataFileToBase64(string fileName)
        {
            byte[] bytes = new byte[3 * 4096]; // Make buffer be a factor of 3 for encoding correctly
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.FileStream fileStream = null;
 
            try
            {
                fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
 
                while (fileStream.Position < fileStream.Length)
                {
                    int cb = fileStream.Read(bytes, 0, bytes.Length);
                    sb.Append(System.Convert.ToBase64String(bytes, 0, cb));
                }
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            
            return (sb.ToString());
        }
    }
}
