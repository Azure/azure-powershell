namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Custom domain analysis.</summary>
    public partial class CustomHostnameAnalysisResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResult,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>A records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] ARecord { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).ARecord; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).ARecord = value; }

        /// <summary>Alternate CName records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] AlternateCNameRecord { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).AlternateCNameRecord; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).AlternateCNameRecord = value; }

        /// <summary>Alternate TXT records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] AlternateTxtRecord { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).AlternateTxtRecord; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).AlternateTxtRecord = value; }

        /// <summary>CName records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] CNameRecord { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CNameRecord; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CNameRecord = value; }

        /// <summary>Name of the conflicting app on scale unit if it's within the same subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ConflictingAppResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).ConflictingAppResourceId; }

        /// <summary>Basic error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomDomainVerificationFailureInfoCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoCode = value; }

        /// <summary>Type of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomDomainVerificationFailureInfoExtendedCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoExtendedCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoExtendedCode = value; }

        /// <summary>Inner errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] CustomDomainVerificationFailureInfoInnerError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoInnerError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoInnerError = value; }

        /// <summary>Any details of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomDomainVerificationFailureInfoMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoMessage = value; }

        /// <summary>Message template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomDomainVerificationFailureInfoMessageTemplate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoMessageTemplate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoMessageTemplate = value; }

        /// <summary>Parameters for the template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] CustomDomainVerificationFailureInfoParameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoParameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfoParameter = value; }

        /// <summary>DNS verification test result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult? CustomDomainVerificationTest { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationTest; }

        /// <summary>
        /// <code>true</code> if there is a conflict across subscriptions; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? HasConflictAcrossSubscription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).HasConflictAcrossSubscription; }

        /// <summary>
        /// <code>true</code> if there is a conflict on a scale unit; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? HasConflictOnScaleUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).HasConflictOnScaleUnit; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>
        /// <code>true</code> if hostname is already verified; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsHostnameAlreadyVerified { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).IsHostnameAlreadyVerified; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for ConflictingAppResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal.ConflictingAppResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).ConflictingAppResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).ConflictingAppResourceId = value; }

        /// <summary>Internal Acessors for CustomDomainVerificationFailureInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal.CustomDomainVerificationFailureInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationFailureInfo = value; }

        /// <summary>Internal Acessors for CustomDomainVerificationTest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal.CustomDomainVerificationTest { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationTest; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).CustomDomainVerificationTest = value; }

        /// <summary>Internal Acessors for HasConflictAcrossSubscription</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal.HasConflictAcrossSubscription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).HasConflictAcrossSubscription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).HasConflictAcrossSubscription = value; }

        /// <summary>Internal Acessors for HasConflictOnScaleUnit</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal.HasConflictOnScaleUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).HasConflictOnScaleUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).HasConflictOnScaleUnit = value; }

        /// <summary>Internal Acessors for IsHostnameAlreadyVerified</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal.IsHostnameAlreadyVerified { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).IsHostnameAlreadyVerified; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).IsHostnameAlreadyVerified = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResultProperties()); set { {_property = value;} } }

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
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties _property;

        /// <summary>CustomHostnameAnalysisResult resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CustomHostnameAnalysisResultProperties()); set => this._property = value; }

        /// <summary>TXT records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] TxtRecord { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).TxtRecord; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal)Property).TxtRecord = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="CustomHostnameAnalysisResult" /> instance.</summary>
        public CustomHostnameAnalysisResult()
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
    /// Custom domain analysis.
    public partial interface ICustomHostnameAnalysisResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>A records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A records controller can see for this hostname.",
        SerializedName = @"aRecords",
        PossibleTypes = new [] { typeof(string) })]
        string[] ARecord { get; set; }
        /// <summary>Alternate CName records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Alternate CName records controller can see for this hostname.",
        SerializedName = @"alternateCNameRecords",
        PossibleTypes = new [] { typeof(string) })]
        string[] AlternateCNameRecord { get; set; }
        /// <summary>Alternate TXT records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Alternate TXT records controller can see for this hostname.",
        SerializedName = @"alternateTxtRecords",
        PossibleTypes = new [] { typeof(string) })]
        string[] AlternateTxtRecord { get; set; }
        /// <summary>CName records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"CName records controller can see for this hostname.",
        SerializedName = @"cNameRecords",
        PossibleTypes = new [] { typeof(string) })]
        string[] CNameRecord { get; set; }
        /// <summary>Name of the conflicting app on scale unit if it's within the same subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the conflicting app on scale unit if it's within the same subscription.",
        SerializedName = @"conflictingAppResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ConflictingAppResourceId { get;  }
        /// <summary>Basic error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Basic error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string CustomDomainVerificationFailureInfoCode { get; set; }
        /// <summary>Type of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of error.",
        SerializedName = @"extendedCode",
        PossibleTypes = new [] { typeof(string) })]
        string CustomDomainVerificationFailureInfoExtendedCode { get; set; }
        /// <summary>Inner errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Inner errors.",
        SerializedName = @"innerErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] CustomDomainVerificationFailureInfoInnerError { get; set; }
        /// <summary>Any details of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Any details of the error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string CustomDomainVerificationFailureInfoMessage { get; set; }
        /// <summary>Message template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Message template.",
        SerializedName = @"messageTemplate",
        PossibleTypes = new [] { typeof(string) })]
        string CustomDomainVerificationFailureInfoMessageTemplate { get; set; }
        /// <summary>Parameters for the template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Parameters for the template.",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(string) })]
        string[] CustomDomainVerificationFailureInfoParameter { get; set; }
        /// <summary>DNS verification test result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"DNS verification test result.",
        SerializedName = @"customDomainVerificationTest",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult? CustomDomainVerificationTest { get;  }
        /// <summary>
        /// <code>true</code> if there is a conflict across subscriptions; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"<code>true</code> if there is a conflict across subscriptions; otherwise, <code>false</code>.",
        SerializedName = @"hasConflictAcrossSubscription",
        PossibleTypes = new [] { typeof(bool) })]
        bool? HasConflictAcrossSubscription { get;  }
        /// <summary>
        /// <code>true</code> if there is a conflict on a scale unit; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"<code>true</code> if there is a conflict on a scale unit; otherwise, <code>false</code>.",
        SerializedName = @"hasConflictOnScaleUnit",
        PossibleTypes = new [] { typeof(bool) })]
        bool? HasConflictOnScaleUnit { get;  }
        /// <summary>
        /// <code>true</code> if hostname is already verified; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"<code>true</code> if hostname is already verified; otherwise, <code>false</code>.",
        SerializedName = @"isHostnameAlreadyVerified",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsHostnameAlreadyVerified { get;  }
        /// <summary>TXT records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"TXT records controller can see for this hostname.",
        SerializedName = @"txtRecords",
        PossibleTypes = new [] { typeof(string) })]
        string[] TxtRecord { get; set; }

    }
    /// Custom domain analysis.
    internal partial interface ICustomHostnameAnalysisResultInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>A records controller can see for this hostname.</summary>
        string[] ARecord { get; set; }
        /// <summary>Alternate CName records controller can see for this hostname.</summary>
        string[] AlternateCNameRecord { get; set; }
        /// <summary>Alternate TXT records controller can see for this hostname.</summary>
        string[] AlternateTxtRecord { get; set; }
        /// <summary>CName records controller can see for this hostname.</summary>
        string[] CNameRecord { get; set; }
        /// <summary>Name of the conflicting app on scale unit if it's within the same subscription.</summary>
        string ConflictingAppResourceId { get; set; }
        /// <summary>Raw failure information if DNS verification fails.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity CustomDomainVerificationFailureInfo { get; set; }
        /// <summary>Basic error code.</summary>
        string CustomDomainVerificationFailureInfoCode { get; set; }
        /// <summary>Type of error.</summary>
        string CustomDomainVerificationFailureInfoExtendedCode { get; set; }
        /// <summary>Inner errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] CustomDomainVerificationFailureInfoInnerError { get; set; }
        /// <summary>Any details of the error.</summary>
        string CustomDomainVerificationFailureInfoMessage { get; set; }
        /// <summary>Message template.</summary>
        string CustomDomainVerificationFailureInfoMessageTemplate { get; set; }
        /// <summary>Parameters for the template.</summary>
        string[] CustomDomainVerificationFailureInfoParameter { get; set; }
        /// <summary>DNS verification test result.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult? CustomDomainVerificationTest { get; set; }
        /// <summary>
        /// <code>true</code> if there is a conflict across subscriptions; otherwise, <code>false</code>.
        /// </summary>
        bool? HasConflictAcrossSubscription { get; set; }
        /// <summary>
        /// <code>true</code> if there is a conflict on a scale unit; otherwise, <code>false</code>.
        /// </summary>
        bool? HasConflictOnScaleUnit { get; set; }
        /// <summary>
        /// <code>true</code> if hostname is already verified; otherwise, <code>false</code>.
        /// </summary>
        bool? IsHostnameAlreadyVerified { get; set; }
        /// <summary>CustomHostnameAnalysisResult resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties Property { get; set; }
        /// <summary>TXT records controller can see for this hostname.</summary>
        string[] TxtRecord { get; set; }

    }
}