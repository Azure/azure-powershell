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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.SignalR;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalR" + "NetworkAcl", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(PSSignalRNetworkAcls))]
    public class UpdateAzureRmSignalRNetworkAcl : SignalRCmdletBase,
IWithResourceId,IWithInputObject
    {
        [Parameter(
    Mandatory = false,
    ParameterSetName = ResourceGroupParameterSet,
    HelpMessage = "The resource group name. The default one will be used if not specified.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(
    Mandatory = true,
    Position = 0,
    ParameterSetName = ResourceGroupParameterSet,
    HelpMessage = "The SignalR service name.")]
        [ValidateNotNullOrEmpty()]
        public string Name { get; set; }

        [Parameter(
    Mandatory = true,
    ParameterSetName = ResourceIdParameterSet,
    ValueFromPipelineByPropertyName = true,
    HelpMessage = "The SignalR service resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
    Mandatory = true,
    ParameterSetName = InputObjectParameterSet,
    ValueFromPipeline = true,
    HelpMessage = "The SignalR resource object.")]
        [ValidateNotNull]
        public PSSignalRResource InputObject { get; set; }

        [Parameter(
    Mandatory = false,
    HelpMessage = "Run the cmdlet in background job.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
    Mandatory = false,
    HelpMessage = "Default Action of SignalR network ACLs, either allow or deny")]
        [PSArgumentCompleter("Allow", "Deny")]
        [ValidateSet("Allow", "Deny", IgnoreCase = true)]
        public string DefaultAction { get; set; }

        [Parameter(
    Mandatory = false,
    HelpMessage = "Update public network ACLs")]
        public SwitchParameter PublicNetwork { get; set; }

        [Parameter(
         Mandatory = false,
         HelpMessage = "Name(s) of private endpoint(s) to be updated")]
        public  string[] PrivateEndpointName { get; set; }

        [Parameter(HelpMessage = "Allowed network ACLs")]
        [PSArgumentCompleter("ClientConnection", "ServerConnection","RESTAPI")]
        [ValidateSet("ClientConnection", "ServerConnection", "RESTAPI", IgnoreCase = true)]
        public string[] Allow { get; set; }

        [Parameter(HelpMessage = "Denied network ACLs")]
        [PSArgumentCompleter("ClientConnection", "ServerConnection", "RESTAPI")]
        [ValidateSet("ClientConnection", "ServerConnection", "RESTAPI", IgnoreCase = true)]
        public string[] Deny { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdlet(() =>
            {
                switch (ParameterSetName)
                {
                    case ResourceGroupParameterSet:
                        ResolveResourceGroupName();
                        break;
                    case ResourceIdParameterSet:
                        this.LoadFromResourceId();
                        break;
                    case InputObjectParameterSet:
                        this.LoadFromInputObject();
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }
                if (ShouldProcess($"SignalR service {ResourceGroupName}/{Name}", "update"))
                {
                    PromptParameter(nameof(ResourceGroupName), ResourceGroupName);
                    PromptParameter(nameof(Name), Name);
                    var signalr = Client.SignalR.Get(ResourceGroupName, Name);
                    var networkACLs = signalr.NetworkACLs;
                    var publicNetwork = networkACLs.PublicNetwork;
                   var privateEndpoints = networkACLs.PrivateEndpoints;
                    if (PublicNetwork)
                    {
                        publicNetwork.Allow = Allow?? publicNetwork.Allow;
                        publicNetwork.Deny = Deny?? publicNetwork.Deny;
                    }
                    if (PrivateEndpointName != null && privateEndpoints!=null)  //if privateEndpoints is null, that means no private endpoint in this instance
                    {
                        PrivateEndpointName.ForEach(name =>
                        {
                            var target = privateEndpoints.Single(endpoint => endpoint.Name.Equals(name));
                            target.Allow = Allow ?? target.Allow;
                            target.Deny = Deny ?? target.Deny;
                        });
                    }
                    networkACLs.DefaultAction = DefaultAction ?? networkACLs.DefaultAction;
                    PromptParameter(nameof(networkACLs), networkACLs == null ? null : JsonConvert.SerializeObject(networkACLs));
                    signalr = Client.SignalR.Update(ResourceGroupName, Name, signalr);
                    WriteObject(new PSSignalRNetworkAcls(signalr.NetworkACLs));
                }
            });
        }
    }
}