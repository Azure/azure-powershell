. "./Common.ps1"
. "./Assert.ps1"
# Profile tests
. "./Profile/SubscriptionCmdletTests.ps1"
# Resources tests
. "./Resources/ActiveDirectoryTests.ps1"
. "./Resources/AuthorizationTests.ps1"
. "./Resources/DeploymentTests.ps1"
. "./Resources/LocationTests.ps1"
. "./Resources/MoveResourceTest.ps1"
. "./Resources/PolicyTests.ps1"
. "./Resources/ProviderTests.ps1"
. "./Resources/ResourceGroupTests.ps1"
. "./Resources/ResourceLockTests.ps1"
. "./Resources/ResourceTests.ps1"
. "./Resources/RoleAssignmentTests.ps1"
. "./Resources/RoleDefinitionTests.ps1"
. "./Compute/ComputeTestCommon.ps1"
. "./Compute/VirtualMachineTests.ps1"
. "./Websites/Common.ps1"
. "./Websites/WebAppTests.ps1"

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

Login-AzureRmAccount
Select-AzureRmSubscription -SubscriptionId 00977cdb-163f-435f-9c32-39ec8ae61f4d

$ErrorActionPreference = "Stop"
$global:startTime = Get-Date

#Proflie tests
Run-TestProtected { Test-GetSubscriptionsEndToEnd } "Test-GetSubscriptionsEndToEnd" 
Run-TestProtected { Test-PipingWithContext } "Test-PipingWithContext" 
Run-TestProtected { Test-SetAzureRmContextEndToEnd } "Test-SetAzureRmContextEndToEnd" 
Run-TestProtected { Test-SetAzureRmContextWithoutSubscription } "Test-SetAzureRmContextWithoutSubscription" 

# Resource Groups tests
Run-TestProtected { Test-CreatesNewSimpleResourceGroup } "Test-CreatesNewSimpleResourceGroup" 
Run-TestProtected { Test-UpdatesExistingResourceGroup} "Test-UpdatesExistingResourceGroup"
Run-TestProtected { Test-AzureTagsEndToEnd } "Test-AzureTagsEndToEnd" 
Run-TestProtected { Test-RemoveDeployment } "Test-RemoveDeployment" 
Run-TestProtected { Test-MoveAzureResource } "Test-MoveAzureResource" 

# Active Directory tests
Run-TestProtected { Test-GetADGroupWithSearchString "Azure DevEx Powershell team" } "Test-GetADGroupWithSearchString" 
Run-TestProtected { Test-GetADGroupWithBadSearchString } "Test-GetADGroupWithBadSearchString" 
Run-TestProtected { Test-GetADGroupWithObjectId "25cda556-8965-4159-aea3-a9391398cc7a" } "Test-GetADGroupWithObjectId" 
Run-TestProtected { Test-GetADServicePrincipalWithObjectId "00901ac3-b9b7-4f5e-b89e-178c9266894b" } "Test-GetADServicePrincipalWithObjectId" 
Run-TestProtected { Test-GetADUserWithSearchString "Hovsep Mkrtchyan" } "Test-GetADUserWithSearchString" 

# Authorization tests - Skipped in repo due to error
Run-TestProtected { Test-AuthorizationEndToEnd } "Test-AuthorizationEndToEnd" 

# Resource Group Deployment tests
Run-TestProtected { Test-CrossResourceGroupDeploymentFromTemplateFile } "Test-CrossResourceGroupDeploymentFromTemplateFile" 

# Locations tests
Run-TestProtected { Test-AzureLocation } "Test-AzureLocation" 

# Policy tests
Run-TestProtected { Test-PolicyDefinitionCRUD } "Test-PolicyDefinitionCRUD" 
Run-TestProtected { Test-PolicyAssignmentCRUD } "Test-PolicyAssignmentCRUD" 

# RoleDefinition tests
Run-TestProtected { Test-RoleDefinitionCreateTests } "Test-RoleDefinitionCreateTests" 

# Compute tests 
Run-TestProtected { Test-VirtualMachine $null $true } "Test-VirtualMachine With Managed Disks" 
Run-TestProtected { Test-VirtualMachine $null } "Test-VirtualMachine" 

# WebApp tests
Run-TestProtected { Test-GetWebApp } "Test-GetWebApp" 
Run-TestProtected { Test-GetWebAppMetrics } "Test-GetWebAppMetrics" 
Run-TestProtected { Test-StartStopRestartWebApp } "Test-StartStopRestartWebApp" 
Run-TestProtected { Test-CloneNewWebAppAndDeploymentSlots } "Test-CloneNewWebAppAndDeploymentSlots" 
Run-TestProtected { Test-RemoveWebApp } "Test-RemoveWebApp" 
Run-TestProtected { Test-SetWebApp} "Test-SetWebApp" 
Run-TestProtected { Test-CloneNewWebAppWithTrafficManager } "Test-CloneNewWebAppWithTrafficManager" 

# final results
Write-Host
Write-Host -ForegroundColor Green "$global:passedCount / $global:totalCount E2E Scenario Tests Pass"
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

$ErrorActionPreference = "Continue"