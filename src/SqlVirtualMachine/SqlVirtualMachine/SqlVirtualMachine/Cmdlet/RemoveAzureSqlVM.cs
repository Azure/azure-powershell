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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// This class implements the Remove-AzSqlVM cmdlet. It will delete the Azure Sql virtual machine instance corresponding to the parameter given as input and
    /// it will return an AzureSqlVMModel object containing the information of the deleted sqlvm.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVM", DefaultParameterSetName = ParameterSet.Name, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlVMModel))]
    public class RemoveAzureSqlVM : AzureSqlVMCmdletBase
    {
        /// <summary>
        /// Resource group name of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 0,
            HelpMessage = HelpMessages.ResourceGroupSqlVM)]
        [ResourceGroupCompleter]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 1,
            HelpMessage = HelpMessages.NameSqlVM)]
        [Alias("SqlVMName")]
        [ResourceNameCompleter("Microsoft.SqlVirtualMachine/SqlVirtualMachines", "ResourceGroupName")]
        public virtual string Name { get; set; }
        
        /// <summary>
        /// Sql virtual machine resource to be removed
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.InputObject,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = HelpMessages.InputObjectSqlVM)]
        [Alias("SqlVM")]
        [ValidateNotNullOrEmpty]
        public AzureSqlVMModel InputObject { get; set; }

        /// <summary>
        /// Resource id of the sql virtual machine that will be removed
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.ResourceId,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = HelpMessages.SqlVMResourceId)]
        [Alias("SqlVMId")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Parse the input of the cmdlet depending on the parameter set provided. Retrieve the resource group name and the resource name.
        /// </summary>
        protected override void ParseInput()
        {
            if(ParameterSetName == ParameterSet.InputObject)
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName == ParameterSet.ResourceId)
            {
                Name = GetResourceNameFromId(ResourceId);
                ResourceGroupName = GetResourceGroupNameFromId(ResourceId);
            }
        }

        /// <summary>
        /// Get the entity to delete
        /// </summary>
        /// <returns>The sql virtual machine that will be deleted</returns>
        protected override IEnumerable<AzureSqlVMModel> GetEntity()
        {
            return new List<AzureSqlVMModel>() {
                ModelAdapter.GetSqlVirtualMachine(ResourceGroupName, Name)
            };
        }

        /// <summary>
        /// Apply user input. Nothing to apply
        /// </summary>
        /// <param name="model">The input model</param>
        /// <returns></returns>
        protected override IEnumerable<AzureSqlVMModel> ApplyUserInputToModel(IEnumerable<AzureSqlVMModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the sql virtual machine
        /// </summary>
        /// <param name="entity">The sql virtual machine being deleted</param>
        /// <returns>The sql virtual machine that was deleted</returns>
        protected override IEnumerable<AzureSqlVMModel> PersistChanges(IEnumerable<AzureSqlVMModel> entity)
        {
            ModelAdapter.RemoveSqlVirtualMachine(ResourceGroupName, Name);
            return entity;
        }
    }
}
