
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


using System.Management.Automation;
using Microsoft.Azure.Commands.WebApp.Utilities;


namespace Microsoft.Azure.Commands.WebApp.Cmdlets
{
    /// <summary>
    /// this commandlet will let you Start an Azure Web app
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureRmWebApp")]
    public class StartAzureWebAppCmdlet : WebAppBaseCmdlet
    {

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ValidateNotNullOrEmptyAttribute]
        public string SlotName { get; set; }
     
        protected override void ProcessRecord()
        {
            WriteObject(WebsitesClient.StartWebsite(ResourceGroupName, Name, SlotName));
            
        }
        
    }
}



