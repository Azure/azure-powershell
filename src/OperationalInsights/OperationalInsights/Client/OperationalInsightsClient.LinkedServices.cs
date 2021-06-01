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
                throw new System.ArgumentException($"linked service {linkedServiceName} for {workspaceName} is not existed");
            }

            parameters.Tags = parameters.Tags == null
                ? existingLinkedService.Tags
                : parameters.Tags;

            parameters.ResourceId = string.IsNullOrEmpty(parameters.ResourceId)
                ? existingLinkedService.ResourceId
                : parameters.ResourceId;

            parameters.WriteAccessResourceId = string.IsNullOrEmpty(parameters.WriteAccessResourceId)
                ? existingLinkedService.WriteAccessResourceId
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
