using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.PowerShell.Common.Config;

using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    internal abstract class ConfigManagerWithEventHandler : ConfigManager, IConfigManagerWithEventHandler
    {
        event EventHandler<ConfigEventArgs> _configEventHandler;

        public void ClearHandlers()
        {
            _configEventHandler = null;
        }

        public void RegisterHandler(EventHandler<ConfigEventArgs> handlerInitializer)
        {
            _configEventHandler += handlerInitializer;
        }

        public void UnregisterHandler(EventHandler<ConfigEventArgs> handlerInitializer)
        {
            _configEventHandler -= handlerInitializer;
        }

        protected void OnEvent(ConfigEventArgs e)
        {
            _configEventHandler?.Invoke(this, e);
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
                RaiseConfigReadedEvent(key, trackedDef.TelemetryKey, value?.ToString() ?? string.Empty);
            }
            return value;
        }

        private void RaiseConfigReadedEvent(string key, string telemetryKey, string value) => 
            OnEvent(new ConfigReadEventArgs(key, telemetryKey, value));
    }
}
