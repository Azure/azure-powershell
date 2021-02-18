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
using Microsoft.Rest.Azure;
using static Microsoft.Azure.Commands.SqlVirtualMachine.Common.ParameterSet;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// This class implements the New-AzSqlVM cmdlet. It creates a new instance of an Azure Sql Virtual machine and returns its information to the powershell
    /// user as a AzureSqlVMModel object.
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVM", DefaultParameterSetName = NameParameterList, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlVMModel))]
    public class NewAzureSqlVM : AzureSqlVMUpsertCmdletBase
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
        /// Sql virtual machine to be updated
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = NameInputObject,
            ValueFromPipeline = true,
            Position = 2,
            HelpMessage = HelpMessages.InputObjectSqlVM)]
        public AzureSqlVMModel SqlVM { get; set; }

        /// <summary>
        /// License type of new sql virtual machine
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = NameParameterList,
            Position = 2,
            HelpMessage = HelpMessages.LicenseTypeSqlVM)]
        [ValidateNotNullOrEmpty]
        [LicenseTypeCompleter]
        public string LicenseType { get; set; }

        /// <summary>
        /// Location in which the sql virtual machine will be created
        /// </summary>
        [Parameter(Mandatory = true,
           HelpMessage = HelpMessages.LocationSqlVM)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter]
        public string Location { get; set; }
        
        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Check to see if a sql virtual machine with the same name already exists in this resource group.
        /// </summary>
        /// <returns>Null if the sql virtual machine doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<AzureSqlVMModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetSqlVirtualMachine(this.ResourceGroupName, this.Name);
            }
            catch (CloudException)
            {
                // This is what we want: there is not another sql virtual machine with the same name
                return null;
            }
            throw new PSArgumentException(
                string.Format("A sql virtual machine with name {0} in resource group {1} already exists. If you want to modify an existing SqlVM you can use" +
                " Update-AzSqlVM command.", Name, ResourceGroupName),
                "SqlVirtualMachine");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the sql virtual machine doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlVMModel> ApplyUserInputToModel(IEnumerable<AzureSqlVMModel> model)
        {
            List<AzureSqlVMModel> newEntity = new List<AzureSqlVMModel>();
            AzureSqlVMModel sqlVM = new AzureSqlVMModel(ResourceGroupName)
            {
                Name = this.Name,
                Location = this.Location,
                VirtualMachineId = RetrieveVirtualMachineId(ResourceGroupName, Name)
            };
            if (ParameterSetName.Contains(InputObject))
            {
                sqlVM.LicenseType = SqlVM.LicenseType;
                sqlVM.Offer = SqlVM.Offer;
                sqlVM.Sku = SqlVM.Sku;
                sqlVM.SqlManagementType = SqlVM.SqlManagementType;
                sqlVM.SqlVirtualMachineGroup = SqlVM.SqlVirtualMachineGroup;
                sqlVM.WsfcDomainCredentials = SqlVM.WsfcDomainCredentials;
                sqlVM.Tags = SqlVM.Tags;
            }
            else
            {
                sqlVM.LicenseType = this.LicenseType;
                sqlVM.Offer = this.Offer;
                sqlVM.Sku = this.Sku;
                sqlVM.SqlManagementType = this.SqlManagementType;
                sqlVM.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
            }
            newEntity.Add(sqlVM);
            return newEntity;
        }

        /// <summary>
        /// Creates the sql virtual machine
        /// </summary>
        /// <param name="entity">The sql virtual machine to create</param>
        /// <returns>The created sql virtual machine</returns>
        protected override IEnumerable<AzureSqlVMModel> PersistChanges(IEnumerable<AzureSqlVMModel> entity)
        {
            return new List<AzureSqlVMModel>()
            {
                ModelAdapter.UpsertSqlVirtualMachine(entity.First())
            };
        }
    }
}
