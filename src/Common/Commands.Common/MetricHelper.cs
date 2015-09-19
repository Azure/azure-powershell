using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public static class MetricHelper
    {
        private const int FlushTimeoutInMilli = 5000;
        private static readonly TelemetryClient TelemetryClient;

        static MetricHelper()
        {            
            TelemetryClient = new TelemetryClient();
            // TODO: InstrumentationKey shall be injected in build server
            TelemetryClient.InstrumentationKey = "7df6ff70-8353-4672-80d6-568517fed090";
            // Disable IP collection
            TelemetryClient.Context.Location.Ip = "0.0.0.0";

            if (TestMockSupport.RunningMocked)
            {
                TelemetryConfiguration.Active.DisableTelemetry = true;
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
            var tcEvent = new RequestTelemetry(qos.CmdletType, qos.StartTime, qos.Duration, string.Empty, qos.IsSuccess);
            tcEvent.Context.User.Id = qos.Uid;
            tcEvent.Context.User.UserAgent = AzurePowerShell.UserAgentValue.ToString();
            tcEvent.Context.Device.OperatingSystem = Environment.OSVersion.VersionString;

            TelemetryClient.TrackRequest(tcEvent);
        }

        private static void LogExceptionEvent(AzurePSQoSEvent qos)
        {
            //Log as custome event to exclude actual exception message
            var tcEvent = new EventTelemetry("CmdletError");
            tcEvent.Properties.Add("ExceptionType", qos.Exception.GetType().FullName);
            tcEvent.Properties.Add("StackTrace", qos.Exception.StackTrace);
            if (qos.Exception.InnerException != null)
            {
                tcEvent.Properties.Add("InnerExceptionType", qos.Exception.InnerException.GetType().FullName);
                tcEvent.Properties.Add("InnerStackTrace", qos.Exception.InnerException.StackTrace);
            }

            tcEvent.Context.User.Id = qos.Uid;
            tcEvent.Properties.Add("CmdletType", qos.CmdletType);

            TelemetryClient.TrackEvent(tcEvent);
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
                TelemetryClient.Flush();
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
            return Encoding.UTF8.GetString(bytes);
        }
    }
}

public class AzurePSQoSEvent
{
    private readonly Stopwatch _timer;

    public DateTimeOffset StartTime { get; set; }
    public TimeSpan Duration { get; set; }
    public bool IsSuccess { get; set; }
    public string CmdletType { get; set; }
    public Exception Exception { get; set; }
    public string Uid { get; set; }

    public AzurePSQoSEvent()
    {
        StartTime = DateTimeOffset.Now;
        _timer = new Stopwatch();
        _timer.Start();
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
            "AzureQoSEvent: CmdletType - {0}; IsSuccess - {1}; Duration - {2}; Exception - {3};",
            CmdletType, IsSuccess, Duration, Exception);
    }
}
