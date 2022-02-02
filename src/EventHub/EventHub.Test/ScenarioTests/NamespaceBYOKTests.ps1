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
    $location = "East US 2"	
	$locationKafka = "East US 2"
	$namespaceName = getAssetName "Eventhub-Namespace1-"
	$namespaceName2 = getAssetName "Eventhub-Namespace2-"
	$keyVaultName = "SDKTesting1Key"
	$keyName = "sdktesting1key"
    $resourceGroupName = "prod-by3-533-rg"
	$namespaceNameKafka = getAssetName "Eh-NamespaceKafka-"
	#$namespaceName = "Eventhub-Namespace1-9237"


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
	
	## KeyVault	
	#$keyVault = New-AzKeyVault -VaultName $keyVaultName -ResourceGroupName $resourceGroupName -Location $location -EnablePurgeProtection
	$keyVault = Get-AzKeyVault -VaultName $keyVaultName -ResourceGroupName $resourceGroupName
	Set-AzKeyVaultAccessPolicy -VaultName $keyVaultName -ObjectId $createdNamespace.Identity.PrincipalId -PermissionsToKeys wrapkey,unwrapkey,get -BypassObjectIdValidation
	#$key = $keyVault | Add-AzKeyVaultKey -Name $keyName -Destination software 
        
	### change the Namespace Keyvalut Properties
	Write-Debug "Namespace name : $namespaceName"
	$result = Set-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location -KeySource "Microsoft.KeyVault" -KeyProperty @(@($keyName,$keyVault.VaultUri,""))
	
	## Create Namespace and than set identity in update command 

	$result2 = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName2 -Location $location -SkuName "Standard" -SkuCapacity "1" -EnableAutoInflate -MaximumThroughputUnits 10 -ClusterARMId "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/prod-by3-533-rg/providers/Microsoft.EventHub/clusters/PMTestCluster"

	Assert-AreEqual $result2.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
	Assert-AreEqual $result2.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches" 
	
	# Assert 
	Assert-AreEqual $result2.ProvisioningState "Succeeded"

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace2 = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName2
	Assert-AreEqual $createdNamespace2.ResourceGroup $resourceGroupName "Namespace get : ResourceGroup name matches"
	Assert-AreEqual $createdNamespace2.ResourceGroupName $resourceGroupName "Namespace get: ResourceGroupName name matches"
    Assert-AreEqual $createdNamespace2.Name $namespaceName2 "Namespace created earlier is not found."	

	# Set Identity 
	$resultUpdate = Set-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName2 -Location $location -Identity
	Assert-NotNull $resultUpdate.Identity "Identity Not updated in Set Command"


    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName
	
	#Assert
    Assert-True {$allCreatedNamespace.Count -ge 0 } "Namespace created earlier is not found. in list"
    
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzEventHubNamespace
	
    Assert-True {$allCreatedNamespace.Count -ge 0} "Namespaces created earlier is not found."
	

    Write-Debug " Delete namespaces"
    Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName2
	
}
