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
        #test New-AzHDInsightClusterConfig		
		$config = New-AzHDInsightClusterConfig -ClusterType Hadoop -ClusterTier Standard
		Assert-NotNull $config.ClusterType
		Assert-NotNull $config.ClusterTier
		
		#test Add-AzHDInsightStorage
		Assert-AreEqual $config.AdditionalStorageAccounts.Count 0
		$config = $config | Add-AzHDInsightStorage -StorageAccountName fakestorageaccount -StorageAccountKey STORAGEACCOUNTKEY==
		Assert-AreEqual $config.AdditionalStorageAccounts.Count 1
		
		#test Add-AzHDInsightConfigValues
		Assert-AreEqual $config.Configurations.Count 0
		Assert-Null $config.Configurations["core-site"]
		$coreconfig = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
		$coreconfig.Add('coreconfig', 'corevalue')
		Assert-Null $config.Configurations["core-site"]
		$config = $config | Add-AzHDInsightConfigValues -Core $coreconfig
		Assert-NotNull $config.Configurations["core-site"]

		$oozieconfig = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
		$oozieconfig.Add('oozieconfig', 'oozievalue')
		Assert-Null $config.Configurations["oozie-site"]
		$config = $config | Add-AzHDInsightConfigValues -OozieSite $coreconfig
		Assert-NotNull $config.Configurations["oozie-site"]

		#test Add-AzHDInsightMetastore
		Assert-Null $config.OozieMetastore
		Assert-Null $config.HiveMetastore
		$secpasswd = ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force
		$mycreds = New-Object System.Management.Automation.PSCredential ("username", $secpasswd)
		$config = $config | Add-AzHDInsightMetastore -MetastoreType HiveMetastore -SqlAzureServerName server.server.server -DatabaseName dbname -Credential $mycreds
		Assert-NotNull $config.HiveMetastore
		Assert-Null $config.OozieMetastore

		#test Add-AzHDInsightScriptAction
		Assert-AreEqual $config.ScriptActions.Count 0
		Assert-Null $config.ScriptActions["WorkerNode"]
		$config = $config | Add-AzHDInsightScriptAction -NodeType WorkerNode -Uri "http://uri.com" -Name "scriptaction" -Parameters "parameters"
		Assert-AreEqual $config.ScriptActions.Count 1
		Assert-AreEqual $config.ScriptActions["WorkerNode"].Count 1
		$config = $config | Add-AzHDInsightScriptAction -NodeType WorkerNode -Uri "http://uri.com" -Name "scriptaction2" -Parameters "parameters"
		Assert-AreEqual $config.ScriptActions.Count 1
		Assert-AreEqual $config.ScriptActions["WorkerNode"].Count 2

		#test Set-AzHDInsightDefaultStorage
		Assert-Null $config.DefaultStorageAccountName
		Assert-Null $config.DefaultStorageAccountKey
		$config = $config | Set-AzHDInsightDefaultStorage -StorageAccountName fakedefaultaccount -StorageAccountKey DEFAULTACCOUNTKEY==
		Assert-NotNull $config.DefaultStorageAccountName
		Assert-NotNull $config.DefaultStorageAccountKey

		#test Add-AzHDInsightComponentVersion
		$componentName="Spark"
		$componentVersion="2.3"
		$config=$config | Add-AzHDInsightComponentVersion -ComponentName $componentName -ComponentVersion $componentVersion
		Assert-AreEqual $config.ComponentVersion[$componentName] $componentVersion

		#test Add-AzHDInsightClusterIdentity
		$objectId=New-Guid
		$certificateFilePath="testhost:/testpath/"
		$certificatePassword="testpassword123@"
		$aadTenantId=New-Guid
		$config=$config | Add-AzHDInsightClusterIdentity -ObjectId $objectId -CertificateFilePath $certificateFilePath `
		-CertificatePassword $certificatePassword -AadTenantId $aadTenantId
		Assert-AreEqual $config.CertificatePassword $certificatePassword

		#test Add-AzHDInsightSecurityProfile
		Assert-Null $config.SecurityProfile
		$domain = "sampledomain.onmicrosoft.com"
		$domainUser = "sample.user@sampledomain.onmicrosoft.com"
		$domainPassword = ConvertTo-SecureString "domainPassword" -AsPlainText -Force
		$domainUserCredential = New-Object System.Management.Automation.PSCredential($domainUser, $domainPassword)
		$organizationalUnitDN = "ou=testunitdn"
		$ldapsUrls = ("ldaps://sampledomain.onmicrosoft.com:636","ldaps://sampledomain.onmicrosoft.com:389")
		$clusterUsersGroupDNs = ("groupdn1","groupdn2")
		$config = $config | Add-AzHDInsightSecurityProfile -Domain $domain -DomainUserCredential $domainUserCredential -OrganizationalUnitDN $organizationalUnitDN -LdapsUrls $ldapsUrls -ClusterUsersGroupDNs $clusterUsersGroupDNs 
		Assert-AreEqual $config.SecurityProfile.Domain $domain
		Assert-NotNull $config.SecurityProfile.LdapsUrls
    }

<#
    SYNOPSIS
    Tests create cluster by pipelining config
#>
function Test-CreateClusterByConfigurationPipelining{
	try
	{
		# prepare parameter for creating parameter
		$params = Prepare-ClusterCreateParameter
		#test New-AzHDInsightClusterConfig
		$config = New-AzHDInsightClusterConfig

		#test Set-AzHDInsightDefaultStorage
		$config = Set-AzHDInsightDefaultStorage -Config $config `
			-StorageAccountResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/group-ps-test/providers/Microsoft.Storage/storageAccounts/storagepstest" `
			-StorageAccountKey "Sanitized"

		#test Add-AzHDInsightStorage
		$config = Add-AzHDInsightStorage -Config $config `
			-StorageAccountName "storagepstest.blob.core.windows.net" `
			-StorageAccountKey "Sanitized"
		
		#test Add-AzHDInsightComponentVersion
		$config = Add-AzHDInsightComponentVersion -Config $config -ComponentName "Hadoop" -ComponentVersion "3.3"
		
		#test Add-AzHDInsightConfigValue
		$config = Add-AzHDInsightConfigValue -Config $config -Core @{coreconfig = 'corevalue'}
		
		#test Add-AzHDInsightScriptAction
		$config = Add-AzHDInsightScriptAction -Config $config -NodeType HeadNode -Uri "https://hdiconfigactions.blob.core.windows.net/linuxhueconfigactionv02/install-hue-uber-v02.sh" -Name "InstallHue" -Parameters "-version latest -port 20000"

		#test Add-AzHDInsightMetastore
		$sqlUser="username"
		$sqlPassword = ConvertTo-SecureString "Password" -AsPlainText -Force
		$sqlCredential = New-Object System.Management.Automation.PSCredential($sqlUser, $sqlPassword)
		$config = Add-AzHDInsightMetastore -Config $config `
			-MetastoreType HiveMetastore -SqlAzureServerName "pstestsqldbserver.database.windows.net" `
			-DatabaseName "pstestdb01" -Credential $sqlCredential

		$clusterParams = @{
			ClusterType                     = $params.clusterType
			ClusterSizeInNodes              = $params.clusterSizeInNodes
			ResourceGroupName               = $params.resourceGroupName
			ClusterName                     = $params.clusterName
			HttpCredential                  = $params.httpCredential
			SshCredential                   = $params.sshCredential
			Location                        = $params.location
			MinSupportedTlsVersion          = $params.minSupportedTlsVersion
			VirtualNetworkId                = $params.virtualNetworkId
			SubnetName                      = $params.subnet
			Version                         = $params.version
			Config                          = $config
         }
		$cluster = New-AzHDInsightCluster @clusterParams
		Assert-NotNull $cluster

		$objectId=New-Guid
		$certificateFilePath="testhost:/testpath/"
		$certificatePassword="Sanitized"
		$aadTenantId=New-Guid
		$config = Add-AzHDInsightClusterIdentity -Config $config -ObjectId $objectId -CertificateFilePath $certificateFilePath `
		-CertificatePassword $certificatePassword -AadTenantId $aadTenantId
		Assert-AreEqual $config.CertificateFilePath $certificateFilePath

		$domain = "sampledomain.onmicrosoft.com"
		$domainUser = "sample.user@sampledomain.onmicrosoft.com"
		$domainPassword = ConvertTo-SecureString "domainPassword" -AsPlainText -Force
		$domainUserCredential = New-Object System.Management.Automation.PSCredential($domainUser, $domainPassword)
		$organizationalUnitDN = "ou=testunitdn"
		$ldapsUrls = ("ldaps://sampledomain.onmicrosoft.com:636","ldaps://sampledomain.onmicrosoft.com:389")
		$clusterUsersGroupDNs = ("groupdn1","groupdn2")
		$config = Add-AzHDInsightSecurityProfile -Config $config -DomainResourceId $domain -DomainUserCredential $domainUserCredential `
		-OrganizationalUnitDN $organizationalUnitDN -LdapsUrls $ldapsUrls -ClusterUsersGroupDNs $clusterUsersGroupDNs 
		Assert-AreEqual $config.SecurityProfile.DomainResourceId $domain
		Assert-NotNull $config.SecurityProfile.LdapsUrls
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
	}
}
