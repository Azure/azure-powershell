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

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.Utilities;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation.Host;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public class MetricHelper
    {
        protected INetworkHelper _networkHelper;
        private const int FlushTimeoutInMilli = 5000;
        private const string DefaultPSVersion = "3.0.0.0";
        private const string EventName = "cmdletInvocation";

        /// <summary>
        /// The collection of telemetry clients.
        /// </summary>
        private readonly List<TelemetryClient> _telemetryClients =
            new List<TelemetryClient>();

        /// <summary>
        /// A read-only, thread-safe collection of telemetry clients.  Since
        /// List is only thread-safe for reads (and adding/removing tracing
        /// interceptors isn't a very common operation), we simply replace the
        /// entire collection of interceptors so any enumeration of the list
        /// in progress on a different thread will not be affected by the
        /// change.
        /// </summary>
        private List<TelemetryClient> _threadSafeTelemetryClients =
            new List<TelemetryClient>();

        /// <summary>
        /// Lock used to synchronize mutation of the tracing interceptors.
        /// </summary>
        private readonly object _lock = new object();

        private string _hashMacAddress = string.Empty;

        private AzurePSDataCollectionProfile _profile;

        private static PSHost _host;

        private static string _psVersion;

        protected string PSVersion
        {
            get
            {
                if (_host != null)
                {
                    _psVersion = _host.Version.ToString();
                }
                else
                {
                    _psVersion = DefaultPSVersion;
                }
                return _psVersion;
            }
        }

        public string HashMacAddress
        {
            get
            {
                lock(_lock)
                {
                    if (_hashMacAddress == string.Empty)
                    {
                       _hashMacAddress = null;

                        try
                        {
                            var macAddress = _networkHelper.GetMACAddress();
                            _hashMacAddress = string.IsNullOrWhiteSpace(macAddress) 
                                ? null : GenerateSha256HashString(macAddress)?.Replace("-", string.Empty)?.ToLowerInvariant();
                        }
                        catch
                        {
                            // ignore exceptions in getting the network address
                        }
                    }

                    return _hashMacAddress;
                }
            }

            // Add test hook to reset
            set { lock(_lock) { _hashMacAddress = value; } }
        }

        public MetricHelper(AzurePSDataCollectionProfile profile) : this(new NetworkHelper())
        {
            _profile = profile;
        }

        public MetricHelper(INetworkHelper network)
        {
            _networkHelper = network;
#if DEBUG
            if (TestMockSupport.RunningMocked)
            {
                TelemetryConfiguration.Active.DisableTelemetry = true;
            }
#endif
        }

        /// <summary>
        /// Gets a sequence of the telemetry clients to notify of changes.
        /// </summary>
        internal IEnumerable<TelemetryClient> TelemetryClients
        {
            get { return _threadSafeTelemetryClients; }
        }

        /// <summary>
        /// Add a telemetry client.
        /// </summary>
        /// <param name="client">The telemetry client.</param>
        public void AddTelemetryClient(TelemetryClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            lock (_lock)
            {
                // TODO: Investigate whether this needs to be disabled
                client.Context.Location.Ip = "0.0.0.0";
                _telemetryClients.Add(client);
                _threadSafeTelemetryClients = new List<TelemetryClient>(_telemetryClients);
            }
        }

        public void LogQoSEvent(AzurePSQoSEvent qos, bool isUsageMetricEnabled, bool isErrorMetricEnabled)
        {
            if (qos == null || !IsMetricTermAccepted())
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

        public void LogCustomEvent<T>(string eventName, T payload, bool force = false)
        {
            if (payload == null || (!force && !IsMetricTermAccepted()))
            {
                return;
            }

            foreach (TelemetryClient client in TelemetryClients)
            {
                client.TrackEvent(eventName, SerializeCustomEventPayload(payload));
            }
        }

        private void LogUsageEvent(AzurePSQoSEvent qos)
        {
            if (qos != null)
            {
                foreach (TelemetryClient client in TelemetryClients)
                {
                    var pageViewTelemetry = new PageViewTelemetry
                    {
                        Name = EventName,
                        Duration = qos.Duration,
                        Timestamp = qos.StartTime
                    };
                    LoadTelemetryClientContext(qos, pageViewTelemetry.Context);
                    //we only need to populate exception details into pageview
                    PopulatePropertiesFromQos(qos, pageViewTelemetry.Properties, true);
                    client.TrackPageView(pageViewTelemetry);
                }
            }
        }

        private void LogExceptionEvent(AzurePSQoSEvent qos)
        {
            if (qos == null || qos.Exception == null)
            {
                return;
            }

            Dictionary<string, double> eventMetrics = new Dictionary<string, double>();
            eventMetrics.Add("Duration", qos.Duration.TotalMilliseconds);

            foreach (TelemetryClient client in TelemetryClients)
            {
                Dictionary<string, string> eventProperties = new Dictionary<string, string>();
                LoadTelemetryClientContext(qos, client.Context);
                PopulatePropertiesFromQos(qos, eventProperties);
                // qos.Exception contains exception message which may contain Users specific data. 
                // We should not collect users specific data.
                eventProperties.Add("Message", "Message removed due to PII.");
                eventProperties.Add("StackTrace", qos.Exception.StackTrace);
                eventProperties.Add("ExceptionType", qos.Exception.GetType().ToString());
                Exception innerEx = qos.Exception.InnerException;
                int exceptionCount = 0;
                //keep goin till we get to the last inner exception
                while (innerEx != null)
                {
                    //Increment the inner exception count so that we can tell which is the outermost
                    //and which the innermost
                    eventProperties.Add("InnerExceptionType-"+exceptionCount++, innerEx.GetType().ToString());
                    innerEx = innerEx.InnerException;
                }
                client.TrackException(null, eventProperties, eventMetrics);
            }
        }

        private void LoadTelemetryClientContext(AzurePSQoSEvent qos, TelemetryContext clientContext)
        {
            if (clientContext != null && qos != null)
            {
                clientContext.User.Id = qos.Uid;
                clientContext.User.AccountId = qos.Uid;
                clientContext.Session.Id = qos.SessionId;
                clientContext.Device.OperatingSystem = Environment.OSVersion.ToString();
            }
        }

        public void SetPSHost(PSHost host)
        {
            _host = host;
        }

        private void PopulatePropertiesFromQos(AzurePSQoSEvent qos, IDictionary<string, string> eventProperties, bool populateException = false)
        {
            if (qos == null)
            {
                return;
            }

            eventProperties.Add("telemetry-version", "1");
            eventProperties.Add("Command", qos.CommandName);
            eventProperties.Add("IsSuccess", qos.IsSuccess.ToString());
            eventProperties.Add("ModuleName", qos.ModuleName);
            eventProperties.Add("ModuleVersion", qos.ModuleVersion);
            eventProperties.Add("HostVersion", qos.HostVersion);
            eventProperties.Add("OS", Environment.OSVersion.ToString());
            eventProperties.Add("CommandParameters", qos.Parameters);
            eventProperties.Add("x-ms-client-request-id", qos.ClientRequestId);
            eventProperties.Add("UserAgent", qos.UserAgent);
            eventProperties.Add("HashMacAddress", HashMacAddress);
            eventProperties.Add("PowerShellVersion", PSVersion);
            eventProperties.Add("Version", qos.AzVersion);
            eventProperties.Add("CommandParameterSetName", qos.ParameterSetName);
            eventProperties.Add("CommandInvocationName", qos.InvocationName);
            eventProperties.Add("start-time", qos.StartTime.ToUniversalTime().ToString("o"));
            eventProperties.Add("end-time", qos.EndTime.ToUniversalTime().ToString("o"));
            eventProperties.Add("duration", qos.Duration.ToString("c"));
            if (qos.Uid != null)
            {
                eventProperties.Add("UserId", qos.Uid);
            }
            if (qos.SubscriptionId != null)
            {
                eventProperties.Add("subscription-id", qos.SubscriptionId);
            }
            if (qos.TenantId != null)
            {
                eventProperties.Add("tenant-id", qos.TenantId);
            }

            if (qos.PreviousEndTime != null)
            {
                eventProperties.Add("interval", ((TimeSpan)(qos.StartTime - qos.PreviousEndTime)).ToString("c"));
            }

            if (qos.Exception != null && populateException)
            {
                eventProperties["exception-type"] = qos.Exception.GetType().ToString();
                string cloudErrorCode = null;
                if (qos.Exception is CloudException cloudException)
                {
                    eventProperties["exception-httpcode"] = cloudException.Response?.StatusCode.ToString();
                    cloudErrorCode = cloudException.Body?.Code;
                }
                Exception innerException = qos.Exception.InnerException;
                List<Exception> innerExceptions = new List<Exception>();
                string innerExceptionStr = string.Empty;
                while (innerException != null)
                {
                    innerExceptions.Add(innerException);
                    if (innerException is CloudException innerCloudException)
                    {
                        eventProperties["exception-httpcode"] = innerCloudException.Response?.StatusCode.ToString();
                        cloudErrorCode = innerCloudException.Body?.Code;
                    }
                    innerException = innerException.InnerException;
                }
                if (innerExceptions.Count > 0)
                {
                    eventProperties["exception-inner"] = string.Join(";", innerExceptions.Select(e => e.GetType().ToString()));
                }
                if (exceptionTrackAcceptModuleList.Contains(qos.ModuleName, StringComparer.InvariantCultureIgnoreCase)
                    || exceptionTrackAcceptCmdletList.Contains(qos.CommandName, StringComparer.InvariantCultureIgnoreCase))
                {
                    StackTrace trace = new StackTrace(qos.Exception);
                    string stack = string.Join(";", trace.GetFrames().Take(2).Select(f => ConvertFrameToString(f)));
                    eventProperties["exception-stack"] = stack;
                }

                if (cloudErrorCode != null && !(qos.Exception.Data?.Contains(AzurePSErrorDataKeys.CloudErrorCodeKey) == true))
                {
                    qos.Exception.Data[AzurePSErrorDataKeys.CloudErrorCodeKey] = cloudErrorCode;
                }

                if (qos.Exception.Data != null)
                {
                    if (qos.Exception.Data.Contains(AzurePSErrorDataKeys.HttpStatusCode))
                    {
                        eventProperties["exception-httpcode"] = qos.Exception.Data[AzurePSErrorDataKeys.HttpStatusCode].ToString();
                    }

                    if (qos.Exception.Data.Contains(AzurePSErrorDataKeys.CloudErrorCodeKey) == true)
                    {
                        string existingErrorKind = qos.Exception.Data.Contains(AzurePSErrorDataKeys.ErrorKindKey)
                                                    ? qos.Exception.Data[AzurePSErrorDataKeys.ErrorKindKey].ToString()
                                                    : null;
                        cloudErrorCode = (string)qos.Exception.Data[AzurePSErrorDataKeys.CloudErrorCodeKey];
                        // For the time being, we consider ResourceNotFound and ResourceGroupNotFound as user's input error. 
                        // We are considering if ResourceNotFound should be false positive error.
                        if (("ResourceNotFound".Equals(cloudErrorCode) || "ResourceGroupNotFound".Equals(cloudErrorCode))
                            && existingErrorKind != ErrorKind.FalseError)
                        {
                            qos.Exception.Data[AzurePSErrorDataKeys.ErrorKindKey] = ErrorKind.UserError;
                        }
                    }

                    StringBuilder sb = new StringBuilder();
                    foreach (var key in qos.Exception.Data?.Keys)
                    {
                        if (AzurePSErrorDataKeys.IsKeyPredefined(key.ToString()) 
                            && !AzurePSErrorDataKeys.HttpStatusCode.Equals(key))
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(";");
                            }
                            sb.Append($"{key.ToString().Substring(AzurePSErrorDataKeys.KeyPrefix.Length)}={qos.Exception.Data[key]}");
                        }
                    }
                    if(sb.Length > 0)
                    {
                        eventProperties["exception-data"] = sb.ToString();
                    }
                }
                //We record the case which exception has no message
                if (string.IsNullOrEmpty(qos.Exception.Message))
                {
                    eventProperties["exception-emptymessage"] = true.ToString();
                }

                if (!qos.IsSuccess && qos.Exception?.Data?.Contains(AzurePSErrorDataKeys.ErrorKindKey) == true)
                {
                    eventProperties["pebcak"] = (qos.Exception.Data[AzurePSErrorDataKeys.ErrorKindKey] == ErrorKind.UserError).ToString();
                    if (qos.Exception.Data[AzurePSErrorDataKeys.ErrorKindKey] == ErrorKind.FalseError)
                    {
                        eventProperties["IsSuccess"] = true.ToString();
                    }
                }
            }

            if (qos.InputFromPipeline != null)
            {
                eventProperties.Add("InputFromPipeline", qos.InputFromPipeline.Value.ToString());
            }
            if (qos.OutputToPipeline != null)
            {
                eventProperties.Add("OutputToPipeline", qos.OutputToPipeline.Value.ToString());
            }
            foreach (var key in qos.CustomProperties.Keys)
            {
                eventProperties[key] = qos.CustomProperties[key];
            }
        }

        private static string[] exceptionTrackAcceptModuleList = { "Az.Accounts", "Az.Compute", "Az.AKS", "Az.ContainerRegistry" };
        private static string[] exceptionTrackAcceptCmdletList = { "Get-AzKeyVaultSecret", "Get-AzKeyVaultCert" };

        private static string ConvertFrameToString(StackFrame frame)
        {
            string[] fullNameParts = frame?.GetMethod()?.DeclaringType?.FullName?.Split('.');
            if(fullNameParts == null || fullNameParts.Length == 0)
            {
                return null;
            }

            string ret = string.Join(",", frame.GetMethod().GetParameters().Select(p => p.ParameterType.Name));
            ret = $"{fullNameParts[fullNameParts.Length - 1]}.{frame.GetMethod().Name}({ret})";
            if (fullNameParts.Length > 1)
            {
                ret = string.Join(".", fullNameParts.Take(fullNameParts.Length - 1).Select(s => s.Substring(0, 1)))
                    + $".{ret}";
            }
            return ret;
        }

        public bool IsMetricTermAccepted()
        {
            return _profile != null 
                && _profile.EnableAzureDataCollection.HasValue 
                && _profile.EnableAzureDataCollection.Value;
        }

        public void FlushMetric()
        {
            if (!IsMetricTermAccepted())
            {
                return;
            }

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
        /// Generate a SHA256 Hash string from the originInput.
        /// </summary>
        /// <param name="originInput"></param>
        /// <returns>The Sha256 hash, or empty if the input is only whtespace</returns>
        public static string GenerateSha256HashString(string originInput)
        {
            if (string.IsNullOrWhiteSpace(originInput))
            {
                return string.Empty;
            }

            string result = null;
            try
            {
                using (var sha256 = new SHA256CryptoServiceProvider())
                {
                    var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(originInput));
                    result = BitConverter.ToString(bytes);
                }
            }
            catch
            {
                // do not throw if CryptoProvider is not provided
            }

            return result;
        }

        /// <summary>
        /// Generate a serialized payload for custom events.
        /// </summary>
        /// <param name="payload">The payload object for the custom event.</param>
        /// <returns>The serialized payload.</returns>
        public static Dictionary<string, string> SerializeCustomEventPayload<T>(T payload)
        {
            var payloadAsJson = JsonConvert.SerializeObject(payload, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(payloadAsJson);
        }
    }
}

