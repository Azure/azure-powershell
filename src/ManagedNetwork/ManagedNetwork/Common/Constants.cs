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

namespace Microsoft.Azure.Commands.ManagedNetwork.Common
{
    public class Constants
    {
        #region Message

        /// <summary>
        /// ConfirmOverwriteResource
        /// </summary>
        public const string ConfirmOverwriteResource = "{0} already exists. Are you sure you want to overwrite it.";

        /// <summary>
        /// ConfirmOverwriteResource
        /// </summary>
        public const string ConfirmDeleteResource = "{0} exists. Are you sure you want to delete it.";

        /// <summary>
        /// CreatingResource
        /// </summary>
        public const string CreatingResource = "Creating Resource...";

        /// <summary>
        /// UpdatingResource
        /// </summary>
        public const string UpdatingResource = "Updating Resource...";

        /// <summary>
        /// DeletingResource
        /// </summary>
        public const string DeletingResource = "Deleting Resource...";

        /// <summary>
        /// ManagedNetworkDoesNotExist
        /// </summary>
        public const string ManagedNetworkDoesNotExist = "A Managed Network with name '{0}' in resource group '{1}' does not exist. Please use New-AzManagedNetwork to create a Managed Network with these properties.";

        /// <summary>
        /// ManagedNetworkGroupDoesNotExist
        /// </summary>
        public const string ManagedNetworkGroupDoesNotExist = "A Managed Network Group with name '{0}' in managed network '{1}' and  resource group '{2}' does not exist. Please use New-AzManagedNetwork to create a Managed Network with these properties.";

        /// <summary>
        /// ManagedNetworkPeeringPolicyDoesNotExist
        /// </summary>
        public const string ManagedNetworkPeeringPolicyDoesNotExist = "A Managed Network Peering Policy with name '{0}' in managed network '{1}' and  resource group '{2}' does not exist. Please use New-AzManagedNetwork to create a Managed Network with these properties.";



        #endregion
        #region Help


        /// <summary>
        /// ResourceGroupNameHelp
        /// </summary>
        public const string ResourceIdNameHelp = "The unique ARM id of an existing resource.";

        /// <summary>
        /// ResourceGroupNameHelp
        /// </summary>
        public const string ResourceGroupNameHelp = "The create or use an existing resource group name.";

        /// <summary>
        /// ManagedNetworkNameHelp
        /// </summary>
        public const string ManagedNetworkNameHelp = "The unique name of the Managed Network.";

        /// <summary>
        /// ManagedNetworkGroupNameHelp
        /// </summary>
        public const string ManagedNetworkGroupNameHelp = "The unique name of the Managed Network Group.";

        /// <summary>
        /// ManagedNetworkPeeringPolicyNameHelp
        /// </summary>
        public const string ManagedNetworkPeeringPolicyNameHelp = "The unique name of the Managed Network Peering Policy.";

        /// <summary>
        /// ManagedNetworkHelp
        /// </summary>
        public const string ManagedNetworkObjectHelp = "The object of Managed Network.";

        /// <summary>
        /// InputObjectHelp
        /// </summary>
        public const string InputObjectHelp = "The Input Object.";

        /// <summary>
        /// ManagedNetworkScopeHelp
        /// </summary>
        public const string ManagedNetworkScopeHelp = "The scope of control of the Managed Network.";

        /// <summary>
        /// ManagedNetworkTagHelp
        /// </summary>
        public const string ManagedNetworkTagHelp = "The tags assigned to a Managed Network.";

        /// <summary>
        /// ManagedNetworkLocationHelp
        /// </summary>
        public const string ManagedNetworkLocationHelp = "The Location assigned to a Managed Network.";

        /// <summary>
        /// The force help.
        /// </summary>
        public const string ForceHelp = "Force the operation to complete";

        /// <summary>
        /// The pass thru help.
        /// </summary>
        public const string PassThruHelp = "Return true if complete";

        /// <summary>
        /// AsJobHelp
        /// </summary>
        public const string AsJobHelp = "Run in the background.";

        #endregion
        #region ParameterSet
        public const string NameParameterSet = "NameParameterSet";
        public const string ListParameterSet = "ListParameterSet";
        public const string ResourceIdParameterSet = "ResourceIdParameterSet";
        public const string InputObjectParameterSet = "InputObjectParameterSet";
        public const string ManagedNetworkObjectParameterSet = "ManagedNetworkObjectParameterSet";
        #endregion
    }
}
