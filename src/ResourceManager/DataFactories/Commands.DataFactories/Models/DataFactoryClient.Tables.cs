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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.WindowsAzure;

namespace Microsoft.Azure.Commands.DataFactories
{
    public partial class DataFactoryClient
    {
        public virtual Table CreateOrUpdateTable(string resourceGroupName, string dataFactoryName, string tableName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            // If create or update failed, the current behavior is to throw
            var response = DataPipelineManagementClient.Tables.CreateOrUpdateWithRawJsonContent(
                resourceGroupName,
                dataFactoryName,
                tableName,
                new TableCreateOrUpdateWithRawJsonContentParameters() { Content = rawJsonContent });

            return response.Table;
        }

        public virtual PSTable GetTable(string resourceGroupName, string dataFactoryName, string tableName)
        {
            var response = DataPipelineManagementClient.Tables.Get(
                resourceGroupName, dataFactoryName, tableName);

            return new PSTable(response.Table)
            {
                ResourceGroupName = resourceGroupName,
                DataFactoryName = dataFactoryName
            };
        }

        public virtual List<PSTable> ListTables(string resourceGroupName, string dataFactoryName)
        {
            List<PSTable> tables = new List<PSTable>();

            var response = DataPipelineManagementClient.Tables.List(resourceGroupName, dataFactoryName);

            if (response != null && response.Tables != null)
            {
                foreach (var table in response.Tables)
                {
                    tables.Add(
                        new PSTable(table)
                        {
                            ResourceGroupName = resourceGroupName,
                            DataFactoryName = dataFactoryName
                        });
                }
            }

            return tables;
        }

        public virtual HttpStatusCode DeleteTable(string resourceGroupName, string dataFactoryName, string tableName)
        {
            OperationResponse response = DataPipelineManagementClient.Tables.Delete(resourceGroupName, dataFactoryName, tableName);
            return response.StatusCode;
        }

        public virtual List<PSTable> FilterPSTables(TableFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            if (string.IsNullOrWhiteSpace(filterOptions.ResourceGroupName))
            {
                throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
            }

            List<PSTable> tables = new List<PSTable>();

            if (!string.IsNullOrWhiteSpace(filterOptions.Name))
            {
                tables.Add(GetTable(filterOptions.ResourceGroupName, filterOptions.DataFactoryName, filterOptions.Name));
            }
            else
            {
                tables.AddRange(ListTables(filterOptions.ResourceGroupName, filterOptions.DataFactoryName));
            }

            return tables;
        }

        public virtual PSTable CreatePSTable(CreatePSTableParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            PSTable table = null;
            Action createTable = () =>
            {
                table =
                    new PSTable(CreateOrUpdateTable(
                        parameters.ResourceGroupName,
                        parameters.DataFactoryName,
                        parameters.Name,
                        parameters.RawJsonContent))
                    {
                        ResourceGroupName = parameters.ResourceGroupName,
                        DataFactoryName = parameters.DataFactoryName
                    };
            };

            if (parameters.Force)
            {
                // If user decides to overwrite anyway, then there is no need to check if the table exists or not.
                createTable();
            }
            else
            {
                bool tableExists = CheckTableExists(parameters.ResourceGroupName, parameters.DataFactoryName,
                    parameters.Name);

                parameters.ConfirmAction(
                    !tableExists,  // prompt only if the table exists
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.TableExists,
                        parameters.Name,
                        parameters.DataFactoryName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.TableCreating,
                        parameters.Name,
                        parameters.DataFactoryName),
                    parameters.Name,
                    createTable);
            }

            return table;
        }

        private bool CheckTableExists(string resourceGroupName, string dataFactoryName, string tableName)
        {
            // ToDo: implement HEAD to check if the table exists
            try
            {
                PSTable table = GetTable(resourceGroupName, dataFactoryName, tableName);

                return true;
            }
            catch (CloudException e)
            {
                //Get throws Exception message with NotFound Status
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
