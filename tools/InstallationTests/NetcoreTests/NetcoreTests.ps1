# Set script preferences.

$VerbosePreference = "SilentlyContinue"
$ErrorActionPreference = "Stop"

# Results object to pass to jobs.

$results = @{
  totalCount = 0;
  passedCount = 0;
  passedTests = @();
  failedTests = @();
  times = @{};
  startTime = Get-Date;
}
function Run-TestProtectedAsJob
{
  param($script, $testName)

  $job = Start-Job -Name $testName -ScriptBlock { 
    param($script, $testName, $results, $dir)

    Import-AzureRmContext -Path azpsTestContext.json > $null

    $VerbosePreference = "SilentlyContinue"
    $ErrorActionPreference = "Stop"
    function Run-TestProtected
    {
       param($script, $testName, $results)

       $testStart = Get-Date
       try 
       {
         Write-Host  -ForegroundColor Green =====================================
         Write-Host  -ForegroundColor Green "Running test $testName"
         Write-Host  -ForegroundColor Green =====================================
         Write-Host
         & $script > $null
         $results.passedCount = $results.passedCount + 1
         Write-Host
         Write-Host -ForegroundColor Green =====================================
         Write-Host -ForegroundColor Green "Test Passed"
         Write-Host -ForegroundColor Green =====================================
         Write-Host
         $results.passedTests += $testName
       }
       catch
       {
         Out-String -InputObject $_.Exception | Write-Host -ForegroundColor Red
         Write-Host
         Write-Host -ForegroundColor Red =====================================
         Write-Host -ForegroundColor Red "Test Failed"
         Write-Host -ForegroundColor Red =====================================
         Write-Host
         $results.failedTests += $testName
       }
       finally
       {
          $testEnd = Get-Date
          $testElapsed = $testEnd - $testStart
          $results.times[$testName] = $testElapsed
          $results.totalCount = $results.totalCount + 1
       }

       return $results
    }

    # Test helpers.
    . "$dir/Common.ps1"
    . "$dir/Assert.ps1"

    # Profile tests.
    . "$dir/Profile/SubscriptionCmdletTests.ps1"

    # Resources tests.
    . "$dir/Resources/ActiveDirectoryTests.ps1"
    . "$dir/Resources/AuthorizationTests.ps1"
    . "$dir/Resources/DeploymentTests.ps1"
    . "$dir/Resources/LocationTests.ps1"
    . "$dir/Resources/MoveResourceTest.ps1"
    . "$dir/Resources/PolicyTests.ps1"
    . "$dir/Resources/ProviderTests.ps1"
    . "$dir/Resources/ResourceGroupTests.ps1"
    . "$dir/Resources/ResourceLockTests.ps1"
    . "$dir/Resources/ResourceTests.ps1"
    . "$dir/Resources/RoleAssignmentTests.ps1"
    . "$dir/Resources/RoleDefinitionTests.ps1"
    . "$dir/Compute/ComputeTestCommon.ps1"
    . "$dir/Compute/VirtualMachineTests.ps1"
    . "$dir/Websites/Common.ps1"
    . "$dir/Websites/WebAppTests.ps1"

    $block = [Scriptblock]::Create($script)

    return Run-TestProtected $block $testName $results
  } -ArgumentList ($script, $testName, $results, $pwd)

  return $job
}

# Login or skip if the context exists.
if(!(Test-Path azpsTestContext.json)) {
  Login-AzureRmAccount > $null
  Select-AzureRmSubscription -SubscriptionId c9cbd920-c00c-427c-852b-8aaf38badaeb > $null
  Save-AzureRmContext -Path azpsTestContext.json > $null
}

# Start jobs and add to array.

