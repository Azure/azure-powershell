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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Websites;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    
    public class ShowAzurePortalTests : WebsitesTestBase
    {
        [Fact(Skip = "Consider removing these.")]
        public void ProcessGetAzurePublishSettingsTest()
        {
            ShowAzurePortalCommand showAzurePortalCommand = new ShowAzurePortalCommand
            {
                Name = null,
                Environment = EnvironmentName.AzureCloud,
                Realm = "microsoft.com"
            };

            showAzurePortalCommand.ExecuteCmdlet();

            //If test reaches here then it passed.
        }
    }
}