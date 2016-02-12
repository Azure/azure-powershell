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

using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AzureBackup.Client
{
    public partial class HydraHelper
    {
        public CSMOperationResult BackupGetOperationStatus(string resourceGroupName, string resourceName, string operationId)
        {
            return BackupBmsAdapter.Client.OperationStatus.CSMGetAsync(
                resourceGroupName, resourceName, operationId,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result;
        }
    }
}