

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
E2E scenario for data flow debug workflow.
#>
function Test-DataFlowDebugScenario
{
    $dfname = Get-DataFactoryName
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $dflocation = Get-ProviderLocation DataFactoryManagement
        
    New-AzResourceGroup -Name $rgname -Location $rglocation -Force

    try
    {
        $df = Set-AzDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Location $dflocation -Force

		# Start one debug session
        $session = Start-AzDataFactoryV2DataFlowDebugSession -DataFactory $df

		# Get all debug sessions and check the count
		$list = Get-AzDataFactoryV2DataFlowDebugSession -DataFactory $df
		Assert-AreEqual 1 $list.Count

		# Add data flow debug package
		Add-AzDataFactoryV2DataFlowDebugSessionPackage -DataFactory $df -PackageFile .\Resources\dataFlowDebugPackage.json -SessionId $session.SessionId

		# Execute debug command 
        $result = Invoke-AzDataFactoryV2DataFlowDebugSessionCommand -DataFactory $df -Command executePreviewQuery -SessionId $session.SessionId -StreamName source1 -RowLimit 100
		Assert-AreEqual 'Succeeded' $result.Status
		Assert-NotNull $result.Data

        # Remove session eventually
		Stop-AzDataFactoryV2DataFlowDebugSession -DataFactory $df -SessionId $session.SessionId -Force
	    $newList = Get-AzDataFactoryV2DataFlowDebugSession -DataFactory $df
		Assert-AreEqual 0 $newList.Count
    }
    finally
    {
        CleanUp $rgname $dfname
    }
}