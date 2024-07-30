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

#### Resource Group Scoped Stacks ####

<#
.SYNOPSIS
Tests GET operation on deployment stacks at the RG scope.
#>
function Test-GetResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Prepare 
		New-AzResourceGroup -Name $rgname -Location $rglocation
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - GetByNameAndResourceGroup - Success 
		$getByNameAndResourceGroup = Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -StackName $rname 
		Assert-NotNull $getByNameAndResourceGroup
		Assert-NotNull $getByNameAndResourceGroup.CorrelationId

		# Test - GetByNameAndResourceGroup - Failure - RG NotFound
		$badResourceGroupName = "badrg1928273615"
		$exceptionMessage = "DeploymentStack '$rname' in Resource Group '$badResourceGroupName' not found."
		Assert-Throws { Get-AzResourceGroupDeploymentStack -ResourceGroupName $badResourceGroupName -StackName $rname } $exceptionMessage 

		# Test - GetByNameAndResourceGroup - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in Resource Group '$rgname' not found."
		Assert-Throws { Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -StackName $badStackName } $exceptionMessage

		# Test - GetByResourceId - Success
		$getByResourceId = Get-AzResourceGroupDeploymentStack -ResourceId $resourceId
		Assert-NotNull $getByResourceId

		# Test - GetByResourceId - Failure - Bad ID form
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/resourceGroups/<rgname>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Get-AzResourceGroupDeploymentStack -ResourceId $badId } $exceptionMessage

		# Test - ListByResourceGroupName - Success
		$listByResourceGroup = Get-AzResourceGroupDeploymentStack -ResourceGroupName $rgname
		Assert-AreNotEqual 0 $listByResourceGroup.Count
		Assert-True { $listByResourceGroup.name.contains($rname) }
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests New operation on deployment stacks at the RG scope.
#>
function Test-NewResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile blankTemplate.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile $missingFile -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# Test - Failure - RG does not exist
		$badRGname = "badRG114172"
		$exceptionMessage = "Error: Code=ResourceGroupNotFound; Message=Resource group '$badRGname' could not be found"
		Assert-ThrowsContains { New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $badRGname -TemplateFile blankTemplate.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage
		
		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile $missingFile -DenySettingsMode None -Force } $exceptionMessage

		# Test - Failure - Deployment Validation Error - Bad Storage Account Name
		
		$exceptionMessage = "Storage account name must be between 3 and 24 characters in length"
		Assert-ThrowsContains { New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgName -TemplateFile StacksRGBadStorageAccountName.bicep -TemplateParameterFile StacksRGBadStorageAccountName.bicepparam -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success (with BypassStackOutOfSyncError)
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterObject @{templateSpecName = "StacksScenarioTestSpec"} -DenySettingsMode None -ActionOnUnmanage DetachAll -BypassStackOutOfSyncError -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Test (validate) operation on deployment stacks at the RG scope.
#>
function Test-TestResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success
		Assert-True { Test-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile blankTemplate.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force -PassThru }

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Test-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile $missingFile -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# Test - Failure - RG does not exist
		$badRGname = "badRG114172"
		$exceptionMessage = "Error: Code=ResourceGroupNotFound; Message=Resource group '$badRGname' could not be found"
		Assert-ThrowsContains { Test-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $badRGname -TemplateFile blankTemplate.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		Assert-True { Test-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force -PassThru }

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Test-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile $missingFile -DenySettingsMode None -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success (with BypassStackOutOfSyncError)
		Assert-True { Test-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterObject @{templateSpecName = "StacksScenarioTestSpec"} -DenySettingsMode None -ActionOnUnmanage DetachAll -BypassStackOutOfSyncError -Force -PassThru }
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests New operation on deployment stacks at the RG scope.
#>
function Test-NewAndSetResourceGroupDeploymentStackWithTags
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - Add Tags
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile blankTemplate.json -Tag @{"key1" = "value1"; "key2" = "value2"} -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 2 $deployment.Tags.Count

		# Test - Keep Tags
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile blankTemplate.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 2 $deployment.Tags.Count

		# Test - Clear Tags
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile blankTemplate.json -Tag @{} -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 0 $deployment.Tags.Count
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Tests NEW operation with unmanage action parameters on deploymentStacks at the RG scope.
#>
function Test-NewResourceGroupDeploymentStackUnmanageActions
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - Setting a blank stack with no flags set
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DenySettingsMode None -ActionOnUnmanage DeleteResources -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DenySettingsMode None -ActionOnUnmanage DeleteAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "delete" $deployment.ManagementGroupsCleanupAction
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests NEW and SET operations with deny settings on deploymentStacks at the RG scope.
#>
function Test-NewAndSetResourceGroupDeploymentStackDenySettings
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - NEW - DenySettingsMode and ApplyToChildScopes
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode DenyDelete -DenySettingsApplyToChildScopes -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyDelete" $deployment.DenySettings.Mode

		# Test - SET - DenySettingsMode and ApplyToChildScopes
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode DenyWriteAndDelete -DenySettingsApplyToChildScopes -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyWriteAndDelete" $deployment.DenySettings.Mode
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests SET operation on deployment stacks at the RG scope.
#>
function Test-SetResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...

		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success SET after NEW
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile blankTemplate.json -DenySettingsMode Non -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile $missingFile -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# Test - Failure - RG does not exist
		$badRGname = "badRG114172"
		$exceptionMessage = "Error: Code=ResourceGroupNotFound; Message=Resource group '$badRGname' could not be found.
"
		Assert-ThrowsContains { Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $badRGname -TemplateFile blankTemplate.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile $missingFile -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -Description "A Stack" -ResourceGroup $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterObject @{templateSpecName = "StacksScenarioTestSpec"} -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests SET operation with unmanage action parameters on deploymentStacks at the RG scope.
#>
function Test-SetResourceGroupDeploymentStackUnmanageActions
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - Setting a blank stack with no flags set
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json  -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DenySettingsMode None -ActionOnUnmanage DeleteResources -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile blankTemplate.json -DenySettingsMode None -ActionOnUnmanage DeleteAll -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "delete" $deployment.ManagementGroupsCleanupAction
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests NEW operation on deploymentStacks at the RG scope with bicep file.
#>
function Test-NewAndSetResourceGroupDeploymentStackWithBicep
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	
	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - NewByNameAndResourceGroupAndBicepTemplateFile
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.bicep -TemplateParameterFile StacksRGTemplateParams.bicepparam -DenySettingsMode None -ActionOnUnmanage DetachAll  -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - .bicepparam file only
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateParameterFile StacksRGTemplateParams.bicepparam -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzResourceGroupDeploymentStacks
		$deployment = Set-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplatePlus.bicep -TemplateParameterFile StacksRGTemplatePlusParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally 
	{
        # Cleanup
        Clean-ResourceGroup $rgname
	}
}

 <#
 .SYNOPSIS
 Tests NEW, SET and SAVE operations on deploymentStacks at the RG scope using template specs.
 #>
 function Test-NewAndSetAndSaveResourceGroupDeploymentStackWithTemplateSpec
 {
 	# Setup
 	$rgname = Get-ResourceGroupName
 	$stackname = Get-ResourceName
 	$rname = Get-ResourceName
 	$rglocation = "West US 2"

 	try 
	{
 		# Prepare
 		New-AzResourceGroup -Name $rgname -Location $rglocation
 		$sampleTemplateJson = Get-Content -Raw -Path StacksRGTemplate.json
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Force
 		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

 		# Test - New-AzResourceGroupDeploymentStack using templateSpecs
 		$deployment = New-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateSpec $resourceId -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

 		# Test - Set-AzResourceGroupDeploymentStack using templateSpecs
 		$deployment = Set-AzResourceGroupDeploymentStack -Name $stackname -ResourceGroupName $rgname -TemplateSpec $resourceId -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Save-AzResourceGroupDeploymentStack checking for template link
		$template = Save-AzResourceGroupDeploymentStackTemplate -StackName $stackname -ResourceGroupName $rgname
		Assert-NotNull $template
		Assert-NotNull $template.TemplateLink
		Assert-Null $template.Template
 	}

 	finally
     {
         # Cleanup
         Clean-ResourceGroup $rgname
     }
 }

 <#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks at RG scope.
#>
function Test-RemoveResourceGroupDeploymentStack
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# --- RemoveByResourceIdParameterSetName ---

		# Test - Success
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzResourceGroupDeploymentStack -Id $resourceId -ActionOnUnmanage DeleteAll -Force
		Assert-Null $deployment

		# Test - Failure - Bad ID form 
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/resourceGroups/<rgname>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Remove-AzResourceGroupDeploymentStack -Id $badId -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- RemoveByNameAndResourceGroupName --- 

		# Test - Failure - RG NotFound
		$badResourceGroupName = "badrg1928273615"
		$exceptionMessage = "Operation returned an invalid status code 'NotFound' : ResourceGroupNotFound : Resource group '$badResourceGroupName' could not be found."
		Assert-Throws { Remove-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $badResourceGroupName -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# Test - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in ResourceGroup '$rgname' not found."
		Assert-Throws { Remove-AzResourceGroupDeploymentStack -ResourceGroupName $rgname -StackName $badStackName -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# Test - Success with PassThru - DeleteResources
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -ActionOnUnmanage DeleteResources -PassThru -Force
		Assert-AreEqual "true" $deployment


		# Test - Success with PassThru - DeleteAll
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -ActionOnUnmanage DeleteAll -PassThru -Force
		Assert-AreEqual "true" $deployment
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests SAVE operation on deployment stack templates at RG scope.
#>
function Test-SaveResourceGroupDeploymentStackTemplate
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation 
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentStacks/$rname"

		# --- SaveByResourceIdParameterSetName ---
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/resourceGroups/<rgname>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Save-AzResourceGroupDeploymentStackTemplate -Id $badId } $exceptionMessage

		# Test - Success
		$deployment = Save-AzResourceGroupDeploymentStackTemplate -Id $resourceId
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template

		# --- SaveByNameAndResourceGroupName ---

		# Test - Failure - Resource Group NotFound
		$badResourceGroupName = "badrg1928273615"
		$exceptionMessage = "DeploymentStack '$rname' in Resource Group '$badResourceGroupName' not found."
		Assert-Throws { Save-AzResourceGroupDeploymentStackTemplate -StackName $rname -ResourceGroupName $badResourceGroupName } $exceptionMessage
		
		# Test - Failure - Stack NotFound
		$badStackName = "badStack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in Resource Group '$rgname' not found."
		Assert-Throws { Save-AzResourceGroupDeploymentStackTemplate -StackName $badStackName -ResourceGroupName $rgname } $exceptionMessage

		# Test - Success
		$deployment = Save-AzResourceGroupDeploymentStackTemplate -StackName $rname -ResourceGroupName $rgname
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template 
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

 <#
.SYNOPSIS
Tests SAVE and REMOVE operation using pipe operator on deploymentStacks at RG scope.
#>
function Test-SaveAndRemoveResourceGroupDeploymentStackWithPipeOperator
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation
		$deployment = New-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# --- SaveByStackObjectSetName ---
		$template = Get-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname | Save-AzResourceGroupDeploymentStackTemplate
		Assert-NotNull $template

		# --- RemoveByStackObjectSetName ---
		$deployment = Get-AzResourceGroupDeploymentStack -Name $rname -ResourceGroupName $rgname | Remove-AzResourceGroupDeploymentStack -ActionOnUnmanage DetachAll -Force
		Assert-Null $deployment
	}

	finally
	{
		# Cleanup
		Clean-ResourceGroup $rgname
	}
}

#### Subscription Scoped Stacks #####

<#
.SYNOPSIS
Tests GET operation on deployment stacks at the SUB scope.
#>
function Test-GetSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try
	{
		# Prepare 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - GetByName - Success 
		$getByName = Get-AzSubscriptionDeploymentStack -StackName $rname 
		Assert-NotNull $getByName
		Assert-NotNull $getByName.CorrelationId

		# Test - GetByName - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' not found in current subscription scope."
		Assert-Throws { Get-AzSubscriptionDeploymentStack -StackName $badStackName } $exceptionMessage

		# Test - GetByResourceId - Success
		$getByResourceId = Get-AzSubscriptionDeploymentStack -ResourceId $resourceId
		Assert-NotNull $getByResourceId

		# Test - GetByResourceId - Failure - Bad ID form
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Get-AzSubscriptionDeploymentStack -ResourceId $badId } $exceptionMessage

		# Test - ListBySubscription - Success
		$listBySubscription = Get-AzSubscriptionDeploymentStack
		Assert-AreNotEqual 0 $listBySubscription.Count
		Assert-True { $listBySubscription.name.contains($rname) }
	}
	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -ActionOnUnmanage DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests NEW operation on deployment stacks at the SUB scope.
