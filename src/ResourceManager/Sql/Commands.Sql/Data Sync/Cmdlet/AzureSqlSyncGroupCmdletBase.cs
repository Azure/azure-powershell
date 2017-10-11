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
using System.IO;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Commands.Sql.DataSync.Services;
using Microsoft.Azure.Management.Sql.Models;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// The base class for all sync group cmdlets
    /// </summary>
    public abstract class AzureSqlSyncGroupCmdletBase : AzureSqlDatabaseCmdletBase<IEnumerable<AzureSqlSyncGroupModel>, AzureSqlDataSyncAdapter>
    {
        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <param name="subscription">The Azure Subscription in which the current execution is performed</param>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override AzureSqlDataSyncAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlDataSyncAdapter(DefaultProfile.DefaultContext);
        }

        /// <summary>
        /// Construct schema for schema file
        /// </summary>
        /// <param name="filePath">The path of the schema file</param>
        /// <returns>A schema object of member database</returns>
        protected static AzureSqlSyncGroupSchemaModel ConstructSchemaFromFile(string filePath)
        {
            try
            {
                JObject jSchema = JObject.Parse(File.ReadAllText(filePath));
                return ConstructSchemaFromJObject(jSchema);
            }
            catch (Newtonsoft.Json.JsonReaderException)
            {
                throw new PSArgumentException("The schema file is empty or invalid!", "SchemaFile");
            }
        }

        /// <summary>
        /// Construct schema for schema object
        /// </summary>
        /// <param name="jSchema">JObject containing description of the schema</param>
        /// <returns>A schema object of member database</returns>
        public static AzureSqlSyncGroupSchemaModel ConstructSchemaFromJObject(JObject jSchema)
        {
            AzureSqlSyncGroupSchemaModel schema = new AzureSqlSyncGroupSchemaModel();
            JToken masterSyncMemberName = jSchema.GetValue("masterSyncMemberName", StringComparison.InvariantCultureIgnoreCase);
            schema.MasterSyncMemberName = masterSyncMemberName == null ? null : masterSyncMemberName.ToString();
            List<AzureSqlSyncGroupSchemaTableModel> tables = new List<AzureSqlSyncGroupSchemaTableModel>();
            JArray jTables = (JArray)jSchema.GetValue("tables", StringComparison.InvariantCultureIgnoreCase);
            if (jTables != null)
            {
                foreach (var jTableToken in jTables.Children())
                {
                    if (jTableToken.Type == JTokenType.Object)
                    {
                        JObject jTable = (JObject)jTableToken;
                        AzureSqlSyncGroupSchemaTableModel table = new AzureSqlSyncGroupSchemaTableModel();
                        JToken tableQuotedNameToken = jTable.GetValue("quotedName", StringComparison.InvariantCultureIgnoreCase);
                        table.QuotedName = tableQuotedNameToken == null ? null : tableQuotedNameToken.ToString();
                        List<AzureSqlSyncGroupSchemaColumnModel> columns = new List<AzureSqlSyncGroupSchemaColumnModel>();
                        JArray jColumns = (JArray)jTable.GetValue("columns", StringComparison.InvariantCultureIgnoreCase);
                        if (jColumns != null)
                        {
                            foreach (var jColumnToken in jColumns.Children())
                            {
                                if (jColumnToken.Type == JTokenType.Object)
                                {
                                    AzureSqlSyncGroupSchemaColumnModel column = new AzureSqlSyncGroupSchemaColumnModel();
                                    JToken columnQuotedNameToken = ((JObject)jColumnToken).GetValue("quotedName", StringComparison.InvariantCultureIgnoreCase);
                                    column.QuotedName = columnQuotedNameToken == null ? null : columnQuotedNameToken.ToString();
                                    columns.Add(column);
                                }
                            }
                        }
                        table.Columns = columns;
                        tables.Add(table);
                    }
                }
            }
            schema.Tables = tables;
            return schema;
        }
    }
}
