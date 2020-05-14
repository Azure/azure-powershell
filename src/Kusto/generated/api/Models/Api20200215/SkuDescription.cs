namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The Kusto SKU description of given resource type</summary>
    public partial class SkuDescription :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescription,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionInternal
    {

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string[] _location;

        /// <summary>The set of locations that the SKU is available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] Location { get => this._location; }

        /// <summary>Backing field for <see cref="LocationInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuLocationInfoItem[] _locationInfo;

        /// <summary>Locations and zones</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuLocationInfoItem[] LocationInfo { get => this._locationInfo; }

        /// <summary>Internal Acessors for Location</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionInternal.Location { get => this._location; set { {_location = value;} } }

        /// <summary>Internal Acessors for LocationInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuLocationInfoItem[] Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionInternal.LocationInfo { get => this._locationInfo; set { {_locationInfo = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for ResourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionInternal.ResourceType { get => this._resourceType; set { {_resourceType = value;} } }

        /// <summary>Internal Acessors for Restriction</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionRestrictionsItem[] Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionInternal.Restriction { get => this._restriction; set { {_restriction = value;} } }

        /// <summary>Internal Acessors for Tier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionInternal.Tier { get => this._tier; set { {_tier = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the SKU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>The resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; }

        /// <summary>Backing field for <see cref="Restriction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionRestrictionsItem[] _restriction;

        /// <summary>The restrictions because of which SKU cannot be used</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionRestrictionsItem[] Restriction { get => this._restriction; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private string _tier;

        /// <summary>The tier of the SKU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Tier { get => this._tier; }

        /// <summary>Creates an new <see cref="SkuDescription" /> instance.</summary>
        public SkuDescription()
        {

        }
    }
    /// The Kusto SKU description of given resource type
    public partial interface ISkuDescription :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The set of locations that the SKU is available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The set of locations that the SKU is available",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        string[] Location { get;  }
        /// <summary>Locations and zones</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Locations and zones",
        SerializedName = @"locationInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuLocationInfoItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuLocationInfoItem[] LocationInfo { get;  }
        /// <summary>The name of the SKU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the SKU",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource type",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get;  }
        /// <summary>The restrictions because of which SKU cannot be used</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The restrictions because of which SKU cannot be used",
        SerializedName = @"restrictions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionRestrictionsItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionRestrictionsItem[] Restriction { get;  }
        /// <summary>The tier of the SKU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tier of the SKU",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string Tier { get;  }

    }
    /// The Kusto SKU description of given resource type
    internal partial interface ISkuDescriptionInternal

    {
        /// <summary>The set of locations that the SKU is available</summary>
        string[] Location { get; set; }
        /// <summary>Locations and zones</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuLocationInfoItem[] LocationInfo { get; set; }
        /// <summary>The name of the SKU</summary>
        string Name { get; set; }
        /// <summary>The resource type</summary>
        string ResourceType { get; set; }
        /// <summary>The restrictions because of which SKU cannot be used</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ISkuDescriptionRestrictionsItem[] Restriction { get; set; }
        /// <summary>The tier of the SKU</summary>
        string Tier { get; set; }

    }
}