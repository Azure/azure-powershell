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
Tests BYOK for EventHub Namespace operations.
#>

function NamespaceTests
{
    # Setup    
    $location = Get-Location	
	$locationKafka = "westus"
	$namespaceName = getAssetName "Eventhub-Namespace1-"
	$namespaceName2 = getAssetName "Eventhub-Namespace2-"
    $resourceGroupName = "prod-by3-533-rg"
	$namespaceNameKafka = getAssetName "Eh-NamespaceKafka-"


    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
	#New-AzResourceGroup -Name $resourceGroupName -Location $location -Force   

	# Check Namespace Name Availability

	$checkNameResult = Test-AzEventHubName -Namespace $namespaceName 
	Assert-True {$checkNameResult.NameAvailable}

    Write-Debug " Create new eventHub namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location -SkuName "Standard" -SkuCapacity "1" -EnableAutoInflate -MaximumThroughputUnits 10 -ClusterARMId "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/prod-by3-533-rg/providers/Microsoft.EventHub/clusters/PMTestCluster" -Identity
	Assert-AreEqual $result.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
	Assert-AreEqual $result.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"
	
	# Assert 
	Assert-AreEqual $result.ProvisioningState "Succeeded"

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	Assert-AreEqual $createdNamespace.ResourceGroup $resourceGroupName "Namespace get : ResourceGroup name matches"
	Assert-AreEqual $createdNamespace.ResourceGroupName $resourceGroupName "Namespace get: ResourceGroupName name matches"

    Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found."	  
	
	
	## Create KeyVault
	
	$keyVault = New-AzKeyVault -VaultName "MyKeyVault" -ResourceGroupName $resourceGroupName -Location $location
	$key = Add-AzKeyVaultKey -VaultName "MyKeyVault" -Name "MyKey" -Destination 'Software'
	Set-AzKeyVaultAccessPolicy -VaultName "MyKeyVault" -ObjectId $createdNamespace.Identity.PrincipalId -PermissionsToKeys wrapkey,unwrapkey,get
        
	### change the Namespace Keyvalut Properties
	Write-Debug "Namespace name : $namespaceName"
	$result = Set-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location -KeySource "Microsoft.KeyVault" -KeyProperties @(@($key.Name,$keyVault.VaultUri,$key.Version))
	
	   
    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName
	
	#Assert
    Assert-True {$allCreatedNamespace.Count -ge 0 } "Namespace created earlier is not found. in list"
    
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzEventHubNamespace
	
    Assert-True {$allCreatedNamespace.Count -ge 0} "Namespaces created earlier is not found."

    Write-Debug " Delete namespaces"
    Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	
	Write-Debug " Delete resourcegroup"
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}
