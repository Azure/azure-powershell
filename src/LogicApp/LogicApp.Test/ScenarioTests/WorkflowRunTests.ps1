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
Test Start and Stop AzLogicApp command for logic app workflow.
#>
function Test-StartLogicApp
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$workflowName = getAssetname
	$definitionFilePath = Join-Path "Resources" "TestSimpleWorkflowTriggerDefinition.json"

	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath
	
	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"
}

<#
.SYNOPSIS
Test Get-AzLogicAppRunHistory and Get-AzLogicAppRun command to get the logic app history
#>
function Test-GetAzLogicAppRunHistory
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$workflowName = getAssetname
	$definitionFilePath = Join-Path "Resources" "TestSimpleWorkflowTriggerDefinition.json"

	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath
	
	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"

	$runHistory = Get-AzLogicAppRunHistory -ResourceGroupName $resourceGroupName -Name $workflowName 
	Assert-NotNull $runHistory
	$run = Get-AzLogicAppRunHistory -ResourceGroupName $resourceGroupName -Name $workflowName -RunName $runHistory[0].Name	
	Assert-NotNull $run
	Assert-AreEqual $runHistory[0].Name $run.Name
}

<#
.SYNOPSIS
Test Get-AzLogicAppRunAction command to get the logic app run action
#>
function Test-GetAzLogicAppRunAction
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$workflowName = getAssetname
	$definitionFilePath = Join-Path $TestOutputRoot "Resources\TestSimpleWorkflowTriggerDefinition.json"

	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath

	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"

	$runHistory = Get-AzLogicAppRunHistory -ResourceGroupName $resourceGroupName -Name $workflowName 
	Assert-NotNull $runHistory
	
	$actions = Get-AzLogicAppRunAction -ResourceGroupName $resourceGroupName -Name $workflowName -RunName $runHistory[0].Name
	Assert-NotNull $actions
	Assert-AreEqual 2 $actions.Count

	$action = Get-AzLogicAppRunAction -ResourceGroupName $resourceGroupName -Name $workflowName -RunName $runHistory[0].Name -ActionName "http"
	Assert-NotNull $action
}

<#
.SYNOPSIS
Test Start and Stop AzLogicApp command for logic app workflow.
#>
function Test-StopAzLogicAppRun
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$workflowName = getAssetname
	$definitionFilePath = Join-Path "Resources" "TestSimpleWorkflowTriggerDefinitionWithDelayAction.json"

	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath
	
	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"

	$runHistory = Get-AzLogicAppRunHistory -ResourceGroupName $resourceGroupName -Name $workflowName

	Stop-AzLogicAppRun -ResourceGroupName $resourceGroupName -Name $workflowName -RunName $runHistory[0].Name -Force
}