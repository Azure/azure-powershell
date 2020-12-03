namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>Each pivot must contain a 'type' and 'name'.</summary>
    public partial class PivotProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IPivotPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Data field to show in view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.PivotType? _type;

        /// <summary>Data type to show in view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.PivotType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="PivotProperties" /> instance.</summary>
        public PivotProperties()
        {

        }
    }
    /// Each pivot must contain a 'type' and 'name'.
    public partial interface IPivotProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>Data field to show in view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Data field to show in view.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Data type to show in view.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Data type to show in view.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.PivotType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.PivotType? Type { get; set; }

    }
    /// Each pivot must contain a 'type' and 'name'.
    public partial interface IPivotPropertiesInternal

    {
        /// <summary>Data field to show in view.</summary>
        string Name { get; set; }
        /// <summary>Data type to show in view.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.PivotType? Type { get; set; }

    }
}