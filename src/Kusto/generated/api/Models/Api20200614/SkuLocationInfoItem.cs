namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The locations and zones info for SKU.</summary>
    public partial class SkuLocationInfoItem :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ISkuLocationInfoItem,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ISkuLocationInfoItemInternal
    {

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The available location of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string[] _zone;

        /// <summary>The available zone of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] Zone { get => this._zone; set => this._zone = value; }

        /// <summary>Creates an new <see cref="SkuLocationInfoItem" /> instance.</summary>
        public SkuLocationInfoItem()
        {

        }
    }
    /// The locations and zones info for SKU.
    public partial interface ISkuLocationInfoItem :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The available location of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The available location of the SKU.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>The available zone of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The available zone of the SKU.",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        string[] Zone { get; set; }

    }
    /// The locations and zones info for SKU.
    internal partial interface ISkuLocationInfoItemInternal

    {
        /// <summary>The available location of the SKU.</summary>
        string Location { get; set; }
        /// <summary>The available zone of the SKU.</summary>
        string[] Zone { get; set; }

    }
}