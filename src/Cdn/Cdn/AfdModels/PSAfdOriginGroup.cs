﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Cdn.AfdModels
{
    public class PSAfdOriginGroup : PSArmBaseResource
    {
        public int? SampleSize { get; set; }

        public int? SuccessfulSamplesRequired { get; set; }

        public int? AdditionalLatencyInMilliseconds { get; set; }

        public string ProbePath { get; set; }

        public string ProbeRequestType { get; set; }

        public string ProbeProtocol { get; set; }

        public int? ProbeIntervalInSeconds { get; set; }

        public int? TrafficRestorationTimeToHealedOrNewEndpointsInMinutes { get; set; } // confirm this field
    }
}
