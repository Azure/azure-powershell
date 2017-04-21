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
using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ServiceFabricSettingsCmdletBase : ServiceFabricClusterCmdlet
    {
        private List<PSSettingsSectionDescription> changedSettingsSectionDescriptions =
            new List<PSSettingsSectionDescription>();
        protected const string OneCertSet = "OneSetting";
        protected const string GroupCertSet = "BatchSettings";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = OneCertSet,
                   HelpMessage = "Section")]
        [ValidateNotNullOrEmpty()]
        public string Section { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = OneCertSet,
                   HelpMessage = "Parameter")]
        [ValidateNotNullOrEmpty()]
        public string Parameter { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = OneCertSet,
                   HelpMessage = "Value")]
        [ValidateNotNullOrEmpty()]
        public virtual string Value { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GroupCertSet,
                   HelpMessage = "Client authentication type")]
        [ValidateNotNullOrEmpty()]
        public PSSettingsSectionDescription[] SettingsSectionDescriptions { get; set; }

        protected List<PSSettingsSectionDescription> ChangedSettingsSectionDescriptions
        {
            get
            {
                switch (ParameterSetName)
                {
                    case OneCertSet:
                        {
                            changedSettingsSectionDescriptions.Add(new PSSettingsSectionDescription()
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
                    case GroupCertSet:
                        {
                            if (this.SettingsSectionDescriptions != null)
                            {
                                changedSettingsSectionDescriptions.AddRange(this.SettingsSectionDescriptions);
                            }

                            break;
                        }
                    default:
                        break;
                }

                return this.changedSettingsSectionDescriptions;
            }
        }

        protected Dictionary<string, Dictionary<string, string>> FabricSettingsToDictionary(
            IList<SettingsSectionDescription> fabricSettings)
        {
            Dictionary<string, Dictionary<string, string>> settings =
                new Dictionary<string, Dictionary<string, string>>(StringComparer.InvariantCultureIgnoreCase);

            if (fabricSettings != null)
            {
                foreach (var setting in fabricSettings)
                {
                    settings[setting.Name] = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
                    foreach (var ps in setting.Parameters)
                    {
                        settings[setting.Name][ps.Name] = ps.Value;
                    }
                }
            }

            return settings;
        }

        protected IList<SettingsSectionDescription> DictionaryToFabricSettings(
            Dictionary<string, Dictionary<string, string>> settings)
        {
            List<SettingsSectionDescription> fabricSettings =
                new List<SettingsSectionDescription>();

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