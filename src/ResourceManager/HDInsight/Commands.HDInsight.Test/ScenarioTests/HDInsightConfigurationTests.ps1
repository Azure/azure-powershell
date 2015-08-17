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
        #test New-AzureHDInsightClusterConfig
		$config = New-AzureHDInsightClusterConfig -ClusterType Hadoop
		Assert-NotNull $config.ClusterType
		
		#test Add-AzureHDInsightStorage
		Assert-AreEqual $config.AdditionalStorageAccounts.Count 0
		$config = $config | Add-AzureHDInsightStorage -StorageAccountName fakestorageaccount -StorageAccountKey STORAGEACCOUNTKEY==
		Assert-AreEqual $config.AdditionalStorageAccounts.Count 1
		
		#test Add-AzureHDInsightConfigValues
		Assert-AreEqual $config.Configurations.Count 0
		Assert-Null $config.Configurations["core-site"]
		$coreconfig = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
		$coreconfig.Add('coreconfig', 'corevalue')
		Assert-Null $config.Configurations["core-site"]
		$config = $config | Add-AzureHDInsightConfigValues -Core $coreconfig
		Assert-NotNull $config.Configurations["core-site"]

		$oozieconfig = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
		$oozieconfig.Add('oozieconfig', 'oozievalue')
		Assert-Null $config.Configurations["oozie-site"]
		$config = $config | Add-AzureHDInsightConfigValues -OozieSite $coreconfig
		Assert-NotNull $config.Configurations["oozie-site"]

		#test Add-AzureHDInsightMetastore
		Assert-Null $config.OozieMetastore
		Assert-Null $config.HiveMetastore
		$secpasswd = ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force
		$mycreds = New-Object System.Management.Automation.PSCredential ("username", $secpasswd)
		$config = $config | Add-AzureHDInsightMetastore -MetastoreType HiveMetastore -SqlAzureServerName server.server.server -DatabaseName dbname -Credential $mycreds
		Assert-NotNull $config.HiveMetastore
		Assert-Null $config.OozieMetastore

		#test Add-AzureHDInsightScriptAction
		Assert-AreEqual $config.ScriptActions.Count 0
		Assert-Null $config.ScriptActions["WorkerNode"]
		$config = $config | Add-AzureHDInsightScriptAction -NodeType WorkerNode -Uri "http://uri.com" -Name "scriptaction" -Parameters "parameters"
		Assert-AreEqual $config.ScriptActions.Count 1
		Assert-AreEqual $config.ScriptActions["WorkerNode"].Count 1
		$config = $config | Add-AzureHDInsightScriptAction -NodeType WorkerNode -Uri "http://uri.com" -Name "scriptaction2" -Parameters "parameters"
		Assert-AreEqual $config.ScriptActions.Count 1
		Assert-AreEqual $config.ScriptActions["WorkerNode"].Count 2

		#test Set-AzureHDInsightDefaultStorage
		Assert-Null $config.DefaultStorageAccountName
		Assert-Null $config.DefaultStorageAccountKey
		$config = $config | Set-AzureHDInsightDefaultStorage -StorageAccountName fakedefaultaccount -StorageAccountKey DEFAULTACCOUNTKEY==
		Assert-NotNull $config.DefaultStorageAccountName
		Assert-NotNull $config.DefaultStorageAccountKey
    }