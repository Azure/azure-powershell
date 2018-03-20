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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ServiceFabricSettingsCmdletBase : ServiceFabricClusterCmdlet
    {
        private readonly List<PSSettingsSectionDescription> updatedSettingsSectionDescriptionList = new List<PSSettingsSectionDescription>();
        protected const string OneSetting = "OneSetting";
        protected const string BatchSettings = "BatchSettings";

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = OneSetting, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = BatchSettings, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = OneSetting, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = BatchSettings, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = OneSetting,
                   HelpMessage = "Section name of the fabric setting")]
        [ValidateNotNullOrEmpty()]
        public string Section { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = OneSetting,
                   HelpMessage = "Parameter name of the fabric setting")]
        [ValidateNotNullOrEmpty()]
        public string Parameter { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = OneSetting,
                   HelpMessage = "Parameter value of the fabric setting")]
        [ValidateNotNullOrEmpty()]
        public virtual string Value { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = BatchSettings,
                   HelpMessage = "An array of fabric settings")]
        [ValidateNotNullOrEmpty()]
        public PSSettingsSectionDescription[] SettingsSectionDescription { get; set; }

        protected List<PSSettingsSectionDescription> UpdatedSettingsSectionDescriptionList
        {
            get
            {
                if (updatedSettingsSectionDescriptionList.Any())
                {
                    return updatedSettingsSectionDescriptionList;
                }

                switch (ParameterSetName)
                {
                    case OneSetting:
                        {
                            updatedSettingsSectionDescriptionList.Add(new PSSettingsSectionDescription()
                            {
                                Name = this.Section,
                                Parameters = new List<PSSettingsParameterDescription>()
                                {
                                    new PSSettingsParameterDescription()
                                    {
                                        Name = this.Parameter,
                                        Value = this.Value
                                    }
                                }
                            });
                            break;
                        }
                    case BatchSettings:
                        {
                            if (this.SettingsSectionDescription != null)
                            {
                                updatedSettingsSectionDescriptionList.AddRange(this.SettingsSectionDescription);
                            }

                            break;
                        }
                }

                return this.updatedSettingsSectionDescriptionList;
            }
        }

        protected Dictionary<string, Dictionary<string, string>> FabricSettingsToDictionary(IList<SettingsSectionDescription> fabricSettings)
        {
            var settings = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

            if (fabricSettings != null)
            {
                foreach (var setting in fabricSettings)
                {
                    if (!settings.ContainsKey(setting.Name))
                    {
                        settings[setting.Name] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    }

                    foreach (var ps in setting.Parameters)
                    {
                        if (settings[setting.Name].ContainsKey(ps.Name))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(  
                                    ServiceFabricProperties.Resources.DuplicatedFabricSetting, 
                                    ps.Name));
                        }

                        settings[setting.Name][ps.Name] = ps.Value;
                    }
                }
            }

            return settings;
        }

        protected IList<SettingsSectionDescription> DictionaryToFabricSettings(Dictionary<string, Dictionary<string, string>> settings)
        {
            var fabricSettings = new List<SettingsSectionDescription>();

            if (settings != null)
            {
                foreach (var kvp1 in settings)
                {
                    var setting = new SettingsSectionDescription()
                    {
                        Name = kvp1.Key,
                        Parameters = new List<SettingsParameterDescription>()
                    };

                    foreach (var kvp2 in kvp1.Value)
                    {
                        setting.Parameters.Add(new SettingsParameterDescription()
                        {
                            Name = kvp2.Key,
                            Value = kvp2.Value
                        });
                    }

                    fabricSettings.Add(setting);
                }
            }

            return fabricSettings;
        }
    }
}