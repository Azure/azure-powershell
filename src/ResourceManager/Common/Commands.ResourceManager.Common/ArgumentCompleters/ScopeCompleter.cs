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

    public class ScopeCompleterAttribute : ArgumentCompleterAttribute
    {
        public static IDictionary<int, IList<string>> _scopeDictionary = new ConcurrentDictionary<int, IList<string>>();
        private static readonly object _lock = new object();
        public static int _timeout = 3;

        protected static IList<String> Scopes
        {
            get
            {
                lock (_lock)
                {
                    IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                    var contextHash = HashContext(context);
                    if (!_scopeDictionary.ContainsKey(contextHash))
                    {
                        var tempScopeList = new List<string>();
                        try
                        {
                            var client = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
                            // Retrieve only the first page of ResourceGroups to use for scopes
                            var resourceGroups = client.ResourceGroups.ListAsync();
                            if (resourceGroups.Wait(TimeSpan.FromSeconds(_timeout)))
                            {
                                tempScopeList = CreateScopeList(resourceGroups.Result, context.Subscription.Id);
                                _scopeDictionary[contextHash] = tempScopeList;
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

                        return tempScopeList;
                    }

                    else
                    {
                        return _scopeDictionary[contextHash];
                    }
                }
            }
        }

        /// <summary>
        /// This class will provide a list of scopes that are available to the user. This will then be available to the user to tab through.
        /// </summary>
        public ScopeCompleterAttribute() : base(CreateScriptBlock())
        {
        }

        public static string[] GetScopes(int timeout)
        {
            _timeout = timeout;
            return GetScopes();
        }

        public static string[] GetScopes()
        {
            return Scopes.ToArray();
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                "$scopes = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ScopeCompleterAttribute]::GetScopes()\n" +
                "$scopes | Where-Object { $_ -Like \"*$wordToComplete*\" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }

        private static int HashContext(IAzureContext context)
        {
            return (context.Account.Id + context.Environment.Name + context.Subscription.Id + context.Tenant.Id).GetHashCode();
        }

        public static List<string> CreateScopeList(IPage<ResourceGroup> result, string subscriptionId)
        {
            var tempScopeList = new List<string> { string.Format("/subscriptions/{0}", subscriptionId) };
            if (result != null)
            {
                foreach (ResourceGroup resourceGroup in result)
                {
                    tempScopeList.Add(string.Format("/subscriptions/{0}/resourceGroups/{1}", subscriptionId, resourceGroup.Name));
                }
            }
#if DEBUG
            else
            {
                throw new Exception("Result from client.ResourceGroups is null");
            }
#endif
            return tempScopeList;
        }
    }
}
