namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMwareCbt NIC input.</summary>
    public partial class VMwareCbtNicInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtNicInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtNicInputInternal
    {

        /// <summary>Backing field for <see cref="IsPrimaryNic" /> property.</summary>
        private string _isPrimaryNic;

        /// <summary>A value indicating whether this is the primary NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IsPrimaryNic { get => this._isPrimaryNic; set => this._isPrimaryNic = value; }

        /// <summary>Backing field for <see cref="IsSelectedForMigration" /> property.</summary>
        private string _isSelectedForMigration;

        /// <summary>A value indicating whether this NIC is selected for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IsSelectedForMigration { get => this._isSelectedForMigration; set => this._isSelectedForMigration = value; }

        /// <summary>Backing field for <see cref="NicId" /> property.</summary>
        private string _nicId;

        /// <summary>The NIC Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NicId { get => this._nicId; set => this._nicId = value; }

        /// <summary>Backing field for <see cref="TargetStaticIPAddress" /> property.</summary>
        private string _targetStaticIPAddress;

        /// <summary>The static IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetStaticIPAddress { get => this._targetStaticIPAddress; set => this._targetStaticIPAddress = value; }

        /// <summary>Backing field for <see cref="TargetSubnetName" /> property.</summary>
        private string _targetSubnetName;

        /// <summary>Target subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetSubnetName { get => this._targetSubnetName; set => this._targetSubnetName = value; }

        /// <summary>Creates an new <see cref="VMwareCbtNicInput" /> instance.</summary>
        public VMwareCbtNicInput()
        {

        }
    }
    /// VMwareCbt NIC input.
    public partial interface IVMwareCbtNicInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>A value indicating whether this is the primary NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A value indicating whether this is the primary NIC.",
        SerializedName = @"isPrimaryNic",
        PossibleTypes = new [] { typeof(string) })]
        string IsPrimaryNic { get; set; }
        /// <summary>A value indicating whether this NIC is selected for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether this NIC is selected for migration.",
        SerializedName = @"isSelectedForMigration",
        PossibleTypes = new [] { typeof(string) })]
        string IsSelectedForMigration { get; set; }
        /// <summary>The NIC Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The NIC Id.",
        SerializedName = @"nicId",
        PossibleTypes = new [] { typeof(string) })]
        string NicId { get; set; }
        /// <summary>The static IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The static IP address.",
        SerializedName = @"targetStaticIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string TargetStaticIPAddress { get; set; }
        /// <summary>Target subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target subnet name.",
        SerializedName = @"targetSubnetName",
        PossibleTypes = new [] { typeof(string) })]
        string TargetSubnetName { get; set; }

    }
    /// VMwareCbt NIC input.
    internal partial interface IVMwareCbtNicInputInternal

    {
        /// <summary>A value indicating whether this is the primary NIC.</summary>
        string IsPrimaryNic { get; set; }
        /// <summary>A value indicating whether this NIC is selected for migration.</summary>
        string IsSelectedForMigration { get; set; }
        /// <summary>The NIC Id.</summary>
        string NicId { get; set; }
        /// <summary>The static IP address.</summary>
        string TargetStaticIPAddress { get; set; }
        /// <summary>Target subnet name.</summary>
        string TargetSubnetName { get; set; }

    }
}