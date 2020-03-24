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
Create a sample pipeline and a sample run with all of its dependencies then test with monitoring commands.
#>
function Test-Run
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement

    $endDate = [DateTime]::Parse("04/08/2017")
    $startDate = $endDate.AddDays(-10)
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $df = Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
        
        $lsName = "foo1"
        Set-AzDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $lsName -Force

        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "dsIn" -File .\Resources\dataset-dsIn.json -Force
        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds0_0" -File .\Resources\dataset-ds0_0.json -Force
        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds1_0" -File .\Resources\dataset-ds1_0.json -Force

        $pipelineName = "samplePipeline"   
        Set-AzDataFactoryV2Pipeline -ResourceGroupName $rgname -Name $pipelineName -DataFactoryName $dfname -File ".\Resources\pipeline.json" -Force

        $Run = Invoke-AzDataFactoryV2Pipeline -ResourceGroupName $rgname -PipelineName $pipelineName -DataFactoryName $dfname -Parameter @{"OutputBlobName"="test";}
        Assert-True { Stop-AzDataFactoryV2PipelineRun -ResourceGroupName $rgname -PipelineRunId $Run -DataFactoryName $dfname -PassThru}

        # Trying get activity run.
        Get-AzDataFactoryV2ActivityRun -ResourceGroupName $rgname -DataFactoryName $dfname -PipelineRunId $Run -RunStartedBefore $endDate -RunStartedAfter $startDate
        Get-AzDataFactoryV2ActivityRun -DataFactory $df -PipelineRunId $Run -RunStartedBefore $endDate -RunStartedAfter $startDate

        # Trying get pipeline run.
        Get-AzDataFactoryV2PipelineRun -ResourceGroupName $rgname -DataFactoryName $dfname -PipelineRunId $Run
        Get-AzDataFactoryV2PipelineRun -DataFactory $df -PipelineRunId $Run

		# Wait run to finish before rerun
		if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
            Start-Sleep -s 120
        }

		# Trying rerun the pipeline run
		$Rerun = Invoke-AzDataFactoryV2Pipeline -ResourceGroupName $rgname -PipelineName $pipelineName -DataFactoryName $dfname -ReferencePipelineRunId $Run -IsRecovery
		Get-AzDataFactoryV2PipelineRun -DataFactory $df -PipelineRunId $Rerun

		# Wait run to finish before rerun
		if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
            Start-Sleep -s 120
        }

		# Trying rerun from activity MyCopyActivity_1_0
		$RerunFromActivity = Invoke-AzDataFactoryV2Pipeline -ResourceGroupName $rgname -PipelineName $pipelineName -DataFactoryName $dfname -ReferencePipelineRunId $Run -IsRecovery -StartActivityName MyCopyActivity_1_0
		Get-AzDataFactoryV2PipelineRun -DataFactory $df -PipelineRunId $RerunFromActivity

		# Wait run to finish before rerun
		if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
            Start-Sleep -s 120
        }

		# Trying rerun from failed activity
		$RerunFromFailedActivity = Invoke-AzDataFactoryV2Pipeline -ResourceGroupName $rgname -PipelineName $pipelineName -DataFactoryName $dfname -ReferencePipelineRunId $Run -IsRecovery -StartFromFailure
		Get-AzDataFactoryV2PipelineRun -DataFactory $df -PipelineRunId $RerunFromActivity
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}

<#
.SYNOPSIS
Negative test for cancel pipeline run
#>
function Test-CancelRunNegative
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement

    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
        
        $Run = "someGuid"
        Assert-ThrowsContains { Stop-AzDataFactoryV2PipelineRun -ResourceGroupName $rgname -DataFactoryName $dfname -PipelineRunId $Run } "ReferencedPipelineRunNotFound" 
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}
