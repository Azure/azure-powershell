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
        public void TestNewProfile()
        {
            TestRunner.RunTestScript("Test-NewProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetProfile()
        {
            TestRunner.RunTestScript("Test-GetProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveProfile()
        {
            TestRunner.RunTestScript("Test-RemoveProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListProfile()
        {
            TestRunner.RunTestScript("Test-ListProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRevokeProfile()
        {
            TestRunner.RunTestScript("Test-RevokeProfile");
        }
    }
}
