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
Get valid resource group name
#>
function Get-ResourceGroupName
{
	return "RGName-" + (getAssetName)	 
}

<#
.SYNOPSIS
Get valid WcfRelay name
#>
function Get-HybridConnectionsName
{
    return "HybridConnections-" + (getAssetName)
}

<#
.SYNOPSIS
Get valid Namespace name
#>
function Get-NamespaceName
{
    return "Relay-Namespace-" + (getAssetName)
	
}

<#
.SYNOPSIS
Get valid AuthorizationRule name
#>
function Get-AuthorizationRuleName
{
    return "Relay-HybridConnections-AuthorizationRule" + (getAssetName)
	
}

<#
.SYNOPSIS
Tests HybridConnections Create Get List Remove operations.
#>
function HybridConnectionsTests
{
    # Setup    
    $location = Get-Location
    $resourceGroupName = Get-ResourceGroupName
	$namespaceName = Get-NamespaceName
	$HybridConnectionsName = Get-HybridConnectionsName

	# Create Resource Group
    Write-Debug "Create resource group"    
    Write-Debug " Resource Group Name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	
	    
    # Create Relay Namespace
    Write-Debug "  Create new Relay namespace"
    Write-Debug " Namespace name : $namespaceName"
    $result = New-AzureRmRelayNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -Location $location
    Wait-Seconds 15

	# Assert
	Assert-True {$result.ProvisioningState -eq "Succeeded"}	

	# get the created Relay Namespace 
    Write-Debug " Get the created namespace within the resource group"
    $returnedNamespace = Get-AzureRmRelayNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName    
	# Assert
    Assert-AreEqual $location $returnedNamespace.Location "NameSpace Location Not matched."        
    Assert-True {$returnedNamespace.Name -eq $namespaceName} "Namespace created earlier is not found."
	
	# Create a HybridConnections
    Write-Debug "Create new HybridConnections"
	$userMetadata = "User Meta data"
    $result = New-AzureRmRelayHybridConnections -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $HybridConnectionsName -RequiresClientAuthorization $True -UserMetadata $userMetadata
	
		
    Write-Debug " Get the created HybridConnections "
    $createdHybridConnections = Get-AzureRmRelayHybridConnections -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $HybridConnectionsName

    #Assert
	Assert-True {$createdHybridConnections.Name -eq $HybridConnectionsName} "HybridConnections created earlier is not found."

	# Get the Created HybridConnections
    Write-Debug " Get all the created HybridConnections "
    $createdHybridConnectionsList = Get-AzureRmRelayHybridConnections -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
	    
	#Assert
    Assert-True {$createdHybridConnectionsList[0].Name -eq $HybridConnectionsName }"HybridConnections created earlier is not found."

	# Update the Created HybridConnections
    Write-Debug " Update HybridConnections "
	$createdHybridConnections.UserMetadata = "usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store  descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored."	   
    $result1 = Set-AzureRmRelayHybridConnections -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $HybridConnectionsName -HybridConnectionsObj $createdHybridConnections
    Wait-Seconds 15
	
	# Assert
	Assert-True { $result1.RequiresClientAuthorization -eq $createdHybridConnections.RequiresClientAuthorization } "Updated HybridConnections 'RequiresClientAuthorization' not Matched "
	
	# Cleanup
	# Delete all Created HybridConnections
	Write-Debug " Delete the HybridConnections"
	for ($i = 0; $i -lt $createdHybridConnectionsList.Count; $i++)
	{
		$delete1 = Remove-AzureRmRelayHybridConnections -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $HybridConnectionsName		
	}
    Write-Debug " Delete namespaces"
    Remove-AzureRmRelayNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests HybridConnections AuthorizationRules Create List Remove operations.
#>
function HybridConnectionsAuthTests
{
    # Setup    
    $location =  Get-Location
	$resourceGroupName = Get-ResourceGroupName
	$namespaceName = Get-NamespaceName    
	$HybridConnectionsName = Get-HybridConnectionsName	
    $authRuleName = Get-AuthorizationRuleName

	# Create ResourceGroup
    Write-Debug " Create resource group"    
    Write-Debug "Resource group name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	   
    # Create Relay Namespace
    Write-Debug "  Create new Relay namespace"
    Write-Debug " Namespace name : $namespaceName"
    $result = New-AzureRmRelayNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -Location $location
    Wait-Seconds 15

	# Assert
	Assert-True {$result.ProvisioningState -eq "Succeeded"}	

	# get the created Relay Namespace 
    Write-Debug " Get the created namespace within the resource group"
    $returnedNamespace = Get-AzureRmRelayNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName    
	# Assert
    Assert-AreEqual $location $returnedNamespace.Location "NameSpace Location Not matched."        
    Assert-True {$returnedNamespace.Name -eq $namespaceName} "Namespace created earlier is not found."
	
	# Create a HybridConnections
    Write-Debug "Create new HybridConnections"
	$userMetadata = "User Meta data"
    $result = New-AzureRmRelayHybridConnections -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $HybridConnectionsName -RequiresClientAuthorization $True -UserMetadata $userMetadata
	
		
    Write-Debug " Get the created HybridConnections "
    $createdHybridConnections = Get-AzureRmRelayHybridConnections -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $HybridConnectionsName

    #Assert
	Assert-True {$createdHybridConnections.Name -eq $HybridConnectionsName} "HybridConnections created earlier is not found."

	# Create HybridConnections Authorization Rule
    Write-Debug "Create a HybridConnections Authorization Rule"
    $resultAuthorizationRule = New-AzureRmRelayHybridConnectionsAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $result.Name -AuthorizationRuleName $authRuleName -Rights @("Listen","Send")

	# Assert
    Assert-AreEqual $authRuleName $resultAuthorizationRule.Name
    Assert-AreEqual 2 $resultAuthorizationRule.Rights.Count
    Assert-True { $resultAuthorizationRule.Rights -Contains "Listen" }
    Assert-True { $resultAuthorizationRule.Rights -Contains "Send" }
    Wait-Seconds 15

	# Get Created HybridConnections Authorization Rule
    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmRelayHybridConnectionsAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $result.Name -AuthorizationRule $authRuleName

	# Assert
    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }

	# Get all HybridConnections Authorization Rules
    Write-Debug "Get All HybridConnections AuthorizationRule"
    $resultAuthorizationRule1 = Get-AzureRmRelayHybridConnectionsAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $result.Name
	# Assert
    $found = 0
    
        if ($resultAuthorizationRule1.Name -eq $authRuleName)
        {
            $found = 1
            Assert-AreEqual 2 $resultAuthorizationRule1.Rights.Count
            Assert-True { $resultAuthorizationRule1.Rights -Contains "Listen" }
            Assert-True { $resultAuthorizationRule1.Rights -Contains "Send" }         
            Assert-True {$found -eq 1} "HybridConnections AuthorizationRule created earlier is not found."
        }
    

	# Update the HybridConnections Authorization Rule
    Write-Debug "Update HybridConnections AuthorizationRule"
	$createdAuthRule.Rights.Add("Manage")
    $updatedAuthRule = Set-AzureRmRelayHybridConnectionsAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $result.Name -AuthorizationRuleName $authRuleName -AuthRuleObj $createdAuthRule
    Wait-Seconds 15

	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	   
    # get the Updated HybridConnections Authorization Rule
    $updatedAuthRule = Get-AzureRmRelayHybridConnectionsAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $result.Name -AuthorizationRuleName $authRuleName
    
	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	
	# Get the List Keys
    Write-Debug "Get HybridConnections authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmRelayHybridConnectionsKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $result.Name -AuthorizationRuleName $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}
	
	# Regentrate the Keys 
	$policyKey = "PrimaryKey"

	$namespaceRegenerateKeys = New-AzureRmRelayHybridConnectionsKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $result.Name -AuthorizationRuleName $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzureRmRelayHybridConnectionsKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $result.Name -AuthorizationRuleName $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}
	
	# Cleanup
    Write-Debug "Delete the created HybridConnections AuthorizationRule"
    $resultDelete = Remove-AzureRmRelayHybridConnectionsAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $result.Name -AuthorizationRuleName $authRuleName
    
    Write-Debug "Delete the HybridConnections"
    Remove-AzureRmRelayHybridConnections -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -HybridConnectionsName $result.Name
    
    Write-Debug "Delete NameSpace"
    Remove-AzureRmRelayNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}