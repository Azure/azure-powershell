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
	
	$createdDRConfig = Get-AzEventHubGeoDRConfiguration -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $drConfigName

	while($createdDRConfig.ProvisioningState -ne "Succeeded")
	{
		Wait-Seconds 10
		$createdDRConfig = Get-AzEventHubGeoDRConfiguration -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $drConfigName
	}

	while($createdDRConfig.PendingReplicationOperationsCount -ne $null -and $createdDRConfig.PendingReplicationOperationsCount -gt 0)
	{
		Wait-Seconds 10
		$createdDRConfig = Get-AzEventHubGeoDRConfiguration -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $drConfigName
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
	
	$Getnamespace = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName 

	while($Getnamespace.ProvisioningState -ne "Succeeded")
	{
		Wait-Seconds 10
		$Getnamespace = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
	}

}

<#
.SYNOPSIS
Tests EventHubs DRConfiguration Create List Remove operations.
#>

function DRConfigurationTests
{
	# Setup
	$location_south =  Get-Location "Microsoft.ServiceBus" "namespaces" "South Central US"
	$location_north = Get-Location "Microsoft.ServiceBus" "namespaces" "North Central US"
	$resourceGroupName = getAssetName
	$namespaceName1 = getAssetName "Eventhub-Namespace-"
	$namespaceName2 = getAssetName "Eventhub-Namespace-"
	$drConfigName = getAssetName "DRConfig-"
	$authRuleName = getAssetName "Eventhub-Namespace-AuthorizationRule"

	# Create Resource Group
	Write-Debug "Create resource group"
	Write-Debug " Resource Group Name : $resourceGroupName"
	New-AzResourceGroup -Name $resourceGroupName -Location $location_south -Force
	
		
	# Create EventHub Namespace - 1
	Write-Debug "  Create new eventhub namespace 1"
	Write-Debug " Namespace 1 name : $namespaceName1"
	$result1 = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Location $location_south

	# Assert
	Assert-AreEqual $result1.Name $namespaceName1


	# Create EventHub Namespace - 2
	Write-Debug "  Create new eventhub namespace 2"
	Write-Debug " Namespace 2 name : $namespaceName2"
	$result2 = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Location $location_north

	# Assert
	Assert-AreEqual $result2.Name $namespaceName2

	# get the created Eventhub Namespace  1
		Write-Debug " Get the created namespace within the resource group"
		$createdNamespace1 = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1
	
		Assert-AreEqual $createdNamespace1.Name $namespaceName1 "Namespace created earlier is not found."

		# get the created Eventhub Namespace  2
		Write-Debug " Get the created namespace within the resource group"
		$createdNamespace2 = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2
	
		Assert-AreEqual $createdNamespace2.Name $namespaceName2 "Namespace created earlier is not found."

		# Create AuthorizationRule
		Write-Debug "Create a Namespace Authorization Rule"
		Write-Debug "Auth Rule name : $authRuleName"
		$result = New-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName1 -Name $authRuleName -Rights @("Listen","Send")
																																	  
		Assert-AreEqual $authRuleName $result.Name
		Assert-AreEqual 2 $result.Rights.Count
		Assert-True { $result.Rights -Contains "Listen" }
		Assert-True { $result.Rights -Contains "Send" }

		# Create 30 Eventhubs under Primary namespace
		for($count = 0; $count -lt 10; $count++)
		{
			$eventhubname = getAssetName "EventHub-"
			$eventhubname = New-AzEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName1 -Name $eventhubname
		}

		# Check DR Configuration Name Availability

		$checkNameResult = Test-AzEventHubName -ResourceGroup $resourceGroupName -Namespace $namespaceName1 -AliasName $drConfigName
		Assert-True { $checkNameResult.NameAvailable}

		# Create a DRConfiguration
		Write-Debug " Create new DRConfiguration"
		$result = New-AzEventHubGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName -PartnerNamespace $createdNamespace2.Id

		# Wait till the Alias Provisioning  state changes to succeeded
		$newDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
		Assert-AreEqual $newDRConfig.Role "Primary"

		# Get AuthorizationRule through DRConfiguration
		Write-Debug "Get Namespace Authorization Rule details"
		Write-Debug "Auth Rule name : $authRuleName"
		$resultAuthRuleDR = Get-AzEventHubAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -AliasName $drConfigName -Name $authRuleName

		Assert-AreEqual $authRuleName $resultAuthRuleDR.Name
		Assert-AreEqual 2 $resultAuthRuleDR.Rights.Count
		Assert-True { $resultAuthRuleDR.Rights -Contains "Listen" }
		Assert-True { $resultAuthRuleDR.Rights -Contains "Send" }
	
		# Get the connectionStrings for DRConfiguration

		Write-Debug "Get namespace authorizationRules connectionStrings using DRConfiguration"
		$DRnamespaceListKeys = Get-AzEventHubKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -AliasName $drConfigName -Name $authRuleName
	
		Write-Debug " Get the created DRConfiguration"
		$createdDRConfig = Get-AzEventHubGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName
		# Assert
		Assert-AreEqual $createdDRConfig.PartnerNamespace $createdNamespace2.Id "DRConfig created earlier is not found."

		Write-Debug "Get the created DRConfiguration using Namespace object"
		$createdDRConfig = Get-AzEventHubGeoDRConfiguration -InputObject $createdNamespace1 -Name $drConfigName
		# Assert
		Assert-AreEqual $createdDRConfig.PartnerNamespace $createdNamespace2.Id "DRConfig created earlier is not found."
	
		Write-Debug " Get the created DRConfiguration for Secondary Namespace"
		$createdDRConfigSecondary = Get-AzEventHubGeoDRConfiguration -ResourceId $createdNamespace2.Id -Name $drConfigName
		Assert-AreEqual $createdDRConfigSecondary.Role "Secondary"
	
		# Get the Created DRConfiguration using Namespace ResourceId
		Write-Debug " Get all the created DRConfiguration using Namespace ResourceId"
		$createdEventHubDRConfigList = Get-AzEventHubGeoDRConfiguration -ResourceId $createdNamespace1.Id

		# Assert
		Assert-AreEqual $createdEventHubDRConfigList.Count 1 "EventHub DRConfig created earlier is not found in list"

		# BreakPairing on Primary Namespace - Parameters
		Write-Debug "BreakPairing on Primary Namespace"
		Set-AzEventHubGeoDRConfigurationBreakPair -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName

		# Wait till the Alias Provisioning  state changes to succeeded
		$breakPairingDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
		Assert-AreEqual $breakPairingDRConfig.Role "PrimaryNotReplicating"

		#Remove the created Eventhubs from Secondary Namespace 
		$getCreatedEventhubs = Get-AzEventHub -ResourceGroupName  $resourceGroupName -Namespace $createdNamespace2.Name

		foreach($eventhub in $getCreatedEventhubs)
		{
			Remove-AzEventHub -ResourceGroupName  $resourceGroupName -Namespace $createdNamespace2.Name -Name $eventhub.Name
		}
		
		# Create a DRConfiguration
		Write-Debug " Create new DRConfiguration using Namespace object"
		$DRresult = New-AzEventHubGeoDRConfiguration -InputObject $createdNamespace1 -Name $drConfigName -PartnerNamespace $createdNamespace2.Id
	
		# Wait till the Alias Provisioning  state changes to succeeded
		$UpdateDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
		Assert-AreEqual $UpdateDRConfig.Role "Primary"	

		# BreakPairing on Primary Namespace - InputObject
		Write-Debug "BreakPairing on Primary Namespace"
		Set-AzEventHubGeoDRConfigurationBreakPair -InputObject $DRresult

		# Wait till the Alias Provisioning  state changes to succeeded
		$breakPairingDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
		Assert-AreEqual $breakPairingDRConfig.Role "PrimaryNotReplicating"

		#Remove the created Eventhubs from Secondary Namespace 
		$getCreatedEventhubs = Get-AzEventHub -ResourceGroupName  $resourceGroupName -Namespace $createdNamespace2.Name

		foreach($eventhub in $getCreatedEventhubs)
		{
			Remove-AzEventHub -ResourceGroupName  $resourceGroupName -Namespace $createdNamespace2.Name -Name $eventhub.Name
		}

		# Create a DRConfiguration
		Write-Debug " Create new DRConfiguration"
		$DRBreakPair_withInputObject = New-AzEventHubGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName -PartnerNamespace $createdNamespace2.Id
	
		# Wait till the Alias Provisioning  state changes to succeeded
		$UpdateDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
		Assert-AreEqual $UpdateDRConfig.Role "Primary"
	
		# FailOver on Secondary Namespace - Parameters
		Write-Debug "FailOver on Secondary Namespace"
		Set-AzEventHubGeoDRConfigurationFailOver -ResourceGroupName $resourceGroupName -Namespace $namespaceName2 -Name $drConfigName

		# Wait till the Alias Provisioning  state changes to succeeded
		$failoverDrConfiguration = WaitforStatetoBeSucceded $resourceGroupName $namespaceName2 $drConfigName
		Assert-AreEqual $failoverDrConfiguration.Role "PrimaryNotReplicating"
		Assert-AreEqual $failoverDrConfiguration.PartnerNamespace "" "FaileOver: PartnerNamespace exists"

		#Remove the created Eventhubs from Secondary Namespace 
		$getCreatedEventhubs = Get-AzEventHub -ResourceGroupName  $resourceGroupName -Namespace $createdNamespace1.Name

		foreach($eventhub in $getCreatedEventhubs)
		{
			Remove-AzEventHub -ResourceGroupName  $resourceGroupName -Namespace $createdNamespace1.Name -Name $eventhub.Name
		}

		# Create a DRConfiguration
		Write-Debug " Create new DRConfiguration"
		$DRFailOver_withInputObject = New-AzEventHubGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName2 -Name $drConfigName -PartnerNamespace $createdNamespace1.Id
	
		# Wait till the Alias Provisioning  state changes to succeeded
		$UpdateDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName2 $drConfigName
		Assert-AreEqual $UpdateDRConfig.Role "Primary"

		$DRFailOver_withInputObject = Get-AzEventHubGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName

		# FailOver on Primary Namespace - InputObject
		Write-Debug "FailOver on Primary Namespace"
		Set-AzEventHubGeoDRConfigurationFailOver -InputObject $DRFailOver_withInputObject

		# Wait till the Alias Provisioning  state changes to succeeded
		$failoverDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
		Assert-AreEqual $failoverDRConfig.Role "PrimaryNotReplicating"

		# Remove the Alias created
		Remove-AzEventHubGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName
		Wait-Seconds 120

		# Get the Created GeoDRConfiguration
		Write-Debug " Get all the created GeoDRConfiguration"
		$createdServiceBusDRConfigList_delete = Get-AzEventHubGeoDRConfiguration -ResourceGroup $resourceGroupName -Namespace $namespaceName1

		# Assert
		Assert-AreEqual $createdServiceBusDRConfigList_delete.Count 0 "DR Config List: after delete the DRCoinfig was listed"
		# Wait till the Namespace Provisioning  state changes to succeeded
		WaitforStatetoBeSucceded_namespace $resourceGroupName $namespaceName1

		Write-Debug " Delete namespaces"
		Remove-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName1

		# Wait till the Namespace Provisioning  state changes to succeeded\
		WaitforStatetoBeSucceded_namespace $resourceGroupName $namespaceName2

		Write-Debug " Delete namespaces"
		Remove-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2

		Write-Debug " Delete resourcegroup"
		Remove-AzResourceGroup -Name $resourceGroupName -Force
}

