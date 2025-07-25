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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Model
{
    /// <summary>
    /// Represents an Azure Sql Managed Database
    /// </summary>
    public class MoveCopyManagedDatabaseModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed instance
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed database
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the target resource group
        /// </summary>
        public string TargetResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the target managed instance
        /// </summary>
        public string TargetInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the Id of the target subscription.
        /// </summary>
        public string TargetSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the operation type
        /// </summary>
        public OperationMode OperationMode { get; set; }

        /// <summary>
        /// Location of the managed instance
        /// </summary>
        public string Location { get; set; }

        public string getTargetManagedDatabaseId()
        {
            var managedDatabaseResourceId = new ResourceIdentifier()
            {
                Subscription = TargetSubscriptionId,
                ResourceGroupName = TargetResourceGroupName,
                ParentResource = $"managedInstances/{TargetInstanceName}",
                ResourceType = "Microsoft.Sql/managedInstances/databases",
                ResourceName = DatabaseName,
            };
            return managedDatabaseResourceId.ToString();
        }
    }

    public enum OperationMode
    {
        Move,
        Copy
    }
}
