using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.OperationalInsights.Properties;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {

        public virtual List<PSDataExport> FilterPSDataExports(string resourceGroupName, string workspaceName, string dataExportName = null)
        {
            List<PSDataExport> dataExports = new List<PSDataExport>();

            if (!string.IsNullOrWhiteSpace(dataExportName))
            {
                if (string.IsNullOrWhiteSpace(resourceGroupName))
                {
                    throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
                }

                dataExports.Add(GetPSDataExport(resourceGroupName, workspaceName, dataExportName));
            }
            else
            {
                dataExports.AddRange(ListPSDataExports(resourceGroupName, workspaceName));
            }

            return dataExports;
        }

        public virtual PSDataExport GetPSDataExport(string resourceGroupName, string workspaceName, string dataExportName)
        {
            return new PSDataExport(OperationalInsightsManagementClient.DataExports.Get(resourceGroupName, workspaceName, dataExportName));
        }

        public virtual List<PSDataExport> ListPSDataExports(string resourceGroupName, string workspaceName)
        {
            List<PSDataExport> dataExports = new List<PSDataExport>();
            var responseDataExports = OperationalInsightsManagementClient.DataExports.ListByWorkspace(resourceGroupName, workspaceName);

            if (responseDataExports != null)
            {
                dataExports.AddRange(from DataExport dataExport in responseDataExports select new PSDataExport(dataExport));
            }

            return dataExports;
        }

        public virtual PSDataExport CreateDataExport(string resourceGroupName, CreatePSDataExportParameters parameters)
        {
            PSDataExport existingDataExport;
            try
            {
                existingDataExport = GetPSDataExport(resourceGroupName, parameters.WorkspaceName, parameters.DataExportName);
            }
            catch (RestException)
            {
                existingDataExport = null;
            }

            if (existingDataExport != null)
            {
                throw new PSInvalidOperationException(string.Format("DataExport: '{0}' already exists in workspace '{1}'. Please use Update-AzOperationalInsightsDataExport for updating.", parameters.DataExportName, parameters.WorkspaceName)); // TODO Test if a Data Export already exists tiwht this name - what exeption is throwen
            }

            return new PSDataExport(OperationalInsightsManagementClient.DataExports.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                workspaceName: parameters.WorkspaceName,
                dataExportName: parameters.DataExportName,
                parameters: PSDataExport.getDataExport(parameters)));
        }

        public virtual PSDataExport UpdateDataExport(string resourceGroupName, CreatePSDataExportParameters parameters)
        {
            PSDataExport existingDataExport;
            try
            {
                existingDataExport = GetPSDataExport(resourceGroupName, parameters.WorkspaceName, parameters.DataExportName);
            }
            catch (RestException)
            {
                throw new ArgumentException($"Data export {parameters.DataExportName} under resourceGroup {resourceGroupName} worspace:{parameters.WorkspaceName} does not exist");
            }

            //validate user input parameters were not null - if they were then use existing values so they wont be ran over by null values
            parameters.TableNames = parameters.TableNames ?? existingDataExport.TableNames.ToArray();
            parameters.ResourceId = parameters.ResourceId ?? existingDataExport.ResourceId;
            parameters.EventHubName = parameters.EventHubName ?? existingDataExport.EventHubName;
            parameters.Enable = parameters.Enable ?? existingDataExport.Enable;


            return new PSDataExport(OperationalInsightsManagementClient.DataExports.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                workspaceName: parameters.WorkspaceName,
                dataExportName: parameters.DataExportName,
                parameters: PSDataExport.getDataExport(parameters)));
        }


        public virtual HttpStatusCode DeleteDataExports(string resourceGroupName, string workspaceName, string dataExportName)
        {
            Rest.Azure.AzureOperationResponse result = OperationalInsightsManagementClient.DataExports.DeleteWithHttpMessagesAsync(resourceGroupName, workspaceName, dataExportName).GetAwaiter().GetResult();
            return result.Response.StatusCode;
        }
    }
}
