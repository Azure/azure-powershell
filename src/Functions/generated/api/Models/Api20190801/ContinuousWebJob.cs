namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Continuous Web Job Information.</summary>
    public partial class ContinuousWebJob :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJob,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Detailed status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DetailedStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).DetailedStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).DetailedStatus = value; }

        /// <summary>Error information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).Error = value; }

        /// <summary>Extra Info URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ExtraInfoUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).ExtraInfoUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).ExtraInfoUrl = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Log URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LogUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).LogUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).LogUrl = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContinuousWebJobProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobProperties _property;

        /// <summary>ContinuousWebJob resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContinuousWebJobProperties()); set => this._property = value; }

        /// <summary>Run command.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RunCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).RunCommand; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).RunCommand = value; }

        /// <summary>Job settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesSettings Setting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).Setting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).Setting = value; }

        /// <summary>Job status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ContinuousWebJobStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).Status = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Job URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Url { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).Url; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).Url = value; }

        /// <summary>Using SDK?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? UsingSdk { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).UsingSdk; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).UsingSdk = value; }

        /// <summary>Job type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? WebJobType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).WebJobType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal)Property).WebJobType = value; }

        /// <summary>Creates an new <see cref="ContinuousWebJob" /> instance.</summary>
        public ContinuousWebJob()
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
    /// Continuous Web Job Information.
    public partial interface IContinuousWebJob :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Detailed status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Detailed status.",
        SerializedName = @"detailed_status",
        PossibleTypes = new [] { typeof(string) })]
        string DetailedStatus { get; set; }
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
        /// <summary>Log URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Log URL.",
        SerializedName = @"log_url",
        PossibleTypes = new [] { typeof(string) })]
        string LogUrl { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesSettings) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesSettings Setting { get; set; }
        /// <summary>Job status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ContinuousWebJobStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ContinuousWebJobStatus? Status { get; set; }
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
    /// Continuous Web Job Information.
    internal partial interface IContinuousWebJobInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Detailed status.</summary>
        string DetailedStatus { get; set; }
        /// <summary>Error information.</summary>
        string Error { get; set; }
        /// <summary>Extra Info URL.</summary>
        string ExtraInfoUrl { get; set; }
        /// <summary>Log URL.</summary>
        string LogUrl { get; set; }
        /// <summary>ContinuousWebJob resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobProperties Property { get; set; }
        /// <summary>Run command.</summary>
        string RunCommand { get; set; }
        /// <summary>Job settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesSettings Setting { get; set; }
        /// <summary>Job status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ContinuousWebJobStatus? Status { get; set; }
        /// <summary>Job URL.</summary>
        string Url { get; set; }
        /// <summary>Using SDK?</summary>
        bool? UsingSdk { get; set; }
        /// <summary>Job type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? WebJobType { get; set; }

    }
}