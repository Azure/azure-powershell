using Microsoft.Azure.PowerShell.Common.Config;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    internal abstract class ConfigDefinitionWithTelemetryInfo : ConfigDefinition
    {
        /// <summary>
        /// Define additional telemetry info for a config
        /// </summary>
        internal virtual string TelemetryKey => Key;

        internal virtual bool ShouldTrackedInTelemetry => false;
    }
}
