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
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.WindowsAzure.Management.Storage.Test.Common.Cmdlet
{
    public class StorageContextDisconnectedTests
    {
        class TestProfileProvider : AzureRmProfileProvider
        {
            public override T GetProfile<T>()
            {
                return default(T);
            }
        }

        class TestSMProfileProvider : AzureSMProfileProvider
        {
            public override T GetProfile<T>()
            {
                return default(T);
            }

            public override void SetTokenCacheForProfile(IAzureContextContainer profile)
            {
                
            }
        }

        class TestContextContainer : IAzureContextContainer
        {
            public IEnumerable<IAzureAccount> Accounts
            {
                get;
            } = new List<IAzureAccount>();

            public IAzureContext DefaultContext
            {
                get; set;
            }

            public IEnumerable<IAzureEnvironment> Environments
            {
                get;
            } = new List<IAzureEnvironment>();

            public IDictionary<string, string> ExtendedProperties
            {
                get;
            } = new Dictionary<string, string>();

            public IEnumerable<IAzureSubscription> Subscriptions
            {
                get;
            } = new List<IAzureSubscription>();

            public void Clear()
            {
                
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextNameAndKey()
        {
            AzureSessionInitializer.InitializeAzureSession();
            var smProvider = AzureSMProfileProvider.Instance;
            var rmProvider = AzureRmProfileProvider.Instance;
            AzureRmProfileProvider.SetInstance(() => new TestProfileProvider(), true);
            AzureSMProfileProvider.SetInstance(()=> new TestSMProfileProvider(), true);
            try
            {
                var mock = new MockCommandRuntime();

                AzureSMProfileProvider.Instance.Profile = null;
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    StorageAccountKey = "AAAAAAAA",
                };

                cmdlet.SetParameterSet("AccountNameAndKey");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);

                cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    Anonymous = true,
                };

                cmdlet.SetParameterSet("AnonymousAccount");
                cmdlet.ExecuteCmdlet();
                output = mock.OutputPipeline;
                Assert.NotNull(output);
                storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);

                cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    SasToken = "AAAAAAAA",
                };

                cmdlet.SetParameterSet("SasToken");
                cmdlet.ExecuteCmdlet();
                output = mock.OutputPipeline;
                Assert.NotNull(output);
                storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
            }
            finally
            {
                AzureSMProfileProvider.SetInstance(() => smProvider, true);
                AzureRmProfileProvider.SetInstance(() => rmProvider, true);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextSASToken()
        {
            AzureSessionInitializer.InitializeAzureSession();
            var smProvider = AzureSMProfileProvider.Instance;
            var rmProvider = AzureRmProfileProvider.Instance;
            AzureRmProfileProvider.SetInstance(() => new TestProfileProvider(), true);
            AzureSMProfileProvider.SetInstance(() => new TestSMProfileProvider(), true);
            try
            {
                var mock = new MockCommandRuntime();

                AzureSMProfileProvider.Instance.Profile = null;
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    SasToken = "AAAAAAAA",
                };

                cmdlet.SetParameterSet("SasToken");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal("[SasToken]", storageContext.StorageAccountName);
            }
            finally
            {
                AzureSMProfileProvider.SetInstance(() => smProvider, true);
                AzureRmProfileProvider.SetInstance(() => rmProvider, true);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextAnonymous()
        {
            AzureSessionInitializer.InitializeAzureSession();
            var smProvider = AzureSMProfileProvider.Instance;
            var rmProvider = AzureRmProfileProvider.Instance;
            AzureRmProfileProvider.SetInstance(() => new TestProfileProvider(), true);
            AzureSMProfileProvider.SetInstance(() => new TestSMProfileProvider(), true);
            try
            {
                var mock = new MockCommandRuntime();

                AzureSMProfileProvider.Instance.Profile = null;
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    Anonymous = true,
                };

                cmdlet.SetParameterSet("AnonymousAccount");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal("[Anonymous]", storageContext.StorageAccountName);
            }
            finally
            {
                AzureSMProfileProvider.SetInstance(() => smProvider, true);
                AzureRmProfileProvider.SetInstance(() => rmProvider, true);
            }
        }

    }
}
