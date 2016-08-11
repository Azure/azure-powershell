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

# Default job collection values
$location = "West US"

<#
.SYNOPSIS
Test creation of Http Job.
#>
function Test-CreateHttpJob
{
    $resource = TestSetup-CreateResourceGroup
    $resourceGroupName = $resource.ResourceGroupName
    
    try
    {
        # Create job collection with Standard Plan
        $jobCollectionName = "CreateJobCollectionWithStandardPlan"
        New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location

        # Create a new default http job
        $jobName = "DefaultHttpJob"
        $status = "Enabled"
        $startTime = $null
        $recurrence = $null
        $endSchedule = "Run once"
        $jobActionType = "Http"
        $method = "get"
        $uri = "http://www.bing.com/"
        $body = $null
        $headers = $null
        $httpAuthenticationType = $null

        $jobDefinition = New-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -Method $method -Uri $uri

        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction

        # Create a new http job with headers and body
        $jobName = "HttpJobWithHeadersAndBody"
        $method = "post"
        $body = "Hello"
        $headers = @{"ConTent-tYPe" = "application/json"}

        $jobDefinition =  New-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -Method $method -Uri $uri -RequestBody $body -Headers $headers
        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction

        $jobName = "HttpJobWithHttpClientCertificateAuthentication"
        $method = "get"
        $body = $null
        $headers = $null
        $httpAuthenticationType = "Basic"
        $userName = "httpJob"
        $password = "p@ssword!"
        $jobDefinition =  New-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -Method $method -Uri $uri -HttpAuthenticationType $httpAuthenticationType -Username $username -Password $password
        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction

        $jobName = "HttpJobWithStartTime"
        $startTime = Get-Date
        $startTime = $startTime.AddDays(1)
        $startTime = $startTime.ToUniversalTime()
        $httpAuthenticationType = $null

        $jobDefinition =  New-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -Method $method -Uri $uri -StartTime $startTime
        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction

        $jobName = "HttpJobWith"
        $jobName = "HttpJobWithRecurrence"
        $interval = 1
        $frequency = "Minute"
        $endTime = Get-Date
        $endTime = $endTime.AddDays(4)
        $endTime = $endTime.ToUniversalTime()
        $executionCount = 10
        $endSchedule = "Until 10 executions. Or on " + $endTime.GetDateTimeFormats('G')[0] + " whichever occurs first."
        $recurrence = "Every 1 Minutes"

        $jobDefinition =  New-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -Method $method -Uri $uri -StartTime $startTime -Interval $interval -Frequency $frequency -ExecutionCount $executionCount -EndTime $endTime
        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction

        $jobName = "HttpJobWithErrorHttpAction"
        $status = "Enabled"
        $startTime = $null
        $recurrence = $null
        $endSchedule = "Run once"
        $jobActionType = "Http"
        $method = "get"
        $uri = "http://www.bing.com/"
        $body = $null
        $headers = $null
        $httpAuthenticationType = $null
        $errorActionType = "Http"
        $errorActionMethod = "post"
        $errorActionUri = "http://www.bing.com/"
        $errorActionBody = "HelloError"
        $errorActionHeaders = @{"ContEnt-TyPe" = "application/json";}
        $errorActionAuthenticationType = "Basic"
        $errorActionUserName = "HttpErrorAction"
        $errorActionPassword = "p@ssword!"
        $jobDefinition = New-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -Method $method -Uri $uri -ErrorActionType $errorActionType -ErrorActionMethod $errorActionMethod -ErrorActionUri $errorActionUri -ErrorActionRequestBody $errorActionBody -ErrorActionHeaders $errorActionHeaders -ErrorActionHttpAuthenticationType $errorActionAuthenticationType -ErrorActionUsername $errorActionUsername -ErrorActionPassword $errorActionPassword
        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction
        Validate-HttpJob $errorActionMethod $errorActionUri $errorActionBody $errorActionHeaders $errorActionAuthenticationType $jobDefinition.JobErrorAction
    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test creation of Http Job.
#>
function Test-UpdateHttpJob
{
    $resource = TestSetup-CreateResourceGroup
    $resourceGroupName = $resource.ResourceGroupName
    
    try
    {
        # Create job collection with Standard Plan
        $jobCollectionName = "CreateJobCollectionWithStandardPlan"
        New-AzureRmSchedulerJobCollection -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -Location $location

        # Create a new default http job
        $jobName = "DefaultHttpJob"
        $status = "Enabled"
        $startTime = $null
        $recurrence = $null
        $endSchedule = "Run once"
        $jobActionType = "Http"
        $method = "get"
        $uri = "http://www.bing.com/"
        $body = $null
        $headers = $null
        $httpAuthenticationType = $null

        $jobDefinition = New-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -Method $method -Uri $uri

        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction

        $startTime = Get-Date
        $startTime = $startTime.AddDays(1)
        $startTime = $startTime.ToUniversalTime()

        $jobDefinition =  Set-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -StartTime $startTime
        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction

        # Create a new http job with headers and body
        $method = "post"
        $body = "Hello"
        $headers = @{"Content-Type" = "application/json"}

        $jobDefinition =  Set-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -Method $method -Uri $uri -RequestBody $body -Headers $headers
        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction

        $httpAuthenticationType = "Basic"
        $userName = "httpJob"
        $password = "p@ssword!"
        $jobDefinition =  Set-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -HttpAuthenticationType $httpAuthenticationType -Username $username -Password $password
        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction

        $interval = 1
        $frequency = "Minute"
        $endTime = Get-Date
        $endTime = $endTime.AddDays(4)
        $endTime = $endTime.ToUniversalTime()
        $executionCount = 10
        $endSchedule = "Until 10 executions. Or on " + $endTime.GetDateTimeFormats('G')[0] + " whichever occurs first."
        $recurrence = "Every 1 Minutes"

        $jobDefinition =  Set-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -StartTime $startTime -Interval $interval -Frequency $frequency -ExecutionCount $executionCount -EndTime $endTime
        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction

        $status = "Enabled"
        $jobActionType = "Http"
        $errorActionType = "Http"
        $errorActionMethod = "post"
        $errorActionUri = "http://www.bing.com/"
        $errorActionBody = "HelloError"
        $errorActionHeaders = @{"ContEnt-TyPe" = "application/json";}
        $errorActionAuthenticationType = "Basic"
        $errorActionUserName = "HttpErrorAction"
        $errorActionPassword = "p@ssword!"
        $jobDefinition = Set-AzureRmSchedulerHttpJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -ErrorActionType $errorActionType -ErrorActionMethod $errorActionMethod -ErrorActionUri $errorActionUri -ErrorActionRequestBody $errorActionBody -ErrorActionHeaders $errorActionHeaders -ErrorActionHttpAuthenticationType $errorActionAuthenticationType -ErrorActionUsername $errorActionUsername -ErrorActionPassword $errorActionPassword
        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition.JobAction
        Validate-HttpJob $errorActionMethod $errorActionUri $errorActionBody $errorActionHeaders $errorActionAuthenticationType $jobDefinition.JobErrorAction

        $jobDefinition = Get-AzureRmSchedulerJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName
        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition[0]
        Validate-HttpJob $method $uri $body $headers $httpAuthenticationType $jobDefinition[0].JobAction
        Validate-HttpJob $errorActionMethod $errorActionUri $errorActionBody $errorActionHeaders $errorActionAuthenticationType $jobDefinition[0].JobErrorAction
    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test creation of storage job.
#>
function Test-CreateStorageJob
{
    $resource = TestSetup-CreateResourceGroup
    $resourceGroupName = $resource.ResourceGroupName
    
    try
    {
        #Create a Storage account.
        $storageAccountName = 'storage' + $resourceGroupName
        $location = 'West US'
        New-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -Location $location "StandardLRS"

        $storageQueueName = 'blahblahQueue'
        $storageSasToken = 'blahblahToken'
        $storageQueueMessage = 'blahblahMessage'
        $jobCollectionName = $resourceGroupName + 'StorageJC'
        $jobName = $jobCollectionName + 'StorageJob'
        $status = "Enabled"
        $startTime = $null
        $recurrence = $null
        $endSchedule = "Run once"

        $jobDefinition = New-AzureRmSchedulerStorageQueueJob -ResourceGroupName $resourceGroupName -JobCollectionName $jobCollectionName -JobName $jobName -StorageQueueAccount $storageAccountName -StorageQueueName $storageQueueName -StorageSASToken $storageSasToken -StorageQueueMessage $storageQueueMessage

        Validate-DefaultJob $resourceGroupName $jobCollectionName $jobName $status $startTime $recurrence $endSchedule $jobDefinition
        Validate-StorageQueueJob $storageAccountName $storageQueueName $storageQueueMessage $jobDefinition.JobAction
    }
    finally
    {
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Validates default functionality of a job.
#>
function Validate-DefaultJob(
    [string]$resourceGroupName,
    [string]$jobCollectionName,
    [string]$jobName,
    [string]$status,
    [string]$startTime,
    [string]$recurrence,
    [string]$endSchedule,
    [Microsoft.Azure.Commands.Scheduler.Models.PSSchedulerJobDefinition]$jobDefinition)
{
    Assert-AreEqual $resourceGroupName $jobDefinition.ResourceGroupName
    Assert-AreEqual $jobCollectionname $jobDefinition.JobCollectionName
    Assert-AreEqual $jobName $jobDefinition.JobName
    Assert-AreEqual $status $jobDefinition.Status
    #Assert-AreEqual $endSchedule $jobDefinition.EndSchedule

    if($recurrence -eq $null -or $recurrence -eq '')
    {
        Assert-Null $jobDefinition.Recurrence
    }
    else
    {
        Assert-AreEqual $recurrence $jobDefinition.Recurrence
    }

    if($startTime -eq $null -or $startTime -eq '')
    {
        Assert-Null $jobDefinition.StartTime
    }
}

<#
.SYNOPSIS
Validates http functionality of a job.
#>
function Validate-HttpJob(
    [string]$method,
    [string]$uri,
    [string]$body,
    [string]$headers,
    [string]$httpAuthenticationType,
    [Microsoft.Azure.Commands.Scheduler.Models.PSHttpJobActionDetails]$jobAction)
{
    $jobActionType = "Http"
    Assert-AreEqual $jobActionType $jobAction.JobActionType.ToString()
    Assert-AreEqual $method.ToUpper() $jobAction.RequestMethod.ToUpper()
    Assert-AreEqual $uri.ToUpper() $jobAction.Uri.ToUpper()

    if($body -eq $null -or $body -eq '')
    {
        Assert-Null $jobAction.RequestBody
    }
    else
    {
        Assert-AreEqual $body $jobAction.RequestBody
    }
    
    if($headers -eq $null -or $body -eq '')
    {
        Assert-Null $jobAction.RequestHeaders
    }
    else
    {
        Assert-NotNull $jobAction.RequestHeaders
    }

    if($httpAuthenticationType -eq $null -or $httpAuthenticationType -eq '')
    {
        Assert-Null $jobAction.HttpJobAuthentication
    }
    else
    {
        Assert-AreEqual $httpAuthenticationType.ToUpper() $jobAction.HttpJobAuthentication.HttpAuthType.ToUpper()
    }
}

<#
.SYNOPSIS
Validates storage queue functionality of a job.
#>
function Validate-StorageQueueJob(
    [string]$storageAccountName,
    [string]$storageQueueName,
    [string]$storageQueueMessage,
    [Microsoft.Azure.Commands.Scheduler.Models.PSHttpJobActionDetails]$jobAction)
{
    $jobActionType = "StorageQueue"
    Assert-AreEqual $jobActionType $jobAction.JobActionType.ToString()
    Assert-AreEqual $storageAccountName.ToUpper() $jobAction.StorageAccount.ToUpper()
    Assert-AreEqual $storageQueueName.ToUpper() $jobAction.StorageQueueName.ToUpper()
    Assert-AreEqual $storageQueueMessage.ToUpper() $jobAction.StorageQueueMessage.ToUpper()
}