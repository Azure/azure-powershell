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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using Microsoft.Azure.Commands.Profile.Context;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Moq;
using System.IO;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Profile.Test
{
    public class SessionInitializationTests
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;
        public SessionInitializationTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new MockCommandRuntime();
            dataStore = new MemoryDataStore();
            ResetState();
        }

        Mock<IDataStore> SetupStore()
        {
            var store = new Mock<IDataStore>();
            store.Setup(f => f.FileExists(It.IsAny<string>())).Returns(true);
            store.Setup(f => f.DirectoryExists(It.IsAny<string>())).Returns(true);
            return store;
        }

        void ResetState()
        {

            TestExecutionHelpers.SetUpSessionAndProfile();
            ResourceManagerProfileProvider.InitializeResourceManagerProfile(true);
            AzureSession.Instance.DataStore = dataStore;
            AzureSession.Instance.ARMContextSaveMode = ContextSaveMode.Process;
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            AzureSession.Instance.TokenCache = new AuthenticationStoreTokenCache(new AzureTokenCache());
            Environment.SetEnvironmentVariable("Azure_PS_Data_Collection", "");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DataCollectionSettingPreventsFileWrite()
        {
            try
            {
                Environment.SetEnvironmentVariable("Azure_PS_Data_Collection", "true");
                var store = SetupStore();
                store.Setup(f => f.FileExists(It.IsAny<string>())).Returns(false);
                store.Setup(f => f.WriteFile(It.IsAny<string>(), It.IsAny<string>())).Throws(new IOException("Cannot access file"));
                store.Setup(f => f.WriteFile(It.IsAny<string>(), It.IsAny<byte[]>())).Throws(new IOException("Cannot access file"));
                store.Setup(f => f.WriteFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Encoding>())).Throws(new IOException("Cannot access file"));
                AzureSessionInitializer.CreateOrReplaceSession(store.Object);
                var session = AzureSession.Instance;
                Assert.NotNull(session);
                Assert.Equal(ContextSaveMode.Process, session.ARMContextSaveMode);
                Assert.NotNull(session.TokenCache);
                Assert.Equal(typeof(AuthenticationStoreTokenCache), session.TokenCache.GetType());
                Assert.NotNull(AzureRmProfileProvider.Instance);
                Assert.Equal(typeof(ResourceManagerProfileProvider), AzureRmProfileProvider.Instance.GetType());
                store.Verify(f => f.WriteFile(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            }
            finally
            {
                ResetState();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInitializationCannotCheckDirectoryExistence()
        {
            try
            {
                var store = SetupStore();
                store.Setup(f => f.FileExists(It.IsAny<string>())).Returns(false);
                store.Setup(f => f.DirectoryExists(It.IsAny<string>())).Throws(new IOException("Cannot access directory"));
                AzureSessionInitializer.CreateOrReplaceSession(store.Object);
                var session = AzureSession.Instance;
                Assert.NotNull(session);
                Assert.Equal(ContextSaveMode.Process, session.ARMContextSaveMode);
                Assert.NotNull(session.TokenCache);
                Assert.Equal(typeof(AuthenticationStoreTokenCache), session.TokenCache.GetType());
                Assert.NotNull(AzureRmProfileProvider.Instance);
                Assert.Equal(typeof(ResourceManagerProfileProvider), AzureRmProfileProvider.Instance.GetType());
                store.Verify(f => f.DirectoryExists(It.IsAny<string>()), Times.AtLeastOnce);
            }
            finally
            {
                ResetState();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInitializationCannotCheckFileExistence()
        {
            try
            {
                var store = SetupStore();
                store.Setup(f => f.FileExists(It.IsAny<string>())).Throws(new IOException("Cannot access directory"));
                AzureSessionInitializer.CreateOrReplaceSession(store.Object);
                var session = AzureSession.Instance;
                Assert.NotNull(session);
                Assert.Equal(ContextSaveMode.Process, session.ARMContextSaveMode);
                Assert.NotNull(session.TokenCache);
                Assert.Equal(typeof(AuthenticationStoreTokenCache), session.TokenCache.GetType());
                Assert.NotNull(AzureRmProfileProvider.Instance);
                Assert.Equal(typeof(ResourceManagerProfileProvider), AzureRmProfileProvider.Instance.GetType());
                store.Verify(f => f.FileExists(It.IsAny<string>()), Times.AtLeastOnce);
            }
            finally
            {
                ResetState();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInitializationCannotRead()
        {
            try
            {
                var store = SetupStore();
                store.Setup(f => f.ReadFileAsText(It.IsAny<string>())).Throws(new IOException("Cannot access file"));
                store.Setup(f => f.ReadFileAsBytes(It.IsAny<string>())).Throws(new IOException("Cannot access file"));
                AzureSessionInitializer.CreateOrReplaceSession(store.Object);
                var session = AzureSession.Instance;
                Assert.NotNull(session);
                Assert.Equal(ContextSaveMode.Process, session.ARMContextSaveMode);
                Assert.NotNull(session.TokenCache);
                Assert.Equal(typeof(AuthenticationStoreTokenCache), session.TokenCache.GetType());
                Assert.NotNull(AzureRmProfileProvider.Instance);
                Assert.Equal(typeof(ResourceManagerProfileProvider), AzureRmProfileProvider.Instance.GetType());
                store.Verify(f => f.ReadFileAsText(It.IsAny<string>()), Times.AtLeastOnce);
            }
            finally
            {
                ResetState();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInitializationCannotCreateDirectory()
        {
            try
            {
                var store = SetupStore();
                store.Setup(f => f.FileExists(It.IsAny<string>())).Returns(false);
                store.Setup(f => f.DirectoryExists(It.IsAny<string>())).Returns(false);
                store.Setup(f => f.CreateDirectory(It.IsAny<string>())).Throws(new IOException("Cannot access file"));
                AzureSessionInitializer.CreateOrReplaceSession(store.Object);
                var session = AzureSession.Instance;
                Assert.NotNull(session);
                Assert.Equal(ContextSaveMode.Process, session.ARMContextSaveMode);
                Assert.NotNull(session.TokenCache);
                Assert.Equal(typeof(AuthenticationStoreTokenCache), session.TokenCache.GetType());
                Assert.NotNull(AzureRmProfileProvider.Instance);
                Assert.Equal(typeof(ResourceManagerProfileProvider), AzureRmProfileProvider.Instance.GetType());
                store.Verify(f => f.CreateDirectory(It.IsAny<string>()), Times.AtLeastOnce());
            }
            finally
            {
                ResetState();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInitializationCannotWrite()
        {
            try
            {
                var store = SetupStore();
                store.Setup(f => f.FileExists(It.IsAny<string>())).Returns(false);
                store.Setup(f => f.WriteFile(It.IsAny<string>(), It.IsAny<string>())).Throws(new IOException("Cannot access file"));
                store.Setup(f => f.WriteFile(It.IsAny<string>(), It.IsAny<byte[]>())).Throws(new IOException("Cannot access file"));
                store.Setup(f => f.WriteFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Encoding>())).Throws(new IOException("Cannot access file"));
                AzureSessionInitializer.CreateOrReplaceSession(store.Object);
                var session = AzureSession.Instance;
                Assert.NotNull(session);
                Assert.Equal(ContextSaveMode.Process, session.ARMContextSaveMode);
                Assert.NotNull(session.TokenCache);
                Assert.Equal(typeof(AuthenticationStoreTokenCache), session.TokenCache.GetType());
                Assert.NotNull(AzureRmProfileProvider.Instance);
                Assert.Equal(typeof(ResourceManagerProfileProvider), AzureRmProfileProvider.Instance.GetType());
                store.Verify(f => f.WriteFile(It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce);
            }
            finally
            {
                ResetState();
            }
        }
    }
}
