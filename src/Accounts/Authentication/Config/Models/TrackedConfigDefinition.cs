using Microsoft.Azure.PowerShell.Common.Config;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    internal abstract class TrackedConfigDefinition : ConfigDefinition
    {
        /// <summary>
        /// Define the telemetry key for the config
        /// </summary>
        internal virtual string TelemetryKey => Key;

        internal virtual bool ShouldTrackedInTelemetry => false;
    }
}
