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
function Get-WcfRelayName
{
    return "WcfRelay-" + (getAssetName)
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
    return "Relay-WcfRelay-AuthorizationRule" + (getAssetName)
	
}


<#
.SYNOPSIS
Tests WcfRelay Create List Remove operations.
#>
function WcfRelayTests
{
    # Setup    
    $location = Get-Location
    $resourceGroupName = Get-ResourceGroupName
	$namespaceName = Get-NamespaceName
	$wcfRelayName = Get-WcfRelayName

	# Create Resource Group
    Write-Debug "Create resource group"    
    Write-Debug " Resource Group Name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	
	    
    # Create Relay Namespace
    Write-Debug "  Create new Relay namespace"
    Write-Debug " Namespace name : $namespaceName"
    $result = New-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Location $location
    Wait-Seconds 15

	# Assert
	Assert-True {$result.ProvisioningState -eq "Succeeded"}	

	# get the created Relay Namespace 
    Write-Debug " Get the created namespace within the resource group"
    $returnedNamespace = Get-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName    
	# Assert
    Assert-AreEqual $location $returnedNamespace.Location "NameSpace Location Not matched."        
    Assert-True {$returnedNamespace.Name -eq $namespaceName} "Namespace created earlier is not found."
	
	# Create a WcfRelay
    Write-Debug "Create new WcfRelay"    
	$wcfRelayType = "NetTcp"
	$userMetadata = "User Meta data"
    $result = New-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $wcfRelayName -WcfRelayType $wcfRelayType  -RequiresClientAuthorization $True -RequiresTransportSecurity $True -UserMetadata $userMetadata
	
		
    Write-Debug " Get the created WcfRelay "
    $createdWcfRelay = Get-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $wcfRelayName

    # Assert
	Assert-True {$createdWcfRelay.Name -eq $wcfRelayName} "WcfRelay created earlier is not found."

	# Get the Created WcfRelay
    Write-Debug " Get all the created WcfRelay "
    $createdWcfRelayList = Get-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
	    
	# Assert
    Assert-True {$createdWcfRelayList[0].Name -eq $wcfRelayName }"WcfRelay created earlier is not found."

	# Update the Created WcfRelay
    Write-Debug " Update the first WcfRelay "
	$createdWcfRelay.UserMetadata = "usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store  descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored."	   
    $result1 = Set-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $wcfRelayName -WcfRelayObj $createdWcfRelay
    Wait-Seconds 15
	
	# Assert
	Assert-True { $result1.RequiresClientAuthorization -eq $createdWcfRelay.RequiresClientAuthorization } "Updated WCFRelay 'RequiresClientAuthorization' not Matched "
	
	# Cleanup
	# Delete all Created WcfRelay
	Write-Debug " Delete the WcfRelay"
	for ($i = 0; $i -lt $createdWcfRelayList.Count; $i++)
	{
		$delete1 = Remove-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $wcfRelayName		
	}
    Write-Debug " Delete namespaces"
    Remove-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests WcfRelay AuthorizationRules Create List Remove operations.
#>
function WcfRelayAuthTests
{
    # Setup    
    $location =  Get-Location
	$resourceGroupName = Get-ResourceGroupName
	$namespaceName = Get-NamespaceName    
	$wcfRelayName = Get-WcfRelayName	
    $authRuleName = Get-AuthorizationRuleName

	# Create ResourceGroup
    Write-Debug " Create resource group"    
    Write-Debug "Resource group name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	   
    # Create Relay Namespace 
    Write-Debug " Create new Relay namespace"
    Write-Debug "Namespace name : $namespaceName"
    $result = New-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Location $location
    Wait-Seconds 15
    
	# Assert
	Assert-True {$result.ProvisioningState -eq "Succeeded"}

	# Get Created NameSpace
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
    
	# Assert
    $found = 0
    
        if ($createdNamespace.Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location $createdNamespace.Location "NameSpace Location Not matched."          
        }

	# Assert
    #Assert-True {$found -eq 0} "Namespace created earlier is not found."

	# Create a WcfRelay
    Write-Debug " Create new WcfRelay "    
	$wcfRelayType = "NetTcp"
	$userMetadata = "usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store  descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored."
    $result1 = New-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $wcfRelayName -WcfRelayType $wcfRelayType  -RequiresClientAuthorization $true -RequiresTransportSecurity $true -UserMetadata $userMetadata
	
		
    Write-Debug " Get the created WcfRelay"
    $createdWcfRelay = Get-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $result1.Name

    # Assert
	Assert-True {$createdWcfRelay.Count -eq 1} "WcfRelay List count is not equal to 1 "  

	# Create WcfRelay Authorization Rule
    Write-Debug "Create a WcfRelay Authorization Rule"
    $result = New-AzureRmWcfRelayAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $result1.Name -AuthorizationRuleName $authRuleName -Rights @("Listen","Send")

	# Assert
    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Wait-Seconds 15

	# Get Created WcfRelay Authorization Rule
    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmWcfRelayAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $result1.Name -AuthorizationRule $authRuleName

	# Assert
    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }

	# Get all WcfRelay Authorization Rules
    Write-Debug "Get All WcfRelay AuthorizationRule"
    $result = Get-AzureRmWcfRelayAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $result1.Name
	# Assert
    $found = 0
    
        if ($result.Name -eq $authRuleName)
        {
            $found = 1
            Assert-AreEqual 2 $result.Rights.Count
            Assert-True { $result.Rights -Contains "Listen" }
            Assert-True { $result.Rights -Contains "Send" }         
            Assert-True {$found -eq 1} "WcfRelay AuthorizationRule created earlier is not found."
        }
    

	# Update the WcfRelay Authorization Rule
    Write-Debug "Update WcfRelay AuthorizationRule"
	$createdAuthRule.Rights.Add("Manage")
    $updatedAuthRule = Set-AzureRmWcfRelayAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $result1.Name -AuthorizationRuleName $authRuleName -AuthRuleObj $createdAuthRule
    Wait-Seconds 15

	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	   
    # get the Updated WcfRelay Authorization Rule
    $updatedAuthRule = Get-AzureRmWcfRelayAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $result1.Name -AuthorizationRuleName $authRuleName
    
	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	
	# Get the List Keys
    Write-Debug "Get WcfRelay authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmWcfRelayKey -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $result1.Name -AuthorizationRuleName $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}
	
	# Regentrate the Keys 
	$policyKey = "PrimaryKey"

	$namespaceRegenerateKeys = New-AzureRmWcfRelayKey -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $result1.Name -AuthorizationRuleName $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzureRmWcfRelayKey -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $result1.Name -AuthorizationRuleName $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}
	
	# Cleanup
    Write-Debug "Delete the created WcfRelay AuthorizationRule"
    $result = Remove-AzureRmWcfRelayAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $result1.Name -AuthorizationRuleName $authRuleName
    
    Write-Debug "Delete the WcfRelay"
    Remove-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -WcfRelayName $result1.Name
    
    Write-Debug "Delete NameSpace"
    Remove-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}