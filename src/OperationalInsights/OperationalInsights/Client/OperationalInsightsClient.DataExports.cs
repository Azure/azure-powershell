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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Rest;
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
                    throw new PSArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
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
                throw new PSInvalidOperationException(string.Format("DataExport: '{0}' already exists in workspace '{1}'. Please use Update-AzOperationalInsightsDataExport for updating.", parameters.DataExportName, parameters.WorkspaceName));
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
                throw new PSArgumentException($"Data export {parameters.DataExportName} under resourceGroup {resourceGroupName} worspace:{parameters.WorkspaceName} does not exist, please use 'New-AzOperationalInsightsDataExport' instead.");
            }

            //validate user input parameters were not null - if they were then use existing values so they wont be ran over by null values
            parameters.TableNames = parameters.TableNames ?? existingDataExport.TableNames;
            parameters.DestinationResourceId = parameters.DestinationResourceId ?? existingDataExport.ResourceId;
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
