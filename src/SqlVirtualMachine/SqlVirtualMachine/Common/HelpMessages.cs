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

namespace Microsoft.Azure.Commands.SqlVirtualMachine.Common
{
    /// <summary>
    /// Help messages for the parameters provided to the sqlvirtualmachine cmdlets
    /// </summary>
    public static class HelpMessages
    {
        // Generic help messages
        public const string AsJobHelpMessage = "Run cmdlet in the background.";
        public const string PassThruHelpMessage = "Specifies whether to output the deleted resource at end of cmdlet execution.";

        // Help messages relative to sql virtual machine cmdlets
        public const string ResourceGroupSqlVM = "The name of the resource group.";
        public const string NameSqlVM = "SQL virtual machine name.";
        public const string LocationSqlVM = "SQL virtual machine location.";
        public const string LicenseTypeSqlVM = "SQL virtual machine license type.";
        public const string OfferSqlVM = "SQL virtual machine offer.";
        public const string SkuSqlVM = "SQL virtual machine edition type.";
        public const string SqlManagementTypeSqlVM = "SQL virtual machine management type.";
        public const string TagSqlVM = "The tags to associate with the SQL virtual machine.";
        public const string VirtualMachineIdSqlVM = "Underlying virtual machine id.";
        public const string SqlVMResourceId = "SQL virtual machine resource id.";
        public const string InputObjectSqlVM = "SQL virtual machine object.";
        // Help messages relative to config
        public const string SqlVMConfig = "The SQL virtual machine configuration which group membership will be added to.";
        public const string GroupSqlVM = "The group the SQL virtual machine will be part of.";
        public const string ClusterOperatorAccountPasswordSqlVM = "Password for the cluster operator account.";
        public const string SqlServiceAccountPasswordSqlVM = "Password for the SQL service account.";
        public const string ClusterBootstrapAccountPasswordSqlVM = "Password for the cluster bootstrap account.";

        
        // Help messages relative to sql virtual machine group cmdlets
        public const string ResourceGroupSqlVMGroup = "The name of the resource group.";
        public const string NameSqlVMGroup = "SQL virtual machine group name.";
        public const string LocationSqlVMGroup = "SQL virtual machine group location.";
        public const string OfferSqlVMGroup = "SQL virtual machine group offer.";
        public const string SkuSqlVMGroup = "SQL virtual machine group edition type.";
        public const string SqlVMGroupResourceId = "SQL virtual machine group resource id.";
        public const string InputObjectSqlVMGroup = "SQL virtual machine object.";

        // Help messages relative to Availability Group Listener
        public const string ResourceGroupAvailabilityGroupListener = "The name of the resource group.";
        public const string NameAvailabilityGroupListener = "Availability Group Listener name.";
        public const string AvailabilityGroupListenerResourceId = "Availability Group Listener Resource Id";
        public const string InputObjectAvailabilityGroupListener = "Availability Group Listener object.";
        public const string AvailabilityGroupNameHelpMessage = "Availability Group name.";
        public const string PortHelpMessage = "Port number of AG Listener. Default Value is 1433.";
        public const string CreateDefaultAvailabilityGroupIfNotExistHelpMessage = "Do you want to create a new Availability Group if specified group is not present";
        public const string LoadBalancerResourceIdHelpMessage = "Load Balancer Id";
        public const string PrivateIpAddressHelpMessage = "Private Ip Address";
        public const string SubnetIdHelpMessage = "Subnet Resource Id";
        public const string ProbePortHelpMessage = "Probe Port";
        public const string PublicIpAddressResourceIdHelpMessage = "Public Ip Address Resource Id";
        public const string SqlVirtualMachineIDsHelpMessage = "List of Sql VM Resource IDs";
        public const string SqlVMGroupObjectHelpMessage = "SQL virtual machine Group object.";

        // Upsert
        public const string ClusterOperatorAccountSqlVMGroup = "Name used for operating cluster.";
        public const string SqlServiceAccountSqlVMGroup = "Name under which SQL service will run on all participating SQL virtual machines in the cluster.";
        public const string StorageAccountUrlSqlVMGroup = "Fully qualified ARM resource id of the witness storage account.";
        public const string StorageAccountPrimaryKeySqlVMGroup = "Primary key of the witness storage account.";
        public const string DomainFqdnSqlVMGroup = "Fully qualified name of the domain.";
        public const string OuPathSqlVMGroup = "Organizational Unit path in which the nodes and cluster will be present.";
        public const string FileShareWitnessPathSqlVMGroup = "Optional path for fileshare witness.";
        public const string ClusterBootstrapAccountSqlVMGroup = "Name used for creating cluster.";
        public const string TagSqlVMGroup = "The tags to associate with the SQL virtual machine group.";
        
    }
}
