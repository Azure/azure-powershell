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
Tests Set-AzureRmDefault when resource group given is valid
#>
function Test-SetAzureRmDefaultResourceGroupValid
{
	$validResourceGroups = Get-AzureRmResourceGroup
	$output = Set-AzureRmDefault -ResourceGroupName $validResourceGroups[0].Name
	Assert-True { $output -eq $validResourceGroups[0] }
}

<#
.SYNOPSIS
Tests Set-AzureRmDefault when resource group given is not valid
#>
function Test-SetAzureRmDefaultResourceGroupNotValid
{
	$invalidResourceGroupName = "Invalid Resource Group"
	$output = Set-AzureRmDefault -ResourceGroupName $invalidResourceGroupName
	Assert-Null($output)
	Assert-ThrowsContains { Set-AzureRmDefault -ResourceGroupName $invalidResourceGroupName } "Resource group 'Invalid Resource Group' could not be found"
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
	Assert-Null($output1)
}

<#
.SYNOPSIS
Tests Get-AzureRmDefault when default set
#>
function Test-GetAzureRmDefaultWithDefault
{
	$validResourceGroups = Get-AzureRmResourceGroup
	Set-AzureRmDefault -ResourceGroupName $validResourceGroups[0].Name
	$output = Get-AzureRmDefault
	Assert-AreEqual $output $validResourceGroups[0]
	$output1 = Get-AzureRmDefault -ResourceGroup
	Assert-AreEqual $output1 $validResourceGroups[0]
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
	$validResourceGroups = Get-AzureRmResourceGroup
	Set-AzureRmDefault -ResourceGroupName $validResourceGroups[0].Name
	Clear-AzureRmDefault
	$output = Get-AzureRmDefault
	Assert-Null($output)
	$validResourceGroups = Get-AzureRmResourceGroup
	Set-AzureRmDefault -ResourceGroupName $validResourceGroups[0].Name
	$output1 = Get-AzureRmDefault
	Assert-AreEqual $output1 $validResourceGroups[0]
	Clear-AzureRmDefault -ResourceGroup
	$output2 = Get-AzureRmDefault
	Assert-Null($output2)
}