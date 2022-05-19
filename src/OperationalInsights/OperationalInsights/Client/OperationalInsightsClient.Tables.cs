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
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual List<PSTable> FilterPSTables(string resourceGroupName, string workspaceName, string tableName = null)
        {
            List<PSTable> tables = new List<PSTable>();

            if (!string.IsNullOrWhiteSpace(tableName))
            {
                if (string.IsNullOrWhiteSpace(resourceGroupName))
                {
                    throw new PSArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
                }

                tables.Add(GetTable(resourceGroupName, workspaceName, tableName));
            }
            else
            {
                tables.AddRange(ListPSTables(resourceGroupName, workspaceName));
            }

            return tables;
        }

        /// <summary>
        /// Updates a table it it exists
        /// </summary>
        /// <param name="parameters">New table parameters for update</param>
        /// <returns>Updated table object</returns>
        /// <exception cref="PSArgumentException">Thrown if table does not exist</exception>
        public virtual PSTable UpdatePSTable(PSTable parameters)
        {
            PSTable existingTable = null;
            try
            {
                existingTable = this.GetTable(parameters.ResourceGroupName, parameters.WorkspaceName, parameters.TableName);
            }
            catch (System.Exception)
            {
                throw new PSArgumentException(string.Format(Constants.TableDoesNotExist, parameters?.WorkspaceName, parameters?.ResourceGroupName, parameters?.TableName));
            }

            var response = OperationalInsightsManagementClient.Tables.Update(
                resourceGroupName: parameters.ResourceGroupName,
                workspaceName: parameters.WorkspaceName,
                tableName: parameters.TableName,
                parameters: parameters.ToTableProperties());

            return new PSTable(response);
        }

        /// <summary>
        /// List tables for a given workspace
        /// </summary>
        /// <param name="resourceGroupName">Resource group for operation</param>
        /// <param name="workspaceName">Workspace name for operation</param>
        /// <returns>A list of tables for a given workspace</returns>
        public virtual List<PSTable> ListPSTables(string resourceGroupName, string workspaceName)
        {
            List<PSTable> tables = new List<PSTable>();
            var responseTables = OperationalInsightsManagementClient.Tables.ListByWorkspace(resourceGroupName, workspaceName);

            if (responseTables != null)
            {
                tables.AddRange(from Table tbl in responseTables select new PSTable(tbl));
            }

            return tables;
        }

        /// <summary>
        /// Gets a table by resource group, workspace and table names.
        /// </summary>
        /// <param name="resourceGroupName">Resource group for operation</param>
        /// <param name="workspaceName">Workspace name for operation</param>
        /// <param name="tableName">Table name for operation</param>
        /// <returns>Table object</returns>
        public virtual PSTable GetTable(string resourceGroupName, string workspaceName, string tableName)
        {
            return new PSTable(OperationalInsightsManagementClient.Tables.Get(resourceGroupName, workspaceName, tableName));
        }

        /// <summary>
        /// Migrate a Log Analytics table from support of the Data Collector API and Custom Fields features to support of Data Collection Rule-based Custom Logs
        /// </summary>
        /// <param name="resourceGroupName">Resource group for operation</param>
        /// <param name="workspaceName">Workspace name for operation</param>
        /// <param name="tableName">Table name for operation</param>
        /// <returns>HttpStatusCode indicating success or failure</returns>
        /// <exception cref="PSArgumentException">Thrown if table does not exist</exception>
        public virtual HttpStatusCode MigratePSTable(string resourceGroupName, string workspaceName, string tableName)
        {
            PSTable existingTable = null;
            try
            {
                existingTable = this.GetTable(resourceGroupName, workspaceName, tableName);
            }
            catch (System.Exception)
            {
                throw new PSArgumentException(string.Format(Constants.TableDoesNotExist, workspaceName, resourceGroupName, tableName));
            }

            return OperationalInsightsManagementClient.Tables.MigrateWithHttpMessagesAsync(resourceGroupName, workspaceName, tableName).Result.Response.StatusCode;
        }
    }
}