public class AzurePSQoSEvent
{
    private readonly Stopwatch _timer;

    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public DateTimeOffset? PreviousEndTime { get; set; }
    public TimeSpan Duration { get; set; }
    public bool IsSuccess { get; set; }
    public string CommandName { get; set; }
    public string ModuleName { get; set; }
    public string ModuleVersion { get; set; }
    public string HostVersion { get; set; }
    public string AzVersion { get; set; }
    public string UserAgent { get; set; }
    public string Parameters { get; set; }
    public bool? InputFromPipeline { get; set; }
    public bool? OutputToPipeline { get; set; }
    public Exception Exception { get; set; }
    public string Uid { get; set; }
    public string ClientRequestId { get; set; }
    public string SessionId { get; set; }
    public string SubscriptionId { get; set; }
    public string TenantId { get; set; }

    public string ParameterSetName { get; set; }
    public string InvocationName { get; set; }
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
        EndTime = DateTimeOffset.Now;
    }

    public override string ToString()
    {
        string ret = string.Format(
            "AzureQoSEvent: CommandName - {0}; IsSuccess - {1}; Duration - {2}", CommandName, IsSuccess, Duration);
        if (Exception != null)
        {
            ret = $"{ret}; Exception - {Exception.Message};";
        }
        return ret;
    }
}
