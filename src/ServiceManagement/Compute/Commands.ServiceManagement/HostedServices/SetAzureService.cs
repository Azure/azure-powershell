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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.HostedServices
{
    /// <summary>
    /// Sets the label and description of the specified hosted service
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureService"), OutputType(typeof(ManagementOperationContext))]
    public class SetAzureServiceCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, HelpMessage = "A label for the hosted service. The label may be up to 100 characters in length.")]
        [ValidateLength(0, 100)]
        public string Label
        {
            get;
            set;
        }

        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true, HelpMessage = "A description for the hosted service. The description may be up to 1024 characters in length.")]
        [ValidateLength(0, 1024)]
        public string Description
        {
            get;
            set;
        }

        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true, HelpMessage = "Dns address to which the cloud service’s IP address resolves when queried using a reverse Dns query.")]
        public string ReverseDnsFqdn
        {
            get;
            set;
        }


        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (this.Label == null && this.Description == null && this.ReverseDnsFqdn == null)
            {
                ThrowTerminatingError(new ErrorRecord(
                                               new Exception(
                                               Resources.LabelOrDescriptionOrReverseDnsFqdnMustBeSpecified),
                                               string.Empty,
                                               ErrorCategory.InvalidData,
                                               null));
            }

            var parameters = new HostedServiceUpdateParameters
            {
                Label = this.Label ?? null,
                Description = this.Description,
                ReverseDnsFqdn = this.ReverseDnsFqdn
            };
            ExecuteClientActionNewSM(parameters, 
                CommandRuntime.ToString(),
                () => this.ComputeClient.HostedServices.Update(this.ServiceName, parameters));
            
        }
    }
}
