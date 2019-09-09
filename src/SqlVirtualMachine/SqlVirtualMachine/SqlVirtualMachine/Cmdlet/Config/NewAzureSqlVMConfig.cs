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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using static Microsoft.Azure.Commands.SqlVirtualMachine.Common.ParameterSet;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet.Config
{
    /// <summary>
    /// This class implements the New-AzVMConfig cmdlet. It will create a local AzureSqlVMModel powershell object that can be used as configuration settings 
    /// for the creation of a sql virtual machine on Azure.
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVMConfig", DefaultParameterSetName = NameParameterList, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlVMModel))]
    public class NewAzureSqlVMConfig : AzureSqlVMUpsertCmdletBase
    {
        /// <summary>
        /// License type of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = NameParameterList,
            Position = 0,
            HelpMessage = HelpMessages.LicenseTypeSqlVM)]
        [ValidateNotNullOrEmpty]
        [LicenseTypeCompleter]
        public string LicenseType { get; set; }

        protected override IEnumerable<AzureSqlVMModel> GetEntity()
        {
            return null;
        }

        protected override IEnumerable<AzureSqlVMModel> ApplyUserInputToModel(IEnumerable<AzureSqlVMModel> model)
        {
            List<AzureSqlVMModel> newEntity = new List<AzureSqlVMModel>();
            newEntity.Add(new AzureSqlVMModel()
            {
                LicenseType = this.LicenseType,
                Offer = this.Offer,
                Sku = this.Sku,
                SqlManagementType = this.SqlManagementType,
                Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
            });
            return newEntity;
        }

        protected override IEnumerable<AzureSqlVMModel> PersistChanges(IEnumerable<AzureSqlVMModel> entity)
        {
            return entity;
        }
    }
}
