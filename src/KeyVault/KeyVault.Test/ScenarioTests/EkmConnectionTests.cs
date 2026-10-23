using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class EkmConnectionTests : KeyVaultTestRunner
    {
        public EkmConnectionTests(Xunit.Abstractions.ITestOutputHelper output) : base(output) { }

        [EkmLiveFact("EKM_TEST_HSM_NAME", "EKM_TEST_HOST", "EKM_TEST_CA_CERT", "EKM_TEST_SERVER_CN", "EKM_TEST_ALLOW_CONNECTION_CHANGES")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestEkmConnectionLifecycle()
        {
            TestRunner.RunTestScript("Test-EkmConnectionLifecycle");
        }

        [EkmLiveFact("EKM_TEST_HSM_NAME", "EKM_TEST_PLS_ALIAS")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestEkmPrivateEndpointLifecycle()
        {
            TestRunner.RunTestScript("Test-EkmPrivateEndpointLifecycle");
        }

        [EkmLiveFact("EKM_TEST_KEY_HSM_NAME", "EKM_TEST_EXTERNAL_KEY_ID", "EKM_TEST_ALLOW_KEY_CHANGES")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestCreateExternalKey()
        {
            TestRunner.RunTestScript("Test-CreateExternalKey");
        }
    }

    public sealed class EkmLiveFactAttribute : FactAttribute
    {
        public EkmLiveFactAttribute(params string[] requiredSettings)
        {
            if (Environment.GetEnvironmentVariable("AZURE_KEYVAULT_EKM_LIVE_TESTS") != "1")
            {
                Skip = "Requires explicit AZURE_KEYVAULT_EKM_LIVE_TESTS=1 opt-in and an authorized test HSM.";
                return;
            }
            foreach (string setting in requiredSettings)
            {
                if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(setting)))
                {
                    Skip = "Missing EKM live-test setting: " + setting;
                    return;
                }
            }
        }
    }
}