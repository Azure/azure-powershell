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

namespace Microsoft.Azure.Commands.Sql.ServerUpgrade.Model
{
    public class AzureSqlServerUpgradeModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group the server being upgraded is in
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server being upgraded
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the upgrade status of the server
        /// </summary>
        public ServerUpgradeStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the earliest time to upgrade the server
        /// </summary>
        public DateTime? ScheduleUpgradeAfterUtcDateTime { get; set; }
    }
}