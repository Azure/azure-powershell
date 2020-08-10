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

using Microsoft.Azure.Management.Storage.Models;
using System;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class PSRoutingPreference
    {
        //Parse RoutingPreference  in SDK to wrapped property PSRoutingPreference
        public static PSRoutingPreference ParsePSRoutingPreference(RoutingPreference routingPreference)
        {
            if (routingPreference == null)
            {
                return null;
            }

            PSRoutingPreference pSRoutingPreference = new PSRoutingPreference();

            pSRoutingPreference.RoutingChoice = routingPreference.RoutingChoice;
            pSRoutingPreference.PublishMicrosoftEndpoints = routingPreference.PublishMicrosoftEndpoints;
            pSRoutingPreference.PublishInternetEndpoints = routingPreference.PublishInternetEndpoints;

            return pSRoutingPreference;
        }

        public string RoutingChoice { get; set; }
        public bool? PublishMicrosoftEndpoints { get; set; }
        public bool? PublishInternetEndpoints { get; set; }
    }
}
