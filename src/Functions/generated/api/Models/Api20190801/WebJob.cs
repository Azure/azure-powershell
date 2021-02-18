namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Web Job Information.</summary>
    public partial class WebJob :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJob,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Error information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).Error = value; }

        /// <summary>Extra Info URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ExtraInfoUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).ExtraInfoUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).ExtraInfoUrl = value; }

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

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WebJobProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobProperties _property;

        /// <summary>WebJob resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WebJobProperties()); set => this._property = value; }

        /// <summary>Run command.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RunCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).RunCommand; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).RunCommand = value; }

        /// <summary>Job settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesSettings Setting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).Setting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).Setting = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Job URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Url { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).Url; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).Url = value; }

        /// <summary>Using SDK?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? UsingSdk { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).UsingSdk; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).UsingSdk = value; }

        /// <summary>Job type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? WebJobType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).WebJobType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesInternal)Property).WebJobType = value; }

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

        /// <summary>Creates an new <see cref="WebJob" /> instance.</summary>
        public WebJob()
        {

        }
    }
    /// Web Job Information.
    public partial interface IWebJob :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Error information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error information.",
        SerializedName = @"error",
        PossibleTypes = new [] { typeof(string) })]
        string Error { get; set; }
        /// <summary>Extra Info URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Extra Info URL.",
        SerializedName = @"extra_info_url",
        PossibleTypes = new [] { typeof(string) })]
        string ExtraInfoUrl { get; set; }
        /// <summary>Run command.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Run command.",
        SerializedName = @"run_command",
        PossibleTypes = new [] { typeof(string) })]
        string RunCommand { get; set; }
        /// <summary>Job settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job settings.",
        SerializedName = @"settings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesSettings) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesSettings Setting { get; set; }
        /// <summary>Job URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job URL.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }
        /// <summary>Using SDK?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Using SDK?",
        SerializedName = @"using_sdk",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UsingSdk { get; set; }
        /// <summary>Job type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job type.",
        SerializedName = @"web_job_type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? WebJobType { get; set; }

    }
    /// Web Job Information.
    internal partial interface IWebJobInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Error information.</summary>
        string Error { get; set; }
        /// <summary>Extra Info URL.</summary>
        string ExtraInfoUrl { get; set; }
        /// <summary>WebJob resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobProperties Property { get; set; }
        /// <summary>Run command.</summary>
        string RunCommand { get; set; }
        /// <summary>Job settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesSettings Setting { get; set; }
        /// <summary>Job URL.</summary>
        string Url { get; set; }
        /// <summary>Using SDK?</summary>
        bool? UsingSdk { get; set; }
        /// <summary>Job type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? WebJobType { get; set; }

    }
}