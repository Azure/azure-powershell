namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Usage of the quota resource.</summary>
    public partial class Usage :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsage,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Compute mode used for this usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).ComputeMode; }

        /// <summary>The current value of the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? CurrentValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).CurrentValue; }

        /// <summary>Friendly name shown in the UI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).DisplayName; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>The resource limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? Limit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).Limit; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for ComputeMode</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageInternal.ComputeMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).ComputeMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).ComputeMode = value; }

        /// <summary>Internal Acessors for CurrentValue</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageInternal.CurrentValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).CurrentValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).CurrentValue = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).DisplayName = value; }

        /// <summary>Internal Acessors for Limit</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageInternal.Limit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).Limit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).Limit = value; }

        /// <summary>Internal Acessors for NextResetTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageInternal.NextResetTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).NextResetTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).NextResetTime = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.UsageProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ResourceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageInternal.ResourceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).ResourceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).ResourceName = value; }

        /// <summary>Internal Acessors for SiteMode</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageInternal.SiteMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).SiteMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).SiteMode = value; }

        /// <summary>Internal Acessors for Unit</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageInternal.Unit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).Unit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).Unit = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Next reset time for the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? NextResetTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).NextResetTime; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageProperties _property;

        /// <summary>Usage resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.UsageProperties()); set => this._property = value; }

        /// <summary>Name of the quota resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ResourceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).ResourceName; }

        /// <summary>Site mode used for this usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SiteMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).SiteMode; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Units of measurement for the quota resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Unit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsagePropertiesInternal)Property).Unit; }

        /// <summary>Creates an new <see cref="Usage" /> instance.</summary>
        public Usage()
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
    /// Usage of the quota resource.
    public partial interface IUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Compute mode used for this usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Compute mode used for this usage.",
        SerializedName = @"computeMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get;  }
        /// <summary>The current value of the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current value of the resource counter.",
        SerializedName = @"currentValue",
        PossibleTypes = new [] { typeof(long) })]
        long? CurrentValue { get;  }
        /// <summary>Friendly name shown in the UI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Friendly name shown in the UI.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>The resource limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource limit.",
        SerializedName = @"limit",
        PossibleTypes = new [] { typeof(long) })]
        long? Limit { get;  }
        /// <summary>Next reset time for the resource counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Next reset time for the resource counter.",
        SerializedName = @"nextResetTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? NextResetTime { get;  }
        /// <summary>Name of the quota resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the quota resource.",
        SerializedName = @"resourceName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceName { get;  }
        /// <summary>Site mode used for this usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Site mode used for this usage.",
        SerializedName = @"siteMode",
        PossibleTypes = new [] { typeof(string) })]
        string SiteMode { get;  }
        /// <summary>Units of measurement for the quota resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Units of measurement for the quota resource.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get;  }

    }
    /// Usage of the quota resource.
    internal partial interface IUsageInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Compute mode used for this usage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get; set; }
        /// <summary>The current value of the resource counter.</summary>
        long? CurrentValue { get; set; }
        /// <summary>Friendly name shown in the UI.</summary>
        string DisplayName { get; set; }
        /// <summary>The resource limit.</summary>
        long? Limit { get; set; }
        /// <summary>Next reset time for the resource counter.</summary>
        global::System.DateTime? NextResetTime { get; set; }
        /// <summary>Usage resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUsageProperties Property { get; set; }
        /// <summary>Name of the quota resource.</summary>
        string ResourceName { get; set; }
        /// <summary>Site mode used for this usage.</summary>
        string SiteMode { get; set; }
        /// <summary>Units of measurement for the quota resource.</summary>
        string Unit { get; set; }

    }
}