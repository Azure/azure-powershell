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
function Test-ManagedCassandraClusterCreateUpdateGetCmdlets
{
  $RgName = "test-powershell"
  $ClusterName = "cluster1"
  $DCName = "dc1"
  $Location = "eastus2"
  $MyVirtualNetwork = "network1"
  $BackendSubnetName = "subnet1"

  Try {            
      New-AzResourceGroup -Name $RgName -Location $Location
      $backendSubnet  = New-AzVirtualNetworkSubnetConfig -Name $BackendSubnetName  -AddressPrefix "10.0.2.0/24"
      $network = New-AzVirtualNetwork -Name MyVirtualNetwork -ResourceGroupName $RgName -Location $Location -AddressPrefix "10.0.0.0/16" -Subnet $backendSubnet          
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name $BackendSubnetName -VirtualNetwork $network      
      
      $cluster = New-AzManagedCassandraCluster -ResourceGroupName $RgName -ClusterName $ClusterName -Location $Location -InitialCassandraAdminPassword "password" -DelegatedManagementSubnetId $subnet.Id
      Assert-AreEqual "Succeeded" $cluster.Properties.ProvisioningState

      $cluster = Update-AzManagedCassandraCluster -ResourceGroupName $RgName -ClusterName $ClusterName -ExternalSeedNodes "127.0.0.1", "127.0.0.2", "127.0.0.3"
      Assert-AreEqual "Succeeded" $cluster.Properties.ProvisioningState

      $cluster = Get-AzManagedCassandraCluster -ResourceGroupName $RgName -ClusterName $ClusterName
      Assert-AreEqual 1 $cluster.Count

      $cluster = Get-AzManagedCassandraCluster -ResourceGroupName $RgName
      Assert-AreEqual 1 $cluster.Count

      Remove-AzManagedCassandraCluster -ResourceGroupName $RgName -ClusterName $ClusterName
    }
    Finally {
	}
}

<#
.SYNOPSIS
Test Cassandra Datacenter CRUD cmdlets using Name paramter set
#>
function Test-ManagedCassandraDatacenterCreateUpdateGetCmdlets
{
  $RgName = "test-powershell"
  $ClusterName = "cluster1"
  $DCName = "dc1"
  $Location = "eastus2"
  $MyVirtualNetwork = "network1"
  $BackendSubnetName = "subnet1"

  Try {            
      New-AzResourceGroup -Name $RgName -Location $Location
      $backendSubnet  = New-AzVirtualNetworkSubnetConfig -Name $BackendSubnetName  -AddressPrefix "10.0.2.0/24"
      $network = New-AzVirtualNetwork -Name MyVirtualNetwork -ResourceGroupName $RgName -Location $Location -AddressPrefix "10.0.0.0/16" -Subnet $backendSubnet          
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name $BackendSubnetName -VirtualNetwork $network  
      
      $cluster = New-AzManagedCassandraCluster -ResourceGroupName $RgName -ClusterName $ClusterName -Location $Location -InitialCassandraAdminPassword "password" -DelegatedManagementSubnetId $subnet.Id
      Assert-AreEqual "Succeeded" $cluster.Properties.ProvisioningState

      $datacenter = New-AzManagedCassandraDatacenter -ResourceGroupName $RgName -ClusterName $ClusterName -DatacenterName $DCName -Location $Location -NodeCount 3 -DelegatedSubnetId $subnet.Id
      Assert-AreEqual "Succeeded" $datacenter.Properties.ProvisioningState

      $datacenter = Update-AzManagedCassandraDatacenter -ResourceGroupName $RgName -ClusterName $ClusterName -DatacenterName $DCName -NodeCount 4 
      Assert-AreEqual "Succeeded" $cluster.Properties.ProvisioningState

      $datacenter = Get-AzManagedCassandraDatacenter -ResourceGroupName $RgName -ClusterName $ClusterName -DatacenterName $DCName
      Assert-AreEqual 1 $cluster.Count

      $datacenter = Get-AzManagedCassandraDatacenter -ResourceGroupName $RgName -ClusterName $ClusterName
      Assert-AreEqual 1 $cluster.Count

      Remove-AzManagedCassandraDatacenter -ResourceGroupName $RgName -ClusterName $ClusterName -DatacenterName $DCName
    }
    Finally {
	}
}