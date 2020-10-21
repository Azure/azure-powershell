namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Details of capabilities available to a SKU in specific zones</summary>
    public partial class ResourceSkuZoneDetails :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuZoneDetails,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuZoneDetailsInternal
    {

        /// <summary>Backing field for <see cref="Capability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuCapabilities[] _capability;

        /// <summary>
        /// Gets a list of capabilities that are available for the SKU in the
        /// specified list of zones.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuCapabilities[] Capability { get => this._capability; set => this._capability = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string[] _name;

        /// <summary>
        /// Gets the set of zones that the SKU is available in with the
        /// specified capabilities.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string[] Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="ResourceSkuZoneDetails" /> instance.</summary>
        public ResourceSkuZoneDetails()
        {

        }
    }
    /// Details of capabilities available to a SKU in specific zones
    public partial interface IResourceSkuZoneDetails :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets a list of capabilities that are available for the SKU in the
        /// specified list of zones.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a list of capabilities that are available for the SKU in the
        specified list of zones.",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuCapabilities) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuCapabilities[] Capability { get; set; }
        /// <summary>
        /// Gets the set of zones that the SKU is available in with the
        /// specified capabilities.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the set of zones that the SKU is available in with the
        specified capabilities.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string[] Name { get; set; }

    }
    /// Details of capabilities available to a SKU in specific zones
    public partial interface IResourceSkuZoneDetailsInternal

    {
        /// <summary>
        /// Gets a list of capabilities that are available for the SKU in the
        /// specified list of zones.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuCapabilities[] Capability { get; set; }
        /// <summary>
        /// Gets the set of zones that the SKU is available in with the
        /// specified capabilities.
        /// </summary>
        string[] Name { get; set; }

    }
}