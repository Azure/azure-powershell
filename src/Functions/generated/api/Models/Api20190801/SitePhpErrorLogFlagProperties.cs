namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SitePhpErrorLogFlag resource specific properties</summary>
    public partial class SitePhpErrorLogFlagProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePhpErrorLogFlagPropertiesInternal
    {

        /// <summary>Backing field for <see cref="LocalLogError" /> property.</summary>
        private string _localLogError;

        /// <summary>Local log_errors setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LocalLogError { get => this._localLogError; set => this._localLogError = value; }

        /// <summary>Backing field for <see cref="LocalLogErrorsMaxLength" /> property.</summary>
        private string _localLogErrorsMaxLength;

        /// <summary>Local log_errors_max_len setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LocalLogErrorsMaxLength { get => this._localLogErrorsMaxLength; set => this._localLogErrorsMaxLength = value; }

        /// <summary>Backing field for <see cref="MasterLogError" /> property.</summary>
        private string _masterLogError;

        /// <summary>Master log_errors setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MasterLogError { get => this._masterLogError; set => this._masterLogError = value; }

        /// <summary>Backing field for <see cref="MasterLogErrorsMaxLength" /> property.</summary>
        private string _masterLogErrorsMaxLength;

        /// <summary>Master log_errors_max_len setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MasterLogErrorsMaxLength { get => this._masterLogErrorsMaxLength; set => this._masterLogErrorsMaxLength = value; }

        /// <summary>Creates an new <see cref="SitePhpErrorLogFlagProperties" /> instance.</summary>
        public SitePhpErrorLogFlagProperties()
        {

        }
    }
    /// SitePhpErrorLogFlag resource specific properties
    public partial interface ISitePhpErrorLogFlagProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
    /// SitePhpErrorLogFlag resource specific properties
    internal partial interface ISitePhpErrorLogFlagPropertiesInternal

    {
        /// <summary>Local log_errors setting.</summary>
        string LocalLogError { get; set; }
        /// <summary>Local log_errors_max_len setting.</summary>
        string LocalLogErrorsMaxLength { get; set; }
        /// <summary>Master log_errors setting.</summary>
        string MasterLogError { get; set; }
        /// <summary>Master log_errors_max_len setting.</summary>
        string MasterLogErrorsMaxLength { get; set; }

    }
}