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
Tests cmdlets surrounding default resource group
#>
function Test-DefaultResourceGroup
{
	# Setup
	$rgname = Get-ResourceGroupName
	Clear-AzureRmDefault -ResourceGroup

	try
	{
		# Test GetDefault when default not set
		$output = Get-AzureRmDefault
		Assert-Null($output)
		$output = Get-AzureRmDefault -ResourceGroup
		Assert-Null($output)
		$storedValue = (Get-AzureRmContext).ExtendedProperties["Default Resource Group"]
		Assert-Null($storedValue)

		# Test Resoure Group created when it doesn't exist
		$output = Set-AzureRmDefault -ResourceGroupName $rgname -Force
		$resourcegroup = Get-AzureRmResourceGroup -Name $rgname
		Assert-AreEqual $output.Name $resourcegroup.ResourceGroupName
		$context = Get-AzureRmContext
		$storedValue = $context.ExtendedProperties["Default Resource Group"]
		Assert-AreEqual $storedValue $output.Name

		# Test GetDefault when default is set
		$output = Get-AzureRmDefault
		Assert-AreEqual $output.Name $resourceGroup.ResourceGroupName
		$output = Get-AzureRmDefault -ResourceGroup
		Assert-AreEqual $output.Name $resourceGroup.ResourceGroupName

		# Test Clear-AzureRmDefault (no parameters shown)
		Clear-AzureRmDefault -Force
		$output = Get-AzureRmDefault
		Assert-Null($output)
		$context = Get-AzureRmContext
		$storedValue = $context.ExtendedProperties["Default Resource Group"]
		Assert-Null($storedValue)

		# Test SetDefault when resource group exists
		$output = Set-AzureRmDefault -ResourceGroupName $rgname
		Assert-AreEqual $output.Name $resourcegroup.ResourceGroupName
		$context = Get-AzureRmContext
		$storedValue = $context.ExtendedProperties["Default Resource Group"]
		Assert-AreEqual $storedValue $output.Name

		# Test Clear-AzureRmDefault (no parameters shown)
		Clear-AzureRmDefault -ResourceGroup
		$output = Get-AzureRmDefault
		Assert-Null($output)
		$context = Get-AzureRmContext
		$storedValue = $context.ExtendedProperties["Default Resource Group"]
		Assert-Null($storedValue)
	}
	finally
	{
		Clean-ResourceGroup($rgname)
	}
}

<#
.SYNOPSIS
Gets valid resource group name
#>
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
        Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}