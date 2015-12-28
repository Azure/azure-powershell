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
Test New-AzureLogicApp with physical file paths
#>
function Test-NewLogicAppUsingDefinitionFilePath		 
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname	
	$definitionFilePath = "Resources\TestSimpleWorkflowDefinition.json"
	$parameterFilePath = "Resources\TestSimpleWorkflowParameter.json"

	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Location "westus" -State "Enabled" -PlanName "StandardServicePlan" -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath -SkuName "Standard"
    
	Assert-NotNull $workflow
	Assert-AreEqual $workflowName $workflow.Name 
	Assert-NotNull $workflow.Definition
	Assert-NotNull $workflow.Parameters
}

<#
.SYNOPSIS
Test New-AzureLogicApp with object type parameters
#>
function Test-NewLogicAppUsingDefinitionObject
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname	
	$parameterFilePath = "Resources\TestSimpleWorkflowParameter.json"
		
    $definition = [IO.File]::ReadAllText("Resources\TestSimpleWorkflowDefinition.json")

	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Location "westus" -State "Enabled" -SkuName "Standard" -PlanName "StandardServicePlan" -Definition $definition -ParameterFilePath $parameterFilePath
    
	Assert-NotNull $workflow
	Assert-AreEqual $workflowName $workflow.Name 
	Assert-NotNull $workflow.Definition
	Assert-NotNull $workflow.Parameters
}

<#
.SYNOPSIS
Test New-AzureLogicApp with Definition file and object parameters
#>
function Test-NewLogicAppUsingDefinitionObjectAndParameterFile
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname	

	$parameterFilePath = "Resources\TestSimpleWorkflowParameter.json"	
	$definitionFilePath = "Resources\TestSimpleWorkflowDefinition.json"
			
	$definition = [IO.File]::ReadAllText("Resources\TestSimpleWorkflowDefinition.json")

	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroup.ResourceGroupName -Name $workflowName -Location "westus" -State "Enabled" -SkuName "Standard" -PlanName "StandardServicePlan" -Definition $definition -ParameterFilePath $parameterFilePath
    
	Assert-NotNull $workflow
	Assert-AreEqual $workflowName $workflow.Name 
	Assert-NotNull $workflow.Definition
	Assert-NotNull $workflow.Parameters
}

<#
.SYNOPSIS
Test New-AzureLogicApp with Pipeline Input from ResourceGroupObject
#>
function Test-NewLogicAppUsingResourcegroupPipeline
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname	
	$definitionFilePath = "Resources\TestSimpleWorkflowDefinition.json"
	$parameterFilePath = "Resources\TestSimpleWorkflowParameter.json"

	$workflow = $resourceGroup | New-AzureLogicApp -Name $workflowName -State "Enabled" -SkuName "Standard" -PlanName "StandardServicePlan" -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath
    
	Assert-NotNull $workflow
	Assert-AreEqual $workflowName $workflow.Name 
	Assert-NotNull $workflow.Definition
	Assert-NotNull $workflow.Parameters
}

<#
.SYNOPSIS
Test New-AzureLogicApp to create a workflow with a duplicate name.
#>
function Test-NewLogicAppWithDuplicateName
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname	
	$definitionFilePath = "Resources\TestSimpleWorkflowDefinition.json"
	$parameterFilePath = "Resources\TestSimpleWorkflowParameter.json"
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$workflow = $resourceGroup | New-AzureLogicApp -Name $workflowName -SkuName "Standard" -PlanName "StandardServicePlan" -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath
    
	Assert-NotNull $workflow
	try
	{
		$workflow = $resourceGroup | New-AzureLogicApp -Name $workflowName -SkuName "Standard" -PlanName "StandardServicePlan" -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath
	}
	catch
	{		
		Assert-AreEqual $_.Exception.Message "The Resource 'Microsoft.Logic/workflows/$WorkflowName' under resource group '$resourceGroupName' already exists."		
	}	
}

