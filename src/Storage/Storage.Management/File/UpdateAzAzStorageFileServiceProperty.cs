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

namespace Microsoft.Azure.Commands.Management.Storage
{
    using Microsoft.Azure.Commands.Management.Storage.Models;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.Storage.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    /// <summary>
    /// Modify Azure Storage service properties
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + StorageFileServiceProperty, SupportsShouldProcess = true, DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSFileServiceProperties))]
    public class UpdateAzStorageFileServicePropertyCommand : StorageFileBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

        /// <summary>
        /// BlobServiceProperties ResourceId  parameter set 
        /// </summary>
        private const string PropertiesResourceIdParameterSet = "FileServicePropertiesResourceId";

        [Parameter(
          Position = 0,
          Mandatory = true,
          HelpMessage = "Resource Group Name.",
         ParameterSetName = AccountNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
           ParameterSetName = AccountNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Storage/storageAccounts", nameof(ResourceGroupName))]
        [Alias(AccountNameAlias, NameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Input a Storage account Resource Id, or a File service properties Resource Id.",
           ParameterSetName = PropertiesResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "Enable share Delete Retention Policy for the storage account by set to $true, disable share Delete Retention Policy  by set to $false.")]
        [ValidateNotNullOrEmpty]
        public bool EnableShareDeleteRetentionPolicy
        {
            get
            {
                return enableShareDeleteRetentionPolicy is null ? false : enableShareDeleteRetentionPolicy.Value;
            }
            set
            {
                enableShareDeleteRetentionPolicy = value;
            }
        }
        private bool? enableShareDeleteRetentionPolicy = null;

        [Parameter(Mandatory = false, HelpMessage = "Sets the number of retention days for the share DeleteRetentionPolicy. The value should only be set when enable share Delete Retention Policy.")]
        [Alias("Days", "RetentionDays")]
        public int ShareRetentionDays
        {
            get
            {
                return shareRetentionDays is null ? 0 : shareRetentionDays.Value;
            }
            set
            {
                shareRetentionDays = value;
            }
        }
        private int? shareRetentionDays = null;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable Multichannel by set to $true, disable Multichannel by set to $false. Applies to Premium FileStorage only.")]
        [ValidateNotNullOrEmpty]
        public bool EnableSmbMultichannel
        {
            get
            {
                return enableSmbMultichannel is null ? false : enableSmbMultichannel.Value;
            }
            set
            {
                enableSmbMultichannel = value;
            }
        }
        private bool? enableSmbMultichannel = null;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets SMB protocol versions supported by server. Valid values are SMB2.1, SMB3.0, SMB3.1.1.")]
        [ValidateSet(SmbProtocolVersions.SMB21,
            SmbProtocolVersions.SMB30,
            SmbProtocolVersions.SMB311,
            IgnoreCase = true)]
        public string[] SmbProtocolVersion { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets SMB authentication methods supported by server. Valid values are NTLMv2, Kerberos.")]
        [ValidateSet(SmbAuthenticationMethods.Kerberos,
            SmbAuthenticationMethods.NTLMv2,
            IgnoreCase = true)]
        public string[] SmbAuthenticationMethod { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets SMB channel encryption supported by server. Valid values are AES-128-CCM, AES-128-GCM, AES-256-GCM.")]
        [ValidateSet(ChannelEncryption.AES128CCM,
            ChannelEncryption.AES128GCM,
            ChannelEncryption.AES256GCM,
            IgnoreCase = true)]
        public string[] SmbChannelEncryption { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets kerberos ticket encryption supported by server. Valid values are RC4-HMAC, AES-256.")]
        [ValidateSet(KerberosTicketEncryption.AES256,
            KerberosTicketEncryption.RC4HMAC,
            IgnoreCase = true)]
        public string[] SmbKerberosTicketEncryption { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // Check input parameter
            // ShareRetentionDays should only be specified when EnableShareDeleteRetentionPolicy is true
            if (this.enableShareDeleteRetentionPolicy == null || this.enableShareDeleteRetentionPolicy.Value == false)
            {
                if (this.ShareRetentionDays != 0)
                {
                    throw new ArgumentException("ShareRetentionDays should only be specified when EnableShareDeleteRetentionPolicy is true.");
                }
            }
            else
            {
                if (this.ShareRetentionDays == 0)
                {
                    throw new ArgumentException("ShareRetentionDays must be specified when EnableShareDeleteRetentionPolicy is true.");
                }
            }

            if (ShouldProcess("FileServiceProperties", "Update"))
            {
                switch (ParameterSetName)
                {
                    case AccountObjectParameterSet:
                        this.ResourceGroupName = StorageAccount.ResourceGroupName;
                        this.StorageAccountName = StorageAccount.StorageAccountName;
                        break;
                    case PropertiesResourceIdParameterSet:
                        ResourceIdentifier blobServicePropertiesResource = new ResourceIdentifier(ResourceId);
                        this.ResourceGroupName = blobServicePropertiesResource.ResourceGroupName;
                        this.StorageAccountName = PSBlobServiceProperties.GetStorageAccountNameFromResourceId(ResourceId);
                        break;
                    default:
                        // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                        break;
                }
                DeleteRetentionPolicy deleteRetentionPolicy = null;
                if (this.enableShareDeleteRetentionPolicy != null)
                {
                    deleteRetentionPolicy = new DeleteRetentionPolicy();
                    deleteRetentionPolicy.Enabled = this.enableShareDeleteRetentionPolicy.Value;
                    if (this.enableShareDeleteRetentionPolicy.Value == true)
                    {
                        deleteRetentionPolicy.Days = ShareRetentionDays;
                    }
                }

                ProtocolSettings protocolSettings = null;
                if(this.SmbProtocolVersion != null ||
                    this.SmbAuthenticationMethod != null ||
                    this.SmbKerberosTicketEncryption != null ||
                    this.SmbChannelEncryption != null ||
                    this.enableSmbMultichannel != null)
                {
                    protocolSettings = new ProtocolSettings();
                    protocolSettings.Smb = new SmbSetting();
                    if (this.SmbProtocolVersion != null)
                    {
                        protocolSettings.Smb.Versions = ConnectStringArray(this.SmbProtocolVersion);
                    }
                    if (this.SmbAuthenticationMethod != null)
                    {
                        protocolSettings.Smb.AuthenticationMethods = ConnectStringArray(this.SmbAuthenticationMethod);
                    }
                    if (this.SmbKerberosTicketEncryption != null)
                    {
                        protocolSettings.Smb.KerberosTicketEncryption = ConnectStringArray(this.SmbKerberosTicketEncryption);
                    }
                    if (this.SmbChannelEncryption != null)
                    {
                        protocolSettings.Smb.ChannelEncryption = ConnectStringArray(this.SmbChannelEncryption);
                    }
                    if(this.enableSmbMultichannel != null)
                    {
                        protocolSettings.Smb.Multichannel = new Multichannel();
                        protocolSettings.Smb.Multichannel.Enabled = this.enableSmbMultichannel;
                    }
                }

                FileServiceProperties serviceProperties = this.StorageClient.FileServices.SetServiceProperties(this.ResourceGroupName, this.StorageAccountName, 
                    new FileServiceProperties(shareDeleteRetentionPolicy: deleteRetentionPolicy, protocolSettings: protocolSettings));

                // Get all File service properties from server for output
                serviceProperties = this.StorageClient.FileServices.GetServiceProperties(this.ResourceGroupName, this.StorageAccountName);

                WriteObject(new PSFileServiceProperties(serviceProperties));
            }
        }
    }
}
