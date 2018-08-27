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

using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureLoadBalancerProbeConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the probe")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Request path")]
        [ValidateNotNullOrEmpty]
        public string RequestPath { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The transport protocol for the external endpoint.")]
        [ValidateSet(MNM.ProbeProtocol.Tcp, MNM.ProbeProtocol.Http, IgnoreCase = true)]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The probe port")]
        public int Port { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "IntervalInSeconds")]
        public int IntervalInSeconds { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "NumberOfProbes")]
        public int ProbeCount { get; set; }
    }
}
