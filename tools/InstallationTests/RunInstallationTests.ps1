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
.".\\InstallationTests.ps1"
# Pass expected PowerShell version as 1st param
$global:totalCount = 0;
$global:passedCount = 0;
$global:passedTests = @()
$global:failedTests = @()
$global:times = @{}
$VerbosePreference = "SilentlyContinue"

$clientId = 'aa0e49f9-96d1-46fd-82b3-b5e48915c9de'
$ssClientSecret = ConvertTo-SecureString -String 'sDji5X6hbXSjrfZOC0+2k+nvBF8QkDpY38JnL/Yhifw=' -AsPlainText -Force
$cred = New-Object -TypeName "System.Management.Automation.PSCredential" -ArgumentList $clientId, $ssClientSecret
$tenantId = '72f988bf-86f1-41af-91ab-2d7cd011db47'
$subscriptionIdToUse = "2c224e7e-3ef5-431d-a57b-e71f4662e3a6"

function CleanUp-Subscriptions()
{
    Get-AzureSubscription | ForEach-Object {Remove-AzureSubscription -SubscriptionId $_.SubscriptionId -Force}
}

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

CleanUp-Subscriptions
$context = Add-AzureRmAccount -Credential $cred -TenantId $tenantId -ServicePrincipal -SubscriptionId $subscriptionIdToUse
if ($context -eq $null)
{
  Write-Error "Node CLI Test does not exist in the list of available subscriptions. Make sure to have it to run the tests"
  Exit
}
[Microsoft.Azure.Common.Authentication.AzureSession]::ClientFactory.AddUserAgent("azure-powershell-test", "1.0")
Import-AzurePublishSettingsFile -PublishSettingsFile '.\NodeCLITest.publishsettings'
Select-AzureSubscription -SubscriptionId $subscriptionIdToUse -Current

$serviceCommands = @(
  {Get-AzureLocation},
  {Get-AzureAffinityGroup},
  {Get-AzureService},
  {Get-AzureVM},
  {Get-AzureVnetConfig},
  {Get-AzureStorageAccount},
  {Get-AzureMediaServicesAccount},
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
  {Get-AzureRmResourceGroup},
  {Get-AzureRmTag},
  {Get-AzureRmADUser -UPN $context.Context.Account.Id},
  #{Get-AzureRmRoleAssignment}, we can enable this once this cmdLet works well with service principal, currently it has a hard dependency on Graph API Version 1.6-preview and hence it has some bugs
  {Get-AzureRmRoleDefinition},
  {Get-AzureRmWebApp}
)

$ErrorActionPreference = "Stop"
$global:startTime = Get-Date
Run-TestProtected { Test-SetAzureStorageBlobContent } "Test-SetAzureStorageBlobContent"
Run-TestProtected { Test-UpdateStorageAccount } "Test-UpdateStorageAccount"

$serviceCommands | % { Run-TestProtected $_  $_.ToString() }
Write-Host -ForegroundColor Green "STARTING RESOURCE MANAGER TESTS"

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
Write-Host
CleanUp-Subscriptions
$ErrorActionPreference = "Continue"