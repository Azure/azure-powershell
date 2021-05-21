namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>A static site user provided function.</summary>
    public partial class StaticSiteUserProvidedFunctionApp :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ProxyOnlyResource();

        /// <summary>
        /// The date and time on which the function app was registered with the static site.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public global::System.DateTime? CreatedOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppPropertiesInternal)Property).CreatedOn; }

        /// <summary>The region of the function app registered with the static site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string FunctionAppRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppPropertiesInternal)Property).FunctionAppRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppPropertiesInternal)Property).FunctionAppRegion = value ?? null; }

        /// <summary>The resource id of the function app registered with the static site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string FunctionAppResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppPropertiesInternal)Property).FunctionAppResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppPropertiesInternal)Property).FunctionAppResourceId = value ?? null; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for CreatedOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppInternal.CreatedOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppPropertiesInternal)Property).CreatedOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppPropertiesInternal)Property).CreatedOn = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppProperties Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteUserProvidedFunctionAppProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppProperties _property;

        /// <summary>StaticSiteUserProvidedFunctionApp resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteUserProvidedFunctionAppProperties()); set => this._property = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="StaticSiteUserProvidedFunctionApp" /> instance.</summary>
        public StaticSiteUserProvidedFunctionApp()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// A static site user provided function.
    public partial interface IStaticSiteUserProvidedFunctionApp :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource
    {
        /// <summary>
        /// The date and time on which the function app was registered with the static site.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The date and time on which the function app was registered with the static site.",
        SerializedName = @"createdOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedOn { get;  }
        /// <summary>The region of the function app registered with the static site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The region of the function app registered with the static site",
        SerializedName = @"functionAppRegion",
        PossibleTypes = new [] { typeof(string) })]
        string FunctionAppRegion { get; set; }
        /// <summary>The resource id of the function app registered with the static site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource id of the function app registered with the static site",
        SerializedName = @"functionAppResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string FunctionAppResourceId { get; set; }

    }
    /// A static site user provided function.
    internal partial interface IStaticSiteUserProvidedFunctionAppInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal
    {
        /// <summary>
        /// The date and time on which the function app was registered with the static site.
        /// </summary>
        global::System.DateTime? CreatedOn { get; set; }
        /// <summary>The region of the function app registered with the static site</summary>
        string FunctionAppRegion { get; set; }
        /// <summary>The resource id of the function app registered with the static site</summary>
        string FunctionAppResourceId { get; set; }
        /// <summary>StaticSiteUserProvidedFunctionApp resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionAppProperties Property { get; set; }

    }
}