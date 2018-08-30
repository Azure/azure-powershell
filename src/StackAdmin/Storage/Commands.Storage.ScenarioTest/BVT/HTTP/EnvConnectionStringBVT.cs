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

namespace Commands.Storage.ScenarioTest.BVT.HTTP
{
    /// <summary>
    /// bvt tests using  environment variable "AZURE_STORAGE_CONNECTION_STRING"
    /// </summary>
    [TestClass]
    class EnvConnectionStringBVT : HTTPS.EnvConnectionStringBVT
    {
        [ClassInitialize()]
        public static void EnvConnectionStringHTTPBVTClassInitialize(TestContext testContext)
        {
            //first set the storage account
            //second init common bvt
            //third set storage context in powershell
            useHttps = false;
            SetUpStorageAccount = TestBase.GetCloudStorageAccountFromConfig(string.Empty, useHttps);
            CLICommonBVT.CLICommonBVTInitialize(testContext);
            System.Environment.SetEnvironmentVariable(EnvKey, SetUpStorageAccount.ToString(true));
        }

        [ClassCleanup()]
        public static void EnvConnectionStringHTTPBVTCleanUp()
        {
            CLICommonBVT.CLICommonBVTCleanup();
        }
    }
}
