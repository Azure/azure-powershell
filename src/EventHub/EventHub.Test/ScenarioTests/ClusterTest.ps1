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
Tests Eventhub Cluster operations.
#>

function ClusterTest
{
    # Setup
    $location = "southcentralus"
	$clusterName = getAssetName "Eventhub-Cluster-"
    $resourceGroupName = getAssetName "RSG-Cluster"
	
	Write-Debug "  Create resource group"
    Write-Debug " Resource Group Name : $resourceGroupName"
    $ResultResourceGroup = New-AzResourceGroup -Name $resourceGroupName -Location $location -Force   

    Write-Debug " Create a Cluster in South Central US"
    Write-Debug "Cluster Name : $clusterName" 
    $result = New-AzEventHubCluster -ResourceGroup $resourceGroupName -Name $clusterName -Location $location  -Capacity "1"
	Assert-AreEqual $result.Name $clusterName "Created Cluster Name matches"
	
	# Get Cluster
    Write-Debug "Get the created cluster within the resource group"	
	$getResponse = Get-AzEventHubCluster -ResourceGroup $resourceGroupName -Name $clusterName
	    
	Assert-AreEqual $getResponse.Name $clusterName "Cluster get : Cluster name matches"
	Assert-AreEqual $getResponse.Sku.Capacity "1" "Cluster get : Capacity matches"

	#Update Cluster
	$resultUpdate = Set-AzEventHubCluster -ResourceGroup $resourceGroupName -Name $clusterName -Location $location -Tag @{"ClusterTag1" = "Tag3"; "ClusterTag2" = "Tag4";}
	Assert-AreEqual $resultUpdate.Name $clusterName "Updated Cluster Name matches"    
}
