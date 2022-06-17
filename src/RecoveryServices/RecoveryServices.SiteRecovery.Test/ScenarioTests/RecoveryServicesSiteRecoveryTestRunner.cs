using Microsoft.Azure.Commands.TestFx;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Test.ScenarioTests
{
    public class RecoveryServicesSiteRecoveryTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected RecoveryServicesSiteRecoveryTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithCommonPsScripts(new[]
                {
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1"
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.Network.psd1"),
                    helper.GetRMModulePath("Az.Compute.psd1"),
                    helper.GetRMModulePath("Az.RecoveryServices.psd1"),
#if !NETSTANDARD
                    helper.GetRMModulePath("Az.RecoveryServices.SiteRecovery.psd1"),
#endif
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Compute", null},
                        {"Microsoft.Storage", null},
                        {"Microsoft.Network", null}
                    }
                )
                .Build();
        }
    }
}
