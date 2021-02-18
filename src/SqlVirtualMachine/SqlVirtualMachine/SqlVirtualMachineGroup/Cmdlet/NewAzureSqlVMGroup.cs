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
using System.Security;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// This class implements the New-AzSqlVMGroup cmdlet. It creates a new instance of an Azure Sql Virtual machine group and returns its information 
    /// to the powershell user as a AzureSqlVMGroupModel object.
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVMGroup", SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlVMGroupModel))]
    public class NewAzureSqlVMGroup : AzureSqlVMGroupUpsertCmdletBase
    {
        /// <summary>
        /// Location in which the sql virtual machine group will be created
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 2,
            HelpMessage = HelpMessages.LocationSqlVMGroup)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter]
        public string Location { get; set; }

        /// <summary>
        /// Offer of the new sql virtual machine group
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessages.OfferSqlVMGroup)]
        [OfferCompleter]
        public string Offer { get; set; }

        /// <summary>
        /// Sku of the new sql virtual machine group
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessages.SkuSqlVMGroup)]
        [SkuCompleter]
        public string Sku { get; set; }

        /// <summary>
        /// Name used for operating cluster
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessages.ClusterOperatorAccountSqlVMGroup)]
        public new string ClusterOperatorAccount { get; set; }

        /// <summary>
        /// Name under which SQL service will run on all participating SQL virtual machines in the cluster
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessages.SqlServiceAccountSqlVMGroup)]
        public new string SqlServiceAccount { get; set; }

        /// <summary>
        /// Fully qualified ARM resource id of the witness storage account
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessages.StorageAccountPrimaryKeySqlVMGroup)]
        public new string StorageAccountUrl { get; set; }

        /// <summary>
        /// Primary key of the witness storage account
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessages.StorageAccountPrimaryKeySqlVMGroup)]
        public new SecureString StorageAccountPrimaryKey { get; set; }

        /// <summary>
        /// Fully qualified name of the domain
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = HelpMessages.DomainFqdnSqlVMGroup)]
        public new string DomainFqdn { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Check to see if a sql virtual machine group  with the same name already exists in this resource group.
        /// </summary>
        /// <returns>Null if the sql virtual machine group doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<AzureSqlVMGroupModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetSqlVirtualMachineGroup(this.ResourceGroupName, this.Name);
            }
            catch (CloudException)
            {
                return null;
            }

            throw new PSArgumentException(
                string.Format("A sql virtual machine group with name {0} in resource group {1} already exists. If you want to modify an existing SqlVMGroup you can use" +
                " Update-AzSqlVMGroup command.", Name, ResourceGroupName),
                "SqlVirtualMachineGroup");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the sql virtual machine group doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlVMGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlVMGroupModel> model)
        {
            List<AzureSqlVMGroupModel> newEntity = new List<AzureSqlVMGroupModel>();
            newEntity.Add(new AzureSqlVMGroupModel(ResourceGroupName)
            {
                Location = this.Location,
                Name = this.Name,
                Offer = this.Offer,
                Sku = this.Sku,
                WsfcDomainProfile = new WsfcDomainProfile()
                {
                    ClusterBootstrapAccount = this.ClusterBootstrapAccount,
                    ClusterOperatorAccount = this.ClusterOperatorAccount,
                    DomainFqdn = this.DomainFqdn,
                    SqlServiceAccount = this.SqlServiceAccount,
                    StorageAccountUrl = this.StorageAccountUrl,
                    StorageAccountPrimaryKey = this.StorageAccountPrimaryKey != null ? ConversionUtilities.SecureStringToString(this.StorageAccountPrimaryKey) : null,
                    FileShareWitnessPath = this.FileShareWitnessPath,
                    OuPath = this.OuPath
                },
                Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true)
            });
            return newEntity;
        }

        /// <summary>
        /// Creates the sql virtual machine group
        /// </summary>
        /// <param name="entity">The sql virtual machine group to create</param>
        /// <returns>The created sql virtual machine group</returns>
        protected override IEnumerable<AzureSqlVMGroupModel> PersistChanges(IEnumerable<AzureSqlVMGroupModel> entity)
        {
            return new List<AzureSqlVMGroupModel>()
            {
                ModelAdapter.UpsertSqlVirtualMachineGroup(entity.FirstOrDefault())
            };
        }
    }
}
