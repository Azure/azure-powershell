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

namespace Microsoft.Azure.Commands.AzureBackup.Models
{
    internal class ListContainerQueryParameter : ManagementBaseObject
    {
        /// <summary>
        ///Containers information for registration
        /// </summary>
        public string ContainerTypeField { get; set; }

        /// <summary>
        ///Containers status information
        /// </summary>
        public string ContainerStatusField { get; set; }

        /// <summary>
        ///Containers status information
        /// </summary>
        public string ContainerFriendlyNameField { get; set; }
    }
}
