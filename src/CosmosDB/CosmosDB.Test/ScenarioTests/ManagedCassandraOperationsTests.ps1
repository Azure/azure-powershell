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
Test Cassandra Cluster CRUD cmdlets using Name paramter set
#>
function Test-ManagedCassandraCreateUpdateGetCmdlets
{
  $RgName = "nova-powershell-tests-rg"
  $ClusterName = "cluster8ea4cb76-7009-4b56-b09c-13dad8371a42"
  $DCName = "dc1"
  $Location = "central us"
  $VnetName = "cassandra-mi-vnet"

  Try {
      # Because New-AzRoleAssignmentWithId in tools\ScenarioTest.ResourceManager\AzureRM.Resources.ps1
      # is broken, we can't assign the Network Contributor role to virtual networks in the test. Therefore you
      # must set up a resource group with the following PowerShell script:
      #
      # $RgName = "nova-powershell-tests-rg"
      # $Location = "central us"
      # $resourceGroup = New-AzResourceGroup -ResourceGroupName $RgName -Location  $Location
      # $vnetProperties = @{
      #     Name = 'cassandra-mi-vnet'
      #     ResourceGroupName = $RgName
      #     Location = $Location
      #     AddressPrefix = '10.0.0.0/16'
      # }
      # $vnet = New-AzVirtualNetwork @vnetProperties
      # $subnetProperties = @{
      #     Name = 'default'
      #     VirtualNetwork = $vnet
      #     AddressPrefix = '10.0.0.0/24'
      # }
      # $subnet = Add-AzVirtualNetworkSubnetConfig @subnetProperties
      # $vnet = $vnet | Set-AzVirtualNetwork
      # New-AzRoleAssignment -ObjectId "e5007d2c-4b13-4a74-9b6a-605d99f03501" -RoleDefinitionName 'Network Contributor' -Scope $SubnetId
      # $SubnetId = $vnet.Subnets[0].Id
      #
      # then set this variable to the $SubnetId value produced by the script.
      $SubnetId = "/subscriptions/dd31ecae-4522-468e-8b27-5befd051dd53/resourceGroups/nova-powershell-tests-rg/providers/Microsoft.Network/virtualNetworks/cassandra-mi-vnet/subnets/default"

      $initialClusterCount = (Get-AzManagedCassandraCluster -ResourceGroupName $RgName).Count
      
      $response = New-AzManagedCassandraCluster `
        -ResourceGroupName $RgName `
        -ClusterName $ClusterName `
        -Location $Location `
        -InitialCassandraAdminPassword "password" `
        -DelegatedManagementSubnetId $SubnetId
      Assert-AreEqual "Succeeded" $response.Properties.ProvisioningState
      Assert-AreEqual $ClusterName $response.Name
      Assert-AreEqual 0 $response.Properties.ExternalSeedNodes.Count

      $clusterId = $response.Id
      
      $cluster = Get-AzManagedCassandraCluster -ResourceGroupName $RgName -ClusterName $ClusterName
      Assert-AreEqual "Succeeded" $cluster.Properties.ProvisioningState
      Assert-AreEqual $SubnetId $cluster.Properties.DelegatedManagementSubnetId
      Assert-AreEqual $true $cluster.Properties.RepairEnabled
      
      $cluster2 = Get-AzManagedCassandraCluster -ResourceId $clusterId
      Assert-AreEqual $cluster.Id $cluster2.Id
      Assert-AreEqual $cluster.Location $cluster2.Location
      Assert-AreEqual $cluster.Properties.HoursBetweenBackups $cluster2.Properties.HoursBetweenBackups
      Assert-AreEqual $cluster.Properties.CassandraVersion $cluster2.Properties.CassandraVersion

      Update-AzManagedCassandraCluster -ResourceId $clusterId `
        -ExternalSeedNode "127.0.0.1", "127.0.0.2", "127.0.0.3"
      while ($true) {
            $response = Get-AzManagedCassandraCluster -ResourceId $clusterId
            if ($response.Properties.ExternalSeedNodes.Count -eq 3)
            {
                break
            }
            Start-TestSleep -Seconds 1
      }
      $response = Get-AzManagedCassandraCluster -ResourceId $clusterId
      Assert-AreEqual 3 $response.Properties.ExternalSeedNodes.Count
      
      $dcResponse = New-AzManagedCassandraDatacenter `
        -ResourceGroupName $RgName `
        -ClusterName $ClusterName `
        -DatacenterName $DCName `
        -Location $Location `
        -NodeCount 3 `
        -DelegatedSubnetId $SubnetId
      Assert-AreEqual "Succeeded" $dcResponse.Properties.ProvisioningState
      Assert-AreEqual 3 $dcResponse.Properties.NodeCount
      
      $dcId = $dcResponse.Id
      
      $dc = Get-AzManagedCassandraDatacenter -ResourceGroupName $RgName -ClusterName $ClusterName -DatacenterName $DCName
      Assert-AreEqual "Succeeded" $dc.Properties.ProvisioningState
      Assert-AreEqual 3 $dc.Properties.NodeCount

      $dc2 = Get-AzManagedCassandraDatacenter -ResourceId $dcId
      Assert-AreEqual $dc.Id $dc2.Id
      Assert-AreEqual $dc.Name $dc2.Name
      Assert-AreEqual $dc.Properties.NodeCount $dc2.Properties.NodeCount

      Remove-AzManagedCassandraDatacenter -ResourceId $dcId

      Remove-AzManagedCassandraCluster -ResourceId $clusterId
    }
    Finally {
	}
}

