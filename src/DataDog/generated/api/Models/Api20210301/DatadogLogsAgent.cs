namespace Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.Extensions;

    public partial class DatadogLogsAgent :
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301.IDatadogLogsAgent,
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301.IDatadogLogsAgentInternal
    {

        /// <summary>Backing field for <see cref="Transport" /> property.</summary>
        private string _transport;

        /// <summary>The transport.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataDog.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataDog.PropertyOrigin.Owned)]
        public string Transport { get => this._transport; set => this._transport = value; }

        /// <summary>Creates an new <see cref="DatadogLogsAgent" /> instance.</summary>
        public DatadogLogsAgent()
        {

        }
    }
    public partial interface IDatadogLogsAgent :
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.IJsonSerializable
    {
        /// <summary>The transport.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The transport.",
        SerializedName = @"transport",
        PossibleTypes = new [] { typeof(string) })]
        string Transport { get; set; }

    }
    internal partial interface IDatadogLogsAgentInternal

    {
        /// <summary>The transport.</summary>
        string Transport { get; set; }

    }
}