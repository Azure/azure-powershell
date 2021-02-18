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
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics
{
    public class PSIotSecuritySolutionAnalytics : PSResource
    {
        public PSIoTSeverityMetrics Metrics {get; set;}

        public int? UnhealthyDeviceCount { get; set; }

        public IList<PSDevicesMetrics> DevicesMetrics { get; set; }

        public IList<PSIoTSecurityAlertedDevice> TopAlertedDevices { get; set; }

        public IList<PSIoTSecurityDeviceAlert> MostPrevalentDeviceAlerts { get; set; }

        public IList<PSIoTSecurityDeviceRecommendation> MostPrevalentDeviceRecommendations { get; set; }

    }
}