#>
function Test-NewSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile $missingFile  -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState


		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterFile $missingFile -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		$exceptionMessage = "The provided resource group name 'test23!!!' has these invalid characters"
		Assert-ThrowsContains { New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -Location $location -TemplateFile StacksSubBadRGName.bicep -TemplateParameterFile StacksSubBadRGName.bicepparam -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName (with BypassStackOutOfSyncError) ---

		# Test - Success
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterObject @{policyDefinitionName = "PSCmdletTestPolicy4762"} -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -BypassStackOutOfSyncError -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -ActionOnUnmanage DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests Test (validate) operation on deployment stacks at the SUB scope.
#>
function Test-TestSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success
		Assert-True { Test-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force -PassThru }

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Test-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile $missingFile  -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		Assert-True { Test-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force -PassThru }


		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Test-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterFile $missingFile -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		$exceptionMessage = "The provided resource group name 'test23!!!' has these invalid characters"
		Assert-ThrowsContains { Test-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -Location $location -TemplateFile StacksSubBadRGName.bicep -TemplateParameterFile StacksSubBadRGName.bicepparam -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName (with BypassStackOutOfSyncError) ---

		# Test - Success
		Assert-True { Test-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterObject @{policyDefinitionName = "PSCmdletTestPolicy4762"} -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -BypassStackOutOfSyncError -Force -PassThru }
	}

	finally
    {
        # No Cleanup Required.
    }
}

