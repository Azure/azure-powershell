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
	$location = "West US"
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
	
	# Create a WcfRelay
	Write-Debug "Create new WcfRelay"    
	$wcfRelayType = "NetTcp"
	$userMetadata = "User Meta data"
	$result = New-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $wcfRelayName -WcfRelayType $wcfRelayType  -RequiresClientAuthorization $True -RequiresTransportSecurity $True -UserMetadata $userMetadata
	
		
	Write-Debug " Get the created WcfRelay "
	$createdWcfRelay = Get-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $wcfRelayName

	# Assert
	Assert-True {$createdWcfRelay.Name -eq $wcfRelayName} "WcfRelay created earlier is not found."

	# Get the Created WcfRelay
	Write-Debug " Get all the created WcfRelay "
	$createdWcfRelayList = Get-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -Namespace $namespaceName
		
	# Assert
	Assert-True {$createdWcfRelayList[0].Name -eq $wcfRelayName }"WcfRelay created earlier is not found."

	#Update the Creatred WcfRelay with Porperties 
	$result2 = Set-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $wcfRelayName -UserMetadata "usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store  descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored."

	# Update the Created WcfRelay
	Write-Debug " Update the first WcfRelay "
	$createdWcfRelay.UserMetadata = "usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store  descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored."	   
	$result1 = Set-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $wcfRelayName -InputObject $createdWcfRelay
	Wait-Seconds 15
	
	# Assert
	Assert-True { $result1.RequiresClientAuthorization -eq $createdWcfRelay.RequiresClientAuthorization } "Updated WCFRelay 'RequiresClientAuthorization' not Matched "
	
	# Cleanup
	# Delete all Created WcfRelay
	Write-Debug " Delete the WcfRelay"
	for ($i = 0; $i -lt $createdWcfRelayList.Count; $i++)
	{
		$delete1 = Remove-AzureRmWcfRelay -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $wcfRelayName		
	}
	Write-Debug " Delete namespaces"
	Remove-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}