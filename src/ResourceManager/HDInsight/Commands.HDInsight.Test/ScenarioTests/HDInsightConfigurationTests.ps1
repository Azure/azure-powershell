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
    Tests pipelining with creating the config
#>
    function Test-ConfigurationPipelining{
        #test New-AzureRmHDInsightClusterConfig		
		$config = New-AzureRmHDInsightClusterConfig -ClusterType Hadoop -ClusterTier Standard
		Assert-NotNull $config.ClusterType
		Assert-NotNull $config.ClusterTier
		
		#test Add-AzureRmHDInsightStorage
		Assert-AreEqual $config.AdditionalStorageAccounts.Count 0
		$config = $config | Add-AzureRmHDInsightStorage -StorageAccountName fakestorageaccount -StorageAccountKey STORAGEACCOUNTKEY==
		Assert-AreEqual $config.AdditionalStorageAccounts.Count 1
		
		#test Add-AzureRmHDInsightConfigValues
		Assert-AreEqual $config.Configurations.Count 0
		Assert-Null $config.Configurations["core-site"]
		$coreconfig = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
		$coreconfig.Add('coreconfig', 'corevalue')
		Assert-Null $config.Configurations["core-site"]
		$config = $config | Add-AzureRmHDInsightConfigValues -Core $coreconfig
		Assert-NotNull $config.Configurations["core-site"]

		$oozieconfig = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
		$oozieconfig.Add('oozieconfig', 'oozievalue')
		Assert-Null $config.Configurations["oozie-site"]
		$config = $config | Add-AzureRmHDInsightConfigValues -OozieSite $coreconfig
		Assert-NotNull $config.Configurations["oozie-site"]

		#test Add-AzureRmHDInsightMetastore
		Assert-Null $config.OozieMetastore
		Assert-Null $config.HiveMetastore
		$secpasswd = ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force
		$mycreds = New-Object System.Management.Automation.PSCredential ("username", $secpasswd)
		$config = $config | Add-AzureRmHDInsightMetastore -MetastoreType HiveMetastore -SqlAzureServerName server.server.server -DatabaseName dbname -Credential $mycreds
		Assert-NotNull $config.HiveMetastore
		Assert-Null $config.OozieMetastore

		#test Add-AzureRmHDInsightScriptAction
		Assert-AreEqual $config.ScriptActions.Count 0
		Assert-Null $config.ScriptActions["WorkerNode"]
		$config = $config | Add-AzureRmHDInsightScriptAction -NodeType WorkerNode -Uri "http://uri.com" -Name "scriptaction" -Parameters "parameters"
		Assert-AreEqual $config.ScriptActions.Count 1
		Assert-AreEqual $config.ScriptActions["WorkerNode"].Count 1
		$config = $config | Add-AzureRmHDInsightScriptAction -NodeType WorkerNode -Uri "http://uri.com" -Name "scriptaction2" -Parameters "parameters"
		Assert-AreEqual $config.ScriptActions.Count 1
		Assert-AreEqual $config.ScriptActions["WorkerNode"].Count 2

		#test Set-AzureRmHDInsightDefaultStorage
		Assert-Null $config.DefaultStorageAccountName
		Assert-Null $config.DefaultStorageAccountKey
		$config = $config | Set-AzureRmHDInsightDefaultStorage -StorageAccountName fakedefaultaccount -StorageAccountKey DEFAULTACCOUNTKEY==
		Assert-NotNull $config.DefaultStorageAccountName
		Assert-NotNull $config.DefaultStorageAccountKey
    }