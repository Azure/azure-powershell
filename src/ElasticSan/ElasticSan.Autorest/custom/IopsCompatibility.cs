// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models
{
    using System;
    using System.Collections;
    using System.Management.Automation;

    public partial interface IElasticSan
    {
        int? TotalReservedIop { get; }
    }

    public partial class ElasticSan
    {
        public int? TotalReservedIop => TotalReservedIops;

        partial void AfterDeserializeDictionary(IDictionary content)
        {
            IopsCompatibility.Apply(content, nameof(TotalReservedIop), value => ((IElasticSanInternal)this).TotalReservedIops = value);
        }

        partial void AfterDeserializePSObject(PSObject content)
        {
            IopsCompatibility.Apply(content, nameof(TotalReservedIop), value => ((IElasticSanInternal)this).TotalReservedIops = value);
        }
    }

    public partial interface IElasticSanProperties
    {
        int? TotalReservedIop { get; }
    }

    public partial class ElasticSanProperties
    {
        public int? TotalReservedIop => TotalReservedIops;

        partial void AfterDeserializeDictionary(IDictionary content)
        {
            IopsCompatibility.Apply(content, nameof(TotalReservedIop), value => ((IElasticSanPropertiesInternal)this).TotalReservedIops = value);
        }

        partial void AfterDeserializePSObject(PSObject content)
        {
            IopsCompatibility.Apply(content, nameof(TotalReservedIop), value => ((IElasticSanPropertiesInternal)this).TotalReservedIops = value);
        }
    }

    public partial interface IVolumeGroup
    {
        int? ReservedIop { get; set; }
    }

    public partial class VolumeGroup
    {
        public int? ReservedIop { get => ReservedIops; set => ReservedIops = value; }

        partial void AfterDeserializeDictionary(IDictionary content)
        {
            IopsCompatibility.Apply(content, nameof(ReservedIop), value => ReservedIops = value);
        }

        partial void AfterDeserializePSObject(PSObject content)
        {
            IopsCompatibility.Apply(content, nameof(ReservedIop), value => ReservedIops = value);
        }
    }

    public partial interface IVolumeGroupProperties
    {
        int? ReservedIop { get; set; }
    }

    public partial class VolumeGroupProperties
    {
        public int? ReservedIop { get => ReservedIops; set => ReservedIops = value; }

        partial void AfterDeserializeDictionary(IDictionary content)
        {
            IopsCompatibility.Apply(content, nameof(ReservedIop), value => ReservedIops = value);
        }

        partial void AfterDeserializePSObject(PSObject content)
        {
            IopsCompatibility.Apply(content, nameof(ReservedIop), value => ReservedIops = value);
        }
    }

    public partial interface IVolumeGroupUpdate
    {
        int? ReservedIop { get; set; }
    }

    public partial class VolumeGroupUpdate
    {
        public int? ReservedIop { get => ReservedIops; set => ReservedIops = value; }

        partial void AfterDeserializeDictionary(IDictionary content)
        {
            IopsCompatibility.Apply(content, nameof(ReservedIop), value => ReservedIops = value);
        }

        partial void AfterDeserializePSObject(PSObject content)
        {
            IopsCompatibility.Apply(content, nameof(ReservedIop), value => ReservedIops = value);
        }
    }

    public partial interface IVolumeGroupUpdateProperties
    {
        int? ReservedIop { get; set; }
    }

    public partial class VolumeGroupUpdateProperties
    {
        public int? ReservedIop { get => ReservedIops; set => ReservedIops = value; }

        partial void AfterDeserializeDictionary(IDictionary content)
        {
            IopsCompatibility.Apply(content, nameof(ReservedIop), value => ReservedIops = value);
        }

        partial void AfterDeserializePSObject(PSObject content)
        {
            IopsCompatibility.Apply(content, nameof(ReservedIop), value => ReservedIops = value);
        }
    }

    internal static class IopsCompatibility
    {
        internal static void Apply(IDictionary content, string alias, Action<int?> setValue)
        {
            if (content.Contains(alias))
            {
                var canonical = alias + "s";
                Apply(content[alias], content.Contains(canonical), content.Contains(canonical) ? content[canonical] : null, alias, setValue);
            }
        }

        internal static void Apply(PSObject content, string alias, Action<int?> setValue)
        {
            var legacyProperty = content.Properties[alias];
            if (legacyProperty != null)
            {
                var canonicalProperty = content.Properties[alias + "s"];
                Apply(legacyProperty.Value, canonicalProperty != null, canonicalProperty?.Value, alias, setValue);
            }
        }

        private static void Apply(object legacyValue, bool hasCanonical, object canonicalValue, string alias, Action<int?> setValue)
        {
            var value = LanguagePrimitives.ConvertTo<int?>(legacyValue);
            if (hasCanonical)
            {
                if (value != LanguagePrimitives.ConvertTo<int?>(canonicalValue))
                {
                    throw new ArgumentException($"Specify matching values for {alias} and {alias}s, or specify only one property.");
                }
            }
            else
            {
                setValue(value);
            }
        }
    }
}
