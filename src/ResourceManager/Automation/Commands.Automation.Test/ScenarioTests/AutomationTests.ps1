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

<#
.SYNOPSIS
Checks whether the first string contains the second one
#>

$accountName='account'
$location = "East US"

function AssertContains
{
    param([string] $str, [string] $substr, [string] $message)

    if (!$message)
    {
        $message = "Assertion failed because '$str' does not contain '$substr'"
    }
  
    if (!$str.Contains($substr)) 
    {
        throw $message
    }
  
    return $true
}  

<#
.SYNOPSIS
Checks whether the runbook exists and if it exists, removes it and then imports a new runbook 
#>
function CreateRunbook
{
    param([string] $runbookPath, [boolean] $byName=$false, [string[]] $tag, [string] $description)

    $runbookName = gci $runbookPath | %{$_.BaseName}
    $runbook = Get-AzureRmAutomationRunbook $accountName | where {$_.Name -eq $runbookName} 
    if ($runbook.Count -eq 1)
    {
        Remove-AzureRmAutomationRunbook $accountName -Name $runbookName -Force
    }

    if(!$byName)
    {
        return New-AzureRmAutomationRunbook $accountName -Path $runbookPath -Tag $tag -Description $description
    }
    else 
    {
        return New-AzureRmAutomationRunbook $accountName -Name $runbookName -Tag $tag -Description $description
    }
}

########################################################################### Automation Scenario Tests ###########################################################################

######### $accountName and $subscriptionName should be provided in variables.yml in order to run the following Test Cases #######################

<#
.SYNOPSIS
Waits for Job to be a specific status for approximately $numOfSeconds
#>
function WaitForJobStatus
{
    param([Guid] $Id, [Int] $numOfSeconds = 150, [String] $Status)
    
    $timeElapse = 0
    $interval = 3
    $endStatus = @('completed','failed')
    while($timeElapse -lt $numOfSeconds)
    {
        Wait-Seconds $interval
        $timeElapse = $timeElapse + $interval
        $job = Get-AzureRmAutomationJob -AutomationAccount $accountName -Id $Id
        if($job.Status -eq $Status)
        {
            break
        }
        elseif($endStatus -contains $job.Status.ToLower())
        {	    
            Write-Output ("The Job with ID $($job.Id) reached $($job.Status) Status already.")
            return
        }
    }
    Assert-AreEqual $Status $job.Status "Job did not reach $Status status within $numOfSeconds seconds.";
}

<#
.SYNOPSIS
Tests Runbook with Parameters
#>
function Test-RunbookWithParameter
{
    param([string] $runbookPath, [HashTable] $parameters, [int]$expectedResult)

    #Setup
    $automationAccount = Get-AzureRmAutomationAccount -Name $accountName
    Assert-NotNull $automationAccount "Automation account $accountName does not exist."

    $runbook = CreateRunbook  $runbookPath
    Assert-NotNull $runbook  "runBook $runbookPath does not import successfully."
    $automationAccount | Publish-AzureRmAutomationRunbook -Name $runbook.Name

    #Test
    $job = $automationAccount | Start-AzureRmAutomationRunbook -Name $runbook.Name -Parameters $parameters
    WaitForJobStatus -Id $job.Id -Status "Completed"
    $jobOutput = $automationAccount | Get-AzureRmAutomationJobOutput -Id $job.Id -Stream Output
    $automationAccount | Remove-AzureRmAutomationRunbook -Name $runbook.Name -Force 
    Assert-Throws { $automationAccount | Get-AzureRmAutomationRunbook -Name $runbook.Name}
}

<#
.SYNOPSIS
Tests of Start and Stop RunBook
#>
function Test-AutomationStartAndStopRunbook
{
    param([string] $runbookPath)
        
	$automationAccount = Get-AzureRmAutomationAccount -Name $accountName
    Assert-NotNull $automationAccount "Automation account $accountName does not exist."

    $runbook = CreateRunbook $runbookPath
    Assert-NotNull $runbook  "runBook $runbookPath does not import successfully."
    $automationAccount | Publish-AzureRmAutomationRunbook -Name $runbook.Name
    
    #Test
    $job = Start-AzureRmAutomationRunbook -Name $runbook.Name -AutomationAccountName $accountName
    WaitForJobStatus -Id $job.Id -Status "Running"
    $automationAccount | Stop-AzureRmAutomationJob -Id $job.Id
    WaitForJobStatus -Id $job.Id -Status "Stopped"
    $automationAccount | Remove-AzureRmAutomationRunbook -Name $runbook.Name  -Force 
    Assert-Throws { $automationAccount | Get-AzureRmAutomationRunbook -Name $runbook.Name}
}

