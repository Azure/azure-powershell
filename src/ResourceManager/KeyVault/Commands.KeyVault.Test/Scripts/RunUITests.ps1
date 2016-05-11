Param(
  [Parameter(Mandatory=$True,Position=0)]   
  [string]$testns 
)

$invocationPath = Split-Path $MyInvocation.MyCommand.Definition;
. (Join-Path $invocationPath "PSHCommon\Common.ps1");
. (Join-Path $invocationPath "PSHCommon\Assert.ps1");
. (Join-Path $invocationPath "Common.ps1");
. (Join-Path $invocationPath "VaultUITests.ps1");

$global:totalCount = 0;
$global:passedCount = 0;
$global:passedTests = @()
$global:failedTests = @()
$global:times = @{}
$global:testns = $testns+"UI"

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
Cleanup-Log $invocationPath

$testkeyVault = Get-KeyVault
Write-Host Test key vault is $testKeyVault
Write-Host Initializing Key Tests
Initialize-KeyTest
Write-Host Initializing Secret Tests
Initialize-SecretTest
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


$global:endTime = Get-Date

# Report
Write-FileReport
Write-ConsoleReport

# Post run
Move-Log $invocationPath
