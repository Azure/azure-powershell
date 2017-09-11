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
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.BVT.HTTPS
{
    /// <summary>
    /// bvt test using name and key context in https mode
    /// </summary>
    [TestClass]
    class NameKeyContextBVT : CLICommonBVT
    {
        protected static bool useHttps;
        protected static string StorageAccountName;
        protected static bool isSecondary;

        [ClassInitialize()]
        public static void NameKeyContextBVTClassInitialize(TestContext testContext)
        {
            //first set the storage account
            //second init common bvt
            //third set storage context in powershell
            StorageAccountName = Test.Data.Get("StorageAccountName");
            string StorageAccountKey = Test.Data.Get("StorageAccountKey");
            string StorageEndPoint = Test.Data.Get("StorageEndPoint");
            StorageCredentials credential = new StorageCredentials(StorageAccountName, StorageAccountKey);
            useHttps = true;
            isSecondary = false;
            SetUpStorageAccount = Utility.GetStorageAccountWithEndPoint(credential, useHttps, StorageEndPoint);

            CLICommonBVT.CLICommonBVTInitialize(testContext);
            PowerShellAgent.SetStorageContext(StorageAccountName, StorageAccountKey, useHttps, StorageEndPoint);
        }

        [ClassCleanup()]
        public static void NameKeyContextBVTCleanup()
        {
            CLICommonBVT.CLICommonBVTCleanup();
        }

        [TestMethod()]
        [TestCategory(Tag.BVT)]
        public void MakeSureBvtUsingNameKeyContext()
        {
            string key = System.Environment.GetEnvironmentVariable(EnvKey);
            Test.Assert(string.IsNullOrEmpty(key), string.Format("env connection string {0} should be null or empty", key));
            Test.Assert(PowerShellAgent.Context != null, "PowerShell context should be not null when running bvt against storage account name and key");

            //check the container uri is valid for namekey context
            CloudBlobContainer retrievedContainer = CreateAndPsGetARandomContainer();
            string uri = retrievedContainer.Uri.ToString();
            string uriPrefix = string.Empty;
                
            if (useHttps)
            {
                uriPrefix = string.Format("https://{0}.", StorageAccountName);
            }
            else
            {
                uriPrefix = string.Format("http://{0}.", StorageAccountName);
            }

            Test.Assert(uri.ToString().StartsWith(uriPrefix), string.Format("The prefix of container uri should be {0}, actually it's {1}", uriPrefix, uri));
        }

        [TestMethod]
        [TestCategory(Tag.BVT)]
        public void MakeSureUsingCorrectEndPoint()
        {
            EndPointTest(isSecondary);
        }

        protected void EndPointTest(bool isSecondary)
        {
            string configKey = string.Empty;

            if (isSecondary)
            {
                configKey = "Secondary";
            }

            string endpointdomain = Test.Data.Get(string.Format("{0}StorageEndPoint", configKey));
            string [] endpoints = Utility.GetStorageEndPoints(SetUpStorageAccount.Credentials.AccountName, useHttps, endpointdomain);
            TestBase.ExpectEqual(endpoints[0], SetUpStorageAccount.BlobEndpoint.ToString(), "blob endpoint");
            TestBase.ExpectEqual(endpoints[1], SetUpStorageAccount.QueueEndpoint.ToString(), "queue endpoint");
            TestBase.ExpectEqual(endpoints[2], SetUpStorageAccount.TableEndpoint.ToString(), "table endpoint");
        }
    }
}
