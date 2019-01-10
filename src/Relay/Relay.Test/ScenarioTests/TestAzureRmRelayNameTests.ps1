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
Tests Relay Namespace CheckNameAvailability operations.
#>
function TestAzureRmRelayNameTests 
{
	# Setup    
	$location = "West US"
	$namespaceName = getAssetName "Relay-NS"
	$namespaceName2 = getAssetName "Relay-NS"
	$resourceGroupName = getAssetName
	$secondResourceGroup = getAssetName
	
	Write-Debug "Create resource group"
	Write-Debug "ResourceGroup name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force 

	Write-Debug "Create resource group"
	Write-Debug "ResourceGroup name : $secondResourceGroup"
	New-AzureRmResourceGroup -Name $secondResourceGroup -Location $location -Force 
	
	$ResultCheckNameAvailability = Test-AzureRmRelayName -Namespace $namespaceName
	Assert-True {$ResultCheckNameAvailability.NameAvailable} "The Namespace Name not Available"
	
	Write-Debug " Create new Relay namespace"
	Write-Debug "NamespaceName : $namespaceName" 
	$result = New-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -Location $location
	Wait-Seconds 15

	# Assert 
	Assert-True {$result.ProvisioningState -eq "Succeeded"}

	$ReCheckNameAvailability = Test-AzureRmRelayName -Namespace $namespaceName
	Assert-False {$ReCheckNameAvailability.NameAvailable} "The Namespace Name Available failed"  
	
	Write-Debug " Delete namespaces"
	Remove-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}