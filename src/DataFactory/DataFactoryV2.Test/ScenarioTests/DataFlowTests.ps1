

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
Creates a sample data flow with all of its dependencies. Then deletes the data flow with piping.
#>
function Test-DataFlow
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $df = Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force

        $lsName = "foo1"
        Set-AzDataFactoryV2LinkedService -ResourceGroupName $rgname -DataFactoryName $dfname -File .\Resources\linkedService.json -Name $lsName -Force

        Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "DelimitedTextInput" -File .\Resources\dataset-dsIn.json -Force
		Set-AzDataFactoryV2Dataset -ResourceGroupName $rgname -DataFactoryName $dfname -Name "DelimitedTextOutput" -File .\Resources\dataset-dsIn.json -Force

        $dataFlowName = "sample"   
        $expected = Set-AzDataFactoryV2DataFlow -ResourceGroupName $rgname -Name $dataFlowName -DataFactoryName $dfname -File ".\Resources\dataFlow.json" -Force
        $actual = Get-AzDataFactoryV2DataFlow -ResourceGroupName $rgname -Name $dataFlowName -DataFactoryName $dfname

        Verify-AdfSubResource $expected $actual $rgname $dfname $dataFlowName
                
        #remove the pipeline through piping
        Get-AzDataFactoryV2DataFlow -DataFactory $df -Name $dataFlowName | Remove-AzDataFactoryV2DataFlow -Force

        #test the pipeline no longer exists
        Assert-ThrowsContains { Get-AzDataFactoryV2DataFlow -DataFactory $df -Name $dataFlowName } "NotFound" 
                
        #remove the pipeline again should not throw
        Remove-AzDataFactoryV2DataFlow -ResourceGroupName $rgname -DataFactoryName $dfname -Name $dataFlowName -Force
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}