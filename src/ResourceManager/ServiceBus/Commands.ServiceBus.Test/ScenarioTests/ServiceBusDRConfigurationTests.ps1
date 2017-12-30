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
Check the Provisioning state of the created alias and wait till it get succeded 
#>
function WaitforStatetoBeSucceded 
{
	param([string]$resourceGroupName,[string]$namespaceName,[string]$drConfigName)
	
	$createdDRConfig = Get-AzureRmServiceBusDRConfiguration -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -Name $drConfigName

	while($createdDRConfig.ProvisioningState -ne "Succeeded")
	{
		Start-Sleep -s 10
		$createdDRConfig = Get-AzureRmServiceBusDRConfiguration -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -Name $drConfigName
	}

	return $createdDRConfig
}

<#
.SYNOPSIS
Check the Provisioning state of the namespace and wait till it get succeded 
#>
function WaitforStatetoBeSucceded_namespace
{
	param([string]$resourceGroupName,[string]$namespaceName)
	
	$Getnamespace = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName 

	while($Getnamespace.ProvisioningState -ne "Succeeded")
	{
		Wait-Seconds 10
		$Getnamespace = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
	}

}

<#
.SYNOPSIS
Tests ServiceBus DRConfiguration Create List Remove operations.
#>

function ServiceBusDRConfigurationTests
{
	# Setup    
	$location_south = "South Central US"
	$location_north = "North Central US"
	$resourceGroupName = getAssetName "RGName-"
	$namespaceName1 = getAssetName "Namespace1-"
	$namespaceName2 = getAssetName "Namespace2-"
	$drConfigName = getAssetName "drConfig1-"
    $authRuleName = getAssetName "authorule1-"

	
	# Check NameSpace Name Availability
	$checkNamespaceNameResult = Test-AzureRmServiceBusName -Namespace $namespaceName1 
	Assert-True { $checkNamespaceNameResult.NameAvailable}

	# Create Resource Group
	Write-Debug "Create resource group"    
	Write-Debug " Resource Group Name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location_south -Force
			
	# Create ServiceBus Namespace - 1
	Write-Debug "Create new ServiceBus namespace 1"
	Write-Debug " Namespace 1 name : $namespaceName1"
	$result1 = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Location $location_south -SkuName Premium

	# Assert
	Assert-AreEqual $result1.ProvisioningState "Succeeded"

	$result1 = Set-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Location $location_south -SkuName Premium -SkuCapacity 1

	# Create ServiceBus Namespace - 2
	Write-Debug "  Create new ServiceBus namespace 2"
	Write-Debug " Namespace 2 name : $namespaceName2"
	$result2 = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Location $location_north -SkuName Premium

	# Assert
	Assert-AreEqual $result2.ProvisioningState "Succeeded"

	 $result2 = Set-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Location $location_north -SkuName Premium -SkuCapacity 1

	# get the created ServiceBus Namespace  1
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace1 = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1
	
	Assert-AreEqual $createdNamespace1.Name $namespaceName1 "Namespace created earlier is not found."

	# Check DR Configuration Name Availability

	$chackNameResult = Test-AzureRmServiceBusName -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -AliasName $drConfigName 
	Assert-True { $chackNameResult.NameAvailable}

	# get the created ServiceBus Namespace  2
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace2 = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2	
	Assert-AreEqual $createdNamespace2.Name $namespaceName2 "Namespace created earlier is not found"	


	Write-Debug "Create a Namespace Authorization Rule"
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $authRuleName -Rights @("Listen","Send")																																	  

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
	

	# Create a DRConfiguration
	Write-Debug " Create new DRConfiguration"
	$result = New-AzureRmServiceBusDRConfiguration -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName1 -Name $drConfigName -PartnerNamespace $createdNamespace2.Id
	Assert-AreEqual $result.Role "Primary"
		
	Write-Debug " Get the created DRConfiguration"
	$createdDRConfig = Get-AzureRmServiceBusDRConfiguration -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName1 -Name $drConfigName

	# Assert
	Assert-AreEqual $createdDRConfig.PartnerNamespace $createdNamespace2.Id

	# Get the Created DRConfiguration
	Write-Debug " Get all the created DRConfiguration"
	$createdServiceBusDRConfigList = Get-AzureRmServiceBusDRConfiguration -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName1

	# Assert
	Assert-AreEqual $createdServiceBusDRConfigList.Count 1 "ServiceBus DRConfig created earlier is not found in list"

	# Wait till the Alias Provisioning  state changes to succeeded
	WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName

	# BreakPairing on Primary Namespace
	Write-Debug "BreakPairing on Primary Namespace"
	Set-AzureRmServiceBusDRConfigurationBreakPairing -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName1 -Name $drConfigName
	
	# Wait till the Alias Provisioning  state changes to succeeded
	$breakPairingDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
	Assert-AreEqual $breakPairingDRConfig.Role "PrimaryNotReplicating"

	# Create a DRConfiguration
	Write-Debug " Create new DRConfiguration"
	$DRresult = New-AzureRmServiceBusDRConfiguration -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName1 -Name $drConfigName -PartnerNamespace $createdNamespace2.Id
	
	# Wait till the Alias Provisioning  state changes to succeeded
	$UpdateDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName	
	Assert-AreEqual $UpdateDRConfig.Role "Primary"

	# FailOver on Secondary Namespace
	Write-Debug "FailOver on Secondary Namespace"
	Set-AzureRmServiceBusDRConfigurationFailOver -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName2 -Name $drConfigName

	# Wait till the Alias Provisioning  state changes to succeeded
	$failoverDrConfiguration = WaitforStatetoBeSucceded $resourceGroupName $namespaceName2 $drConfigName
	Assert-AreEqual $failoverDrConfiguration.Role "PrimaryNotReplicating"
	
	# Remove created alias
	Remove-AzureRmServiceBusDRConfiguration -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName2 -Name $drConfigName

	Write-Debug " Delete namespaces"
	# Wait till the Namespace Provisioning  state changes to succeeded
	WaitforStatetoBeSucceded_namespace $resourceGroupName $namespaceName1

    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName1

	# Wait till the Namespace Provisioning  state changes to succeeded
	WaitforStatetoBeSucceded_namespace $resourceGroupName $namespaceName2

    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2
		
}