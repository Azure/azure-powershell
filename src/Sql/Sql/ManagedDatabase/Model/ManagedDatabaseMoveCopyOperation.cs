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

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Model
{
    public class ManagedDatabaseMoveCopyOperation
    {
        /// <summary>
        /// Gets the name of operation.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the name of operation.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of operation.
        /// </summary>
        public string Operation { get; private set; }

        /// <summary>
        /// Gets the friendly name of operation.
        /// </summary>
        public string OperationFriendlyName { get; private set; }

        /// <summary>
        /// Gets the operation start time.
        /// </summary>
        public System.DateTime? StartTime { get; private set; }

        /// <summary>
        /// Gets the operation state. Possible values include: 'Pending',
        /// 'InProgress', 'Succeeded', 'Failed', 'CancelInProgress',
        /// 'Cancelled'
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        /// Gets operation mode. Possible values include: 'Move', 'Copy'
        /// </summary>
        public string OperationMode { get; private set; }

        /// <summary>
        /// Gets source Managed Instance name.
        /// </summary>
        public string SourceManagedInstanceName { get; private set; }

        /// <summary>
        /// Gets target Managed Instance name.
        /// </summary>
        public string TargetManagedInstanceName { get; private set; }

        /// <summary>
        /// Gets source Managed Instance resource id.
        /// </summary>
        public string SourceManagedInstanceId { get; private set; }

        /// <summary>
        /// Gets target Managed instance resource id.
        /// </summary>
        public string TargetManagedInstanceId { get; private set; }

        /// <summary>
        /// Gets source database name.
        /// </summary>
        public string SourceDatabaseName { get; private set; }

        /// <summary>
        /// Gets target database name.
        /// </summary>
        public string TargetDatabaseName { get; private set; }

        /// <summary>
        /// Gets is move operation cancellable.
        /// </summary>
        public bool? IsCancellable { get; private set; }

        /// <summary>
        /// Gets the operation error code.
        /// </summary>
        public int? ErrorCode { get; private set; }

        /// <summary>
        /// Gets the operation error description.
        /// </summary>
        public string ErrorDescription { get; private set; }

        /// <summary>
        /// Gets the operation error severity.
        /// </summary>
        public int? ErrorSeverity { get; private set; }

        /// <summary>
        /// Gets whether or not the error is a user error.
        /// </summary>
        public bool? IsUserError { get; private set; }

        public ManagedDatabaseMoveCopyOperation(ManagedDatabaseMoveOperationResult operationResult)
        {
            Name = operationResult.Name;
            Id = operationResult.Id;
            Operation = operationResult.Operation;
            OperationFriendlyName = operationResult.OperationFriendlyName;
            StartTime = operationResult.StartTime;
            State = operationResult.State;
            OperationMode = operationResult.OperationMode;
            SourceManagedInstanceName = operationResult.SourceManagedInstanceName;
            TargetManagedInstanceName = operationResult.TargetManagedInstanceName;
            SourceManagedInstanceId = operationResult.SourceManagedInstanceId;
            TargetManagedInstanceId = operationResult.TargetManagedInstanceId;
            SourceDatabaseName = operationResult.SourceDatabaseName;
            TargetDatabaseName = operationResult.TargetDatabaseName;
            IsCancellable = operationResult.IsCancellable;
            ErrorCode = operationResult.ErrorCode;
            ErrorDescription = operationResult.ErrorDescription;
            ErrorSeverity = operationResult.ErrorSeverity;
            IsUserError = operationResult.IsUserError;
        }
    }
}
