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
Tests deployment template validation.
#>
function Test-DeploymentEndToEnd-SubscriptionScope
{
    # Setup
	$deploymentName = Get-ResourceName
	$location = "WestUS"

    try
	{
		# Test
		$deployment = New-AzSubscriptionDeployment -Name $deploymentName -Location $location -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json
    
		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$getByName = Get-AzSubscriptionDeployment -Name $deploymentName
		Assert-AreEqual $getByName.DeploymentName $deployment.DeploymentName

		$templatePath = Save-AzSubscriptionDeploymentTemplate -Name $deploymentName -Force
		Assert-NotNull $templatePath.Path

		$operations = Get-AzSubscriptionDeploymentOperation -DeploymentName $deploymentName
		Assert-AreEqual 5 @($operations).Count

		Remove-AzSubscriptionDeployment -Name $deploymentName
	}
	finally
	{
	    #clean up
	    Clean-DeploymentAtSubscription $deploymentName
	}
}

<#
.SYNOPSIS
Tests deployment template validation.
#>
function Test-DeploymentEndToEnd-ResourceGroup
{
    try
	{
	    # Setup
		$location = "WestUS"
		$rgname = Get-ResourceGroupName
		$deploymentName = Get-ResourceName
		$storageAccountName = Get-ResourceName

		New-AzResourceGroup -Name $rgname -Location $location

		# Test
		$deployment = New-AzResourceGroupDeployment -ResourceGroupName $rgname -Name $deploymentName -TemplateFile sampleDeploymentTemplate.json -TemplateParameterFile sampleDeploymentTemplateParams.json -storageAccountName $storageAccountName
    
		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$getByName = Get-AzResourceGroupDeployment -ResourceGroupName $rgname -Name $deploymentName
		Assert-AreEqual $getByName.DeploymentName $deployment.DeploymentName

		$templatePath = Save-AzResourceGroupDeploymentTemplate -ResourceGroupName $rgname -Name $deploymentName -Force
		Assert-NotNull $templatePath.Path

		$operations = Get-AzResourceGroupDeploymentOperation -ResourceGroupName $rgname -DeploymentName $deploymentName
		Assert-AreEqual 3 @($operations).Count

		Remove-AzResourceGroupDeployment -ResourceGroupName $rgname -Name $deploymentName
	}
	finally
	{
	    Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests management group level deployment.
#>
function Test-DeploymentEndToEnd-ManagementGroup
{
    # Setup
	$deploymentName = Get-ResourceName
	$managementGroupId = Get-ResourceName
	$subscriptionId = "89ec4d1d-dcc7-4a3f-a701-0a5d074c8505"
	$rgname = Get-ResourceGroupName
	$storageAccountName = Get-ResourceName
	$deploymentLocation = "EastUS"

    try
	{
	    # Create management group
	    New-AzManagementGroup -GroupName $managementGroupId

		# New deployment
		$deployment = New-AzManagementGroupDeployment -ManagementGroupId $managementGroupId -Name $deploymentName -Location $deploymentLocation -TemplateFile management_group_level_template.json -TemplateParameterFile management_group_level_parameters.json -targetMG $managementGroupId -nestedSubId $subscriptionId -nestedRG $rgname -storageAccountName $storageAccountName
    
		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$deploymentId = "/providers/Microsoft.Management/managementGroups/$managementGroupId/providers/Microsoft.Resources/deployments/$deploymentName"
		
		$getById = Get-AzManagementGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$getByName = Get-AzManagementGroupDeployment -ManagementGroupId $managementGroupId -Name $deploymentName
		Assert-AreEqual $getByName.DeploymentName $deployment.DeploymentName
		
		$templatePath = Save-AzManagementGroupDeploymentTemplate -ManagementGroupId $managementGroupId -Name $deploymentName -Force
		Assert-NotNull $templatePath.Path
		
		$operations = Get-AzManagementGroupDeploymentOperation -ManagementGroup $managementGroupId -DeploymentName $deploymentName
		Assert-AreEqual 4 @($operations).Count
		#
		Remove-AzManagementGroupDeployment -ManagementGroup $managementGroupId -Name $deploymentName
	}
	finally
	{
	    #clean up
		Clean-ResourceGroup $rgname
	    Remove-AzManagementGroup -GroupName $managementGroupId
	}
}

<#
.SYNOPSIS
Tests tenant level deployment.
#>
function Test-DeploymentEndToEnd-TenantScope
{
    # Setup
	$deploymentName = Get-ResourceName
	$managementGroupId = Get-ResourceName
	$subscriptionId = "89ec4d1d-dcc7-4a3f-a701-0a5d074c8505"
	$rgname = Get-ResourceGroupName
	$deploymentLocation = "EastUS"

    try
	{
	    # Create management group
	    New-AzManagementGroup -GroupName $managementGroupId

		# Test
		$deployment = New-AzTenantDeployment -Name $deploymentName -Location $deploymentLocation -TemplateFile tenant_level_template.json -targetMG $managementGroupId -nestedSubId $subscriptionId -nestedRG $rgname
    
		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$deploymentId = "/providers/Microsoft.Resources/deployments/$deploymentName"
		
		$getById = Get-AzTenantDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$getByName = Get-AzTenantDeployment -Name $deploymentName
		Assert-AreEqual $getByName.DeploymentName $deployment.DeploymentName
		
		$templatePath = Save-AzTenantDeploymentTemplate -Name $deploymentName -Force
		Assert-NotNull $templatePath.Path
		
		$operations = Get-AzTenantDeploymentOperation -DeploymentName $deploymentName
		Assert-AreEqual 4 @($operations).Count
		#
		Remove-AzTenantDeployment -Name $deploymentName
	}
	finally
	{
	    #clean up
		Clean-ResourceGroup $rgname
		Remove-AzManagementGroup -GroupName $managementGroupId
	    Clean-DeploymentAtTenant $deploymentName
	}
}