<#
.SYNOPSIS
Tests NEW operation on deployment stacks at the SUB scope.
#>
function Test-NewAndSetSubscriptionDeploymentStackWithTags
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try 
	{
		# Test - Add Tags
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile blankTemplate.json -Location $location -Tag @{"key1" = "value1"; "key2" = "value2"} -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 2 $deployment.Tags.Count

		# Test - Keep Tags
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 2 $deployment.Tags.Count

		# Test - Clear Tags
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile blankTemplate.json -Location $location -Tag @{} -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 0 $deployment.Tags.Count
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -ActionOnUnmanage DeleteAll -Force
    }
}


<#
.SYNOPSIS
Tests NEW operation with unmanage action parameters on deploymentStacks at the Sub scope.
#>
function Test-NewSubscriptionDeploymentStackUnmanageActions
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try 
	{
		# Test - Setting a blank stack with no flags set
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -ActionOnUnmanage DeleteResources -Location $location -DenySettingsMode None -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -ActionOnUnmanage DeleteAll -Location $location -DenySettingsMode None -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "delete" $deployment.ManagementGroupsCleanupAction
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -ActionOnUnmanage DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests NEW and SET operations with deny settings on deploymentStacks at the Sub scope.
#>
function Test-NewAndSetSubscriptionDeploymentStackDenySettings
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try 
	{
		# Test - NEW- DenySettingsMode and ApplyToChildScopes
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -ActionOnUnmanage DetachAll -DenySettingsMode DenyDelete -DenySettingsApplyToChildScopes -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyDelete" $deployment.DenySettings.Mode

		# Test - SET - DenySettingsMode and ApplyToChildScopes
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -ActionOnUnmanage DetachAll -DenySettingsMode DenyWriteAndDelete -DenySettingsApplyToChildScopes -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyWriteAndDelete" $deployment.DenySettings.Mode
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -ActionOnUnmanage DeleteAll -Force
    }
}
<#
.SYNOPSIS
Tests SET operation on deployment stacks at the Sub scope.
#>
function Test-SetSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try {
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Set-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile $missingFile -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Set-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -TemplateParameterFile $missingFile -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterObjectTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -Description "A Stack" -TemplateFile StacksSubTemplate.json -Location $location -TemplateParameterObject @{policyDefinitionName = "PSCmdletTestPolicy4762"} -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -ActionOnUnmanage DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests SET operation with unmanage action parameters on deploymentStacks at the Sub scope.
#>
function Test-SetSubscriptionDeploymentStackUnmanageActions
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try 
	{
		# Test - Setting a blank stack with no flags set
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -ActionOnUnmanage DeleteResources -Location $location -DenySettingsMode None -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile blankTemplate.json -ActionOnUnmanage DeleteAll -Location $location -DenySettingsMode None -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "delete" $deployment.ManagementGroupsCleanupAction
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -ActionOnUnmanage DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests NEW and SET operations on deploymentStacks at the Sub scope with bicep file.
#>
function Test-NewAndSetSubscriptionDeploymentStackWithBicep
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"
	
	try 
	{
		# Test - NewByNameAndResourceGroupAndBicepTemplateFile
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.bicep -TemplateParameterFile StacksSubTemplateParams.bicepparam -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - .bicepparam file only
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateParameterFile StacksSubTemplateParams.bicepparam -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzSubscriptionDeploymentStacks
		$deployment = Set-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplatePlus.bicep -TemplateParameterFile StacksSubTemplatePlusParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally 
	{
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -ActionOnUnmanage DeleteAll -Force
	}
}

 <#
 .SYNOPSIS
 Tests NEW, SET, and SAVE operations on deploymentStacks at the Sub scope using template specs.
 #>
 function Test-NewAndSetAndSaveSubscriptionDeploymentStackWithTemplateSpec
 {
 	# Setup
 	$rgname = Get-ResourceGroupName
 	$rname = Get-ResourceName
 	$stackname = Get-ResourceName
 	$rglocation = "West US 2"
	$location = "West US 2"

 	try 
	{
 		# Prepare
 		New-AzResourceGroup -Name $rgname -Location $rglocation
 		$sampleTemplateJson = Get-Content -Raw -Path StacksSubTemplate.json
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Location $rgLocation -Name $rname -Version "v1" -TemplateJson $sampleTemplateJson -Force
 		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

 		# Test - New-AzSubscriptionDeploymentStacks using templateSpecs
 		$deployment = New-AzSubscriptionDeploymentStack -Name $stackname -TemplateSpec $resourceId -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

 		# Test - Set-AzSubscriptionDeploymentStacks using templateSpecs
 		$deployment = Set-AzSubscriptionDeploymentStack -Name $stackname -TemplateSpec $resourceId -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Save-AzSubscriptionDeploymentStack checking for template link
		$template = Save-AzSubscriptionDeploymentStackTemplate -StackName $stackname
		Assert-NotNull $template
		Assert-NotNull $template.TemplateLink
		Assert-Null $template.Template
 	}

 	finally
     {
         # Cleanup
         Clean-ResourceGroup $rgname
		 Remove-AzSubscriptionDeploymentStack -Name $stackname -ActionOnUnmanage DeleteAll -Force
     }
 }

 <#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks at Sub scope.
#>
function Test-RemoveSubscriptionDeploymentStack
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try {
		# --- RemoveByResourceIdParameterSetName ---

		# Test - Success
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzSubscriptionDeploymentStack -Id $resourceId -ActionOnUnmanage DetachAll -Force
		Assert-Null $deployment

		# Test - Failure - Bad ID form 
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Remove-AzSubscriptionDeploymentStack -Id $badId -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- RemoveByNameParameterSetName --- 

		# Test - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' not found in the curent subscription scope."
		Assert-Throws { Remove-AzSubscriptionDeploymentStack -StackName $badStackName -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# Test - Success with PassThru - DeleteResources
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzSubscriptionDeploymentStack -Name $rname -ActionOnUnmanage DeleteResources -PassThru -Force
		Assert-AreEqual "true" $deployment

		# Test - Success with PassThru - DeleteAll
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzSubscriptionDeploymentStack -Name $rname -ActionOnUnmanage DeleteAll -PassThru -Force
		Assert-AreEqual "true" $deployment
	}
	finally
	{
		# No need to cleanup as we already deleted stack.
	}
}

<#
.SYNOPSIS
Tests SAVE operation on deploymentStacks.
#>
function Test-SaveSubscriptionDeploymentStackTemplate
{
	# Setup
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try 
	{
		# Prepare
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$rname"
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# --- SaveByResourceIdParameterSetName ---
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /subscriptions/<subid>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Save-AzSubscriptionDeploymentStackTemplate -Id $badId } $exceptionMessage

		# Test - Success
		$deployment = Save-AzSubscriptionDeploymentStackTemplate -Id $resourceId
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template

		# --- SaveByNameParameterSetName ---
		
		# Test - Failure - Stack NotFound
		$badStackName = "badStack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in active subscription not found."
		Assert-Throws { Save-AzSubscriptionDeploymentStackTemplate -StackName $badStackName } $exceptionMessage

		# Test - Success
		$deployment = Save-AzSubscriptionDeploymentStackTemplate -StackName $rname
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template 
	}

	finally
    {
        # Cleanup
        Remove-AzSubscriptionDeploymentStack -Name $rname -ActionOnUnmanage DeleteAll -Force
    }
}

#### Management Group Scoped Stacks ####

<#
.SYNOPSIS
Tests GET operation on deployment stacks at the RG scope.
#>
function Test-GetManagementGroupDeploymentStack
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$location = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Prepare 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		$resourceId = "/providers/Microsoft.Management/managementGroups/$mgid/providers/Microsoft.Resources/deploymentStacks/$rname"

		# Test - GetByManagementGroupIdAndName - Success 
		$getByNameAndManagementGroup = Get-AzManagementGroupDeploymentStack -ManagementGroupId $mgid -Name $rname 
		Assert-NotNull $getByNameAndManagementGroup
		Assert-NotNull $getByNameAndManagementGroup.CorrelationId

		# Test - GetByManagementGroupIdAndName - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in Management Group '$mgid' not found."
		Assert-Throws { Get-AzManagementGroupDeploymentStack -ManagementGroupId $mgid -StackName $badStackName } $exceptionMessage

		# Test - GetByResourceId - Success
		$getByResourceId = Get-AzManagementGroupDeploymentStack -ResourceId $resourceId
		Assert-NotNull $getByResourceId

		# Test - GetByResourceId - Failure - Bad ID form
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /providers/Microsoft.Management/managementGroups/<managementgroupid>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Get-AzManagementGroupDeploymentStack -ResourceId $badId } $exceptionMessage

		# Test - ListByManagementGroupId - Success
		$listByManagementGroup = Get-AzManagementGroupDeploymentStack -ManagementGroupId $mgid
		Assert-AreNotEqual 0 $listByManagementGroup.Count
		Assert-True { $listByManagementGroup.name.contains($rname) }
	}

	finally
    {
        # Cleanup
        Remove-AzManagementGroupDeploymentStack $mgid $rname -ActionOnUnmanage DeleteAll -Force
    }
}

 <#
