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

namespace Microsoft.Azure.Commands.DataShare.Helpers
{
    using System.Diagnostics;
    using Microsoft.Azure.Commands.DataShare.Models;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    public static class ModelExtensions
    {
        public static TToEnum CastEnum<TFromEnum, TToEnum>(this TFromEnum fromEnum)
        {
            return (TToEnum)Enum.Parse(typeof(TToEnum), fromEnum.ToString());
        }

        public static PSIdentity ToPsIdentity(this Identity identity)
        {
            return new PSIdentity
            {
                PrincipalId = identity.PrincipalId,
                TenantId = identity.TenantId,
                Type = identity.Type
            };
        }

        public static PSDataShareSynchronizationSetting ToPsObject(this ScheduledSynchronizationSetting setting)
        {
            return new PSDataShareSynchronizationSetting
            {
                Id = setting.Id,
                Name = setting.Name,
                Type = setting.Type,
                CreatedAt = setting.CreatedAt,
                CreatedBy = setting.CreatedBy,
                ProvisioningState = (PSProvisioningState)Enum.Parse(
                    typeof(PSProvisioningState),
                    setting.ProvisioningState),
                SynchronizationTime = setting.SynchronizationTime,
                RecurrenceInterval = setting.RecurrenceInterval,
            };
        }

        public static PSDataShareAccount ToPsObject(this Account account)
        {
            Debug.Assert(account.ProvisioningState != null, "account.ProvisioningState != null");

            return new PSDataShareAccount
            {
                Id = account.Id,
                Name = account.Name,
                ProvisioningState = (PSProvisioningState)Enum.Parse(
                    typeof(PSProvisioningState),
                    account.ProvisioningState),
                Type = account.Type,
                CreatedAt = account.CreatedAt,
                CreatedBy = account.CreatedBy,
                Location = account.Location,
                Identity = account.Identity.ToPsIdentity(),
                Tags = account.Tags.ToHashTableTags()
            };
        }

        public static PSDataShare ToPsObject(this Share share)
        {
            return new PSDataShare
            {
                Id = share.Id,
                Name = share.Name,
                ProvisioningState = (PSProvisioningState)Enum.Parse(
                    typeof(PSProvisioningState),
                    share.ProvisioningState),
                Type = share.Type,
                CreatedAt = share.CreatedAt,
                CreatedBy = share.CreatedBy,
                ShareKind = share.ShareKind,
                Description = share.Description,
                Terms = share.Terms
            };
        }

        public static PSDataShareInvitation ToPsObject(this Invitation invitation)
        {
            return new PSDataShareInvitation
            {
                Id = invitation.Id,
                Name = invitation.Name,
                Type = invitation.Type,
                InvitationId = invitation.InvitationId,
                InvitationStatus = invitation.InvitationStatus,
                Sender = invitation.Sender,
                SentAt = invitation.SentAt,
                TargetEmail = string.IsNullOrEmpty(invitation.TargetEmail) ? null : invitation.TargetEmail,
                TargetObjectId = string.IsNullOrEmpty(invitation.TargetObjectId) ? null : invitation.TargetObjectId,
                TargetTenantId = string.IsNullOrEmpty(invitation.TargetActiveDirectoryId) ? null : invitation.TargetActiveDirectoryId
            };
        }

        public static PSDataShareSubscription ToPsObject(this ShareSubscription shareSubscription)
        {
            return new PSDataShareSubscription
            {
                Id = shareSubscription.Id,
                Name = shareSubscription.Name,
                Type = shareSubscription.Type,
                CreatedAt = shareSubscription.CreatedAt,
                CreatedBy = shareSubscription.CreatedBy,
                InvitationId = shareSubscription.InvitationId,
                ProvisioningState = (PSProvisioningState)Enum.Parse(
                    typeof(PSProvisioningState),
                    shareSubscription.ProvisioningState),
                ShareName = shareSubscription.ShareName,
                ShareKind = shareSubscription.ShareKind,
                ShareDescription = shareSubscription.ShareDescription,
                ShareSender = shareSubscription.ShareSender,
                ShareSenderCompanyName = shareSubscription.ShareSenderCompanyName,
                ShareTerms = shareSubscription.ShareTerms,
                ShareSubscriptionStatus = shareSubscription.ShareSubscriptionStatus
            };
        }

        public static PSDataShareConsumerInvitation ToPsObject(this ConsumerInvitation consumerInvitation)
        {
            return new PSDataShareConsumerInvitation
            {
                Id = consumerInvitation.Id,
                Name = consumerInvitation.Name,
                Type = consumerInvitation.Type,
                InvitationId = consumerInvitation.InvitationId,
                InvitationStatus = consumerInvitation.InvitationStatus,
                Sender = consumerInvitation.Sender,
                SentAt = consumerInvitation.SentAt,
                SenderCompanyName = consumerInvitation.SenderCompanyName,
                DataSetCount = consumerInvitation.DataSetCount,
                Description = consumerInvitation.Description,
                Terms = consumerInvitation.TermsOfUse,
                RespondedAt = consumerInvitation.RespondedAt,
                Location = consumerInvitation.Location,
                ShareName = consumerInvitation.ShareName
            };
        }

        public static PSDataShareDataSet ToPsObject(this DataSet dataSet)
        {
            switch (dataSet)
            {
                case BlobDataSet blobDataSet:
                    return blobDataSet.ToPsObject();
                case BlobContainerDataSet blobContainerDataSet:
                    return blobContainerDataSet.ToPsObject();
                case BlobFolderDataSet blobFolderDataSet:
                    return blobFolderDataSet.ToPsObject();
                case ADLSGen2FileDataSet adlsGen2FileDataSet:
                    return adlsGen2FileDataSet.ToPsObject();
                case ADLSGen2FileSystemDataSet adlsGen2FileSystemDataSet:
                    return adlsGen2FileSystemDataSet.ToPsObject();
                case ADLSGen2FolderDataSet adlsGen2FolderDataSet:
                    return adlsGen2FolderDataSet.ToPsObject();
                case ADLSGen1FileDataSet adlsGen1FileDataSet:
                    return adlsGen1FileDataSet.ToPsObject();
                case ADLSGen1FolderDataSet adlsGen1FolderDataSet:
                    return adlsGen1FolderDataSet.ToPsObject();
                default: return null;
            }
        }

        public static PSDataShareDataSetMapping ToPsObject(this DataSetMapping dataSetMapping)
        {
            switch (dataSetMapping)
            {
                case BlobDataSetMapping blobDataSetMapping:
                    return blobDataSetMapping.ToPsObject();
                case BlobContainerDataSetMapping blobContainerDataSet:
                    return blobContainerDataSet.ToPsObject();
                case BlobFolderDataSetMapping blobFolderDataSet:
                    return blobFolderDataSet.ToPsObject();
                case ADLSGen2FileDataSetMapping adlsGen2FileDataSet:
                    return adlsGen2FileDataSet.ToPsObject();
                case ADLSGen2FileSystemDataSetMapping adlsGen2FileSystemDataSet:
                    return adlsGen2FileSystemDataSet.ToPsObject();
                case ADLSGen2FolderDataSetMapping adlsGen2FolderDataSet:
                    return adlsGen2FolderDataSet.ToPsObject();
                default: return null;
            }
        }

        public static PSBlobDataSet ToPsObject(this BlobDataSet blobDataSet)
        {
            return new PSBlobDataSet
            {
                Id = blobDataSet.Id,
                Name = blobDataSet.Name,
                Type = blobDataSet.Type,
                DataSetId = blobDataSet.DataSetId,
                ContainerName = blobDataSet.ContainerName,
                FilePath = blobDataSet.FilePath,
                SubscriptionId = blobDataSet.SubscriptionId,
                ResourceGroup = blobDataSet.ResourceGroup,
                StorageAccount = blobDataSet.StorageAccountName
            };
        }

        public static PSBlobContainerDataSet ToPsObject(this BlobContainerDataSet blobContainerDataSet)
        {
            return new PSBlobContainerDataSet
            {
                Id = blobContainerDataSet.Id,
                Name = blobContainerDataSet.Name,
                Type = blobContainerDataSet.Type,
                DataSetId = blobContainerDataSet.DataSetId,
                ContainerName = blobContainerDataSet.ContainerName,
                SubscriptionId = blobContainerDataSet.SubscriptionId,
                ResourceGroup = blobContainerDataSet.ResourceGroup,
                StorageAccount = blobContainerDataSet.StorageAccountName
            };
        }

        public static PSBlobFolderDataSet ToPsObject(this BlobFolderDataSet blobFolderDataSet)
        {
            return new PSBlobFolderDataSet
            {
                Id = blobFolderDataSet.Id,
                Name = blobFolderDataSet.Name,
                Type = blobFolderDataSet.Type,
                DataSetId = blobFolderDataSet.DataSetId,
                Prefix = blobFolderDataSet.Prefix,
                ContainerName = blobFolderDataSet.ContainerName,
                SubscriptionId = blobFolderDataSet.SubscriptionId,
                ResourceGroup = blobFolderDataSet.ResourceGroup,
                StorageAccount = blobFolderDataSet.StorageAccountName
            };
        }

        public static PSAdlsGen2FileDataSet ToPsObject(this ADLSGen2FileDataSet adlsGen2FileDataSet)
        {
            return new PSAdlsGen2FileDataSet
            {
                Id = adlsGen2FileDataSet.Id,
                Name = adlsGen2FileDataSet.Name,
                Type = adlsGen2FileDataSet.Type,
                DataSetId = adlsGen2FileDataSet.DataSetId,
                FileSystem = adlsGen2FileDataSet.FileSystem,
                FilePath = adlsGen2FileDataSet.FilePath,
                SubscriptionId = adlsGen2FileDataSet.SubscriptionId,
                ResourceGroup = adlsGen2FileDataSet.ResourceGroup,
                StorageAccount = adlsGen2FileDataSet.StorageAccountName
            };
        }

        public static PSAdlsGen2FileSystemDataSet ToPsObject(this ADLSGen2FileSystemDataSet adlsGen2FileSystemDataSet)
        {
            return new PSAdlsGen2FileSystemDataSet
            {
                Id = adlsGen2FileSystemDataSet.Id,
                Name = adlsGen2FileSystemDataSet.Name,
                Type = adlsGen2FileSystemDataSet.Type,
                DataSetId = adlsGen2FileSystemDataSet.DataSetId,
                FileSystem = adlsGen2FileSystemDataSet.FileSystem,
                SubscriptionId = adlsGen2FileSystemDataSet.SubscriptionId,
                ResourceGroup = adlsGen2FileSystemDataSet.ResourceGroup,
                StorageAccount = adlsGen2FileSystemDataSet.StorageAccountName
            };
        }

        public static PSAdlsGen2FolderDataSet ToPsObject(this ADLSGen2FolderDataSet adlsGen2FolderDataSet)
        {
            return new PSAdlsGen2FolderDataSet
            {
                Id = adlsGen2FolderDataSet.Id,
                Name = adlsGen2FolderDataSet.Name,
                Type = adlsGen2FolderDataSet.Type,
                DataSetId = adlsGen2FolderDataSet.DataSetId,
                FolderPath = adlsGen2FolderDataSet.FolderPath,
                FileSystem = adlsGen2FolderDataSet.FileSystem,
                SubscriptionId = adlsGen2FolderDataSet.SubscriptionId,
                ResourceGroup = adlsGen2FolderDataSet.ResourceGroup,
                StorageAccount = adlsGen2FolderDataSet.StorageAccountName
            };
        }

        public static PSBlobDataSetMapping ToPsObject(this BlobDataSetMapping blobDataSetMapping)
        {
            return new PSBlobDataSetMapping
            {
                Id = blobDataSetMapping.Id,
                Name = blobDataSetMapping.Name,
                Type = blobDataSetMapping.Type,
                DataSetId = blobDataSetMapping.DataSetId,
                DataSetMappingStatus = blobDataSetMapping.DataSetMappingStatus,
                ContainerName = blobDataSetMapping.ContainerName,
                FilePath = blobDataSetMapping.FilePath,
                SubscriptionId = blobDataSetMapping.SubscriptionId,
                ResourceGroup = blobDataSetMapping.ResourceGroup,
                StorageAccount = blobDataSetMapping.StorageAccountName
            };
        }

        public static PSBlobContainerDataSetMapping ToPsObject(this BlobContainerDataSetMapping blobContainerDataSetMapping)
        {
            return new PSBlobContainerDataSetMapping
            {
                Id = blobContainerDataSetMapping.Id,
                Name = blobContainerDataSetMapping.Name,
                Type = blobContainerDataSetMapping.Type,
                DataSetId = blobContainerDataSetMapping.DataSetId,
                DataSetMappingStatus = blobContainerDataSetMapping.DataSetMappingStatus,
                ContainerName = blobContainerDataSetMapping.ContainerName,
                SubscriptionId = blobContainerDataSetMapping.SubscriptionId,
                ResourceGroup = blobContainerDataSetMapping.ResourceGroup,
                StorageAccount = blobContainerDataSetMapping.StorageAccountName
            };
        }

        public static PSBlobFolderDataSetMapping ToPsObject(this BlobFolderDataSetMapping blobFolderDataSetMapping)
        {
            return new PSBlobFolderDataSetMapping
            {
                Id = blobFolderDataSetMapping.Id,
                Name = blobFolderDataSetMapping.Name,
                Type = blobFolderDataSetMapping.Type,
                DataSetId = blobFolderDataSetMapping.DataSetId,
                DataSetMappingStatus = blobFolderDataSetMapping.DataSetMappingStatus,
                Prefix = blobFolderDataSetMapping.Prefix,
                ContainerName = blobFolderDataSetMapping.ContainerName,
                SubscriptionId = blobFolderDataSetMapping.SubscriptionId,
                ResourceGroup = blobFolderDataSetMapping.ResourceGroup,
                StorageAccount = blobFolderDataSetMapping.StorageAccountName
            };
        }

        public static PSAdlsGen2FileDataSetMapping ToPsObject(this ADLSGen2FileDataSetMapping adlsGen2FileDataSetMapping)
        {
            return new PSAdlsGen2FileDataSetMapping
            {
                Id = adlsGen2FileDataSetMapping.Id,
                Name = adlsGen2FileDataSetMapping.Name,
                Type = adlsGen2FileDataSetMapping.Type,
                DataSetId = adlsGen2FileDataSetMapping.DataSetId,
                DataSetMappingStatus = adlsGen2FileDataSetMapping.DataSetMappingStatus,
                FileSystem = adlsGen2FileDataSetMapping.FileSystem,
                FilePath = adlsGen2FileDataSetMapping.FilePath,
                SubscriptionId = adlsGen2FileDataSetMapping.SubscriptionId,
                ResourceGroup = adlsGen2FileDataSetMapping.ResourceGroup,
                StorageAccount = adlsGen2FileDataSetMapping.StorageAccountName
            };
        }

        public static PSAdlsGen2FileSystemDataSetMapping ToPsObject(this ADLSGen2FileSystemDataSetMapping adlsGen2FileSystemDataSetMapping)
        {
            return new PSAdlsGen2FileSystemDataSetMapping
            {
                Id = adlsGen2FileSystemDataSetMapping.Id,
                Name = adlsGen2FileSystemDataSetMapping.Name,
                Type = adlsGen2FileSystemDataSetMapping.Type,
                DataSetId = adlsGen2FileSystemDataSetMapping.DataSetId,
                DataSetMappingStatus = adlsGen2FileSystemDataSetMapping.DataSetMappingStatus,
                FileSystem = adlsGen2FileSystemDataSetMapping.FileSystem,
                SubscriptionId = adlsGen2FileSystemDataSetMapping.SubscriptionId,
                ResourceGroup = adlsGen2FileSystemDataSetMapping.ResourceGroup,
                StorageAccount = adlsGen2FileSystemDataSetMapping.StorageAccountName
            };
        }

        public static PSAdlsGen2FolderDataSetMapping ToPsObject(this ADLSGen2FolderDataSetMapping adlsGen2FolderDataSetMapping)
        {
            return new PSAdlsGen2FolderDataSetMapping
            {
                Id = adlsGen2FolderDataSetMapping.Id,
                Name = adlsGen2FolderDataSetMapping.Name,
                Type = adlsGen2FolderDataSetMapping.Type,
                DataSetId = adlsGen2FolderDataSetMapping.DataSetId,
                DataSetMappingStatus = adlsGen2FolderDataSetMapping.DataSetMappingStatus,
                FolderPath = adlsGen2FolderDataSetMapping.FolderPath,
                FileSystem = adlsGen2FolderDataSetMapping.FileSystem,
                SubscriptionId = adlsGen2FolderDataSetMapping.SubscriptionId,
                ResourceGroup = adlsGen2FolderDataSetMapping.ResourceGroup,
                StorageAccount = adlsGen2FolderDataSetMapping.StorageAccountName
            };
        }

        public static PSAdlsGen1FileDataSet ToPsObject(this ADLSGen1FileDataSet adlsGen1FileDataSet)
        {
            return new PSAdlsGen1FileDataSet
            {
                Id = adlsGen1FileDataSet.Id,
                Name = adlsGen1FileDataSet.Name,
                Type = adlsGen1FileDataSet.Type,
                DataSetId = adlsGen1FileDataSet.DataSetId,
                FileName = adlsGen1FileDataSet.FileName,
                FolderPath = adlsGen1FileDataSet.FolderPath,
                SubscriptionId = adlsGen1FileDataSet.SubscriptionId,
                ResourceGroup = adlsGen1FileDataSet.ResourceGroup,
                StorageAccount = adlsGen1FileDataSet.AccountName
            };
        }

        public static PSAdlsGen1FolderDataSet ToPsObject(this ADLSGen1FolderDataSet adlsGen1FolderDataSet)
        {
            return new PSAdlsGen1FolderDataSet
            {
                Id = adlsGen1FolderDataSet.Id,
                Name = adlsGen1FolderDataSet.Name,
                Type = adlsGen1FolderDataSet.Type,
                DataSetId = adlsGen1FolderDataSet.DataSetId,
                FolderPath = adlsGen1FolderDataSet.FolderPath,
                SubscriptionId = adlsGen1FolderDataSet.SubscriptionId,
                ResourceGroup = adlsGen1FolderDataSet.ResourceGroup,
                StorageAccount = adlsGen1FolderDataSet.AccountName
            };
        }

        public static PSDataShareProviderShareSubscription ToPsObject(this ProviderShareSubscription providerShareSubscription)
        {
            return new PSDataShareProviderShareSubscription
            {
                Id = providerShareSubscription.Id,
                Name = providerShareSubscription.Name,
                Type = providerShareSubscription.Type,
                Company = providerShareSubscription.Company,
                CreatedAt = providerShareSubscription.CreatedAt,
                CreatedBy = providerShareSubscription.CreatedBy,
                SharedAt = providerShareSubscription.SharedAt,
                SharedBy = providerShareSubscription.SharedBy,
                ShareSubscriptionObjectId = providerShareSubscription.ShareSubscriptionObjectId,
                ShareSubscriptionStatus = providerShareSubscription.ShareSubscriptionStatus
            };
        }

        public static PSDataShareTrigger ToPsObject(this ScheduledTrigger trigger)
        {
            var parsedResourceId = new ResourceIdentifier(trigger.Id);

            return new PSDataShareTrigger
            {
                Id = trigger.Id,
                Name = trigger.Name,
                Type = trigger.Type,
                ProvisioningState = (PSProvisioningState)Enum.Parse(
                    typeof(PSProvisioningState),
                    trigger.ProvisioningState),
                CreatedAt = trigger.CreatedAt,
                CreatedBy = trigger.CreatedBy,
                RecurrenceInterval = trigger.RecurrenceInterval,
                SynchronizationMode = trigger.SynchronizationMode,
                SynchronizationTime = trigger.SynchronizationTime,
                TriggerStatus = trigger.TriggerStatus,
            };
        }

        public static PSDataShareSubscriptionSynchronization ToPsObject(this ShareSubscriptionSynchronization sync)
        {
            return new PSDataShareSubscriptionSynchronization
            {
                DurationMs = sync.DurationMs,
                StartTime = sync.StartTime,
                EndTime = sync.EndTime,
                Message = sync.Message,
                Status = sync.Status,
                SynchronizationId = sync.SynchronizationId
            };
        }

        public static PSDataShareSynchronization ToPsObject(this ShareSynchronization shareSynchronization)
        {
            return new PSDataShareSynchronization
            {
                Company = shareSynchronization.Company,
                DurationMs = shareSynchronization.DurationMs,
                StartTime = shareSynchronization.StartTime,
                EndTime = shareSynchronization.EndTime,
                Message = shareSynchronization.Message,
                Status = shareSynchronization.Status,
                SynchronizationId = shareSynchronization.SynchronizationId
            };
        }

        public static PSDataShareSynchronizationDetail ToPsObject(this SynchronizationDetails synchronizationDetails)
        {
            return new PSDataShareSynchronizationDetail
            {
                Name = synchronizationDetails.Name,
                DataSetId = synchronizationDetails.DataSetId,
                DataSetType = synchronizationDetails.DataSetType,
                DurationMs = synchronizationDetails.DurationMs,
                StartTime = synchronizationDetails.StartTime,
                EndTime = synchronizationDetails.EndTime,
                Status = synchronizationDetails.Status,
                FilesRead = synchronizationDetails.FilesRead,
                FilesWritten = synchronizationDetails.FilesWritten,
                SizeRead = synchronizationDetails.SizeRead,
                SizeWritten = synchronizationDetails.SizeWritten,
                Message = synchronizationDetails.Message
            };
        }

        public static PSDataShareSourceDataSet ToPsObject(this ConsumerSourceDataSet sourceDataSet)
        {
            return new PSDataShareSourceDataSet
            {
                Name = sourceDataSet.Name,
                Id = sourceDataSet.Id,
                DataSetId = sourceDataSet.DataSetId,
                DataSetName = sourceDataSet.DataSetName,
                DataSetType = sourceDataSet.DataSetType,
                Type = sourceDataSet.Type
            };
        }

        public static IDictionary<string, string> ToDictionaryTags(this Hashtable table)
        {
            return table?.Cast<DictionaryEntry>()
                .ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value);
        }

        public static Hashtable ToHashTableTags(this IDictionary<string, string> tags)
        {
            if (tags == null)
            {
                return null;
            }

            var tagsInHashTable = new Hashtable();
            tags.Keys.ForEach(key => tagsInHashTable.Add(key, tags[key]));
            return tagsInHashTable;
        }
    }
}
