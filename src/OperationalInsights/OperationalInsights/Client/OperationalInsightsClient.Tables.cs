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

        public virtual PSTable UpdatePSTable(UpdatePSTableParameters parameters)
        {
            var response = OperationalInsightsManagementClient.Tables.Update(
                resourceGroupName: parameters.ResourceGroupName,
                workspaceName: parameters.WorkspaceName,
                tableName: parameters.TableName,
                retentionInDays: parameters.RetentionInDays);

            return new PSTable(response);
        }

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

        public virtual PSTable GetTable(string resourceGroupName, string workspaceName, string tableName)
        {
            return new PSTable(OperationalInsightsManagementClient.Tables.Get(resourceGroupName, workspaceName, tableName));
        }
    }
}
