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
function Test-DeploymentEndToEnd
{
    try
	{
	    # Setup
		$rgname = Get-ResourceGroupName
		$deploymentName = Get-ResourceName
		$location = "WestUS"

		New-AzResourceGroup -Name $rgname -Location $location

		# Test
		$deployment = New-AzDeployment -Name $deploymentName -Location $location -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -nestedDeploymentRG $rgname
    
		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/providers/Microsoft.Resources/deployments/$deploymentName"
		$getById = Get-AzDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$templatePath = Save-AzDeploymentTemplate -Name $deploymentName -Force
		Assert-NotNull $templatePath.Path

		$operations = Get-AzDeploymentOperation -DeploymentName $deploymentName
		Assert-AreEqual 4 @($operations).Count

		Remove-AzDeployment -Name $deploymentName
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
function Test-DeploymentAsJob
{
    try
	{
	    # Setup
		$rgname = Get-ResourceGroupName
		$deploymentName = Get-ResourceName
		$storageAccountName = Get-ResourceName
		$location = "WestUS"

		New-AzResourceGroup -Name $rgname -Location $location

		# Test
		$job = New-AzDeployment -Name $deploymentName -Location $location -TemplateFile subscription_level_template.json -nestedDeploymentRG $rgname -storageAccountName $storageAccountName -AsJob
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
		Assert-AreEqual 4 @($operations).Count

		Remove-AzDeployment -Name $deploymentName
	}
	finally
	{
	    Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests stopping deployment.
#>
function Test-StopDeployment
{
    try
	{
	    # Setup
		$rgname = Get-ResourceGroupName
		$deploymentName = Get-ResourceName
		$storageAccountName = Get-ResourceName
		$location = "WestUS"

		New-AzResourceGroup -Name $rgname -Location $location

		# Test
		$job = New-AzDeployment -Name $deploymentName -Location $location -TemplateFile subscription_level_template.json -nestedDeploymentRG $rgname -storageAccountName $storageAccountName -AsJob
		Assert-AreEqual Running $job[0].State

		#Start-Sleep -s 1

		Stop-AzDeployment -Name $deploymentName

		$job = $job | Wait-Job
		Assert-AreEqual Completed $job[0].State

		$deployment = $job | Receive-Job
		Assert-AreEqual Canceled $deployment.ProvisioningState

		#Start-Sleep -s 1

		Remove-AzDeployment -Name $deploymentName
	}
	finally
	{
	    Clean-ResourceGroup $rgname
	}
}