.SYNOPSIS
Tests SAVE and REMOVE operation using pipe operator on deploymentStacks at Sub scope.
#>
function Test-SaveAndRemoveSubscriptionDeploymentStackWithPipeOperator
{
	# Setup
	$rname = Get-ResourceName
	$location = "West US 2"

	try 
	{
		# Prepare
		$deployment = New-AzSubscriptionDeploymentStack -Name $rname -Location $location -TemplateFile StacksSubTemplate.json -TemplateParameterFile StacksSubTemplateParams.json -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# --- SaveByStackObjectSetName ---
		$template = Get-AzSubscriptionDeploymentStack -Name $rname | Save-AzSubscriptionDeploymentStackTemplate
		Assert-NotNull $template

		# --- RemoveByStackObjectSetName ---
		$deployment = Get-AzSubscriptionDeploymentStack -Name $rname | Remove-AzSubscriptionDeploymentStack -ActionOnUnmanage DetachAll -Force
		Assert-Null $deployment
	}

	finally
	{
		# No need to cleanup as we already deleted stack.
	}
}

<#
.SYNOPSIS
Tests New operation on deployment stacks at the MG scope.
#>
function Test-NewManagementGroupDeploymentStack
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success - blank template
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Success - MG scoped deployment
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid -TemplateFile StacksMGTemplateMGDeployment.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid  -DeploymentSubscriptionId $subId -TemplateFile $missingFile -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success (with BypassStackOutOfSyncError)
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid  -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -BypassStackOutOfSyncError -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid  -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile $missingFile -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage
	}

	finally
    {
		# Cleanup
		Remove-AzManagementGroupDeploymentStack $mgid $rname -ActionOnUnmanage DeleteAll -Force
        
    }
}

