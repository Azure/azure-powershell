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
Tests AuthorizationRules Create List Remove operations.
#>
function RelayAuthTests
{
    # Setup    
    $location =  "West US"
	$resourceGroupName = getAssetName
	$namespaceName = getAssetName "Relay-NS"
	$wcfRelayName = getAssetName "Relay-WcfR"	
	$HybridConnectionsName = getAssetName "Relay-HybrdCon"
    $authRuleName = getAssetName "Relay-NSAuthoRule"
	$WcfRelayAuthRuleName = getAssetName "WcfR-AuthoRule"
	$HybirdConnectionAuthRuleName = getAssetName "HybrdCon-AuthoRule"
	$keyValue = "YskcXxK7Jk0qeOPlISv8J/JFHU5pGFfxI4p0W1voKIc="

	# Create ResourceGroup
    Write-Debug " Create resource group"    
    Write-Debug "Resource group name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
	   
    # Create Relay Namespace 
    Write-Debug " Create new Relay namespace"
    Write-Debug "Namespace name : $namespaceName"
    $result = New-AzRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -Location $location
    Wait-Seconds 15
    
	# Assert
	Assert-True {$result.ProvisioningState -eq "Succeeded"}

	Try
	{
		# Get Created NameSpace
		Write-Debug " Get the created namespace within the resource group"
		$createdNamespace = Get-AzRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    
		# Assert
		Assert-True {$createdNamespace.Name -eq $namespaceName} "Namespace created earlier is not found."

		## Create a WcfRelay
		Write-Debug " Create new WcfRelay "    
		$wcfRelayType = "NetTcp"
		$userMetadata = "usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store  descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored."
		$resultWcfRelay = New-AzWcfRelay -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $wcfRelayName -WcfRelayType $wcfRelayType  -RequiresClientAuthorization $true -RequiresTransportSecurity $true -UserMetadata $userMetadata
			
		Write-Debug " Get the created WcfRelay"
		$createdWcfRelay = Get-AzWcfRelay -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $resultWcfRelay.Name

		# Assert
		Assert-True {$createdWcfRelay.Name -eq $wcfRelayName} "WcfRelay created earlier is not found."  

		# Create a HybridConnections
		Write-Debug "Create new HybridConnections"
		$userMetadata = "User Meta data"
		$resultHybirdconnection = New-AzRelayHybridConnection -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $HybridConnectionsName -RequiresClientAuthorization $True -UserMetadata $userMetadata
	
		
		Write-Debug " Get the created HybridConnections "
		$createdHybridConnections = Get-AzRelayHybridConnection -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $HybridConnectionsName

		#Assert
		Assert-True {$createdHybridConnections.Name -eq $HybridConnectionsName} "HybridConnections created earlier is not found."
	
		#Create Namespace AuthorizationRule 
		Write-Debug "Create a WcfRelay Authorization Rule"
		$result = New-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights "Send"

		# Assert
		Assert-AreEqual $authRuleName $result.Name
		Assert-True { $result.Rights -Contains "Send" }
		Wait-Seconds 15

		# get the Updated Namespace Authorization Rule
		$getAuthRule = Get-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName 

		$getAuthRule.Rights.Add("Listen")

		# Update the Namespace Authorization Rule
		Write-Debug "Update Namespace AuthorizationRule"
		$updatedAuthRule = Set-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -InputObject $getAuthRule
		Wait-Seconds 15

		# get the Updated Namespace Authorization Rule
		$getAuthRule1 = Get-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName 

		# Create WcfRelay Authorization Rule
		Write-Debug "Create a WcfRelay Authorization Rule"
		$result = New-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -WcfRelay $wcfRelayName -Name $WcfRelayAuthRuleName -Rights "Listen","Send"

		# Assert
		Assert-AreEqual $WcfRelayAuthRuleName $result.Name
		Assert-True { $result.Rights -Contains "Listen" }
		Assert-True { $result.Rights -Contains "Send" }
		Wait-Seconds 15

		# Get Created HybridConnection Authorization Rule
		Write-Debug "Get created authorizationRule"
		$createdAuthRule = New-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -HybridConnection $HybridConnectionsName -Name $HybirdConnectionAuthRuleName -Rights "Listen","Send"

		# Assert
		Assert-AreEqual $HybirdConnectionAuthRuleName $createdAuthRule.Name
		Assert-True { $createdAuthRule.Rights -Contains "Listen" }
		Assert-True { $createdAuthRule.Rights -Contains "Send" }

	
		# Get all Namespace Authorization Rules
		Write-Debug "Get All WcfRelay AuthorizationRule"
		$result = Get-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName
		# Assert
		$found = 0
    
			if ($result.Name -eq $authRuleName)
			{
				$found = 1
				Assert-True { $result.Rights -Contains "Listen" }
				Assert-True { $result.Rights -Contains "Send" }         
				Assert-True {$found -eq 1} "Namespace AuthorizationRule created earlier is not found."
			}
    
		# Get all WcfRelay Authorization Rules
		Write-Debug "Get All WcfRelay AuthorizationRule"
		$resultWcfRelayAuthoRuleList = Get-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -WcfRelay $wcfRelayName
		# Assert
		$found = 0
    
			if ($resultWcfRelayAuthoRuleList.Name -eq $WcfRelayAuthRuleName)
			{
				$found = 1
				Assert-True { $resultWcfRelayAuthoRuleList.Rights -Contains "Listen" }
				Assert-True { $resultWcfRelayAuthoRuleList.Rights -Contains "Send" }         
				Assert-True {$found -eq 1} "WcfRelay AuthorizationRule created earlier is not found."
			}


		# Get all HybirdConnection Authorization Rules
		Write-Debug "Get All WcfRelay AuthorizationRule"
		$resultHybirdConnectionAuthoRuleList = Get-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -HybridConnection $HybridConnectionsName 
		# Assert
		$found = 0
    
			if ($resultHybirdConnectionAuthoRuleList.Name -eq $HybirdConnectionAuthRuleName)
			{
				$found = 1
				Assert-True { $resultHybirdConnectionAuthoRuleList.Rights -Contains "Listen" }
				Assert-True { $resultHybirdConnectionAuthoRuleList.Rights -Contains "Send" }         
				Assert-True {$found -eq 1} "WcfRelay AuthorizationRule created earlier is not found."
			}
    
		# Update the Namespace Authorization Rule
		Write-Debug "Update Namespace AuthorizationRule"
		$updatedAuthRule = Set-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights "Listen","Manage","Send"
		Wait-Seconds 15

		# Assert
		Assert-AreEqual $authRuleName $updatedAuthRule.Name
		Assert-AreEqual 3 $updatedAuthRule.Rights.Count
		Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
		Assert-True { $updatedAuthRule.Rights -Contains "Send" }
		Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	   
		# get the Updated Namespace Authorization Rule
		$updatedAuthRule = Get-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName 
    
		# Assert
		Assert-AreEqual $authRuleName $updatedAuthRule.Name
		Assert-AreEqual 3 $updatedAuthRule.Rights.Count
		Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
		Assert-True { $updatedAuthRule.Rights -Contains "Send" }
		Assert-True { $updatedAuthRule.Rights -Contains "Manage" }


		# Update the WcfRelay Authorization Rule
		Write-Debug "Update WcfRelay AuthorizationRule"
		$updatedWcfRelayAuthRule = Set-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -WcfRelay $wcfRelayName -Name $WcfRelayAuthRuleName -Rights "Listen","Send", "Manage"
		Wait-Seconds 15

		# Assert
		Assert-AreEqual $WcfRelayAuthRuleName $updatedWcfRelayAuthRule.Name
		Assert-AreEqual 3 $updatedWcfRelayAuthRule.Rights.Count
		Assert-True { $updatedWcfRelayAuthRule.Rights -Contains "Listen" }
		Assert-True { $updatedWcfRelayAuthRule.Rights -Contains "Send" }
		Assert-True { $updatedWcfRelayAuthRule.Rights -Contains "Manage" }
	   
		# get the Updated WcfRelay Authorization Rule
		$updatedWcfRelayAuthRule1 = Get-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -WcfRelay $wcfRelayName -Name $WcfRelayAuthRuleName
    
		# Assert
		Assert-AreEqual $WcfRelayAuthRuleName $updatedWcfRelayAuthRule1.Name
		Assert-AreEqual 3 $updatedWcfRelayAuthRule1.Rights.Count
		Assert-True { $updatedWcfRelayAuthRule1.Rights -Contains "Listen" }
		Assert-True { $updatedWcfRelayAuthRule1.Rights -Contains "Send" }
		Assert-True { $updatedWcfRelayAuthRule1.Rights -Contains "Manage" }



		# Update the HybirdConnection Authorization Rule
		Write-Debug "Update HybirdConnection AuthorizationRule"
		$updatedHybirdConnectionAuthRule = Set-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -HybridConnection $HybridConnectionsName -Name $HybirdConnectionAuthRuleName -Rights "Listen","Send", "Manage"
		Wait-Seconds 15

		# Assert
		Assert-AreEqual $HybirdConnectionAuthRuleName $updatedHybirdConnectionAuthRule.Name
		Assert-AreEqual 3 $updatedHybirdConnectionAuthRule.Rights.Count
		Assert-True { $updatedHybirdConnectionAuthRule.Rights -Contains "Listen" }
		Assert-True { $updatedHybirdConnectionAuthRule.Rights -Contains "Send" }
		Assert-True { $updatedHybirdConnectionAuthRule.Rights -Contains "Manage" }
	   
		# get the Updated HybridConnection Authorization Rule
		$updatedHybirdConnectionAuthRule1 = Get-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -HybridConnection $HybridConnectionsName -Name $HybirdConnectionAuthRuleName
    
		# Assert
		Assert-AreEqual $HybirdConnectionAuthRuleName $updatedHybirdConnectionAuthRule1.Name
		Assert-AreEqual 3 $updatedHybirdConnectionAuthRule1.Rights.Count
		Assert-True { $updatedHybirdConnectionAuthRule1.Rights -Contains "Listen" }
		Assert-True { $updatedHybirdConnectionAuthRule1.Rights -Contains "Send" }
		Assert-True { $updatedHybirdConnectionAuthRule1.Rights -Contains "Manage" }

		# Get the List Keys - Namespace
		Write-Debug "Get WcfRelay authorizationRules connectionStrings"
		$namespaceListKeys = Get-AzRelayKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName

		Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($namespaceListKeys.PrimaryKey)}
		Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($namespaceListKeys.SecondaryKey)}
	
		# Regentrate the Keys 
		$policyKey = "PrimaryKey"

		$namespaceRegenerateKeys = New-AzRelayKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey -KeyValue $keyValue
		Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}
		Assert-AreEqual $namespaceRegenerateKeys.PrimaryKey $keyValue

		$policyKey1 = "SecondaryKey"

		$namespaceRegenerateKeys1 = New-AzRelayKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey1 -KeyValue $keyValue
		Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}
		Assert-AreEqual $namespaceRegenerateKeys1.SecondaryKey $keyValue


	
		# Get the List Keys - WcfRelay
		Write-Debug "Get WcfRelay authorizationRules connectionStrings"
		$WcfRelayListKeys = Get-AzRelayKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -WcfRelay $wcfRelayName -Name $WcfRelayAuthRuleName

		Assert-True {$WcfRelayListKeys.PrimaryConnectionString.Contains($WcfRelayListKeys.PrimaryKey)}
		Assert-True {$WcfRelayListKeys.SecondaryConnectionString.Contains($WcfRelayListKeys.SecondaryKey)}
	
		# Regentrate the Keys 
		$policyKey = "PrimaryKey"

		$WcfRelayRegenerateKeys = New-AzRelayKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -WcfRelay $wcfRelayName -Name $WcfRelayAuthRuleName -RegenerateKey $policyKey -KeyValue $keyValue
		Assert-True {$WcfRelayRegenerateKeys.PrimaryKey -ne $WcfRelayListKeys.PrimaryKey}
		Assert-AreEqual $WcfRelayRegenerateKeys.PrimaryKey $keyValue

		$policyKey1 = "SecondaryKey"

		$WcfRelayRegenerateKeys1 = New-AzRelayKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -WcfRelay $wcfRelayName -Name $WcfRelayAuthRuleName -RegenerateKey $policyKey1 -KeyValue $keyValue
		Assert-True {$WcfRelayRegenerateKeys1.SecondaryKey -ne $WcfRelayListKeys.SecondaryKey}
		Assert-AreEqual $WcfRelayRegenerateKeys1.SecondaryKey $keyValue

		# Get the List Keys - HybirdConnection
		Write-Debug "Get WcfRelay authorizationRules connectionStrings"
		$HybirdConnectionListKeys = Get-AzRelayKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -HybridConnection $HybridConnectionsName -Name $HybirdConnectionAuthRuleName

		Assert-True {$HybirdConnectionListKeys.PrimaryConnectionString.Contains($HybirdConnectionListKeys.PrimaryKey)}
		Assert-True {$HybirdConnectionListKeys.SecondaryConnectionString.Contains($HybirdConnectionListKeys.SecondaryKey)}
	
		# Regentrate the Keys 
		$policyKey = "PrimaryKey"

		$HybirdConnectionRegenerateKeys = New-AzRelayKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -HybridConnection $HybridConnectionsName -Name $HybirdConnectionAuthRuleName -RegenerateKey $policyKey -KeyValue $keyValue
		Assert-True {$HybirdConnectionRegenerateKeys.PrimaryKey -ne $HybirdConnectionListKeys.PrimaryKey}
		Assert-AreEqual $HybirdConnectionRegenerateKeys.PrimaryKey $keyValue

		$policyKey1 = "SecondaryKey"

		$HybirdConnectionRegenerateKeys1 = New-AzRelayKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -HybridConnection $HybridConnectionsName -Name $HybirdConnectionAuthRuleName -RegenerateKey $policyKey1 -KeyValue $keyValue
		Assert-True {$HybirdConnectionRegenerateKeys1.SecondaryKey -ne $HybirdConnectionListKeys.SecondaryKey}
		Assert-AreEqual $HybirdConnectionRegenerateKeys1.SecondaryKey $keyValue
	

		# Cleanup
		Write-Debug "Delete the created Namespace AuthorizationRule"
		$result = Remove-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Force

		Write-Debug "Delete the created WcfRelay AuthorizationRule"
		$result = Remove-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -WcfRelay $wcfRelayName -Name $WcfRelayAuthRuleName -Force

		Write-Debug "Delete the created HybridConnection AuthorizationRule"
		$result = Remove-AzRelayAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -HybridConnection $HybridConnectionsName -Name $HybirdConnectionAuthRuleName -Force
    

		Write-Debug "Delete the WcfRelay"
		Remove-AzRelayHybridConnection -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $HybridConnectionsName
    
		Write-Debug "Delete the WcfRelay"
		Remove-AzWcfRelay -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $wcfRelayName
	}
	Finally
	{
		Write-Debug "Delete NameSpace"
		Remove-AzRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

		Write-Debug " Delete resourcegroup"
		Remove-AzResourceGroup -Name $resourceGroupName -Force
	}        
}