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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.ServiceBus;
using Microsoft.Azure.Management.ServiceBus.Models;
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands.ServiceBus.Commands;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Security.Cryptography;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.ServiceBus
{
    public class ServiceBusClient
    {
         // Azure SDK requires a request parameter to be specified for a few Backup API calls, but
        // the request is actually optional unless an update is needed
       // private static readonly BackupRequest EmptyRequest = new BackupRequest(location: "");

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public ServiceBusClient(IAzureContext context)
        {
            this.Client = AzureSession.Instance.ClientFactory.CreateArmClient<ServiceBusManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        public ServiceBusManagementClient Client
        {
            get;
            private set;
        }

        #region Namespace
        public PSNamespaceAttributes GetNamespace(string resourceGroupName, string namespaceName)
        {
            SBNamespace response = Client.Namespaces.Get(resourceGroupName, namespaceName);
            return new PSNamespaceAttributes(response);
        }

        public IEnumerable<PSNamespaceAttributes> ListNamespaces(string resourceGroupName)
        {
            Rest.Azure.IPage<SBNamespace> response = Client.Namespaces.ListByResourceGroup(resourceGroupName);
            IEnumerable<PSNamespaceAttributes> resourceList = response.Select(resource => new PSNamespaceAttributes(resource));
            return resourceList;
        }

        public IEnumerable<PSNamespaceAttributes> ListAllNamespaces()
        {
            Rest.Azure.IPage<SBNamespace> response = Client.Namespaces.List();
            var resourceList = response.Select(resource => new PSNamespaceAttributes(resource));
            return resourceList;
        }


        public PSNamespaceAttributes BeginCreateNamespace(string resourceGroupName, string namespaceName, string location, string skuName, Dictionary<string, string> tags, int? skuCapacity = null, bool enableZoneRedundant = false)
        {
            SBNamespace parameter = new SBNamespace();
            parameter.Location = location;

            if (tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            if (skuName != null)
            {
                parameter.Sku = new SBSku();
                parameter.Sku.Name = AzureServiceBusCmdletBase.ParseSkuName(skuName);

                if (parameter.Sku.Name == SkuName.Premium && skuCapacity != null)
                {
                    parameter.Sku.Capacity = skuCapacity;
                }
            }

            if (enableZoneRedundant.Equals(true))
            {
                parameter.ZoneRedundant = true;
            }

            SBNamespace response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new PSNamespaceAttributes(response);
        }


        public PSNamespaceAttributes UpdateNamespace(string resourceGroupName, string namespaceName, string location, string skuName, int? skuCapacity, Dictionary<string, string> tags)
        {

            var parameter = new SBNamespace()
            {
                Location = location
            };

            if (tags != null)
            {
                parameter.Tags = new Dictionary<string, string>(tags);
            }

            SBSku tempSku = new SBSku();



            if (skuName != null)
            {
                tempSku.Name = AzureServiceBusCmdletBase.ParseSkuName(skuName);
                tempSku.Tier = AzureServiceBusCmdletBase.ParseSkuTier(skuName);
            }

            if (skuCapacity != null)
            {
                tempSku.Capacity = skuCapacity;
            }

            parameter.Sku = tempSku;

            SBNamespace response = Client.Namespaces.CreateOrUpdate(resourceGroupName, namespaceName, parameter);
            return new PSNamespaceAttributes(response);
        }

        public bool BeginDeleteNamespace(string resourceGroupName, string namespaceName)
        {
            Client.Namespaces.DeleteAsync(resourceGroupName, namespaceName);
            return true;
        }        

        private static void RetryAfter(PSNamespaceLongRunningOperation longrunningResponse, int longRunningOperationInitialTimeout)
        {
            if (longRunningOperationInitialTimeout >= 0)
            {
                //longrunningResponse.RetryAfter = longRunningOperationInitialTimeout;
            }
        }
        #endregion


        #region IP Filter Rule
        public PSIpFilterRuleAttributes CreateOrUpdateIPFilterRule(string resourceGroupName, string namespaceName, string ipfiltername, PSIpFilterRuleAttributes parameter)
        {
            var Parameter1 = new Management.ServiceBus.Models.IpFilterRule();

            if (!string.IsNullOrEmpty(parameter.Action))
            {
                Parameter1.Action = parameter.Action;
            }

            if (!string.IsNullOrEmpty(parameter.Name))
            {
                Parameter1.FilterName = parameter.Name;
            }

            if (!string.IsNullOrEmpty(parameter.IpMask))
            {
                Parameter1.IpMask = parameter.IpMask;
            }

            var response = Client.Namespaces.CreateOrUpdateIpFilterRule(resourceGroupName, namespaceName, ipfiltername, Parameter1);
            return new PSIpFilterRuleAttributes(response);
        }

        // get the IP Filter by name
        public PSIpFilterRuleAttributes GetIPFilterRule(string resourceGroupName, string namespaceName, string ipfiltername)
        {
            var response = Client.Namespaces.GetIpFilterRule(resourceGroupName, namespaceName, ipfiltername);
            return new PSIpFilterRuleAttributes(response);
        }

        //  List IP Filters by Namespace  
        public IEnumerable<PSIpFilterRuleAttributes> ListIPFilterRule(string resourceGroupName, string namespaceName)
        {
            IEnumerable<PSIpFilterRuleAttributes> resourcelist = Enumerable.Empty<PSIpFilterRuleAttributes>();
            var response = Client.Namespaces.ListIpFilterRules(resourceGroupName, namespaceName);
            resourcelist = response.Select(resource => new PSIpFilterRuleAttributes(resource));
            return resourcelist;
        }

        // delete the IP Filter by name
        public bool DeleteIPFilterRule(string resourceGroupName, string namespaceName, string ipfiltername)
        {
            Client.Namespaces.DeleteIpFilterRule(resourceGroupName, namespaceName, ipfiltername);
            return true;
        }
        #endregion

        #region VNet Rule
        public PSVirtualNetWorkRuleAttributes CreateOrUpdateVNetRule(string resourceGroupName, string namespaceName, string vNetRuleName, PSVirtualNetWorkRuleAttributes parameter)
        {
            var Parameter1 = new Management.ServiceBus.Models.VirtualNetworkRule();

            if (!string.IsNullOrEmpty(parameter.VirtualNetworkSubnetId))
            {
                Parameter1.VirtualNetworkSubnetId = parameter.VirtualNetworkSubnetId;
            }

            var response = Client.Namespaces.CreateOrUpdateVirtualNetworkRule(resourceGroupName, namespaceName, vNetRuleName, Parameter1);
            return new PSVirtualNetWorkRuleAttributes(response);
        }

        // get the VNet Rule by name
        public PSVirtualNetWorkRuleAttributes GetVNetRule(string resourceGroupName, string namespaceName, string ipfiltername)
        {
            var response = Client.Namespaces.GetVirtualNetworkRule(resourceGroupName, namespaceName, ipfiltername);
            return new PSVirtualNetWorkRuleAttributes(response);
        }

        //  List VNet Rule by Namespace  
        public IEnumerable<PSVirtualNetWorkRuleAttributes> ListVNetRule(string resourceGroupName, string namespaceName)
        {
            IEnumerable<PSVirtualNetWorkRuleAttributes> resourcelist = Enumerable.Empty<PSVirtualNetWorkRuleAttributes>();
            var listVnetRules = Client.Namespaces.ListVirtualNetworkRules(resourceGroupName, namespaceName);
            resourcelist = listVnetRules.Select(resource => new PSVirtualNetWorkRuleAttributes(resource));
            return resourcelist;
        }

        // delete the VNet Rule by name
        public bool DeleteVNetRule(string resourceGroupName, string namespaceName, string ipfiltername)
        {
            Client.Namespaces.DeleteVirtualNetworkRule(resourceGroupName, namespaceName, ipfiltername);
            return true;
        }
        #endregion

        public static string GenerateRandomKey()
        {
            byte[] key256 = new byte[32];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(key256);
            }

            return Convert.ToBase64String(key256);
        }

        public static int ReturnmaxCountvalueForSwtich(int? maxcount)
        {
            int returnvalue = -1;

            if (maxcount != null && maxcount <= 100)
                returnvalue = 0;
            if (maxcount != null && maxcount > 100)
                returnvalue = 1;

            return returnvalue;
        }
             

        public static ErrorRecord WriteErrorforBadrequest(ErrorResponseException ex)
        {
            if (ex != null && !string.IsNullOrEmpty(ex.Response.Content))
            {
                ErrorResponseContent errorExtract = new ErrorResponseContent();
                errorExtract = JsonConvert.DeserializeObject<ErrorResponseContent>(ex.Response.Content);
                if (!string.IsNullOrEmpty(errorExtract.error.message))
                {
                    return new ErrorRecord(ex, errorExtract.error.message, ErrorCategory.OpenError, ex);
                }
                else
                {
                    return new ErrorRecord(ex, ex.Response.Content, ErrorCategory.OpenError, ex);
                }
            }
            else
            {
                Exception emptyEx = new Exception("Response object empty");
                return new ErrorRecord(emptyEx, "Response object was empty", ErrorCategory.OpenError, emptyEx);
            }
        }
    }
}
