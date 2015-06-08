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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ExpressRoute.Properties;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{
    [Cmdlet(VerbsCommon.New, "AzureCrossConnection"), OutputType(typeof(AzureCrossConnection))]
    public class NewAzureCrossConnectionCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Dedicated Circuit Service Key")]
        public Guid ServiceKey { get; set; }

        [Parameter(HelpMessage = "Do not confirm Azure Cross Connection creation")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
               Force.IsPresent,
               string.Format(Resources.NewAzureCrossConnectionWarning, ServiceKey),
               string.Format(Resources.NewAzureCrossConnectionMessage, ServiceKey),
               ServiceKey.ToString(),
               () =>
               {
                   var crossConnection = ExpressRouteClient.NewAzureCrossConnection(ServiceKey);
                   WriteVerboseWithTimestamp(Resources.NewAzureCrossConnectionSucceeded);
                   WriteObject(crossConnection);
               });

        }
    }
}
