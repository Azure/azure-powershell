// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Storage size (in MB) capability.</summary>
    public partial class StorageMbCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageMbCapability,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageMbCapabilityInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase __capabilityBase = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.CapabilityBase();

        /// <summary>Backing field for <see cref="DefaultIopsTier" /> property.</summary>
        private string _defaultIopsTier;

        /// <summary>Default IOPS for this tier and storage size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DefaultIopsTier { get => this._defaultIopsTier; }

        /// <summary>Backing field for <see cref="MaximumStorageSizeMb" /> property.</summary>
        private long? _maximumStorageSizeMb;

        /// <summary>Maximum supported size (in MB) of storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public long? MaximumStorageSizeMb { get => this._maximumStorageSizeMb; }

        /// <summary>Internal Acessors for Reason</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal.Reason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason = value ?? null; }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status = value ?? null; }

        /// <summary>Internal Acessors for DefaultIopsTier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageMbCapabilityInternal.DefaultIopsTier { get => this._defaultIopsTier; set { {_defaultIopsTier = value;} } }

        /// <summary>Internal Acessors for MaximumStorageSizeMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageMbCapabilityInternal.MaximumStorageSizeMb { get => this._maximumStorageSizeMb; set { {_maximumStorageSizeMb = value;} } }

        /// <summary>Internal Acessors for StorageSizeMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageMbCapabilityInternal.StorageSizeMb { get => this._storageSizeMb; set { {_storageSizeMb = value;} } }

        /// <summary>Internal Acessors for SupportedIop</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageMbCapabilityInternal.SupportedIop { get => this._supportedIop; set { {_supportedIop = value;} } }

        /// <summary>Internal Acessors for SupportedIopsTier</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageTierCapability> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageMbCapabilityInternal.SupportedIopsTier { get => this._supportedIopsTier; set { {_supportedIopsTier = value;} } }

        /// <summary>Internal Acessors for SupportedMaximumIop</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageMbCapabilityInternal.SupportedMaximumIop { get => this._supportedMaximumIop; set { {_supportedMaximumIop = value;} } }

        /// <summary>Internal Acessors for SupportedMaximumThroughput</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageMbCapabilityInternal.SupportedMaximumThroughput { get => this._supportedMaximumThroughput; set { {_supportedMaximumThroughput = value;} } }

        /// <summary>Internal Acessors for SupportedThroughput</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageMbCapabilityInternal.SupportedThroughput { get => this._supportedThroughput; set { {_supportedThroughput = value;} } }

        /// <summary>Reason for the capability not being available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public string Reason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason; }

        /// <summary>Status of the capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public string Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status; }

        /// <summary>Backing field for <see cref="StorageSizeMb" /> property.</summary>
        private long? _storageSizeMb;

        /// <summary>Minimum supported size (in MB) of storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public long? StorageSizeMb { get => this._storageSizeMb; }

        /// <summary>Backing field for <see cref="SupportedIop" /> property.</summary>
        private int? _supportedIop;

        /// <summary>Minimum IOPS supported by the storage size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? SupportedIop { get => this._supportedIop; }

        /// <summary>Backing field for <see cref="SupportedIopsTier" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageTierCapability> _supportedIopsTier;

        /// <summary>List of all supported storage tiers for this tier and storage size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageTierCapability> SupportedIopsTier { get => this._supportedIopsTier; }

        /// <summary>Backing field for <see cref="SupportedMaximumIop" /> property.</summary>
        private int? _supportedMaximumIop;

        /// <summary>Maximum IOPS supported by the storage size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? SupportedMaximumIop { get => this._supportedMaximumIop; }

        /// <summary>Backing field for <see cref="SupportedMaximumThroughput" /> property.</summary>
        private int? _supportedMaximumThroughput;

        /// <summary>Maximum supported throughput (in MB/s) of storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? SupportedMaximumThroughput { get => this._supportedMaximumThroughput; }

        /// <summary>Backing field for <see cref="SupportedThroughput" /> property.</summary>
        private int? _supportedThroughput;

        /// <summary>Minimum supported throughput (in MB/s) of storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? SupportedThroughput { get => this._supportedThroughput; }

        /// <summary>Creates an new <see cref="StorageMbCapability" /> instance.</summary>
        public StorageMbCapability()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__capabilityBase), __capabilityBase);
            await eventListener.AssertObjectIsValid(nameof(__capabilityBase), __capabilityBase);
        }
    }
    /// Storage size (in MB) capability.
    public partial interface IStorageMbCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase
    {
        /// <summary>Default IOPS for this tier and storage size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Default IOPS for this tier and storage size.",
        SerializedName = @"defaultIopsTier",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultIopsTier { get;  }
        /// <summary>Maximum supported size (in MB) of storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Maximum supported size (in MB) of storage.",
        SerializedName = @"maximumStorageSizeMb",
        PossibleTypes = new [] { typeof(long) })]
        long? MaximumStorageSizeMb { get;  }
        /// <summary>Minimum supported size (in MB) of storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Minimum supported size (in MB) of storage.",
        SerializedName = @"storageSizeMb",
        PossibleTypes = new [] { typeof(long) })]
        long? StorageSizeMb { get;  }
        /// <summary>Minimum IOPS supported by the storage size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Minimum IOPS supported by the storage size.",
        SerializedName = @"supportedIops",
        PossibleTypes = new [] { typeof(int) })]
        int? SupportedIop { get;  }
        /// <summary>List of all supported storage tiers for this tier and storage size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of all supported storage tiers for this tier and storage size.",
        SerializedName = @"supportedIopsTiers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageTierCapability) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageTierCapability> SupportedIopsTier { get;  }
        /// <summary>Maximum IOPS supported by the storage size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Maximum IOPS supported by the storage size.",
        SerializedName = @"supportedMaximumIops",
        PossibleTypes = new [] { typeof(int) })]
        int? SupportedMaximumIop { get;  }
        /// <summary>Maximum supported throughput (in MB/s) of storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Maximum supported throughput (in MB/s) of storage.",
        SerializedName = @"supportedMaximumThroughput",
        PossibleTypes = new [] { typeof(int) })]
        int? SupportedMaximumThroughput { get;  }
        /// <summary>Minimum supported throughput (in MB/s) of storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Minimum supported throughput (in MB/s) of storage.",
        SerializedName = @"supportedThroughput",
        PossibleTypes = new [] { typeof(int) })]
        int? SupportedThroughput { get;  }

    }
    /// Storage size (in MB) capability.
    internal partial interface IStorageMbCapabilityInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal
    {
        /// <summary>Default IOPS for this tier and storage size.</summary>
        string DefaultIopsTier { get; set; }
        /// <summary>Maximum supported size (in MB) of storage.</summary>
        long? MaximumStorageSizeMb { get; set; }
        /// <summary>Minimum supported size (in MB) of storage.</summary>
        long? StorageSizeMb { get; set; }
        /// <summary>Minimum IOPS supported by the storage size.</summary>
        int? SupportedIop { get; set; }
        /// <summary>List of all supported storage tiers for this tier and storage size.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageTierCapability> SupportedIopsTier { get; set; }
        /// <summary>Maximum IOPS supported by the storage size.</summary>
        int? SupportedMaximumIop { get; set; }
        /// <summary>Maximum supported throughput (in MB/s) of storage.</summary>
        int? SupportedMaximumThroughput { get; set; }
        /// <summary>Minimum supported throughput (in MB/s) of storage.</summary>
        int? SupportedThroughput { get; set; }

    }
}