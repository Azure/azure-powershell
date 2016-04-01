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
Tests creating a Task
#>
function Test-CreateTask-using-td
{
    param([string]$accountName, [string]$jobId)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $taskId1 = "simple"
    $taskId2= "complex"
    $cmd = "cmd /c dir /s"

    # Create a simple task and verify pipeline
    Get-AzureBatchJob -Id $jobId -BatchContext $context | New-AzureBatchTask -Id $taskId1 -CommandLine $cmd -BatchContext $context
    $task1 = Get-AzureBatchTask -JobId $jobId -Id $taskId1 -BatchContext $context

    # Verify created task matches expectations
    Assert-AreEqual $taskId1 $task1.Id
    Assert-AreEqual $cmd $task1.CommandLine

    # Create a complicated task
	$affinityId = "affinityId"
    $affinityInfo = New-Object Microsoft.Azure.Commands.Batch.Models.PSAffinityInformation -ArgumentList @($affinityId)

    $taskConstraints = New-Object Microsoft.Azure.Commands.Batch.Models.PSTaskConstraints -ArgumentList @([TimeSpan]::FromDays(1),[TimeSpan]::FromDays(2),5)
    $maxWallClockTime = $taskConstraints.MaxWallClockTime
    $retentionTime = $taskConstraints.RetentionTime
    $maxRetryCount = $taskConstraints.MaxRetryCount

    $resourceFiles = @{"file1"="https://testacct.blob.core.windows.net/"}

    $envSettings = @{"env1"="value1";"env2"="value2"}

    $numInstances = 3
    $multiInstanceSettings = New-Object Microsoft.Azure.Commands.Batch.Models.PSMultiInstanceSettings -ArgumentList @($numInstances)
    $multiInstanceSettings.CoordinationCommandLine = $coordinationCommandLine = "cmd /c echo coordinating"
    $multiInstanceSettings.CommonResourceFiles = New-Object System.Collections.Generic.List``1[Microsoft.Azure.Commands.Batch.Models.PSResourceFile]
    $commonResourceBlob = "https://common.blob.core.windows.net/"
    $commonResourceFile = "common.exe"
    $commonResource = New-Object Microsoft.Azure.Commands.Batch.Models.PSResourceFile -ArgumentList @($commonResourceBlob,$commonResourceFile)
    $multiInstanceSettings.CommonResourceFiles.Add($commonResource)

    New-AzureBatchTask -JobId $jobId -Id $taskId2 -CommandLine $cmd -EnvironmentSettings $envSettings -ResourceFiles $resourceFiles -AffinityInformation $affinityInfo -Constraints $taskConstraints -MultiInstanceSettings $multiInstanceSettings -BatchContext $context

    $task2 = Get-AzureBatchTask -JobId $jobId -Id $taskId2 -BatchContext $context

    # Verify created task matches expectations
    Assert-AreEqual $taskId2 $task2.Id
    Assert-AreEqual $cmd $task2.CommandLine
    Assert-AreEqual $false $task2.RunElevated
    Assert-AreEqual $affinityId $task2.AffinityInformation.AffinityId
    Assert-AreEqual $maxWallClockTime $task2.Constraints.MaxWallClockTime
    Assert-AreEqual $retentionTime $task2.Constraints.RetentionTime
    Assert-AreEqual $maxRetryCount $task2.Constraints.MaxRetryCount
    Assert-AreEqual $resourceFiles.Count $task2.ResourceFiles.Count
    foreach($r in $task2.ResourceFiles)
    {
        Assert-AreEqual $resourceFiles[$r.FilePath] $r.BlobSource
    }
    Assert-AreEqual $envSettings.Count $task2.EnvironmentSettings.Count
    foreach($e in $task2.EnvironmentSettings)
    {
        Assert-AreEqual $envSettings[$e.Name] $e.Value
    }
    Assert-AreEqual $numInstances $task2.MultiInstanceSettings.NumberOfInstances
    Assert-AreEqual $coordinationCommandLine $task2.MultiInstanceSettings.CoordinationCommandLine
    Assert-AreEqual 1 $task2.MultiInstanceSettings.CommonResourceFiles.Count
    Assert-AreEqual $commonResourceBlob $task2.MultiInstanceSettings.CommonResourceFiles[0].BlobSource
    Assert-AreEqual $commonResourceFile $task2.MultiInstanceSettings.CommonResourceFiles[0].FilePath
}