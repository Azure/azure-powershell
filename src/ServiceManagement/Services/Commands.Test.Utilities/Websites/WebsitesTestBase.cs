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

using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Websites
{
    [TestClass]
    public class WebsitesTestBase : SMTestBase
    {
        protected string subscriptionId = "035B9E16-BA8E-40A3-BEEA-4998F452C203";

        [TestInitialize]
        public virtual void SetupTest()
        {
            new FileSystemHelper(this).CreateAzureSdkDirectoryAndImportPublishSettings();

            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            string webSpacesFile = Path.Combine(AzurePowerShell.ProfileDirectory,
                                                          string.Format("spaces.{0}.json", subscriptionId));

            string sitesFile = Path.Combine(AzurePowerShell.ProfileDirectory,
                                                          string.Format("sites.{0}.json", subscriptionId));

            if (File.Exists(webSpacesFile))
            {
                File.Delete(webSpacesFile);
            }

            if (File.Exists(sitesFile))
            {
                File.Delete(sitesFile);
            }
        }

        protected void SetupProfile(string storageName)
        {

            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSMCmdlet.CurrentProfile = currentProfile;
            var subscription = new AzureSubscription { Id = new Guid(subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(subscriptionId)] = subscription;
            if (storageName != null)
            {
                currentProfile.Context.Subscription.Properties[AzureSubscription.Property.StorageAccount] = storageName;
            }
            currentProfile.Save();
        }
    }
}
