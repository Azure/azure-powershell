namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Static Site Function Overview ARM resource.</summary>
    public partial class StaticSiteFunctionOverviewArmResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>The name for the function</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FunctionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourcePropertiesInternal)Property).FunctionName; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for FunctionName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourceInternal.FunctionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourcePropertiesInternal)Property).FunctionName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourcePropertiesInternal)Property).FunctionName = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourceProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteFunctionOverviewArmResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for TriggerType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggerTypes? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourceInternal.TriggerType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourcePropertiesInternal)Property).TriggerType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourcePropertiesInternal)Property).TriggerType = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourceProperties _property;

        /// <summary>StaticSiteFunctionOverviewARMResource resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteFunctionOverviewArmResourceProperties()); set => this._property = value; }

        /// <summary>The trigger type of the function</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggerTypes? TriggerType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourcePropertiesInternal)Property).TriggerType; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="StaticSiteFunctionOverviewArmResource" /> instance.</summary>
        public StaticSiteFunctionOverviewArmResource()
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
    /// Static Site Function Overview ARM resource.
    public partial interface IStaticSiteFunctionOverviewArmResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>The name for the function</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name for the function",
        SerializedName = @"functionName",
        PossibleTypes = new [] { typeof(string) })]
        string FunctionName { get;  }
        /// <summary>The trigger type of the function</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The trigger type of the function",
        SerializedName = @"triggerType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggerTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggerTypes? TriggerType { get;  }

    }
    /// Static Site Function Overview ARM resource.
    internal partial interface IStaticSiteFunctionOverviewArmResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>The name for the function</summary>
        string FunctionName { get; set; }
        /// <summary>StaticSiteFunctionOverviewARMResource resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteFunctionOverviewArmResourceProperties Property { get; set; }
        /// <summary>The trigger type of the function</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggerTypes? TriggerType { get; set; }

    }
}