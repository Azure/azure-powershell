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
// TODO: Remove IfDef
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
#endif
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common;
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
            List<IAzureEnvironment> _environments = new List<IAzureEnvironment>();
            public TestContextContainer()
            {
                foreach(var environment in AzureEnvironment.PublicEnvironments)
                {
                    _environments.Add(environment.Value);
                }
            }
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
                get { return _environments; }
            } 

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

        public AzureSMProfileProvider smProvider = AzureSMProfileProvider.Instance;
        public AzureRmProfileProvider rmProvider = AzureRmProfileProvider.Instance;

        private void InitSession()
        {
            AzureSessionInitializer.InitializeAzureSession();
            smProvider = AzureSMProfileProvider.Instance;
            rmProvider = AzureRmProfileProvider.Instance;
            AzureRmProfileProvider.SetInstance(() => new TestProfileProvider(), true);
            AzureSMProfileProvider.SetInstance(() => new TestSMProfileProvider(), true);

        }

        private void SetSM_RMProfile(bool isSMProfileNull = false, bool isRMProfileNull = false)
        {
            if (isSMProfileNull)
            {
                AzureSMProfileProvider.Instance.Profile = null;
            }
            else
            {
                AzureSMProfileProvider.Instance.Profile = new TestContextContainer();
            }
            if (isRMProfileNull)
            {
                AzureRmProfileProvider.Instance.Profile = null;
            }
            else
            {
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
            }
        }

        private void CleanupSession()
        {
            AzureSMProfileProvider.SetInstance(() => smProvider, true);
            AzureRmProfileProvider.SetInstance(() => rmProvider, true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextNameAndKey_SmNull_RmNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: true, isRMProfileNull: true);

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
            }
            finally
            {
                CleanupSession();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextNameAndKey_SmNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();

                SetSM_RMProfile(isSMProfileNull: true, isRMProfileNull: false);
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
            }
            finally
            {
                CleanupSession();
            }
        }

#if !NETSTANDARD
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextNameAndKey_SmNotNull_RmNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: true);

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
            }
            finally
            {
                CleanupSession();
            }
        }
#endif

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextNameAndKey_SmNotNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: false);

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
            }
            finally
            {
                CleanupSession();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextInChinaCloud_SmNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: true, isRMProfileNull: false);

                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    StorageAccountKey = "AAAAAAAA",
                    Environment = EnvironmentName.AzureChinaCloud
                };

                cmdlet.SetParameterSet("AccountNameAndKeyEnvironment");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
                Assert.Contains(".cn", storageContext.BlobEndPoint);
            }
            finally
            {
                CleanupSession();
            }
        }

#if !NETSTANDARD
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextInChinaCloud_SmNotNull_RmNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: true);

                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    StorageAccountKey = "AAAAAAAA",
                    Environment = EnvironmentName.AzureChinaCloud
                };

                cmdlet.SetParameterSet("AccountNameAndKeyEnvironment");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
                Assert.True(storageContext.BlobEndPoint.Contains(".cn"));
            }
            finally
            {
                CleanupSession();
            }
        }
#endif

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextInChinaCloud_SmNotNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: false);

                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    StorageAccountKey = "AAAAAAAA",
                    Environment = EnvironmentName.AzureChinaCloud
                };

                cmdlet.SetParameterSet("AccountNameAndKeyEnvironment");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
                Assert.Contains(".cn", storageContext.BlobEndPoint);
            }
            finally
            {
                CleanupSession();
            }
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextSASToken_SmNull_RmNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: true, isRMProfileNull: true);

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
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextSASToken_SmNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: true, isRMProfileNull: false);

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
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }

#if !NETSTANDARD
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextSASToken_SmNotNull_RmNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: true);

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
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }
#endif

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextSASToken_SmNotNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: false);

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
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextAnonymous_SmNull_RmNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: true, isRMProfileNull: true);

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
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextAnonymous_SmNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: true, isRMProfileNull: false);

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
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }

