using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
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
        private static readonly TelemetryClient TelemetryClient;

        static MetricHelper()
        {            
            TelemetryClient = new TelemetryClient();
            TelemetryClient.Context.Location.Ip = "0.0.0.0";

            if (!IsMetricTermAccepted())
            {
                TelemetryConfiguration.Active.DisableTelemetry = true;
            }

            if (TestMockSupport.RunningMocked)
            {
                //TODO enable in final cr
                //TelemetryConfiguration.Active.DisableTelemetry = true;
            }
        }

        public static void LogUsageEvent(AzurePSQoSEvent qos)
        {
            if (!IsMetricTermAccepted())
            {
                return;
            }

            var tcEvent = new EventTelemetry("CmdletUsage");
            //tcEvent.Context.Location.Ip = "0.0.0.0";
            tcEvent.Context.User.Id = qos.UID;
            tcEvent.Context.User.UserAgent = AzurePowerShell.UserAgentValue.ToString();
            tcEvent.Properties.Add("CmdletType", qos.CmdletType);
            tcEvent.Properties.Add("IsSuccess", qos.IsSuccess.ToString());
            tcEvent.Properties.Add("Duration", qos.Duration.TotalSeconds.ToString(CultureInfo.InvariantCulture));

            TelemetryClient.TrackEvent(tcEvent);

            if (qos.Exception != null)
            {
                LogExceptionEvent(qos);
            }
        }

        private static void LogExceptionEvent(AzurePSQoSEvent qos)
        {

            var tcEvent = new EventTelemetry("CmdletError");
            tcEvent.Properties.Add("ExceptionType", qos.Exception.GetType().FullName);
            if (qos.Exception.InnerException != null)
            {
                tcEvent.Properties.Add("InnerExceptionType", qos.Exception.InnerException.GetType().FullName);
            }

            tcEvent.Context.User.Id = qos.UID;
            tcEvent.Properties.Add("CmdletType", qos.CmdletType);

            TelemetryClient.TrackEvent(tcEvent);
        }

        public static bool IsMetricTermAccepted()
        {
            //TODO check the config/preference
            return true;
        }

        public static void FlushMetric(bool waitForMetricSending)
        {
            if (!IsMetricTermAccepted())
            {
                return;
            }

            if (waitForMetricSending)
            {
                FlushAi();
            }
            else
            {
                Task.Run(() => FlushAi());
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

    public TimeSpan Duration { get; set; }
    public bool IsSuccess { get; set; }
    public string CmdletType { get; set; }
    public Exception Exception { get; set; }
    public string UID { get; set; }

    public AzurePSQoSEvent()
    {
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
