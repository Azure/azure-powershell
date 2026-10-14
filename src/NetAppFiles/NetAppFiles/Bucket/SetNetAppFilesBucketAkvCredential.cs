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
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.Bucket
{
    [Cmdlet(
        VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesBucketAkvCredential",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(bool))]
    [Alias("Set-AnfBucketAkvCredential")]
    public class SetAzureRmNetAppFilesBucketAkvCredential : AzureNetAppFilesCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts", nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF capacity pool")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts/capacityPools", nameof(ResourceGroupName), nameof(AccountName))]
        public string PoolName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF volume")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts/capacityPools/volumes", nameof(ResourceGroupName), nameof(AccountName), nameof(PoolName))]
        public string VolumeName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF bucket")]
        [ValidateNotNullOrEmpty]
        [Alias("BucketName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/volumes/buckets",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName),
            nameof(VolumeName))]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The resource id of the ANF bucket")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The bucket object for which AKV-stored credentials should be generated")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesBucket InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Number of days from now until the newly generated Access and Secret key pair will expire.")]
        [ValidateRange(1, int.MaxValue)]
        public int? KeyPairExpiryDay { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return whether the operation completed successfully")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                PoolName = parentResources[3];
                VolumeName = parentResources[5];
                Name = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                var nameParts = ResourceIdHelpers.NamePartsFromId(InputObject.Id);
                AccountName = nameParts[0];
                PoolName = nameParts[1];
                VolumeName = nameParts[2];
                Name = nameParts[3];
            }

            var body = new BucketCredentialsExpiry(KeyPairExpiryDay);
            bool success = false;

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.UpdateResourceMessage, Name)))
            {
                try
                {
                    AzureNetAppFilesManagementClient.Buckets.GenerateAkvCredentials(ResourceGroupName, AccountName, PoolName, VolumeName, Name, body);
                    success = true;
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }

            if (PassThru)
            {
                WriteObject(success);
            }
        }
    }
}
