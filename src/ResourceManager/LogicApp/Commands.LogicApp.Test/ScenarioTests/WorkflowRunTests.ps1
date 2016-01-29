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
Test Start and Stop AzureLogicApp command for logic app workflow.
#>
function Test-StartLogicApp
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$planName = "StandardServicePlan"
	$Plan = TestSetup-CreateAppServicePlan $resourceGroup.ResourceGroupName $planName

	$workflowName = getAssetname		
	$definitionFilePath = "Resources\TestSimpleWorkflowTriggerDefinition.json"			
		
	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -AppServicePlan $planName
	
	[int]$counter = 0
	do {
		Sleep -seconds 2        
		$workflow =  Get-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"
}

<#
.SYNOPSIS
Test Get-AzureLogicAppRunHistory and Get-AzureLogicAppRun command to get the logic app history
#>
function Test-GetAzureLogicAppRunHistory
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$planName = "StandardServicePlan"
	$Plan = TestSetup-CreateAppServicePlan $resourceGroup.ResourceGroupName $planName

	$workflowName = getAssetname		
	$definitionFilePath = "Resources\TestSimpleWorkflowTriggerDefinition.json"			
		
	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -AppServicePlan $planName
	
	[int]$counter = 0
	do {
		Sleep -seconds 2        
		$workflow =  Get-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"

	$runHistory = Get-AzureLogicAppRunHistory -ResourceGroupName $resourceGroupName -Name $workflowName 
	Assert-NotNull $runHistory
	$run = Get-AzureLogicAppRunHistory -ResourceGroupName $resourceGroupName -Name $workflowName -RunName $runHistory[0].Name	
	Assert-NotNull $run
	Assert-AreEqual $runHistory[0].Name $run.Name
}

<#
.SYNOPSIS
Test Get-AzureLogicAppRunAction command to get the logic app run action
#>
function Test-GetAzureLogicAppRunAction
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$planName = "StandardServicePlan"
	$Plan = TestSetup-CreateAppServicePlan $resourceGroup.ResourceGroupName $planName

	$workflowName = getAssetname		
	$definitionFilePath = "Resources\TestSimpleWorkflowTriggerDefinition.json"			
		
	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -AppServicePlan $planName
	
	[int]$counter = 0
	do {
		Sleep -seconds 2        
		$workflow =  Get-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"

	$runHistory = Get-AzureLogicAppRunHistory -ResourceGroupName $resourceGroupName -Name $workflowName 
	Assert-NotNull $runHistory
	
	$actions = Get-AzureLogicAppRunAction -ResourceGroupName $resourceGroupName -Name $workflowName -RunName $runHistory[0].Name
	Assert-NotNull $actions
	Assert-AreEqual 2 $actions.Count

	$action = Get-AzureLogicAppRunAction -ResourceGroupName $resourceGroupName -Name $workflowName -RunName $runHistory[0].Name -ActionName "http"
	Assert-NotNull $action

}