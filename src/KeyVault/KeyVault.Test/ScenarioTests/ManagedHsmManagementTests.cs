using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class ManagedHsmManagementTests: KeyVaultTestRunner
    {
        public ManagedHsmManagementTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedHsmCRUD()
        {
            TestRunner.RunTestScript("Test-ManagedHsmCRUD");
        }
    }
}
