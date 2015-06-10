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

using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    public enum AzureBackupContainerTypeInput
    {
        All,
        AzureVirtualMachine,
    }

    public enum AzureBackupContainerStatusInput
    {
        All,
        Registering,
        Registered,
    }

    public enum AzureBackupContainerType
    {
        Invalid = 0,

        Unknown,

        // used by fabric adapter to populate discovered VMs
        IaasVMContainer,

        // used by fabric adapter to populate discovered services
        // VMs are child containers of services they belong to
        IaasVMServiceContainer
    }

    public enum AzureBackupContainerRegistrationStatus
    {
        Invalid = 0,

        Unknown,

        NotRegistered,

        Registered,

        Registering,
    }

    public enum AzureBackupOperationStatus
    {
        Invalid = 0,

        InProgress,

        Completed
    }

    public enum AzureBackupOperationResult
    {
        Invalid = 0,

        Cancelled,

        Succeeded,

        Failed,

        PartialSuccess
    }

    public enum AzureBackupOperationErrorCode
    {
        BMSUserErrorObjectLocked = 390026,
        DiscoveryInProgress = 410002,
    }
}
