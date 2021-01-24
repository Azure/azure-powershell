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
Creates a trigger and then does a Get to compare the results.
Deletes the created trigger at the end.
#>
function Test-Trigger
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $triggername = "foo"
        $expected = Set-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -File .\Resources\scheduletrigger.json -Force
        $actual = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername

        Verify-Trigger $expected $actual $rgname $dfname $triggername

        Remove-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a trigger and then does a Get to compare the results.
Starts and Stops trigger.
Then deletes the created trigger at the end.
#>
function Test-StartTriggerThrowsWithoutPipeline
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $triggername = "foo"
        $expected = Set-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -File .\Resources\scheduletrigger.json -Force
        $actual = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername

        Verify-Trigger $expected $actual $rgname $dfname $triggername

        Assert-ThrowsContains {Start-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force} "BadRequest"
        
        Remove-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a trigger and then does a Get to compare the results.
Starts and Stops trigger and checks that there is at least one Trigger Run
Deletes the created trigger at the end.
#>
function Test-TriggerRun
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $lsName = "foo1"
        Set-AzDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $lsName -Force

        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "dsIn" -File .\Resources\dataset-dsIn.json -Force
        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds0_0" -File .\Resources\dataset-ds0_0.json -Force
        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds1_0" -File .\Resources\dataset-ds1_0.json -Force

        $pipelineName = "samplePipeline"   
        Set-AzDataFactoryV2Pipeline -ResourceGroupName $rgname -Name $pipelineName -DataFactoryName $dfname -File ".\Resources\pipeline.json" -Force

        $triggername = "foo"
        $expected = Set-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -File .\Resources\scheduleTriggerWithPipeline.json -Force
        $actual = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername

        Verify-Trigger $expected $actual $rgname $dfname $triggername
        
        $startDate = [DateTime]::Parse("09/10/2017")
        Start-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $started = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Started' $started.RuntimeState 
        
        if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
            Start-Sleep -s 150
        }
        
        $endDate = $startDate.AddYears(1)
        $triggerRuns = Get-AzDataFactoryV2TriggerRun -ResourceGroupName $rgname -DataFactoryName $dfname -TriggerName $triggername -TriggerRunStartedAfter $startDate -TriggerRunStartedBefore $endDate
        
        if($triggerRuns.Count -lt 1)
        {
            throw "Expected atleast 1 trigger run"
        }
         
        Stop-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $stopped = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Stopped' $stopped.RuntimeState 

        Remove-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a trigger and then does a Get to compare the results.
Starts and Stops trigger and checks that there is at least one Trigger Run
Deletes the created trigger at the end.
#>
function Test-BlobEventTriggerSubscriptions
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $lsName = "foo1"
        Set-AzDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $lsName -Force

        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "dsIn" -File .\Resources\dataset-dsIn.json -Force
        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds0_0" -File .\Resources\dataset-ds0_0.json -Force
        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds1_0" -File .\Resources\dataset-ds1_0.json -Force

        $pipelineName = "samplePipeline"   
        Set-AzDataFactoryV2Pipeline -ResourceGroupName $rgname -Name $pipelineName -DataFactoryName $dfname -File ".\Resources\pipeline.json" -Force

        $triggername = "foo"
        $expected = Set-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -File .\Resources\blobeventtrigger.json -Force
        $actual = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername

        Verify-Trigger $expected $actual $rgname $dfname $triggername
        
        $startDate = [DateTime]::Parse("09/10/2017")
		Add-AzDataFactoryV2TriggerSubscription -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
		$status = Get-AzDataFactoryV2TriggerSubscriptionStatus -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
		while ($status.Status -ne "Enabled"){
			if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
				Start-Sleep -s 150
			}
			$status = Get-AzDataFactoryV2TriggerSubscriptionStatus -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
		}
        
        Start-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $started = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Started' $started.RuntimeState 
        
		Remove-AzDataFactoryV2TriggerSubscription -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force

        Stop-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $stopped = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Stopped' $stopped.RuntimeState 

        Remove-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a trigger and then does a Get to compare the results.
Starts and Stops trigger and checks that there is at least one Trigger Run
Deletes the created trigger at the end.
#>
function Test-BlobEventTriggerSubscriptionsByInputObject
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $lsName = "foo1"
        Set-AzDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $lsName -Force

        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "dsIn" -File .\Resources\dataset-dsIn.json -Force
        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds0_0" -File .\Resources\dataset-ds0_0.json -Force
        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds1_0" -File .\Resources\dataset-ds1_0.json -Force

        $pipelineName = "samplePipeline"   
        Set-AzDataFactoryV2Pipeline -ResourceGroupName $rgname -Name $pipelineName -DataFactoryName $dfname -File ".\Resources\pipeline.json" -Force

        $triggername = "foo"
        $expected = Set-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -File .\Resources\blobeventtrigger.json -Force
        $actual = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername

        Verify-Trigger $expected $actual $rgname $dfname $triggername
        
		Add-AzDataFactoryV2TriggerSubscription $actual
		$status = Get-AzDataFactoryV2TriggerSubscriptionStatus $actual
		while ($status.Status -ne "Enabled"){
			if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
				Start-Sleep -s 150
			}
			$status = Get-AzDataFactoryV2TriggerSubscriptionStatus $actual
		}
        
        Start-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $started = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Started' $started.RuntimeState 
        
		Remove-AzDataFactoryV2TriggerSubscription $started -Force

        Stop-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $stopped = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Stopped' $stopped.RuntimeState 

        Remove-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a trigger and then does a Get to compare the results.
