// ----------------------------------------------------------------------------------
//
// Copyright 2012 Microsoft Corporation
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

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Table
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;

    [TestClass]
    public class GetAzureStorageTableStoredAccessPolicyTest : StorageTableStorageTestBase
    {
        public GetAzureStorageTableStoredAccessPolicyCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new GetAzureStorageTableStoredAccessPolicyCommand(tableMock)
            {
                CommandRuntime = MockCmdRunTime
            };
            CurrentTableCmd = command;
        }

        [TestCleanup]
        public void CleanCommand()
        {
            this.clearTest();
            command = null;
        }

        //[TestMethod]
        public void GetStoredAccessPolicyNotExistsTest()
        {
            ClearAndAddTestStoredAccessPolicies();
            string policyName = "Policy" + Guid.NewGuid();
            string tableName = "sampleTable";

            MockCmdRunTime.ResetPipelines();
            command.Table = tableName;
            command.Policy = policyName;
            RunAsyncCommand(() => command.ExecuteCmdlet());

            Assert.AreEqual(0, MockCmdRunTime.OutputPipeline.Count);
           
            MockCmdRunTime.ResetPipelines();
            clearTest();
        }

        [TestMethod]
        public void GetStoredAccessPolicySuccessTest()
        {
            ClearAndAddTestStoredAccessPolicies();
            string policyName = PolicyName1;
            string tableName = "sampleTable";

            MockCmdRunTime.ResetPipelines();
            command.Table = tableName;
            command.Policy = policyName;
            RunAsyncCommand(() => command.ExecuteCmdlet());

            Assert.AreEqual(1, MockCmdRunTime.OutputPipeline.Count);

            MockCmdRunTime.ResetPipelines();
            clearTest();
        }

        [TestMethod]
        public void GetAllStoredAccessPolicySuccessTest()
        {
            ClearAndAddTestStoredAccessPolicies();
            string tableName = "sampleTable";

            MockCmdRunTime.ResetPipelines();
            command.Table = tableName;
            RunAsyncCommand(() => command.ExecuteCmdlet());

            Assert.AreEqual(2, MockCmdRunTime.OutputPipeline.Count);

            MockCmdRunTime.ResetPipelines();
            clearTest();
        }
    }
}
