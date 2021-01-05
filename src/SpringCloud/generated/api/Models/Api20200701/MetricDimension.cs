namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Specifications of the Dimension of metrics</summary>
    public partial class MetricDimension :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMetricDimension,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMetricDimensionInternal
    {

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Localized friendly display name of the dimension</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the dimension</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="MetricDimension" /> instance.</summary>
        public MetricDimension()
        {

        }
    }
    /// Specifications of the Dimension of metrics
    public partial interface IMetricDimension :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Localized friendly display name of the dimension</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized friendly display name of the dimension",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Name of the dimension</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the dimension",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Specifications of the Dimension of metrics
    public partial interface IMetricDimensionInternal

    {
        /// <summary>Localized friendly display name of the dimension</summary>
        string DisplayName { get; set; }
        /// <summary>Name of the dimension</summary>
        string Name { get; set; }

    }
}