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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Storage.Table;
using Microsoft.WindowsAzure.Commands.Storage.Test.Service;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Table
{
    public class StorageTableStorageTestBase : StorageTestBase
    {
        public MockStorageTableManagement tableMock = null;
        public const string TestPolicy1 = "TestPolicy1";
        public const string TestPolicy2 = "TestPolicy2";

        protected StorageCloudTableCmdletBase CurrentTableCmd { get; set; }

        [TestInitialize]
        public void InitMock()
        {
            tableMock = new MockStorageTableManagement();
            MockCmdRunTime = new MockCommandRuntime();
        }

        [TestCleanup]
        public void CleanMock()
        {
            tableMock = null;
        }

        public void AddTestTables()
        {
            tableMock.tableList.Clear();
            string testUri = "https://127.0.0.1/account/test";
            string textUri = "https://127.0.0.1/account/text";
            
            tableMock.tableList.Add(new CloudTable(new Uri(testUri)));
            tableMock.tableList.Add(new CloudTable(new Uri(textUri)));
        }

        public void AddTestStoredAccessPolicy()
        {
            tableMock.tablePermissions.SharedAccessPolicies.Clear();

            SharedAccessTablePolicy testPolicy1 = new SharedAccessTablePolicy();
            testPolicy1.Permissions = SharedAccessTablePermissions.None;
            testPolicy1.Permissions |= SharedAccessTablePermissions.Query;
            testPolicy1.SharedAccessStartTime = DateTime.Today.ToUniversalTime();
            testPolicy1.SharedAccessExpiryTime = DateTime.Today.AddDays(1).ToUniversalTime();
            tableMock.tablePermissions.SharedAccessPolicies.Add(TestPolicy1, testPolicy1);

            SharedAccessTablePolicy testPolicy2 = new SharedAccessTablePolicy();
            testPolicy1.Permissions = SharedAccessTablePermissions.None;
            testPolicy1.Permissions |= SharedAccessTablePermissions.Query;
            testPolicy1.SharedAccessStartTime = DateTime.Today.ToUniversalTime();
            testPolicy1.SharedAccessExpiryTime = DateTime.Today.AddDays(1).ToUniversalTime();
            tableMock.tablePermissions.SharedAccessPolicies.Add(TestPolicy2, testPolicy2);
        }

        public void clearTest()
        {
            tableMock.tableList.Clear();
            tableMock.tablePermissions.SharedAccessPolicies.Clear();
        }

        /// <summary>
        /// Run async command
        /// </summary>
        /// <param name="cmd">Storage command</param>
        /// <param name="asyncAction">Async action</param>
        protected void RunAsyncCommand(Action asyncAction)
        {
            MockCmdRunTime.ResetPipelines();
            CurrentTableCmd.SetUpMultiThreadEnvironment();
            asyncAction();
            CurrentTableCmd.MultiThreadEndProcessing();
        }
    }
}