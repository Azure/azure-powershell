namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Geographical region.</summary>
    public partial class GeoRegion :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegion,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Region description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotFormat]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal)Property).Description; }

        /// <summary>Display name for region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotFormat]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal)Property).DisplayName; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotFormat]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal)Property).Description = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal)Property).DisplayName = value; }

        /// <summary>Internal Acessors for OrgDomain</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionInternal.OrgDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal)Property).OrgDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal)Property).OrgDomain = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.GeoRegionProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Display name for region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotFormat]
        public string OrgDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionPropertiesInternal)Property).OrgDomain; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionProperties _property;

        /// <summary>GeoRegion resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.GeoRegionProperties()); set => this._property = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="GeoRegion" /> instance.</summary>
        public GeoRegion()
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
    /// Geographical region.
    public partial interface IGeoRegion :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Geographical region.
    internal partial interface IGeoRegionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Region description.</summary>
        string Description { get; set; }
        /// <summary>Display name for region.</summary>
        string DisplayName { get; set; }
        /// <summary>Display name for region.</summary>
        string OrgDomain { get; set; }
        /// <summary>GeoRegion resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegionProperties Property { get; set; }

    }
}