<#
.SYNOPSIS
Tests Test (validate) operation on deployment stacks at the MG scope.
#>
function Test-TestManagementGroupDeploymentStack
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success - blank template
		Assert-True { Test-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force -PassThru }

		# Test - Success - MG scoped deployment
		Assert-True { Test-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid -TemplateFile StacksMGTemplateMGDeployment.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force -PassThru }

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Test-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid  -DeploymentSubscriptionId $subId -TemplateFile $missingFile -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success (with BypassStackOutOfSyncError)
		Assert-True { Test-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid  -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -BypassStackOutOfSyncError -ActionOnUnmanage DetachAll -Force -PassThru }

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Test-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid  -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile $missingFile -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage
	}

	finally
    {
		# No Cleanup Required.
        
    }
}

<#
.SYNOPSIS
Tests New operation on deployment stacks at the RG scope.
#>
function Test-NewAndSetManagementGroupDeploymentStackWithTags
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try 
	{
		# Test - Add Tags
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -Tag @{"key1" = "value1"; "key2" = "value2"} -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 2 $deployment.Tags.Count

		# Test - Keep Tags
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 2 $deployment.Tags.Count

		# Test - Clear Tags
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -Tag @{} -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual 0 $deployment.Tags.Count
	}
	
	finally
    {
		# Cleanup
		Remove-AzManagementGroupDeploymentStack $mgid $rname -ActionOnUnmanage DeleteAll -Force
        
    }
}


