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
Test New-AzLogicApp with physical file paths
Test New-AzLogicApp using definition object and parameter file
Test New-AzLogicApp using piped input
#>
function Test-CreateAndRemoveLogicApp
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$definitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowDefinition.json"
	$parameterFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowParameter.json"

	#Case1 : Using physical file
	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath
	
	Assert-NotNull $workflow
	Assert-NotNull $workflow.Definition
	Assert-NotNull $workflow.Parameters
	Assert-AreEqual $workflowName $workflow.Name 
	Remove-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $WorkflowName -Force

	#Case2 : Using definition object and parameter file
	$parameterFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowParameter.json"
    $definition = [IO.File]::ReadAllText((Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowDefinition.json"))

	$workflowName = getAssetname
	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Definition $definition -ParameterFilePath $parameterFilePath -Location $location

	Assert-NotNull $workflow
	Assert-NotNull $workflow.Definition
	Assert-NotNull $workflow.Parameters
	Assert-AreEqual $workflowName $workflow.Name 
	Remove-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $WorkflowName -Force

	#Case3 : Create using Piped input
	$workflowName = getAssetname
	$workflow = $resourceGroup | New-AzLogicApp -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath

	Assert-NotNull $workflow
	Remove-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $WorkflowName -Force
}

<#
.SYNOPSIS
Test New-AzLogicApp to create a workflow with a duplicate name.
#>
function Test-CreateLogicAppWithDuplicateName
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$definitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowDefinition.json"
	$parameterFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowParameter.json"
	$resourceGroupName = $resourceGroup.ResourceGroupName

	$workflow = $resourceGroup | New-AzLogicApp -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath

	Assert-NotNull $workflow
	try
	{
		$workflow = $resourceGroup | New-AzLogicApp -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath
	}
	catch
	{
		Assert-AreEqual $_.Exception.Message "The Resource '$WorkflowName' under resource group '$resourceGroupName' already exists."
	}
	
	Remove-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $WorkflowName -Force
}

<#
.SYNOPSIS
Test New-AzLogicApp with workflow object
#>
function Test-CreateLogicAppUsingInputfromWorkflowObject
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname
	$newWorkflowName = getAssetname
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$definitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowDefinition.json"
	$parameterFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowParameter.json"

	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath 
	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $newWorkflowName -Location $location -Definition $workflow.Definition -Parameters $workflow.Parameters

	Assert-NotNull $workflow
	Assert-NotNull $workflow.Definition
	Assert-NotNull $workflow.Parameters
	Assert-AreEqual $newWorkflowName $workflow.Name 
	Assert-AreEqual "Enabled" $workflow.State

	Remove-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Force
}

<#
.SYNOPSIS
Test New-AzLogicApp with Parameter as hash table
#>
function Test-CreateLogicAppUsingInputParameterAsHashTable
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$definitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowDefinition.json"	
	$parameters = @{destinationUri="http://www.bing.com"}

	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -Parameters $parameters -Location $location

	Assert-NotNull $workflow
	Assert-NotNull $workflow.Parameters

	Remove-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $WorkflowName -Force	
}

<#
.SYNOPSIS
Test New-AzLogicApp with only definition
#>
function Test-CreateLogicAppUsingDefinitionWithTriggers
{		
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$definitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowTriggerDefinition.json"
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -Location $location

	Assert-NotNull $workflow
	
	[int]$counter = 0
	do {
		SleepInRecordMode 2000
		$workflow =  Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	} while ($workflow.State -ne "Enabled" -and $counter++ -lt 5)
	
	Remove-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Force
}

<#
.SYNOPSIS
Test New-AzLogicApp with only definition
Test Get-AzLogicApp
Test Get-AzLogicApp for a given version
Test Get-AzLogicApp for a non-existing logic app
#>
function Test-CreateAndGetLogicAppUsingDefinitionWithActions
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$definitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowActionDefinition.json"
	
	# Test 1: Create logic app without parameters
	$workflow1 = New-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -Location $location
	Assert-NotNull $workflow1

	# Test 2: Get logic app using get cmdlet
	$workflow2 = Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName
	Assert-NotNull $workflow2

	# Test 3: Get logic app using get cmdlet for a specific version
	$workflow3 = Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Version $workflow1.Version
	Assert-NotNull $workflow3

	# Test 4: Get all workflows in ResourceGroup
	$workflow4 = Get-AzLogicApp -ResourceGroupName $resourceGroupName
	Assert-NotNull $workflow4
	Assert-True { $workflow4.Length -ge 1 }

	# Test 5: Get all workflows in Subscription
	$workflow5 = Get-AzLogicApp
	Assert-NotNull $workflow5
	Assert-True { $workflow5.Length -ge 1 }

	# Test 6: Get workflow with just name parameter
	$workflow6 = Get-AzLogicApp -Name $workflowName
	Assert-NotNull $workflow6
	Assert-True { $workflow6.Length -ge 1 }

	# Test 7: Get non-existing logic app using get cmdlet
	try
	{
		Get-AzLogicApp -ResourceGroupName $resourceGroupName -Name "InvalidWorkflow"
	}
	catch
	{
		Assert-AreEqual $_.Exception.Message "The Resource 'Microsoft.Logic/workflows/InvalidWorkflow' under resource group '$resourceGroupName' was not found."
	} 

	Remove-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Force
}

<#
.SYNOPSIS
Test Remove-AzLogicApp command to remove nonexisting workflow by name.
#>
function Test-RemoveNonExistingLogicApp
{
	$WorkflowName = "09e81ac4-848a-428d-82a6-7d61953e3940"
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName

	Remove-AzLogicApp -ResourceGroupName $resourceGroupName -Name $WorkflowName -Force
}

