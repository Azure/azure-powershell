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
    SYNOPSIS
    Tests Data Lake Cluster Creation
#>

function Test-DataLakeStoreClusterCreate {
	#test New-AzureRmHDInsightCluster with Data Lake Parameters
	
	#setup
	$subscription = " "
	$rmGroup = "sisankarwasbprodclusterresourcegroup"
	$locName = "East US"
	$version = 3.5
	$saName = " "
	$storageAccountKey = "test"
	$clusterName = "sisankarpsadladditionalfs"
	$clusterNodes = 2
	$headnodeSize = "Standard_D3"
	$workernodeSize = "Standard_D3"
	$username = "admin"
	$passwd = "test"
	$certPasswd = "test"
	$certPath = ".\SessionRecords\Microsoft.Azure.Commands.HDInsight.Test.DataLakeStoreScenarioTests\test.pfx"
	$objectId = [GUID] ("00000000-0000-0000-0000-000000000001")
	$tenantId = [GUID] ("00000000-0000-0000-0000-000000000001")
	$sshUser = "test"

	$secPasswd = ConvertTo-SecureString $passwd -AsPlainText -Force
	$credential=New-Object System.Management.Automation.PSCredential($username,$secPasswd)
		
	$sshPasswd=ConvertTo-SecureString $passwd -AsPlainText -Force
	$sshCred=New-Object System.Management.Automation.PSCredential($sshUser,$sshPasswd)

	#execute
	$cluster = New-AzureRmHDInsightCluster -Location $locName -ResourceGroupName $rmGroup -ClusterType Hadoop `
				-ClusterName $clusterName -ClusterSizeInNodes $clusterNodes -HttpCredential $credential `
				-DefaultStorageAccountName "$saName.blob.core.windows.net" -DefaultStorageAccountKey $storageAccountKey `
				-DefaultStorageContainer $clusterName -Version $version -SshCredential $sshCred -OSType Linux `
				-AadTenantId $tenantId -ObjectId $objectId -CertificateFilePath $certPath -CertificatePassword $certPasswd

	#get
	$clusterGetResponse = Get-AzureRmHDInsightCluster -ResourceGroupName $rmGroup -ClusterName $clusterName

	#assert
	Assert-NotNull $cluster

	Assert-AreEqual $clusterName $cluster.Name

	Assert-Null $cluster.Error

	Assert-True {$clusterGetResponse.DefaultStorageAccount.Contains(".blob.core.windows.net")} "Did not create cluster with WASB defaultFS"
	Assert-NotNull $clusterGetResponse.DefaultStorageContainer
}


function Test-DataLakeStoreDefaultFSClusterCreate {
	#test New-AzureRmHDInsightCluster with Data Lake specified as DefaultFS 
	
	#setup
	$subscription = " "
	$rmGroup = "sisankarwasbprodclusterresourcegroup"
	$locName = "East US"
	$version = 3.5
	$saName = "test"
	$clusterName = "sisankarpsadlstoragetype"
	$clusterNodes = 2
	$headnodeSize = "Standard_D3"
	$workernodeSize = "Standard_D3"
	$username = "admin"
	$passwd = "test"
	$certPasswd = "test"
	$certPath = ".\SessionRecords\Microsoft.Azure.Commands.HDInsight.Test.DataLakeStoreScenarioTests\test.pfx"
	$objectId = [GUID] ("00000000-0000-0000-0000-000000000001")
	$tenantId = [GUID] ("00000000-0000-0000-0000-000000000001")
	$sshUser = "hdiuser"

	$secPasswd = ConvertTo-SecureString $passwd -AsPlainText -Force
	$credential=New-Object System.Management.Automation.PSCredential($username,$secPasswd)
		
	$sshPasswd=ConvertTo-SecureString $passwd -AsPlainText -Force
	$sshCred=New-Object System.Management.Automation.PSCredential($sshUser,$sshPasswd)

	#execute
	$cluster = New-AzureRmHDInsightCluster -Location $locName -ResourceGroupName $rmGroup -ClusterType Hadoop `
				-ClusterName $clusterName -ClusterSizeInNodes $clusterNodes -HttpCredential $credential `
				-DefaultStorageAccountType AzureDataLakeStore -DefaultStorageAccountName "$saName" `
				-Version $version -SshCredential $sshCred -OSType Linux `
				-AadTenantId $tenantId -ObjectId $objectId `
				-CertificateFilePath $certPath -CertificatePassword $certPasswd

	#get
	$clusterGetResponse = Get-AzureRmHDInsightCluster -ResourceGroupName $rmGroup -ClusterName $clusterName

	#assert
	Assert-NotNull $cluster

	Assert-AreEqual $clusterName $cluster.Name

	Assert-Null $cluster.Error

	Assert-True {$clusterGetResponse.DefaultStorageAccount.Contains(".azuredatalakestore.net")} "Did not create cluster with DataLake defaultFS"
	Assert-AreEqual $clusterGetResponse.DefaultStorageContainer ""
}