<#
.SYNOPSIS
Tests NEW operation with unmanage action parameters on deploymentStacks at the RG scope.
#>
function Test-NewManagementGroupDeploymentStackUnmanageActions
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try 
	{
		# Test - Setting a blank stack with no flags set
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -ActionOnUnmanage DeleteResources -Location $location -DenySettingsMode None -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DeleteAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "delete" $deployment.ManagementGroupsCleanupAction
	}

	finally
    {
		# Cleanup
		Remove-AzManagementGroupDeploymentStack $mgid $rname -ActionOnUnmanage DeleteAll -Force
        
    }
}

<#
.SYNOPSIS
Tests NEW and SET operations with deny settings on deploymentStacks at the RG scope.
#>
function Test-NewAndSetManagementGroupDeploymentStackDenySettings
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try 
	{
		# Test - NEW - DenySettingsMode and ApplyToChildScopes
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -DenySettingsMode DenyDelete -DenySettingsApplyToChildScopes -ActionOnUnmanage DetachAll -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyDelete" $deployment.DenySettings.Mode

		# Test - SET - DenySettingsMode and ApplyToChildScopes
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -DenySettingsMode DenyWriteAndDelete -DenySettingsApplyToChildScopes -ActionOnUnmanage DetachAll -Location $location -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "DenyWriteAndDelete" $deployment.DenySettings.Mode
	}

	finally
    {
		# Cleanup
		Remove-AzManagementGroupDeploymentStack $mgid $rname -ActionOnUnmanage DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests SET operation on deployment stacks at the RG scope.
#>
function Test-SetManagementGroupDeploymentStack
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try 
	{
		# TODO Testing: URI parameter types for templates and template parameters, bad template content, more with parameter object validation...
		
		# --- ParameterlessTemplateFileParameterSetName ---

		# Test - Success SET after NEW
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid  -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid  -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Success - MG scoped deployment
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroupId $mgid -TemplateFile StacksMGTemplateMGDeployment.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid  -DeploymentSubscriptionId $subId -TemplateFile $missingFile -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- ParameterFileTemplateFileParameterSetName ---

		# Test - Success
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Failure - template parameter file not found
		$missingFile = "missingFile145.json"
		$exceptionMessage = "$missingFile' because it does not exist."
		Assert-ThrowsContains { Set-AzManagementGroupDeploymentStack -Name $rname -Description "A Stack" -ManagementGroup $mgid  -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile $missingFile -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force } $exceptionMessage
	}

	finally
	{
		# Cleanup
		Remove-AzManagementGroupDeploymentStack $mgid $rname -ActionOnUnmanage DeleteAll  -Force
    }
}

