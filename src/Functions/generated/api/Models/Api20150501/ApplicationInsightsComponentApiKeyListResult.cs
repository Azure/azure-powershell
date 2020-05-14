namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Describes the list of API Keys of an Application Insights Component.</summary>
    public partial class ApplicationInsightsComponentApiKeyListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKeyListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKey[] _value;

        /// <summary>List of API Key definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKey[] Value { get => this._value; set => this._value = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationInsightsComponentApiKeyListResult" /> instance.
        /// </summary>
        public ApplicationInsightsComponentApiKeyListResult()
        {

        }
    }
    /// Describes the list of API Keys of an Application Insights Component.
    public partial interface IApplicationInsightsComponentApiKeyListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List of API Key definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"List of API Key definitions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKey) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKey[] Value { get; set; }

    }
    /// Describes the list of API Keys of an Application Insights Component.
    internal partial interface IApplicationInsightsComponentApiKeyListResultInternal

    {
        /// <summary>List of API Key definitions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentApiKey[] Value { get; set; }

    }
}