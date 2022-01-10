// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Management.OperationalInsights;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual PSLinkedService GetPSLinkedService(string resourceGroupName, string workspaceName, string linkedServiceName)
        {
            return new PSLinkedService(this.OperationalInsightsManagementClient.LinkedServices.Get(resourceGroupName, workspaceName, linkedServiceName));
        }

        public virtual IList<PSLinkedService> ListPSLinkedServices(string resourceGroupName, string workspaceName)
        {
            return this.OperationalInsightsManagementClient
                .LinkedServices
                .ListByWorkspace(resourceGroupName, workspaceName)
                .Select(item => new PSLinkedService(item))
                .ToList();
        }

        public virtual IList<PSLinkedService> FilterLinkedServices(string resourceGroupName, string workspaceName, string linkedServiceName)
        {
            List<PSLinkedService> list = new List<PSLinkedService>();
            if (string.IsNullOrEmpty(linkedServiceName))
            {
                list.AddRange(ListPSLinkedServices(resourceGroupName, workspaceName));
            }
            else
            {
                list.Add(GetPSLinkedService(resourceGroupName, workspaceName, linkedServiceName));
            }

            return list;
        }

        public virtual PSLinkedService SetPSLinkedService(string resourceGroupName, string workspaceName, string linkedServiceName, PSLinkedService parameters)
        {
            PSLinkedService existingLinkedService;
            try
            {
                existingLinkedService = GetPSLinkedService(resourceGroupName, workspaceName, linkedServiceName);
            }
            catch (RestException)
            {
                //linkedService was not found - do nothing
                existingLinkedService = null;
            }

            parameters.Tags = parameters.Tags == null
                ? existingLinkedService?.Tags
                : parameters.Tags;

            parameters.ResourceId = string.IsNullOrEmpty(parameters.ResourceId)
                ? existingLinkedService?.ResourceId
                : parameters.ResourceId;

            parameters.WriteAccessResourceId = string.IsNullOrEmpty(parameters.WriteAccessResourceId)
                ? existingLinkedService?.WriteAccessResourceId
                : parameters.WriteAccessResourceId;

            return new PSLinkedService(this.OperationalInsightsManagementClient.LinkedServices.CreateOrUpdate(resourceGroupName, workspaceName, linkedServiceName, parameters.getLinkedService()));
        }

        public virtual HttpStatusCode DeletePSLinkedService(string resourceGroupName, string workspaceName, string linkedServiceName)
        {
            return this.OperationalInsightsManagementClient.LinkedServices
                .DeleteWithHttpMessagesAsync(resourceGroupName, workspaceName, linkedServiceName)
                .GetAwaiter()
                .GetResult()
                .Response
                .StatusCode;
        }
    }
}