<#
.SYNOPSIS
Tests SET operation with unmanage action parameters on deploymentStacks at the RG scope.
#>
function Test-SetManagementGroupDeploymentStackUnmanageActions
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"

	try 
	{
		# Test - Setting a blank stack with no flags set
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "detach" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteResources set 
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -ActionOnUnmanage DeleteResources -Location $location -DenySettingsMode None -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "detach" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "detach" $deployment.ManagementGroupsCleanupAction

		# Test - Setting a blank stack with DeleteAll set 
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile blankTemplate.json -ActionOnUnmanage DeleteAll -Location $location -DenySettingsMode None  -Force

		Assert-AreEqual "succeeded" $deployment.ProvisioningState
		Assert-AreEqual "delete" $deployment.ResourcesCleanupAction
		Assert-AreEqual "delete" $deployment.ResourceGroupsCleanupAction
		Assert-AreEqual "delete" $deployment.ManagementGroupsCleanupAction
	}

	finally
    {
		# Cleanup
		Remove-AzManagementGroupDeploymentStack $mgid $rname -ActionOnUnmanage DeleteAll -Force
    }
}

<#
.SYNOPSIS
Tests NEW operation on deploymentStacks at the RG scope with bicep file.
#>
function Test-NewAndSetManagementGroupDeploymentStackWithBicep
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$location = "West US 2"
	
	try 
	{
		# Test - NewByNameAndManagementGroupAndBicepTemplateFile
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.bicep -TemplateParameterFile StacksMGTemplateParams.bicepparam -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - .bicepparam file only
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateParameterFile StacksMGTemplateParams.bicepparam -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Set-AzManagementGroupDeploymentStacks
		$deployment = Set-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplatePlus.bicep -TemplateParameterFile StacksMGTemplatePlusParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	}

	finally 
	{
		# Cleanup
		Remove-AzManagementGroupDeploymentStack $mgid $rname -ActionOnUnmanage DeleteAll -Force
	}
}

 <#
 .SYNOPSIS
 Tests NEW, SET and SAVE operations on deploymentStacks at the RG scope using template specs.
 #>
 function Test-NewAndSetAndSaveManagementGroupDeploymentStackWithTemplateSpec
 {
 	# Setup
 	$mgid = "AzBlueprintAssignTest"
 	$stackname = Get-ResourceName
 	$specname = Get-ResourceName
	$rgname = Get-ResourceName
	$subId = (Get-AzContext).Subscription.SubscriptionId
 	$location = "West US 2"

 	try 
	{
 		# Prepare
		New-AzResourceGroup -Name $rgname -Location $location
 		$sampleTemplateJson = Get-Content -Raw -Path StacksMGTemplate.json
        $basicCreatedTemplateSpec = New-AzTemplateSpec -Name $specname -ResourceGroupName $rgname -Location $location -Version "v1" -TemplateJson $sampleTemplateJson -Force
 		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

 		# Test - New-AzManagementGroupDeploymentStack using templateSpecs
 		$deployment = New-AzManagementGroupDeploymentStack -Name $stackname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateSpec $resourceId -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

 		# Test - Set-AzManagementGroupDeploymentStack using templateSpecs
 		$deployment = Set-AzManagementGroupDeploymentStack -Name $stackname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateSpec $resourceId -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
 		$id = $deployment.id
 		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		# Test - Save-AzManagementGroupDeploymentStack checking for template link
		$template = Save-AzManagementGroupDeploymentStackTemplate -StackName $stackname -ManagementGroupId $mgid
		Assert-NotNull $template
		Assert-NotNull $template.TemplateLink
		Assert-Null $template.Template
 	}

 	finally
     {
		# Cleanup
		Remove-AzManagementGroupDeploymentStack $mgid $stackname -ActionOnUnmanage DeleteAll -Force
     }
 }

 <#
