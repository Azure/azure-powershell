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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.New, "AzureRmOperationalInsightsAzureAuditDataSource", SupportsShouldProcess = true, 
        DefaultParameterSetName = ByWorkspaceName), OutputType(typeof(PSDataSource))]
    public class NewAzureOperationalInsightsAzureAuditDataSourceCommand : NewAzureOperationalInsightsDataSourceBaseCmdlet
    {
        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The azure subscription Id.")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        public override void ExecuteCmdlet()
        {
            var auditLogProperties = new PSAzureAuditLogDataSourceProperties
            {
                SubscriptionId = this.SubscriptionId
            };

            CreatePSDataSourceWithProperties(auditLogProperties);
        }
    }
}