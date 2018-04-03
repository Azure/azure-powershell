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
Tests Runbook with Parameters
#>
function Test-RunbookWithParameter
{
    param([string] $runbookPath)

    #Setup
    $runbook = CreateRunbook  $runbookPath
    Assert-NotNull $runbook  "runBook $runbookPath does not import successfully."
	$resourceGroupName = $runbook.ResourceGroupName
	$automationAccountName = $runbook.AutomationAccountName

    Publish-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                 -AutomationAccountName $automationAccountName `
									 -Name $runbook.Name

    #Test
	# Hardcoded the parameters as the input int[] is coming as string from C#.
	$numberArray= 1,2,3,4,5,6,7
	$parameters=@{'nums'= $numberArray}
	$expectedResult = 28
    $job = Start-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                      -AutomationAccountName $automationAccountName `
										  -Name $runbook.Name `
										  -Parameters $parameters
    WaitForJobStatus -ResourceGroupName $resourceGroupName `
	                 -AutomationAccountName $automationAccountName `
					 -Id $job.JobId `
					 -Status "Completed"
    
	$jobOutput = Get-AzureRmAutomationJobOutput -ResourceGroupName $resourceGroupName `
	                                            -AutomationAccountName $automationAccountName `
												-Id $job.JobId `
												-Stream "Output" | Get-AzureRmAutomationJobOutputRecord

    Assert-AreEqual 1 $jobOutput.Count
    AssertContains $jobOutput.Value.Values $expectedResult "The output sum is wrong."

    Remove-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                -AutomationAccountName $automationAccountName `
									-Name $runbook.Name `
									-Force 
    Assert-Throws { Get-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                             -AutomationAccountName $automationAccountName `
												 -Name $runbook.Name}
}

