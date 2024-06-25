// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// -------------------------------------

using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;
using Microsoft.Azure.PowerShell.Common.Config;

using System;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    /// <summary>
    /// Abstract implementation of <see cref="IConfigManagerWithEvents"/>, 
    /// Providing the read ability to the configs 
    /// and allowing to binding events.
    /// </summary>
    internal abstract class ConfigManagerWithEvents : ConfigManager, IConfigManagerWithEvents
    {
        // Event handlers
        private EventHandler<ConfigEventArgs> _onConfigReadHandler;
        private EventHandler<ConfigEventArgs> _onConfigUpdatedHandler;
        private EventHandler<ConfigEventArgs> _onConfigClearedHandler;

        public event EventHandler<ConfigEventArgs> ConfigRead
        {
            add
            {
                _onConfigReadHandler += value;
            }
            remove
            {
                _onConfigReadHandler -= value;
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

        private void RaiseConfigReadEvent(string key, object value)
        {
            if (_onConfigReadHandler != null &&
                _configDefinitionMap.TryGetValue(key, out ConfigDefinition definition) &&
                null != definition &&
                definition is ConfigDefinitionWithTelemetryInfo defWithTelemetryInfo &&
                defWithTelemetryInfo.ShouldTrackedInTelemetry)
            {
                OnConfigRead(key, defWithTelemetryInfo.TelemetryKey, value?.ToString() ?? string.Empty);
            }
        }

        private void OnConfigRead(string key, string telemetryKey, string value) =>
            InvokeOn(new ConfigReadEventArgs(key, telemetryKey, value), _onConfigReadHandler);


        internal override object GetConfigValueInternal(string key, InternalInvocationInfo invocation)
        {
            var value = base.GetConfigValueInternal(key, invocation);
            RaiseConfigReadEvent(key, value);
            return value;
        }
    }
}
