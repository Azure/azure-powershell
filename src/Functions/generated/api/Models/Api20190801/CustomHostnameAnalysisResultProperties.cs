namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>CustomHostnameAnalysisResult resource specific properties</summary>
    public partial class CustomHostnameAnalysisResultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ARecord" /> property.</summary>
        private string[] _aRecord;

        /// <summary>A records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] ARecord { get => this._aRecord; set => this._aRecord = value; }

        /// <summary>Backing field for <see cref="AlternateCNameRecord" /> property.</summary>
        private string[] _alternateCNameRecord;

        /// <summary>Alternate CName records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AlternateCNameRecord { get => this._alternateCNameRecord; set => this._alternateCNameRecord = value; }

        /// <summary>Backing field for <see cref="AlternateTxtRecord" /> property.</summary>
        private string[] _alternateTxtRecord;

        /// <summary>Alternate TXT records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AlternateTxtRecord { get => this._alternateTxtRecord; set => this._alternateTxtRecord = value; }

        /// <summary>Backing field for <see cref="CNameRecord" /> property.</summary>
        private string[] _cNameRecord;

        /// <summary>CName records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] CNameRecord { get => this._cNameRecord; set => this._cNameRecord = value; }

        /// <summary>Backing field for <see cref="ConflictingAppResourceId" /> property.</summary>
        private string _conflictingAppResourceId;

        /// <summary>Name of the conflicting app on scale unit if it's within the same subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ConflictingAppResourceId { get => this._conflictingAppResourceId; }

        /// <summary>Backing field for <see cref="CustomDomainVerificationFailureInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity _customDomainVerificationFailureInfo;

        /// <summary>Raw failure information if DNS verification fails.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity CustomDomainVerificationFailureInfo { get => (this._customDomainVerificationFailureInfo = this._customDomainVerificationFailureInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ErrorEntity()); }

        /// <summary>Basic error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomDomainVerificationFailureInfoCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).Code = value; }

        /// <summary>Type of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomDomainVerificationFailureInfoExtendedCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).ExtendedCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).ExtendedCode = value; }

        /// <summary>Inner errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] CustomDomainVerificationFailureInfoInnerError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).InnerError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).InnerError = value; }

        /// <summary>Any details of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomDomainVerificationFailureInfoMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).Message = value; }

        /// <summary>Message template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomDomainVerificationFailureInfoMessageTemplate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).MessageTemplate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).MessageTemplate = value; }

        /// <summary>Parameters for the template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] CustomDomainVerificationFailureInfoParameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).Parameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal)CustomDomainVerificationFailureInfo).Parameter = value; }

        /// <summary>Backing field for <see cref="CustomDomainVerificationTest" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult? _customDomainVerificationTest;

        /// <summary>DNS verification test result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult? CustomDomainVerificationTest { get => this._customDomainVerificationTest; }

        /// <summary>Backing field for <see cref="HasConflictAcrossSubscription" /> property.</summary>
        private bool? _hasConflictAcrossSubscription;

        /// <summary>
        /// <code>true</code> if there is a conflict across subscriptions; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? HasConflictAcrossSubscription { get => this._hasConflictAcrossSubscription; }

        /// <summary>Backing field for <see cref="HasConflictOnScaleUnit" /> property.</summary>
        private bool? _hasConflictOnScaleUnit;

        /// <summary>
        /// <code>true</code> if there is a conflict on a scale unit; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? HasConflictOnScaleUnit { get => this._hasConflictOnScaleUnit; }

        /// <summary>Backing field for <see cref="IsHostnameAlreadyVerified" /> property.</summary>
        private bool? _isHostnameAlreadyVerified;

        /// <summary>
        /// <code>true</code> if hostname is already verified; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsHostnameAlreadyVerified { get => this._isHostnameAlreadyVerified; }

        /// <summary>Internal Acessors for ConflictingAppResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal.ConflictingAppResourceId { get => this._conflictingAppResourceId; set { {_conflictingAppResourceId = value;} } }

        /// <summary>Internal Acessors for CustomDomainVerificationFailureInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal.CustomDomainVerificationFailureInfo { get => (this._customDomainVerificationFailureInfo = this._customDomainVerificationFailureInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ErrorEntity()); set { {_customDomainVerificationFailureInfo = value;} } }

        /// <summary>Internal Acessors for CustomDomainVerificationTest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DnsVerificationTestResult? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal.CustomDomainVerificationTest { get => this._customDomainVerificationTest; set { {_customDomainVerificationTest = value;} } }

        /// <summary>Internal Acessors for HasConflictAcrossSubscription</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal.HasConflictAcrossSubscription { get => this._hasConflictAcrossSubscription; set { {_hasConflictAcrossSubscription = value;} } }

        /// <summary>Internal Acessors for HasConflictOnScaleUnit</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal.HasConflictOnScaleUnit { get => this._hasConflictOnScaleUnit; set { {_hasConflictOnScaleUnit = value;} } }

        /// <summary>Internal Acessors for IsHostnameAlreadyVerified</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICustomHostnameAnalysisResultPropertiesInternal.IsHostnameAlreadyVerified { get => this._isHostnameAlreadyVerified; set { {_isHostnameAlreadyVerified = value;} } }

        /// <summary>Backing field for <see cref="TxtRecord" /> property.</summary>
        private string[] _txtRecord;

        /// <summary>TXT records controller can see for this hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] TxtRecord { get => this._txtRecord; set => this._txtRecord = value; }

        /// <summary>Creates an new <see cref="CustomHostnameAnalysisResultProperties" /> instance.</summary>
        public CustomHostnameAnalysisResultProperties()
        {

        }
    }
    /// CustomHostnameAnalysisResult resource specific properties
    public partial interface ICustomHostnameAnalysisResultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
    /// CustomHostnameAnalysisResult resource specific properties
    internal partial interface ICustomHostnameAnalysisResultPropertiesInternal

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
        /// <summary>TXT records controller can see for this hostname.</summary>
        string[] TxtRecord { get; set; }

    }
}