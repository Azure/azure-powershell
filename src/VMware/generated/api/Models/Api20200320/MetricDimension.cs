namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>Specifications of the Dimension of metrics</summary>
    public partial class MetricDimension :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricDimension,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IMetricDimensionInternal
    {

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Localized friendly display name of the dimension</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="InternalName" /> property.</summary>
        private string _internalName;

        /// <summary>Name of the dimension as it appears in MDM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string InternalName { get => this._internalName; set => this._internalName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the dimension</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ToBeExportedForShoebox" /> property.</summary>
        private bool? _toBeExportedForShoebox;

        /// <summary>
        /// A boolean flag indicating whether this dimension should be included for the shoebox export scenario
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public bool? ToBeExportedForShoebox { get => this._toBeExportedForShoebox; set => this._toBeExportedForShoebox = value; }

        /// <summary>Creates an new <see cref="MetricDimension" /> instance.</summary>
        public MetricDimension()
        {

        }
    }
    /// Specifications of the Dimension of metrics
    public partial interface IMetricDimension :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>Localized friendly display name of the dimension</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized friendly display name of the dimension",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Name of the dimension as it appears in MDM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the dimension as it appears in MDM",
        SerializedName = @"internalName",
        PossibleTypes = new [] { typeof(string) })]
        string InternalName { get; set; }
        /// <summary>Name of the dimension</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the dimension",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// A boolean flag indicating whether this dimension should be included for the shoebox export scenario
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean flag indicating whether this dimension should be included for the shoebox export scenario",
        SerializedName = @"toBeExportedForShoebox",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ToBeExportedForShoebox { get; set; }

    }
    /// Specifications of the Dimension of metrics
    internal partial interface IMetricDimensionInternal

    {
        /// <summary>Localized friendly display name of the dimension</summary>
        string DisplayName { get; set; }
        /// <summary>Name of the dimension as it appears in MDM</summary>
        string InternalName { get; set; }
        /// <summary>Name of the dimension</summary>
        string Name { get; set; }
        /// <summary>
        /// A boolean flag indicating whether this dimension should be included for the shoebox export scenario
        /// </summary>
        bool? ToBeExportedForShoebox { get; set; }

    }
}