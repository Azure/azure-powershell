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

namespace Commands.Storage.ScenarioTest.BVT.HTTP
{
    /// <summary>
    /// BVT test case for secondary end point with http protocol
    /// </summary>
    [TestClass]
    class SecondaryEndPointBVT : HTTPS.SecondaryEndPointBVT
    {
        [ClassInitialize()]
        public static void SecondaryEndPointHTTPBVTClassInitialize(TestContext testContext)
        {
            //first set the storage account
            //second init common bvt
            //third set storage context in powershell
            useHttps = false;
            isSecondary = true;
            SetUpStorageAccount = TestBase.GetCloudStorageAccountFromConfig("Secondary", useHttps);
            StorageAccountName = SetUpStorageAccount.Credentials.AccountName;
            string StorageEndPoint = Test.Data.Get("SecondaryStorageEndPoint");
            CLICommonBVT.CLICommonBVTInitialize(testContext);
            PowerShellAgent.SetStorageContext(SetUpStorageAccount.ToString(true));
        }

        [ClassCleanup()]
        public static void SecondaryEndPointHTTPBVTCleanup()
        {
            CLICommonBVT.CLICommonBVTCleanup();
        }
    }
}
