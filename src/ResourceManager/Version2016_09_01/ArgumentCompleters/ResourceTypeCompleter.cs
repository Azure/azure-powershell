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
    /// This attribute will allow the user to autocomplete the -ResourceType parameter of a cmdlet with valid resource types
    /// </summary>
    public class ResourceTypeCompleterAttribute : ArgumentCompleterAttribute
    {
        private static IDictionary<int, IList<String>> _resourceTypesDictionary = new ConcurrentDictionary<int, IList<string>>();
        private static readonly object _lock = new object();
        public static int _timeout = 3;

        protected static IList<String> ResourceTypes
        {
            get
            {
                lock (_lock)
                {
                    IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                    var contextHash = HashContext(context);
                    if (!_resourceTypesDictionary.ContainsKey(contextHash))
                    {
                        var tempResourceTypeList = new List<string>();
                        try
                        {
                            var client = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
                            var resourceTypes = new List<Provider>();
                            var task = client.Providers.ListAsync();
                            if (task.Wait(TimeSpan.FromSeconds(_timeout)))
                            {
                                var page = task.Result;
                                resourceTypes.AddRange(page);
                                while (!string.IsNullOrEmpty(page.NextPageLink))
                                {
                                    task = client.Providers.ListNextAsync(page.NextPageLink);

                                    if (_timeout == -1)
                                    {
                                        task.Wait();
                                        page = task.Result;
                                        resourceTypes.AddRange(page);
                                    }
                                    else if (task.Wait(TimeSpan.FromSeconds(_timeout)))
                                    {
                                        page = task.Result;
                                        resourceTypes.AddRange(page);
                                    }
#if DEBUG
                                    else
                                    {
                                        throw new InvalidOperationException("client.Providers.ListNextAsync() call timed out");
                                    }
#endif
                                }

                                tempResourceTypeList = CreateResourceTypeList(resourceTypes);
                                if (tempResourceTypeList != null)
                                {
                                    _resourceTypesDictionary[contextHash] = tempResourceTypeList;
                                }
                            }
#if DEBUG
                            else
                            {
                                throw new InvalidOperationException("client.Providers.ListAsync() call timed out");
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

                        return tempResourceTypeList;
                    }

                    else
                    {
                        return _resourceTypesDictionary[contextHash];
                    }
                }
            }
        }

        /// <summary>
        /// This class will provide a list of resource types that are available to the user. This will then be available to the user to tab through.
        /// </summary>
        public ResourceTypeCompleterAttribute() : base(CreateScriptBlock())
        {
        }

        public static string[] GetResourceTypes(int timeout)
        {
            _timeout = timeout;
            return GetResourceTypes();
        }

        public static string[] GetResourceTypes()
        {
            return ResourceTypes.ToArray();
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                "$locations = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceTypeCompleterAttribute]::GetResourceTypes()\n" +
                "$locations | Where-Object { $_ -Like \"*$wordToComplete*\" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }

        private static int HashContext(IAzureContext context)
        {
            return (context.Account.Id + context.Environment.Name + context.Subscription.Id + context.Tenant.Id).GetHashCode();
        }

        public static List<string> CreateResourceTypeList(List<Provider> result)
        {
            var tempResourceTypeList = new List<string>();
            if (result != null)
            {
                foreach (Provider provider in result)
                {
                    foreach (ProviderResourceType resourceType in provider.ResourceTypes)
                    {
                        var type = provider.NamespaceProperty + "/" + resourceType.ResourceType;
                        tempResourceTypeList.Add(type);
                    }
                }
            }
#if DEBUG
            else
            {
                throw new Exception("Result from client.Providers.ListAsync() is null");
            }
#endif
            return tempResourceTypeList;
        }
    }
}