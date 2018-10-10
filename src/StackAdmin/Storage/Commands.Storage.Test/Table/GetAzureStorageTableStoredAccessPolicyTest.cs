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
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;
    using Microsoft.WindowsAzure.Storage.Table;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using System;
    using System.Collections.Generic;

    public class GetAzureStorageTableStoredAccessPolicyTest : StorageTableStorageTestBase
    {
        public GetAzureStorageTableStoredAccessPolicyCommand command = null;

        public GetAzureStorageTableStoredAccessPolicyTest()
        {
            command = new GetAzureStorageTableStoredAccessPolicyCommand(tableMock)
            {
                CommandRuntime = MockCmdRunTime
            };
            CurrentTableCmd = command;
        }

        public void GetStoredAccessPolicyNotExistsTest()
        {
            AddTestStoredAccessPolicy();
            string policyName = "Policy" + Guid.NewGuid();
            string tableName = "sampleTable";

            MockCmdRunTime.ResetPipelines();
            command.Table = tableName;
            command.Policy = policyName;
            RunAsyncCommand(() => command.ExecuteCmdlet());

            Assert.Equal(0, MockCmdRunTime.OutputPipeline.Count);
           
            MockCmdRunTime.ResetPipelines();
            clearTest();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStoredAccessPolicySuccessTest()
        {
            AddTestStoredAccessPolicy();
            string policyName = TestPolicy1;
            string tableName = "sampleTable";

            MockCmdRunTime.ResetPipelines();
            command.Table = tableName;
            command.Policy = policyName;
            RunAsyncCommand(() => command.ExecuteCmdlet());

            Assert.Equal(1, MockCmdRunTime.OutputPipeline.Count);

            MockCmdRunTime.ResetPipelines();
            clearTest();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAllStoredAccessPolicySuccessTest()
        {
            AddTestStoredAccessPolicy();
            string tableName = "sampleTable";

            MockCmdRunTime.ResetPipelines();
            command.Table = tableName;
            RunAsyncCommand(() => command.ExecuteCmdlet());

            Assert.Equal(2, MockCmdRunTime.OutputPipeline.Count);

            MockCmdRunTime.ResetPipelines();
            clearTest();
        }
    }
}
