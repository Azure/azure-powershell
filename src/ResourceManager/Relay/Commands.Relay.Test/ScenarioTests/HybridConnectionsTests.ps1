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
	return "Relay-HybridCon-AuthRule" + (getAssetName)
	
}

<#
.SYNOPSIS
Tests HybridConnections Create Get List Remove operations.
#>
function HybridConnectionsTests
{
	# Setup    
	$location = "West US"
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
	$result = New-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -Location $location
	Wait-Seconds 15

	# Assert
	Assert-True {$result.ProvisioningState -eq "Succeeded"}

	# get the created Relay Namespace 
	Write-Debug " Get the created namespace within the resource group"
	$returnedNamespace = Get-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName    
	# Assert
	Assert-AreEqual $location $returnedNamespace.Location "NameSpace Location Not matched."        
	Assert-True {$returnedNamespace.Name -eq $namespaceName} "Namespace created earlier is not found."
	
	# Create a HybridConnections
	Write-Debug "Create new HybridConnections"
	$userMetadata = "User Meta data"
	$result = New-AzureRmRelayHybridConnection -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $HybridConnectionsName -RequiresClientAuthorization $True -UserMetadata $userMetadata
	
		
	Write-Debug " Get the created HybridConnections "
	$createdHybridConnections = Get-AzureRmRelayHybridConnection -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $HybridConnectionsName
	
	$result2 = Set-AzureRmRelayHybridConnection -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $HybridConnectionsName -UserMetadata "Test UserMetdata"

	#Assert
	Assert-True {$result2.Name -eq $HybridConnectionsName} "HybridConnections created earlier is not found."

	# Get the Created HybridConnections
	Write-Debug " Get all the created HybridConnections "
	$createdHybridConnectionsList = Get-AzureRmRelayHybridConnection -ResourceGroupName $resourceGroupName -Namespace $namespaceName
		
	#Assert
	Assert-True {$createdHybridConnectionsList[0].Name -eq $HybridConnectionsName }"HybridConnections created earlier is not found."
	
	# Update the Created HybridConnections
	Write-Debug " Update HybridConnections "
	$createdHybridConnections.UserMetadata = "usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store  descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored."	   
	$result1 = Set-AzureRmRelayHybridConnection -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $HybridConnectionsName -InputObject $createdHybridConnections
	Wait-Seconds 15
	
	# Assert
	Assert-True { $result1.UserMetadata -eq $createdHybridConnections.UserMetadata } "Updated HybridConnections 'RequiresClientAuthorization' not Matched "
	
	# Cleanup
	# Delete all Created HybridConnections
	Write-Debug " Delete the HybridConnections"
	for ($i = 0; $i -lt $createdHybridConnectionsList.Count; $i++)
	{
		$delete1 = Remove-AzureRmRelayHybridConnection -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $HybridConnectionsName		
	}
	Write-Debug " Delete namespaces"
	Remove-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}