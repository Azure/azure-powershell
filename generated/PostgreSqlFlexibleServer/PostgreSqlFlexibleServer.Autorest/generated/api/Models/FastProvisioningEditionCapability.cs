// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Capability of a fast provisioning compute tier.</summary>
    public partial class FastProvisioningEditionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapability,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapabilityInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase __capabilityBase = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.CapabilityBase();

        /// <summary>Internal Acessors for Reason</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal.Reason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason = value ?? null; }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status = value ?? null; }

        /// <summary>Internal Acessors for ServerCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapabilityInternal.ServerCount { get => this._serverCount; set { {_serverCount = value;} } }

        /// <summary>Internal Acessors for SupportedServerVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapabilityInternal.SupportedServerVersion { get => this._supportedServerVersion; set { {_supportedServerVersion = value;} } }

        /// <summary>Internal Acessors for SupportedSku</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapabilityInternal.SupportedSku { get => this._supportedSku; set { {_supportedSku = value;} } }

        /// <summary>Internal Acessors for SupportedStorageGb</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapabilityInternal.SupportedStorageGb { get => this._supportedStorageGb; set { {_supportedStorageGb = value;} } }

        /// <summary>Internal Acessors for SupportedTier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapabilityInternal.SupportedTier { get => this._supportedTier; set { {_supportedTier = value;} } }

        /// <summary>Reason for the capability not being available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public string Reason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason; }

        /// <summary>Backing field for <see cref="ServerCount" /> property.</summary>
        private int? _serverCount;

        /// <summary>Count of servers in cache matching this specification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? ServerCount { get => this._serverCount; }

        /// <summary>Status of the capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public string Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status; }

        /// <summary>Backing field for <see cref="SupportedServerVersion" /> property.</summary>
        private string _supportedServerVersion;

        /// <summary>Major version of PostgreSQL database engine supporting fast provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SupportedServerVersion { get => this._supportedServerVersion; }

        /// <summary>Backing field for <see cref="SupportedSku" /> property.</summary>
        private string _supportedSku;

        /// <summary>Compute name (SKU) supporting fast provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SupportedSku { get => this._supportedSku; }

        /// <summary>Backing field for <see cref="SupportedStorageGb" /> property.</summary>
        private int? _supportedStorageGb;

        /// <summary>Storage size (in GB) supporting fast provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? SupportedStorageGb { get => this._supportedStorageGb; }

        /// <summary>Backing field for <see cref="SupportedTier" /> property.</summary>
        private string _supportedTier;

        /// <summary>Compute tier supporting fast provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SupportedTier { get => this._supportedTier; }

        /// <summary>Creates an new <see cref="FastProvisioningEditionCapability" /> instance.</summary>
        public FastProvisioningEditionCapability()
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
    /// Capability of a fast provisioning compute tier.
    public partial interface IFastProvisioningEditionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase
    {
        /// <summary>Count of servers in cache matching this specification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Count of servers in cache matching this specification.",
        SerializedName = @"serverCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ServerCount { get;  }
        /// <summary>Major version of PostgreSQL database engine supporting fast provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Major version of PostgreSQL database engine supporting fast provisioning.",
        SerializedName = @"supportedServerVersions",
        PossibleTypes = new [] { typeof(string) })]
        string SupportedServerVersion { get;  }
        /// <summary>Compute name (SKU) supporting fast provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Compute name (SKU) supporting fast provisioning.",
        SerializedName = @"supportedSku",
        PossibleTypes = new [] { typeof(string) })]
        string SupportedSku { get;  }
        /// <summary>Storage size (in GB) supporting fast provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Storage size (in GB) supporting fast provisioning.",
        SerializedName = @"supportedStorageGb",
        PossibleTypes = new [] { typeof(int) })]
        int? SupportedStorageGb { get;  }
        /// <summary>Compute tier supporting fast provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Compute tier supporting fast provisioning.",
        SerializedName = @"supportedTier",
        PossibleTypes = new [] { typeof(string) })]
        string SupportedTier { get;  }

    }
    /// Capability of a fast provisioning compute tier.
    internal partial interface IFastProvisioningEditionCapabilityInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal
    {
        /// <summary>Count of servers in cache matching this specification.</summary>
        int? ServerCount { get; set; }
        /// <summary>Major version of PostgreSQL database engine supporting fast provisioning.</summary>
        string SupportedServerVersion { get; set; }
        /// <summary>Compute name (SKU) supporting fast provisioning.</summary>
        string SupportedSku { get; set; }
        /// <summary>Storage size (in GB) supporting fast provisioning.</summary>
        int? SupportedStorageGb { get; set; }
        /// <summary>Compute tier supporting fast provisioning.</summary>
        string SupportedTier { get; set; }

    }
}