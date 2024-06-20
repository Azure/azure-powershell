using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;
using Microsoft.Azure.Commands.Shared.Config;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    public class ConfigEventArgs: EventArgs, IExtensibleModel
    {
        public string ConfigKey { get; }

        public string ConfigValue { get; }

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>();

        public ConfigEventArgs(string configKey, string configValue)
        {
            ConfigKey = configKey;
            ConfigValue = configValue;
        }
    }
}
