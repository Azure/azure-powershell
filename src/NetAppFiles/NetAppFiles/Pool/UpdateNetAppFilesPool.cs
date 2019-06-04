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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Pool
{
    [Cmdlet(
        "Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesPool",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesPool))]
    [Alias("Update-AnfPool")]
    public class UpdateAzureRmNetAppFilesPool : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/netAppAccounts/capacityPools")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts",
            nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF pool")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParentObjectParameterSet,
            HelpMessage = "The name of the ANF pool")]
        [ValidateNotNullOrEmpty]
        [Alias("PoolName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The size of the ANF pool")]
        [ValidateNotNullOrEmpty]
        public long? PoolSize { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The service level of the ANF pool")]
        [ValidateNotNullOrEmpty]
        public string ServiceLevel { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The account object containing the pool to update")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccount AccountObject { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The pool object to update")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesPool InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                Location = InputObject.Location;
                var NameParts = InputObject.Name.Split('/');
                AccountName = NameParts[0];
                Name = NameParts[1];
            }
            else if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = AccountObject.ResourceGroupName;
                Location = AccountObject.Location;
                AccountName = AccountObject.Name;
            }

            var capacityPoolBody = new CapacityPool()
            {
                ServiceLevel = ServiceLevel,
                Size = PoolSize,
                Location = Location
            };

            if (ShouldProcess(Name, "Update the pool"))
            {
                var anfPool = AzureNetAppFilesManagementClient.Pools.CreateOrUpdate(capacityPoolBody, ResourceGroupName, AccountName, Name);
                WriteObject(anfPool);
            }
        }
    }
}
