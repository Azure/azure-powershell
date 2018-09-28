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
Tests ServiceBus Namespace CURD operations.
#>
function ServiceBusTests
{
    #Setup    
    $location = Get-Location
	$resourceGroupName = getAssetName "RGName-"
	$namespaceName = getAssetName "Namespace1-"
	$namespaceName2 = getAssetName "Namespace2-"
 
    Write-Debug "Create resource group"    
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug " Create new ServiceBus namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location  -Name $namespaceName -SkuName "Standard"
	# Assert 
	Assert-AreEqual $result.Name $namespaceName
	Assert-AreEqual $result.ProvisioningState "Succeeded"

    Write-Debug "Get the created namespace within the resource group"
    $getNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
	Assert-AreEqual $getNamespace.Name $namespaceName "Get-ServicebusName- created namespace not found"
    
	$UpdatedNameSpace = Set-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName -SkuName "Standard" -SkuCapacity 2	
	Assert-AreEqual $UpdatedNameSpace.Name $namespaceName

    Write-Debug "Namespace name : $namespaceName2"
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location "East US 2" -Name $namespaceName2 -SkuName "Premium" -EnableZoneRedundant 
	Assert-True {$result.ZoneRedundant}

    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName
	Assert-True {$allCreatedNamespace.Count -gt 1}
    
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzureRmServiceBusNamespace
	Assert-True {$allCreatedNamespace.Count -gt 1 }

    Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2
    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}