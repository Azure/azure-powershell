﻿

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
Create a sample pipeline with all of its dependencies. Then test overwrite the pipeline and then
delete the pipeline with piping.
#>
function Test-Pipeline
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement

    $endDate = [DateTime]::Parse("9/8/2014")
    $startDate = $endDate.AddHours(-1)
        
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
        $expectedPipeline = Get-AzureRmDataFactoryV2Pipeline -ResourceGroupName $rgname -Name $pipelineName -DataFactoryName $dfname

        Assert-AreEqual $rgname $expectedPipeline.ResourceGroupName
        Assert-AreEqual $dfname $expectedPipeline.DataFactoryName
        Assert-AreEqual $pipelineName $expectedPipeline.Name
                
        #remove the pipeline through piping
        Get-AzureRmDataFactoryV2Pipeline -DataFactory $df -Name $pipelineName | Remove-AzureRmDataFactoryV2Pipeline -Force

        #test the pipeline no longer exists
        Assert-ThrowsContains { Get-AzureRmDataFactoryV2Pipeline -DataFactory $df -Name $pipelineName } "NotFound" 
                
        #remove the pipeline again should not throw
        Remove-AzureRmDataFactoryV2Pipeline -ResourceGroupName $rgname -DataFactoryName $dfname -Name $pipelineName -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}