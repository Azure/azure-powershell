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
using System.Security;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceOperation.Model
{
    /// <summary>
    /// Represents the core properties of an Managed instance
    /// </summary>
    public class AzureSqlManagedInstanceOperationModel
    {
        /// <summary>
        /// Gets or sets the resource ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets the name of the managed instance the operation is being
        /// performed on.
        /// </summary>
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets the name of the operation
        /// performed on.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the name of operation.
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Gets the friendly name of operation.
        /// </summary>
        public string OperationFriendlyName { get; set; }

        /// <summary>
        /// Gets the percentage of the operation completed.
        /// </summary>
        public int? PercentComplete { get; set; }

        /// <summary>
        /// Gets the operation start time.
        /// </summary>
        public System.DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets the operation state. Possible values include: 'Pending',
        /// 'InProgress', 'Succeeded', 'Failed', 'CancelInProgress',
        /// 'Cancelled'
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets the operation error code.
        /// </summary>
        public int? ErrorCode { get; set; }

        /// <summary>
        /// Gets the operation error description.
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets the operation error severity.
        /// </summary>
        public int? ErrorSeverity { get; set; }

        /// <summary>
        /// Gets whether or not the error is a user error.
        /// </summary>
        public bool? IsUserError { get; set; }

        /// <summary>
        /// Gets the estimated completion time of the operation.
        /// </summary>
        public System.DateTime? EstimatedCompletionTime { get; set; }

        /// <summary>
        /// Gets the operation description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets whether the operation can be cancelled.
        /// </summary>
        public bool? IsCancellable { get; set; }

        /// <summary>
        /// Gets the operation parameters.
        /// </summary>
        public Microsoft.Azure.Management.Sql.Models.ManagedInstanceOperationParametersPair OperationParameters { get; set; }

        /// <summary>
        /// Gets the operation steps.
        /// </summary>
        public Microsoft.Azure.Management.Sql.Models.ManagedInstanceOperationSteps OperationSteps { get; set; }
    }
}
