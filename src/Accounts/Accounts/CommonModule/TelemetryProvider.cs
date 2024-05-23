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
// ----------------------------------------------------------------------------------


using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Profile.CommonModule;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Sanitizer;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// Class providing telemetry usage based on the user's data collection settings
    /// </summary>
    public class TelemetryProvider : IDictionary<string, AzurePSQoSEvent>, IDisposable
    {
        const string SubscriptionIdString = "SubscriptionId";

        AzurePSDataCollectionProfile _dataCollectionProfile;
        MetricHelper _helper;
        Action<string> _warningLogger, _debugLogger;
        protected IDictionary<string, AzurePSQoSEvent> ProcessRecordEvents { get; } = new ConcurrentDictionary<string, AzurePSQoSEvent>(StringComparer.OrdinalIgnoreCase);

        public ICollection<string> Keys => ProcessRecordEvents.Keys;

        public ICollection<AzurePSQoSEvent> Values => ProcessRecordEvents.Values;

        public int Count => ProcessRecordEvents.Count;

        public bool IsReadOnly => false;

        public AzurePSQoSEvent this[string key] { get => ProcessRecordEvents[key]; set => ProcessRecordEvents[key] = value; }

        protected TelemetryProvider(AzurePSDataCollectionProfile profile, MetricHelper helper, Action<string> warningLogger, Action<string> debugLogger)
        {
            _dataCollectionProfile = profile;
            _helper = helper;
            _warningLogger = warningLogger;
            _debugLogger = debugLogger;
        }

        /// <summary>
        /// Create a Telemetry Provider using the given event listener
        /// </summary>
        /// <param name="listener">The event listenet</param>
        /// <returns>A telemetry provider that send data over the given event listener</returns>
        public static TelemetryProvider Create(IEventListener listener)
        {
            Func<string, Action<string>> messageLogger = ((messageType) => ( message) => listener.Signal(messageType, listener.Token, () => new EventData { Id = messageType, Message = message }));
            var warningLogger = messageLogger(Events.Warning);
            var debugLogger = messageLogger(Events.Debug);
            var profile = CreateDataCollectionProfile(warningLogger);
            var helper = CreateMetricHelper(profile);
            return new TelemetryProvider(profile, helper, warningLogger, debugLogger);
        }

        /// <summary>
        /// Factory method for TelemetryProvider
        /// </summary>
        /// <param name="warningLogger">A logger for warnign messages (conditionally used for data collection warning)</param>
        /// <param name="debugLogger">A logger for debugging traces</param>
        /// <returns></returns>
        public static TelemetryProvider Create(Action<string> warningLogger, Action<string> debugLogger)
        {
            var profile = CreateDataCollectionProfile(warningLogger);
            var helper = CreateMetricHelper(profile);
            return new TelemetryProvider(profile, helper, warningLogger, debugLogger);
        }

        /// <summary>
        /// Create a telemtry provider, using the given profile settings and event store
        /// </summary>
        /// <param name="collect">Whether ot not to collect data</param>
        /// <param name="store">The store for events generated during telemetry</param>
        /// <returns></returns>
        public static TelemetryProvider Create(bool collect, IEventStore store)
        {
            var profile = new AzurePSDataCollectionProfile(false);
            var helper = CreateMetricHelper(profile);
            return new TelemetryProvider(profile, helper, store.GetWarningLogger(), store.GetDebugLogger());
        }

        /// <summary>
        /// Log a telemetry event
        /// </summary>
        /// <param name="qosEventKey">The event to log</param>
        public virtual void LogEvent(string qosEventKey)
        {
            var dataCollection = _dataCollectionProfile.EnableAzureDataCollection;
            var enabled = dataCollection.HasValue ? dataCollection.Value : true;

            AzurePSQoSEvent qosEvent;
            if (this.TryGetValue(qosEventKey, out qosEvent))
            {
                qosEvent.FinishQosEvent();
                _helper.LogQoSEvent(qosEvent, enabled, enabled);
                _helper.FlushMetric();
                this.Remove(qosEventKey);
            }
        }

        /// <summary>
        /// Flush metrics
        /// </summary>
        public virtual void Flush()
        {
            _helper.FlushMetric();
        }

        /// <summary>
        /// Create a telmetry record
        /// </summary>
        /// <param name="invocationInfo"></param>
        /// <param name="parameterSetName"></param>
        /// <param name="correlationId"></param>
        /// <param name="processRecordId"></param>
        /// <returns></returns>
        public virtual AzurePSQoSEvent CreateQosEvent(InvocationInfo invocationInfo, string parameterSetName, string correlationId, string processRecordId)
        {
            var qosEvent = new AzurePSQoSEvent
            {
                CommandName = invocationInfo?.MyCommand?.Name,
                ModuleVersion = TrimModuleVersion(invocationInfo?.MyCommand?.Module?.Version),
                ModuleName = TrimModuleName(invocationInfo?.MyCommand?.ModuleName),
                SourceScript = invocationInfo?.ScriptName,
                ScriptLineNumber = invocationInfo?.ScriptLineNumber ?? 0,
                SessionId = MetricHelper.SessionId,
                ParameterSetName = parameterSetName,
                InvocationName = invocationInfo?.InvocationName,
                InputFromPipeline = invocationInfo?.PipelineLength > 0,
                UserAgent = AzurePSCmdlet.UserAgent,
                AzVersion = AzurePSCmdlet.AzVersion,
                AzAccountsVersion = AzurePSCmdlet.AzAccountsVersion,
                PSVersion = AzurePSCmdlet.PowerShellVersion,
                HostVersion = AzurePSCmdlet.PSHostVersion,
                PSHostName = AzurePSCmdlet.PSHostName,
            };

            if (invocationInfo != null)
            {
                qosEvent.Parameters = string.Join(" ",
                    invocationInfo.BoundParameters.Keys.Select(
                        s => string.Format(CultureInfo.InvariantCulture, "-{0} ***", s)));
            }

            IAzureContextContainer profile = AzureRmProfileProvider.Instance?.Profile;
            if(profile?.DefaultContext != null)
            {
                IAzureContext context = profile?.DefaultContext;
                qosEvent.SubscriptionId = context.Subscription?.Id;
                qosEvent.TenantId = context.Tenant?.Id;
                if (context.Account != null && !String.IsNullOrWhiteSpace(context.Account.Id))
                {
                    qosEvent.Uid = MetricHelper.GenerateSha256HashString(context.Account.Id.ToString());
                }
            }

            var showSecretsWarning = false;
            if (AzureSession.Instance.TryGetComponent<IOutputSanitizer>(nameof(IOutputSanitizer), out var outputSanitizer))
            {
                showSecretsWarning = outputSanitizer?.RequireSecretsDetection == true;
            }
            qosEvent.SanitizerInfo = new SanitizerTelemetry(showSecretsWarning);

            this[processRecordId] = qosEvent;
            return qosEvent;
        }

        private const string privateAssemblySuffix = ".private";
        private const string privateAssemblyPrefix = "Az.";
        private static readonly int privateAssemblyPrefixLength = privateAssemblyPrefix.Length;
        /// <summary>
        /// below is workaround that current invocationInfo only contains private module name. Trimming '.private' is a workaround for the time being.
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        internal static string TrimModuleName(string moduleName)
        {
            if (moduleName != null && moduleName.StartsWith(privateAssemblyPrefix) && moduleName.EndsWith(privateAssemblySuffix))
            {
                int splitter = moduleName.Substring(privateAssemblyPrefixLength).IndexOf('.');
                moduleName = moduleName.Substring(0, splitter + privateAssemblyPrefixLength);
            }
            return moduleName;

        }
        /// <summary>
        /// PowerShell module doesn't support revision. Trim it from sematic version.
        /// </summary>
        /// <param name="moduleVersion"></param>
        /// <returns></returns>
        internal static string TrimModuleVersion(Version moduleVersion)
        {
            if (moduleVersion == null)
                return "0.0.0";
            return $"{moduleVersion.Major}.{moduleVersion.Minor}.{moduleVersion.Build}";
        }

        private static MetricHelper CreateMetricHelper(AzurePSDataCollectionProfile profile)
        {
            var result = new MetricHelper(profile);
            result.AddDefaultTelemetryClient();
            return result;
        }

        private static AzurePSDataCollectionProfile CreateDataCollectionProfile(Action<string> warningLogger)
        {
            DataCollectionController controller;
            if (AzureSession.Instance.TryGetComponent(DataCollectionController.RegistryKey, out controller))
            {
                return controller.GetProfile(() => warningLogger(Resources.DataCollectionEnabledWarning));
            }

            warningLogger(Resources.DataCollectionEnabledWarning);
            return new AzurePSDataCollectionProfile();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                ProcessRecordEvents?.Clear();
            }
        }

        public void Add(string key, AzurePSQoSEvent value)
        {
            ProcessRecordEvents.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return ProcessRecordEvents.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return ProcessRecordEvents.Remove(key);
        }

        public bool TryGetValue(string key, out AzurePSQoSEvent value)
        {
            if(key != null)
            {
                return ProcessRecordEvents.TryGetValue(key, out value);
            }
            value = null;
            return false;
        }

        public void Add(KeyValuePair<string, AzurePSQoSEvent> item)
        {
            ProcessRecordEvents.Add(item);
        }

        public void Clear()
        {
            ProcessRecordEvents.Clear();
        }

        public bool Contains(KeyValuePair<string, AzurePSQoSEvent> item)
        {
            return ProcessRecordEvents.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, AzurePSQoSEvent>[] array, int arrayIndex)
        {
            ProcessRecordEvents.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, AzurePSQoSEvent> item)
        {
            return ProcessRecordEvents.Remove(item);
        }

        public IEnumerator<KeyValuePair<string, AzurePSQoSEvent>> GetEnumerator()
        {
            return ProcessRecordEvents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ProcessRecordEvents.GetEnumerator();
        }
    }
}
