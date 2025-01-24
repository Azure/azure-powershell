using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.CodeSigning.Test.ScenarioTests
{
    public class AccountTests : CodeSigningTestRunner
    {
        public AccountTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAccount()
        {
            TestRunner.RunTestScript("Test-NewAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAccount()
        {
            TestRunner.RunTestScript("Test-GetAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAccount()
        {
            TestRunner.RunTestScript("Test-RemoveAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAccount()
        {
            TestRunner.RunTestScript("Test-ListAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAccountAvailable()
        {
            TestRunner.RunTestScript("Test-AccountAvailable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAccountNotAvailable()
        {
            TestRunner.RunTestScript("Test-AccountNotAvailable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateAccountSku()
        {
            TestRunner.RunTestScript("Test-UpdateAccountSku");
        }
    }
}
