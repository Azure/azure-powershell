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

namespace Microsoft.Azure.Commands.ResourceManager.Common.TabCompletion
{
    using Commands.Common.Authentication;
    using Commands.Common.Authentication.Abstractions;
    using Management.Internal.Resources;
    using Management.Internal.Resources.Models;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// This attribute will allow the user to autocomplete the -ResourceGroup parameter of a cmdlet with valid resource groups
    /// </summary>
    public class ResourceGroupCompleterAttribute : ArgumentCompleterAttribute
    {
        private static IList<String> _resourceGroupNames = new List<string>();
        private static readonly object _lock = new object();

        protected static IList<String> ResourceGroupNames
        {
            get
            {
                lock (_lock)
                {
                    _resourceGroupNames = new List<string>();
                    IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                    try
                    {
                        var instance = AzureSession.Instance;
                        var client = instance.ClientFactory.CreateCustomArmClient<ResourceManagementClient>(
                            context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                            instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager),
                            instance.ClientFactory.GetCustomHandlers());
                        client.SubscriptionId = context.Subscription.Id;
                        // Retrieve only the first page of ResourceGroups to display to the user
                        var resourceGroups = client.ResourceGroups.ListAsync();
                        if (resourceGroups.Wait(TimeSpan.FromSeconds(5)))
                        {
                            if (resourceGroups.Result != null)
                            {
                                var resourceGroupList = resourceGroups.Result;
                                foreach (ResourceGroup resourceGroup in resourceGroupList)
                                {
                                    _resourceGroupNames.Add(resourceGroup.Name);
                                }
                            }
#if DEBUG
                            else
                            {
                                throw new Exception("Result from client.ResourceGroups is null");
                            }
#endif
                        }
#if DEBUG
                        else
                        {
                            throw new Exception("client.ResourceGroups call timed out");
                        }
#endif
                    }

                    catch (Exception ex)
                    {
#if DEBUG
                        throw ex;
#endif
                    }
                }

                return _resourceGroupNames;
            }
        }

        /// <summary>
        /// This class will provide a list of resource groups that are available to the user (with default resource group first if it exists). This will then be available to the user to tab through.
        /// Example: [Parameter(ParameterSetName = ListByNameInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false), ResourceGroupCompleter()]
        /// </summary>
        /// <param name="resourceTypes"></param>
        public ResourceGroupCompleterAttribute() : base(CreateScriptBlock())
        {
        }

        public static string[] GetResourceGroups()
        {
            IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
            var resourceGroupNamesCopy = ResourceGroupNames;
            if (context.ExtendedProperties.ContainsKey(Resources.DefaultResourceGroupKey))
            {
                return GetResourceGroups(resourceGroupNamesCopy, context.ExtendedProperties[Resources.DefaultResourceGroupKey]);
            }
            return GetResourceGroups(resourceGroupNamesCopy, null);
        }

        public static string[] GetResourceGroups(IList<string> resourceGroupNames, string defaultResourceGroup)
        {
            if (defaultResourceGroup != null)
            {
                if (resourceGroupNames.Contains(defaultResourceGroup))
                {
                    resourceGroupNames.Remove(defaultResourceGroup);    
                }
                resourceGroupNames.Insert(0, defaultResourceGroup);
            }
            return resourceGroupNames.ToArray();
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                "$locations = [Microsoft.Azure.Commands.ResourceManager.Common.TabCompletion.ResourceGroupCompleterAttribute]::GetResourceGroups()\n" +
                "$locations | Where-Object { $_ -Like \"$wordToComplete*\" } | Select-Object -First 50 | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }
    }
}