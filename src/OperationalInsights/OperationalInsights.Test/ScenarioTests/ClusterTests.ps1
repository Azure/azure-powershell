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
Test Cluster CRUD
#>
function Test-ClusterCRUD
{
	# setup
	$rgName = Get-ResourceGroupName
	$clusterName = Get-ResourceName
	$loc = Get-ProviderLocation

	$rgNameExisting = "azps-test-group"
	$clusterNameExisting = "yabocluster7"
	$kvNameExisting = "azps-test-kv8"
	$keyNameExisting = "azps-test-key3"
	$kvUri = "https://azps-test-kv8.vault.azure.net"
	$version = "9ac53081c8fe45f0b26d9d476b29c017"

	try
	{
		# get cluster
		$cluster = Get-AzOperationalInsightsCluster -ResourceGroupName $rgNameExisting -ClusterName $clusterNameExisting

		Assert-NotNull $cluster
		Assert-AreEqual $clusterNameExisting $cluster.Name

		# update cluster, clusters to be update require provisioning state to be "Succeeded", existing clusters were used in this Test
		# kv used in this test case need to enable both softdelete and purge protection	

		$job = Update-AzOperationalInsightsCluster -ResourceGroupName $rgNameExisting -ClusterName $clusterNameExisting -SkuCapacity 1500 -KeyVaultUri $kvUri -KeyName $keyNameExisting -KeyVersion $version -AsJob
		$job | Wait-Job
		$cluster = $job | Receive-Job

		Assert-NotNull $cluster
		Assert-AreEqual 1500 $cluster.Sku.Capacity
		Assert-AreEqual "Succeeded" $cluster.ProvisioningState
	}
	finally
	{
		# Cleanup
        Clean-ResourceGroup $rgName
	}
	
}