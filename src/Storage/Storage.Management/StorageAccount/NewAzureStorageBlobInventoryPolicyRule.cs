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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections.Generic;
using System.Management.Automation;
using System.Reflection;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageBlobInventoryPolicyRule", DefaultParameterSetName = BlobRuleParameterSet), OutputType(typeof(PSBlobInventoryPolicyRule))]
    public class NewAzureStorageBlobInventoryPolicyRuleCommand : StorageAccountBaseCmdlet
    {
        protected const string BlobRuleParameterSet = "BlobRuleParameterSet";
        protected const string ContainerRuleParameterSet = "ContainerRuleParameterSet";

        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The rule is disabled if set it.")]
        public SwitchParameter Disabled { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The container name where blob inventory files are stored. Must be pre-created.")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Specifies the format for the inventory files. Possible values include: 'Csv', 'Parquet'")]
        [ValidateSet(BlobInventoryPolicyRuleFormat.Csv,
            BlobInventoryPolicyRuleFormat.Parquet,
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Format { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "This field is used to schedule an inventory formation. Possible values include: 'Daily', 'Weekly'")]
        [ValidateSet(BlobInventoryPolicyRuleSchedule.Daily,
            BlobInventoryPolicyRuleSchedule.Weekly,
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Schedule { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = BlobRuleParameterSet,
            HelpMessage = "Specifies the fields and properties of the Blob object to be included in the inventory. Valid values include: " +
                            "Name, Creation-Time, Last-Modified, Content-Length, Content-MD5, BlobType, AccessTier, AccessTierChangeTime, Expiry-Time, hdi_isfolder, Owner, " +
                            "Group, Permissions, Acl, Metadata, LastAccessTime, AccessTierInferred, Tags. 'Name' is a required schemafield. " + 
                            "Schema field values 'Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl' are valid only for Hns enabled accounts.'Tags' field is only valid for non Hns accounts." +
                            "If specify '-IncludeSnapshot', will include 'Snapshot'  in the inventory.  If specify '-IncludeBlobVersion', will include 'VersionId, 'IsCurrentVersion' in the inventory.")]
        [ValidateSet(BlobInventoryPolicyBlobSchemaField.Name,
            BlobInventoryPolicyBlobSchemaField.CreationTime,
            BlobInventoryPolicyBlobSchemaField.LastModified,
            BlobInventoryPolicyBlobSchemaField.ContentLength,
            BlobInventoryPolicyBlobSchemaField.ContentMD5,
            BlobInventoryPolicyBlobSchemaField.BlobType,
            BlobInventoryPolicyBlobSchemaField.AccessTier,
            BlobInventoryPolicyBlobSchemaField.AccessTierChangeTime,
            BlobInventoryPolicyBlobSchemaField.ExpiryTime,
            BlobInventoryPolicyBlobSchemaField.hdiisfolder,
            BlobInventoryPolicyBlobSchemaField.Owner,
            BlobInventoryPolicyBlobSchemaField.Group,
            BlobInventoryPolicyBlobSchemaField.Permissions,
            BlobInventoryPolicyBlobSchemaField.Acl,
            BlobInventoryPolicyBlobSchemaField.Metadata,
            BlobInventoryPolicyBlobSchemaField.LastAccessTime,
            BlobInventoryPolicyBlobSchemaField.AccessTierInferred,
            BlobInventoryPolicyBlobSchemaField.Tags,
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string[] BlobSchemaField { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ContainerRuleParameterSet,
            HelpMessage = "Specifies the fields and properties of the container object to be included in the inventory. Valid values include: " +
                            "Name, Last-Modified, Metadata, LeaseStatus, LeaseState, LeaseDuration, PublicAccess, HasImmutabilityPolicy, HasLegalHold. " + 
                            "'Name' is a required schemafield.")]
        [ValidateSet(BlobInventoryPolicyContainerSchemaField.Name,
            BlobInventoryPolicyContainerSchemaField.LastModified,
            BlobInventoryPolicyContainerSchemaField.Metadata,
            BlobInventoryPolicyContainerSchemaField.LeaseStatus,
            BlobInventoryPolicyContainerSchemaField.LeaseState,
            BlobInventoryPolicyContainerSchemaField.LeaseDuration,
            BlobInventoryPolicyContainerSchemaField.PublicAccess,
            BlobInventoryPolicyContainerSchemaField.HasImmutabilityPolicy,
            BlobInventoryPolicyContainerSchemaField.HasLegalHold,
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string[] ContainerSchemaField { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = BlobRuleParameterSet,
            HelpMessage = "Sets the blob types for the blob inventory policy rule. Valid values include blockBlob, appendBlob, pageBlob. Hns accounts does not support pageBlobs.")]
        [ValidateSet(AzureBlobType.BlockBlob,
            AzureBlobType.PageBlob,
            AzureBlobType.AppendBlob,
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string[] BlobType { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Sets an array of strings for blob prefixes to be matched..")]
        [ValidateNotNullOrEmpty]
        public string[] PrefixMatch { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = BlobRuleParameterSet,
            HelpMessage = "The rule is disabled if set it.")]
        public SwitchParameter IncludeSnapshot { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = BlobRuleParameterSet,
            HelpMessage = "The rule is disabled if set it.")]
        public SwitchParameter IncludeBlobVersion { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PSBlobInventoryPolicyDefinition definition = new PSBlobInventoryPolicyDefinition();
            if (this.BlobType != null || this.PrefixMatch != null || this.IncludeSnapshot.IsPresent || this.IncludeBlobVersion.IsPresent)
            {
                definition.Filters = new PSBlobInventoryPolicyFilter()
                {
                    BlobTypes = NormalizeStringArray<AzureBlobType>(this.BlobType),
                    PrefixMatch = this.PrefixMatch
                };
                if (this.IncludeBlobVersion.IsPresent)
                {
                    definition.Filters.IncludeBlobVersions = true;
                }
                if (this.IncludeSnapshot.IsPresent)
                {
                    definition.Filters.IncludeSnapshots = true;
                }
            }
            definition.Format = NormalizeString<BlobInventoryPolicyRuleFormat>(this.Format);
            definition.Schedule = NormalizeString<BlobInventoryPolicyRuleSchedule>(this.Schedule);

            // Set schemaFields
            List<string> schemaFieldList = null;
            if (ParameterSetName == ContainerRuleParameterSet) // Container inventory
            {
                definition.ObjectType = BlobInventoryPolicyRuleObjectType.Container;

                // ContainerSchemaField can't be null, so schemaFieldList won't be null
                schemaFieldList = new List<string>(NormalizeStringArray<BlobInventoryPolicyContainerSchemaField>(this.ContainerSchemaField));
            }
            else // Blob inventory
            {
                definition.ObjectType = BlobInventoryPolicyRuleObjectType.Blob;

                // BlobInventoryPolicyBlobSchemaField can't be null, so schemaFieldList won't be null
                schemaFieldList = new List<string>(NormalizeStringArray<BlobInventoryPolicyBlobSchemaField>(this.BlobSchemaField));
                if (this.IncludeSnapshot.IsPresent)
                {
                    schemaFieldList.Add(BlobInventoryPolicyBlobSchemaField.Snapshot);
                }
                if (this.IncludeBlobVersion.IsPresent)
                {
                    schemaFieldList.Add(BlobInventoryPolicyBlobSchemaField.VersionId);
                    schemaFieldList.Add(BlobInventoryPolicyBlobSchemaField.IsCurrentVersion);
                }
            }
            if (!schemaFieldList.Contains(BlobInventoryPolicyBlobSchemaField.Name))
            {
                WriteWarning("The SchemaFields miss require field 'Name', so add 'Name' to the SchemaFields.");
                schemaFieldList.Add(BlobInventoryPolicyBlobSchemaField.Name);
            }
            definition.SchemaFields = schemaFieldList.ToArray();

            PSBlobInventoryPolicyRule rule = new PSBlobInventoryPolicyRule()
            {
                Name = this.Name,
                Enabled = Disabled.IsPresent ? false : true,
                Definition = definition,
                Destination = this.Destination
            };

            WriteObject(rule);
        }

        protected struct BlobInventoryPolicyRuleFormat
        {
            public const string Csv = "Csv";
            public const string Parquet = "Parquet";
        }

        protected struct BlobInventoryPolicyContainerSchemaField
        {
            public const string Name = "Name";
            public const string LastModified = "Last-Modified";
            public const string Metadata = "Metadata";
            public const string LeaseStatus = "LeaseStatus";
            public const string LeaseState = "LeaseState";
            public const string LeaseDuration = "LeaseDuration";
            public const string PublicAccess = "PublicAccess";
            public const string HasImmutabilityPolicy = "HasImmutabilityPolicy";
            public const string HasLegalHold = "HasLegalHold";
        }

        protected struct BlobInventoryPolicyBlobSchemaField
        {
            public const string Name = "Name";
            public const string CreationTime = "Creation-Time";
            public const string LastModified = "Last-Modified";
            public const string ContentLength = "Content-Length";
            public const string ContentMD5 = "Content-MD5";
            public const string BlobType = "BlobType";
            public const string AccessTier = "AccessTier";
            public const string AccessTierChangeTime = "AccessTierChangeTime";
            public const string ExpiryTime = "Expiry-Time";
            public const string hdiisfolder = "hdi_isfolder";
            public const string Owner = "Owner";
            public const string Group = "Group";
            public const string Permissions = "Permissions";
            public const string Acl = "Acl";
            public const string Snapshot = "Snapshot";
            public const string VersionId = "VersionId";
            public const string IsCurrentVersion = "IsCurrentVersion";
            public const string Metadata = "Metadata";
            public const string LastAccessTime = "LastAccessTime";
            public const string AccessTierInferred = "AccessTierInferred";
            public const string Tags = "Tags";
        }

        protected struct BlobInventoryPolicyRuleSchedule
        {
            public const string Daily = "Daily";
            public const string Weekly = "Weekly";
        }

        protected struct BlobInventoryPolicyRuleObjectType
        {
            public const string Blob = "Blob";
            public const string Container = "Container";
        }
    }
}
