namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    /// <summary>The shared dashboard properties.</summary>
    public partial class DashboardProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Lens" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesLenses _lens;

        /// <summary>The dashboard lenses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Origin(Microsoft.Azure.PowerShell.Cmdlets.Portal.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesLenses Lens { get => (this._lens = this._lens ?? new Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPropertiesLenses()); set => this._lens = value; }

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesMetadata _metadata;

        /// <summary>The dashboard metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Origin(Microsoft.Azure.PowerShell.Cmdlets.Portal.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesMetadata Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPropertiesMetadata()); set => this._metadata = value; }

        /// <summary>Creates an new <see cref="DashboardProperties" /> instance.</summary>
        public DashboardProperties()
        {

        }
    }
    /// The shared dashboard properties.
    public partial interface IDashboardProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IJsonSerializable
    {
        /// <summary>The dashboard lenses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The dashboard lenses.",
        SerializedName = @"lenses",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesLenses) })]
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesLenses Lens { get; set; }
        /// <summary>The dashboard metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The dashboard metadata.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesMetadata) })]
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesMetadata Metadata { get; set; }

    }
    /// The shared dashboard properties.
    internal partial interface IDashboardPropertiesInternal

    {
        /// <summary>The dashboard lenses.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesLenses Lens { get; set; }
        /// <summary>The dashboard metadata.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesMetadata Metadata { get; set; }

    }
}