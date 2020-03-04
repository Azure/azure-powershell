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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.EdgeStorageAccounts
{
    [Cmdlet(VerbsCommon.New, Constants.EdgeStorageAccount,
         DefaultParameterSetName = EdgeStorageAccountParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(PSStackEdgeStorageAccount))]
    public class StackEdgeStorageAccountNewCmdlet : AzureStackEdgeCmdletBase
    {
        private const string EdgeStorageAccountParameterSet = "EdgeStorageAccountParameterSet";

        [Parameter(Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageEdgeStorageAccount.EdgeStorageAccountAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = EdgeStorageAccountParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageEdgeStorageAccount.StorageAccountCredentialHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountCredentialName { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageEdgeStorageAccount.CloudDataPolicyHelpMessage)]
        public SwitchParameter Cloud;

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }


        private StorageAccount GetResource()
        {
            return this.StackEdgeManagementClient.StorageAccounts.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private string GetResourceAlreadyExistMessage()
        {
            return string.Format("'{0}'{1}{2}'.",
                HelpMessageEdgeStorageAccount.ObjectName, Constants.ResourceAlreadyExists, this.Name);
        }

        private bool DoesResourceExists()
        {
            try
            {
                if (GetResource() == null) return false;
                throw new Exception(GetResourceAlreadyExistMessage());
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        private PSStackEdgeStorageAccount CreateResource()
        {
            var storageAccountCredential = this.StackEdgeManagementClient.StorageAccountCredentials.Get(
                this.DeviceName,
                this.StorageAccountCredentialName,
                this.ResourceGroupName);

            var edgeStorageAccount = new StorageAccount(
                name: Name,
                dataPolicy: "Cloud",
                storageAccountStatus: "OK",
                description: "",
                storageAccountCredentialId: storageAccountCredential.Id);
            edgeStorageAccount = this.StackEdgeManagementClient.StorageAccounts.CreateOrUpdate(
                DeviceName,
                Name,
                edgeStorageAccount,
                this.ResourceGroupName
            );
            return new PSStackEdgeStorageAccount(edgeStorageAccount
            );
        }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name,
                string.Format("Creating '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageEdgeStorageAccount.ObjectName, this.DeviceName, this.Name)))
            {
                DoesResourceExists();
                var results = new List<PSStackEdgeStorageAccount>()
                {
                    CreateResource()
                };

                WriteObject(results, true);
            }
        }
    }
}