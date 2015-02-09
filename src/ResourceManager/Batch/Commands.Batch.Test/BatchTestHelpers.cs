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

using System.Net;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.Entities;
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test
{
    public static class BatchTestHelpers
    {
        /// <summary>
        /// Builds an AccountResource object using the specified parameters
        /// </summary>
        public static AccountResource CreateAccountResource(string accountName, string resourceGroupName, Hashtable[] tags = null)
        {
            string tenantUrlEnding = "batch-test.windows-int.net";
            string endpoint = string.Format("{0}.{1}", accountName, tenantUrlEnding);
            string subscription = "00000000-0000-0000-0000-000000000000";
            string resourceGroup = resourceGroupName;

            AccountResource resource = new AccountResource()
            {
                Id = string.Format("id/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Batch/batchAccounts/abc", subscription, resourceGroup),
                Location = "location",
                Properties = new AccountProperties() { AccountEndpoint = endpoint, ProvisioningState = AccountProvisioningState.Succeeded },
                Type = "type"
            };
            if (tags != null)
            {
                resource.Tags = Microsoft.Azure.Commands.Batch.Helpers.CreateTagDictionary(tags, true);
            }

            return resource;
        }

        /// <summary>
        /// Builds a BatchAccountContext object with the keys set for testing
        /// </summary>
        public static BatchAccountContext CreateBatchContextWithKeys()
        {
            AccountResource resource = CreateAccountResource("account", "resourceGroup");
            BatchAccountContext context = BatchAccountContext.ConvertAccountResourceToNewAccountContext(resource);
            string dummyKey = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            SetProperty(context, "PrimaryAccountKey", dummyKey);
            SetProperty(context, "SecondaryAccountKey", dummyKey);

            return context;
        }


        /// <summary>
        /// Verifies that two BatchAccountContext objects are equal
        /// </summary>
        public static void AssertBatchAccountContextsAreEqual(BatchAccountContext context1, BatchAccountContext context2)
        {
            if (context1 == null)
            {
                Assert.Null(context2);
                return;
            }
            if (context2 == null)
            {
                Assert.Null(context1);
                return;
            }

            Assert.Equal<string>(context1.AccountEndpoint, context2.AccountEndpoint);
            Assert.Equal<string>(context1.AccountName, context2.AccountName);
            Assert.Equal<string>(context1.Id, context2.Id);
            Assert.Equal<string>(context1.Location, context2.Location);
            Assert.Equal<string>(context1.PrimaryAccountKey, context2.PrimaryAccountKey);
            Assert.Equal<string>(context1.ResourceGroupName, context2.ResourceGroupName);
            Assert.Equal<string>(context1.SecondaryAccountKey, context2.SecondaryAccountKey);
            Assert.Equal<string>(context1.State, context2.State);
            Assert.Equal<string>(context1.Subscription, context2.Subscription);
            Assert.Equal<string>(context1.TagsTable, context2.TagsTable);
            Assert.Equal<string>(context1.TaskTenantUrl, context2.TaskTenantUrl);
        }

        /// <summary>
        /// Builds a GetPoolResponse object
        /// </summary>
        public static GetPoolResponse CreateGetPoolResponse(string poolName)
        {
            GetPoolResponse response = new GetPoolResponse();
            SetProperty(response, "StatusCode", HttpStatusCode.OK);

            Pool pool = new Pool();
            SetProperty(pool, "Name", poolName);

            SetProperty(response, "Pool", pool);

            return response;
        }

        /// <summary>
        /// Builds a ListPoolsResponse object
        /// </summary>
        public static ListPoolsResponse CreateListPoolsResponse(IEnumerable<string> poolNames)
        {
            ListPoolsResponse response = new ListPoolsResponse();
            SetProperty(response, "StatusCode", HttpStatusCode.OK);

            List<Pool> pools = new List<Pool>();

            foreach (string name in poolNames)
            {
                Pool pool = new Pool();
                SetProperty(pool, "Name", name);
                pools.Add(pool);
            }

            SetProperty(response, "Pools", pools);

            return response;
        }

        /// <summary>
        /// Builds a GetWorkItemResponse object
        /// </summary>
        public static GetWorkItemResponse CreateGetWorkItemResponse(string workItemName)
        {
            GetWorkItemResponse response = new GetWorkItemResponse();
            SetProperty(response, "StatusCode", HttpStatusCode.OK);

            JobExecutionEnvironment jee = new JobExecutionEnvironment();

            WorkItem workItem = new WorkItem(workItemName, jee);
            SetProperty(response, "WorkItem", workItem);

            return response;
        }

        /// <summary>
        /// Builds a ListWorkItemsResponse object
        /// </summary>
        public static ListWorkItemsResponse CreateListWorkItemsResponse(IEnumerable<string> workItemNames)
        {
            ListWorkItemsResponse response = new ListWorkItemsResponse();
            SetProperty(response, "StatusCode", HttpStatusCode.OK);

            List<WorkItem> workItems = new List<WorkItem>();
            JobExecutionEnvironment jee = new JobExecutionEnvironment();

            foreach (string name in workItemNames)
            {
                workItems.Add(new WorkItem(name, jee));
            }

            SetProperty(response, "WorkItems", workItems);

            return response;
        }

        /// <summary>
        /// Uses Reflection to set a property value on an object. Can be used to bypass restricted set accessors.
        /// </summary>
        private static void SetProperty(object obj, string propertyName, object propertyValue)
        {
            Type t = obj.GetType();
            PropertyInfo propInfo = t.GetProperty(propertyName);
            propInfo.SetValue(obj, propertyValue);
        }
    }
}
