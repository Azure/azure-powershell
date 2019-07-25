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
    try
	{
	    # Setup
		$deploymentName = Get-ResourceName
		$location = "WestUS"

		# Test
		$deployment = New-AzDeployment -Name $deploymentName -Location $location -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json
    
		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$getByName = Get-AzDeployment -Name $deploymentName
		Assert-AreEqual $getByName.DeploymentName $deployment.DeploymentName

		$templatePath = Save-AzDeploymentTemplate -Name $deploymentName -Force
		Assert-NotNull $templatePath.Path

		$operations = Get-AzDeploymentOperation -DeploymentName $deploymentName
		Assert-AreEqual 5 @($operations).Count

		Remove-AzDeployment -Name $deploymentName
	}
	finally
	{

	}
}

<#
.SYNOPSIS
Tests deployment as job.
#>
function Test-DeploymentAsJob-SubscriptionScope
{
    try
	{
	    # Setup
		$deploymentName = Get-ResourceName
		$storageAccountName = Get-ResourceName
		$location = "WestUS"

		# Test
		$job = New-AzDeployment -Name $deploymentName -Location $location -TemplateFile subscription_level_template.json -storageAccountName $storageAccountName -AsJob
		Assert-AreEqual Running $job[0].State

		$job = $job | Wait-Job
		Assert-AreEqual Completed $job[0].State

		$deployment = $job | Receive-Job
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/providers/Microsoft.Resources/deployments/$deploymentName"
		$getById = Get-AzDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$operations = Get-AzDeploymentOperation -DeploymentName $deploymentName
		Assert-AreEqual 5 @($operations).Count

		Remove-AzDeployment -Name $deploymentName
	}
	finally
	{

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
		$deployment = New-AzDeployment -ResourceGroupName $rgname -Name $deploymentName -TemplateFile sampleDeploymentTemplate.json -TemplateParameterFile sampleDeploymentTemplateParams.json -storageAccountName $storageAccountName
    
		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$getByName = Get-AzDeployment -ResourceGroupName $rgname -Name $deploymentName
		Assert-AreEqual $getByName.DeploymentName $deployment.DeploymentName

		$templatePath = Save-AzDeploymentTemplate -ResourceGroupName $rgname -Name $deploymentName -Force
		Assert-NotNull $templatePath.Path

		$operations = Get-AzDeploymentOperation -ResourceGroupName $rgname -DeploymentName $deploymentName
		Assert-AreEqual 3 @($operations).Count

		Remove-AzDeployment -ResourceGroupName $rgname -Name $deploymentName
	}
	finally
	{
	    Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests deployment as job.
#>
function Test-DeploymentAsJob-ResourceGroup
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
		$job = New-AzDeployment -ResourceGroupName $rgname -Name $deploymentName -TemplateFile sampleDeploymentTemplate.json -TemplateParameterFile sampleDeploymentTemplateParams.json -storageAccountName $storageAccountName -AsJob
		Assert-AreEqual Running $job[0].State

		$job = $job | Wait-Job
		Assert-AreEqual Completed $job[0].State

		$deployment = $job | Receive-Job
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourceGroups/$rgname/providers/Microsoft.Resources/deployments/$deploymentName"
		$getById = Get-AzDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$operations = Get-AzDeploymentOperation -ResourceGroupName $rgname -DeploymentName $deploymentName
		Assert-AreEqual 3 @($operations).Count

		Remove-AzDeployment -ResourceGroupName $rgname -Name $deploymentName
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
    try
	{
        # Setup
		$deploymentName = Get-ResourceName
		$location = "EastUS"

		# Test
		$deployment = New-AzDeployment -ManagementGroupId "tiano-mgtest01" -Name $deploymentName -Location $location -TemplateFile management_group_level_template.json -TemplateParameterFile management_group_level_parameters.json
    
		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$deploymentId = "/providers/Microsoft.Management/managementGroups/tiano-mgtest01/providers/Microsoft.Resources/deployments/$deploymentName"
		
		$getById = Get-AzDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$getByName = Get-AzDeployment -ManagementGroupId "tiano-mgtest01" -Name $deploymentName
		Assert-AreEqual $getByName.DeploymentName $deployment.DeploymentName
		
		$templatePath = Save-AzDeploymentTemplate -ManagementGroupId "tiano-mgtest01" -Name $deploymentName -Force
		Assert-NotNull $templatePath.Path
		
		$operations = Get-AzDeploymentOperation -ManagementGroup "tiano-mgtest01" -DeploymentName $deploymentName
		Assert-AreEqual 4 @($operations).Count
		#
		Remove-AzDeployment -ManagementGroup "tiano-mgtest01" -Name $deploymentName
	}
	finally
	{
	    
	}
}

<#
.SYNOPSIS
Tests deployment as job.
#>
function Test-DeploymentAsJob-ManagementGroup
{
    try
	{
	    # Setup
		$deploymentName = Get-ResourceName
		$location = "EastUS"

		# Test
		$job = New-AzDeployment -ManagementGroupId "tiano-mgtest01" -Name $deploymentName -Location $location -TemplateFile management_group_level_template.json -TemplateParameterFile management_group_level_parameters.json -AsJob
		Assert-AreEqual Running $job[0].State

		$job = $job | Wait-Job
		Assert-AreEqual Completed $job[0].State

		$deployment = $job | Receive-Job
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$deploymentId = "/providers/Microsoft.Management/managementGroups/tiano-mgtest01/providers/Microsoft.Resources/deployments/$deploymentName"
		$getById = Get-AzDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$operations = Get-AzDeploymentOperation -ManagementGroup "tiano-mgtest01" -DeploymentName $deploymentName
		Assert-AreEqual 4 @($operations).Count

		Remove-AzDeployment -ManagementGroup "tiano-mgtest01" -Name $deploymentName
	}
	finally
	{

	}
}