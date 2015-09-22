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

using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ScenarioTest.Common;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.CloudServiceTests
{
    [TestClass]
    public class EmulatorTests : AzurePowerShellCertificateTest
    {
        static string TrueIsNotFalseException = "Assertion failed: $true -eq $false";
        static string ExceptionMatchFailedException = "Exception match failed, '{0}' != '{1}'";
        public EmulatorTests()
            : base("CloudService\\Common.ps1",
                   "CloudService\\CloudServiceTests.ps1")
        {
        }

        [TestMethod]
        public void CommonPowerShellSucceedingTest()
        {
            RunPowerShellTest(
                "Write-Output \"Output\"",
                "Write-Debug \"Debug\"",
                "Write-Progress \"Progress\"",
                "Write-Verbose \"Verbose\"",
                "Write-Warning \"Warning\"",
                "foreach ($k in (Get-Item env:) ){$name=$k.name; $Value = $k.Value; Write-Debug \"$name=$Value\"}",
                "foreach ($sub in Get-AzureSubscription) {$name = $sub.SubscriptionName; Write-Debug $name}",
                "Assert-True {$true -eq $true}"
                );
        }

        [TestMethod]
        public void CommonPowerShellExceptionThrowingTest()
        {
            try
            {
                RunPowerShellTest(
                    "Write-Output \"Output\"",
                    "Write-Debug \"Debug\"",
                    "Write-Progress \"Progress\"",
                    "Write-Verbose \"Verbose\"",
                    "Write-Warning \"Warning\"",
                    "Assert-True {$true -eq $false}"
                    );
                Assert.Fail("Expected exception not thrown");
            }
            catch (RuntimeException runtimeException)
            {
                Assert.AreEqual(TrueIsNotFalseException, runtimeException.Message,
                    string.Format(ExceptionMatchFailedException, TrueIsNotFalseException, runtimeException.Message));
            }
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        public void TestStartAzureEmulatorTwice()
        {
            RunPowerShellTest("Test-StartAzureEmulatorTwice");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        public void TestStartAzureEmulatorExpress()
        {
            RunPowerShellTest("Test-StartAzureEmulatorExpress");
        }
    }
}
