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

$WORKFLOW_LOCATION = 'westus'

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
		
	$workflow = New-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location $WORKFLOW_LOCATION -DefinitionFilePath $definitionFilePath
	
	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"
}

<#
.SYNOPSIS
Test Get-AzureRmLogicAppRunHistory and Get-AzureRmLogicAppRun command to get the logic app history
#>
function Test-GetAzureLogicAppRunHistory
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$planName = "StandardServicePlan"
	$Plan = TestSetup-CreateAppServicePlan $resourceGroup.ResourceGroupName $planName

	$workflowName = getAssetname		
	$definitionFilePath = "Resources\TestSimpleWorkflowTriggerDefinition.json"			
		
	$workflow = New-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location $WORKFLOW_LOCATION -DefinitionFilePath $definitionFilePath
	
	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"

	$runHistory = Get-AzureRmLogicAppRunHistory -ResourceGroupName $resourceGroupName -Name $workflowName 
	Assert-NotNull $runHistory
	$run = Get-AzureRmLogicAppRunHistory -ResourceGroupName $resourceGroupName -Name $workflowName -RunName $runHistory[0].Name	
	Assert-NotNull $run
	Assert-AreEqual $runHistory[0].Name $run.Name
}

<#
.SYNOPSIS
Test Get-AzureRmLogicAppRunAction command to get the logic app run action
#>
function Test-GetAzureLogicAppRunAction
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$planName = "StandardServicePlan"
	$Plan = TestSetup-CreateAppServicePlan $resourceGroup.ResourceGroupName $planName

	$workflowName = getAssetname	
	$definitionFilePath = [System.IO.Path]::Combine($TestOutputRoot, "Resources\TestSimpleWorkflowTriggerDefinition.json")		
		
	$workflow = New-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location $WORKFLOW_LOCATION -DefinitionFilePath $definitionFilePath

	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"

	$runHistory = Get-AzureRmLogicAppRunHistory -ResourceGroupName $resourceGroupName -Name $workflowName 
	Assert-NotNull $runHistory
	
	$actions = Get-AzureRmLogicAppRunAction -ResourceGroupName $resourceGroupName -Name $workflowName -RunName $runHistory[0].Name
	Assert-NotNull $actions
	Assert-AreEqual 2 $actions.Count

	$action = Get-AzureRmLogicAppRunAction -ResourceGroupName $resourceGroupName -Name $workflowName -RunName $runHistory[0].Name -ActionName "http"
	Assert-NotNull $action
}

<#
.SYNOPSIS
Test Start and Stop AzureLogicApp command for logic app workflow.
#>
function Test-StopAzureRmLogicAppRun
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$planName = "StandardServicePlan"
	$Plan = TestSetup-CreateAppServicePlan $resourceGroup.ResourceGroupName $planName

	$workflowName = getAssetname		
	$definitionFilePath = "Resources\TestSimpleWorkflowTriggerDefinitionWithDelayAction.json"			
		
	$workflow = New-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location $WORKFLOW_LOCATION -DefinitionFilePath $definitionFilePath
	
	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Start-AzureRmLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -TriggerName "httpTrigger"
		
	$runHistory = Get-AzureRmLogicAppRunHistory -ResourceGroupName $resourceGroupName -Name $workflowName

	Stop-AzureRmLogicAppRun -ResourceGroupName $resourceGroupName -Name $workflowName -RunName $runHistory[0].Name -Force

}