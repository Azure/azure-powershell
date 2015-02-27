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

namespace Microsoft.Azure.Commands.Test.RemoteApp
{
    using Common;
    using Microsoft.Azure.Management.RemoteApp.Cmdlets;
    using Microsoft.Azure.Management.RemoteApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using VisualStudio.TestTools.UnitTesting;

    // Publish-AzureRemoteAppProgram, Unpublish-AzureRemoteAppProgram

    [TestClass]
    public class RemoteAppProgramTest : RemoteAppClientTest
    {

        [TestMethod]
        public void GetAllRemoteApps()
        {
            List<PublishedApplicationDetails> remoteApps = null;
            int countOfExpectedApps = 0;
            GetAzureRemoteAppProgram mockCmdlet = SetUpTestCommon<GetAzureRemoteAppProgram>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, mockCmdlet.CollectionName);
            countOfExpectedApps = MockObject.SetUpDefaultRemoteAppApplications(remoteAppManagementClientMock, mockCmdlet.CollectionName);

            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppCollection which should have {0} collections.", countOfExpectedApps);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("Get-AzureRemoteAppCollection returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            remoteApps = MockObject.ConvertList<PublishedApplicationDetails>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(remoteApps);

            Assert.IsTrue(remoteApps.Count == countOfExpectedApps,
               String.Format("The expected number of collections returned {0} does not match the actual {1}.",
                   countOfExpectedApps,
                   remoteApps.Count
               )
           );

            Assert.IsTrue(MockObject.HasExpectedResults<PublishedApplicationDetails>(remoteApps, MockObject.ContainsExpectedApplication),
               "The actual result does not match the expected."
           );

            Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", countOfExpectedApps);
        }

        [TestMethod]
        [Ignore]
        public void GetRemoteAppByName()
        {
            List<PublishedApplicationDetails> remoteApps = null;
            int countOfExpectedApps = 0;
            GetAzureRemoteAppProgram mockCmdlet = SetUpTestCommon<GetAzureRemoteAppProgram>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.RemoteAppProgram = remoteApplication;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, mockCmdlet.CollectionName);
            countOfExpectedApps = MockObject.SetUpDefaultRemoteAppApplicationsByName(remoteAppManagementClientMock, mockCmdlet.CollectionName, mockCmdlet.RemoteAppProgram);

            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppCollection which should have {0} collections.", countOfExpectedApps);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("Get-AzureRemoteAppCollection returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            remoteApps = MockObject.ConvertList<PublishedApplicationDetails>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(remoteApps);

            Assert.IsTrue(remoteApps.Count == countOfExpectedApps,
               String.Format("The expected number of collections returned {0} does not match the actual {1}.",
                   countOfExpectedApps,
                   remoteApps.Count
               )
           );

            Assert.IsTrue(MockObject.HasExpectedResults<PublishedApplicationDetails>(remoteApps, MockObject.ContainsExpectedApplication),
               "The actual result does not match the expected."
           );

            Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", countOfExpectedApps);
        }

        [TestMethod]
        [Ignore]
        public void GetAllStartMenuApplication()
        {
            List<StartMenuApplication> remoteApps = null;
            int countOfExpectedApps = 0;
            GetStartMenuProgram mockCmdlet = SetUpTestCommon<GetStartMenuProgram>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, mockCmdlet.CollectionName);
            countOfExpectedApps = MockObject.SetUpDefaultRemoteAppStartMenu(remoteAppManagementClientMock, mockCmdlet.CollectionName);

            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppCollection which should have {0} collections.", countOfExpectedApps);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("Get-AzureRemoteAppCollection returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            remoteApps = MockObject.ConvertList<StartMenuApplication>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(remoteApps);

            Assert.IsTrue(remoteApps.Count == countOfExpectedApps,
               String.Format("The expected number of collections returned {0} does not match the actual {1}.",
                   countOfExpectedApps,
                   remoteApps.Count
               )
           );

            Assert.IsTrue(MockObject.HasExpectedResults<StartMenuApplication>(remoteApps, MockObject.ContainsExpectedStartMenu),
               "The actual result does not match the expected."
           );

            Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", countOfExpectedApps);
        }

        [TestMethod]
        [Ignore]
        public void GetStartMenuApplicationByName()
        {
            List<StartMenuApplication> remoteApps = null;
            int countOfExpectedApps = 1;
            GetStartMenuProgram mockCmdlet = SetUpTestCommon<GetStartMenuProgram>();

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.ProgramName = "notepad";

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, mockCmdlet.CollectionName);
            MockObject.SetUpDefaultRemoteAppStartMenu(remoteAppManagementClientMock, mockCmdlet.CollectionName);
            countOfExpectedApps = MockObject.SetUpDefaultRemoteAppStartMenuByName(remoteAppManagementClientMock, mockCmdlet.CollectionName, mockCmdlet.ProgramName);

            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppCollection which should have {0} collections.", countOfExpectedApps);

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.Fail(
                    String.Format("Get-AzureRemoteAppCollection returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            remoteApps = MockObject.ConvertList<StartMenuApplication>(mockCmdlet.runTime().OutputPipeline);
            Assert.IsNotNull(remoteApps);

            Assert.IsTrue(remoteApps.Count == countOfExpectedApps,
               String.Format("The expected number of collections returned {0} does not match the actual {1}.",
                   countOfExpectedApps,
                   remoteApps.Count
               )
           );

            Assert.IsTrue(MockObject.HasExpectedResults<StartMenuApplication>(remoteApps, MockObject.ContainsExpectedStartMenu),
               "The actual result does not match the expected."
           );

            Log("The test for Get-AzureRemoteAppCollection with {0} collections completed successfully", countOfExpectedApps);
        }
    }
}
