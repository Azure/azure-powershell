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

namespace Microsoft.Azure.Commands.Sql.InstanceActiveDirectoryAdministrator.Model
{
    /// <summary>
    /// Represents an Azure SQL Server Active Directory administrator
    /// </summary>
    public class AzureSqlInstanceActiveDirectoryAdministratorModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Instance Active Directory administrator display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the SID (object ID) of the Azure SQL Instance Active administrator
        /// </summary>
        public Guid ObjectId { get; set; }
    }
}
