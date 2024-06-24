using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    public class ConfigReadEventArgs : ConfigEventArgs
    {
        public string ConfigTelemetryKey { get; }

        public ConfigReadEventArgs(string configKey, string configValue): this(configKey, configKey, configValue)
        {
        }

        public ConfigReadEventArgs(string configKey, string configTelemetryKey, string configValue): base(configKey, configValue)
        {
            ConfigTelemetryKey = configTelemetryKey;
        }
    }
}
