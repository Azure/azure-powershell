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

using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common.ArgumentCompleters;
using System.Collections;
using System.Management.Automation;
using static Microsoft.Azure.Commands.SqlVirtualMachine.Common.ParameterSet;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    public abstract class AzureSqlVMUpsertCmdletBase : AzureSqlVMCmdletBase
    {
        /// <summary>
        /// Offer of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList, 
            HelpMessage = HelpMessages.OfferSqlVM)]
        [OfferCompleter]
        public virtual string Offer { get; set; }

        /// <summary>
        /// Sku of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList,
            HelpMessage = HelpMessages.SkuSqlVM)]
        [SkuCompleter]
        public virtual string Sku { get; set; }

        /// <summary>
        /// SqlManagementType of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList,
            HelpMessage = HelpMessages.SqlManagementTypeSqlVM)]
        [SqlManagementTypeCompleter]
        public virtual string SqlManagementType { get; set; } = "LightWeight";

        /// <summary>
        /// Tags will be associated to the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList,
            HelpMessage = HelpMessages.TagSqlVM)]
        public virtual Hashtable Tag { get; set; }
    }
}
