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
using System.Collections;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    public abstract class AzureSqlVMGroupUpsertCmdletBase : AzureSqlVMGroupCmdletBase
    {
        /// <summary>
        /// Name used for operating cluster
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.ClusterOperatorAccountSqlVMGroup)]
        public virtual string ClusterOperatorAccount { get; set; }

        /// <summary>
        /// Name under which SQL service will run on all participating SQL virtual machines in the cluster
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.SqlServiceAccountSqlVMGroup)]
        public virtual string SqlServiceAccount { get; set; }

        /// <summary>
        /// Fully qualified ARM resource id of the witness storage account
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.StorageAccountPrimaryKeySqlVMGroup)]
        public virtual string StorageAccountUrl { get; set; }

        /// <summary>
        /// Primary key of the witness storage account
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.StorageAccountPrimaryKeySqlVMGroup)]
        public virtual SecureString StorageAccountPrimaryKey { get; set; }

        /// <summary>
        /// Fully qualified name of the domain
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.DomainFqdnSqlVMGroup)]
        public virtual string DomainFqdn { get; set; }

        /// <summary>
        /// Organizational Unit path in which the nodes and cluster will be present.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.OuPathSqlVMGroup)]
        public virtual string OuPath { get; set; }

        /// <summary>
        /// Optional path for fileshare witness
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.FileShareWitnessPathSqlVMGroup)]
        public virtual string FileShareWitnessPath { get; set; }

        /// <summary>
        /// Name used for creating cluster
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.ClusterBootstrapAccountSqlVMGroup)]
        public virtual string ClusterBootstrapAccount { get; set; }

        /// <summary>
        /// Tags will be associated to the sql virtual machine group
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = HelpMessages.TagSqlVMGroup)]
        public virtual Hashtable Tag { get; set; }

    }
}
