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
Check the Provisioning state of the created alias and wait till it get succeeded 
#>
function WaitforStatetoBeSucceded 
{
	param([string]$resourceGroupName,[string]$namespaceName,[string]$drConfigName)
	
	$createdDRConfig = Get-AzureRmServiceBusGeoDRConfiguration -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $drConfigName

	while($createdDRConfig.ProvisioningState -ne "Succeeded")
	{
		Wait-Seconds 10
		$createdDRConfig = Get-AzureRmServiceBusGeoDRConfiguration -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $drConfigName
	}

	return $createdDRConfig
}

<#
.SYNOPSIS
Check the Provisioning state of the namespace and wait till it get succeeded 
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
	$location_south = "South Central US" #Get-Location "Microsoft.ServiceBus" "namespaces" "South Central US"
	$location_north = "North Central US" #Get-Location "Microsoft.ServiceBus" "namespaces" "North Central US"
	$resourceGroupName = getAssetName
	$namespaceName1 = getAssetName "ServiceBus-Namespace-"
	$namespaceName2 = getAssetName "ServiceBus-Namespace-"
	$drConfigName = getAssetName "DRConfig-"
	$authRuleName = getAssetName "ServiceBus-Namespace-AuthorizationRule"

	# Create Resource Group
	Write-Debug "Create resource group"
	Write-Debug " Resource Group Name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location_south -Force
	
		
	# Create ServiceBus Namespace - 1
	Write-Debug "  Create new ServiceBus namespace 1"
	Write-Debug " Namespace 1 name : $namespaceName1"
	$result1 = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Location $location_south -SkuName Premium

	# Assert
	Assert-AreEqual $result1.Name $namespaceName1

	# Create ServiceBus Namespace - 2
	Write-Debug "  Create new ServiceBus namespace 2"
	Write-Debug " Namespace 2 name : $namespaceName2"
	$result2 = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Location $location_north -SkuName Premium

	# Assert
	Assert-AreEqual $result2.Name $namespaceName2

	# get the created ServiceBus Namespace  1
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace1 = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1
	
	Assert-AreEqual $createdNamespace1.Name $namespaceName1 "Namespace created earlier is not found."

	# get the created ServiceBus Namespace  2
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace2 = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2
	
	Assert-AreEqual $createdNamespace2.Name $namespaceName2 "Namespace created earlier is not found."

	# Create AuthorizationRule
	Write-Debug "Create a Namespace Authorization Rule"
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzureRmServiceBusAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName1 -Name $authRuleName -Rights @("Listen","Send")
																																	  
    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

	# Check DR Configuration Name Availability

	$checkNameResult = Test-AzureRmServiceBusName -ResourceGroup $resourceGroupName -Namespace $namespaceName1 -AliasName $drConfigName
	Assert-True { $checkNameResult.NameAvailable}

	# Create a DRConfiguration
	Write-Debug " Create new DRConfiguration"
	$result = New-AzureRmServiceBusGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName -PartnerNamespace $createdNamespace2.Id

	# Wait till the Alias Provisioning  state changes to succeeded
	$newDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
	Assert-AreEqual $newDRConfig.Role "Primary"

	# Get AuthorizationRule through DRConfiguration
	Write-Debug "Get Namespace Authorization Rule details"
	Write-Debug "Auth Rule name : $authRuleName"
    $resultAuthRuleDR = Get-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -AliasName $drConfigName -Name $authRuleName

    Assert-AreEqual $authRuleName $resultAuthRuleDR.Name
    Assert-AreEqual 2 $resultAuthRuleDR.Rights.Count
    Assert-True { $resultAuthRuleDR.Rights -Contains "Listen" }
    Assert-True { $resultAuthRuleDR.Rights -Contains "Send" }
	
	# Get the connectionStrings for DRConfiguration

	Write-Debug "Get namespace authorizationRules connectionStrings using DRConfiguration"
    $DRnamespaceListKeys = Get-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -AliasName $drConfigName -Name $authRuleName
	
	Write-Debug " Get the created DRConfiguration"
	$createdDRConfig = Get-AzureRmServiceBusGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName
	# Assert
	Assert-AreEqual $createdDRConfig.PartnerNamespace $createdNamespace2.Id "DRConfig created earlier is not found."
	
	Write-Debug " Get the created DRConfiguration for Secondary Namespace"
	$createdDRConfigSecondary = Get-AzureRmServiceBusGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName2 -Name $drConfigName
	Assert-AreEqual $createdDRConfigSecondary.Role "Secondary"
	
	# Get the Created DRConfiguration
	Write-Debug " Get all the created DRConfiguration"
	$createdServiceBusDRConfigList = Get-AzureRmServiceBusGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1

	# Assert
	Assert-AreEqual $createdServiceBusDRConfigList.Count 1 "ServiceBus DRConfig created earlier is not found in list"

	# BreakPairing on Primary Namespace - Parameters
	Write-Debug "BreakPairing on Primary Namespace"
	Set-AzureRmServiceBusGeoDRConfigurationBreakPair -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName

	# Wait till the Alias Provisioning  state changes to succeeded
	$breakPairingDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
	Assert-AreEqual $breakPairingDRConfig.Role "PrimaryNotReplicating"
		
	# Create a DRConfiguration
	Write-Debug " Create new DRConfiguration"
	$DRresult = New-AzureRmServiceBusGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName -PartnerNamespace $createdNamespace2.Id
	
	# Wait till the Alias Provisioning  state changes to succeeded
	$UpdateDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
	Assert-AreEqual $UpdateDRConfig.Role "Primary"	

	# BreakPairing on Primary Namespace - InputObject
	Write-Debug "BreakPairing on Primary Namespace"
	Set-AzureRmServiceBusGeoDRConfigurationBreakPair -InputObject $DRresult

	# Wait till the Alias Provisioning  state changes to succeeded
	$breakPairingDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
	Assert-AreEqual $breakPairingDRConfig.Role "PrimaryNotReplicating"

	# Create a DRConfiguration
	Write-Debug " Create new DRConfiguration"
	$DRBreakPair_withInputObject = New-AzureRmServiceBusGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName -PartnerNamespace $createdNamespace2.Id
	
	# Wait till the Alias Provisioning  state changes to succeeded
	$UpdateDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
	Assert-AreEqual $UpdateDRConfig.Role "Primary"
	
	# FailOver on Secondary Namespace - Parameters
	Write-Debug "FailOver on Secondary Namespace"
	Set-AzureRmServiceBusGeoDRConfigurationFailOver -ResourceGroupName $resourceGroupName -Namespace $namespaceName2 -Name $drConfigName

	# Wait till the Alias Provisioning  state changes to succeeded
	$failoverDrConfiguration = WaitforStatetoBeSucceded $resourceGroupName $namespaceName2 $drConfigName
	Assert-AreEqual $failoverDrConfiguration.Role "PrimaryNotReplicating"
	Assert-AreEqual $failoverDrConfiguration.PartnerNamespace "" "FaileOver: PartnerNamespace exists"	

	# Create a DRConfiguration
	Write-Debug " Create new DRConfiguration"
	$DRFailOver_withInputObject = New-AzureRmServiceBusGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName2 -Name $drConfigName -PartnerNamespace $createdNamespace1.Id
	
	# Wait till the Alias Provisioning  state changes to succeeded
	$UpdateDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName2 $drConfigName
	Assert-AreEqual $UpdateDRConfig.Role "Primary"

	$DRFailOver_withInputObject = Get-AzureRmServiceBusGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName

	# FailOver on Primary Namespace - InputObject
	Write-Debug "FailOver on Primary Namespace"
	Set-AzureRmServiceBusGeoDRConfigurationFailOver -InputObject $DRFailOver_withInputObject

	# Wait till the Alias Provisioning  state changes to succeeded
	$failoverDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
	Assert-AreEqual $failoverDRConfig.Role "PrimaryNotReplicating"

	# Remove the Alias created
	Remove-AzureRmServiceBusGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName
	Wait-Seconds 120

	# Get the Created GeoDRConfiguration
	Write-Debug " Get all the created GeoDRConfiguration"
	$createdServiceBusDRConfigList_delete = Get-AzureRmServiceBusGeoDRConfiguration -ResourceGroup $resourceGroupName -Namespace $namespaceName1

	# Assert
	Assert-AreEqual $createdServiceBusDRConfigList_delete.Count 0 "DR Config List: after delete the DRCoinfig was listed"

	# Wait till the Namespace Provisioning  state changes to succeeded
	WaitforStatetoBeSucceded_namespace $resourceGroupName $namespaceName1

	Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName1

	# Wait till the Namespace Provisioning  state changes to succeeded
	WaitforStatetoBeSucceded_namespace $resourceGroupName $namespaceName2

	Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}