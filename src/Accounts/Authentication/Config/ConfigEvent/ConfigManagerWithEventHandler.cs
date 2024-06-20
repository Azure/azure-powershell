using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.PowerShell.Common.Config;

using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    internal abstract class ConfigManagerWithEventHandler : ConfigManager
    {
        event EventHandler<ConfigEventArgs> ConfigEventHandler;

        protected virtual void OnEvent(ConfigEventArgs e)
        {
            ConfigEventHandler?.Invoke(this, e);
        }

        internal override object GetConfigValueInternal(string key, InternalInvocationInfo invocation)
        {
            if (!_configDefinitionMap.TryGetValue(key, out ConfigDefinition definition) || definition == null)
            {
                throw new AzPSArgumentException($"Config with key [{key}] was not registered.", nameof(key));
            }

            var value = base.GetConfigValueInternal(key, invocation);
            if (definition is TrackedConfigDefinition trackedDef)
            {
                OnConfigReaded(key, trackedDef.TelemetryKey, value?.ToString() ?? string.Empty);
            }
            else
            {
                OnConfigReaded(key, key, value?.ToString() ?? string.Empty);
            }
            return value;
        }

        private void OnConfigReaded(string key, string telemetryKey, string value) => OnConfigReaded(new ConfigReadEventArgs(key, telemetryKey, value));

        private void OnConfigReaded(ConfigReadEventArgs args)
        {
            if (null != ConfigEventHandler)
            {
                ConfigEventHandler(this, args);
            }
        }
    }
}
