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

using Commands.Storage.ScenarioTest.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.BVT.HTTPS
{
    /// <summary>
    /// bvt tests using Azure subscription
    /// </summary>
    [TestClass]
    class SubScriptionBVT : CLICommonBVT
    {
        [ClassInitialize()]
        public static void SubScriptionBVTClassInitialize(TestContext testContext)
        {
            //first set the storage account
            //second init common bvt
            //third set storage context in powershell
            SetUpStorageAccount = TestBase.GetCloudStorageAccountFromConfig();
            CLICommonBVT.CLICommonBVTInitialize(testContext);
            SetupSubscription();
        }

        /// <summary>
        /// set up azure subscription
        /// </summary>
        private static void SetupSubscription()
        {
            string subscriptionFile = Test.Data.Get("AzureSubscriptionPath");
            string subscriptionName = Test.Data.Get("AzureSubscriptionName");
            //TODO add tests about invalid storage account name
            string storageAccountName = Test.Data.Get("StorageAccountName");
            PowerShellAgent.ImportAzureSubscriptionAndSetStorageAccount(subscriptionFile, subscriptionName, storageAccountName);
        }

        [ClassCleanup()]
        public static void SubScriptionBVTCleanUp()
        {
            CLICommonBVT.CLICommonBVTCleanup();
        }

        [TestMethod()]
        [TestCategory(Tag.BVT)]
        public void MakeSureBvtUsingSubscriptionContext()
        {
            string key = System.Environment.GetEnvironmentVariable(EnvKey);
            Test.Assert(string.IsNullOrEmpty(key), string.Format("env connection string {0} should be null or empty", key));
            Test.Assert(PowerShellAgent.Context == null, "PowerShell context should be null when running bvt against Subscription");
        }
    }
}
