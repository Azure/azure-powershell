using System.IO;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Azure.Commands.TestFx;
using Xunit;

namespace Microsoft.Azure.Commands.NetAppFiles.UnitTest
{
    [Trait("AcceptanceType", "CheckIn")]
    public class AccountLdapPowerShellTests
    {
        [Fact]
        public void LdapParameterBindingAndWhatIfDoNotRequireRecordings()
        {
            RunPowerShellTest("Test-AccountLdapParameterBinding");
        }

        [Theory]
        [InlineData("New-AzNetAppFilesAccount", "$null")]
        [InlineData("Set-AzNetAppFilesAccount", "$null")]
        [InlineData("Update-AzNetAppFilesAccount", "$null")]
        [InlineData("New-AzNetAppFilesAccount", "@{ LdapPort = 'not-a-number' }")]
        [InlineData("Set-AzNetAppFilesAccount", "@{ LdapPort = 'not-a-number' }")]
        [InlineData("Update-AzNetAppFilesAccount", "@{ LdapPort = 'not-a-number' }")]
        [InlineData("New-AzNetAppFilesAccount", "@{ BindPasswordAkvConfig = 42 }")]
        [InlineData("Set-AzNetAppFilesAccount", "@{ BindPasswordAkvConfig = 42 }")]
        [InlineData("Update-AzNetAppFilesAccount", "@{ BindPasswordAkvConfig = 42 }")]
        public void InvalidLdapParameterBindingFailsWithoutRecordings(string command, string configuration)
        {
            AssertParameterBindingFailure(command +
                " -ResourceGroupName test-rg -Name test-account -Location westus2 -LdapConfiguration " + configuration,
                configuration == "$null" ? "InvalidData" : "InvalidArgument");
        }

        [Theory]
        [InlineData("-ResourceGroupName '' -Name test-account", "InvalidData")]
        [InlineData("-ResourceGroupName $null -Name test-account", "InvalidData")]
        [InlineData("-ResourceGroupName test-rg -Name ''", "InvalidData")]
        [InlineData("-ResourceGroupName test-rg -Name $null", "InvalidData")]
        [InlineData("-ResourceId ''", "InvalidData")]
        [InlineData("-ResourceId $null", "InvalidData")]
        [InlineData("-InputObject $null", "InvalidData")]
        [InlineData("-InputObject 42", "InvalidArgument")]
        [InlineData("-ResourceId /subscriptions/test/resourceGroups/test-rg/providers/Microsoft.NetApp/netAppAccounts/test-account -ResourceGroupName test-rg -Name test-account", "InvalidArgument")]
        public void InvalidRefreshParameterBindingFailsWithoutRecordings(string parameters, string category)
        {
            AssertParameterBindingFailure("Update-AzNetAppFilesAccountLdapBindPassword " + parameters + " -PassThru", category);
        }

        private static void AssertParameterBindingFailure(string invocation, string category)
        {
            RunPowerShellTest(@"
$ErrorActionPreference = 'Stop'
$failure = $null
$output = @()
try {
    $output = @(" + invocation + @" -WhatIf -ErrorAction Stop)
} catch {
    $failure = $_
}
Assert-NotNull $failure
Assert-True { $failure.Exception -is [System.Management.Automation.ParameterBindingException] }
Assert-AreEqual '" + category + @"' $failure.CategoryInfo.Category.ToString()
Assert-AreEqual 0 $output.Count
");
        }

        private static void RunPowerShellTest(string testScript)
        {
            var projectPath = typeof(AccountLdapPowerShellTests).Assembly
                .GetCustomAttributes<AssemblyMetadataAttribute>()
                .Single(attribute => attribute.Key == "TestProjectPath").Value;
            var repoRoot = Path.GetFullPath(Path.Combine(projectPath, "..", "..", ".."));
            var helper = new EnvironmentSetupHelper();
            var initialState = InitialSessionState.CreateDefault();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                initialState.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.Unrestricted;
            }

            using (var powershell = System.Management.Automation.PowerShell.Create(initialState))
            {
                foreach (var modulePath in new[] { helper.RMProfileModule, helper.GetRMModulePath("Az.NetAppFiles.psd1") })
                {
                    powershell.AddCommand("Import-Module").AddParameter("Name", modulePath).AddParameter("ErrorAction", "Stop");
                    powershell.Invoke();
                    Assert.False(powershell.HadErrors, string.Join("\n", powershell.Streams.Error));
                    powershell.Commands.Clear();
                }

                foreach (var script in new[]
                {
                    Path.Combine(repoRoot, "tools", "TestFx", "Assert.ps1"),
                    Path.Combine(projectPath, "ScenarioTests", "AccountTests.ps1")
                })
                {
                    powershell.AddScript(". '" + script.Replace("'", "''") + "'");
                }
                powershell.AddScript(testScript);
                powershell.Invoke();
                // HadErrors includes the binding failures deliberately caught by negative tests.
                Assert.Empty(powershell.Streams.Error);
            }
        }
    }
}
