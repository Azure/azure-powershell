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
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.ServiceBus
{
    public class ServiceBusClient
    {
         // Azure SDK requires a request parameter to be specified for a few Backup API calls, but
        // the request is actually optional unless an update is needed
       // private static readonly BackupRequest EmptyRequest = new BackupRequest(location: "");

        public ServiceBusClient(IAzureContext context)
        {
            this.Client = AzureSession.Instance.ClientFactory.CreateArmClient<ServiceBusManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        public ServiceBusManagementClient Client
        {
            get;
            private set;
        }

        public PSListKeysAttributes GetNamespaceListKeys(string resourceGroupName, string namespaceName, string authRuleName)
        {
            var listKeys = Client.Namespaces.ListKeys(resourceGroupName, namespaceName, authRuleName);
            return new PSListKeysAttributes(listKeys);
        }

        public PSListKeysAttributes GetTopicKey(string resourceGroupName, string namespaceName, string topicName, string authRuleName)
        {
            var listKeys = Client.Topics.ListKeys(resourceGroupName, namespaceName, topicName, authRuleName);
            return new PSListKeysAttributes(listKeys);
        }


        public PSTopicAttributes GetTopic(string resourceGroupName, string namespaceName, string topicName)
        {
            SBTopic response = Client.Topics.Get(resourceGroupName, namespaceName, topicName);
            return new PSTopicAttributes(response);
        }

        public PSListKeysAttributes GetQueueKey(string resourceGroupName, string namespaceName, string queueName, string authRuleName)
        {
            var listKeys = Client.Queues.ListKeys(resourceGroupName, namespaceName, queueName, authRuleName);
            return new PSListKeysAttributes(listKeys);
        }

        public PSQueueAttributes GetQueue(string resourceGroupName, string namespaceName, string queueName)
        {
            SBQueue response = Client.Queues.Get(resourceGroupName, namespaceName, queueName);
            return new PSQueueAttributes(response);
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
