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

using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.WindowsAzure.Commands.RemoteApp.Test
{
    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.RemoteApp;
    using Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using Moq;
    using Moq.Language.Flow;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;

    // Get-AzureRemoteAppCollectionUsageDetails, Get-AzureRemoteAppCollectionUsageSummary, 
    [TestClass]
    public class RemoteAppVmTest : RemoteAppClientTest
    {

        [TestMethod]
        [TestCategory("CheckIn")]
        public void RestartVm()
        {
            int countOfExpectedCollections = 0;
            RestartAzureRemoteAppVm mockCmdlet = SetUpTestCommon<RestartAzureRemoteAppVm>();
            IEnumerable<TrackingResult> trackingIds = null;

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;
            mockCmdlet.UserUpn = loggedInUserUpn;

            // Setup the environment for testing this cmdlet
            countOfExpectedCollections = MockObject.SetUpDefaultRemoteAppVm(remoteAppManagementClientMock, collectionName, vmName, loggedInUserUpn, trackingId);
            mockCmdlet.ResetPipelines();

            Log("Calling Restart-AzureRemoteAppVm which should return tracking id.");

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.IsTrue(false,
                    String.Format("Restart-AzureRemoteAppVm returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            LanguagePrimitives.GetEnumerable(mockCmdlet.runTime().OutputPipeline).Cast<TrackingResult>();
            trackingIds = LanguagePrimitives.GetEnumerable(mockCmdlet.runTime().OutputPipeline).Cast<TrackingResult>();
            Assert.IsNotNull(trackingIds);

            Assert.AreEqual(1, trackingIds.Count());

            Assert.IsTrue(trackingIds.Any(t => t.TrackingId == trackingId), "The actual result does not match the expected.");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void GetVm()
        {
            int countOfExpectedVms = 0;
            GetAzureRemoteAppVm mockCmdlet = SetUpTestCommon<GetAzureRemoteAppVm>();
            IEnumerable<IList<RemoteAppVm>> result = null;
            IList<RemoteAppVm> resultVms = null;

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;

            // Setup the environment for testing this cmdlet
            countOfExpectedVms = MockObject.SetUpDefaultRemoteAppVm(remoteAppManagementClientMock, collectionName, vmName, loggedInUserUpn, trackingId);
            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppVm which should return list of Vms.");

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.IsTrue(false,
                    String.Format("Get-AzureRemoteAppVm returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            result = LanguagePrimitives.GetEnumerable(mockCmdlet.runTime().OutputPipeline).Cast<IList<RemoteAppVm>>();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());

            resultVms = result.First<IList<RemoteAppVm>>();

            Assert.AreEqual(countOfExpectedVms, resultVms.Count);
            Assert.AreEqual<string>(vmName, resultVms[0].VirtualMachineName);
            Assert.AreEqual<string>(loggedInUserUpn, resultVms[0].LoggedOnUserUpns[0]);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void GetStaleAdVmObjects()
        {
            int countOfExpectedVms = 0;
            GetAzureRemoteAppVmStaleAdObject mockCmdlet = SetUpTestCommon<GetAzureRemoteAppVmStaleAdObject>();
            IEnumerable<string> result = null;
            IList<string> resulAdObjs = null;

            string[] existingVms = new string[] {"abcdefgh0003", "abcdefgh0004", "abcdefgh0005"};
            string[] adObjects = new string[] { "abcdefgh0000", "abcdefgh0002", "abcdefgh0003", "abcdefgh0004", "abcdefgh0005", "abcdefgh0006" };
            string[] expectedResult = new string[] { "abcdefgh0000", "abcdefgh0002" };

            // Required parameters for this test
            mockCmdlet.CollectionName = collectionName;

            // Setup the environment for testing this cmdlet
            countOfExpectedVms = MockObject.SetUpStaleVmObjectsTest(
                remoteAppManagementClientMock,
                collectionName,
                existingVms
                );

            if(mockCmdlet.ActiveDirectoryHelper is MockAdHelper)
            {
                (mockCmdlet.ActiveDirectoryHelper as MockAdHelper).SetEntries(adObjects);
            }

            mockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppVmStaleAdObjects which should return list of stale Vm objects.");

            mockCmdlet.ExecuteCmdlet();
            if (mockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.IsTrue(false,
                    String.Format("Get-AzureRemoteAppVmStaleAdObjects returned the following error {0}.",
                        mockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            result = LanguagePrimitives.GetEnumerable(mockCmdlet.runTime().OutputPipeline).Cast<string>();

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult.Length, result.Count());

            foreach (string staleObj in result)
            {
                Assert.IsTrue(expectedResult.Contains(staleObj));
            }
        }
    }
}
