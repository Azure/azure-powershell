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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using static Microsoft.Azure.Commands.SqlVirtualMachine.Common.ParameterSet;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// This class implements the Update-AzSqlVM cmdlet. It allows to update the information relative to an Azure Sql Virtual Machine
    /// and return to the user an AzureSqlVMModel object corresponding to the instance updated.
    /// </summary>
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVM", DefaultParameterSetName = NameParameterList, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlVMModel))]
    public class UpdateAzureSqlVM : AzureSqlVMUpsertCmdletBase
    {
        /// <summary>
        /// Resource group name of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = NameParameterList,
            Position = 0,
            HelpMessage = HelpMessages.ResourceGroupSqlVM)]
        [Parameter(Mandatory = true,
            ParameterSetName = NameInputObject,
            Position = 0,
            HelpMessage = HelpMessages.ResourceGroupSqlVM)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = NameParameterList,
            Position = 1,
            HelpMessage = HelpMessages.NameSqlVM)]
        [Parameter(Mandatory = true,
            ParameterSetName = NameInputObject,
            Position = 1,
            HelpMessage = HelpMessages.NameSqlVM)]
        [Alias("SqlVMName")]
        [ResourceNameCompleter("Microsoft.SqlVirtualMachine/SqlVirtualMachines", "ResourceGroupName")]
        public string Name { get; set; }

        /// <summary>
        /// License type of the new sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList,
            HelpMessage = HelpMessages.LicenseTypeSqlVM)]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdParameterList,
            HelpMessage = HelpMessages.LicenseTypeSqlVM)]
        [ValidateNotNullOrEmpty]
        [LicenseTypeCompleter]
        public string LicenseType { get; set; }

        /// <summary>
        /// Offer of the new sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList,
            HelpMessage = HelpMessages.OfferSqlVM)]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdParameterList,
            HelpMessage = HelpMessages.SkuSqlVM)]
        [OfferCompleter]
        public new string Offer { get; set; }

        /// <summary>
        /// Sku of the new sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList,
            HelpMessage = HelpMessages.SkuSqlVM)]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdParameterList,
            HelpMessage = HelpMessages.SkuSqlVM)]
        [SkuCompleter]
        public new string Sku { get; set; }

        /// <summary>
        /// SqlManagementType of the new sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList,
            HelpMessage = HelpMessages.SqlManagementTypeSqlVM)]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdParameterList,
            HelpMessage = HelpMessages.SqlManagementTypeSqlVM)]
        [SqlManagementTypeCompleter]
        public new string SqlManagementType { get; set; }

        /// <summary>
        /// Tags will be associated to the new sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList,
            HelpMessage = HelpMessages.TagSqlVM)]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdParameterList,
            HelpMessage = HelpMessages.TagSqlVM)]
        public new Hashtable Tag { get; set; }

        /// <summary>
        /// Sql virtual machine to be updated
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = NameInputObject,
            ValueFromPipeline = true,
            Position = 2,
            HelpMessage = HelpMessages.InputObjectSqlVM)]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdInputObject,
            ValueFromPipeline = true,
            Position = 1,
            HelpMessage = HelpMessages.InputObjectSqlVM)]
        [Alias("SqlVM")]
        public AzureSqlVMModel InputObject { get; set; }

        /// <summary>
        /// Resource id of the sql virtual machine that will be updated
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdParameterList,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = HelpMessages.SqlVMResourceId)]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdInputObject,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = HelpMessages.SqlVMResourceId)]
        [Alias("SqlVMId")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Parse the input of the cmdlet depending on the parameter set provided.
        /// </summary>
        protected override void ParseInput()
        {
            // Recover the resource group name and the sql virtual machine name if the resource id was provided
            if (ParameterSetName.StartsWith(ParameterSet.ResourceId))
            {
                Name = GetResourceNameFromId(ResourceId);
                ResourceGroupName = GetResourceGroupNameFromId(ResourceId);
            }
        }

        /// <summary>
        /// Get the entity to update
        /// </summary>
        /// <returns>The sql virtual machine that will be updated</returns>
        protected override IEnumerable<AzureSqlVMModel> GetEntity()
        {
            return new List<AzureSqlVMModel>() { ModelAdapter.GetSqlVirtualMachine(ResourceGroupName, Name) };
        }

        /// <summary>
        /// Apply user input to the retrieved sql virtual machine.
        /// </summary>
        /// <param name="model">The sql virtual machine that will be updated</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<AzureSqlVMModel> ApplyUserInputToModel(IEnumerable<AzureSqlVMModel> model)
        {
            List<AzureSqlVMModel> updateData = new List<AzureSqlVMModel>();
            AzureSqlVMModel sqlVM = model.FirstOrDefault();
            if (ParameterSetName.EndsWith(ParameterSet.InputObject))
            {
                sqlVM.Offer                     = InputObject.Offer                   ?? sqlVM.Offer;
                sqlVM.Sku                       = InputObject.Sku                     ?? sqlVM.Sku;
                sqlVM.LicenseType               = InputObject.LicenseType             ?? sqlVM.LicenseType;
                sqlVM.SqlManagementType         = InputObject.SqlManagementType       ?? sqlVM.SqlManagementType;
                sqlVM.SqlVirtualMachineGroup    = InputObject.SqlVirtualMachineGroup  ?? sqlVM.SqlVirtualMachineGroup;
                sqlVM.WsfcDomainCredentials     = InputObject.WsfcDomainCredentials   ?? sqlVM.WsfcDomainCredentials;
                sqlVM.Tags                      = InputObject.Tags                    ?? sqlVM.Tags;
            }
            else
            {
                if (LicenseType != null)
                {
                    sqlVM.LicenseType = LicenseType;
                }
                if (Offer != null)
                {
                    sqlVM.Offer = Offer;
                }
                if (Sku != null)
                {
                    sqlVM.Sku = Sku;
                }
                if (SqlManagementType != null)
                {
                    sqlVM.SqlManagementType = SqlManagementType;
                }
                if (Tag != null)
                {
                    sqlVM.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
                }
            }
            updateData.Add(sqlVM);
            return updateData;
        }

        /// <summary>
        /// Updates the sql virtual machine
        /// </summary>
        /// <param name="entity">The sql virtual machine being updated</param>
        /// <returns>The sql virtual machine that was updated</returns>
        protected override IEnumerable<AzureSqlVMModel> PersistChanges(IEnumerable<AzureSqlVMModel> entity)
        {
            return new List<AzureSqlVMModel>()
            {
                ModelAdapter.UpsertSqlVirtualMachine(entity.First())
            };
        }
    }
}
