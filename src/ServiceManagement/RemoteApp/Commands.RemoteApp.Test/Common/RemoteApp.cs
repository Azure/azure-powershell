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
        public static int SetUpDefaultRemoteAppApplications(Mock<IRemoteAppManagementClient> clientMock, string collectionName)
        {
            ISetup<IRemoteAppManagementClient, Task<GetPublishedApplicationListResult>> setup = null;

            GetPublishedApplicationListResult response = new GetPublishedApplicationListResult()
            {
                RequestId = "122-13342",
                StatusCode = System.Net.HttpStatusCode.OK
            };

            response.ResultList = new List<PublishedApplicationDetails>()
            {
                new PublishedApplicationDetails()
                {
                    Name = "Mohoro RemoteApp1",
                    Alias = "App1",
                    AvailableToUsers = true,
                    CommandLineArguments = "Arg1, Arg2, Arg3",
                    Status =  AppPublishingStatus.Published
                },

                new PublishedApplicationDetails()
                {
                    Name = "Mohoro RemoteApp2",
                    Alias = "App2",
                    AvailableToUsers = false,
                    Status =  AppPublishingStatus.Publishing
                }
            };

            mockApplicationList = new List<PublishedApplicationDetails>();
            foreach (PublishedApplicationDetails app in response.ResultList)
            {
                PublishedApplicationDetails mockApp = new PublishedApplicationDetails()
                {
                    Name = app.Name,
                    Alias = app.Alias,
                    AvailableToUsers = app.AvailableToUsers,
                    CommandLineArguments = app.CommandLineArguments,
                    Status = app.Status
                };
                mockApplicationList.Add(mockApp);
            }

            setup = clientMock.Setup(c => c.Publishing.ListAsync(collectionName, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockApplicationList.Count;
        }

        public static int SetUpDefaultRemoteAppApplicationsByName(Mock<IRemoteAppManagementClient> clientMock, string collectionName, string alias)
        {
            ISetup<IRemoteAppManagementClient, Task<GetPublishedApplicationResult>> setup = null;

            GetPublishedApplicationResult response = new GetPublishedApplicationResult()
            {
                RequestId = "3351-98686",
                StatusCode = HttpStatusCode.OK
            };

            response.Result = new PublishedApplicationDetails()
            {
                Name = "Mohoro RemoteApp By Name",
                Alias = alias,
                AvailableToUsers = true,
                CommandLineArguments = "Arg1, Arg2, Arg3",
                Status = AppPublishingStatus.Published
            };

            mockApplicationList = new List<PublishedApplicationDetails>()
            {
                new PublishedApplicationDetails()
                {
                    Name = response.Result.Name,
                    Alias = response.Result.Alias,
                    AvailableToUsers = response.Result.AvailableToUsers,
                    CommandLineArguments = response.Result.CommandLineArguments,
                    Status = response.Result.Status
                }
            };

            setup = clientMock.Setup(c => c.Publishing.GetAsync(collectionName, alias, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockCollectionList.Count;
        }

        public static int SetUpDefaultRemoteAppStartMenu(Mock<IRemoteAppManagementClient> clientMock, string collectionName)
        {
            ISetup<IRemoteAppManagementClient, Task<GetStartMenuApplicationListResult>> setup = null;

            GetStartMenuApplicationListResult response = new GetStartMenuApplicationListResult()
            {
                RequestId = "122-13342",
                StatusCode = System.Net.HttpStatusCode.OK
            };

            response.ResultList = new List<StartMenuApplication>()
            {
                new StartMenuApplication()
                {
                    Name = "Mohoro RemoteApp1",
                    StartMenuAppId = "1",
                    VirtualPath = @"C:\Application\RemoteApp1.exe",
                    CommandLineArguments = "Arg1, Arg2, Arg3",
                    IconUri =  @"C:\Application\RemoteApp1.exe",
                },
                new StartMenuApplication()
                {
                    Name = "Mohoro RemoteApp2",
                    StartMenuAppId = "2",
                    VirtualPath = @"C:\Application\RemoteApp2.exe",
                    CommandLineArguments = "1, 86, 42",
                    IconUri = @"C:\Application\RemoteApp2.exe",
                }
            };

            mockStartMenuList = new List<StartMenuApplication>();
            foreach (StartMenuApplication app in response.ResultList)
            {
                StartMenuApplication mockApp = new StartMenuApplication()
                {
                    Name = app.Name,
                    StartMenuAppId = app.StartMenuAppId,
                    VirtualPath = app.VirtualPath,
                    CommandLineArguments = app.CommandLineArguments,
                    IconUri = app.IconUri
                };
                mockStartMenuList.Add(mockApp);
            }

            setup = clientMock.Setup(c => c.Publishing.StartMenuApplicationListAsync(collectionName, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockStartMenuList.Count;
        }

        public static int SetUpDefaultRemoteAppStartMenuByName(Mock<IRemoteAppManagementClient> clientMock, string collectionName, string programName)
        {
            ISetup<IRemoteAppManagementClient, Task<GetStartMenuApplicationResult>> setup = null;

            GetStartMenuApplicationResult response = new GetStartMenuApplicationResult()
            {
                RequestId = "122-13342",
                StatusCode = System.Net.HttpStatusCode.OK
            };

            response.Result = new StartMenuApplication()
            {
                    Name = programName,
                    StartMenuAppId = "123456",
                    VirtualPath = @"C:\Application\" + programName,
                    CommandLineArguments = "Arg1, Arg2, Arg3",
                    IconUri =  @"C:\Application\" + programName,
            };

            mockStartMenuList = new List<StartMenuApplication>()
            {
                new StartMenuApplication()
                {
                    Name = response.Result.Name,
                    StartMenuAppId = response.Result.StartMenuAppId,
                    VirtualPath = response.Result.VirtualPath,
                    CommandLineArguments = response.Result.CommandLineArguments,
                    IconUri = response.Result.IconUri
                }
            };

            setup = clientMock.Setup(c => c.Publishing.StartMenuApplicationAsync(collectionName, programName, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockStartMenuList.Count;
        }

        public static bool ContainsExpectedStartMenu(List<StartMenuApplication> expectedResult, StartMenuApplication actual)
        {
            bool isIdentical = false;

            foreach (StartMenuApplication expected in expectedResult)
            {
                isIdentical = expected.Name == actual.Name;
                isIdentical &= expected.StartMenuAppId == actual.StartMenuAppId;
                isIdentical &= expected.VirtualPath == actual.VirtualPath;
                isIdentical &= expected.CommandLineArguments == actual.CommandLineArguments;
                isIdentical &= expected.IconUri == actual.IconUri;

                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }

        public static bool ContainsExpectedApplication(List<PublishedApplicationDetails> expectedResult, PublishedApplicationDetails actual)
        {
            bool isIdentical = false;

            foreach (PublishedApplicationDetails expected in expectedResult)
            {
                isIdentical = expected.Name == actual.Name;
                isIdentical &= expected.Alias == actual.Alias;
                isIdentical &= expected.AvailableToUsers == actual.AvailableToUsers;
                isIdentical &= expected.Status == actual.Status;

                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }
    }
}
