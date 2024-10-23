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
 Azure HDInsight Cluster Script Action Commands Test Cases
#>

function Test-ScriptActionRelatedCommands{

	# Create some resources that will be used throughout test 
	try
	{
		$params= Prepare-ClusterCreateParameter

		# test create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"
		
		$scriptActionName = Generate-Name("scriptaction")
		$uri = "https://hdiconfigactions.blob.core.windows.net/linuxhueconfigactionv02/install-hue-uber-v02.sh"
		$nodeTypes = ("Worker")
		
		#test Submit-AzHDInsightScriptAction
		$script = Submit-AzHDInsightScriptAction -ResourceGroupName $params.resourceGroupName -ClusterName $cluster.Name -Name $scriptActionName -Uri $uri -NodeTypes $nodeTypes
		
		#test Get-AzHDInsightScriptActionHistory
		$getScript = Get-AzHDInsightScriptActionHistory -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup `
		           | Where-Object {$_.Name -eq $script.Name }
		
		Assert-AreEqual $getScript.Name $script.Name
		
		#test Set-AzHDInsightPersistedScriptAction
		Set-AzHDInsightPersistedScriptAction -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup `
		-ScriptExecutionId $getScript.ScriptExecutionId
		
		#test Get-AzHDInsightPersistedScriptAction
		$persistedScript = Get-AzHDInsightPersistedScriptAction -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup `
		-Name $getScript.Name
		
		Assert-AreEqual $persistedScript.Name $getScript.Name
		
		#test Remove-AzHDInsightPersistedScriptAction
		Remove-AzHDInsightPersistedScriptAction -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup `
		-Name $persistedScript.Name
		
		$persistedScript = Get-AzHDInsightPersistedScriptAction -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup `
		-Name $getScript.Name
		
		Assert-Null $persistedScript
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}
