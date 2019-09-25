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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Adapters;
using Microsoft.Azure.Storage;
using System;
using System.Collections.Generic;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class PSContainer
    {
        public PSContainer(StorageModels.ListContainerItem container)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(container.Id);
            this.StorageAccountName = ParseStorageAccountNameFromId(container.Id);
            this.Id = container.Id;
            this.Name = container.Name;
            this.Type = container.Type;
            this.Metadata = container.Metadata;
            this.Etag = container.Etag;
            this.PublicAccess = (PSPublicAccess?)container.PublicAccess;
            this.ImmutabilityPolicy = container.ImmutabilityPolicy == null ? null : new PSImmutabilityPolicyProperties(container.ImmutabilityPolicy);
            this.LegalHold = container.LegalHold == null? null : new PSLegalHoldProperties(container.LegalHold);
            this.LastModifiedTime = container.LastModifiedTime;
            this.LeaseStatus = container.LeaseStatus;
            this.LeaseState = container.LeaseState;
            this.LeaseDuration = container.LeaseDuration;
            this.HasLegalHold = container.HasLegalHold;
            this.HasImmutabilityPolicy = container.HasImmutabilityPolicy;
        }

        public PSContainer(BlobContainer container)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(container.Id);
            this.StorageAccountName = ParseStorageAccountNameFromId(container.Id);
            this.Id = container.Id;
            this.Name = container.Name;
            this.Type = container.Type;
            this.Metadata = container.Metadata;
            this.Etag = container.Etag;
            this.PublicAccess = (PSPublicAccess?)container.PublicAccess;
            this.ImmutabilityPolicy = container.ImmutabilityPolicy == null? null : new PSImmutabilityPolicyProperties(container.ImmutabilityPolicy);
            this.LegalHold = container.LegalHold == null ? null : new PSLegalHoldProperties(container.LegalHold);
            this.LastModifiedTime = container.LastModifiedTime;
            this.LeaseStatus = container.LeaseStatus;
            this.LeaseState = container.LeaseState;
            this.LeaseDuration = container.LeaseDuration;
            this.HasLegalHold = container.HasLegalHold;
            this.HasImmutabilityPolicy = container.HasImmutabilityPolicy;
        }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.List, Position = 0)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.List, Position = 1)]
        public string StorageAccountName { get; set; }

        public string Id { get; set; }

        [Ps1Xml(Label = "Name", Target = ViewControl.List, Position = 2)]
        public string Name { get; set; }

        public string Type { get; set; }

        public string Etag { get; set; }

        public IDictionary<string, string> Metadata { get; set; }

        [Ps1Xml(Label = "PublicAccess", Target = ViewControl.List, Position = 3)]
        public PSPublicAccess? PublicAccess { get; set; }

        public PSImmutabilityPolicyProperties ImmutabilityPolicy { get; set; }

        public PSLegalHoldProperties LegalHold { get; set; }

        [Ps1Xml(Label = "LastModifiedTime", Target = ViewControl.List, Position = 4)]
        public DateTime? LastModifiedTime { get; set; }

        public string LeaseStatus { get; set; }

        public string LeaseState { get; set; }

        public string LeaseDuration { get; set; }

        [Ps1Xml(Label = "HasLegalHold", Target = ViewControl.List, Position = 5)]
        public bool? HasLegalHold { get; set; }

        [Ps1Xml(Label = "HasImmutabilityPolicy", Target = ViewControl.List, Position = 6)]
        public bool? HasImmutabilityPolicy { get; set; }


        public static string ParseResourceGroupFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[3];
            }

            return null;
        }

        public static string ParseStorageAccountNameFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[7];
            }

            return null;
        }

        public static string ParseStorageContainerNameFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[11];
            }

            return null;
        }

        /// <summary>
        /// Return a string representation of this storage account
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            // Allow listing storage contents through piping
            return null;
        }
    }

    public class PSLegalHold
    {
        public PSLegalHold(StorageModels.LegalHold legalHold)
        {
            if (legalHold != null)
            {
                this.HasLegalHold = legalHold.HasLegalHold;
                this.Tags = null;
                if (!(legalHold.Tags == null))
                {
                    Tags = ((List<string>)legalHold.Tags).ToArray();
                }
            }
        }
        public bool? HasLegalHold { get; set; }
        public string[] Tags { get; set; }

    }

    public class PSLegalHoldProperties
    {
        public PSLegalHoldProperties(StorageModels.LegalHoldProperties legalHoldProperty)
        {
            this.HasLegalHold = legalHoldProperty.HasLegalHold;
            this.Tags = null;

            List<PSTagProperty> tagList = new List<PSTagProperty>();
            if (legalHoldProperty.Tags != null && legalHoldProperty.Tags.Count != 0)
            {
                foreach (StorageModels.TagProperty tagProperty in legalHoldProperty.Tags)
                {
                    tagList.Add(new PSTagProperty(tagProperty));
                }
            }
            this.Tags = tagList.ToArray();
        }
        public bool? HasLegalHold { get; set; }
        public PSTagProperty[] Tags { get; set; }
    }

    public class PSTagProperty
    {
        public PSTagProperty(StorageModels.TagProperty tagsProperty)
        {
            this.Tag = tagsProperty.Tag;
            this.Timestamp = tagsProperty.Timestamp;
            this.ObjectIdentifier = tagsProperty.ObjectIdentifier;
            this.TenantId = tagsProperty.TenantId;
            this.Upn = tagsProperty.Upn;
        }
        
        public string Tag { get; set; }
        public DateTime? Timestamp { get; set; }
        public string ObjectIdentifier { get; set; }
        public string TenantId { get; set; }
        public string Upn { get; set; }
    }

    public class PSImmutabilityPolicy
    {
        public PSImmutabilityPolicy(StorageModels.ImmutabilityPolicy policy)
        {
            this.ImmutabilityPeriodSinceCreationInDays = policy.ImmutabilityPeriodSinceCreationInDays;
            this.State = policy.State;
            this.Etag = policy.Etag;
            this.Name = policy.Name;
            this.Type = policy.Type;
            this.Id = policy.Id;
        }

        public int ImmutabilityPeriodSinceCreationInDays { get; set; }
        public string State { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Etag { get; set; }
    }

    public class PSImmutabilityPolicyProperties
    {
        public PSImmutabilityPolicyProperties(StorageModels.ImmutabilityPolicyProperties policy)
        {
            this.ImmutabilityPeriodSinceCreationInDays = policy.ImmutabilityPeriodSinceCreationInDays;
            this.State = policy.State;
            this.Etag = policy.Etag;

            List<PSUpdateHistoryProperty> updateHistoryList = new List<PSUpdateHistoryProperty>();
            if (policy.UpdateHistory != null && policy.UpdateHistory.Count != 0)
            {
                foreach (UpdateHistoryProperty updateHistoryItem in policy.UpdateHistory)
                {
                    updateHistoryList.Add(new PSUpdateHistoryProperty(updateHistoryItem));
                }
            }
            this.UpdateHistory = updateHistoryList.ToArray();
        }

        public int ImmutabilityPeriodSinceCreationInDays { get; set; }
        public string State { get; set; }
        public string Etag { get; set; }
        public PSUpdateHistoryProperty[] UpdateHistory { get; set; }
    }

    public enum PSPublicAccess
    {
        Container = 0,
        Blob = 1,
        None = 2
    }

    public class PSUpdateHistoryProperty
    {
        public PSUpdateHistoryProperty(UpdateHistoryProperty updateHistory)
        {
            this.Update = updateHistory.Update;
            this.ImmutabilityPeriodSinceCreationInDays = updateHistory.ImmutabilityPeriodSinceCreationInDays;
            this.Timestamp = updateHistory.Timestamp;
            this.ObjectIdentifier = updateHistory.ObjectIdentifier;
            this.TenantId = updateHistory.TenantId;
            this.Upn = updateHistory.Upn;
        }
        
        public string Update { get; set; }
        public int? ImmutabilityPeriodSinceCreationInDays { get; set; }
        public DateTime? Timestamp { get; set; }
        public string ObjectIdentifier { get; set; }
        public string TenantId { get; set; }
        public string Upn { get; set; }
    }
}
