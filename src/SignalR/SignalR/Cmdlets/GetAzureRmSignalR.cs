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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.SignalR;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalR", DefaultParameterSetName = ListSignalRServiceParameterSet)]
    [OutputType(typeof(PSSignalRResource))]
    public class GetAzureRmSignalR : SignalRCmdletBase, IWithResourceId
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = ListSignalRServiceParameterSet,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceGroupParameterSet,
            HelpMessage = "The resource group name. The default one will be used if not specified.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceGroupParameterSet,
            HelpMessage = "The SignalR service name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The SignalR service resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdlet(() =>
            {
                switch (ParameterSetName)
                {
                    case ListSignalRServiceParameterSet:
                        var signalrs = string.IsNullOrEmpty(ResourceGroupName)
                                     ? Client.SignalR.ListBySubscription()
                                     : Client.SignalR.ListByResourceGroup(ResourceGroupName);
                        foreach (var s in signalrs)
                        {
                            WriteObject(new PSSignalRResource(s));
                        }
                        break;
                    case ResourceIdParameterSet:
                        this.LoadFromResourceId();
                        var signalrById = Client.SignalR.Get(ResourceGroupName, Name);
                        WriteObject(new PSSignalRResource(signalrById));
                        break;
                    case ResourceGroupParameterSet:
                        ResolveResourceGroupName();
                        var signalr = Client.SignalR.Get(ResourceGroupName, Name);
                        WriteObject(new PSSignalRResource(signalr));
                        break;

                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }
            });
        }
    }
}
