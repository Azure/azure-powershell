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

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSPublicIpDdosProtectionStatusResult
    {
        
        [Ps1Xml(Target = ViewControl.Table)]
        public string PublicIpAddressId { get; set; }

        //
        // Summary:
        //     Gets or sets IP Address of the Public IP Resource
        [Ps1Xml(Target = ViewControl.Table)]
        public string PublicIpAddress { get; set; }

        //
        // Summary:
        //     Gets or sets value indicating whether the IP address is DDoS workload protected
        //     or not. Possible values include: 'False', 'True'
        [Ps1Xml(Target = ViewControl.Table)]
        public string IsWorkloadProtected { get; set; }

        //
        // Summary:
        //     Gets or sets DDoS protection plan Resource Id of a if IP address is protected
        //     through a plan.
        [Ps1Xml(Target = ViewControl.Table)]
        public string DdosProtectionPlanId { get; set; }

    }
}