<#
.SYNOPSIS
Tests publishing runbook and editing runbook with and without Overwrite parameter
#>
function Test-AutomationPublishAndEditRunbook
{
    param([string] $runbookPath, [string] $editRunbookPath)
    
    $runbook = CreateRunbook $runbookPath $true

    #Publish Runbook
    Publish-AzureRmAutomationRunbook $accountName -Name $runbook.Name
	$publishedRunbook = Get-AzureRmAutomationRunbook  $accountName -Name $runbook.Name
	$runbookState = "Published"
    Assert-AreEqual $publishedRunbook.State $runbookState "Runbook should be in $runbookState state"
    $publishedRunbookDefn = Get-AzureRmAutomationRunbookDefinition $accountName -Name $runbook.Name
    
    #Edit Runbook
    Set-AzureRmAutomationRunbookDefinition $accountName -Name $runbook.Name -Path $runbookPath -Overwrite
    $runbook = Get-AzureRmAutomationRunbook  $accountName -Name $runbook.Name
	$runbookState = "Edit"
    Assert-AreEqual $runbook.State $runbookState "Runbook should be in $runbookState state"
    $editedRunbookDefn = Get-AzureRmAutomationRunbookDefinition $accountName -Name $runbook.Name -Slot "Draft"
    Assert-AreNotEqual $editedRunbookDefn.Content $publishedRunbookDefn.Content "Old content and edited content of the runbook shouldn't be equal"
    
    Assert-Throws {Set-AzureRmAutomationRunbookDefinition $accountName -Name $runbook.Name -Path $editRunbookPath -PassThru -ErrorAction Stop} 
    Set-AzureRmAutomationRunbookDefinition $accountName -Name $runbook.Name -Path $editRunbookPath -Overwrite
    $editedRunbookDefn2 = Get-AzureRmAutomationRunbookDefinition $accountName -Name $runbook.Name -Slot "Draft"
    Assert-AreNotEqual $editedRunbookDefn2.Content $editedRunbookDefn.Content "Old content and edited content of the runbook shouldn't be equal"

    Remove-AzureRmAutomationRunbook $accountName -Name $runbook.Name -Force
    Assert-Throws {Get-AzureRmAutomationRunbook $accountName -Name $runbook.Name}

}

