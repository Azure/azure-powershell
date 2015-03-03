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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Websites.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Websites.Cmdlets;
using Microsoft.Azure.Commands.Websites;
using Microsoft.Azure.Commands.Websites.Models;
using Moq;
using Xunit;



namespace Microsoft.Azure.Commands.Websites.Test
{
    public class NewAzureWebsiteCommandTests
    {
        private NewAzureWebsiteCmdlet cmdlet;

        private Mock<WebsitesClient> websitesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

 //       ResourceGroupName, WebsiteName, SlotName, Location, WebHostingPlan


        private string resourceGroupName = "Default-Web-WestUS";

        private string websiteName = "ngoliPSWebsite";

        private string slotName = null; 
        
        private string webHostingPlan = "myWHP";

        private string location = "West US";

        private Dictionary<string, object> properties;

        private Hashtable[] tags;

        public NewAzureWebsiteCommandTests()
        {
            websitesClientMock = new Mock<WebsitesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewAzureWebsiteCmdlet()
            {
                CommandRuntime = commandRuntimeMock.Object,
                WebsitesClient = websitesClientMock.Object
            };
        }

    }
}
