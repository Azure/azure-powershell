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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PsScriptStatus
    {
        public string ContainerInstanceId { get; set; }
        public string StorageAccountId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? ExpirationTime { get; set; }
        public PSResourceManagerError Error { get; set; }

        internal static PsScriptStatus ToPsScriptStatus(ScriptStatus status)
        {
            return new PsScriptStatus
            {
                ContainerInstanceId = status?.ContainerInstanceId,
                StorageAccountId = status?.StorageAccountId,
                StartTime = status?.StartTime,
                EndTime = status?.EndTime,
                ExpirationTime = status?.ExpirationTime,
                Error = status?.Error?.ToPSResourceManagerError()
            };
        }
    }
}
