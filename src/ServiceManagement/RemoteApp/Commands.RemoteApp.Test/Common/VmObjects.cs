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

namespace Microsoft.WindowsAzure.Commands.RemoteApp.Test.Common
{
    using Microsoft.WindowsAzure.Management.RemoteApp;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using Moq;
    using Moq.Language.Flow;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class MockObject
    {
        public static int SetUpDefaultRemoteAppVm(Mock<IRemoteAppManagementClient> clientMock, string collectionName, string vmName, string userUpn, string trackingId)
        {
            CollectionVmsListResult response = new CollectionVmsListResult();
            OperationResultWithTrackingId restartResponse = new OperationResultWithTrackingId()
            {
                StatusCode = System.Net.HttpStatusCode.Accepted,
                TrackingId = trackingId,
                RequestId = "111-2222-4444"
            };

            response.Vms = new List<RemoteAppVm>()
            {
                new RemoteAppVm()
                {
                    VirtualMachineName = vmName,
                    LoggedOnUserUpns = { userUpn, "testuser1@somedomain.com" }
                },

                new RemoteAppVm()
                {
                    VirtualMachineName = "testVm2",
                    LoggedOnUserUpns = { "testuser2@somedomain.com" }
                }
            };

            mockVmList = new List<RemoteAppVm>();
            foreach (RemoteAppVm vm in response.Vms)
            {
                RemoteAppVm mockVm = new RemoteAppVm()
                {
                    VirtualMachineName = vm.VirtualMachineName,
                    LoggedOnUserUpns = vm.LoggedOnUserUpns
                };
                mockVmList.Add(mockVm);
            }

            ISetup<IRemoteAppManagementClient, Task<CollectionVmsListResult>> setup = clientMock.Setup(c => c.Collections.ListVmsAsync(collectionName, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            ISetup<IRemoteAppManagementClient, Task<OperationResultWithTrackingId>> setupRestart = clientMock.Setup(c => c.Collections.RestartVmAsync(collectionName, It.IsAny<RestartVmCommandParameter>(),It.IsAny<CancellationToken>()));
            setupRestart.Returns(Task.Factory.StartNew(() => restartResponse));
            
            return mockVmList.Count;
        }

        public static int SetUpStaleVmObjectsTest(Mock<IRemoteAppManagementClient> clientMock, string collectionName, string[] vmNames)
        {
            CollectionVmsListResult response = new CollectionVmsListResult();
            ActiveDirectoryConfigResult getAdResponse = new ActiveDirectoryConfigResult()
            {
                ActiveDirectoryConfig = new ActiveDirectoryConfig()
                {
                    DomainName = "contoso.com",
                    OrganizationalUnit = null,
                    UserName = "user",
                    Password = "********"
                }
            };

            response.Vms = new List<RemoteAppVm>();
            foreach(string vmName in vmNames)
            {
                response.Vms.Add(new RemoteAppVm()
                    {
                        VirtualMachineName = vmName,
                        LoggedOnUserUpns = { }
                    });
            };

            mockVmList = new List<RemoteAppVm>();
            foreach (RemoteAppVm vm in response.Vms)
            {
                RemoteAppVm mockVm = new RemoteAppVm()
                {
                    VirtualMachineName = vm.VirtualMachineName,
                    LoggedOnUserUpns = vm.LoggedOnUserUpns
                };
                mockVmList.Add(mockVm);
            }

            ISetup<IRemoteAppManagementClient, Task<CollectionVmsListResult>> setup = clientMock.Setup(c => c.Collections.ListVmsAsync(collectionName, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            ISetup<IRemoteAppManagementClient, Task<ActiveDirectoryConfigResult>> setupGetAd = clientMock.Setup(c => c.Collections.GetAdAsync(collectionName, It.IsAny<CancellationToken>()));
            setupGetAd.Returns(Task.Factory.StartNew(() => getAdResponse));

            return mockVmList.Count;
        }
    
    }
}
