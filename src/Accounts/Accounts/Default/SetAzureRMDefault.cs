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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Default
{
    /// <summary>
    /// Cmdlet to set default options. 
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Default", DefaultParameterSetName = ResourceGroupNameParameterSet,SupportsShouldProcess = true)]
    [OutputType(typeof(PSResourceGroup))]
    public class SetAzureRMDefaultCommand : AzureContextModificationCmdlet
    {
        private const string ResourceGroupNameParameterSet = "ResourceGroupName";

        [Parameter(ParameterSetName = ResourceGroupNameParameterSet, Mandatory = false, HelpMessage = "Name of the resource group being set as default", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Create a new resource group if specified default does not exist")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Environment.GetEnvironmentVariable("ACC_CLOUD") != null)
            {
                throw new Exception("Default Resource Group cannot be set on CloudShell");
            }

            IAzureContext context = DefaultContext;
            IResourceManagementClient resourceManagementclient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<ResourceManagementClient>(
                                context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                                AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager, _cmdletContext),
                                AzureSession.Instance.ClientFactory.GetCustomHandlers());
            resourceManagementclient.SubscriptionId = context.Subscription.Id;

            if (ResourceGroupName != null)
            {
                ResourceGroup defaultResourceGroup;
                if (ShouldProcess(Resources.DefaultResourceGroupTarget, string.Format(Resources.DefaultResourceGroupChangeWarning, ResourceGroupName)))
                {
                    if (!resourceManagementclient.ResourceGroups.CheckExistence(ResourceGroupName) && (Force.IsPresent || ShouldContinue(string.Format(Resources.CreateResourceGroupMessage, ResourceGroupName), Resources.CreateResourceGroupCaption)))
                    {
                        ResourceGroup parameters = new ResourceGroup("West US");
                        resourceManagementclient.ResourceGroups.CreateOrUpdate(ResourceGroupName, parameters);
                    }

                    defaultResourceGroup = resourceManagementclient.ResourceGroups.Get(ResourceGroupName);
                    ModifyContext((profile, client) => SetDefaultProperty(profile));
                    WriteObject(defaultResourceGroup);
                }
            }
        }

        private void SetDefaultProperty(IProfileOperations profile)
        {
            var context = profile.DefaultContext;
            context.SetProperty(Resources.DefaultResourceGroupKey, ResourceGroupName);
        }
    }
}