<#
.SYNOPSIS
Test New-AzureLogicApp with SKU Plan ID
#>
function Test-NewLogicAppWithPlanId
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname	
	
	$definitionFilePath = "Resources\TestSimpleWorkflowDefinition.json"
	$parameterFilePath = "Resources\TestSimpleWorkflowParameter.json"

	$resourceGroupName = $resourceGroup.ResourceGroupName
	$planId = "/subscriptions/57b7034d-72d4-433d-ace2-a7460aed6a99/resourceGroups/$resourceGroupName/providers/Microsoft.Web/serverfarms/StandardServicePlan"
	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location "westus" -State "Enabled" -SkuName "Standard" -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath -PlanId $planId -PlanName "StandardServicePlan"
    
	Assert-NotNull $workflow	
	Assert-NotNull $workflow.Definition
	Assert-NotNull $workflow.Parameters	
	Assert-AreEqual $workflowName $workflow.Name 
}

<#
.SYNOPSIS
Test New-AzureLogicApp with Pipeline Input from Sku
#>
function Test-NewLogicAppUsingSkuPipeline
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname	
	$resourceGroupName = $resourceGroup.ResourceGroupName
	$planId = "/subscriptions/57b7034d-72d4-433d-ace2-a7460aed6a99/resourceGroups/$resourceGroupName/providers/Microsoft.Web/serverfarms/StandardServicePlan"
	
	#Custom Sku Object
	$SkuObject = [PSCustomObject]@{
		SkuName = 'Standard'
		PlanName = 'StandardServicePlan'
		PlanId = $planId
	}

	$definitionFilePath = "Resources\TestSimpleWorkflowDefinition.json"
	$parameterFilePath = "Resources\TestSimpleWorkflowParameter.json"

	$workflow = $SkuObject | New-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location "westus" -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath	
		    
	Assert-NotNull $workflow	
	Assert-NotNull $workflow.Definition
	Assert-NotNull $workflow.Parameters
	Assert-AreEqual $workflowName $workflow.Name 
	Assert-AreEqual "Enabled" $workflow.State
}

<#
.SYNOPSIS
Test New-AzureLogicApp with workflow object
#>
function Test-NewLogicAppUsingInputfromWorkflowObject
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname	
	$resourceGroupName = $resourceGroup.ResourceGroupName
	
	$definitionFilePath = "Resources\TestSimpleWorkflowDefinition.json"
	$parameterFilePath = "Resources\TestSimpleWorkflowParameter.json"

	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location "westus" -DefinitionFilePath $definitionFilePath -ParameterFilePath $parameterFilePath -PlanName "StandardServicePlan" -SkuName "Standard"
	$newWorkflowName = getAssetname	
	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $newWorkflowName -Location "westus" -Definition $workflow.Definition -Parameters $workflow.Parameters -PlanName "StandardServicePlan" -SkuName "Standard"
		    
	Assert-NotNull $workflow	
	Assert-NotNull $workflow.Definition
	Assert-NotNull $workflow.Parameters
	Assert-AreEqual $newWorkflowName $workflow.Name 
	Assert-AreEqual "Enabled" $workflow.State
}

<#
.SYNOPSIS
Test New-AzureLogicApp with Parameter as hash table
#>
function Test-NewLogicAppUsingInputParameterAsHashTable
{
	$endpointName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname	
	$resourceGroupName = $resourceGroup.ResourceGroupName
	
	$definitionFilePath = "Resources\TestSimpleWorkflowDefinition.json"	
	$parameters = @{destinationUri="http://requestb.in/1kj7g8e1"}
		
	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location "westus" -DefinitionFilePath $definitionFilePath -Parameters $parameters -PlanName "StandardServicePlan" -SkuName "Standard"
		    
	Assert-NotNull $workflow	
	Assert-NotNull $workflow.Parameters
}

<#
.SYNOPSIS
Test New-AzureLogicApp with only definition
#>
function Test-NewLogicAppUsingDefinitionWithTriggers
{
	$endpointName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname	
	$resourceGroupName = $resourceGroup.ResourceGroupName
	
	$definitionFilePath = "Resources\TestSimpleWorkflowTriggerDefinition.json"			
		
	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location "westus" -DefinitionFilePath $definitionFilePath -PlanName "StandardServicePlan" -SkuName "Standard"
		    
	Assert-NotNull $workflow		
}

