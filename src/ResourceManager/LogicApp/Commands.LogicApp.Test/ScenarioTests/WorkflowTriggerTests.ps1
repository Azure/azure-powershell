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
Test Get-AzureRmLogicAppTrigger for workflow triggers and test to get trigger by name
#>
function Test-GetAzureLogicAppTrigger
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$planName = "StandardServicePlan"
	$Plan = TestSetup-CreateAppServicePlan $resourceGroup.ResourceGroupName $planName

	$workflowName = getAssetname	
	$definitionFilePath = "Resources\TestSimpleWorkflowTriggerDefinition.json"
		
	$workflow = New-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -AppServicePlan $planName

	$workflowTrigger = Get-AzureRmLogicAppTrigger -ResourceGroupName $resourceGroupName -Name $workflowName		    
	Assert-NotNull $workflowTrigger	

	$workflowTrigger = Get-AzureRmLogicAppTrigger -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger" 	    
	Assert-NotNull $workflowTrigger
}

<#
.SYNOPSIS
Test Get-AzureRmLogicAppTriggerHistory command to get workflow trigger histories and history by history name
#>
function Test-GetAzureLogicAppTriggerHistory
{	
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$planName = "StandardServicePlan"
	$Plan = TestSetup-CreateAppServicePlan $resourceGroup.ResourceGroupName $planName

	$workflowName = getAssetname		
	$definitionFilePath = "Resources\TestSimpleWorkflowTriggerDefinition.json"			
		
	$workflow = New-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -AppServicePlan $planName
	
	[int]$counter = 0
	do {
		Sleep -seconds 2        
		$workflow =  Get-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -or $counter++ -lt 5)
	
	Start-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"

	$workflowTriggerHistories = Get-AzureRmLogicAppTriggerHistory -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"
	Assert-NotNull $workflowTriggerHistories	
	$firstHistory = $workflowTriggerHistories[0]

	$workflowTriggerHistory = Get-AzureRmLogicAppTriggerHistory -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger" -HistoryName  $firstHistory.Name
	Assert-NotNull $workflowTriggerHistory	
}

<#
.SYNOPSIS
Test Start-AzureRmLogicAppTrigger command to run workflow trigger
#>
function Test-StartAzureLogicAppTrigger
{	
	$resourceGroup = TestSetup-CreateResourceGroup	
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$planName = "StandardServicePlan"
	$Plan = TestSetup-CreateAppServicePlan $resourceGroup.ResourceGroupName $planName
	
	$workflowName = getAssetname	
	$definitionFilePath = "Resources\TestSimpleWorkflowTriggerDefinition.json"			
		
	$workflow = New-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -AppServicePlan $planName
	
	[int]$counter = 0
	do {
		Sleep -seconds 2        
		$workflow =  Get-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -or $counter++ -lt 5)
	
	$workflowTriggerHistories1 = Get-AzureRmLogicAppTriggerHistory -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"
	$counter = 2
	while($val -lt $counter)
	{
		Start-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"
		Sleep -seconds 1
		$val++	
	}

	$workflowTriggerHistories2 = Get-AzureRmLogicAppTriggerHistory -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"	
	$count = $workflowTriggerHistories2.Count - $workflowTriggerHistories1.Count
	Assert-AreEqual $counter $count 
}