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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.WindowsAzure.Commands.Common;
using System;

namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// Class providing telemtry usage based on the user's data collection settings
    /// </summary>
    public class TelemetryProvider
    {
        AzurePSDataCollectionProfile _dataCollectionProfile;
        MetricHelper _helper;
        Action<string> _warningLogger, _debugLogger;


        protected TelemetryProvider(AzurePSDataCollectionProfile profile, MetricHelper helper, Action<string> warningLogger, Action<string> debugLogger)
        {
            _dataCollectionProfile = profile;
            _helper = helper;
            _warningLogger = warningLogger;
            _debugLogger = debugLogger;
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
        /// Log a telemtry event
        /// </summary>
        /// <param name="qosEvent">The event to log</param>
        public void LogEvent(AzurePSQoSEvent qosEvent)
        {
            var dataCollection = _dataCollectionProfile.EnableAzureDataCollection;
            var enabled = dataCollection.HasValue ? dataCollection.Value : true;
            _helper.LogQoSEvent(qosEvent, enabled, enabled);
        }

        private static MetricHelper CreateMetricHelper(AzurePSDataCollectionProfile profile)
        {
            var result = new MetricHelper(profile);
            result.AddTelemetryClient(new TelemetryClient
            {
                InstrumentationKey = "7df6ff70-8353-4672-80d6-568517fed090"
            });

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
            return new AzurePSDataCollectionProfile(true);
        }
    }
}
