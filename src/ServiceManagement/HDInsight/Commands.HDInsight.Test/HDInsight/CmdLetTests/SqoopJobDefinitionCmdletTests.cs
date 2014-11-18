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
using Microsoft.Hadoop.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    [TestClass]
    public class SqoopJobDefinitionCmdletTests : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        public void CanCreateSDKObjectFromPowershellObject()
        {
            var sqoopJobDefinition = new AzureHDInsightSqoopJobDefinition
            {
                Command = "Import into sqlserver",
                File = "http://myfileshare.txt",
                StatusFolder = Guid.NewGuid().ToString(),
            };

            sqoopJobDefinition.Arguments.Add("arg1");
            sqoopJobDefinition.Files.Add("file1.sqoop");
            SqoopJobCreateParameters sdkObject = sqoopJobDefinition.ToSqoopJobCreateParameters();

            Assert.AreEqual(sqoopJobDefinition.StatusFolder, sdkObject.StatusFolder);
            Assert.AreEqual(sqoopJobDefinition.File, sdkObject.File);
            Assert.AreEqual(sqoopJobDefinition.Command, sdkObject.Command);

            foreach (string file in sqoopJobDefinition.Files)
            {
                Assert.IsTrue(sdkObject.Files.Contains(file), file);
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
