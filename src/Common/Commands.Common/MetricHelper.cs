using System;
using System.Collections.Generic;
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

            if (!IsMetricTermAccepted())
            {
                TelemetryConfiguration.Active.DisableTelemetry = true;
            }

            if (TestMockSupport.RunningMocked)
            {
                //TODO enable in final cr
                //TelemetryConfiguration.Active.DisableTelemetry = true;
                //TelemetryConfiguration.Active.TelemetryChannel.DeveloperMode = true;
            }
        }

        public static void LogUsageEvent(string subscriptionId, string cmdletName)
        {
            if (!IsMetricTermAccepted())
            {
                return;
            }

            var tcEvent = new EventTelemetry("CmdletUsage");

            tcEvent.Context.User.Id = GenerateSha256HashString(subscriptionId);
            tcEvent.Context.User.UserAgent = AzurePowerShell.UserAgentValue.ToString();
            tcEvent.Properties.Add("CmdletType", cmdletName);

            TelemetryClient.TrackEvent(tcEvent);
        }

        public static void LogErrorEvent(ErrorRecord err, string subscriptionId, string cmdletName)
        {
            if (!IsMetricTermAccepted())
            {
                return;
            }

            var tcEvent = new EventTelemetry("CmdletError");
            tcEvent.Properties.Add("ExceptionType", err.Exception.GetType().FullName);
            if (err.Exception.InnerException != null)
            {
                tcEvent.Properties.Add("InnerExceptionType", err.Exception.InnerException.GetType().FullName);
            }
            
            tcEvent.Context.User.Id = GenerateSha256HashString(subscriptionId);
            tcEvent.Context.User.UserAgent = AzurePowerShell.UserAgentValue.ToString();
            tcEvent.Properties.Add("CmdletType", cmdletName);

            TelemetryClient.TrackEvent(tcEvent);
        }

        public static bool IsMetricTermAccepted()
        {
            //TODO check the config/preference
            return true;
        }

        public static void FlushMetric()
        {
            if (!IsMetricTermAccepted())
            {
                return;
            }

            var t = Task.Run(() => FlushAi());
            //TelemetryClient.Flush();
        }

        private static void FlushAi()
        {
            try
            {
                TelemetryClient.Flush();
                
                //return Task.FromResult(default(object));
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
