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

function Test-CreateBasicCluster
{
	$resourceGroupName = "sfmcps-rg-" + (getAssetname)
	$clusterName = "sfmcps-" + (getAssetname)
	$pass = (ConvertTo-SecureString -AsPlainText -Force "TestPass1234!@#")
	$location = "southcentralus"
	$testClientTp = "123BDACDCDFB2C7B250192C6078E47D1E1DB119B"
	Assert-ThrowsContains { Get-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -Name $clusterName } "NotFound"

	$tags = @{"test"="tag"}

	$cluster = New-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Location $location `
		-AdminPassword $pass -Sku Basic -ClientCertThumbprint $testClientTp -Tag $tags -Verbose
	Assert-AreEqual "Succeeded" $cluster.ProvisioningState
	Assert-AreEqual "Automatic" $cluster.ClusterUpgradeMode
	Assert-AreEqual "Wave0" $cluster.ClusterUpgradeCadence

	$pnt = New-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name pnt -InstanceCount 5 -DiskType Standard_LRS -Primary
	Assert-AreEqual 5 $pnt.VmInstanceCount
	Assert-AreEqual "Standard_LRS" $pnt.DataDiskType

	# shouldn't be allowed to remove the only primary node type in the cluster
	Assert-ThrowsContains { $pnt | Remove-AzServiceFabricManagedNodeType } "InvalidParameter"

	$clusterFromGet = Get-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -Name $clusterName
	Assert-AreEqual "Ready" $clusterFromGet.ClusterState
	Assert-HashtableEqual $cluster.Tags $clusterFromGet.Tags

	# scale primary node type
	$pnt = Set-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name pnt -InstanceCount 6
	Assert-AreEqual 6 $pnt.VmInstanceCount

	$removeResponse = $clusterFromGet | Remove-AzServiceFabricManagedCluster -PassThru
	Assert-True { $removeResponse }
	
	Assert-ThrowsContains { Get-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName } "NotFound"
}

function Test-NodeTypeOperations
{
	$resourceGroupName = "sfmcps-rg-" + (getAssetname)
	$clusterName = "sfmcps-" + (getAssetname)
	$location = "southcentralus"
	$testClientTp = "123BDACDCDFB2C7B250192C6078E47D1E1DB119B"
	$pass = (ConvertTo-SecureString -AsPlainText -Force "TestPass1234!@#")
	Assert-ThrowsContains { Get-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -Name $clusterName } "NotFound"

	$cluster = New-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName -UpgradeMode Automatic -UpgradeCadence Wave1 -Location $location `
		-AdminPassword $pass -Sku Standard -ClientCertThumbprint $testClientTp -Verbose
	Assert-AreEqual "Succeeded" $cluster.ProvisioningState
	Assert-AreEqual "WaitingForNodes" $cluster.ClusterState
	Assert-AreEqual "Automatic" $cluster.ClusterUpgradeMode
	Assert-AreEqual "Wave1" $cluster.ClusterUpgradeCadence

	New-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name pnt -InstanceCount 5 -Primary -DiskType Premium_LRS -VmSize "Standard_DS2" -AsJob
	New-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name snt -InstanceCount 6 -IsStateless -AsJob

	#wait for nodetypes
	WaitForAllJob

	$pnt = Get-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name pnt
	Assert-AreEqual "Premium_LRS" $pnt.DataDiskType
	Assert-False { $pnt.IsStateless }

	$snt = Get-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name snt
	Assert-AreEqual "StandardSSD_LRS" $snt.DataDiskType
	Assert-True { $snt.IsStateless }

	$restart = Restart-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name snt -NodeName snt_0, snt_1 -PassThru
	Assert-True { $restart }

	$delete = Remove-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name snt -NodeName snt_1 -PassThru
	Assert-True { $delete }

	$reimage = Set-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name snt -NodeName snt_3 -Reimage -PassThru
	Assert-True { $reimage }

	$snt = Get-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name snt
	$removeResponse = $snt | Remove-AzServiceFabricManagedNodeType -PassThru
	Assert-True { $removeResponse }

	$removeResponse = $cluster | Remove-AzServiceFabricManagedCluster -PassThru
	Assert-True { $removeResponse }
}

function Test-CertAndExtension
{
	$resourceGroupName = "sfmcps-rg-" + (getAssetname)
	$clusterName = "sfmcps-" + (getAssetname)
	$location = "southcentralus"
	$testClientTp = "123BDACDCDFB2C7B250192C6078E47D1E1DB119B"
	$pass = (ConvertTo-SecureString -AsPlainText -Force "TestPass1234!@#")
	Assert-ThrowsContains { Get-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -Name $clusterName } "NotFound"

	$cluster = New-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Location $location `
		-AdminPassword $pass -Sku Standard -ClientCertThumbprint $testClientTp -Verbose
	Assert-AreEqual "Succeeded" $cluster.ProvisioningState
	Assert-AreEqual "WaitingForNodes" $cluster.ClusterState

	$pnt = New-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name pnt -InstanceCount 5 -Primary

	# add extension
	$extName = 'csetest';
    $publisher = 'Microsoft.Compute';
    $extType = 'BGInfo';
    $extVer = '2.1';

	$pnt = Add-AzServiceFabricManagedNodeTypeVMExtension -ResourceGroupName $resourceGroupName -ClusterName $clusterName -NodeTypeName pnt `
		-Name $extName -Publisher $publisher -Type $extType -TypeHandlerVersion $extVer -Verbose

	$pnt = Get-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name pnt

	Assert-NotNull $pnt.VmExtensions
	Assert-AreEqual 1 $pnt.VmExtensions.Count

	# add client cert
	Assert-AreEqual 1 $cluster.Clients.Count
	$testClientTp2 = "123BDACDCDFB2C7B250192C6078E47D1E1DB7777"
	$cluster = Add-AzServiceFabricManagedClusterClientCertificate -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Thumbprint $testClientTp2
	Assert-AreEqual 2 $cluster.Clients.Count
	Assert-AreEqual $testClientTp2 $cluster.Clients[1].Thumbprint

	# remove client cert
	$remove = Remove-AzServiceFabricManagedClusterClientCertificate -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Thumbprint $testClientTp2 -PassThru
	Assert-True { $remove }

	$cluster = Get-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -Name $clusterName
	Assert-AreEqual 1 $cluster.Clients.Count

	$removeResponse = $cluster | Remove-AzServiceFabricManagedCluster -PassThru
	Assert-True { $removeResponse }
}