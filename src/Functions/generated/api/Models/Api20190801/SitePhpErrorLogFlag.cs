namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Used for getting PHP error logging flag.</summary>
    public partial class SitePhpErrorLogFlag :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlag,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Local log_errors setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LocalLogError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagPropertiesInternal)Property).LocalLogError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagPropertiesInternal)Property).LocalLogError = value; }

        /// <summary>Local log_errors_max_len setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LocalLogErrorsMaxLength { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagPropertiesInternal)Property).LocalLogErrorsMaxLength; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagPropertiesInternal)Property).LocalLogErrorsMaxLength = value; }

        /// <summary>Master log_errors setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MasterLogError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagPropertiesInternal)Property).MasterLogError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagPropertiesInternal)Property).MasterLogError = value; }

        /// <summary>Master log_errors_max_len setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MasterLogErrorsMaxLength { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagPropertiesInternal)Property).MasterLogErrorsMaxLength; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagPropertiesInternal)Property).MasterLogErrorsMaxLength = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SitePhpErrorLogFlagProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagProperties _property;

        /// <summary>SitePhpErrorLogFlag resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SitePhpErrorLogFlagProperties()); set => this._property = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="SitePhpErrorLogFlag" /> instance.</summary>
        public SitePhpErrorLogFlag()
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
    /// Used for getting PHP error logging flag.
    public partial interface ISitePhpErrorLogFlag :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Local log_errors setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Local log_errors setting.",
        SerializedName = @"localLogErrors",
        PossibleTypes = new [] { typeof(string) })]
        string LocalLogError { get; set; }
        /// <summary>Local log_errors_max_len setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Local log_errors_max_len setting.",
        SerializedName = @"localLogErrorsMaxLength",
        PossibleTypes = new [] { typeof(string) })]
        string LocalLogErrorsMaxLength { get; set; }
        /// <summary>Master log_errors setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Master log_errors setting.",
        SerializedName = @"masterLogErrors",
        PossibleTypes = new [] { typeof(string) })]
        string MasterLogError { get; set; }
        /// <summary>Master log_errors_max_len setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Master log_errors_max_len setting.",
        SerializedName = @"masterLogErrorsMaxLength",
        PossibleTypes = new [] { typeof(string) })]
        string MasterLogErrorsMaxLength { get; set; }

    }
    /// Used for getting PHP error logging flag.
    internal partial interface ISitePhpErrorLogFlagInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Local log_errors setting.</summary>
        string LocalLogError { get; set; }
        /// <summary>Local log_errors_max_len setting.</summary>
        string LocalLogErrorsMaxLength { get; set; }
        /// <summary>Master log_errors setting.</summary>
        string MasterLogError { get; set; }
        /// <summary>Master log_errors_max_len setting.</summary>
        string MasterLogErrorsMaxLength { get; set; }
        /// <summary>SitePhpErrorLogFlag resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagProperties Property { get; set; }

    }
}