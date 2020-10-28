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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalR" + "Upstream", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(PSServerlessUpstreamSettings))]
    public class SetAzureRmSignalRUpstream : SignalRCmdletBase ,  IWithResourceId, IWithInputObject
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
HelpMessage = "Template item(s) for upstream settings. " +
            "Required key: UrlTemplate." +
            " Optional keys: HubPattern, EventPattern, CategoryPattern. " +
            "Example using splatting syntax to create two templates: " +
            "@{UrlTemplate='http://host-connections1.com'; HubPattern='chat';EventPattern='broadcast' }, @{UrlTemplate='http://host-connections2.com'}")]
        public PSUpstreamTemplate[] Template { get; set; }

        [Parameter(
Mandatory = false,
HelpMessage = "Clear all the upstream settings.")]
        public SwitchParameter Clear { get; set; }

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
                if (ShouldProcess($"SignalR service {ResourceGroupName}/{Name}", "update upstream settings"))
                {
                    PromptParameter(nameof(ResourceGroupName), ResourceGroupName);
                    PromptParameter(nameof(Name), Name);
                    if (Clear)
                    {
                        Template = new PSUpstreamTemplate[0];
                    }
                    PromptParameter(nameof(Template), JsonConvert.SerializeObject(Template));

                    var signalr = Client.SignalR.Get(ResourceGroupName, Name);
                    signalr.Upstream.Templates = Template.Select(t => t.toSDKTemplate()).ToList();
                    signalr = Client.SignalR.Update(ResourceGroupName, Name, signalr);
                    WriteObject(new PSSignalRResource(signalr).Upstream);
                }
            });
        }
    }
}
