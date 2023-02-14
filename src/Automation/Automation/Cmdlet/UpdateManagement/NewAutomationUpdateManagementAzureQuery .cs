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

namespace Microsoft.Azure.Commands.Automation.Cmdlet.UpdateManagement
{
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using Microsoft.Azure.Commands.Automation.Common;
    using Models = Microsoft.Azure.Commands.Automation.Model;
    using Microsoft.Azure.Commands.Automation.Model.UpdateManagement;
    using System.Linq;
    using Properties;
    using System.Collections;
    using TagHelper = Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzurePrefix + "AutomationUpdateManagementAzureQuery")]
    [OutputType(typeof(AzureQueryProperties))]
    public class NewAutomationUpdateManagementAzureQuery : AzureAutomationBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Resource Ids for azure virtual machines.")]
        [ValidateNotNull]
        public string[] Scope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of locations for azure virtual machines.")]
        [LocationCompleter("Microsoft.Compute/virtualMachines")]
        [Alias("Locaton")]
        public string[] Location { get; set; }

        [Parameter(Mandatory = false,  HelpMessage = "Tag for azure virtual machines.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Tag filter operator.")]
        public TagOperators FilterOperator { get; set; }


        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            var azureQuery = new AzureQueryProperties
            {
                Scope = this.Scope,
                Locations = this.Location,
                TagSettings = this.Tag == null ? null : new TagSettings
                {
                    Tags = CreateTagDictionary(this.Tag),
                    FilterOperator = this.FilterOperator
                }
            };

            this.WriteObject(azureQuery);
        }

        private Dictionary<string, List<string>> CreateTagDictionary(Hashtable tags)
        {
            Dictionary<string, List<string>> tagDictionary = null;
            if (tags != null)
            {
                tagDictionary = new Dictionary<string, List<string>>();

                foreach (var key in tags.Keys)
                {
                    if (tags[key] != null && tags[key].GetType() == typeof(string))
                    {
                        tagDictionary.Add(key.ToString(), new List<string> { tags[key].ToString() });
                    }
                    else if (tags[key] != null && tags[key].GetType() == typeof(System.Object[]))
                    {
                        var stringList = new List<string>();
                        foreach(var value in tags[key] as Array)
                        {
                            stringList.Add(value.ToString());
                        }

                        tagDictionary.Add(key.ToString(), stringList);
                    }
                    else
                    {
                        throw new PSArgumentException(Resources.SoftwareUpdateConfigurationInvalidTagFormat);
                    }
                }
            }
            return tagDictionary;
        }
    }
}
