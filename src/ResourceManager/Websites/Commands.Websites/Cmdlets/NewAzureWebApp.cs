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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.Azure.Commands.WebApp;
using Microsoft.Azure.Management.WebSites;
using System.Net.Http;
using System.Threading;
using System.Net;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.WebApp.Utilities;


namespace Microsoft.Azure.Commands.WebApp.Cmdlets
{
    /// <summary>
    /// this commandlet will let you create a new Azure Web app using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureWebApp")]
    public class NewAzureWebAppCmdlet : WebAppBaseCmdlet
    {

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ValidateNotNullOrEmptyAttribute]
        public string SlotName { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The Location of the web app eg: West US.")]
        public string Location { get; set; }

        [Parameter(Position = 4, Mandatory = true, HelpMessage = "The name of the app service plan eg: Default1.")]
        public string AppServicePlan { get; set; }
       
        public override void ExecuteCmdlet()
        {
            WriteObject(WebsitesClient.CreateWebsite(ResourceGroupName, Name, SlotName, Location, AppServicePlan));
            
        }
        
    }
}



