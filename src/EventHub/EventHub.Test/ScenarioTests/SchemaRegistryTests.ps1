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
Test EventHubs Schema Registry Operations
#>

function SchemaRegistryTest {
	#Setup
	$location = "southcentralus"
	$resourceGroupName = getAssetName "EventHub-SchemaRegistry-PS-Testing"
	$namespaceName = getAssetName "davadhani-PS-Testing"
	$schemaGroupName = getAssetName "SchemaGroup"

	#Create Resource Group
	Write-Debug "  Create resource group"
    	Write-Debug " Resource Group Name : $resourceGroupName"
    	$ResultResourceGroup = New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

	#Create Namespace
	$result = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location
	Assert-AreEqual $result.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
	Assert-AreEqual $result.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"

	Write-Debug " Get the created namespace within the resource group"
    	$createdNamespace = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	Assert-AreEqual $createdNamespace.ResourceGroup $resourceGroupName "Namespace get : ResourceGroup name matches"
	Assert-AreEqual $createdNamespace.ResourceGroupName $resourceGroupName "Namespace get : ResourceGroupName name matches"
    
	#Assert
    	Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found."

	#Create Schema Group
	$result = New-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName -SchemaCompatibility Forward -SchemaType Avro -GroupProperties @{"name"="name"}
	
	Assert-AreEqual $schemaGroupName $result.Name
	Assert-AreEqual "Forward" $result.SchemaCompatibility
	Assert-AreEqual "Avro" $result.SchemaType
	Assert-AreEqual @{"name"="name"} $result.GroupProperties
	
	$resultRemove = Remove-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName
	
	Assert-AreEqual $resultRemove true

	Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzResourceGroup -Name $resourceGroupName -Force

	
}