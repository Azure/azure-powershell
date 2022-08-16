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

function assertClusterProperties {
	
	param([Microsoft.Azure.Commands.EventHub.Models.PSEventHubClusterAttributes]$expectedCluster,[Microsoft.Azure.Commands.EventHub.Models.PSEventHubClusterAttributes]$cluster)

	Assert-AreEqual $expectedCluster.Name $cluster.Name
	Assert-AreEqual $expectedCluster.Tags.Count $cluster.Tags.Count
	Assert-AreEqual $expectedCluster.Location $cluster.Location
	Assert-AreEqual $expectedCluster.Capacity $cluster.Capacity
	Assert-AreEqual $expectedCluster.Sku.Capacity $cluster.Sku.Capacity
}

function ClusterTest
{
    # Setup
    $location = "southcentralus"
	$clusterName = getAssetName "Eventhub-Cluster-"
    $resourceGroupName = getAssetName "RSG-Cluster"
	
	Write-Debug "  Create resource group"
    Write-Debug " Resource Group Name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force   

    Write-Debug " Create a Cluster in South Central US"
    Write-Debug "Cluster Name : $clusterName" 
    $expectedCluster = New-AzEventHubCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location
	Assert-AreEqual $expectedCluster.Name $clusterName
	Assert-AreEqual $expectedCluster.Location $location
	Assert-AreEqual $expectedCluster.Capacity 1
	Assert-AreEqual 0 $expectedCluster.Tags.Count

    Write-Debug "Get the created cluster within the resource group"	
	$cluster = Get-AzEventHubCluster -ResourceGroupName $resourceGroupName -Name $clusterName
	assertClusterProperties $expectedCluster $cluster

	#Update Cluster
	$cluster = Set-AzEventHubCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Location $location -Tag @{"ClusterTag1" = "Tag3"; "ClusterTag2" = "Tag4";}
	$expectedCluster.Tags = $cluster.Tags
	assertClusterProperties $expectedCluster $cluster
}

function SelfServeCluster{
	# Setup
    $location = "southcentralus"
	$locationForAssert = "South Central US"
	$clusterName = getAssetName "Eventhub-Cluster-"
    $resourceGroupName = getAssetName "RSG-Cluster"
	$namespaceName = getAssetName "ClusterNamespace-"
	
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force   

    $expectedCluster = New-AzEventHubCluster -ResourceGroup $resourceGroupName -Name $clusterName -Location $location -Capacity 2 -SupportsScaling
	Assert-AreEqual $expectedCluster.Name $clusterName
	Assert-True { $expectedCluster.SupportsScaling }
	Assert-AreEqual $expectedCluster.Capacity 2
	Assert-AreEqual $location $expectedCluster.Location

	$cluster = Get-AzEventHubCluster -ResourceGroup $resourceGroupName -Name $clusterName
	assertClusterProperties $expectedCluster $cluster

	$cluster.Capacity = 3
	$cluster = Set-AzEventHubCluster -InputObject $cluster
	Assert-AreEqual 3 $cluster.Capacity
	$expectedCluster.Capacity = $cluster.Capacity
	$expectedCluster.Sku.Capacity = $cluster.Capacity
	assertClusterProperties $expectedCluster $cluster

	$cluster = Set-AzEventHubCluster -ResourceId $expectedCluster.Id -Tag @{k1='v1'; k2='v2'}
	$expectedCluster.Tags = $cluster.Tags
	assertClusterProperties $expectedCluster $cluster

	$cluster = Set-AzEventHubCluster -ResourceGroupName $resourceGroupName -Name $clusterName -Capacity 1
	$expectedCluster.Capacity = 1
	$expectedCluster.Sku.Capacity = 1
	assertClusterProperties $expectedCluster $cluster


	$namespace = New-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -ClusterARMId $expectedCluster.Id -SkuName Standard -Location $location
	Assert-NotNull $namespace.ClusterArmId


}
