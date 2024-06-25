using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.PowerShell.Common.Config;

using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    internal abstract class ConfigManagerWithEvents : ConfigManager, IConfigManagerWithEvents
    {
        // Event handlers
        private EventHandler<ConfigEventArgs> _onConfigReadedHandler;
        private EventHandler<ConfigEventArgs> _onConfigUpdatedHandler;
        private EventHandler<ConfigEventArgs> _onConfigClearedHandler;

        public event EventHandler<ConfigEventArgs> ConfigReaded
        {
            add
            {
                _onConfigReadedHandler += value;
            }
            remove
            {
                _onConfigReadedHandler -= value;
            }

        }

        public event EventHandler<ConfigEventArgs> ConfigUpdated
        {
            add
            {
                _onConfigUpdatedHandler += value;
            }
            remove
            {
                _onConfigUpdatedHandler -= value;
            }

        }

        public event EventHandler<ConfigEventArgs> ConfigCleared
        {
            add
            {
                _onConfigClearedHandler += value;
            }
            remove
            {
                _onConfigClearedHandler -= value;
            }
        }

        private void InvokeOn(ConfigEventArgs e, EventHandler<ConfigEventArgs> handler)
        {
            handler?.Invoke(this, e);
        }

        internal override object GetConfigValueInternal(string key, InternalInvocationInfo invocation)
        {
            if (!_configDefinitionMap.TryGetValue(key, out ConfigDefinition definition) || definition == null)
            {
                throw new AzPSArgumentException($"Config with key [{key}] was not registered.", nameof(key));
            }

            var value = base.GetConfigValueInternal(key, invocation);
            if (definition is TrackedConfigDefinition trackedDef && trackedDef.ShouldTrackedInTelemetry)
            {
                OnConfigReaded(key, trackedDef.TelemetryKey, value?.ToString() ?? string.Empty);
            }
            return value;
        }

        private void OnConfigReaded(string key, string telemetryKey, string value) =>
            InvokeOn(new ConfigReadEventArgs(key, telemetryKey, value), _onConfigReadedHandler);
    }
}
