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
    using LocalModels;
    using Microsoft.WindowsAzure.Management.RemoteApp;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using Moq;
    using Moq.Language.Flow;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class MockObject
    {
        public static int SetUpDefaultRemoteAppSecurityPrincipals(Mock<IRemoteAppManagementClient> clientMock, string collectionName, string userName)
        {
            SecurityPrincipalInfoListResult response = new SecurityPrincipalInfoListResult();

            response.SecurityPrincipalInfoList = new List<SecurityPrincipalInfo>()
            {
                new SecurityPrincipalInfo()
                {
                    SecurityPrincipal = new SecurityPrincipal()
                    {
                        Name = userName,
                        SecurityPrincipalType = PrincipalType.User,
                        UserIdType = PrincipalProviderType.OrgId,
                    },
                    Status = ConsentStatus.Pending
                },
                new SecurityPrincipalInfo()
                {
                    SecurityPrincipal = new SecurityPrincipal()
                    {
                        Name = "user2",
                        SecurityPrincipalType = PrincipalType.User,
                        UserIdType = PrincipalProviderType.OrgId,
                    },
                    Status = ConsentStatus.Pending
                },
            };

            mockUsersConsents = new List<ConsentStatusModel>();
            foreach (SecurityPrincipalInfo consent in response.SecurityPrincipalInfoList)
            {
                mockUsersConsents.Add(new ConsentStatusModel(consent));
            };

           ISetup<IRemoteAppManagementClient, Task<SecurityPrincipalInfoListResult>> setup = clientMock.Setup(c => c.Principals.ListAsync(collectionName, It.IsAny<CancellationToken>()));
           setup.Returns(Task.Factory.StartNew(() => response));

           return mockUsersConsents.Count;
        }

        public static int SetUpRemoteAppSecurityPrincipalsForApp(Mock<IRemoteAppManagementClient> clientMock, string collectionName, string appAlias, string userName)
        {
            SecurityPrincipalInfoListResult response = new SecurityPrincipalInfoListResult();

            response.SecurityPrincipalInfoList = new List<SecurityPrincipalInfo>()
            {
                new SecurityPrincipalInfo()
                {
                    SecurityPrincipal = new SecurityPrincipal()
                    {
                        Name = userName,
                        SecurityPrincipalType = PrincipalType.User,
                        UserIdType = PrincipalProviderType.OrgId,
                    },
                    Status = ConsentStatus.Pending
                },
                new SecurityPrincipalInfo()
                {
                    SecurityPrincipal = new SecurityPrincipal()
                    {
                        Name = "user2",
                        SecurityPrincipalType = PrincipalType.User,
                        UserIdType = PrincipalProviderType.OrgId,
                    },
                    Status = ConsentStatus.Pending
                },
            };

            mockUsersConsents = new List<ConsentStatusModel>();
            foreach (SecurityPrincipalInfo consent in response.SecurityPrincipalInfoList)
            {
                mockUsersConsents.Add(new ConsentStatusModel(consent));
            };

            ISetup<IRemoteAppManagementClient, Task<SecurityPrincipalInfoListResult>> setup = clientMock.Setup(c => c.Principals.ListForAppAsync(collectionName, appAlias, It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            return mockUsersConsents.Count;
        }

        public static int SetUpRemoteAppUserToAdd(Mock<IRemoteAppManagementClient> clientMock, string collectionName, PrincipalProviderType userIdType, string[] userNames)
        {
            SecurityPrincipalOperationsResult response = new SecurityPrincipalOperationsResult()
            {
                RequestId = "122-13342",
                TrackingId = "2334-323456",
                StatusCode = System.Net.HttpStatusCode.Accepted,
                Errors = null,
            };

            mockSecurityPrincipalResult = new List<SecurityPrincipalOperationsResult>()
            {
                new SecurityPrincipalOperationsResult()
                {
                    RequestId = response.RequestId,
                    TrackingId = response.TrackingId,
                    StatusCode = response.StatusCode,
                    Errors = response.Errors
                },
            };

            SecurityPrincipalList spAdd = new SecurityPrincipalList();

            foreach (string userName in userNames)
            {
                SecurityPrincipal mockUser = new SecurityPrincipal()
                {
                    Name = userName,
                    SecurityPrincipalType = PrincipalType.User,
                    UserIdType = userIdType,
                };
                spAdd.SecurityPrincipals.Add(mockUser);
            }

            ISetup<IRemoteAppManagementClient, Task<SecurityPrincipalOperationsResult>> setup = clientMock.Setup(c => c.Principals.AddAsync(collectionName, It.IsAny<SecurityPrincipalList>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            mockUsers = spAdd.SecurityPrincipals;

            return mockUsers.Count;
        }

        public static int SetUpDefaultRemoteAppUserToRemove(Mock<IRemoteAppManagementClient> clientMock, string collectionName, PrincipalProviderType userIdType, string[] userNames)
        {
            SecurityPrincipalOperationsResult response = new SecurityPrincipalOperationsResult()
            {
                RequestId = "122-13342",
                TrackingId = "1348570-182754",
                StatusCode = System.Net.HttpStatusCode.Accepted,
                Errors = null
            };
            mockSecurityPrincipalResult = new List<SecurityPrincipalOperationsResult>()
            {
                new SecurityPrincipalOperationsResult()
                {
                    RequestId = response.RequestId,
                    TrackingId = response.TrackingId,
                    StatusCode = response.StatusCode,
                    Errors = response.Errors
                },
            };

            SecurityPrincipalList spRemove = new SecurityPrincipalList();

            foreach (string userName in userNames)
            {
                SecurityPrincipal mockUser = new SecurityPrincipal()
                {
                    Name = userName,
                    SecurityPrincipalType = PrincipalType.User,
                    UserIdType = userIdType,
                };
                spRemove.SecurityPrincipals.Add(mockUser);
            }

            ISetup<IRemoteAppManagementClient, Task<SecurityPrincipalOperationsResult>> setup = clientMock.Setup(c => c.Principals.DeleteAsync(collectionName, It.IsAny<SecurityPrincipalList>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            mockUsers = spRemove.SecurityPrincipals;

            return mockUsers.Count;
        }

        public static int SetUpRemoteAppUserToAddForApp(Mock<IRemoteAppManagementClient> clientMock, string collectionName, string appAlias, PrincipalProviderType userIdType, string[] userNames)
        {
            SecurityPrincipalOperationsResult response = new SecurityPrincipalOperationsResult()
            {
                RequestId = "122-13342",
                TrackingId = "2334-323456",
                StatusCode = System.Net.HttpStatusCode.Accepted,
                Errors = null,
            };

            mockSecurityPrincipalResult = new List<SecurityPrincipalOperationsResult>()
            {
                new SecurityPrincipalOperationsResult()
                {
                    RequestId = response.RequestId,
                    TrackingId = response.TrackingId,
                    StatusCode = response.StatusCode,
                    Errors = response.Errors
                },
            };

            SecurityPrincipalList spAdd = new SecurityPrincipalList();

            foreach (string userName in userNames)
            {
                SecurityPrincipal mockUser = new SecurityPrincipal()
                {
                    Name = userName,
                    SecurityPrincipalType = PrincipalType.User,
                    UserIdType = userIdType,
                };
                spAdd.SecurityPrincipals.Add(mockUser);
            }

            ISetup<IRemoteAppManagementClient, Task<SecurityPrincipalOperationsResult>> setup = clientMock.Setup(c => c.Principals.AddToAppAsync(collectionName, appAlias, It.IsAny<SecurityPrincipalList>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            mockUsers = spAdd.SecurityPrincipals;

            return mockUsers.Count;
        }

        public static int SetUpRemoteAppUserToRemoveFromApp(Mock<IRemoteAppManagementClient> clientMock, string collectionName, string appAlias, PrincipalProviderType userIdType, string[] userNames)
        {
            SecurityPrincipalOperationsResult response = new SecurityPrincipalOperationsResult()
            {
                RequestId = "122-13342",
                TrackingId = "1348570-182754",
                StatusCode = System.Net.HttpStatusCode.Accepted,
                Errors = null
            };
            mockSecurityPrincipalResult = new List<SecurityPrincipalOperationsResult>()
            {
                new SecurityPrincipalOperationsResult()
                {
                    RequestId = response.RequestId,
                    TrackingId = response.TrackingId,
                    StatusCode = response.StatusCode,
                    Errors = response.Errors
                },
            };

            SecurityPrincipalList spRemove = new SecurityPrincipalList();

            foreach (string userName in userNames)
            {
                SecurityPrincipal mockUser = new SecurityPrincipal()
                {
                    Name = userName,
                    SecurityPrincipalType = PrincipalType.User,
                    UserIdType = userIdType,
                };
                spRemove.SecurityPrincipals.Add(mockUser);
            }

            ISetup<IRemoteAppManagementClient, Task<SecurityPrincipalOperationsResult>> setup = clientMock.Setup(c => c.Principals.DeleteFromAppAsync(collectionName, appAlias, It.IsAny<SecurityPrincipalList>(), It.IsAny<CancellationToken>()));
            setup.Returns(Task.Factory.StartNew(() => response));

            mockUsers = spRemove.SecurityPrincipals;

            return mockUsers.Count;
        }

        public static bool ContainsExpectedServicePrincipalList(IList<LocalModels.ConsentStatusModel> expectedResult, IList<LocalModels.ConsentStatusModel> principalList)
        {
            bool isIdentical = false;
            IList<LocalModels.ConsentStatusModel> actualResult = new List<LocalModels.ConsentStatusModel>(principalList);

            foreach (LocalModels.ConsentStatusModel expected in expectedResult)
            {
                int i = 0;

                while (i < actualResult.Count)
                {
                    bool found = false;
                    LocalModels.ConsentStatusModel actual = actualResult[i];
                    found = expected.ConsentStatus == actual.ConsentStatus;
                    found &= expected.Name == actual.Name;
                    found &= expected.UserIdType == actual.UserIdType;
                    if (found)
                    {
                        isIdentical = found;
                        break;
                    }

                    i++;
                }

                if (isIdentical && actualResult.Count > 0)
                {
                    actualResult.RemoveAt(i);
                }
                else if (actualResult.Count > 0)
                {
                    return false;
                }
            }

            return isIdentical;
        }

        public static bool ContainsExpectedServicePrincipalErrorDetails(IList<SecurityPrincipalOperationErrorDetails> expectedResult, IList<SecurityPrincipalOperationErrorDetails> errorList)
        {
            bool isIdentical = false;
            IList<SecurityPrincipalOperationErrorDetails> actualResult = new List<SecurityPrincipalOperationErrorDetails>(errorList);

            foreach (SecurityPrincipalOperationErrorDetails expected in expectedResult)
            {
                int i = 0;

                while (i < actualResult.Count)
                {
                    bool found = false;
                    SecurityPrincipalOperationErrorDetails actual = actualResult[i];
                    found = expected.Error == actual.Error;
                    found &= expected.SecurityPrincipal == actual.SecurityPrincipal;
                    if (found)
                    {
                        isIdentical = found;
                        break;
                    }

                    i++;
                }

                if (isIdentical && actualResult.Count > 0)
                {
                    actualResult.RemoveAt(i);
                }
                else if (actualResult.Count > 0)
                {
                    return false;
                }
            }

            return isIdentical;
        }

        public static bool ContainsExpectedStatus(List<SecurityPrincipalOperationsResult> expectedResult, SecurityPrincipalOperationsResult operationResult)
        {
            bool isIdentical = false;
            foreach (SecurityPrincipalOperationsResult expected in expectedResult)
            {
                isIdentical = expected.RequestId == operationResult.RequestId;
                isIdentical &= expected.StatusCode == operationResult.StatusCode;
                isIdentical &= expected.TrackingId == operationResult.TrackingId;

                if (expected.Errors != null && operationResult.Errors != null)
                {
                    if (expected.Errors.Count == operationResult.Errors.Count)
                    {
                        isIdentical &= ContainsExpectedServicePrincipalErrorDetails(expected.Errors, operationResult.Errors);
                    }
                    else
                    {
                        isIdentical = false;
                    }
                }
                else if (expected.Errors == null && operationResult.Errors != null)
                {
                    isIdentical = false;
                }
                else if (expected.Errors != null && operationResult.Errors == null)
                {
                    isIdentical = false;
                }

                if (isIdentical)
                {
                    break;
                }
            }

            return isIdentical;
        }
    }
}
