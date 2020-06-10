namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ResourceHealthMetadata resource specific properties</summary>
    public partial class ResourceHealthMetadataProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceHealthMetadataProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceHealthMetadataPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private string _category;

        /// <summary>The category that the resource matches in the RHC Policy File</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Category { get => this._category; set => this._category = value; }

        /// <summary>Backing field for <see cref="SignalAvailability" /> property.</summary>
        private bool? _signalAvailability;

        /// <summary>Is there a health signal for the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? SignalAvailability { get => this._signalAvailability; set => this._signalAvailability = value; }

        /// <summary>Creates an new <see cref="ResourceHealthMetadataProperties" /> instance.</summary>
        public ResourceHealthMetadataProperties()
        {

        }
    }
    /// ResourceHealthMetadata resource specific properties
    public partial interface IResourceHealthMetadataProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The category that the resource matches in the RHC Policy File</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The category that the resource matches in the RHC Policy File",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string Category { get; set; }
        /// <summary>Is there a health signal for the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Is there a health signal for the resource",
        SerializedName = @"signalAvailability",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SignalAvailability { get; set; }

    }
    /// ResourceHealthMetadata resource specific properties
    internal partial interface IResourceHealthMetadataPropertiesInternal

    {
        /// <summary>The category that the resource matches in the RHC Policy File</summary>
        string Category { get; set; }
        /// <summary>Is there a health signal for the resource</summary>
        bool? SignalAvailability { get; set; }

    }
}