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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    [TestClass]
    public class CmdLetIntegrationScenarioTestCaseTests : CmdletScenariosTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("Integration")]
        
        [TestCategory("JobsIntegration")]
        public override void NewHiveJob_StartJob_GetJob()
        {
            base.NewHiveJob_StartJob_GetJob();
        }

        [TestMethod]
        [TestCategory("Integration")]
        
        [TestCategory("JobsIntegration")]
        public override void NewMapReduceJob_StartJob_GetJob()
        {
            base.NewMapReduceJob_StartJob_GetJob();
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
