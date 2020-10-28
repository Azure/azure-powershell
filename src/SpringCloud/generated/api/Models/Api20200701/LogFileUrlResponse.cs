namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Log file URL payload</summary>
    public partial class LogFileUrlResponse :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ILogFileUrlResponse,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ILogFileUrlResponseInternal
    {

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>URL of the log file</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Creates an new <see cref="LogFileUrlResponse" /> instance.</summary>
        public LogFileUrlResponse()
        {

        }
    }
    /// Log file URL payload
    public partial interface ILogFileUrlResponse :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>URL of the log file</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"URL of the log file",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }

    }
    /// Log file URL payload
    public partial interface ILogFileUrlResponseInternal

    {
        /// <summary>URL of the log file</summary>
        string Url { get; set; }

    }
}