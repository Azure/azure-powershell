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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalRCustomCertificate", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmSignalRCustomCertificate : SignalRCmdletBase, ISignalRChildResource
    {
        [Parameter(Mandatory = false, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The resource group name. The default one will be used if not specified.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The SignalR service name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(Constants.SignalRResourceType, nameof(ResourceGroupName))]
        public string SignalRName { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The custom certificate name.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SignalRObjectParameterSet, HelpMessage = "The custom certificate name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The SignalR custom certificate resource object.")]
        [ValidateNotNull]
        public PSCustomCertificateResource InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SignalRObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The SignalR resource object.")]
        [ValidateNotNull]
        public PSSignalRResource SignalRInputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The resource ID of the custom certificate", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty()]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run the cmdlet in background job.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

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
                        this.LoadFromChildResourceId(ResourceId, Constants.SignalRCustomCertificateResourceType);
                        break;
                    case SignalRObjectParameterSet:
                        var signalRResourceId = new ResourceIdentifier(SignalRInputObject.Id);
                        ResourceGroupName = signalRResourceId.ResourceGroupName;
                        SignalRName = signalRResourceId.ResourceName;
                        break;
                    case InputObjectParameterSet:
                        this.LoadFromChildResourceId(InputObject.Id, Constants.SignalRCustomCertificateResourceType);
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }
                if (ShouldProcess($"SignalR custom certificate {ResourceGroupName}/{SignalRName}/{Name}", "remove"))
                {
                    Microsoft.Azure.Management.SignalR.SignalRCustomCertificatesOperationsExtensions.Delete(Client.SignalRCustomCertificates, ResourceGroupName, SignalRName, Name);
                    WriteObject(true);
                }
            });
        }
    }
}
