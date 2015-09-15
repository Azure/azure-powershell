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
function Test-ValidateDeployment
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = Get-ProviderLocation ResourceManagement
	$location = Get-ProviderLocation "Microsoft.Web/sites"

	# Test
	New-AzureResourceGroup -Name $rgname -Location $rglocation
		
	$list = Test-AzureResourceGroupTemplate -ResourceGroupName $rgname -TemplateFile Build2014_Website_App.json -siteName $rname -hostingPlanName $rname -siteLocation $location -sku Free -workerSize 0

	# Assert
	Assert-AreEqual 0 @($list).Count
}

<#
.SYNOPSIS
Tests deployment via template file and parameter object.
#>
function Test-NewDeploymentFromTemplateFile
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = Get-ProviderLocation ResourceManagement
	$location = Get-ProviderLocation "Microsoft.Web/sites"

	# Test
	New-AzureResourceGroup -Name $rgname -Location $rglocation
		
	$deployment = New-AzureResourceGroupDeployment -ResourceGroupName $rgname -TemplateFile Build2014_Website_App.json -siteName $rname -hostingPlanName $rname -siteLocation $location -sku Free -workerSize 0

	# Assert
	Assert-AreEqual Succeeded $deployment.ProvisioningStatelean-ResourceGroup $rgname
}