#if !NETSTANDARD
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextAnonymous_SmNotNull_RmNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: true);

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
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }
#endif

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextAnonymous_SmNotNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: false);

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
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextEndPoint_SmNull_RmNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: true, isRMProfileNull: true);

                AzureSMProfileProvider.Instance.Profile = null;
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    StorageAccountKey = "AAAAAAAA",
                    Endpoint = "core.chinacloudapi.cn",
                };

                cmdlet.SetParameterSet("AccountNameAndKey");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
                Assert.Contains("core.chinacloudapi.cn", storageContext.BlobEndPoint);
            }
            finally
            {
                CleanupSession();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextEndPoint_SmNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: true, isRMProfileNull: false);

                AzureSMProfileProvider.Instance.Profile = null;
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    StorageAccountKey = "AAAAAAAA",
                    Endpoint = "core.chinacloudapi.cn",
                };

                cmdlet.SetParameterSet("AccountNameAndKey");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
                Assert.Contains("core.chinacloudapi.cn", storageContext.BlobEndPoint);
            }
            finally
            {
                CleanupSession();
            }
        }

#if !NETSTANDARD
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextEndPoint_SmNotNull_RmNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: true);

                AzureSMProfileProvider.Instance.Profile = null;
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    StorageAccountKey = "AAAAAAAA",
                    Endpoint = "core.chinacloudapi.cn",
                };

                cmdlet.SetParameterSet("AccountNameAndKey");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
                Assert.True(storageContext.BlobEndPoint.Contains("core.chinacloudapi.cn"));
            }
            finally
            {
                CleanupSession();
            }
        }
#endif

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextEndPoint_SmNotNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: false);

                AzureSMProfileProvider.Instance.Profile = null;
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    StorageAccountName = "contosostorage",
                    StorageAccountKey = "AAAAAAAA",
                    Endpoint = "core.chinacloudapi.cn",
                };

                cmdlet.SetParameterSet("AccountNameAndKey");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal(cmdlet.StorageAccountName, storageContext.StorageAccountName);
                Assert.Contains("core.chinacloudapi.cn", storageContext.BlobEndPoint);
            }
            finally
            {
                CleanupSession();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextConnectionString_SmNull_RmNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: true, isRMProfileNull: true);

                AzureSMProfileProvider.Instance.Profile = null;
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    ConnectionString = "DefaultEndpointsProtocol=https;AccountName=contosostorage;AccountKey=AAAAAAAA",
                };

                cmdlet.SetParameterSet("ConnectionString");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal("contosostorage", storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextConnectionString_SmNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: true, isRMProfileNull: false);

                AzureSMProfileProvider.Instance.Profile = null;
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    ConnectionString = "DefaultEndpointsProtocol=https;AccountName=contosostorage;AccountKey=AAAAAAAA",
                };

                cmdlet.SetParameterSet("ConnectionString");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal("contosostorage", storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }

#if !NETSTANDARD
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextConnectionString_SmNotNull_RmNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: true);

                AzureSMProfileProvider.Instance.Profile = null;
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    ConnectionString = "DefaultEndpointsProtocol=https;AccountName=contosostorage;AccountKey=AAAAAAAA",
                };

                cmdlet.SetParameterSet("ConnectionString");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal("contosostorage", storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }
#endif

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateStorageContextConnectionString_SmNotNull_RmNotNull()
        {
            InitSession();
            try
            {
                var mock = new MockCommandRuntime();
                SetSM_RMProfile(isSMProfileNull: false, isRMProfileNull: false);

                AzureSMProfileProvider.Instance.Profile = null;
                AzureRmProfileProvider.Instance.Profile = new TestContextContainer();
                var cmdlet = new NewAzureStorageContext
                {
                    CommandRuntime = mock,
                    ConnectionString = "DefaultEndpointsProtocol=https;AccountName=contosostorage;AccountKey=AAAAAAAA",
                };

                cmdlet.SetParameterSet("ConnectionString");
                cmdlet.ExecuteCmdlet();
                var output = mock.OutputPipeline;
                Assert.NotNull(output);
                var storageContext = output.First() as AzureStorageContext;
                Assert.NotNull(storageContext);
                Assert.Equal("contosostorage", storageContext.StorageAccountName);
            }
            finally
            {
                CleanupSession();
            }
        }
    }
}
