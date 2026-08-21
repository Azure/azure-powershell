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

.DESCRIPTION
This test is fully self-contained. It creates its own resource group, virtual network,
subnet, and role assignment before provisioning a Garnet cluster. No pre-existing
infrastructure is assumed.
#>
function Test-GarnetClusterCreateUpdateGetCmdlets
{
    $RgName = "garnet-powershell-tests-rg"
    $ClusterName = "garnet-ps-test-cluster"
    $Location = "westus2"
    $VnetName = "garnet-test-vnet"
    $SubnetName = "default"
    $NodeSku = "Standard_E8s_v4"
    $CosmosDbServicePrincipalId = "e5007d2c-4b13-4a74-9b6a-605d99f03501"

    Try {
        # Set up infrastructure: resource group, VNet, subnet
        $resourceGroup = New-AzResourceGroup -ResourceGroupName $RgName -Location $Location

        $vnet = New-AzVirtualNetwork -Name $VnetName -ResourceGroupName $RgName -Location $Location -AddressPrefix "10.0.0.0/16"
        $subnet = Add-AzVirtualNetworkSubnetConfig -Name $SubnetName -VirtualNetwork $vnet -AddressPrefix "10.0.0.0/24"
        $vnet = $vnet | Set-AzVirtualNetwork
        $SubnetId = $vnet.Subnets[0].Id

        # Assign Network Contributor role to Cosmos DB service principal on the subnet.
        # Use Invoke-AzRestMethod with a fixed RoleAssignmentId for deterministic playback.
        $RoleAssignmentId = "f019e411-2330-44da-ad24-70e24c6c2c79"
        $NetworkContributorRoleId = "4d97b98b-1d4f-4787-a291-c67834d212e7"
        $SubscriptionId = (Get-AzContext).Subscription.Id
        $roleAssignmentPath = "$SubnetId/providers/Microsoft.Authorization/roleAssignments/$RoleAssignmentId`?api-version=2022-04-01"
        $roleAssignmentBody = @{
            properties = @{
                roleDefinitionId = "/subscriptions/$SubscriptionId/providers/Microsoft.Authorization/roleDefinitions/$NetworkContributorRoleId"
                principalId = $CosmosDbServicePrincipalId
            }
        } | ConvertTo-Json -Depth 5
        Invoke-AzRestMethod -Path $roleAssignmentPath -Method PUT -Payload $roleAssignmentBody

        # Create cluster
        $cluster = New-AzCosmosDBGarnetCluster `
            -ResourceGroupName $RgName `
            -ClusterName $ClusterName `
            -Location $Location `
            -SubnetId $SubnetId `
            -NodeSku $NodeSku `
            -ReplicationFactor 4 `
            -ShardCount 1 `
            -AuthenticationMethod "Entra" `
            -Persistence $false
        Assert-NotNull $cluster
        Assert-AreEqual $ClusterName $cluster.Name

        $clusterId = $cluster.Id

        # Get by name
        $clusterByName = Get-AzCosmosDBGarnetCluster -ResourceGroupName $RgName -ClusterName $ClusterName
        Assert-NotNull $clusterByName
        Assert-AreEqual $clusterId $clusterByName.Id

        # List in resource group
        $clustersInRg = @(Get-AzCosmosDBGarnetCluster -ResourceGroupName $RgName)
        Assert-True { $clustersInRg.Count -ge 1 }

        # Get by resource ID
        $clusterById = Get-AzCosmosDBGarnetCluster -ResourceId $clusterId
        Assert-AreEqual $clusterId $clusterById.Id

        # Get by input object (pipeline)
        $clusterByObject = $clusterByName | Get-AzCosmosDBGarnetCluster
        Assert-AreEqual $clusterId $clusterByObject.Id

        # Update cluster
        $updatedCluster = Update-AzCosmosDBGarnetCluster `
            -ResourceGroupName $RgName `
            -ClusterName $ClusterName `
            -Persistence $true
        Assert-NotNull $updatedCluster
        Assert-AreEqual $clusterId $updatedCluster.Id

        # Delete cluster
        $removed = Remove-AzCosmosDBGarnetCluster -ResourceGroupName $RgName -ClusterName $ClusterName -PassThru -Confirm:$false
        Assert-AreEqual $true $removed
    }
    Finally {
        # Clean up: delete the cluster (if still exists), then the resource group
        Remove-AzCosmosDBGarnetCluster -ResourceGroupName $RgName -ClusterName $ClusterName -Confirm:$false -ErrorAction SilentlyContinue
        Remove-AzResourceGroup -ResourceGroupName $RgName -Force -ErrorAction SilentlyContinue
    }
}
