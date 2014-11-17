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
An E2E test to create and monitor a Wikipedia sample pipeline.
#>
function Test-WikipediaSamplePipeline
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement

    $endDate = [DateTime]::Parse("9/8/2014")
    $startDate = $endDate.AddHours(-1)
    $folder = ".\Resources\WikiSamplePipeline\"
        
    New-AzureResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        #create datafactory
        $df = New-AzureDataFactory -ResourceGroupName $rgname -Name $dfname -Location $dflocation

        #create linked services
        $lsCurated = New-AzureDataFactoryLinkedService  -ResourceGroupName $rgname -DataFactoryName $dfname -File $folder"LinkedService_CuratedWikiData.json"
	    $lsHDI = New-AzureDataFactoryLinkedService  -ResourceGroupName $rgname -Name HDILinkedService -DataFactoryName $dfname -File $folder"LinkedService_HDIBYOC.json"
	    $lsAggregated = New-AzureDataFactoryLinkedService  -ResourceGroupName $rgname -Name LinkedService-WikiAggregatedData -DataFactoryName $dfname -File $folder"LinkedService_WikiAggregatedData.json"
	    $lsClicked = New-AzureDataFactoryLinkedService  -ResourceGroupName $rgname -Name LinkedService-WikipediaClickEvents -DataFactoryName $dfname -File $folder"LinkedService_WikipediaClickEvents.json"
	
        #create tables
        $tbAggregated = New-AzureDataFactoryTable  -ResourceGroupName $rgname DA_WikiAggregatedData -DataFactoryName $dfname -File $folder"DA_WikiAggregatedData.json"
	    $tbClick = New-AzureDataFactoryTable  -ResourceGroupName $rgname -Name DA_WikipediaClickEvents -DataFactoryName $dfname -File $folder"DA_WikipediaClickEvents.json"
	    $tbCurated = New-AzureDataFactoryTable  -ResourceGroupName $rgname -Name DA_CuratedWikiData -DataFactoryName $dfname -File $folder"DA_CuratedWikiData.json"
	
        #create pipeline
        $actualPipeline = New-AzureDataFactoryPipeline  -ResourceGroupName $rgname -Name DP_WikipediaSamplePipeline -DataFactoryName $dfname -File $folder"DP_Wikisamplev2json.json" -Force
        $expectedPipeline = Get-AzureDataFactoryPipeline -ResourceGroupName $rgname -Name DP_WikipediaSamplePipeline -DataFactoryName $dfname

        Assert-AreEqual $actualPipeline.ResourceGroupName $expectedPipeline.ResourceGroupName
        Assert-AreEqual $actualPipeline.DataFactoryName $expectedPipeline.DataFactoryName
	    Assert-AreEqual $actualPipeline.PipelineName $expectedPipeline.PipelineName
        
        #set pipeline active period
        Set-AzureDataFactoryPipelineActivePeriod  -Name DP_WikipediaSamplePipeline -ResourceGroupName $rgname -DataFactoryName $dfname -StartDateTime $startDate -EndDateTime $endDate -Force
		
        $slices = Get-AzureDataFactorySlice -ResourceGroupName $rgname -DataFactoryName $dfname -TableName DA_WikiAggregatedData -StartDateTime $startDate -EndDateTime $endDate
        Assert-AreEqual $slices.Count 1

        #overwrite the pipeline again with -DataFactory parameter
        $actualPipeline = New-AzureDataFactoryPipeline -DataFactory $df -File $folder"DP_Wikisamplev2json.json" -Force
        $expectedPipeline = Get-AzureDataFactoryPipeline -DataFactory $df -Name DP_WikipediaSamplePipeline

        Assert-AreEqual $actualPipeline.ResourceGroupName $expectedPipeline.ResourceGroupName
        Assert-AreEqual $actualPipeline.DataFactoryName $expectedPipeline.DataFactoryName
	    Assert-AreEqual $actualPipeline.PipelineName $expectedPipeline.PipelineName

        #remove the pipeline
        Remove-AzureDataFactoryPipeline -ResourceGroupName $rgname -DataFactoryName $dfname -Name DP_WikipediaSamplePipeline -Force
        
        #remove the pipeline again should not throw
        Remove-AzureDataFactoryPipeline -DataFactory $df -Name DP_WikipediaSamplePipeline -Force
    }
    finally
    {
        Clean-DataFactory $rgname $dfname
    }
}