namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Protection profile custom data details.</summary>
    public partial class ProtectionContainerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FabricFriendlyName" /> property.</summary>
        private string _fabricFriendlyName;

        /// <summary>Fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FabricFriendlyName { get => this._fabricFriendlyName; set => this._fabricFriendlyName = value; }

        /// <summary>Backing field for <see cref="FabricSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerFabricSpecificDetails _fabricSpecificDetail;

        /// <summary>Fabric specific details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerFabricSpecificDetails FabricSpecificDetail { get => (this._fabricSpecificDetail = this._fabricSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProtectionContainerFabricSpecificDetails()); set => this._fabricSpecificDetail = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FabricSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerFabricSpecificDetailsInternal)FabricSpecificDetail).InstanceType; }

        /// <summary>Backing field for <see cref="FabricType" /> property.</summary>
        private string _fabricType;

        /// <summary>The fabric type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FabricType { get => this._fabricType; set => this._fabricType = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Internal Acessors for FabricSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerFabricSpecificDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerPropertiesInternal.FabricSpecificDetail { get => (this._fabricSpecificDetail = this._fabricSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProtectionContainerFabricSpecificDetails()); set { {_fabricSpecificDetail = value;} } }

        /// <summary>Internal Acessors for FabricSpecificDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerPropertiesInternal.FabricSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerFabricSpecificDetailsInternal)FabricSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerFabricSpecificDetailsInternal)FabricSpecificDetail).InstanceType = value; }

        /// <summary>Backing field for <see cref="PairingStatus" /> property.</summary>
        private string _pairingStatus;

        /// <summary>The pairing status of this cloud.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PairingStatus { get => this._pairingStatus; set => this._pairingStatus = value; }

        /// <summary>Backing field for <see cref="ProtectedItemCount" /> property.</summary>
        private int? _protectedItemCount;

        /// <summary>Number of protected PEs</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ProtectedItemCount { get => this._protectedItemCount; set => this._protectedItemCount = value; }

        /// <summary>Backing field for <see cref="Role" /> property.</summary>
        private string _role;

        /// <summary>The role of this cloud.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Role { get => this._role; set => this._role = value; }

        /// <summary>Creates an new <see cref="ProtectionContainerProperties" /> instance.</summary>
        public ProtectionContainerProperties()
        {

        }
    }
    /// Protection profile custom data details.
    public partial interface IProtectionContainerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fabric friendly name.",
        SerializedName = @"fabricFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FabricFriendlyName { get; set; }
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the class type. Overridden in derived classes.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string FabricSpecificDetailInstanceType { get;  }
        /// <summary>The fabric type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The fabric type.",
        SerializedName = @"fabricType",
        PossibleTypes = new [] { typeof(string) })]
        string FabricType { get; set; }
        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The pairing status of this cloud.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The pairing status of this cloud.",
        SerializedName = @"pairingStatus",
        PossibleTypes = new [] { typeof(string) })]
        string PairingStatus { get; set; }
        /// <summary>Number of protected PEs</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of protected PEs",
        SerializedName = @"protectedItemCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ProtectedItemCount { get; set; }
        /// <summary>The role of this cloud.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The role of this cloud.",
        SerializedName = @"role",
        PossibleTypes = new [] { typeof(string) })]
        string Role { get; set; }

    }
    /// Protection profile custom data details.
    internal partial interface IProtectionContainerPropertiesInternal

    {
        /// <summary>Fabric friendly name.</summary>
        string FabricFriendlyName { get; set; }
        /// <summary>Fabric specific details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerFabricSpecificDetails FabricSpecificDetail { get; set; }
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        string FabricSpecificDetailInstanceType { get; set; }
        /// <summary>The fabric type.</summary>
        string FabricType { get; set; }
        /// <summary>The name.</summary>
        string FriendlyName { get; set; }
        /// <summary>The pairing status of this cloud.</summary>
        string PairingStatus { get; set; }
        /// <summary>Number of protected PEs</summary>
        int? ProtectedItemCount { get; set; }
        /// <summary>The role of this cloud.</summary>
        string Role { get; set; }

    }
}