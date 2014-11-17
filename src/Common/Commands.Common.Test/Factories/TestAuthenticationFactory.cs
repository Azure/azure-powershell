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

using Xunit;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Factories
{
    public class TestAuthenticationFactory
    {
        [Fact]
        public void GetCloudCredentialThrowsExceptionForInvalidSubscription()
        {
            //AzureSession.DataStoreInitializer = (p) => { return new MockDataStore(); };
            //AzureSession powershell = new AzureSession();
            //var id = Guid.NewGuid();
            //powershell.Profile.Subscriptions[id] = new AzureSubscription
            //{
            //    Id = id,
            //    Name = "Test",
            //    Environment = "Test"
            //};
            //powershell.Profile.Environments["Test"] = new AzureEnvironment
            //{
            //    Name = "Test"
            //};
            //Assert.Throws<ArgumentException>(() => powershell.AuthenticationFactory.GetSubscriptionCloudCredentials(Guid.NewGuid()));
        }

        [Fact (Skip = "TODO: Implement mocks to test logic without interactive flow.")]
        public void AuthenticateReturnsSubscriptions()
        {
            //AzureSession.DataStoreInitializer = (p) => { return new MockDataStore(); };
            //AzureSession powershell = new AzureSession();
            //UserCredentials creds = new UserCredentials();
            //powershell.AuthenticationFactory.Authenticate(powershell.CurrentEnvironment, ref creds);
            //Assert.NotNull(creds.UserName);
        }
    }
}
