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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Analysis;
using Microsoft.Azure.Management.Analysis.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace Microsoft.Azure.Commands.AnalysisServices.Models
{
    public class AnalysisServicesClient
    {
        private readonly AnalysisServicesManagementClient _client;
        private readonly Guid _subscriptionId;
        private readonly string _currentUser;

        public AnalysisServicesClient(AzureContext context)
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.InvalidDefaultSubscription);
            }

            _subscriptionId = context.Subscription.Id;
            _client = AnalysisServicesCmdletBase.CreateAsClient<AnalysisServicesManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);
            _currentUser = context.Account.Id;
        }

        public AnalysisServicesClient()
        {
        }

        #region Server Related Operations

        public AnalysisServicesServer CreateOrUpdateServer(
            string resourceGroupName, 
            string serverName,
            string location, 
            string skuName = null,
            Hashtable customTags = null,
            string administrators = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByServer(serverName);
            }

            var tags = (customTags != null)
                ? TagsConversionHelper.CreateTagDictionary(customTags, true)
                : null;

            AnalysisServicesServer server = null;
            try
            {
                server = GetServer(resourceGroupName, serverName);
            }
            catch
            {
                // intentionally empty since if there is any exception attempting to 
                // get the server we know it doesn't exist and we will attempt to create it fresh.
            }

            var adminList = new List<string>();

            if (!string.IsNullOrEmpty(administrators))
            {
                adminList.AddRange(administrators.Split(','));
            }

            if (server != null)
            {
                var updateParameters = new AnalysisServicesServerUpdateParameters()
                {
                    Sku = server.Sku,
                    Tags = tags ?? new Dictionary<string, string>(),
                    AsAdministrators = new ServerAdministrators(adminList)
                };

                server = _client.Servers.Update(resourceGroupName, serverName, updateParameters);
            }
            else
            {
                if (adminList.Count == 0)
                {
                    adminList.Add(_currentUser);
                }

                server = _client.Servers.Create(
                    resourceGroupName, 
                    serverName, 
                    new AnalysisServicesServer()
                    {
                        AsAdministrators = new ServerAdministrators(adminList),
                        Location = location,
                        Sku = new ResourceSku(skuName, "Standard"),
                        Tags = tags ?? new Dictionary<string, string>()
                    });
            }

            return server;
        }

        public void DeleteServer(string resourceGroupName, string serverName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByServer(serverName);
            }

            if (!TestServer(resourceGroupName, serverName))
            {
                throw new InvalidOperationException(string.Format(Properties.Resources.ServerDoesNotExist, serverName));
            }

            _client.Servers.Delete(resourceGroupName, serverName);
        }

        public bool TestServer(string resourceGroupName, string serverName)
        {
            try
            {
                GetServer(resourceGroupName, serverName);
                return true;
            }
            catch (CloudException ex)
            {
                if ((ex.Response != null && ex.Response.StatusCode == HttpStatusCode.NotFound) || ex.Message.Contains(string.Format(Properties.Resources.FailedToDiscoverResourceGroup, serverName,
                    _subscriptionId)))
                {
                    return false;
                }

                throw;
            }
        }

        public AnalysisServicesServer GetServer(string resourceGroupName, string serverName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByServer(serverName);
            }

            return _client.Servers.GetDetails(resourceGroupName, serverName);
        }

        public List<AnalysisServicesServer> ListServers(string resourceGroupName)
        {
            var serverList = new List<AnalysisServicesServer>();
            var response = string.IsNullOrEmpty(resourceGroupName) ?
                _client.Servers.List() :
                _client.Servers.ListByResourceGroup(resourceGroupName);

            serverList.AddRange(response);

            return serverList;
        }
        
        private string GetResourceGroupByServer(string serverName)
        {
            try
            {
                var acctId =
                    ListServers(null)
                        .Find(x => x.Name.Equals(serverName, StringComparison.InvariantCultureIgnoreCase))
                        .Id;
                var rgStart = acctId.IndexOf("resourceGroups/", StringComparison.InvariantCultureIgnoreCase) +
                              ("resourceGroups/".Length);
                var rgLength = (acctId.IndexOf("/providers/", StringComparison.InvariantCultureIgnoreCase)) - rgStart;
                return acctId.Substring(rgStart, rgLength);
            }
            catch
            {
                throw new CloudException(string.Format(Properties.Resources.FailedToDiscoverResourceGroup, serverName, _subscriptionId));
            }
        }

        #endregion
    }
}