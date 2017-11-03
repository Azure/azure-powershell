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
using Microsoft.WindowsAzure.Storage.Blob;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.BVT.HTTPS
{
    /// <summary>
    /// bvt tests using  environment variable "AZURE_STORAGE_CONNECTION_STRING"
    /// </summary>
    [TestClass]
    class EnvConnectionStringBVT : CLICommonBVT
    {
        protected static bool useHttps;

        [ClassInitialize()]
        public static void EnvConnectionStringBVTClassInitialize(TestContext testContext)
        {
            //first set the storage account
            //second init common bvt
            //third set storage context in powershell
            SetUpStorageAccount = TestBase.GetCloudStorageAccountFromConfig();
            CLICommonBVT.CLICommonBVTInitialize(testContext);
            //set env connection string
            System.Environment.SetEnvironmentVariable(EnvKey, SetUpStorageAccount.ToString(true));
            useHttps = true;
        }

        [ClassCleanup()]
        public static void EnvConnectionStringBVTCleanUp()
        {
            CLICommonBVT.CLICommonBVTCleanup();
        }

        [TestMethod()]
        [TestCategory(Tag.BVT)]
        public void MakeSureBvtUsingEnvConnectionStringContext()
        {
            string key = System.Environment.GetEnvironmentVariable(EnvKey);
            Test.Assert(!string.IsNullOrEmpty(key), string.Format("env connection string {0} should be not null or empty", key));
            Test.Assert(PowerShellAgent.Context == null, "PowerShell context should be null when running bvt against env connection string");

            //check the container uri is valid for env connection string context
            CloudBlobContainer retrievedContainer = CreateAndPsGetARandomContainer();
            string uri = retrievedContainer.Uri.ToString();
            string uriPrefix = string.Empty;

            //only check the http/https usage
            if (useHttps)
            {
                uriPrefix = "https";
            }
            else
            {
                uriPrefix = "http";
            }

            Test.Assert(uri.ToString().StartsWith(uriPrefix), string.Format("The prefix of container uri should be {0}, actually it's {1}", uriPrefix, uri));
        }
    }
}
