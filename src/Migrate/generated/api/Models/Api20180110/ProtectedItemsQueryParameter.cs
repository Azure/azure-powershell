namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Query parameter to enumerate protected items.</summary>
    public partial class ProtectedItemsQueryParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectedItemsQueryParameter,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectedItemsQueryParameterInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>The replication provider type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; set => this._instanceType = value; }

        /// <summary>Backing field for <see cref="MultiVMGroupCreateOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMGroupCreateOption? _multiVMGroupCreateOption;

        /// <summary>Whether Multi VM group is auto created or specified by user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMGroupCreateOption? MultiVMGroupCreateOption { get => this._multiVMGroupCreateOption; set => this._multiVMGroupCreateOption = value; }

        /// <summary>Backing field for <see cref="RecoveryPlanName" /> property.</summary>
        private string _recoveryPlanName;

        /// <summary>The recovery plan filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryPlanName { get => this._recoveryPlanName; set => this._recoveryPlanName = value; }

        /// <summary>Backing field for <see cref="SourceFabricName" /> property.</summary>
        private string _sourceFabricName;

        /// <summary>The source fabric name filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SourceFabricName { get => this._sourceFabricName; set => this._sourceFabricName = value; }

        /// <summary>Backing field for <see cref="VCenterName" /> property.</summary>
        private string _vCenterName;

        /// <summary>The vCenter name filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VCenterName { get => this._vCenterName; set => this._vCenterName = value; }

        /// <summary>Creates an new <see cref="ProtectedItemsQueryParameter" /> instance.</summary>
        public ProtectedItemsQueryParameter()
        {

        }
    }
    /// Query parameter to enumerate protected items.
    public partial interface IProtectedItemsQueryParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The replication provider type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The replication provider type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get; set; }
        /// <summary>Whether Multi VM group is auto created or specified by user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether Multi VM group is auto created or specified by user.",
        SerializedName = @"multiVmGroupCreateOption",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMGroupCreateOption) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMGroupCreateOption? MultiVMGroupCreateOption { get; set; }
        /// <summary>The recovery plan filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery plan filter.",
        SerializedName = @"recoveryPlanName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryPlanName { get; set; }
        /// <summary>The source fabric name filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source fabric name filter.",
        SerializedName = @"sourceFabricName",
        PossibleTypes = new [] { typeof(string) })]
        string SourceFabricName { get; set; }
        /// <summary>The vCenter name filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The vCenter name filter.",
        SerializedName = @"vCenterName",
        PossibleTypes = new [] { typeof(string) })]
        string VCenterName { get; set; }

    }
    /// Query parameter to enumerate protected items.
    internal partial interface IProtectedItemsQueryParameterInternal

    {
        /// <summary>The replication provider type.</summary>
        string InstanceType { get; set; }
        /// <summary>Whether Multi VM group is auto created or specified by user.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMGroupCreateOption? MultiVMGroupCreateOption { get; set; }
        /// <summary>The recovery plan filter.</summary>
        string RecoveryPlanName { get; set; }
        /// <summary>The source fabric name filter.</summary>
        string SourceFabricName { get; set; }
        /// <summary>The vCenter name filter.</summary>
        string VCenterName { get; set; }

    }
}