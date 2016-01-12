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

using Microsoft.Azure.Commands.Utilities.Common;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.DataContracts;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common
{
    public static class MetricHelper
    {
        private const int FlushTimeoutInMilli = 5000;

        /// <summary>
        /// The collection of telemetry clients.
        /// </summary>
        private static readonly List<TelemetryClient> _telemetryClients =
            new List<TelemetryClient>();

        /// <summary>
        /// A read-only, thread-safe collection of telemetry clients.  Since
        /// List is only thread-safe for reads (and adding/removing tracing
        /// interceptors isn't a very common operation), we simply replace the
        /// entire collection of interceptors so any enumeration of the list
        /// in progress on a different thread will not be affected by the
        /// change.
        /// </summary>
        private static List<TelemetryClient> _threadSafeTelemetryClients =
            new List<TelemetryClient>();

        /// <summary>
        /// Lock used to synchronize mutation of the tracing interceptors.
        /// </summary>
        private static readonly object _lock = new object();

        static MetricHelper()
        {
            if (TestMockSupport.RunningMocked)
            {
                TelemetryConfiguration.Active.DisableTelemetry = true;
            }
        }

        /// <summary>
        /// Gets a sequence of the telemetry clients to notify of changes.
        /// </summary>
        internal static IEnumerable<TelemetryClient> TelemetryClients
        {
            get { return _threadSafeTelemetryClients; }
        }

        /// <summary>
        /// Add a telemetry client.
        /// </summary>
        /// <param name="client">The telemetry client.</param>
        public static void AddTelemetryClient(TelemetryClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            lock (_lock)
            {
                // TODO: Investigate whether this needs to be disabled
                client.Context.Location.Ip = "0.0.0.0";
                _telemetryClients.Add(client);
                _threadSafeTelemetryClients = new List<TelemetryClient>(_telemetryClients);
            }
        }

        public static void LogQoSEvent(AzurePSQoSEvent qos, bool isUsageMetricEnabled, bool isErrorMetricEnabled)
        {
            if (!IsMetricTermAccepted())
            {
                return;
            }

            if (isUsageMetricEnabled)
            {
                LogUsageEvent(qos);
            }

            if (isErrorMetricEnabled && qos.Exception != null)
            {
                LogExceptionEvent(qos);
            }
        }

        private static void LogUsageEvent(AzurePSQoSEvent qos)
        {
            Dictionary<string, double> eventMetrics = new Dictionary<string, double>();
            eventMetrics.Add("Duration", qos.Duration.TotalMilliseconds);
            Dictionary<string, string> eventProperties = GetPropertiesFromQos(qos);

            foreach (TelemetryClient client in TelemetryClients)
            {
                LoadTelemetryClientContext(qos, client);
                client.TrackEvent(qos.CommandName, eventProperties, eventMetrics);
            }
        }
        private static void LogExceptionEvent(AzurePSQoSEvent qos)
        {
            Dictionary<string, double> eventMetrics = new Dictionary<string, double>();
            eventMetrics.Add("Duration", qos.Duration.TotalMilliseconds);
            Dictionary<string, string> eventProperties = GetPropertiesFromQos(qos);

            foreach (TelemetryClient client in TelemetryClients)
            {
                LoadTelemetryClientContext(qos, client);
                client.TrackException(qos.Exception, eventProperties, eventMetrics);
            }
        }

        private static void LoadTelemetryClientContext(AzurePSQoSEvent qos, TelemetryClient client)
        {
            client.Context.User.Id = qos.Uid;
            client.Context.Session.Id = qos.ClientRequestId;
            client.Context.User.AuthenticatedUserId = qos.Uid;
            if (CLU.CLUEnvironment.Platform.IsMacOSX)
            {
                client.Context.Device.OperatingSystem = "MacOS";
            }
            else if (CLU.CLUEnvironment.Platform.IsUnix)
            {
                client.Context.Device.OperatingSystem = "Unix";
            }
            else
            {
                client.Context.Device.OperatingSystem = "Windows";
            }
        }

        private static Dictionary<string, string> GetPropertiesFromQos(AzurePSQoSEvent qos)
        {
            Dictionary<string, string> eventProperties = new Dictionary<string, string>();
            eventProperties.Add("IsSuccess", qos.IsSuccess.ToString());
            eventProperties.Add("ModuleName", qos.ModuleName);
            eventProperties.Add("ModuleVersion", qos.ModuleVersion);
            eventProperties.Add("HostVersion", qos.HostVersion);
            if (CLU.CLUEnvironment.Platform.IsMacOSX)
            {
                eventProperties.Add("OS", "MacOS");
            }
            else if (CLU.CLUEnvironment.Platform.IsUnix)
            {
                eventProperties.Add("OS", "Unix");
            }
            else
            {
                eventProperties.Add("OS", "Windows");
            }
            eventProperties.Add("CommandParameters", qos.Parameters);
            eventProperties.Add("UserId", qos.Uid);
            eventProperties.Add("x-ms-client-request-id", qos.ClientRequestId);
            eventProperties.Add("UserAgent", AzurePowerShell.UserAgentValue.ToString());
            if (qos.InputFromPipeline != null)
            {
                eventProperties.Add("InputFromPipeline", qos.InputFromPipeline.Value.ToString());
            }
            if (qos.OutputToPipeline != null)
            {
                eventProperties.Add("OutputToPipeline", qos.OutputToPipeline.Value.ToString());
            }
            foreach(var key in qos.CustomProperties.Keys)
            {
                eventProperties[key] = qos.CustomProperties[key];
            }
            return eventProperties;
        }

        public static bool IsMetricTermAccepted()
        {
            return AzurePSCmdlet.IsDataCollectionAllowed();
        }

        public static void FlushMetric(bool waitForMetricSending)
        {
            if (!IsMetricTermAccepted())
            {
                return;
            }

            var flushTask = Task.Run(() => FlushAi());
            if (waitForMetricSending)
            {
                Task.WaitAll(new[] { flushTask }, FlushTimeoutInMilli);
            }
        }

        private static void FlushAi()
        {
            try
            {
                foreach (TelemetryClient client in TelemetryClients)
                {
                    client.Flush();
                }
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// Gereate a SHA256 Hash string from the originInput.
        /// </summary>
        /// <param name="originInput"></param>
        /// <returns></returns>
        public static string GenerateSha256HashString(string originInput)
        {
            SHA256 sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(originInput));
            return BitConverter.ToString(bytes);
        }
    }
}

public class AzurePSQoSEvent
{
    private readonly Stopwatch _timer;

    public DateTimeOffset StartTime { get; set; }
    public TimeSpan Duration { get; set; }
    public bool IsSuccess { get; set; }
    public string CommandName { get; set; }
    public string ModuleName { get; set; }
    public string ModuleVersion { get; set; }
    public string HostVersion { get; set; }
    public string Parameters { get; set; }
    public bool? InputFromPipeline { get; set; }
    public bool? OutputToPipeline { get; set; }
    public Exception Exception { get; set; }
    public string Uid { get; set; }
    public string ClientRequestId { get; set; }
    public Dictionary<string, string> CustomProperties { get; private set; }

    public AzurePSQoSEvent()
    {
        StartTime = DateTimeOffset.Now;
        _timer = new Stopwatch();
        _timer.Start();
        CustomProperties = new Dictionary<string, string>();
    }

    public void PauseQoSTimer()
    {
        _timer.Stop();
    }

    public void ResumeQosTimer()
    {
        _timer.Start();
    }

    public void FinishQosEvent()
    {
        _timer.Stop();
        Duration = _timer.Elapsed;
    }

    public override string ToString()
    {
        return string.Format(
            "AzureQoSEvent: CommandName - {0}; IsSuccess - {1}; Duration - {2}; Exception - {3};",
            CommandName, IsSuccess, Duration, Exception);
    }
}

