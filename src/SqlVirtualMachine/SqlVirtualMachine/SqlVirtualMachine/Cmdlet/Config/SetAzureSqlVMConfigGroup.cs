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
using System.Security;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Adapter;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet.Config
{
    /// <summary>
    /// This class implements the Set-AzVMConfigGroup cmdlet. It takes an instance of AzureSqlVMModel and adds the information relative to the
    /// Sql Virtual Machine group to the local copy of the powershell object. It returns an instance of AzureSqlVMModel that can be used as configuration
    /// for an Azure Sql Virtual Machine.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVMConfigGroup", SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlVMModel))]
    public class SetAzureSqlVMConfigGroup : AzureSqlVirtualMachineCmdletBase<IEnumerable<AzureSqlVMModel>, AzureSqlVMAdapter>
    {
        [Parameter(Mandatory = true,
           ValueFromPipeline = true,
           Position = 0,
           HelpMessage = HelpMessages.SqlVMConfig)]
        public AzureSqlVMModel SqlVM { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = HelpMessages.GroupSqlVM)]
        public AzureSqlVMGroupModel SqlVMGroup { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessages.ClusterOperatorAccountPasswordSqlVM)]
        public SecureString ClusterOperatorAccountPassword { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessages.SqlServiceAccountPasswordSqlVM)]
        public SecureString SqlServiceAccountPassword { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.ClusterBootstrapAccountPasswordSqlVM)]
        public SecureString ClusterBootstrapAccountPassword { get; set; }

        protected override IEnumerable<AzureSqlVMModel> GetEntity()
        {
            return null;
        }

        protected override IEnumerable<AzureSqlVMModel> ApplyUserInputToModel(IEnumerable<AzureSqlVMModel> model)
        {
            List<AzureSqlVMModel> newEntity = new List<AzureSqlVMModel>();
            SqlVM.SqlVirtualMachineGroup = SqlVMGroup;
            SqlVM.WsfcDomainCredentials = new WsfcDomainCredentials()
            {
                ClusterBootstrapAccountPassword = ClusterBootstrapAccountPassword != null ? ConversionUtilities.SecureStringToString(ClusterBootstrapAccountPassword) : null,
                ClusterOperatorAccountPassword = ClusterOperatorAccountPassword != null ? ConversionUtilities.SecureStringToString(ClusterOperatorAccountPassword) : null,
                SqlServiceAccountPassword = SqlServiceAccountPassword != null ? ConversionUtilities.SecureStringToString(SqlServiceAccountPassword) : null,
            };
            newEntity.Add(SqlVM);
            return newEntity;
        }

        protected override IEnumerable<AzureSqlVMModel> PersistChanges(IEnumerable<AzureSqlVMModel> entity)
        {
            return new List<AzureSqlVMModel>()
            {
                entity.FirstOrDefault()
            };
        }

        protected override AzureSqlVMAdapter InitModelAdapter()
        {
            return null;
        }
    }
}