function DRConfigurationTestsAlternateName
{
	# Setup
	$location_south =  Get-Location "Microsoft.ServiceBus" "namespaces" "South Central US"
	$location_north = Get-Location "Microsoft.ServiceBus" "namespaces" "North Central US"
	$resourceGroupName = getAssetName
	$namespaceName1 = getAssetName "Eventhub-Namespace-"
	$namespaceName2 = getAssetName "Eventhub-Namespace-"
	$drConfigName = $namespaceName1 
	$authRuleName = getAssetName "Eventhub-Namespace-AuthorizationRule"
	$AlternateName = getAssetName "AlternateName"

	# Create Resource Group
	Write-Debug "Create resource group"
	Write-Debug " Resource Group Name : $resourceGroupName"
	New-AzResourceGroup -Name $resourceGroupName -Location $location_south -Force
	
		
	# Create EventHub Namespace - 1
	Write-Debug "  Create new eventhub namespace 1"
	Write-Debug " Namespace 1 name : $namespaceName1"
	$result1 = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Location $location_south

	# Assert
	Assert-AreEqual $result1.Name $namespaceName1


	# Create EventHub Namespace - 2
	Write-Debug "  Create new eventhub namespace 2"
	Write-Debug " Namespace 2 name : $namespaceName2"
	$result2 = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Location $location_north

	# Assert
	Assert-AreEqual $result2.Name $namespaceName2

	# get the created Eventhub Namespace  1
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace1 = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1
	
	Assert-AreEqual $createdNamespace1.Name $namespaceName1 "Namespace created earlier is not found."

	# get the created Eventhub Namespace  2
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace2 = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2
	
	Assert-AreEqual $createdNamespace2.Name $namespaceName2 "Namespace created earlier is not found."

	# Create AuthorizationRule
	Write-Debug "Create a Namespace Authorization Rule"
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName1 -Name $authRuleName -Rights @("Listen","Send")
																																	  
    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

	# Check DR Configuration Name Availability

	$checkNameResult = Test-AzEventHubName -ResourceGroup $resourceGroupName -Namespace $namespaceName1 -AliasName $drConfigName
	Assert-True { $checkNameResult.NameAvailable}

	# Create a DRConfiguration
	Write-Debug " Create new DRConfiguration"
	$result = New-AzEventHubGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName -PartnerNamespace $createdNamespace2.Id -AlternateName $AlternateName

	# Wait till the Alias Provisioning  state changes to succeeded
	$newDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
	Assert-AreEqual $newDRConfig.Role "Primary"

	# Get AuthorizationRule through DRConfiguration
	Write-Debug "Get Namespace Authorization Rule details"
	Write-Debug "Auth Rule name : $authRuleName"
    $resultAuthRuleDR = Get-AzEventHubAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -AliasName $drConfigName -Name $authRuleName

    Assert-AreEqual $authRuleName $resultAuthRuleDR.Name
    Assert-AreEqual 2 $resultAuthRuleDR.Rights.Count
    Assert-True { $resultAuthRuleDR.Rights -Contains "Listen" }
    Assert-True { $resultAuthRuleDR.Rights -Contains "Send" }
	
	# Get the connectionStrings for DRConfiguration

	Write-Debug "Get namespace authorizationRules connectionStrings using DRConfiguration"
    $DRnamespaceListKeys = Get-AzEventHubKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -AliasName $drConfigName -Name $authRuleName
	
	Write-Debug " Get the created DRConfiguration"
	$createdDRConfig = Get-AzEventHubGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName
	# Assert
	Assert-AreEqual $createdDRConfig.PartnerNamespace $createdNamespace2.Id "DRConfig created earlier is not found."	
	
	Write-Debug " Get the created DRConfiguration for Secondary Namespace"
	$createdDRConfigSecondary = Get-AzEventHubGeoDRConfiguration -ResourceId $createdNamespace2.Id -Name $drConfigName
	Assert-AreEqual $createdDRConfigSecondary.Role "Secondary"
	

	# BreakPairing on Primary Namespace - Parameters
	Write-Debug "BreakPairing on Primary Namespace"
	Set-AzEventHubGeoDRConfigurationBreakPair -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName

	# Wait till the Alias Provisioning  state changes to succeeded
	$breakPairingDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
	Assert-AreEqual $breakPairingDRConfig.Role "PrimaryNotReplicating"

	# Create a DRConfiguration
	Write-Debug " Create new DRConfiguration"
	$DRBreakPair_withInputObject = New-AzEventHubGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $drConfigName -PartnerNamespace $createdNamespace2.Id -AlternateName $AlternateName
	
	# Wait till the Alias Provisioning  state changes to succeeded
	$UpdateDRConfig = WaitforStatetoBeSucceded $resourceGroupName $namespaceName1 $drConfigName
	Assert-AreEqual $UpdateDRConfig.Role "Primary"
	
	# FailOver on Secondary Namespace - Parameters
	Write-Debug "FailOver on Secondary Namespace"
	Set-AzEventHubGeoDRConfigurationFailOver -ResourceGroupName $resourceGroupName -Namespace $namespaceName2 -Name $drConfigName

	# Wait till the Alias Provisioning  state changes to succeeded
	$failoverDrConfiguration = WaitforStatetoBeSucceded $resourceGroupName $namespaceName2 $drConfigName
	Assert-AreEqual $failoverDrConfiguration.Role "PrimaryNotReplicating"
	Assert-AreEqual $failoverDrConfiguration.PartnerNamespace "" "FaileOver: PartnerNamespace exists"	
	
	# Remove the Alias created
	Remove-AzEventHubGeoDRConfiguration -ResourceGroupName $resourceGroupName -Namespace $namespaceName2 -Name $drConfigName
	Wait-Seconds 180

	# Get the Created GeoDRConfiguration
	Write-Debug " Get all the created GeoDRConfiguration"
	$createdServiceBusDRConfigList_delete = Get-AzEventHubGeoDRConfiguration -ResourceGroup $resourceGroupName -Namespace $namespaceName1

	# Assert
	Assert-AreEqual $createdServiceBusDRConfigList_delete.Count 0 "DR Config List: after delete the DRCoinfig was listed"

	# Wait till the Namespace Provisioning  state changes to succeeded
	WaitforStatetoBeSucceded_namespace $resourceGroupName $namespaceName1

	Write-Debug " Delete namespaces"
    Remove-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName1

	# Wait till the Namespace Provisioning  state changes to succeeded\
	WaitforStatetoBeSucceded_namespace $resourceGroupName $namespaceName2

	Write-Debug " Delete namespaces"
    Remove-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2

	Write-Debug " Delete resourcegroup"
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}