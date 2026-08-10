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
Test Garnet cache cluster CRUD cmdlets using name, resource ID, and object parameter sets.
#>
function Test-GarnetClusterCreateUpdateGetCmdlets
{
    $rgName = Get-ResourceGroupName
    $clusterName = ("garnet" + (Get-ResourceName)).ToLowerInvariant()
    $location = Get-ProviderLocation "Microsoft.DocumentDB/garnetClusters"
    $cluster = $null

    try {
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $location -Force

        $subscriptionClusters = Get-AzCosmosDBGarnetCluster
        Assert-NotNull $subscriptionClusters

        $cluster = New-AzCosmosDBGarnetCluster `
            -ResourceGroupName $rgName `
            -ClusterName $clusterName `
            -Location $location `
            -AuthenticationMethod "Entra" `
            -ClusterType "NonProduction" `
            -Persistence $false
        Assert-NotNull $cluster
        Assert-AreEqual $clusterName $cluster.Name
        Assert-AreEqual $location.ToLowerInvariant() $cluster.Location.ToLowerInvariant()

        $clusterByName = Get-AzCosmosDBGarnetCluster -ResourceGroupName $rgName -ClusterName $clusterName
        Assert-NotNull $clusterByName
        Assert-AreEqual $cluster.Id $clusterByName.Id

        $clustersInRg = Get-AzCosmosDBGarnetCluster -ResourceGroupName $rgName
        Assert-NotNull $clustersInRg
        Assert-True { $clustersInRg.Count -ge 1 }

        $clusterById = Get-AzCosmosDBGarnetCluster -ResourceId $cluster.Id
        Assert-AreEqual $cluster.Id $clusterById.Id

        $clusterByObject = $clusterByName | Get-AzCosmosDBGarnetCluster
        Assert-AreEqual $cluster.Id $clusterByObject.Id

        $updatedCluster = $clusterByObject | Update-AzCosmosDBGarnetCluster `
            -AuthenticationMethod "Entra" `
            -ClusterType "NonProduction" `
            -Persistence $true
        Assert-NotNull $updatedCluster
        Assert-AreEqual $cluster.Id $updatedCluster.Id

        $removed = $updatedCluster | Remove-AzCosmosDBGarnetCluster -PassThru -Confirm:$false
        Assert-AreEqual $true $removed
        $cluster = $null
    }
    finally {
        if ($null -ne $cluster) {
            Remove-AzCosmosDBGarnetCluster -ResourceGroupName $rgName -ClusterName $clusterName -Confirm:$false
        }

        Remove-AzResourceGroup -Name $rgName -Force -ErrorAction SilentlyContinue
    }
}
