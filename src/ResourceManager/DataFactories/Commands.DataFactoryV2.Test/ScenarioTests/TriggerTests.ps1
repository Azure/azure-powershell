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
Create a trigger and then do a Get to compare the result are identical.
Delete the created trigger after test finishes.
#>
function Test-Trigger
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $triggername = "foo"
   
        $actual = Set-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -File .\Resources\scheduletrigger.json -Force
        $expected = Get-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername

        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.DataFactoryName $actual.DataFactoryName
        Assert-AreEqual $expected.Name $triggername
        Assert-AreEqual $expected.RuntimeState $actual.RuntimeState

        Remove-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}

<#
.SYNOPSIS
Create a trigger and then do a Get to compare the result are identical.
Start and Stop trigger
Delete the created trigger after test finishes.
#>
function Test-StartStopTrigger
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $triggername = "foo"
   
        $actual = Set-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -File .\Resources\scheduletrigger.json -Force
        $expected = Get-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername

        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.DataFactoryName $actual.DataFactoryName
        Assert-AreEqual $expected.Name $triggername
        Assert-AreEqual $expected.RuntimeState $actual.RuntimeState

        Start-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $started = Get-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual $started.RuntimeState 'Started'
        
        Stop-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $stopped = Get-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual $stopped.RuntimeState 'Stopped'

        Remove-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}

<#
.SYNOPSIS
Create a trigger and then do a Get to compare the result are identical.
Start and Stop trigger and check Trigger Run
Delete the created trigger after test finishes.
#>
function Test-TriggerRun
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        $triggername = "foo"
   
        $lsName = "foo1"
        Set-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $lsName -Force

        Set-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "dsIn" -File .\Resources\dataset-dsIn.json -Force
        Set-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds0_0" -File .\Resources\dataset-ds0_0.json -Force
        Set-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds1_0" -File .\Resources\dataset-ds1_0.json -Force

        $pipelineName = "samplePipeline"   
        Set-AzureRmDataFactoryV2Pipeline -ResourceGroupName $rgname -Name $pipelineName -DataFactoryName $dfname -File ".\Resources\pipeline.json" -Force

        $actual = Set-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -File .\Resources\scheduleTriggerWithPipeline.json -Force
        $expected = Get-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername

        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.DataFactoryName $actual.DataFactoryName
        Assert-AreEqual $expected.Name $actual.Name
        Assert-AreEqual $expected.RuntimeState $actual.RuntimeState
        
        $startDate = [DateTime]::Parse("09/10/2017")
        Start-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $started = Get-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Started' $started.RuntimeState 
        
        if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
            Start-Sleep -s 150
        }
        
        $endDate = $startDate.AddYears(1)
        $triggerRuns = Get-AzureRmDataFactoryV2TriggerRun -ResourceGroupName $rgname -DataFactoryName $dfname -TriggerName $triggername -TriggerRunStartedAfter $startDate -TriggerRunStartedBefore $endDate
        
        if($triggerRuns.Count -lt 1)
        {
            throw "Expected atleast 1 trigger run"
        }
         
        Stop-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
        $stopped = Get-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername
        
        Assert-AreEqual 'Stopped' $stopped.RuntimeState 

        Remove-AzureRmDataFactoryV2Trigger -ResourceGroupName $rgname -DataFactoryName $dfname -Name $triggername -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}