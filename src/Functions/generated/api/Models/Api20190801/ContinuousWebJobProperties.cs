namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ContinuousWebJob resource specific properties</summary>
    public partial class ContinuousWebJobProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DetailedStatus" /> property.</summary>
        private string _detailedStatus;

        /// <summary>Detailed status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DetailedStatus { get => this._detailedStatus; set => this._detailedStatus = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private string _error;

        /// <summary>Error information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Error { get => this._error; set => this._error = value; }

        /// <summary>Backing field for <see cref="ExtraInfoUrl" /> property.</summary>
        private string _extraInfoUrl;

        /// <summary>Extra Info URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ExtraInfoUrl { get => this._extraInfoUrl; set => this._extraInfoUrl = value; }

        /// <summary>Backing field for <see cref="LogUrl" /> property.</summary>
        private string _logUrl;

        /// <summary>Log URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LogUrl { get => this._logUrl; set => this._logUrl = value; }

        /// <summary>Backing field for <see cref="RunCommand" /> property.</summary>
        private string _runCommand;

        /// <summary>Run command.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RunCommand { get => this._runCommand; set => this._runCommand = value; }

        /// <summary>Backing field for <see cref="Setting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesSettings _setting;

        /// <summary>Job settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesSettings Setting { get => (this._setting = this._setting ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContinuousWebJobPropertiesSettings()); set => this._setting = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ContinuousWebJobStatus? _status;

        /// <summary>Job status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ContinuousWebJobStatus? Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>Job URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Backing field for <see cref="UsingSdk" /> property.</summary>
        private bool? _usingSdk;

        /// <summary>Using SDK?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? UsingSdk { get => this._usingSdk; set => this._usingSdk = value; }

        /// <summary>Backing field for <see cref="WebJobType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? _webJobType;

        /// <summary>Job type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? WebJobType { get => this._webJobType; set => this._webJobType = value; }

        /// <summary>Creates an new <see cref="ContinuousWebJobProperties" /> instance.</summary>
        public ContinuousWebJobProperties()
        {

        }
    }
    /// ContinuousWebJob resource specific properties
    public partial interface IContinuousWebJobProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
    /// ContinuousWebJob resource specific properties
    internal partial interface IContinuousWebJobPropertiesInternal

    {
        /// <summary>Detailed status.</summary>
        string DetailedStatus { get; set; }
        /// <summary>Error information.</summary>
        string Error { get; set; }
        /// <summary>Extra Info URL.</summary>
        string ExtraInfoUrl { get; set; }
        /// <summary>Log URL.</summary>
        string LogUrl { get; set; }
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