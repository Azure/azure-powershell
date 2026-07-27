// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Capabilities in terms of compute.</summary>
    public partial class ServerSkuCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal,
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

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for SecurityProfile</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal.SecurityProfile { get => this._securityProfile; set { {_securityProfile = value;} } }

        /// <summary>Internal Acessors for SupportedFeature</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal.SupportedFeature { get => this._supportedFeature; set { {_supportedFeature = value;} } }

        /// <summary>Internal Acessors for SupportedHaMode</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal.SupportedHaMode { get => this._supportedHaMode; set { {_supportedHaMode = value;} } }

        /// <summary>Internal Acessors for SupportedIop</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal.SupportedIop { get => this._supportedIop; set { {_supportedIop = value;} } }

        /// <summary>Internal Acessors for SupportedMemoryPerVcoreMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal.SupportedMemoryPerVcoreMb { get => this._supportedMemoryPerVcoreMb; set { {_supportedMemoryPerVcoreMb = value;} } }

        /// <summary>Internal Acessors for SupportedZone</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal.SupportedZone { get => this._supportedZone; set { {_supportedZone = value;} } }

        /// <summary>Internal Acessors for VCore</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal.VCore { get => this._vCore; set { {_vCore = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the compute (SKU).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Reason for the capability not being available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public string Reason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason; }

        /// <summary>Backing field for <see cref="SecurityProfile" /> property.</summary>
        private string _securityProfile;

        /// <summary>
        /// Security profile of the compute. Indicates if it's a Confidential Compute virtual machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SecurityProfile { get => this._securityProfile; }

        /// <summary>Status of the capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public string Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status; }

        /// <summary>Backing field for <see cref="SupportedFeature" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature> _supportedFeature;

        /// <summary>Features supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature> SupportedFeature { get => this._supportedFeature; }

        /// <summary>Backing field for <see cref="SupportedHaMode" /> property.</summary>
        private System.Collections.Generic.List<string> _supportedHaMode;

        /// <summary>Modes of high availability supported for this compute.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> SupportedHaMode { get => this._supportedHaMode; }

        /// <summary>Backing field for <see cref="SupportedIop" /> property.</summary>
        private int? _supportedIop;

        /// <summary>Maximum IOPS supported by this compute.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? SupportedIop { get => this._supportedIop; }

        /// <summary>Backing field for <see cref="SupportedMemoryPerVcoreMb" /> property.</summary>
        private long? _supportedMemoryPerVcoreMb;

        /// <summary>Supported memory (in MB) per virtual core assigned to this compute.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public long? SupportedMemoryPerVcoreMb { get => this._supportedMemoryPerVcoreMb; }

        /// <summary>Backing field for <see cref="SupportedZone" /> property.</summary>
        private System.Collections.Generic.List<string> _supportedZone;

        /// <summary>List of supported availability zones. E.g. '1', '2', '3'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> SupportedZone { get => this._supportedZone; }

        /// <summary>Backing field for <see cref="VCore" /> property.</summary>
        private int? _vCore;

        /// <summary>vCores available for this compute.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? VCore { get => this._vCore; }

        /// <summary>Creates an new <see cref="ServerSkuCapability" /> instance.</summary>
        public ServerSkuCapability()
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
    /// Capabilities in terms of compute.
    public partial interface IServerSkuCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase
    {
        /// <summary>Name of the compute (SKU).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Name of the compute (SKU).",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>
        /// Security profile of the compute. Indicates if it's a Confidential Compute virtual machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Security profile of the compute. Indicates if it's a Confidential Compute virtual machine.",
        SerializedName = @"securityProfile",
        PossibleTypes = new [] { typeof(string) })]
        string SecurityProfile { get;  }
        /// <summary>Features supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Features supported.",
        SerializedName = @"supportedFeatures",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature> SupportedFeature { get;  }
        /// <summary>Modes of high availability supported for this compute.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Modes of high availability supported for this compute.",
        SerializedName = @"supportedHaMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("ZoneRedundant", "SameZone")]
        System.Collections.Generic.List<string> SupportedHaMode { get;  }
        /// <summary>Maximum IOPS supported by this compute.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Maximum IOPS supported by this compute.",
        SerializedName = @"supportedIops",
        PossibleTypes = new [] { typeof(int) })]
        int? SupportedIop { get;  }
        /// <summary>Supported memory (in MB) per virtual core assigned to this compute.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Supported memory (in MB) per virtual core assigned to this compute.",
        SerializedName = @"supportedMemoryPerVcoreMb",
        PossibleTypes = new [] { typeof(long) })]
        long? SupportedMemoryPerVcoreMb { get;  }
        /// <summary>List of supported availability zones. E.g. '1', '2', '3'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of supported availability zones. E.g. '1', '2', '3'",
        SerializedName = @"supportedZones",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> SupportedZone { get;  }
        /// <summary>vCores available for this compute.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"vCores available for this compute.",
        SerializedName = @"vCores",
        PossibleTypes = new [] { typeof(int) })]
        int? VCore { get;  }

    }
    /// Capabilities in terms of compute.
    internal partial interface IServerSkuCapabilityInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal
    {
        /// <summary>Name of the compute (SKU).</summary>
        string Name { get; set; }
        /// <summary>
        /// Security profile of the compute. Indicates if it's a Confidential Compute virtual machine.
        /// </summary>
        string SecurityProfile { get; set; }
        /// <summary>Features supported.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature> SupportedFeature { get; set; }
        /// <summary>Modes of high availability supported for this compute.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("ZoneRedundant", "SameZone")]
        System.Collections.Generic.List<string> SupportedHaMode { get; set; }
        /// <summary>Maximum IOPS supported by this compute.</summary>
        int? SupportedIop { get; set; }
        /// <summary>Supported memory (in MB) per virtual core assigned to this compute.</summary>
        long? SupportedMemoryPerVcoreMb { get; set; }
        /// <summary>List of supported availability zones. E.g. '1', '2', '3'</summary>
        System.Collections.Generic.List<string> SupportedZone { get; set; }
        /// <summary>vCores available for this compute.</summary>
        int? VCore { get; set; }

    }
}