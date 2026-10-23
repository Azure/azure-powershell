// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;

    public partial interface IVolume
    {
        string ManagedByResourceId { get; set; }
    }

    public partial class Volume
    {
        /// <summary>
        /// Gets the first managed resource ID. Setting this legacy property replaces all owners with a single resource ID.
        /// Use ManagedBy to work with multiple owners. A null or empty value clears the owners.
        /// </summary>
        public string ManagedByResourceId
        {
            get
            {
                if (ManagedBy != null)
                {
                    foreach (var owner in ManagedBy)
                    {
                        if (owner?.ResourceId != null && owner.ResourceId.Count > 0)
                        {
                            return owner.ResourceId[0];
                        }
                    }
                }

                return null;
            }
            set
            {
                ManagedBy = string.IsNullOrEmpty(value) ? null : new List<IManagedByResources>
                {
                    new ManagedByResources { ResourceId = new List<string> { value } }
                };
            }
        }

        partial void AfterDeserializeDictionary(IDictionary content)
        {
            if (content.Contains(nameof(ManagedByResourceId)))
            {
                SetLegacyManagedBy(content.Contains(nameof(ManagedBy)), content[nameof(ManagedByResourceId)]);
            }
        }

        partial void AfterDeserializePSObject(PSObject content)
        {
            var legacyProperty = content.Properties[nameof(ManagedByResourceId)];
            if (legacyProperty != null)
            {
                SetLegacyManagedBy(content.Properties[nameof(ManagedBy)] != null, legacyProperty.Value);
            }
        }

        private void SetLegacyManagedBy(bool hasManagedBy, object resourceId)
        {
            if (hasManagedBy)
            {
                throw new ArgumentException("Specify either ManagedBy or ManagedByResourceId, not both.");
            }

            ManagedByResourceId = resourceId == null ? null : LanguagePrimitives.ConvertTo<string>(resourceId);
        }
    }
}
