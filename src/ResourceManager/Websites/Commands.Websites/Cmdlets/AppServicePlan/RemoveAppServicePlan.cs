﻿// ----------------------------------------------------------------------------------
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


using System.Management.Automation;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.WebApp.Utilities;


namespace Microsoft.Azure.Commands.WebApp.Cmdlets.AppServicePlan
{
    /// <summary>
    /// this commandlet will let you delete an Azure App Service Plan using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureAppServicePlan"), OutputType(typeof(AzureOperationResponse))]
    public class RemoveAppServicePlanCmdlet : AppServicePlanBaseCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                    Force.IsPresent,
                    string.Format(Microsoft.Azure.Commands.WebApp.Properties.Resources.RemovingAppServicePlan, Name),
                    Microsoft.Azure.Commands.WebApp.Properties.Resources.RemovingAppServicePlan,
                    Name,
                    () => WebsitesClient.RemoveAppServicePlan(ResourceGroupName, Name));
        }
    }
}

