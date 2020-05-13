namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A deleted app.</summary>
    public partial class DeletedSite :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSite,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Numeric id for the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? DeletedSiteId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).DeletedSiteId; }

        /// <summary>Name of the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DeletedSiteName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).DeletedSiteName; }

        /// <summary>Time in UTC when the app was deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DeletedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).DeletedTimestamp; }

        /// <summary>Geo Region of the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string GeoRegionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).GeoRegionName; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for DeletedSiteId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteInternal.DeletedSiteId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).DeletedSiteId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).DeletedSiteId = value; }

        /// <summary>Internal Acessors for DeletedSiteName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteInternal.DeletedSiteName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).DeletedSiteName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).DeletedSiteName = value; }

        /// <summary>Internal Acessors for DeletedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteInternal.DeletedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).DeletedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).DeletedTimestamp = value; }

        /// <summary>Internal Acessors for GeoRegionName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteInternal.GeoRegionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).GeoRegionName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).GeoRegionName = value; }

        /// <summary>Internal Acessors for PropertiesKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteInternal.PropertiesKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).Kind = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DeletedSiteProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteInternal.ResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).ResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).ResourceGroup = value; }

        /// <summary>Internal Acessors for Slot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteInternal.Slot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).Slot; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).Slot = value; }

        /// <summary>Internal Acessors for Subscription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteInternal.Subscription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).Subscription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).Subscription = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Kind of site that was deleted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PropertiesKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).Kind; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteProperties _property;

        /// <summary>DeletedSite resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DeletedSiteProperties()); set => this._property = value; }

        /// <summary>ResourceGroup that contained the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).ResourceGroup; }

        /// <summary>Slot of the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Slot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).Slot; }

        /// <summary>Subscription containing the deleted site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Subscription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)Property).Subscription; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="DeletedSite" /> instance.</summary>
        public DeletedSite()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// A deleted app.
    public partial interface IDeletedSite :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
        string PropertiesKind { get;  }
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
    /// A deleted app.
    internal partial interface IDeletedSiteInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        string PropertiesKind { get; set; }
        /// <summary>DeletedSite resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteProperties Property { get; set; }
        /// <summary>ResourceGroup that contained the deleted site</summary>
        string ResourceGroup { get; set; }
        /// <summary>Slot of the deleted site</summary>
        string Slot { get; set; }
        /// <summary>Subscription containing the deleted site</summary>
        string Subscription { get; set; }

    }
}