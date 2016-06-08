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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CommandTests
{
    [TestClass]
    public class StorageAbstractionTests : HDInsightTestCaseBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("Scenario")]
        public void CanWriteHiveQueryFile()
        {
            this.ApplyIndividualTestMockingOnly();
            var wellKnownStorageAccount = IntegrationTestBase.GetWellKnownStorageAccounts().First();
            var wabsStorageClient = new AzureHDInsightStorageHandler(wellKnownStorageAccount);
            string hiveQueryFilePath = string.Format(CultureInfo.InvariantCulture,
                "http://{0}/{1}/user/{2}/{3}.hql",
                wellKnownStorageAccount.Name,
                wellKnownStorageAccount.Container,
                IntegrationTestBase.TestCredentials.HadoopUserName,
                Guid.NewGuid().ToString("N"));
            var testFilePath = new Uri(hiveQueryFilePath, UriKind.RelativeOrAbsolute);
            var bytes = Encoding.UTF8.GetBytes("Select * from hivesampletable where name like '%bat%'");
            using (var stream = new MemoryStream(bytes, 0, bytes.Length))
            {
                wabsStorageClient.UploadFile(testFilePath, stream);
            }
        }
    }
}
