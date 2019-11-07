﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    public abstract class ModifyAzSqlInstanceDatabaseSensitivityCmdlet : AzureSqlCmdletBase<ManagedDatabaseSensitivityClassificationModel, DataClassificationAdapter>
    {
        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = DataClassificationCommon.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = DataClassificationCommon.InstanceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = DataClassificationCommon.ManagedDatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DataClassificationCommon.ManagedDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public AzureSqlManagedDatabaseModel DatabaseObject { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.SchemaNameHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.SchemaNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SchemaName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.TableNameHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.SchemaNameHelpMessage)]
        public string TableName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.ColumnNameHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.ColumnNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ColumnName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = DataClassificationCommon.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = DataClassificationCommon.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        protected override DataClassificationAdapter InitModelAdapter() => new DataClassificationAdapter(DefaultProfile.DefaultContext);

        protected override bool WriteResult() => PassThru;

        protected override object TransformModelToOutputObject(ManagedDatabaseSensitivityClassificationModel model) => true;
    }
}