<#
.SYNOPSIS
Test New-AzureLogicApp with only definition
#>
function Test-NewLogicAppUsingDefinitionWithActions
{
	$endpointName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup
	$workflowName = getAssetname	
	$resourceGroupName = $resourceGroup.ResourceGroupName
		
	$definitionFilePath = "Resources\TestSimpleWorkflowActionDefinition.json"		
		
	$workflow = New-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location "westus" -DefinitionFilePath $definitionFilePath -PlanName "StandardServicePlan" -SkuName "Standard"
		    
	Assert-NotNull $workflow		
}

<#
.SYNOPSIS
Test GetLogicAppWithWorkflowName command to get workflow by name.
#>
function Test-GetLogicAppWithWorkflowName
{
	$resourceGroupName = getAssetname
	$ExpectedWorkflow = TestSetup-CreateWorkflow $resourceGroupName

	Assert-NotNull $ExpectedWorkflow
		
	$ActualWorkflow = Get-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $ExpectedWorkflow.Name
    
	Assert-NotNull $ActualWorkflow
	Assert-AreEqual $ExpectedWorkflow.Name $ActualWorkflow.Name	
}

<#
.SYNOPSIS
Test RemoveLogicAppWithWorkflowName command to remove workflow by name.
Test Get-AzureLogicApp to get non existing workflow.
#>
function Test-RemoveLogicAppWithWorkflowName
{
	$resourceGroupName = getAssetname
	$ExpectedWorkflow = TestSetup-CreateWorkflow $resourceGroupName
	$WorkflowName = $ExpectedWorkflow.Name
	Assert-NotNull $ExpectedWorkflow
		
	Remove-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $WorkflowName -Force
	try
	{
		$ActualWorkflow = Get-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $WorkflowName
	}
	catch
	{		
		Assert-AreEqual $_.Exception.Message "The Resource 'Microsoft.Logic/workflows/$WorkflowName' under resource group '$resourceGroupName' was not found."		
	}   	
}

<#
.SYNOPSIS
Test RemoveLogicAppWithWorkflowName command to remove nonexisting workflow by name.
#>
function Test-RemoveLogicAppWithInvalidWorkflowName
{
	$WorkflowName = "09e81ac4-848a-428d-82a6-7d61953e3940"
	$resourceGroup = TestSetup-CreateResourceGroup
	$resourceGroupName = $resourceGroup.ResourceGroupName
			
	Remove-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $WorkflowName -Force
}

<#
.SYNOPSIS
Test Set-AzureLogicApp command to update workflow.
#>
function Test-UpdateLogicApp
{
	$resourceGroupName = getAssetname
	$ExpectedWorkflow = TestSetup-CreateWorkflow $resourceGroupName
	$WorkflowName = $ExpectedWorkflow.Name	
	Assert-NotNull $ExpectedWorkflow
				
	$definitionFilePath = "Resources\TestSimpleWorkflowTriggerDefinition.json"	

	$UpdatedWorkflow = Set-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $workflowName -Location "westus" -PlanName "NonStandardServicePlan" -SkuName "Free" -DefinitionFilePath $definitionFilePath

	Assert-NotNull $UpdatedWorkflow
	Assert-AreEqual $UpdatedWorkflow.Location "westus"
	Assert-AreEqual $UpdatedWorkflow.Sku.Plan.Name "NonStandardServicePlan"
	Assert-AreEqual $UpdatedWorkflow.Sku.Name "Free"
	
	Assert-NotNull $UpdatedWorkflow
}

<#
.SYNOPSIS
Test Set-AzureLogicApp command to update non-existing workflow.
#>
function Test-UpdateNonExistingLogicApp
{
	$resourceGroupName = getAssetname
	$ExpectedWorkflow = TestSetup-CreateWorkflow $resourceGroupName
	$WorkflowName = "82D2D842-C312-445C-8A4D-E3EE9542436D"
	Assert-NotNull $ExpectedWorkflow
				
	$definitionFilePath = "Resources\TestSimpleWorkflowTriggerDefinition.json"		

	try
	{
		$UpdatedWorkflow = Set-AzureLogicApp -ResourceGroupName $resourceGroupName -Name $WorkflowName -Location "westus" -PlanName "NonStandardServicePlan" -SkuName "Free" -DefinitionFilePath $definitionFilePath
	}
	catch
	{		
		Assert-AreEqual $_.Exception.Message "The Resource 'Microsoft.Logic/workflows/$WorkflowName' under resource group '$resourceGroupName' was not found."		
	} 
}