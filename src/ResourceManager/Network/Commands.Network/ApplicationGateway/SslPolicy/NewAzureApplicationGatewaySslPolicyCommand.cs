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

using System.Collections.Generic;
using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmApplicationGatewaySslPolicy", SupportsShouldProcess = true), 
        OutputType(typeof(PSApplicationGatewaySslPolicy))]
    public class NewAzureApplicationGatewaySslPolicyCommand : AzureApplicationGatewaySslPolicyBase
    {
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess("AzureApplicationGatewaySslPolicy", Microsoft.Azure.Commands.Network.Properties.Resources.CreatingResourceMessage))
            {
                base.ExecuteCmdlet();

                PSApplicationGatewaySslPolicy policy = new PSApplicationGatewaySslPolicy();
                policy.DisabledSslProtocols = new List<string>();
                foreach (var protocol in this.DisabledSslProtocols)
                {
                    policy.DisabledSslProtocols.Add(protocol);
                }

                WriteObject(policy);
            }
        }
    }
}
