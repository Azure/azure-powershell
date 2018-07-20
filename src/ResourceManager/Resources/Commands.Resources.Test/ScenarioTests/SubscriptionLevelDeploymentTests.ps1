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

		New-AzureRmResourceGroup -Name $rgname -Location $location

		# Test
		$deployment = New-AzureRmDeployment -Name $deploymentName -Location $location -TemplateFile subscription_level_template.json -TemplateParameterFile subscription_level_parameters.json -nestedDeploymentRG $rgname
    
		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
    
		$subId = (Get-AzureRmContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/providers/Microsoft.Resources/deployments/$deploymentName"
		$getById = Get-AzureRmDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$operations = Get-AzureRmDeploymentOperation -Name $deploymentName
		Assert-AreEqual 4 @($operations).Count

		$result = Remove-AzureRmDeployment -Name $deploymentName
		Assert-AreEqual True $result 
	}
	finally
	{
	    Clean-ResourceGroup $rgname
	}
}