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

using Microsoft.Azure.Commands.Synapse.Common;

namespace Microsoft.Azure.Commands.Synapse.Models.DataClassification
{
    public static class DataClassificationCommon
    {
        internal const string SqlPoolObjectColumnParameterSet = "SqlPoolObjectColumnParameterSet";
        internal const string ColumnParameterSet = "ColumnParameterSet";
        internal const string SqlPoolObjectParameterSet = "SqlPoolObjectParameterSet";
        internal const string ClassificationObjectParameterSet = "ClassificationObjectParameterSet";
        internal const string SqlPoolParameterSet = "SqlPoolParameterSet";
        internal const string InputObjectParameterSet = "InputObjectParameterSet";
        internal const string SqlPoolSensitivityRecommendation = nameof(SqlPoolSensitivityRecommendation);
        internal const string SqlPoolSensitivityClassification = nameof(SqlPoolSensitivityClassification);

        internal const string ResourceGroupNameHelpMessage = HelpMessages.ResourceGroupName;
        internal const string WorkspaceNameHelpMessage = HelpMessages.WorkspaceName;
        internal const string SqlPoolNameHelpMessage = HelpMessages.SqlPoolName;
        internal const string LabelNameHelpMessage = "A name that describes the sensitivity of the data stored in the column.";
        internal const string InformationTypeHelpMessage = "A name that describes the information type of the data stored in the column.";
        internal const string SqlPoolObjectHelpMessage = HelpMessages.SqlPoolObject;
        internal const string SqlPoolSensitivityClassificationObjectHelpMessage = "An object representing a SQL Pool Sensitivity Classification.";
        internal const string PassThruHelpMessage = HelpMessages.PassThru;
        internal const string AsJobHelpMessage = HelpMessages.AsJob;
        internal const string SchemaNameHelpMessage = "Name of schema.";
        internal const string TableNameHelpMessage = "Name of table.";
        internal const string ColumnNameHelpMessage = "Name of column.";
        internal const string InputObjectParameterAlias = "ClassificationObject";
    }
}
