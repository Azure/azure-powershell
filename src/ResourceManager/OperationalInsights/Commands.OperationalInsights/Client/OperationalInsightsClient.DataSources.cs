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

using Hyak.Common;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual PSDataSource GetDataSource(string resourceGroupName, string workspaceName, string dataSourceName)
        {
            var response = OperationalInsightsManagementClient.DataSources.Get(resourceGroupName, workspaceName, dataSourceName);
            
            return new PSDataSource(response.DataSource, resourceGroupName, workspaceName);
        }
        
        public virtual List<PSDataSource> ListDataSources(string resourceGroupName, string workspaceName, string kind)
        {
            List<PSDataSource> dataSources = new List<PSDataSource>();
            
            // List data sources by kind
            var response = OperationalInsightsManagementClient.DataSources.ListInWorkspace(resourceGroupName, workspaceName, kind, string.Empty);
            while (null != response)
            {
                if (response.DataSources != null)
                {
                    response.DataSources.ForEach(ds => dataSources.Add(new PSDataSource(ds, resourceGroupName, workspaceName)));
                }
                if (!string.IsNullOrEmpty(response.NextLink))
                {
                    response = OperationalInsightsManagementClient.DataSources.ListNext(response.NextLink);
                }
                else
                {
                    break;
                }
            }
            
            return dataSources;
        }
        
        public virtual HttpStatusCode DeleteDataSource(string resourceGroupName, string workspaceName, string dataSourceName)
        {
            AzureOperationResponse response = OperationalInsightsManagementClient.DataSources.Delete(resourceGroupName, workspaceName, dataSourceName);
            return response.StatusCode;
        }
        
        public virtual DataSource CreateOrUpdateDataSource(
            string resourceGroupName,
            string workspaceName,
            string name,
            PSDataSourcePropertiesBase dataSourceProperties)
        {
            var serializedProperties = JsonConvert.SerializeObject(dataSourceProperties);
            
            var response = OperationalInsightsManagementClient.DataSources.CreateOrUpdate(
                resourceGroupName,
                workspaceName,
                new DataSourceCreateOrUpdateParameters
                {
                    DataSource = new DataSource { Name = name, Kind=dataSourceProperties.Kind, Properties = serializedProperties}
                });
            
            return response.DataSource;
        }
        
        public virtual PSDataSource UpdatePSDataSource(UpdatePSDataSourceParameters parameters)
        {
            // Get the existing data source
            DataSourceGetResponse response = OperationalInsightsManagementClient.DataSources.Get(parameters.ResourceGroupName, parameters.WorkspaceName, parameters.Name);
            DataSource dataSource = response.DataSource;
            
            if (parameters.Properties.Kind != dataSource.Kind)
            {
                throw new ArgumentException(Resources.DataSourceUpdateCannotModifyKind);
            }
            if (parameters.Name != dataSource.Name)
            {
                throw new ArgumentException(Resources.DataSourceUpdateCannotModifyName);
            }
            
            // Execute the update
            DataSource updatedDataSource = CreateOrUpdateDataSource(
                parameters.ResourceGroupName,
                parameters.WorkspaceName,
                dataSource.Name,
                parameters.Properties);
            
            return new PSDataSource(updatedDataSource, parameters.ResourceGroupName, parameters.WorkspaceName);
        }
        
        public virtual PSDataSource CreatePSDataSource(CreatePSDataSourceParameters parameters)
        {
            PSDataSource dataSource = null;
            Action createDataSource = () =>
            {
                dataSource =
                    new PSDataSource(
                        CreateOrUpdateDataSource(
                            parameters.ResourceGroupName,
                            parameters.WorkspaceName,
                            parameters.Name,
                            parameters.Properties),
                        parameters.ResourceGroupName,
                        parameters.WorkspaceName);
            };
            
            parameters.ConfirmAction(
                parameters.Force,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DataSourceExists,
                    parameters.Name,
                    parameters.WorkspaceName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DataSourceNotFound,
                    parameters.Name,
                    parameters.WorkspaceName),
                parameters.Name,
                createDataSource,
                () => CheckDataSourceExists(parameters.ResourceGroupName,
                    parameters.WorkspaceName, parameters.Name));
            return dataSource;
        }
        
        public virtual List<PSDataSource> FilterPSDataSources(string resourceGroupName, string workspaceName, string kind)
        {
            List<PSDataSource> dataSources = new List<PSDataSource>();
            
            if (string.IsNullOrWhiteSpace(resourceGroupName) || string.IsNullOrWhiteSpace(workspaceName))
            {
                throw new ArgumentException(Resources.WorkspaceDetailsCannotBeEmpty);
            }
            
            if (string.IsNullOrWhiteSpace(kind))
            {
                throw new ArgumentException(Resources.DataSourceKindCannotBeEmpty);
            }
            
            dataSources.AddRange(ListDataSources(resourceGroupName, workspaceName, kind));
            
            return dataSources;
        }
        
        public PSDataSource GetSingletonDataSource(string resourceGroup, string workspaceName, string dataSourceKind)
        {
            List<PSDataSource> dataSources;
            if (dataSourceKind == PSDataSourceKinds.IISLogs
                || dataSourceKind == PSDataSourceKinds.LinuxPerformanceCollection
                || dataSourceKind == PSDataSourceKinds.LinuxSyslogCollection
                || dataSourceKind == PSDataSourceKinds.CustomLogCollection)
            {
                dataSources = this.FilterPSDataSources(resourceGroup, workspaceName, dataSourceKind);
            }
            else
            {
                throw new ArgumentException(String.Format(Resources.DataSourceEnableNotSupported, dataSourceKind));
            }
            
            if (dataSources.Count > 1) { throw new Exception(Resources.DataSourceSingletonMultipleRecord); }
            if (dataSources.Count == 1)
            {
                return dataSources[0];
            }
            return null;
        }
        
        private bool CheckDataSourceExists(string resourceGroupName, string workspaceName, string dataSourceName)
        {
            try
            {
                PSDataSource datasource = GetDataSource(resourceGroupName, workspaceName, dataSourceName);
                return true;
            }
            catch (CloudException e)
            {
                // Get throws NotFound exception if workspace does not exist
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                throw;
            }
        }
    }
}
