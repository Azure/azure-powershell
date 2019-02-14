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

namespace Microsoft.Azure.Commands.StorageSync.Common.ArgumentCompleters
{
    using Commands.Common.Authentication;
    using Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Management.StorageSync;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

    /// <summary>
    /// This attribute will allow the user to autocomplete the -StorageSyncServiceName parameter of a cmdlet with valid resource groups
    /// Implements the <see cref="System.Management.Automation.ArgumentCompleterAttribute" />
    /// </summary>
    /// <seealso cref="System.Management.Automation.ArgumentCompleterAttribute" />
    public class StorageSyncServiceCompleterAttribute : ArgumentCompleterAttribute
    {
        /// <summary>
        /// The storage synchronize service names dictionary
        /// </summary>
        private static IDictionary<int, IList<String>> _storageSyncServiceNamesDictionary = new ConcurrentDictionary<int, IList<string>>();
        /// <summary>
        /// The lock
        /// </summary>
        private static readonly object _lock = new object();
        /// <summary>
        /// The timeout
        /// </summary>
        public static int _timeout = 3;

        /// <summary>
        /// Gets the storage synchronize service names.
        /// </summary>
        /// <value>The storage synchronize service names.</value>
        protected static IList<String> StorageSyncServiceNames
        {
            get
            {
                lock (_lock)
                {
                    IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                    var contextHash = HashContext(context);
                    if (!_storageSyncServiceNamesDictionary.ContainsKey(contextHash))
                    {
                        var tempStorageSyncServiceList = new List<string>();
                        try
                        {
                            var client = AzureSession.Instance.ClientFactory.CreateArmClient<StorageSyncManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
                            // Retrieve only the first page of StorageSyncServices to display to the user
                            var storageSyncServices = client.StorageSyncServices.ListBySubscriptionAsync();

                            if (_timeout == -1)
                            {
                                storageSyncServices.Wait();
                                tempStorageSyncServiceList = CreateStorageSyncServiceList(storageSyncServices.Result);
                                if (storageSyncServices.Result != null)
                                {
                                    _storageSyncServiceNamesDictionary[contextHash] = tempStorageSyncServiceList;
                                }
                            }
                            else if (storageSyncServices.Wait(TimeSpan.FromSeconds(_timeout)))
                            {
                                tempStorageSyncServiceList = CreateStorageSyncServiceList(storageSyncServices.Result);
                                if (storageSyncServices.Result != null)
                                {
                                    _storageSyncServiceNamesDictionary[contextHash] = tempStorageSyncServiceList;
                                }
                            }
#if DEBUG
                            else
                            {
                                throw new InvalidOperationException("client.StorageSyncServices call timed out");
                            }
#endif
                        }

                        catch (Exception ex)
                        {
#if DEBUG
                            throw ex;
#endif
                        }

                        return tempStorageSyncServiceList;
                    }

                    else
                    {
                        return _storageSyncServiceNamesDictionary[contextHash];
                    }
                }
            }
        }

        /// <summary>
        /// This class will provide a list of resource groups that are available to the user (with default resource group first if it exists). This will then be available to the user to tab through.
        /// Example: [Parameter(ParameterSetName = ListByNameInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false), StorageSyncServiceCompleter()]
        /// </summary>
        public StorageSyncServiceCompleterAttribute() : base(CreateScriptBlock())
        {
        }

        /// <summary>
        /// Gets the storage synchronize services.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>System.String[].</returns>
        public static string[] GetStorageSyncServices(int timeout)
        {
            _timeout = timeout;
            return GetStorageSyncServices();
        }

        /// <summary>
        /// Gets the storage synchronize services.
        /// </summary>
        /// <returns>System.String[].</returns>
        public static string[] GetStorageSyncServices()
        {
            IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
            return GetStorageSyncServices(StorageSyncServiceNames, defaultStorageSyncService: null);
        }

        /// <summary>
        /// Gets the storage synchronize services.
        /// </summary>
        /// <param name="storageSyncServiceNames">The storage synchronize service names.</param>
        /// <param name="defaultStorageSyncService">The default storage synchronize service.</param>
        /// <returns>System.String[].</returns>
        public static string[] GetStorageSyncServices(IList<string> storageSyncServiceNames, string defaultStorageSyncService)
        {
            if (defaultStorageSyncService != null)
            {
                if (storageSyncServiceNames.Contains(defaultStorageSyncService))
                {
                    storageSyncServiceNames.Remove(defaultStorageSyncService);
                }
                storageSyncServiceNames.Insert(0, defaultStorageSyncService);
            }
            return storageSyncServiceNames.ToArray();
        }

        /// <summary>
        /// Creates the script block.
        /// </summary>
        /// <returns>ScriptBlock.</returns>
        private static ScriptBlock CreateScriptBlock()
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                "$storageSyncServices = [Microsoft.Azure.Commands.StorageSync.Common.AttributeCompleters.StorageSyncServiceCompleterAttribute]::GetStorageSyncServices()\n" +
                "$storageSyncServices | Where-Object { $_ -Like \"$wordToComplete*\" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";

            return ScriptBlock.Create(script);
        }

        /// <summary>
        /// Hashes the context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>System.Int32.</returns>
        private static int HashContext(IAzureContext context)
        {
            return (context.Account.Id + context.Environment.Name + context.Subscription.Id + context.Tenant.Id).GetHashCode();
        }

        /// <summary>
        /// Creates the storage synchronize service list.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> CreateStorageSyncServiceList(IEnumerable<StorageSyncModels.StorageSyncService> result)
        {
            var tempStorageSyncServiceList = new List<string>();
            if (result != null)
            {
                foreach (StorageSyncModels.StorageSyncService storageSyncService in result)
                {
                    tempStorageSyncServiceList.Add(storageSyncService.Name);
                }
            }
#if DEBUG
            else
            {
                throw new Exception("Result from client.StorageSyncServices is null");
            }
#endif
            return tempStorageSyncServiceList;
        }
    }
}
