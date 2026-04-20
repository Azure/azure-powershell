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
        VerbsData.Update,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesBucket",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesBucket))]
    [Alias("Update-AnfBucket")]
    public class UpdateAzureRmNetAppFilesBucket : AzureNetAppFilesCmdletBase
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
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = "The name of the ANF bucket")]
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

        [Parameter(ParameterSetName = ObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The bucket object to update")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesBucket InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Access permissions for the bucket. Either ReadOnly or ReadWrite.")]
        [PSArgumentCompleter("ReadOnly", "ReadWrite")]
        public string Permissions { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "NFS user UID accessing the bucket data (mutually exclusive with CifsUserName).")]
        public long? NfsUserId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "NFS user GID accessing the bucket data.")]
        public long? NfsGroupId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "CIFS username accessing the bucket data (mutually exclusive with NfsUserId/NfsGroupId).")]
        [ValidateNotNullOrEmpty]
        public string CifsUserName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Host part of the bucket URL.")]
        [ValidateNotNullOrEmpty]
        public string ServerFqdn { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Base64-encoded contents of the PEM file containing the bucket server certificate and private key.")]
        [ValidateNotNullOrEmpty]
        public string ServerCertificateObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Action when there is a certificate conflict. Either Update or Fail.")]
        [PSArgumentCompleter("Update", "Fail")]
        public string OnCertificateConflictAction { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Base URI of the Azure Key Vault used to retrieve the bucket server certificate.")]
        [ValidateNotNullOrEmpty]
        public string CertificateKeyVaultUri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the bucket server certificate stored in Azure Key Vault.")]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Base URI of the Azure Key Vault used to store the bucket credentials.")]
        [ValidateNotNullOrEmpty]
        public string CredentialsKeyVaultUri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the secret in Azure Key Vault holding the bucket credentials.")]
        [ValidateNotNullOrEmpty]
        public string CredentialsSecretName { get; set; }

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
                var nameParts = InputObject.Name.Split('/');
                AccountName = nameParts[0];
                PoolName = nameParts[1];
                VolumeName = nameParts[2];
                Name = nameParts[3];
            }

            var patchBody = new BucketPatch
            {
                Permissions = Permissions,
                FileSystemUser = BuildFileSystemUser(),
                Server = BuildServerPatch(),
                AkvDetails = BuildAkvDetails()
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.UpdateResourceMessage, Name)))
            {
                try
                {
                    var anfBucket = AzureNetAppFilesManagementClient.Buckets.Update(ResourceGroupName, AccountName, PoolName, VolumeName, Name, patchBody);
                    WriteObject(anfBucket.ConvertToPs());
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }
        }

        private FileSystemUser BuildFileSystemUser()
        {
            if (NfsUserId.HasValue || NfsGroupId.HasValue)
            {
                return new FileSystemUser(nfsUser: new NfsUser(NfsUserId, NfsGroupId));
            }
            if (!string.IsNullOrEmpty(CifsUserName))
            {
                return new FileSystemUser(cifsUser: new CifsUser(CifsUserName));
            }
            return null;
        }

        private BucketServerPatchProperties BuildServerPatch()
        {
            if (string.IsNullOrEmpty(ServerFqdn) && string.IsNullOrEmpty(ServerCertificateObject) && string.IsNullOrEmpty(OnCertificateConflictAction))
            {
                return null;
            }
            return new BucketServerPatchProperties
            {
                Fqdn = ServerFqdn,
                CertificateObject = ServerCertificateObject,
                OnCertificateConflictAction = OnCertificateConflictAction
            };
        }

        private AzureKeyVaultDetails BuildAkvDetails()
        {
            CertificateAkvDetails certAkv = null;
            CredentialsAkvDetails credAkv = null;

            if (!string.IsNullOrEmpty(CertificateKeyVaultUri) || !string.IsNullOrEmpty(CertificateName))
            {
                certAkv = new CertificateAkvDetails(CertificateKeyVaultUri, CertificateName);
            }
            if (!string.IsNullOrEmpty(CredentialsKeyVaultUri) || !string.IsNullOrEmpty(CredentialsSecretName))
            {
                credAkv = new CredentialsAkvDetails(CredentialsKeyVaultUri, CredentialsSecretName);
            }
            if (certAkv == null && credAkv == null)
            {
                return null;
            }
            return new AzureKeyVaultDetails(certAkv, credAkv);
        }
    }
}
