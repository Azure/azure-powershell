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

function Test-DataLakeStoreClusterCreate{
	#test New-AzureRmHDInsightCluster with Data Lake Parameters
	
	#setup
	$subscription = " "
	$rmGroup = "adlpowershell"
	$locName = "East US"
	$version = 3.2
	$saName = "ypseastus"
	$storageAccountKey = " "
	$clusterName = "adlhdiy5"
	$clusterNodes = 2
	$headnodeSize = "Standard_D3"
	$workernodeSize = "Standard_D3"
	$username = "admin"
	$passwd = " "
	$certPasswd = ""
	$certPath = " "
	$certFile = "sp.pfx"
	$servPrincipal = "sp"
	$objectId = [GUID] ("00000000-0000-0000-0000-000000000000")
	$sshUser = "hdiuser"

	$secPasswd = ConvertTo-SecureString $passwd -AsPlainText -Force
	$credential=New-Object System.Management.Automation.PSCredential($username,$secPasswd)
		
	$sshPasswd=ConvertTo-SecureString ' ' -AsPlainText -Force
	$sshCred=New-Object System.Management.Automation.PSCredential($sshUser,$sshPasswd)

	#execute
	$cluster = New-AzureRmHDInsightCluster -Location $locName -ResourceGroupName $rmGroup -ClusterType Hadoop `
				-ClusterName $clusterName -ClusterSizeInNodes $clusterNodes -HttpCredential $credential `
				-DefaultStorageAccountName "$saName.blob.core.windows.net" -DefaultStorageAccountKey $storageAccountKey `
				-DefaultStorageContainer $clusterName -Version $version -SshCredential $sshCred -OSType Linux `
				-ObjectId $objectId -CertificateFilePath $certFilePath -CertificatePassword $certPasswd

	#assert
	Assert-NotNull $cluster

	Assert-AreEqual $clusterName $cluster.Name

	Assert-Null $cluster.Error
}
