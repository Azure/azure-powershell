Param(
    [Parameter(Mandatory=$true, Position=0)]
    [string] $TestRunNameSpace,
    [Parameter(Mandatory=$false, Position=1)]
    [string] $Vault = ""
)

. (Join-Path $PSScriptRoot "..\..\..\..\Common\Commands.ScenarioTests.Common\Common.ps1")
. (Join-Path $PSScriptRoot "..\..\..\..\Common\Commands.ScenarioTests.Common\Assert.ps1")
. (Join-Path $PSScriptRoot "Common.ps1");
. (Join-Path $PSScriptRoot "VaultUITests.ps1");

$global:totalCount = 0;
$global:passedCount = 0;
$global:passedTests = @()
$global:failedTests = @()
$global:times = @{}
$global:testns = $TestRunNameSpace+"UI"
$global:testVault = $Vault

function Run-TestProtected
{
   param([ScriptBlock]$script, [string] $testName)
   $testStart = Get-Date
   try
   {
     Write-Host  -ForegroundColor Green =====================================
     Write-Host  -ForegroundColor Green "Running test $testName"
     Write-Host  -ForegroundColor Green =====================================
     Write-Host
     &$script
     $global:passedCount = $global:passedCount + 1
     Write-Host
     Write-Host -ForegroundColor Green =====================================
     Write-Host -ForegroundColor Green "Test Passed"
     Write-Host -ForegroundColor Green =====================================
     Write-Host
     $global:passedTests += $testName
   }
   catch
   {
     Out-String -InputObject $_.Exception | Write-Host -ForegroundColor Red
     Write-Host
     Write-Host  -ForegroundColor Red =====================================
     Write-Host -ForegroundColor Red "Test Failed"
     Write-Host  -ForegroundColor Red =====================================
     Write-Host
     $global:failedTests += $testName
   }
   finally
   {
      $testEnd = Get-Date
      $testElapsed = $testEnd - $testStart
      $global:times[$testName] = $testElapsed
      $global:totalCount = $global:totalCount + 1
   }
}

# Initialize
Write-Host Delete log files
Cleanup-LogFiles $invocationPath

$testkeyVault = Get-KeyVault
Write-Host Test key vault is $testKeyVault
Write-Host Initializing Certificate Tests
Cleanup-OldCertificates
Write-Host Initializing Key Tests
Cleanup-OldKeys
Write-Host Initializing Secret Tests
Cleanup-OldSecrets
Write-Host Initialization Completed

$global:startTime = Get-Date

# Run key tests
Run-TestProtected { Run-KeyTest {Test_RemoveKeyWithTwoConfirmations} "Test_RemoveKeyWithTwoConfirmations" } "Test_RemoveKeyWithTwoConfirmations"
Run-TestProtected { Run-KeyTest {Test_RemoveKeyWithOneConfirmations} "Test_RemoveKeyWithOneConfirmations" } "Test_RemoveKeyWithOneConfirmations"
Run-TestProtected { Run-KeyTest {Test_CancelKeyRemovalOnce} "Test_CancelKeyRemovalOnce" } "Test_CancelKeyRemovalOnce"
Run-TestProtected { Run-KeyTest {Test_ConfirmThenCancelKeyRemoval} "Test_ConfirmThenCancelKeyRemoval" } "Test_ConfirmThenCancelKeyRemoval"

# Run secret tests
Run-TestProtected { Run-SecretTest {Test_RemoveSecretWithTwoConfirmations} "Test_RemoveSecretWithTwoConfirmations" } "Test_RemoveSecretWithTwoConfirmations"
Run-TestProtected { Run-SecretTest {Test_RemoveSecretWithOneConfirmations} "Test_RemoveSecretWithOneConfirmations" } "Test_RemoveSecretWithOneConfirmations"
Run-TestProtected { Run-SecretTest {Test_CancelSecretRemovalOnce} "Test_CancelSecretRemovalOnce" } "Test_CancelSecretRemovalOnce"
Run-TestProtected { Run-SecretTest {Test_ConfirmThenCancelSecretRemoval} "Test_ConfirmThenCancelSecretRemoval" } "Test_ConfirmThenCancelSecretRemoval"

# Run certificate tests
Run-TestProtected { Run-CertificateTest {Test_RemoveCertificateWithTwoConfirmations} "Test_RemoveCertificateWithTwoConfirmations" } "Test_RemoveCertificateWithTwoConfirmations"
Run-TestProtected { Run-CertificateTest {Test_RemoveCertificateWithOneConfirmations} "Test_RemoveCertificateWithOneConfirmations" } "Test_RemoveCertificateWithOneConfirmations"
Run-TestProtected { Run-CertificateTest {Test_CancelCertificateRemovalOnce} "Test_CancelCertificateRemovalOnce" } "Test_CancelCertificateRemovalOnce"
Run-TestProtected { Run-CertificateTest {Test_ConfirmThenCancelCertificateRemoval} "Test_ConfirmThenCancelCertificateRemoval" } "Test_ConfirmThenCancelCertificateRemoval"


$global:endTime = Get-Date

# Report
Write-FileReport
Write-ConsoleReport

# Post run
Move-Log $invocationPath
