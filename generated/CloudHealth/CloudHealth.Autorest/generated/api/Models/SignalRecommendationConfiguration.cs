// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Extensions;

    /// <summary>Kind-specific signal recommendation configuration.</summary>
    public partial class SignalRecommendationConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalRecommendationConfigurationInternal
    {

        /// <summary>Backing field for <see cref="SignalKind" /> property.</summary>
        private string _signalKind;

        /// <summary>Kind of the recommended signal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string SignalKind { get => this._signalKind; set => this._signalKind = value; }

        /// <summary>Creates an new <see cref="SignalRecommendationConfiguration" /> instance.</summary>
        public SignalRecommendationConfiguration()
        {

        }
    }
    /// Kind-specific signal recommendation configuration.
    public partial interface ISignalRecommendationConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IJsonSerializable
    {
        /// <summary>Kind of the recommended signal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Kind of the recommended signal.",
        SerializedName = @"signalKind",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("AzureResourceMetric", "LogAnalyticsQuery", "PrometheusMetricsQuery")]
        string SignalKind { get; set; }

    }
    /// Kind-specific signal recommendation configuration.
    internal partial interface ISignalRecommendationConfigurationInternal

    {
        /// <summary>Kind of the recommended signal.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("AzureResourceMetric", "LogAnalyticsQuery", "PrometheusMetricsQuery")]
        string SignalKind { get; set; }

    }
}