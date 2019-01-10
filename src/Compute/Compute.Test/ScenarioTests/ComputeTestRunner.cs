using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.TestFx;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class ComputeTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected ComputeTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestFx.TestManager.CreateInstance (output)
                .WithNewPsScriptFilename ($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests ("ScenarioTests")
                .WithCommonPsScripts (new[]
                {
                    @"Common.ps1",
                    @"ComputeTestCommon.ps1",
                    @"../AzureRM.Resources.ps1",
                    @"../AzureRM.Storage.ps1"
                })
                .WithNewRmModules (helper => new[]
                {
                    helper.RMProfileModule,
#if !NETSTANDARD
                    helper.RMStorageDataPlaneModule,
#endif
                    helper.GetRMModulePath("AzureRM.Compute.psd1"),
                    helper.GetRMModulePath("AzureRM.Network.psd1"),
                    helper.GetRMModulePath("AzureRM.KeyVault.psd1"),

                })
                .WithRecordMatcher(
                    (ignoreResourcesClient, resourceProviders, userAgentsToIgnore) =>
                        new PermissiveRecordMatcherWithApiExclusion(ignoreResourcesClient, resourceProviders, userAgentsToIgnore)
                )
                .WithNewRecordMatcherArguments (
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                        {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10"},
                        {"Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient", "2016-09-01"},
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Compute", null},
                        {"Microsoft.Network", null},
                        {"Microsoft.KeyVault", null},
                        {"Microsoft.Storage", null},
                    }
                )
                .Build();
        }
    }
}
