using System.Collections.Generic;
using Microsoft.Azure.Commands.TestFx;
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.Management.Advisor;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Advisor.Test.ScenarioTests
{
    public class AdvisorTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected AdvisorTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance (output)
                .WithNewPsScriptFilename ($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests ("ScenarioTests")
                .WithCommonPsScripts (new[]
                {
                    @"Common.ps1"
                })
                .WithNewRmModules (helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.Advisor.psd1")
                })
                .WithNewRecordMatcherArguments (
                    userAgentsToIgnore: new Dictionary<string, string>(),
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null}
                    }
                ).WithManagementClients(
                    GetResourceGraphClient,
                    GetSubscriptionClient
                )
                .Build();
        }

        private static IAdvisorManagementClient GetResourceGraphClient(MockContext context)
        {
            return context.GetServiceClient<AdvisorManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static SubscriptionClient GetSubscriptionClient(MockContext context)
        {
            return context.GetServiceClient<SubscriptionClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
