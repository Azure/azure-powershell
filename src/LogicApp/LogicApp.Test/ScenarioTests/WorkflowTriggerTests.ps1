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
Test Get-AzLogicAppTrigger for workflow triggers and test to get trigger by name
#>
function Test-GetAzLogicAppTrigger
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName

	$workflowName = getAssetname
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"
	$definitionFilePath = Join-Path "Resources" "TestSimpleWorkflowTriggerDefinition.json"
		
	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -Location $location

	$workflowTrigger = Get-AzLogicAppTrigger -ResourceGroupName $resourceGroupName -Name $workflowName
	Assert-NotNull $workflowTrigger

	$workflowTrigger = Get-AzLogicAppTrigger -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"
	Assert-NotNull $workflowTrigger
}

<#
.SYNOPSIS
Test Get-AzLogicAppTriggerHistory command to get workflow trigger histories and history by history name
#>
function Test-GetAzLogicAppTriggerHistory
{	
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName

	$workflowName = getAssetname
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"
	$definitionFilePath = Join-Path "Resources" "TestSimpleWorkflowTriggerDefinition.json"
		
	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -Location $location
	
	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"

	$workflowTriggerHistories = Get-AzLogicAppTriggerHistory -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"
	Assert-NotNull $workflowTriggerHistories
	$firstHistory = $workflowTriggerHistories[0]

	$workflowTriggerHistory = Get-AzLogicAppTriggerHistory -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger" -HistoryName  $firstHistory.Name
	Assert-NotNull $workflowTriggerHistory
}

<#
.SYNOPSIS
Test Get-AzLogicAppTriggerCallbackUrl command to get workflow trigger callback URL
#>
function Test-GetAzLogicAppTriggerCallbackUrl
{	
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName

	$workflowName = getAssetname
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"
	$definitionFilePath = Join-Path "Resources" "TestSimpleWorkflowTriggerDefinition.json"
		
	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -Location $location
	
	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	$callbackUrlString = Get-AzLogicAppTriggerCallbackUrl -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "manualTrigger"
	Assert-NotNull $callbackUrlString

	$curApiVersion = '*' + (CurrentApiVersion) + '*'
	Assert-True { $callbackUrlString.Value -like $curApiVersion }
}

<#
.SYNOPSIS
Test Start-AzLogicAppTrigger command to run workflow trigger
#>
function Test-StartAzLogicAppTrigger
{	
	$resourceGroup = TestSetup-CreateResourceGroup	
	$resourceGroupName = $resourceGroup.ResourceGroupName
	
	$workflowName = getAssetname
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"
	$definitionFilePath = Join-Path "Resources" "TestSimpleWorkflowTriggerDefinition.json"
		
	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -Location $location
	
	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"

	$workflowTriggerHistories = Get-AzLogicAppTriggerHistory -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"	
	
	Assert-AreEqual 1 $workflowTriggerHistories.Count 
}