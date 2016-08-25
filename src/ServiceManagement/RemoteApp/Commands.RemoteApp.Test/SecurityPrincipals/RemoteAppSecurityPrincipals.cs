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

namespace Microsoft.WindowsAzure.Commands.RemoteApp.Test
{
    using LocalModels;
    using Common;
    using Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets;
    using Microsoft.WindowsAzure.Management.RemoteApp.Models;
    using System;
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class AzureRemoteAppServiceUser : RemoteAppClientTest
    {
        private string userName = "user1";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAllUsers()
        {
            int countOfExpectedUsers = 0;
            GetAzureRemoteAppUser MockCmdlet = SetUpTestCommon<GetAzureRemoteAppUser>();

            // Required parameters for this test
            MockCmdlet.CollectionName = collectionName;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, collectionName);
            countOfExpectedUsers = MockObject.SetUpDefaultRemoteAppSecurityPrincipals(remoteAppManagementClientMock, collectionName, userName);
            MockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppUser which should have {0} users.", countOfExpectedUsers);

            MockCmdlet.ExecuteCmdlet();
            if (MockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppUser returned the following error {0}.",
                        MockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<ConsentStatusModel> users = MockObject.ConvertList<ConsentStatusModel>(MockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(users);

            Assert.True(users.Count == countOfExpectedUsers,
                String.Format("The expected number of users returned {0} does not match the actual {1}.",
                    countOfExpectedUsers,
                    users.Count
                )
            );

            Assert.True(MockObject.ContainsExpectedServicePrincipalList(MockObject.mockUsersConsents, users),
                "The actual result does not match the expected"
            );

            Log("The test for Get-AzureRemoteAppUser with {0} users completed successfully.", countOfExpectedUsers);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAllUsersForApp()
        {
            int countOfExpectedUsers = 0;
            GetAzureRemoteAppUser MockCmdlet = SetUpTestCommon<GetAzureRemoteAppUser>();

            // Required parameters for this test
            MockCmdlet.CollectionName = collectionName;
            MockCmdlet.Alias = appAlias;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, collectionName);
            countOfExpectedUsers = MockObject.SetUpRemoteAppSecurityPrincipalsForApp(remoteAppManagementClientMock, collectionName, appAlias, userName);
            MockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppUser which should have {0} users.", countOfExpectedUsers);

            MockCmdlet.ExecuteCmdlet();
            if (MockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppUser returned the following error {0}.",
                        MockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<ConsentStatusModel> users = MockObject.ConvertList<ConsentStatusModel>(MockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(users);

            Assert.True(users.Count == countOfExpectedUsers,
                String.Format("The expected number of users returned {0} does not match the actual {1}.",
                    countOfExpectedUsers,
                    users.Count
                )
            );

            Assert.True(MockObject.ContainsExpectedServicePrincipalList(MockObject.mockUsersConsents, users),
                "The actual result does not match the expected"
            );

            Log("The test for Get-AzureRemoteAppUser with {0} users completed successfully.", countOfExpectedUsers);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetUsersByName()
        {
            int countOfExpectedUsers = 1;
            GetAzureRemoteAppUser MockCmdlet = SetUpTestCommon<GetAzureRemoteAppUser>();

            // Required parameters for this test
            MockCmdlet.CollectionName = collectionName;
            MockCmdlet.UserUpn = userName;

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, collectionName);
            MockObject.SetUpDefaultRemoteAppSecurityPrincipals(remoteAppManagementClientMock, collectionName, userName);
            MockCmdlet.ResetPipelines();

            Log("Calling Get-AzureRemoteAppUser to get this user {0}.", MockCmdlet.UserUpn);

            MockCmdlet.ExecuteCmdlet();

            if (MockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Get-AzureRemoteAppUser returned the following error {0}.",
                        MockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<ConsentStatusModel> users = MockObject.ConvertList<ConsentStatusModel>(MockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(users);

            Assert.True(users.Count == countOfExpectedUsers,
                String.Format("The expected number of users returned {0} does not match the actual {1}.",
                    countOfExpectedUsers,
                    users.Count
                )
            );

            Assert.True(MockObject.ContainsExpectedServicePrincipalList(MockObject.mockUsersConsents, users),
                "The actual result does not match the expected"
            );

            Log("The test for Get-AzureRemoteAppUser with {0} users completed successfully.", countOfExpectedUsers);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddMSAUserThatDoesntExist()
        {
            int countOfExistingUsers = 0;
            int countOfNewUsers = 0;
            AddAzureRemoteAppUser MockCmdlet = SetUpTestCommon<AddAzureRemoteAppUser>();

            // Required parameters for this test
            MockCmdlet.CollectionName = collectionName;
            MockCmdlet.UserUpn = new string[]
            {
                "testUser1",
                "testUser2",
            };

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, collectionName);
            countOfExistingUsers = MockObject.SetUpDefaultRemoteAppSecurityPrincipals(remoteAppManagementClientMock, collectionName, userName);
            countOfNewUsers = MockObject.SetUpRemoteAppUserToAdd(remoteAppManagementClientMock, collectionName, PrincipalProviderType.MicrosoftAccount, MockCmdlet.UserUpn);
            MockCmdlet.ResetPipelines();

            Log("Calling Add-AzureRemoteAppMSAUser and adding {0} users.", countOfNewUsers);

            MockCmdlet.ExecuteCmdlet();
            if (MockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Add-AzureRemoteAppMSAUser returned the following error {0}.",
                        MockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<SecurityPrincipalOperationsResult> status = MockObject.ConvertList<SecurityPrincipalOperationsResult>(MockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(status);

            Assert.True(MockObject.HasExpectedResults<SecurityPrincipalOperationsResult>(status, MockObject.ContainsExpectedStatus),
                   "The actual result does not match the expected."
            );

            Log("The test for Add-AzureRemoteAppMSAUser successfully added {0} users the new count is {1}.", countOfNewUsers, countOfExistingUsers + countOfNewUsers);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddOrgIDUserThatDoesntExist()
        {
            int countOfExistingUsers = 0;
            int countOfNewUsers = 0;
            AddAzureRemoteAppUser MockCmdlet = SetUpTestCommon<AddAzureRemoteAppUser>();

            // Required parameters for this test
            MockCmdlet.CollectionName = collectionName;
            MockCmdlet.Type = PrincipalProviderType.OrgId;
            MockCmdlet.UserUpn = new string[]
            {
                "testUser1",
                "testUser2",
            };

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, collectionName);
            countOfExistingUsers = MockObject.SetUpDefaultRemoteAppSecurityPrincipals(remoteAppManagementClientMock, collectionName, userName);
            countOfNewUsers = MockObject.SetUpRemoteAppUserToAdd(remoteAppManagementClientMock, collectionName, PrincipalProviderType.OrgId, MockCmdlet.UserUpn);
            MockCmdlet.ResetPipelines();

            Log("Calling Add-AzureRemoteAppOrgIDUser and adding {0} users.", countOfNewUsers);

            MockCmdlet.ExecuteCmdlet();
            if (MockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Add-AzureRemoteAppOrgIDUser returned the following error {0}.",
                        MockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<SecurityPrincipalOperationsResult> status = MockObject.ConvertList<SecurityPrincipalOperationsResult>(MockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(status);

            Assert.True(MockObject.HasExpectedResults<SecurityPrincipalOperationsResult>(status, MockObject.ContainsExpectedStatus),
                   "The actual result does not match the expected."
            );

            Log("The test for Add-AzureRemoteAppOrgIDUser successfully added {0} users the new count is {1}.", countOfNewUsers, countOfExistingUsers + countOfNewUsers);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddUsersToApp()
        {
            int countOfExistingUsers = 0;
            int countOfNewUsers = 0;
            AddAzureRemoteAppUser MockCmdlet = SetUpTestCommon<AddAzureRemoteAppUser>();

            // Required parameters for this test
            MockCmdlet.CollectionName = collectionName;
            MockCmdlet.Alias = appAlias;
            MockCmdlet.Type = PrincipalProviderType.OrgId;
            MockCmdlet.UserUpn = new string[]
            {
                "testUser1",
                "testUser2",
            };

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, collectionName);
            countOfExistingUsers = MockObject.SetUpDefaultRemoteAppSecurityPrincipals(remoteAppManagementClientMock, collectionName, userName);
            countOfNewUsers = MockObject.SetUpRemoteAppUserToAddForApp(remoteAppManagementClientMock, collectionName, appAlias, PrincipalProviderType.OrgId, MockCmdlet.UserUpn);
            MockCmdlet.ResetPipelines();

            Log("Calling Add-AzureRemoteAppOrgIDUser and adding {0} users.", countOfNewUsers);

            MockCmdlet.ExecuteCmdlet();
            if (MockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Add-AzureRemoteAppOrgIDUser returned the following error {0}.",
                        MockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<SecurityPrincipalOperationsResult> status = MockObject.ConvertList<SecurityPrincipalOperationsResult>(MockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(status);

            Assert.True(MockObject.HasExpectedResults<SecurityPrincipalOperationsResult>(status, MockObject.ContainsExpectedStatus),
                   "The actual result does not match the expected."
            );

            Log("The test for Add-AzureRemoteAppOrgIDUser successfully added {0} users the new count is {1}.", countOfNewUsers, countOfExistingUsers + countOfNewUsers);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveUserThatExistsFromApp()
        {
            int countOfExistingUsers = 0;
            int countOfDeletedUsers = 0;
            RemoveAzureRemoteAppUser MockCmdlet = SetUpTestCommon<RemoveAzureRemoteAppUser>();

            // Required parameters for this test
            MockCmdlet.CollectionName = collectionName;
            MockCmdlet.Alias = appAlias;
            MockCmdlet.Type = PrincipalProviderType.OrgId;
            MockCmdlet.UserUpn = new string[]
            {
                userName
            };

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, collectionName);
            countOfExistingUsers = MockObject.SetUpDefaultRemoteAppSecurityPrincipals(remoteAppManagementClientMock, collectionName, userName);
            countOfDeletedUsers = MockObject.SetUpRemoteAppUserToRemoveFromApp(remoteAppManagementClientMock, collectionName, appAlias, PrincipalProviderType.OrgId, MockCmdlet.UserUpn);
            MockCmdlet.ResetPipelines();

            Log("Calling Remove-AzureRemoteAppOrgIdUser and removing {0} users.", countOfDeletedUsers);

            MockCmdlet.ExecuteCmdlet();
            if (MockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Remove-AzureRemoteAppMSAUser returned the following error {0}.",
                        MockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<SecurityPrincipalOperationsResult> status = MockObject.ConvertList<SecurityPrincipalOperationsResult>(MockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(status);

            Assert.True(MockObject.HasExpectedResults<SecurityPrincipalOperationsResult>(status, MockObject.ContainsExpectedStatus),
                   "The actual result does not match the expected."
            );

            Log("The test for Remove-AzureRemoteAppOrgIdUser successfully removed {0} users the new count is {1}.", countOfDeletedUsers, countOfExistingUsers - countOfDeletedUsers);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveMSAUserThatExists()
        {
            int countOfExistingUsers = 0;
            int countOfDeletedUsers = 0;
            RemoveAzureRemoteAppUser MockCmdlet = SetUpTestCommon<RemoveAzureRemoteAppUser>();

            // Required parameters for this test
            MockCmdlet.CollectionName = collectionName;
            MockCmdlet.Type = PrincipalProviderType.MicrosoftAccount;
            MockCmdlet.UserUpn = new string[]
            {
                userName
            };

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, collectionName);
            countOfExistingUsers = MockObject.SetUpDefaultRemoteAppSecurityPrincipals(remoteAppManagementClientMock, collectionName, userName);
            countOfDeletedUsers = MockObject.SetUpDefaultRemoteAppUserToRemove(remoteAppManagementClientMock, collectionName, PrincipalProviderType.MicrosoftAccount, MockCmdlet.UserUpn);
            MockCmdlet.ResetPipelines();

            Log("Calling Remove-AzureRemoteAppMSAUser and removing {0} users.", countOfDeletedUsers);

            MockCmdlet.ExecuteCmdlet();
            if (MockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Remove-AzureRemoteAppMSAUser returned the following error {0}.",
                        MockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<SecurityPrincipalOperationsResult> status = MockObject.ConvertList<SecurityPrincipalOperationsResult>(MockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(status);

            Assert.True(MockObject.HasExpectedResults<SecurityPrincipalOperationsResult>(status, MockObject.ContainsExpectedStatus),
                   "The actual result does not match the expected."
            );

            Log("The test for Remove-AzureRemoteAppMSAUser successfully removed {0} users the new count is {1}.", countOfDeletedUsers, countOfExistingUsers - countOfDeletedUsers);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveOrgIDUserThatExists()
        {
            int countOfExistingUsers = 0;
            int countOfDeletedUsers = 0;
            RemoveAzureRemoteAppUser MockCmdlet = SetUpTestCommon<RemoveAzureRemoteAppUser>();

            // Required parameters for this test
            MockCmdlet.CollectionName = collectionName;
            MockCmdlet.Type = PrincipalProviderType.OrgId;
            MockCmdlet.UserUpn = new string[]
            {
                userName
            };

            // Setup the environment for testing this cmdlet
            MockObject.SetUpDefaultRemoteAppCollectionByName(remoteAppManagementClientMock, collectionName);
            countOfExistingUsers = MockObject.SetUpDefaultRemoteAppSecurityPrincipals(remoteAppManagementClientMock, collectionName, userName);
            countOfDeletedUsers = MockObject.SetUpDefaultRemoteAppUserToRemove(remoteAppManagementClientMock, collectionName, PrincipalProviderType.OrgId, MockCmdlet.UserUpn);
            MockCmdlet.ResetPipelines();

            Log("Calling Remove-AzureRemoteAppOrgIdUser and removing {0} users.", countOfDeletedUsers);

            MockCmdlet.ExecuteCmdlet();
            if (MockCmdlet.runTime().ErrorStream.Count != 0)
            {
                Assert.True(false,
                    String.Format("Remove-AzureRemoteAppMSAUser returned the following error {0}.",
                        MockCmdlet.runTime().ErrorStream[0].Exception.Message
                    )
                );
            }

            List<SecurityPrincipalOperationsResult> status = MockObject.ConvertList<SecurityPrincipalOperationsResult>(MockCmdlet.runTime().OutputPipeline);
            Assert.NotNull(status);

            Assert.True(MockObject.HasExpectedResults<SecurityPrincipalOperationsResult>(status, MockObject.ContainsExpectedStatus),
                   "The actual result does not match the expected."
            );

            Log("The test for Remove-AzureRemoteAppOrgIdUser successfully removed {0} users the new count is {1}.", countOfDeletedUsers, countOfExistingUsers - countOfDeletedUsers);
        }
    }
}