<#
.SYNOPSIS
Test Set-AzLogicApp command to update workflow definition without parameters.
Test Set-AzLogicApp command to update workflow definition and state to Disabled.
Test Set-AzLogicApp command to update workflow state to Enabled.
Test Set-AzLogicApp command to set logic app with null definition.
Test Set-AzLogicApp command to set non-existing logic app.
#>
function Test-UpdateLogicApp
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$simpleDefinitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowDefinition.json"
	$simpleParameterFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowParameter.json"
	$workflow = $resourceGroup | New-AzLogicApp -Name $workflowName -Location $location -DefinitionFilePath $simpleDefinitionFilePath -ParameterFilePath $simpleParameterFilePath

	Assert-NotNull $workflow

	#Case1: Update definition with no parameters and disable
	$definitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowTriggerDefinition.json"

	$UpdatedWorkflow = Set-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -State "Disabled" -DefinitionFilePath $definitionFilePath -Parameters $null -Force
	
	Assert-NotNull $UpdatedWorkflow
	Assert-AreEqual $UpdatedWorkflow.State "Disabled"

	#Case2: Update definition with parameters of logic app
	$UpdatedWorkflow = Set-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $simpleDefinitionFilePath -ParameterFilePath $simpleParameterFilePath -Force

	Assert-NotNull $UpdatedWorkflow

	#Case3: Enable the logic app
	$UpdatedWorkflow = Set-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -State "Enabled" -Force
	
	Assert-NotNull $UpdatedWorkflow
	Assert-AreEqual $UpdatedWorkflow.State "Enabled"

	#Case4: Test update command to set logic app with null definition
	try
	{
		$UpdatedWorkflow = Set-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Definition $null -Force
	}
	catch
	{
		Assert-AreEqual $_.Exception.Message "Definition content needs to be specified."
	}

	#Case5: Update non-existing workflow
	try
	{
		$workflowName = "82D2D842-C312-445C-8A4D-E3EE9542436D"
		$definitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowTriggerDefinition.json"
		Set-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $definitionFilePath -Force
	}
	catch
	{
		Assert-AreEqual $_.Exception.Message "The Resource 'Microsoft.Logic/workflows/$workflowName' under resource group '$resourceGroupName' was not found."		
	}
}

<#
.SYNOPSIS
Test Test-AzLogicApp with physical file paths.
Test Test-AzLogicApp using definition object and parameter file.
Test Test-AzLogicApp for an invalid definition.
#>
function Test-ValidateLogicApp
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$definitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowDefinition.json"
	$parameterFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowParameter.json"

	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath

	# Test 1: Using physical file.
	Test-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath
	
	# Test 2: Using definition object and parameter file.
	$definition = [IO.File]::ReadAllText($definitionFilePath)
	Test-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Location $location -Definition $definition -ParameterFilePath $parameterFilePath

	# Test 3: Failure for an invalid definition.
	try
	{
		Test-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location $location -Definition '{}'
	}
	catch
	{
		Assert-AreEqual $_.Exception.Message "The request content is not valid and could not be deserialized: 'Required property '`$schema' not found in JSON. Path 'properties.definition', line 4, position 20.'."
	}

	Remove-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Force
}

<#
.SYNOPSIS
Test Get-AzLogicAppUpgradedDefinition to generate an upgraded definition for a workflow of older schema.
#>
function Test-GetUpgradedDefinitionForLogicApp
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"

	$definitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowDefinition.json"
	$parameterFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowParameter.json"

	$workflow = New-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Location $location -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath

	# Generate the upgraded definition.
	$upgradedDefinition = Get-AzLogicAppUpgradedDefinition -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -TargetSchemaVersion "2016-06-01"
	
	# Update the workflow with the upgraded definition.
	Set-AzLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Definition $upgradedDefinition.ToString() -Force

	Remove-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Force	
}

<#
.SYNOPSIS
Test Set-AzLogicApp command to update workflow with integration account.
Test Set-AzLogicApp command to remove integration account from a workflow.
#>
function Test-UpdateLogicAppWithIntegrationAccount
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname
	$location = Get-Location "Microsoft.Logic" "workflows" "West US"
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$simpleDefinitionFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowDefinition.json"
	$simpleParameterFilePath = Join-Path $TestOutputRoot "Resources" "TestSimpleWorkflowParameter.json"
	$workflow = $resourceGroup | New-AzLogicApp -Name $workflowName -Location $location -DefinitionFilePath $simpleDefinitionFilePath -ParameterFilePath $simpleParameterFilePath -IntegrationAccountId $integrationAccount.Id
	Assert-NotNull $workflow

	$updatedWorkflow = Set-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $simpleDefinitionFilePath -ParameterFilePath $simpleParameterFilePath -IntegrationAccountId $integrationAccount.Id -Force
	Assert-AreEqual $integrationAccount.Id $updatedWorkflow.IntegrationAccount.Id

	$updatedWorkflow = Set-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $simpleDefinitionFilePath -ParameterFilePath $simpleParameterFilePath -Force
	Assert-AreEqual $integrationAccount.Id $updatedWorkflow.IntegrationAccount.Id

	$integrationAccountName = "IA-" + (getAssetname)
	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	$updatedWorkflow = Set-AzLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -DefinitionFilePath $simpleDefinitionFilePath -ParameterFilePath $simpleParameterFilePath -IntegrationAccountId $integrationAccount.Id -Force
	Assert-AreEqual $integrationAccount.Id $updatedWorkflow.IntegrationAccount.Id

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}