Starts and Stops trigger and checks that there is at least one Trigger Run
Deletes the created trigger at the end.
#>
function Test-BlobEventTriggerSubscriptionsByResourceId
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $lsName = "foo1"
        Set-AzDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $lsName -Force

        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "dsIn" -File .\Resources\dataset-dsIn.json -Force
        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds0_0" -File .\Resources\dataset-ds0_0.json -Force
        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds1_0" -File .\Resources\dataset-ds1_0.json -Force

        $pipelineName = "samplePipeline"   
        Set-AzDataFactoryV2Pipeline -ResourceGroupName $rgname -Name $pipelineName -DataFactoryName $dfname -File ".\Resources\pipeline.json" -Force

        $triggername = "foo"
        $expected = Set-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -File .\Resources\blobeventtrigger.json -Force
        $actual = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername

        Verify-Trigger $expected $actual $rgname $dfname $triggername
        
		Add-AzDataFactoryV2TriggerSubscription -ResourceId $expected.Id
		$status = Get-AzDataFactoryV2TriggerSubscriptionStatus -ResourceId $expected.Id
		while ($status.Status -ne "Enabled"){
			if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
				Start-Sleep -s 150
			}
			$status = Get-AzDataFactoryV2TriggerSubscriptionStatus -ResourceId $expected.Id
		}
        
        Start-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $started = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Started' $started.RuntimeState 
        
		Remove-AzDataFactoryV2TriggerSubscription -ResourceId $expected.Id -Force

        Stop-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $stopped = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Stopped' $stopped.RuntimeState 

        Remove-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a TumblingWindow trigger and then does a Get to compare the results.
Starts and checks that there is at least one Trigger Run
Reruns the trigger run
Stops trigger
Deletes the created trigger at the end.
#>
function Test-TriggerInvokeAndStop
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
		Get-Command -Name '*AzDataFactoryV2Tr*' | Write-Debug
        Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force

        $pipelineName = "samplePipeline"   
        Set-AzDataFactoryV2Pipeline -ResourceGroupName $rgname -Name $pipelineName -DataFactoryName $dfname -File .\Resources\pipelineWait.json -Force

        $triggername = "foo"
        $expected = Set-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -File .\Resources\tumblingTriggerWithPipeline.json -Force
        $actual = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername

        Verify-Trigger $expected $actual $rgname $dfname $triggername

        $startDate = [DateTime]::Parse("09/10/2020")
        Start-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $started = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Started' $started.RuntimeState 
        
        if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
            Start-Sleep -s 150
        }
        
        $endDate = $startDate.AddYears(1)
        $triggerRuns = Get-AzDataFactoryV2TriggerRun -ResourceGroupName $rgname -DataFactoryName $dfname -TriggerName $triggername -TriggerRunStartedAfter $startDate -TriggerRunStartedBefore $endDate
        
        if($triggerRuns.Count -lt 1)
        {
            throw "Expected atleast 1 trigger run"
        }

		$triggerRunId = $triggerRuns[0].TriggerRunId
		Invoke-AzDataFactoryV2TriggerRun -ResourceGroupName $rgname -DataFactoryName $dfname -TriggerName $triggername -TriggerRunId $triggerRunId

		Assert-ThrowsContains { Stop-AzDataFactoryV2TriggerRun -ResourceGroupName $rgname -DataFactoryName $dfname -TriggerName $triggername -TriggerRunId $triggerRunId } "not in WaitingOnDependency state" 
         
        Stop-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $stopped = Get-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Stopped' $stopped.RuntimeState 

        Remove-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Creates a trigger and then does a Get with resource id to compare the results.
Deletes the created dataset with resource id at the end.
#>
function Test-TriggerWithResourceId
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $df = Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $triggername = "foo"
        $expected = Set-AzDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -File .\Resources\scheduletrigger.json -Force
        $actual = Get-AzDataFactoryV2Trigger -ResourceId $expected.Id

        Verify-Trigger $expected $actual $rgname $dfname $triggername

        Remove-AzDataFactoryV2Trigger -ResourceId $expected.Id -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}


<#
.SYNOPSIS
Verifies the properties of two PSTrigger objects
#>
function Verify-Trigger ($expected, $actual, $rgname, $dfname, $name)
{
    Verify-AdfSubResource $expected $actual $rgname $dfname $triggername
    Assert-AreEqual $expected.RuntimeState $actual.RuntimeState
}
