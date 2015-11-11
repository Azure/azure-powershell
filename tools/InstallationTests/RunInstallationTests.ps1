# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

.".\\Common.ps1"
.".\\Assert.ps1"
.".\\InstallationTest.ps1"
# Pass expected PowerShell version as 1st param
$expectedVersion = [string]$args[0]
$credential = [PSCredential]$args[1]
$global:totalCount = 0;
$global:passedCount = 0;
$global:passedTests = @()
$global:failedTests = @()
$global:times = @{}
$VerbosePreference = "SilentlyContinue"


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
     &$script > $null
	   $global:passedCount = $global:passedCount + 1
	   Write-Host
     Write-Host  -ForegroundColor Green =====================================
	   Write-Host -ForegroundColor Green "Test Passed"
     Write-Host  -ForegroundColor Green =====================================
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

$serviceCommands = @(
  {Get-AzureLocation},
  {Get-AzureAffinityGroup},
  {Get-AzureService},
  {Get-AzureVM},
  {Get-AzureVnetConfig},
  {Get-AzureStorageAccount},
  {Get-AzureMediaServicesAccount},
#  {Get-AzureStoreAddOn -ListAvailable| Select-Object -First 10},
  {Get-AzureSubscription -Current -ExtendedDetails},
  {Get-AzureAccount},
  {Get-AzureManagedCache},
  {Get-AzureHDInsightCluster},
  {Get-AzureSBLocation},
  {Get-AzureSBNamespace},
  {Get-AzureSchedulerLocation},
  {Get-AzureSqlDatabaseServer},
  {Get-AzureWebsiteLocation},
  {Get-AzureAutomationAccount},
  {Get-AzureTrafficManagerProfile}
)

$resourceCommands = @(
  {Get-AzureResourceGroup},
  {Get-AzureResourceGroupGalleryTemplate},
  {Get-AzureTag},
  {Get-AzureADUser -UPN $credential.UserName},
  {Get-AzureRoleAssignment},
  {Get-AzureRmWebApp}
)

if ($credential -eq $null)
{
  $credential = $(Get-Credential)
}
Get-AzureSubscription | Remove-AzureSubscription -Force
Add-AzureAccount -Credential $credential
$ErrorActionPreference = "Stop"
Switch-AzureMode AzureServiceManagement
$subscription = $(Get-AzureSubscription -Current).SubscriptionName
$profile = $(New-AzureProfile -SubscriptionId $subscription -Credential $credential)
Select-AzureProfile $profile
$global:startTime = Get-Date
Run-TestProtected { Test-SetAzureStorageBlobContent } "Test-SetAzureStorageBlobContent"
Run-TestProtected { Test-GetModuleVersion $expectedVersion} "Test-GetModuleVersion"
Run-TestProtected { Test-UpdateStorageAccount } "Test-UpdateStorageAccount"
$serviceCommands | % { Run-TestProtected $_  $_.ToString() }
Write-Host -ForegroundColor Green "STARTING RESOURCE MANAGER TESTS"
Switch-AzureMode AzureResourceManager > $null
$subscription = $(Get-AzureSubscription -Current).SubscriptionName
$profile = $(New-AzureProfile -SubscriptionId $subscription -Credential $credential)
Select-AzureProfile $profile
$resourceCommands | % { Run-TestProtected $_  $_.ToString() }
Write-Host
Write-Host -ForegroundColor Green "$global:passedCount / $global:totalCount Installation Tests Pass"
Write-Host -ForegroundColor Green "============"
Write-Host -ForegroundColor Green "PASSED TESTS"
Write-Host -ForegroundColor Green "============"
$global:passedTests | % { Write-Host -ForegroundColor Green "PASSED "$_": "($global:times[$_]).ToString()}
Write-Host -ForegroundColor Green "============"
Write-Host
if ($global:failedTests.Count -gt 0)
{
  Write-Host -ForegroundColor Red "============"
  Write-Host -ForegroundColor Red "FAILED TESTS"
  Write-Host -ForegroundColor Red "============"
  $global:failedTests | % { Write-Host -ForegroundColor Red "FAILED "$_": "($global:times[$_]).ToString()}
  Write-Host -ForegroundColor Red "============"
  Write-Host
}
$global:endTime = Get-Date
Write-Host -ForegroundColor Green "======="
Write-Host -ForegroundColor Green "TIMES"
Write-Host -ForegroundColor Green "======="
Write-Host
Write-Host -ForegroundColor Green "Start Time: $global:startTime"
Write-Host -ForegroundColor Green "End Time: $global:endTime"
Write-Host -ForegroundColor Green "Elapsed: "($global:endTime - $global:startTime).ToString()
Write-Host "============================================================================================="
Write-Host
Write-Host "===================="
Write-Host "Help Check: ARM Mode"
Write-Host "===================="
Switch-AzureMode AzureResourceManager
Get-IncompleteHelp
Write-Host
Write-Host "===================="
Write-Host "Help Check: ASM Mode"
Write-Host "===================="
Switch-AzureMode AzureServiceManagement
Get-IncompleteHelp
Write-Host
Write-Host "============================================================================================="
Write-Host

$ErrorActionPreference = "Continue"
