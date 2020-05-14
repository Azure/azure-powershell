namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>DeletedSite resource specific properties</summary>
    public partial class DeletedSiteProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal
    {

        /// <summary>Backing field for <see cref="DeletedSiteId" /> property.</summary>
        private int? _deletedSiteId;

        /// <summary>Numeric id for the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? DeletedSiteId { get => this._deletedSiteId; }

        /// <summary>Backing field for <see cref="DeletedSiteName" /> property.</summary>
        private string _deletedSiteName;

        /// <summary>Name of the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DeletedSiteName { get => this._deletedSiteName; }

        /// <summary>Backing field for <see cref="DeletedTimestamp" /> property.</summary>
        private string _deletedTimestamp;

        /// <summary>Time in UTC when the app was deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DeletedTimestamp { get => this._deletedTimestamp; }

        /// <summary>Backing field for <see cref="GeoRegionName" /> property.</summary>
        private string _geoRegionName;

        /// <summary>Geo Region of the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string GeoRegionName { get => this._geoRegionName; }

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private string _kind;

        /// <summary>Kind of site that was deleted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Kind { get => this._kind; }

        /// <summary>Internal Acessors for DeletedSiteId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal.DeletedSiteId { get => this._deletedSiteId; set { {_deletedSiteId = value;} } }

        /// <summary>Internal Acessors for DeletedSiteName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal.DeletedSiteName { get => this._deletedSiteName; set { {_deletedSiteName = value;} } }

        /// <summary>Internal Acessors for DeletedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal.DeletedTimestamp { get => this._deletedTimestamp; set { {_deletedTimestamp = value;} } }

        /// <summary>Internal Acessors for GeoRegionName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal.GeoRegionName { get => this._geoRegionName; set { {_geoRegionName = value;} } }

        /// <summary>Internal Acessors for Kind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal.Kind { get => this._kind; set { {_kind = value;} } }

        /// <summary>Internal Acessors for ResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal.ResourceGroup { get => this._resourceGroup; set { {_resourceGroup = value;} } }

        /// <summary>Internal Acessors for Slot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal.Slot { get => this._slot; set { {_slot = value;} } }

        /// <summary>Internal Acessors for Subscription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal.Subscription { get => this._subscription; set { {_subscription = value;} } }

        /// <summary>Backing field for <see cref="ResourceGroup" /> property.</summary>
        private string _resourceGroup;

        /// <summary>ResourceGroup that contained the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceGroup { get => this._resourceGroup; }

        /// <summary>Backing field for <see cref="Slot" /> property.</summary>
        private string _slot;

        /// <summary>Slot of the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Slot { get => this._slot; }

        /// <summary>Backing field for <see cref="Subscription" /> property.</summary>
        private string _subscription;

        /// <summary>Subscription containing the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Subscription { get => this._subscription; }

        /// <summary>Creates an new <see cref="DeletedSiteProperties" /> instance.</summary>
        public DeletedSiteProperties()
        {

        }
    }
    /// DeletedSite resource specific properties
    public partial interface IDeletedSiteProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Numeric id for the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Numeric id for the deleted site",
        SerializedName = @"deletedSiteId",
        PossibleTypes = new [] { typeof(int) })]
        int? DeletedSiteId { get;  }
        /// <summary>Name of the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the deleted site",
        SerializedName = @"deletedSiteName",
        PossibleTypes = new [] { typeof(string) })]
        string DeletedSiteName { get;  }
        /// <summary>Time in UTC when the app was deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Time in UTC when the app was deleted.",
        SerializedName = @"deletedTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string DeletedTimestamp { get;  }
        /// <summary>Geo Region of the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Geo Region of the deleted site",
        SerializedName = @"geoRegionName",
        PossibleTypes = new [] { typeof(string) })]
        string GeoRegionName { get;  }
        /// <summary>Kind of site that was deleted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Kind of site that was deleted",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string Kind { get;  }
        /// <summary>ResourceGroup that contained the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ResourceGroup that contained the deleted site",
        SerializedName = @"resourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroup { get;  }
        /// <summary>Slot of the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Slot of the deleted site",
        SerializedName = @"slot",
        PossibleTypes = new [] { typeof(string) })]
        string Slot { get;  }
        /// <summary>Subscription containing the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Subscription containing the deleted site",
        SerializedName = @"subscription",
        PossibleTypes = new [] { typeof(string) })]
        string Subscription { get;  }

    }
    /// DeletedSite resource specific properties
    internal partial interface IDeletedSitePropertiesInternal

    {
        /// <summary>Numeric id for the deleted site</summary>
        int? DeletedSiteId { get; set; }
        /// <summary>Name of the deleted site</summary>
        string DeletedSiteName { get; set; }
        /// <summary>Time in UTC when the app was deleted.</summary>
        string DeletedTimestamp { get; set; }
        /// <summary>Geo Region of the deleted site</summary>
        string GeoRegionName { get; set; }
        /// <summary>Kind of site that was deleted</summary>
        string Kind { get; set; }
        /// <summary>ResourceGroup that contained the deleted site</summary>
        string ResourceGroup { get; set; }
        /// <summary>Slot of the deleted site</summary>
        string Slot { get; set; }
        /// <summary>Subscription containing the deleted site</summary>
        string Subscription { get; set; }

    }
}