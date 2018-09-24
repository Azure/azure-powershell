﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.ApplicationInsights.Management.Models;

namespace Microsoft.Azure.Commands.ApplicationInsights.Models
{
    public class PSDailyCap
    {
        public double? Cap { get; set; }

        public int? ResetTime { get; set; }

        public bool StopSendNotificationWhenHitCap { get; set; }

        public PSDailyCap(ApplicationInsightsComponentBillingFeatures billing)
        {
            this.Cap = billing.DataVolumeCap.Cap;
            this.ResetTime = billing.DataVolumeCap.ResetTime;
            this.StopSendNotificationWhenHitCap = billing.DataVolumeCap.StopSendNotificationWhenHitCap.Value;
        }
    }
}
