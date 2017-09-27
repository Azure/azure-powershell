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
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Default
{
    /// <summary>
    /// Cmdlet to set default options. 
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmDefault", DefaultParameterSetName = ResourceGroupNameParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(ResourceGroup))]
    public class SetAzureRMDefaultCommand : AzureRMCmdlet
    {
        private const string ResourceGroupNameParameterSet = "ResourceGroupName";

        [Parameter(ParameterSetName = ResourceGroupNameParameterSet, Mandatory = false, HelpMessage = "Resource Group Name", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
            IResourceManagementClient client = AzureSession.Instance.ClientFactory.CreateCustomArmClient<ResourceManagementClient>(
                                context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                                AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager),
                                AzureSession.Instance.ClientFactory.GetCustomHandlers());
            client.SubscriptionId = context.Subscription.Id;

            if (ResourceGroupName != null)
            {
                var defaultResourceGroup = client.ResourceGroups.Get(ResourceGroupName);
                if (ShouldProcess(Resources.DefaultResourceGroupTarget, String.Format(Resources.DefaultResourceGroupChangeWarning, defaultResourceGroup.Name)))
                {
                    if (context.ExtendedProperties.ContainsKey(Resources.DefaultResourceGroupKey))
                    {
                        context.ExtendedProperties.SetProperty(Resources.DefaultResourceGroupKey, defaultResourceGroup.Name);
                    }

                    else
                    {
                        context.ExtendedProperties.Add(Resources.DefaultResourceGroupKey, defaultResourceGroup.Name);
                    }
                }
                WriteObject(defaultResourceGroup);
            }
        }
    }
}