<#
.SYNOPSIS
Tests of Start and Stop RunBook
#>
function Test-AutomationStartAndStopRunbook
{
    param([string] $runbookPath)
        
    $runbook = CreateRunbook $runbookPath
    Assert-NotNull $runbook  "runBook $runbookPath does not import successfully."
	$resourceGroupName = $runbook.ResourceGroupName
	$automationAccountName = $runbook.AutomationAccountName

    Publish-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                 -AutomationAccountName $automationAccountName `
									 -Name $runbook.Name    
    #Test
    $job = Start-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                      -AutomationAccountName $automationAccountName `
										  -Name $runbook.Name 

    WaitForJobStatus -ResourceGroupName $resourceGroupName `
	                 -AutomationAccountName $automationAccountName `
					 -Id $job.JobId `
					 -Status "Running"

    Stop-AzureRmAutomationJob -ResourceGroupName $resourceGroupName `
	                          -AutomationAccountName $automationAccountName `
					          -Id $job.JobId
    
    WaitForJobStatus -ResourceGroupName $resourceGroupName `
	                 -AutomationAccountName $automationAccountName `
					 -Id $job.JobId `
					 -Status "Stopped"

    Remove-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                -AutomationAccountName $automationAccountName `
									-Name $runbook.Name `
									-Force 
    Assert-Throws { Get-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                             -AutomationAccountName $automationAccountName `
												 -Name $runbook.Name}
}

<#
.SYNOPSIS
Tests publishing runbook and editing runbook with and without Overwrite parameter
#>
function Test-AutomationPublishAndEditRunbook
{
    param([string] $runbookPath, [string] $editRunbookPath)
    
    $runbook = CreateRunbook $runbookPath
    $resourceGroupName = $runbook.ResourceGroupName
	$automationAccountName = $runbook.AutomationAccountName

    #Publish Runbook
    Publish-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                 -AutomationAccountName $automationAccountName `
									 -Name $runbook.Name    

	$publishedRunbook = Get-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                                 -AutomationAccountName $automationAccountName `
													 -Name $runbook.Name   
	$runbookState = "Published"
    Assert-AreEqual $publishedRunbook.State $runbookState "Runbook should be in $runbookState state"

	$publishFolder = New-Item -ItemType Directory -Force -Path (Join-Path $env:temp "Publish")
    $exportPublishedRunbook = Export-AzureRmAutomationRunbook  -ResourceGroupName $resourceGroupName `
	                                                            -AutomationAccountName $automationAccountName `
														        -Name $runbook.Name `
																-Slot "Published" `
																-OutputFolder $publishFolder.FullName `
																-Force 

	$exportPublishedRunbookFileName = Get-ChildItem -Path $publishFolder.FullName -Filter ($runbook.Name+".ps1")
	$exportPublishedRunbookFirstLine = Get-Content $exportPublishedRunbookFileName.FullName -First 1 | Out-String
															    
    #Edit Runbook 
	Import-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                -AutomationAccountName $automationAccountName `
									-Name $runbook.Name `
									-Path $runbookPath `
									-Type PowerShell `
									-Force

    $runbook = Get-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                        -AutomationAccountName $automationAccountName `
											-Name $runbook.Name
	$runbookState = "Edit"
    Assert-AreEqual $runbook.State $runbookState "Runbook should be in $runbookState state"

	$draftFolder = New-Item -ItemType Directory -Force -Path (Join-Path $env:temp "Draft")    
	$exportDraftRunbook = Export-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                                      -AutomationAccountName $automationAccountName `
					               					      -Name $runbook.Name `
														  -Slot "Draft" `
														  -OutputFolder $draftFolder.FullName `
														  -Force

	$exportDraftRunbookFileName = Get-ChildItem -Path $draftFolder.FullName -Filter ($runbook.Name+".ps1")
	$exportDraftRunbookFirstLine = Get-Content $exportDraftRunbookFileName.FullName -First 1 | Out-String
    Assert-True { $exportPublishedRunbookFirstLine  -eq $exportDraftRunbookFirstLine} "Old content and edited content of the runbook should be same"
    
    Assert-Throws {	Import-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                                -AutomationAccountName $automationAccountName `
									                -Name $runbook.Name `
									                -Path $editRunbookPath `
									                -Type PowerShell `
									                -ErrorAction Stop} 
	Import-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                -AutomationAccountName $automationAccountName `
									-Name $runbook.Name `
									-Path $editRunbookPath `
									-Type PowerShell `
									-Force
	$draft2Folder = New-Item -ItemType Directory -Force -Path (Join-Path $env:temp "Draft2")    
	$exportDraft2Runbook = Export-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                                       -AutomationAccountName $automationAccountName `
													       -Name $runbook.Name `
														   -Slot "Draft" `
														   -OutputFolder $draft2Folder.FullName `
														   -Force

	$exportDraft2RunbookFileName = Get-ChildItem -Path $draft2Folder.FullName -Filter ($runbook.Name+".ps1")
	$exportDraft2RunbookFirstLine = Get-Content $exportDraft2RunbookFileName.FullName -First 1| Out-String
    Assert-True {$exportDraft2RunbookFirstLine -ne $exportDraftRunbookFirstLine} "Old content and edited content of the runbook shouldn't be equal"
}

<#
.SYNOPSIS
Tests setting runbook configuration
#>
function Test-AutomationConfigureRunbook
{
    param([string] $runbookPath)
    
    #Setup
    $runbook = CreateRunbook $runbookPath
    Assert-NotNull $runbook  "runbook ($runbookPath) isn't imported successfully."
    $resourceGroupName = $runbook.ResourceGroupName
	$automationAccountName = $runbook.AutomationAccountName

    #Publish Runbook
    Publish-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                 -AutomationAccountName $automationAccountName `
									 -Name $runbook.Name    
    
    #Test

    #Change the runbook configuration
    Set-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                             -AutomationAccountName $automationAccountName `
								 -Name $runbook.Name `
								 -LogVerbose $true `
								 -LogProgress $false

    $runbook = Get-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                        -AutomationAccountName $automationAccountName `
								            -Name $runbook.Name

    Assert-NotNull $runbook "Runbook shouldn't be Null"
    Assert-AreEqual $true $runbook.LogVerbose "Log Verbose mode should be true."
    Assert-AreEqual $false $runbook.LogProgress "Log Progress mode should be false."

    #Start runbook and wait for job complete
    $job = Start-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                      -AutomationAccountName $automationAccountName `
										  -Name $runbook.Name 
    WaitForJobStatus -ResourceGroupName $resourceGroupName `
	                 -AutomationAccountName $automationAccountName `
					 -Id $job.JobId `
					 -Status "Completed"

    #Check job output streams
	$jobOutputs = Get-AzureRmAutomationJobOutput -ResourceGroupName $resourceGroupName `
	                                             -AutomationAccountName $automationAccountName `
										   		 -Id $job.JobId `
												 -Stream "Output" | Get-AzureRmAutomationJobOutputRecord

    Assert-AreEqual 1 $jobOutputs.Count
    AssertContains $jobOutputs.Value.Values "output message" "The output stream is wrong."

    #Verify that verbose streams are logged
    $jobVerboseOutputs =  Get-AzureRmAutomationJobOutput -ResourceGroupName $resourceGroupName `
	                                                     -AutomationAccountName $automationAccountName `
 										   		         -Id $job.JobId `
												         -Stream "Verbose" | Get-AzureRmAutomationJobOutputRecord
    Assert-AreEqual 1 $jobVerboseOutputs.Count
    AssertContains $jobVerboseOutputs.Value.Values "verbose message" "The verbose stream is wrong."

    #Verify that progress stream isn't logged
    $jobProgressOutputs = Get-AzureRmAutomationJobOutput -ResourceGroupName $resourceGroupName `
	                                                     -AutomationAccountName $automationAccountName `
 										   		         -Id $job.JobId `
												         -Stream "Progress" | Get-AzureRmAutomationJobOutputRecord
    Assert-Null $jobProgressOutputs
    
    #Change the runbook configuration again and start the runbook
    Set-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                             -AutomationAccountName $automationAccountName `
								 -Name $runbook.Name `
								 -LogVerbose $false `
								 -LogProgress $true

    $job = Start-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                      -AutomationAccountName $automationAccountName `
										  -Name $runbook.Name 

    WaitForJobStatus -ResourceGroupName $resourceGroupName `
	                 -AutomationAccountName $automationAccountName `
					 -Id $job.JobId `
					 -Status "Completed"    
	
	#Verify that progress stream is logged
    $jobProgressOutputs = Get-AzureRmAutomationJobOutput -ResourceGroupName $resourceGroupName `
	                                                     -AutomationAccountName $automationAccountName `
 										   		         -Id $job.JobId `
												         -Stream "Progress" | Get-AzureRmAutomationJobOutputRecord
    Assert-AreNotEqual 0 $jobProgressOutputs.Count
    Assert-AreEqual $jobProgressOutputs[0].Type "Progress"

    #Verify that verbose streams aren't logged
    $jobVerboseOutputs =  Get-AzureRmAutomationJobOutput -ResourceGroupName $resourceGroupName `
	                                                     -AutomationAccountName $automationAccountName `
 										   		         -Id $job.JobId `
												         -Stream "Verbose" | Get-AzureRmAutomationJobOutputRecord
    Assert-Null $jobVerboseOutputs
    
    #Check whether the total number of jobs for the runbook is correct
    $jobs = Get-AzureRmAutomationJob -ResourceGroupName $resourceGroupName `
	                                 -AutomationAccountName $automationAccountName `
									 -RunbookName $runbook.Name
    Assert-AreEqual 2 $jobs.Count "There should be 2 jobs in total for this runbook."
    
    #Remove runbook
    Remove-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                -AutomationAccountName $automationAccountName `
									-Name $runbook.Name `
									-Force 
    Assert-Throws { Get-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                             -AutomationAccountName $automationAccountName `
												 -Name $runbook.Name}
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
    $runbook = CreateRunbook $runbookPath
	$resourceGroupName = $runbook.ResourceGroupName
	$automationAccountName = $runbook.AutomationAccountName

    Publish-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                 -AutomationAccountName $automationAccountName `
									 -Name $runbook.Name
    
    #Test

    #Create one time schedule
    $oneTimeScheName = "oneTimeSchedule"
    $oneTimeScheStartTime = (Get-Date).AddMinutes(7)
    $oneTimeScheduleCreated = New-AzureRmAutomationSchedule -ResourceGroupName $resourceGroupName `
	                                                        -AutomationAccountName $automationAccountName `
															-Name $oneTimeScheName `
															-OneTime `
															-StartTime $oneTimeScheStartTime

    Assert-NotNull $oneTimeScheduleCreated "$oneTimeScheName doesn't exist!"
    
    #Create daily schedule
    $dailyScheName = "dailySchedule"
    $dailyScheStartTime = (Get-Date).AddDays(1)
    $dailyScheExpiryTime = (Get-Date).AddDays(3)
    $dailyScheduleCreated = New-AzureRmAutomationSchedule -ResourceGroupName $resourceGroupName `
	                                                      -AutomationAccountName $automationAccountName `
												          -Name $dailyScheName `
														  -StartTime $dailyScheStartTime `
														  -ExpiryTime $dailyScheExpiryTime `
														  -DayInterval 1

    $dailySchedule = Get-AzureRmAutomationSchedule -ResourceGroupName $resourceGroupName `
	                                               -AutomationAccountName $automationAccountName `
												   -Name $dailyScheName
    Assert-NotNull $dailySchedule "$dailyScheName doesn't exist!"
	
    $scheduledRunbook = Register-AzureRmAutomationScheduledRunbook -ResourceGroupName $resourceGroupName `
	                                                               -AutomationAccountName $automationAccountName `
														           -Name $runbook.Name `
														           -ScheduleName $oneTimeScheName

    Assert-AreEqual $oneTimeScheName $scheduledRunbook.ScheduleName "The runbook should be associated with $oneTimeScheName"


    $dailyScheduledRunbook = Register-AzureRmAutomationScheduledRunbook -ResourceGroupName $resourceGroupName `
	                                                                    -AutomationAccountName $automationAccountName `
														                -Name $runbook.Name `
														                -ScheduleName $dailyScheName

    Assert-True { $dailyScheduledRunbook.ScheduleName -Contains $dailyScheName} "The runbook should be associated with $dailyScheName"

    #waiting for seven minutes
    Wait-Seconds 420 
    $job = Get-AzureRmAutomationJob -ResourceGroupName $resourceGroupName `
	                                -AutomationAccountName $automationAccountName `
								    -Name $runbook.Name 
	$jobSchedule = Get-AzureRmAutomationScheduledRunbook -ResourceGroupName $resourceGroupName `
	                                                     -AutomationAccountName $automationAccountName `
														 -ScheduleName $oneTimeScheName
	Assert-AreEqual 1 $jobSchedule.Count
    Assert-AreEqual 1 $job.Count
    Assert-AreEqual $runbook.Name $jobSchedule.RunbookName

    WaitForJobStatus -ResourceGroupName $resourceGroupName `
	                 -AutomationAccountName $automationAccountName `
					 -Id $job.JobId `
					 -Status "Completed"

	#Edit schedule
    $description = "Daily Schedule Description"
    Set-AzureRmAutomationSchedule -ResourceGroupName $resourceGroupName `
	                              -AutomationAccountName $automationAccountName `
								  -Name $dailyScheName `
								  -Description $description
    $updatedDailySchedule = Get-AzureRmAutomationSchedule -ResourceGroupName $resourceGroupName `
	                                                      -AutomationAccountName $automationAccountName `
												          -Name $dailyScheName
    Assert-AreEqual $description $updatedDailySchedule.Description

	Unregister-AzureRmAutomationScheduledRunbook -ResourceGroupName $resourceGroupName `
	                                             -AutomationAccountName $automationAccountName `
												 -RunbookName $runbook.Name `
												 -ScheduleName $oneTimeScheName `
												 -Force

    Unregister-AzureRmAutomationScheduledRunbook -ResourceGroupName $resourceGroupName `
	                                             -AutomationAccountName $automationAccountName `
												 -RunbookName $runbook.Name `
												 -ScheduleName $dailyScheName `
												 -Force

	$dailyJobSchedule = Get-AzureRmAutomationScheduledRunbook -ResourceGroupName $resourceGroupName `
	                                                          -AutomationAccountName $automationAccountName `
															   
    Assert-Null $dailyJobSchedule "The runbook shouldn't have an association with $dailyScheName"

    #Remove runbook and schedule
    Remove-AzureRmAutomationSchedule -ResourceGroupName $resourceGroupName `
	                                 -AutomationAccountName $automationAccountName `
									 -Name $oneTimeScheName `
									 -Force
    Assert-Throws {Get-AzureRmAutomationSchedule -ResourceGroupName $resourceGroupName `
	                                             -AutomationAccountName $automationAccountName `
												 -Name $oneTimeScheName}
    Remove-AzureRmAutomationSchedule -ResourceGroupName $resourceGroupName `
	                                 -AutomationAccountName $automationAccountName `
									 -Name $dailyScheName `
									 -Force
    Assert-Throws {Get-AzureRmAutomationSchedule -ResourceGroupName $resourceGroupName `
	                                             -AutomationAccountName $automationAccountName `
												 -Name $dailyScheName}
    Remove-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                -AutomationAccountName $automationAccountName `
									-Name $runbook.Name `
									-Force
    Assert-Throws {Get-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
	                                            -AutomationAccountName $automationAccountName ` 
												-Name $runbook.Name}
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
