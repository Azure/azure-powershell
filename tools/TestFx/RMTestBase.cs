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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System;
using System.Management.Automation;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    /// <summary>
    /// Base class for Microsoft Azure PowerShell unit tests.
    /// </summary>
    public abstract class RMTestBase
    {
        protected AzureRmProfile currentProfile;

        public RMTestBase()
        {
            System.Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            BaseSetup();
        }

        /// <summary>
        /// Initialize the necessary environment for the tests.
        /// </summary>
        public void BaseSetup()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            currentProfile = new AzureRmProfile();
            var newGuid = Guid.NewGuid();
            var account = new AzureAccount
            {
                Id = "test",
                Type = AzureAccount.AccountType.User,
            };
            account.SetSubscriptions(newGuid.ToString());
            var subscription = new AzureSubscription { Id = newGuid.ToString(), Name = "test" };
            subscription.SetAccount("test");
            subscription.SetEnvironment(EnvironmentName.AzureCloud);
            currentProfile.DefaultContext = new AzureContext(
                subscription,
                account,
            AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
            new AzureTenant { Id = Guid.NewGuid().ToString(), Directory = "testdomain.onmicrosoft.com" });
            AzureRmProfileProvider.Instance.Profile = currentProfile;

            // Now override AzureSession.Instance.DataStore to use the MemoryDataStore
            if (AzureSession.Instance.DataStore != null && !(AzureSession.Instance.DataStore is MemoryDataStore))
            {
                AzureSession.Instance.DataStore = new MemoryDataStore();
            }

            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            TestMockSupport.RunningMocked = true;
            //This is needed for AutoRest Authentication
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
        }

        /// <summary>
        /// Set up the command runtime to return true for all confirmation prompts
        /// </summary>
        /// <param name="mock">The mock command runtiem to set up</param>
        public static void SetupConfirmation(Mock<ICommandRuntime> mock)
        {
            mock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);
            mock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            mock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            mock.Setup(f => f.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        }
    }
}
