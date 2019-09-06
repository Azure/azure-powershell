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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using Microsoft.Rest.Azure;


namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// Defines Remove-AzSqlVMGroup cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVMGroup", DefaultParameterSetName = ParameterSet.ParameterList, ConfirmImpact = ConfirmImpact.Medium, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlVMGroupModel))]
    public class RemoveAzureSqlVMGroup : AzureSqlVMGroupCmdletBase
    {
        /// <summary>
        /// Sql virtual machine group resource to be removed
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.InputObject,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            HelpMessage = HelpMessages.InputObjectSqlVMGroup)]
        [Alias("InputObject")]
        [ValidateNotNullOrEmpty]
        public AzureSqlVMGroupModel SqlVMGroup { get; set; }

        /// <summary>
        /// Resource id of the sql virtual machine group that will be removed
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.ResourceId,
            Position = 0,
            HelpMessage = HelpMessages.SqlVMGroupResourceId)]
        [Alias("ResourceId")]
        [ValidateNotNullOrEmpty]
        public string SqlVMGroupId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Parse the input of the cmdlet depending on the parameter set provided. Retrieve the resource group name and the resource name.
        /// </summary>
        protected override void ParseInput()
        {
            if(ParameterSetName == ParameterSet.InputObject)
            {
                SqlVMGroupName = SqlVMGroup.Name;
                ResourceGroupName = SqlVMGroup.ResourceGroupName;
            }
            else if (ParameterSetName == ParameterSet.ResourceId)
            {
                SqlVMGroupName = GetResourceNameFromId(SqlVMGroupId);
                ResourceGroupName = GetResourceGroupNameFromId(SqlVMGroupId);
            }
        }

        /// <summary>
        /// Get the entity to delete
        /// </summary>
        /// <returns>The sql virtual machine group that will be deleted</returns>
        protected override IEnumerable<AzureSqlVMGroupModel> GetEntity()
        {
            return new List<AzureSqlVMGroupModel>() {
                ModelAdapter.GetSqlVirtualMachineGroup(ResourceGroupName, SqlVMGroupName)
            };
        }

        /// <summary>
        /// Apply user input. Nothing to apply
        /// </summary>
        /// <param name="model">The input model</param>
        /// <returns></returns>
        protected override IEnumerable<AzureSqlVMGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlVMGroupModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the sql virtual machine group
        /// </summary>
        /// <param name="entity">The sql virtual machine group being deleted</param>
        /// <returns>The sql virtual machine group that was deleted</returns>
        protected override IEnumerable<AzureSqlVMGroupModel> PersistChanges(IEnumerable<AzureSqlVMGroupModel> entity)
        {
            ModelAdapter.RemoveSqlVirtualMachine(ResourceGroupName, SqlVMGroupName);
            return entity;
        }
    }
}
