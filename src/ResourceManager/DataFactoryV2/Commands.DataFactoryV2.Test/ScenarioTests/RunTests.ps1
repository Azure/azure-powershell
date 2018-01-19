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
        
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $df = Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
        
        $lsName = "foo1"
        Set-AzureRmDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $lsName -Force

        Set-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "dsIn" -File .\Resources\dataset-dsIn.json -Force
        Set-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds0_0" -File .\Resources\dataset-ds0_0.json -Force
        Set-AzureRmDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "ds1_0" -File .\Resources\dataset-ds1_0.json -Force

        $pipelineName = "samplePipeline"   
        Set-AzureRmDataFactoryV2Pipeline -ResourceGroupName $rgname -Name $pipelineName -DataFactoryName $dfname -File ".\Resources\pipeline.json" -Force

        $Run = Invoke-AzureRmDataFactoryV2Pipeline -ResourceGroupName $rgname -PipelineName $pipelineName -DataFactoryName $dfname -Parameter @{"OutputBlobName"="test";}
        Assert-True { Stop-AzureRmDataFactoryV2PipelineRun -ResourceGroupName $rgname -PipelineRunId $Run -DataFactoryName $dfname -PassThru}

        # Trying get activity run.
        Get-AzureRmDataFactoryV2ActivityRun -ResourceGroupName $rgname -DataFactoryName $dfname -PipelineRunId $Run -RunStartedBefore $endDate -RunStartedAfter $startDate
        Get-AzureRmDataFactoryV2ActivityRun -DataFactory $df -PipelineRunId $Run -RunStartedBefore $endDate -RunStartedAfter $startDate

        # Trying get pipeline run.
        Get-AzureRmDataFactoryV2PipelineRun -ResourceGroupName $rgname -DataFactoryName $dfname -PipelineRunId $Run
        Get-AzureRmDataFactoryV2PipelineRun -DataFactory $df -PipelineRunId $Run
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

    New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        Set-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
        
        $Run = "someGuid"
        Assert-ThrowsContains { Stop-AzureRmDataFactoryV2PipelineRun -ResourceGroupName $rgname -DataFactoryName $dfname -PipelineRunId $Run } "Pipeline run does not exist" 
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}
