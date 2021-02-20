using Microsoft.Azure.Commands.TestFx;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class WebsitesTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected WebsitesTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestFx.TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Resources.ps1",
                    @"../AzureRM.Storage.ps1"
                })
                .WithNewRmModules(helper => new[]
               {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("AzureRM.Websites.psd1"),
                    helper.GetRMModulePath("AzureRM.Network.psd1"),
                    helper.GetRMModulePath("AzureRM.KeyVault.psd1"),

                })
                .WithRecordMatcher(
                    (ignoreResourcesClient, resourceProviders, userAgentsToIgnore) =>
                        new PermissiveRecordMatcherWithApiExclusion(ignoreResourcesClient, resourceProviders, userAgentsToIgnore)
                )
                .WithNewRecordMatcherArguments(
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
                        {"Microsoft.Websites", null},
                        {"Microsoft.Network", null},
                        {"Microsoft.KeyVault", null},
                        {"Microsoft.Storage", null},
                    }
                )
                .Build();
        }
    }
}
