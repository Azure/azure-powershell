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
        
    New-AzureResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $df = New-AzureDataFactory -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force
     
        New-AzureDataFactoryLinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Force

        New-AzureDataFactoryTable -ResourceGroupName $rgname -DataFactoryName $dfname -Name inputTable -File .\Resources\table.json -Force
        New-AzureDataFactoryTable -ResourceGroupName $rgname -DataFactoryName $dfname -Name outputTable -File .\Resources\table.json -Force
        
        $pipelineName = "samplePipeline"        
        #create pipeline will return a failed provisioning state because we are not really feed the json with valid credentials.
        #we can still continue the test with a Get operation though.
        Assert-Throws { New-AzureDataFactoryPipeline  -ResourceGroupName $rgname -Name $pipelineName -DataFactoryName $dfname -File ".\Resources\pipeline.json" -Force }
        $expectedPipeline = Get-AzureDataFactoryPipeline -ResourceGroupName $rgname -Name $pipelineName -DataFactoryName $dfname

        Assert-AreEqual $rgname $expectedPipeline.ResourceGroupName
        Assert-AreEqual $dfname $expectedPipeline.DataFactoryName
	    Assert-AreEqual $pipelineName $expectedPipeline.PipelineName
        Assert-AreEqual "Failed" $expectedPipeline.ProvisioningState
                
        #overwrite the pipeline again with -DataFactory parameter (provisioning will still fail as we are not using valid credentials)
        Assert-Throws { New-AzureDataFactoryPipeline -DataFactory $df -File ".\Resources\pipeline.json" -Force }
        $expectedPipeline = Get-AzureDataFactoryPipeline -DataFactory $df -Name $pipelineName

        Assert-AreEqual $rgname $expectedPipeline.ResourceGroupName
        Assert-AreEqual $dfname $expectedPipeline.DataFactoryName
	    Assert-AreEqual $pipelineName $expectedPipeline.PipelineName
        Assert-AreEqual "Failed" $expectedPipeline.ProvisioningState

        #remove the pipeline through piping
        Get-AzureDataFactoryPipeline -DataFactory $df -Name $pipelineName | Remove-AzureDataFactoryPipeline -Force

        #test the pipeline no longer exists
        Assert-ThrowsContains { Get-AzureDataFactoryPipeline -DataFactory $df -Name $pipelineName } "PipelineNotFound"
                
        #remove the pipeline again should not throw
        Remove-AzureDataFactoryPipeline -ResourceGroupName $rgname -DataFactoryName $dfname -Name $pipelineName -Force

        Remove-AzureDataFactoryPipeline -DataFactory $df -Name $pipelineName -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}