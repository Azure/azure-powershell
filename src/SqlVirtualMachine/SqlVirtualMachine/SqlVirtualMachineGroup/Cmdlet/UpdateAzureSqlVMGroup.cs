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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// This class implements the Update-AzSqlVMGroup cmdlet. It allows to update the information relative to an Azure Sql Virtual Machine
    /// Group and return to the user an AzureSqlVMGroupModel object corresponding to the instance updated.
    /// </summary>
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVMGroup", DefaultParameterSetName = ParameterSet.Name, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlVMGroupModel))]
    public class UpdateAzureSqlVMGroup : AzureSqlVMGroupUpsertCmdletBase
    {
        /// <summary>
        /// Sql virtual machine group to be updated
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.InputObject,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = HelpMessages.InputObjectSqlVMGroup)]
        [Alias("SqlVMGroup")]
        public AzureSqlVMGroupModel InputObject { get; set; }

        /// <summary>
        /// Resource id of the sql virtual machine group that will be updated
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.ResourceId,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = HelpMessages.SqlVMGroupResourceId)]
        [Alias("SqlVMGroupId")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Parse the input of the cmdlet depending on the parameter set provided.
        /// </summary>
        protected override void ParseInput()
        {
            if (ParameterSetName == ParameterSet.ResourceId)
            {
                Name = GetResourceNameFromId(ResourceId);
                ResourceGroupName = GetResourceGroupNameFromId(ResourceId);
            }
            if (ParameterSetName == ParameterSet.InputObject)
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
        }

        /// <summary>
        /// Get the entity to update
        /// </summary>
        /// <returns>The sql virtual machine group that will be updated</returns>
        protected override IEnumerable<AzureSqlVMGroupModel> GetEntity()
        {
            return new List<AzureSqlVMGroupModel>() { ModelAdapter.GetSqlVirtualMachineGroup(ResourceGroupName, Name) };
        }

        /// <summary>
        /// Apply user input to the retrieved sql virtual machine group
        /// </summary>
        /// <param name="model">The sql virtual machine group that will be updated</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<AzureSqlVMGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlVMGroupModel> model)
        {
            List<AzureSqlVMGroupModel> updateData = new List<AzureSqlVMGroupModel>();
            AzureSqlVMGroupModel group = model.FirstOrDefault();

            group.WsfcDomainProfile = updateWsfcDomainProfile(group.WsfcDomainProfile);

            if(Tag != null)
            {
                group.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
            }
            
            updateData.Add(group);
            return updateData;
        }
        private WsfcDomainProfile updateWsfcDomainProfile(WsfcDomainProfile profile)
        {
            profile.ClusterBootstrapAccount = ClusterBootstrapAccount   ?? profile.ClusterBootstrapAccount;
            profile.ClusterOperatorAccount  = ClusterOperatorAccount    ?? profile.ClusterOperatorAccount;
            profile.SqlServiceAccount       = SqlServiceAccount         ?? profile.SqlServiceAccount;
            profile.DomainFqdn              = DomainFqdn                ?? profile.DomainFqdn;
            profile.StorageAccountUrl       = StorageAccountUrl         ?? profile.StorageAccountUrl;
            profile.FileShareWitnessPath    = FileShareWitnessPath      ?? profile.FileShareWitnessPath;
            profile.OuPath                  = OuPath                    ?? profile.OuPath;

            profile.StorageAccountPrimaryKey = StorageAccountPrimaryKey != null ? ConversionUtilities.SecureStringToString(StorageAccountPrimaryKey) : profile.StorageAccountPrimaryKey;

            return profile;
        }

        /// <summary>
        /// Updates the sql virtual machine group
        /// </summary>
        /// <param name="entity">The sql virtual machine group being updated</param>
        /// <returns>The sql virtual machine group that was updated</returns>
        protected override IEnumerable<AzureSqlVMGroupModel> PersistChanges(IEnumerable<AzureSqlVMGroupModel> entity)
        {
            return new List<AzureSqlVMGroupModel>()
            {
                ModelAdapter.UpsertSqlVirtualMachineGroup(entity.First())
            };
        }
    }
}
