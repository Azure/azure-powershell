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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyHttpHeaderToInsert",
        SupportsShouldProcess = true),
        OutputType(typeof(PSAzureFirewallPolicyIntrusionDetection))]

    public class NewAzureFirewallPolicyHttpHeaderToInsertCommand : NetworkBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             HelpMessage = "Http header name."
         )]
        [ValidateNotNullOrEmpty]
        public string HeaderName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Http header value."
         )]
        [ValidateNotNullOrEmpty]
        public string HeaderValue { get; set; }

        public override void Execute()
        {
            base.Execute();

            var headerToInsert = new PSAzureFirewallPolicyHttpHeaderToInsert
            {
                HeaderName = this.HeaderName,
                HeaderValue = this.HeaderValue
            };
            
            // TODO - validate

            WriteObject(headerToInsert);
        }
    }
}
