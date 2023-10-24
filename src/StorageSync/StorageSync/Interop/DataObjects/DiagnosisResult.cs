// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosisResult.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.DataObjects
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Enum for result of diagnosing the issue on the server
    /// </summary>
    public enum DiagnosisErrorType
    {
        // No problem detected
        None,

        // Diagnosis failed with an exception
        Fail,

        // Certificate Error Codes
        CertificatePrivateKeyMissing,
        CertificateNotFound,
        CertificateExpired,

        // Compressed SVI Error Codes
        CompressedSviDetected,

        // Event Logs Error Codes
        EventLogsCorrupted,

        // Server Time Error Codes
        ServerTimeIncorrect,
    }

    /// <summary>
    /// Enum for whether the plugin
    /// a) succeeded (either no problem detected or a problem was detected successfully)
    /// b) failed with an unhandled exception
    /// </summary>
    public enum PluginStatus
    {
        Succeeded,
        Failed,
    }

    /// <summary>
    /// Diagnosis result object to encapsulate the error and plugin name
    /// </summary>
    public class DiagnosisResult
    {
        [JsonProperty(PropertyName = "pluginName")]
        public string PluginName { get; set; }

        [JsonProperty(PropertyName = "result")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DiagnosisErrorType Result { get; set; }

        [JsonProperty(PropertyName = "resultDetails")]
        public string ResultDetails { get; set; }
    }
}

