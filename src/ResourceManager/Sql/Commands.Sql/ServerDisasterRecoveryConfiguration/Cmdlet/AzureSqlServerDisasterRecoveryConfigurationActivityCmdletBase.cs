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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Model;
using Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Services;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Cmdlet
{
    public abstract class AzureSqlServerDisasterRecoveryConfigurationActivityCmdletBase
        : AzureSqlCmdletBase<IEnumerable<AzureSqlServerDisasterRecoveryConfigurationActivityModel>, AzureSqlServerDisasterRecoveryConfigurationAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the Disaster Recovery Configuration is in.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Server Disaster Recovery Configuration to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Azure SQL Server Disaster Recovery Configuration.")]
        [ValidateNotNullOrEmpty]
        public string ServerDisasterRecoveryConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the OperationId.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the operation to retrieve.")]
        [ValidateNotNullOrEmpty]
        public Guid? OperationId { get; set; }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        protected override AzureSqlServerDisasterRecoveryConfigurationAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlServerDisasterRecoveryConfigurationAdapter(DefaultProfile.DefaultContext);
        }
    }
}
