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
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Interfaces;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using StorageSync.Test.Common;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace ScenarioTests
{
    /// <summary>
    /// Class StorageSyncTestRunner.
    /// </summary>
    public class StorageSyncTestRunner
    {
        /// <summary>
        /// Gets the user domain.
        /// </summary>
        /// <value>The user domain.</value>
        public string UserDomain { get; private set; }

        protected readonly ITestRunner TestRunner;

        protected StorageSyncTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Storage.ps1",
                    @"../AzureRM.Resources.ps1"
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.RMStorageModule,
                    helper.GetRMModulePath("Az.StorageSync.psd1")
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Storage", null},
                        {"Microsoft.StorageSync", null}
                    }
                ).WithMockContextAction(() =>
                    {
                        var sf = new StackTrace().GetFrame(2);
                        var callingClassType = sf.GetMethod().ReflectedType?.ToString();
                        var testName = sf.GetMethod().Name;

                        using (var context = MockContext.Start(callingClassType, testName))
                        {
                            RegisterComponents(context, testName);
                        }
                    }
                )
                .Build();
        }

        /// <summary>
        /// Registers the components.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="testName">Name of the test.</param>
        private void RegisterComponents(MockContext context, string testName)
        {
            AzureSession.Instance.RegisterComponent<IStorageSyncResourceManager>(StorageSyncConstants.StorageSyncResourceManager, () => new MockStorageSyncResourceManager(testName), overwrite: true);
        }
    }
}