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

namespace Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters
{
    using Commands.Common.Authentication;
    using Commands.Common.Authentication.Abstractions;
    using Management.Internal.Resources;
    using Management.Internal.Resources.Models;
    using Properties;
    using Rest.Azure;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// This attribute will allow the user to autocomplete the -ResourceGroup parameter of a cmdlet with valid resource groups
    /// </summary>
    public class ResourceGroupCompleterAttribute : PSCompleterBaseAttribute
    {
        private static IDictionary<int, IList<String>> _resourceGroupNamesDictionary = new ConcurrentDictionary<int, IList<string>>();
        private static readonly object _lock = new object();
        public static int _timeout = 3;

        protected static IList<String> ResourceGroupNames
        {
            get
            {
                lock (_lock)
                {
                    IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                    var contextHash = HashContext(context);
                    if (!_resourceGroupNamesDictionary.ContainsKey(contextHash))
                    {
                        var tempResourceGroupList = new List<string>();
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
                            if (resourceGroups.Wait(TimeSpan.FromSeconds(_timeout)))
                            {
                                tempResourceGroupList = CreateResourceGroupList(resourceGroups.Result);
                                if (resourceGroups.Result != null)
                                {
                                    _resourceGroupNamesDictionary[contextHash] = tempResourceGroupList;
                                }
                            }
#if DEBUG
                            else
                            {
                                throw new InvalidOperationException("client.ResourceGroups call timed out");
                            }
#endif
                        }

                        catch (Exception ex)
                        {
                            if (ex == null) { }
#if DEBUG
                            throw ex;
#endif
                        }

                        return tempResourceGroupList;
                    }

                    else
                    {
                        return _resourceGroupNamesDictionary[contextHash];
                    }
                }
            }
        }

        /// <summary>
        /// This class will provide a list of resource groups that are available to the user (with default resource group first if it exists). This will then be available to the user to tab through.
        /// Example: [Parameter(ParameterSetName = ListByNameInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false), ResourceGroupCompleter()]
        /// </summary>
        /// <param name="resourceTypes"></param>
        public ResourceGroupCompleterAttribute()
        {
        }

        public override string[] GetCompleterValues()
        {
            return GetResourceGroups();
        }

        public static string[] GetResourceGroups(int timeout)
        {
            _timeout = timeout;
            return GetResourceGroups();
        }

        public static string[] GetResourceGroups()
        {
            IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
            var resourceGroupNamesCopy = ResourceGroupNames;
            if (context.IsPropertySet(Resources.DefaultResourceGroupKey))
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
                "$locations = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceGroupCompleterAttribute]::GetResourceGroups()\n" +
                "$locations | Where-Object { $_ -Like \"$wordToComplete*\" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }

        private static int HashContext(IAzureContext context)
        {
            return (context.Account.Id + context.Environment.Name + context.Subscription.Id + context.Tenant.Id).GetHashCode();
        }

        public static List<string> CreateResourceGroupList(IPage<ResourceGroup> result)
        {
            var tempResourceGroupList = new List<string>();
            if (result != null)
            {
                foreach (ResourceGroup resourceGroup in result)
                {
                    tempResourceGroupList.Add(resourceGroup.Name);
                }
            }
#if DEBUG
            else
            {
                throw new Exception("Result from client.ResourceGroups is null");
            }
#endif
            return tempResourceGroupList;
        }
    }
}