<#
.SYNOPSIS
Tests setting runbook configuration
#>
function Test-AutomationConfigureRunbook
{
    param([string] $runbookPath)
    
    #Setup
    $automationAccount = Get-AzureRmAutomationAccount -Name $accountName
    Assert-NotNull $automationAccount "Automation account $accountName does not exist."
    $runbook = CreateRunbook $runbookPath
    Assert-NotNull $runbook  "runbook ($runbookPath) isn't imported successfully."
    Publish-AzureRmAutomationRunbook -Name $runbook.Name -AutomationAccountName $accountName
    
    #Test

    #Change the runbook configuration
    $automationAccount | Set-AzureRmAutomationRunbook -Name $runbook.Name -LogVerbose $true -LogProgress $false
    $runbook = $automationAccount | Get-AzureRmAutomationRunbook -Name $runbook.Name
    Assert-NotNull $runbook "Runbook shouldn't be Null"
    Assert-AreEqual $true $runbook.LogVerbose "Log Verbose mode should be true."
    Assert-AreEqual $false $runbook.LogProgress "Log Progress mode should be false."

    #Start runbook and wait for job complete
    $job = $automationAccount | Start-AzureRmAutomationRunbook -Name $runbook.Name
    WaitForJobStatus -Id $job.Id -Status "Completed"

    #Check job output streams
    $jobOutputs = $automationAccount | Get-AzureRmAutomationJobOutput -Id $job.Id -Stream "Output"
    Assert-AreEqual 1 $jobOutputs.Count
    AssertContains $jobOutputs[0].Text "output message" "The output stream is wrong."
    #Verify that verbose streams are logged
    $jobVerboseOutputs = Get-AzureRmAutomationJobOutput $accountName -Id $job.Id -Stream "Verbose"
    Assert-AreEqual 1 $jobVerboseOutputs.Count
    AssertContains $jobVerboseOutputs[0].Text "verbose message" "The verbose stream is wrong."
    #Verify that progress stream isn't logged
    $jobProgressOutputs = Get-AzureRmAutomationJobOutput -AutomationAccountName $accountName -Id $job.Id -Stream "Progress"
    Assert-AreEqual 0 $jobProgressOutputs.Count
    
    #Change the runbook configuration again and start the runbook
    Set-AzureRmAutomationRunbook $accountName -Name $runbook.Name -LogVerbose $false -LogProgress $true
    $job = Start-AzureRmAutomationRunbook $accountName -Name $runbook.Name
    WaitForJobStatus -Id $job.Id -Status "Completed"
    #Verify that progress stream is logged
    $jobProgressOutputs = Get-AzureRmAutomationJobOutput $accountName -Id $job.Id -Stream "Progress"
    Assert-AreNotEqual 0 $jobProgressOutputs.Count
    Assert-AreEqual $jobProgressOutputs[0].Type "Progress"
    #Verify that verbose streams aren't logged
    $jobVerboseOutputs = Get-AzureRmAutomationJobOutput $accountName -Id $job.Id -Stream "Verbose"
    Assert-AreEqual 0 $jobVerboseOutputs.Count
    
    #Check whether the total number of jobs for the runbook is correct
    $jobs = Get-AzureRmAutomationJob $accountName -RunbookName $runbook.Name
    Assert-AreEqual 2 $jobs.Count "There should be 2 jobs in total for this runbook."
    
    #Remove runbook
    $automationAccount | Remove-AzureRmAutomationRunbook -Name $runbook.Name -Force 
    Assert-Throws {$automationAccount | Get-AzureRmAutomationRunbook -Name $runbook.Name}
}

<#
.SYNOPSIS
Tests suspending a started job and resuming a suspended job
#>
function Test-AutomationSuspendAndResumeJob
{
    param([string] $runbookPath)
    
    #Setup
    $automationAccount = Get-AzureRmAutomationAccount $accountName
    Assert-NotNull $automationAccount "Automation account $accountName does not exist."
    $runbook = CreateRunbook $runbookPath
    
    #Test

    $automationAccount | Publish-AzureRmAutomationRunbook -Name $runbook.Name
    #Start, suspend, and then resume job
    $job = Start-AzureRmAutomationRunbook $accountName -Name $runbook.Name
    WaitForJobStatus -Id $job.Id -Status "Running"
    Suspend-AzureRmAutomationJob $accountName -Id $job.Id
    WaitForJobStatus -Id $job.Id -Status "Suspended"
    $automationAccount | Resume-AzureRmAutomationJob -Id $job.Id
    WaitForJobStatus -Id $job.Id -Status "Completed"

    #Remove runbook
    Remove-AzureRmAutomationRunbook -AutomationAccountName $accountName -Name $runbook.Name -Force 
    Assert-Throws {Get-AzureRmAutomationRunbook $accountName -Name $runbook.Name}
}

