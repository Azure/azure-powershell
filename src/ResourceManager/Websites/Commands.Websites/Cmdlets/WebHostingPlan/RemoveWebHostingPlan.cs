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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.Azure.Commands.Websites;
using Microsoft.Azure.Management.WebSites;
using System.Net.Http;
using System.Threading;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Websites.Utilities;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;


namespace Microsoft.Azure.Commands.Websites.Cmdlets.WebHostingPlan
{
    /// <summary>
    /// this commandlet will let you delete an Azure Web Hosting Plan using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureWebHostingPlan"), OutputType(typeof(AzureOperationResponse))]
    public class RemoveWebHostingPlanCmdlet : WebHostingPlanBaseCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                    Force.IsPresent,
                    string.Format(Microsoft.Azure.Commands.Websites.Properties.Resources.RemovingWebHostPlan, WebHostingPlanName),
                    Microsoft.Azure.Commands.Websites.Properties.Resources.RemovingWebHostPlan,
                    WebHostingPlanName,
                    () => WebsitesClient.RemoveWebHostingPlan(ResourceGroupName, WebHostingPlanName));
        }
    }
}

