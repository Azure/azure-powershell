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
Tests Set-AzureRmDefault when resource group given does not exist
#>
function Test-SetAzureRmDefaultResourceGroupNonexistent
{
	$output = Set-AzureRmDefault -ResourceGroupName "TestResourceGroup"
	Assert-True { $output.Name -eq "TestResourceGroup" }
	Remove-AzureRmResourceGroup -Name "TestResourceGroup" -Force
	Clear-AzureRmDefault
}

<#
.SYNOPSIS
Tests Set-AzureRmDefault when resource group given exists
#>
function Test-SetAzureRmDefaultResourceGroupExists
{
	Set-AzureRmDefault -ResourceGroupName "TestResourceGroup"
	Clear-AzureRmDefault
	$output = Set-AzureRmDefault -ResourceGroupName "TestResourceGroup"
	Assert-True { $output.Name -eq "TestResourceGroup" }
	Remove-AzureRmResourceGroup -Name "TestResourceGroup" -Force
	Clear-AzureRmDefault
}

<#
.SYNOPSIS
Tests Get-AzureRmDefault when no default set
#>
function Test-GetAzureRmDefaultNoDefault
{
	$output = Get-AzureRmDefault
	Assert-Null($output)
	$output1 = Get-AzureRmDefault -ResourceGroup
	Assert-Null($output)
}

<#
.SYNOPSIS
Tests Get-AzureRmDefault when default set
#>
function Test-GetAzureRmDefaultWithDefault
{
	$resourceGroup = Set-AzureRmDefault -ResourceGroupName "TestResourceGroup"
	$output = Get-AzureRmDefault
	Assert-AreEqual $output.Name $resourceGroup[1].Name
	$output1 = Get-AzureRmDefault -ResourceGroup
	Assert-AreEqual $output1.Name $resourceGroup[1].Name
	Remove-AzureRmResourceGroup -Name "TestResourceGroup" -Force
	Clear-AzureRmDefault
}

<#
.SYNOPSIS
Tests Clear-AzureRmDefault when no default set
#>
function Test-ClearAzureRmDefaultNoDefault
{
	$output = Get-AzureRmDefault
	Assert-Null($output)
	Clear-AzureRmDefault
	$output1 = Get-AzureRmDefault
	Assert-Null($output1)
	Clear-AzureRmDefault -ResourceGroup
	$output2 = Get-AzureRmDefault
	Assert-Null($output2)
}

<#
.SYNOPSIS
Tests Clear-AzureRmDefault when default set
#>
function Test-ClearAzureRmDefaultWithDefault
{
	$resourceGroup = Set-AzureRmDefault -ResourceGroupName "TestResourceGroup"
	$output = Get-AzureRmDefault
	Assert-AreEqual $output.Name $resourceGroup[1].Name

	Clear-AzureRmDefault
	$output = Get-AzureRmDefault
	Assert-Null($output)

	$resourceGroup = Set-AzureRmDefault -ResourceGroupName "TestResourceGroup"
	$output = Get-AzureRmDefault
	Assert-AreEqual $output.Name $resourceGroup.Name

	Clear-AzureRmDefault -ResourceGroup
	$output = Get-AzureRmDefault
	Assert-Null($output)

	Remove-AzureRmResourceGroup -Name "TestResourceGroup" -Force
}