<#
.SYNOPSIS
Tests starting a runbook on a schedule
#>
function Test-AutomationStartRunbookOnASchedule
{
    param([string] $runbookPath)
    
    #Setup
    $automationAccount = Get-AzureRmAutomationAccount -Name $accountName
    $runbook = CreateRunbook $runbookPath
    Publish-AzureRmAutomationRunbook $accountName -Name $runbook.Name
    
    #Test

    #Create one time schedule
    $oneTimeScheName = "oneTimeSchedule"
    $schedule = Get-AzureRmAutomationSchedule $accountName | where {$_.Name -eq $oneTimeScheName} 
    if ($schedule.Count -eq 1)
    {
        Remove-AzureRmAutomationSchedule $accountName -Name $oneTimeScheName -Force
    }
    $startTime = (Get-Date).AddMinutes(7)
    New-AzureRmAutomationSchedule $accountName -Name $oneTimeScheName -OneTime -StartTime $startTime
    $oneTimeSchedule = Get-AzureRmAutomationSchedule $accountName -Name $oneTimeScheName
    Assert-NotNull $oneTimeSchedule "$oneTimeScheName doesn't exist!"
    
    #Create daily schedule
    $dailyScheName = "dailySchedule"
    $schedule = Get-AzureRmAutomationSchedule $accountName | where {$_.Name -eq $dailyScheName} 
    if ($schedule.Count -eq 1)
    {
        Remove-AzureRmAutomationSchedule $accountName -Name $dailyScheName -Force
    }
    $startTime = (Get-Date).AddDays(1)
    $expiryTime = (Get-Date).AddDays(3)
    New-AzureRmAutomationSchedule $accountName -Name $DailyScheName -StartTime $startTime -ExpiryTime $expiryTime -DayInterval 1
    $dailySchedule = Get-AzureRmAutomationSchedule $accountName -Name $dailyScheName
    Assert-NotNull $dailySchedule "$dailyScheName doesn't exist!"

    $runbook = Register-AzureRmAutomationScheduledRunbook $accountName -Name $runbook.Name -ScheduleName $oneTimeScheName
    Assert-AreEqual $oneTimeScheName $runbook.ScheduleNames "The runbook should be associated with $oneTimeScheName"
    $runbook = Register-AzureRmAutomationScheduledRunbook $accountName -Name $runbook.Name -ScheduleName $dailyScheName
    Assert-True { $runbook.ScheduleNames -Contains $dailyScheName} "The runbook should be associated with $dailyScheName"
   
    #waiting for seven minutes
    Wait-Seconds 420 
    $job = Get-AzureRmAutomationJob $accountName -Name $runbook.Name | where {$_.ScheduleName -eq $oneTimeScheName}
	$jobSchedule = Get-AzureRmAutomationScheduledRunbook $accountName -RunbookName $runbook.Name -ScheduleName $oneTimeScheName
	Assert-AreEqual 1 $jobSchedule.Count
    Assert-AreEqual 1 $job.Count
    WaitForJobStatus -Id $job.Id -Status "Completed"

    #Edit schedule
    $description = "Daily Schedule Description"
    Set-AzureRmAutomationSchedule $accountName -Name $dailyScheName -Description $description
    $dailySchedule = Get-AzureRmAutomationSchedule $accountName -Name $dailyScheName
    Assert-AreEqual $description $dailySchedule.Description

    Unregister-AzureRmAutomationScheduledRunbook $accountName -Name $runbook.Name -ScheduleName $dailyScheName
	$jobSchedule = Get-AzureRmAutomationScheduledRunbook $accountName -RunbookName $runbook.Name -ScheduleName $dailyScheName
    Assert-Null $jobSchedule "The runbook shouldn't have an association with $dailyScheName"

    #Remove runbook and schedule
    Remove-AzureRmAutomationSchedule $accountName -Name $oneTimeScheName -Force
    Assert-Throws {$automationAccount | Get-AzureRmAutomationSchedule -Name $oneTimeScheName}
    $automationAccount | Remove-AzureRmAutomationSchedule -Name $dailyScheName -Force
    Assert-Throws {$automationAccount | Get-AzureRmAutomationSchedule -Name $dailyScheName}
    Remove-AzureRmAutomationRunbook $accountName -Name $runbook.Name -Force
    Assert-Throws {Get-AzureRmAutomationRunbook $accountName -Name $runbook.Name}
}

<#
.SYNOPSIS
Tests starting an unpublished runbook
#>
function Test-AutomationStartUnpublishedRunbook
{
    param([string] $runbookPath)
    
    $tags = @("tag1","tag2")
    $description = "Runbook Description"
    $c = Get-Date
    $runbookParameters = @{"a" = "stringParameter"; "b" = 123; "c" = $c}
    $runbook = CreateRunbook $runbookPath $false $tags $description
    Assert-NotNull $runbook "runBook $runbookPath does not import successfully."
    Assert-NotNull $runbook.Tags "Tags of the runbook shouldn't be Null."
    Assert-NotNull $runbook.Description "Description of the runbook shouldn't be Null."
    Assert-Throws {Start-AzureRmAutomationRunbook $accountName -Name $runbook.Name -Parameters $runbookParameters -PassThru -ErrorAction Stop} 
    
    Remove-AzureRmAutomationRunbook $accountName -Name $runbook.Name -Force 
    Assert-Throws {Get-AzureRmAutomationRunbook $accountName -Name $runbook.Name -Parameters $runbookParameters -PassThru -ErrorAction Stop}
}
