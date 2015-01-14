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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.AffinityGroups
{
    /// <summary>
    /// Creates and returns a new affinity group in the specified data center location.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureAffinityGroup"), OutputType(typeof(ManagementOperationContext))]
    public class NewAzureAffinityGroup : ServiceManagementBaseCmdlet
    {
        /// <summary>
        /// A name for the affinity group that is unique to the subscription. (Required)
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the affinity group.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// A label for the affinity group. The label may be up to 100 characters in length. (Required)
        /// </summary>
        [Parameter(HelpMessage = "Label of the affinity group.")]
        [ValidateNotNullOrEmpty]
        [ValidateLength(1, 100)]
        public string Label
        {
            get;
            set;
        }

        /// <summary>
        /// A description for the affinity group. The description may be up to 1024 characters in length. (Optional)
        /// </summary>
        [Parameter(HelpMessage = "Description of the affinity group.")]
        [ValidateLength(0, 1024)]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Required. The location where the affinity group will be created. To list available locations, use the List Locations operation.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Location of the affinity group.")]
        [ValidateNotNullOrEmpty]
        public string Location
        {
            get;
            set;
        }

        public void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();
            
            if (string.IsNullOrEmpty(Label))
            {
                Label = Name;
            }

            var input = new AffinityGroupCreateParameters
                        {
                            Description = this.Description,
                            Label = this.Label,
                            Location = this.Location,
                            Name = this.Name
                        };

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ManagementClient.AffinityGroups.Create(input));
        }

        protected override void OnProcessRecord()
        {
            this.ExecuteCommand();
        }
    }
}