$jobs = @(

  #Proflie tests.
  (Run-TestProtectedAsJob { Test-GetSubscriptionsEndToEnd } "Test-GetSubscriptionsEndToEnd"),
  (Run-TestProtectedAsJob { Test-PipingWithContext } "Test-PipingWithContext")#, 
  (Run-TestProtectedAsJob { Test-SetAzureRmContextEndToEnd } "Test-SetAzureRmContextEndToEnd"), 
  (Run-TestProtectedAsJob { Test-SetAzureRmContextWithoutSubscription } "Test-SetAzureRmContextWithoutSubscription"), 

  # Resource Groups tests.
  (Run-TestProtectedAsJob { Test-CreatesNewSimpleResourceGroup } "Test-CreatesNewSimpleResourceGroup"), 
  (Run-TestProtectedAsJob { Test-UpdatesExistingResourceGroup} "Test-UpdatesExistingResourceGroup"), 
  (Run-TestProtectedAsJob { Test-AzureTagsEndToEnd } "Test-AzureTagsEndToEnd"), 
  (Run-TestProtectedAsJob { Test-RemoveDeployment } "Test-RemoveDeployment"), 
  (Run-TestProtectedAsJob { Test-MoveAzureResource } "Test-MoveAzureResource"), 

  # Active Directory tests.
  (Run-TestProtectedAsJob { Test-GetADGroupWithSearchString "Azure DevEx Powershell team" } "Test-GetADGroupWithSearchString"), 
  (Run-TestProtectedAsJob { Test-GetADGroupWithBadSearchString } "Test-GetADGroupWithBadSearchString"), 
  (Run-TestProtectedAsJob { Test-GetADGroupWithObjectId "25cda556-8965-4159-aea3-a9391398cc7a" } "Test-GetADGroupWithObjectId"), 
  (Run-TestProtectedAsJob { Test-GetADServicePrincipalWithObjectId "00901ac3-b9b7-4f5e-b89e-178c9266894b" } "Test-GetADServicePrincipalWithObjectId"), 
  (Run-TestProtectedAsJob { Test-GetADUserWithSearchString "Hovsep Mkrtchyan" } "Test-GetADUserWithSearchString"), 

  # Authorization tests.
  (Run-TestProtectedAsJob { Test-AuthorizationEndToEnd } "Test-AuthorizationEndToEnd"), 

  # Resource Group Deployment tests.
  (Run-TestProtectedAsJob { Test-CrossResourceGroupDeploymentFromTemplateFile } "Test-CrossResourceGroupDeploymentFromTemplateFile"), 

  # Locations tests.
  (Run-TestProtectedAsJob { Test-AzureLocation } "Test-AzureLocation"), 

  # Policy tests.
  (Run-TestProtectedAsJob { Test-PolicyDefinitionCRUD } "Test-PolicyDefinitionCRUD"), 
  (Run-TestProtectedAsJob { Test-PolicyAssignmentCRUD } "Test-PolicyAssignmentCRUD"), 

  # RoleDefinition tests.
  (Run-TestProtectedAsJob { Test-RoleDefinitionCreateTests } "Test-RoleDefinitionCreateTests"), 

  # Compute tests.
  (Run-TestProtectedAsJob { Test-VirtualMachine $null $true } "Test-VirtualMachine With Managed Disks"), 
  (Run-TestProtectedAsJob { Test-VirtualMachine $null } "Test-VirtualMachine"), 

  # WebApp tests.
  (Run-TestProtectedAsJob { Test-GetWebApp } "Test-GetWebApp"), 
  (Run-TestProtectedAsJob { Test-GetWebAppMetrics } "Test-GetWebAppMetrics"), 
  (Run-TestProtectedAsJob { Test-StartStopRestartWebApp } "Test-StartStopRestartWebApp"), 
  (Run-TestProtectedAsJob { Test-CloneNewWebAppAndDeploymentSlots } "Test-CloneNewWebAppAndDeploymentSlots"), 
  (Run-TestProtectedAsJob { Test-RemoveWebApp } "Test-RemoveWebApp"), 
  (Run-TestProtectedAsJob { Test-SetWebApp} "Test-SetWebApp")

)

# Wait for all of the jobs we just created (and report progress).

while (($jobs | Where-Object { $_.State -eq "Running" }).Count -gt 0) {
  $running = @($jobs | Where-Object { $_.State -eq "Running" } | Select-Object -ExpandProperty Name)
  $completed = @($jobs | Where-Object { $_.State -eq "Completed" } | Select-Object -ExpandProperty Name)
  $runningString = $running -join ", "
  $completedString = $completed -join ", "

  Write-Progress -Activity "Netcore Tests" -CurrentOperation "Running: $runningString" -Status "Completed: $completedString" -PercentComplete ($completed.Count * 100.0 / $jobs.Count)

  Start-Sleep 5
}

# Receive the jobs and compile data.

$jobs | Receive-Job | ForEach-Object {
  $results.passedTests += $_.passedTests
  $results.passedCount += $_.passedCount
  $results.totalCount += $_.totalCount
  $results.failedTests += $_.failedTests
  $results.times += $_.times
} > $null

# Write results.

Write-Host
Write-Host -ForegroundColor Green "${$results.passedCount} / ${$results.totalCount} E2E Scenario Tests Pass"
Write-Host -ForegroundColor Green "============"
Write-Host -ForegroundColor Green "PASSED TESTS"
Write-Host -ForegroundColor Green "============"
$results.passedTests | ForEach-Object { Write-Host -ForegroundColor Green "PASSED "$_": "($results.times[$_]).ToString()}
Write-Host -ForegroundColor Green "============"
Write-Host
if ($results.failedTests.Count -gt 0)
{
  Write-Host -ForegroundColor Red "============"
  Write-Host -ForegroundColor Red "FAILED TESTS"
  Write-Host -ForegroundColor Red "============"
  $results.failedTests | ForEach-Object { Write-Host -ForegroundColor Red "FAILED "$_": "($results.times[$_]).ToString()}
  Write-Host -ForegroundColor Red "============"
  Write-Host
}
$results.endTime = Get-Date
Write-Host -ForegroundColor Green "======="
Write-Host -ForegroundColor Green "TIMES"
Write-Host -ForegroundColor Green "======="
Write-Host
Write-Host -ForegroundColor Green "Start Time: $($results.startTime)"
Write-Host -ForegroundColor Green "End Time: $($results.endTime)"
Write-Host -ForegroundColor Green "Elapsed: "($results.endTime - $results.startTime).ToString()
Write-Host -ForegroundColor Black "============================================================================================="
Write-Host
Write-Host

$ErrorActionPreference = "Continue"