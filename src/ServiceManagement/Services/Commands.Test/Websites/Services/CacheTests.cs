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
using System.IO;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.Test.Websites.Services
{
    
    public class CacheTests : SMTestBase, IDisposable
    {
        public static string SubscriptionName = "fakename";

        public static string WebSpacesFile;

        public static string SitesFile;

        private FileSystemHelper helper;

        public CacheTests()
        {
            helper = new FileSystemHelper(this);
            helper.CreateAzureSdkDirectoryAndImportPublishSettings();

            WebSpacesFile =  Path.Combine(AzurePowerShell.ProfileDirectory,
                                                          string.Format("spaces.{0}.json", SubscriptionName));

            SitesFile = Path.Combine(AzurePowerShell.ProfileDirectory,
                                                          string.Format("sites.{0}.json", SubscriptionName));
            
            if (File.Exists(WebSpacesFile))
            {
                File.Delete(WebSpacesFile);
            }

            if (File.Exists(SitesFile))
            {
                File.Delete(SitesFile);
            }
        }

        public void Dispose()
        {
            CleanupTest();
        }

        public void CleanupTest()
        {
            if (File.Exists(WebSpacesFile))
            {
                File.Delete(WebSpacesFile);
            }

            if (File.Exists(SitesFile))
            {
                File.Delete(SitesFile);
            }

            helper.Dispose();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddSiteTest()
        {
            Site site = new Site { Name = "newsite" };
            // Add without any cache from before
            Cache.AddSite(SubscriptionName, site);

            Sites getSites = Cache.GetSites(SubscriptionName);
            Assert.NotNull(getSites.Find(ws => ws.Name.Equals("newsite")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSiteTest()
        {
            Site site = new Site { Name = "newsite" };
            // Add without any cache from before
            Cache.AddSite(SubscriptionName, site);

            Sites getSites = Cache.GetSites(SubscriptionName);
            Assert.NotNull(getSites.Find(ws => ws.Name.Equals("newsite")));

            // Now remove it
            Cache.RemoveSite(SubscriptionName, site);
            getSites = Cache.GetSites(SubscriptionName);
            Assert.Null(getSites.Find(ws => ws.Name.Equals("newsite")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSetSitesTest()
        {
            Assert.Null(Cache.GetSites(SubscriptionName));

            Sites sites = new Sites(new List<Site> { new Site { Name = "site1" }, new Site { Name = "site2" }});
            Cache.SaveSites(SubscriptionName, sites);

            Sites getSites = Cache.GetSites(SubscriptionName);
            Assert.NotNull(getSites.Find(s => s.Name.Equals("site1")));
            Assert.NotNull(getSites.Find(s => s.Name.Equals("site2")));
        }
    }
}
