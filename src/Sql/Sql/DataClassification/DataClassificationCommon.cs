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
namespace Microsoft.Azure.Commands.Sql.DataClassification
{
    public static class DataClassificationCommon
    {
        internal const string DatabaseObjectColumnParameterSet = "DatabaseObjectColumnParameterSet";
        internal const string ColumnParameterSet = "ColumnParameterSet";
        internal const string DatabaseObjectParameterSet = "DatabaseObjectParameterSet";
        internal const string ClassificationObjectParameterSet = "ClassificationObjectParameterSet";
        internal const string DatabaseParameterSet = "DatabaseParameterSet";
        internal const string SqlDatabaseSensitivityClassification = "SqlDatabaseSensitivityClassification";
        internal const string SqlInstanceDatabaseSensitivityClassification = "SqlInstanceDatabaseSensitivityClassification";
        internal const string ResourceGroupNameHelpMessage = "The name of the resource group.";
        internal const string ServerNameHelpMessage = "SQL server name.";
        internal const string InstanceNameHelpMessage = "Azure SQL managed instance name.";
        internal const string DatabaseNameHelpMessage = "The name of the Azure SQL database.";
        internal const string ManagedDatabaseNameHelpMessage = "The name of the Azure SQL managed instance database.";
        internal const string LabelNameHelpMessage = "A name that describes the sensitivity of the data stored in the column.";
        internal const string InformationTypeHelpMessage = "A name that describes the information type of the data stored in the column.";
        internal const string SqlDatabaseObjectHelpMessage = "The SQL database object.";
        internal const string ManagedDatabaseObjectHelpMessage = "The Azure SQL managed instance database object.";
        internal const string SqlDatabaseSensitivityClassificationObjectHelpMessage = "An object representing a SQL Database Sensitivity Classification.";
        internal const string ManagedDatabaseSensitivityClassificationObjectHelpMessage = "An object representing a SQL Managed Instance Database Sensitivity Classification.";
        internal const string PassThruHelpMessage = "Specifies whether to output the sensitivity classification model at end of cmdlet execution";
        internal const string AsJobHelpMessage = "Run cmdlet in the background";
        internal const string SchemaNameHelpMessage = "Name of schema.";
        internal const string TableNameHelpMessage = "Name of table.";
        internal const string ColumnNameHelpMessage = "Name of column.";
    }
}
