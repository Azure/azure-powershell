namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>GeoRegion resource specific properties</summary>
    public partial class GeoRegionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Region description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display name for region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal.DisplayName { get => this._displayName; set { {_displayName = value;} } }

        /// <summary>Internal Acessors for OrgDomain</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal.OrgDomain { get => this._orgDomain; set { {_orgDomain = value;} } }

        /// <summary>Backing field for <see cref="OrgDomain" /> property.</summary>
        private string _orgDomain;

        /// <summary>Display name for region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string OrgDomain { get => this._orgDomain; }

        /// <summary>Creates an new <see cref="GeoRegionProperties" /> instance.</summary>
        public GeoRegionProperties()
        {

        }
    }
    /// GeoRegion resource specific properties
    public partial interface IGeoRegionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Region description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Region description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Display name for region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display name for region.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Display name for region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display name for region.",
        SerializedName = @"orgDomain",
        PossibleTypes = new [] { typeof(string) })]
        string OrgDomain { get;  }

    }
    /// GeoRegion resource specific properties
    internal partial interface IGeoRegionPropertiesInternal

    {
        /// <summary>Region description.</summary>
        string Description { get; set; }
        /// <summary>Display name for region.</summary>
        string DisplayName { get; set; }
        /// <summary>Display name for region.</summary>
        string OrgDomain { get; set; }

    }
}