.SYNOPSIS
Tests REMOVE operation on deploymentStacks at RG scope.
#>
function Test-RemoveManagementGroupDeploymentStack
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$location = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		# --- RemoveByResourceIdParameterSetName ---

		# Test - Success
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		$resourceId = "/providers/Microsoft.Management/managementGroups/$mgid/providers/Microsoft.Resources/deploymentStacks/$rname" 
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzManagementGroupDeploymentStack -Id $resourceId -ActionOnUnmanage DetachAll -Force
		Assert-Null $deployment

		# Test - Failure - Bad ID form 
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /providers/Microsoft.Management/managementGroups/<managementgroupid>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Remove-AzManagementGroupDeploymentStack -Id $badId -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# --- RemoveByNameAndManagementGroupId --- 

		# Test - Failure - Stack NotFound
		$badStackName = "badstack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' not found in Management Group '$mgid'."
		Assert-Throws { Remove-AzManagementGroupDeploymentStack -ManagementGroupId $mgid -StackName $badStackName -ActionOnUnmanage DetachAll -Force } $exceptionMessage

		# Test - Success with PassThru - DeleteResources
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -ActionOnUnmanage DeleteResources -PassThru -Force
		Assert-AreEqual "true" $deployment

		# Test - Success with PassThru - DeleteAll
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState

		$deployment = Remove-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -ActionOnUnmanage DeleteAll -PassThru -Force
		Assert-AreEqual "true" $deployment
	}

	finally
    {
        # No cleanup needed, as the stack was deleted.
    }
}

<#
.SYNOPSIS
Tests SAVE operation on deployment stack templates at RG scope.
#>
function Test-SaveManagementGroupDeploymentStackTemplate
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$location = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		# Prepare
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll -Force
		$resourceId = "/providers/Microsoft.Management/managementGroups/$mgid/providers/Microsoft.Resources/deploymentStacks/$rname"

		# --- SaveByResourceIdParameterSetName ---
		$badId = "a/bad/id"
		$exceptionMessage = "Provided Id '$badId' is not in correct form. Should be in form /providers/Microsoft.Management/managementGroups/<managementgroupid>/providers/Microsoft.Resources/deploymentStacks/<stackname>"
		Assert-Throws { Save-AzManagementGroupDeploymentStackTemplate -Id $badId } $exceptionMessage

		# Test - Success
		$deployment = Save-AzManagementGroupDeploymentStackTemplate -Id $resourceId
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template

		# --- SaveByNameAndManagementGroupId ---
		
		# Test - Failure - Stack NotFound
		$badStackName = "badStack1928273615"
		$exceptionMessage = "DeploymentStack '$badStackName' in Management Group '$mgid' not found."
		Assert-Throws { Save-AzManagementGroupDeploymentStackTemplate -StackName $badStackName -ManagementGroupId $mgid } $exceptionMessage

		# Test - Success
		$deployment = Save-AzManagementGroupDeploymentStackTemplate -StackName $rname -ManagementGroupId $mgid
		Assert-NotNull $deployment
		Assert-NotNull $deployment.Template 
	}

	finally
    {
		# Cleanup
		Remove-AzManagementGroupDeploymentStack $mgid $rname -ActionOnUnmanage DeleteAll -Force
    }
}

 <#
.SYNOPSIS
Tests SAVE and REMOVE operation using pipe operator on deploymentStacks at MG scope.
#>
function Test-SaveAndRemoveManagementGroupDeploymentStackWithPipeOperator
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$location = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		# Prepare
		$deployment = New-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid -DeploymentSubscriptionId $subId -TemplateFile StacksMGTemplate.json -TemplateParameterFile StacksMGTemplateParams.json -Location $location -DenySettingsMode None -ActionOnUnmanage DetachAll  -Force
		Assert-AreEqual "succeeded" $deployment.ProvisioningState
	
		# --- SaveByStackObjectSetName ---
		$template = Get-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid | Save-AzManagementGroupDeploymentStackTemplate
		Assert-NotNull $template

		# --- RemoveByStackObjectSetName ---
		$deployment = Get-AzManagementGroupDeploymentStack -Name $rname -ManagementGroupId $mgid | Remove-AzManagementGroupDeploymentStack -ActionOnUnmanage DetachAll -Force
		Assert-Null $deployment
	}

	finally
	{
		# No cleanup needed, as the stack was deleted.
	}
}