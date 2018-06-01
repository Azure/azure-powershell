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
Gets the values of the parameters used at the auditing tests
#>
function Get-SqlAuditingTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "sql-audit-cmdlet-test-rg" +$testSuffix;
			  serverName = "sql-audit-cmdlet-server" +$testSuffix;
			  databaseName = "sql-audit-cmdlet-db" + $testSuffix;
			  storageAccount = "auditcmdlets" +$testSuffix
		}
}

<#
.SYNOPSIS
Gets the values of the parameters used at the blob auditing tests
#>
function Get-SqlBlobAuditingTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "blob-audit-cmdlet-test-rg" + $testSuffix;
			  serverName = "blob-audit-cmdlet-server" + $testSuffix;
			  databaseName = "blob-audit-cmdlet-db" + $testSuffix;
			  storageAccount = "blobaudit" + $testSuffix
		}
}


<#
.SYNOPSIS
Gets the values of the parameters used at the threat detection tests
#>
function Get-SqlThreatDetectionTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "sql-td-cmdlet-test-rg" +$testSuffix;
			  serverName = "sql-td-cmdlet-server" +$testSuffix;
			  databaseName = "sql-td-cmdlet-db" + $testSuffix;
			  storageAccount = "tdcmdlets" +$testSuffix
			  }
}

<#
.SYNOPSIS
Gets the values of the parameters used by the data masking tests
#>
function Get-SqlDataMaskingTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "sql-dm-cmdlet-test-rg" +$testSuffix;
			  serverName = "sql-dm-cmdlet-server" +$testSuffix;
			  databaseName = "sql-dm-cmdlet-db" + $testSuffix;
			  userName = "testuser";
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
			  table1="table1";
			  column1 = "column1";
			  columnInt = "columnInt";
			  table2="table2";
			  column2 = "column2";
			  columnFloat = "columnFloat"
			  }
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql auditing tests
#>
function Create-AuditingTestEnvironment ($testSuffix, $location = "West Central US", $serverVersion = "12.0")
{
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	Create-TestEnvironmentWithParams $params $location $serverVersion
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql blob auditing tests
#>
function Create-BlobAuditingTestEnvironment ($testSuffix, $location = "West Central US", $serverVersion = "12.0")
{
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	Create-TestEnvironmentWithParams $params $location $serverVersion
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql auditing tests with classic storage
#>
function Create-AuditingClassicTestEnvironment ($testSuffix, $location = "West Central US", $serverVersion = "12.0")
{
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	Create-ClassicTestEnvironmentWithParams $params $location $serverVersion
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql auditing tests with classic storage
#>
function Create-BlobAuditingClassicTestEnvironment ($testSuffix, $location = "West Central US", $serverVersion = "12.0")
{
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	Create-ClassicTestEnvironmentWithParams $params $location $serverVersion
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql threat detecion tests
#>
function Create-ThreatDetectionTestEnvironment ($testSuffix, $location = "West Central US", $serverVersion = "12.0")
{
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix
	Create-TestEnvironmentWithParams $params $location $serverVersion
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql threat detecion tests with classic storage
#>
function Create-ThreatDetectionClassicTestEnvironment ($testSuffix, $location = "West Central US", $serverVersion = "12.0")
{
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix
	Create-ClassicTestEnvironmentWithParams $params $location $serverVersion
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql auditing tests
#>
function Create-TestEnvironmentWithParams ($params, $location, $serverVersion)
{
	Create-BasicTestEnvironmentWithParams $params $location $serverVersion
	New-AzureRmStorageAccount -StorageAccountName $params.storageAccount -ResourceGroupName $params.rgname -Location $location -Type Standard_GRS
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql auditing tests
#>
function Create-ClassicTestEnvironmentWithParams ($params, $location, $serverVersion)
{
	Create-BasicTestEnvironmentWithParams $params $location $serverVersion
	try
	{
		New-AzureRmResource -ResourceName $params.storageAccount -ResourceGroupName $params.rgname -ResourceType "Microsoft.ClassicStorage/StorageAccounts" -Location $location -Properties @{ AccountType = "Standard_GRS" } -ApiVersion "2014-06-01" -Force
	}
	catch
	{
		# We catch the exceptions not to fail the tests in playback mode
	}
}

<#
.SYNOPSIS
Creates the basic test environment needed to perform the Sql data security tests - resource group, server and database
#>
function Create-BasicTestEnvironmentWithParams ($params, $location, $serverVersion)
{
	New-AzureRmResourceGroup -Name $params.rgname -Location $location
	$serverName = $params.serverName
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!Sec"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	New-AzureRmSqlServer -ResourceGroupName $params.rgname -ServerName $params.serverName -Location $location -ServerVersion $serverVersion -SqlAdministratorCredentials $credentials
	New-AzureRmSqlDatabase -DatabaseName $params.databaseName -ResourceGroupName $params.rgname -ServerName $params.serverName -Edition Basic
}

<#
Creates the basic test environment needed to perform the Elastic Job agent tests
#>
function Create-ElasticJobAgentTestEnvironment ()
{
	$rg1 = Create-ResourceGroupForTest
	$s1 = Create-ServerForTest $rg1 "westus2"
	$s1fw = $s1 | New-AzureRmSqlServerFirewallRule -AllowAllAzureIPs # allow azure ips
	$db1 = Create-DatabaseForTest $s1
	$agent = Create-AgentForTest $db1
	return $agent
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql data masking tests
#>
function Create-DataMaskingTestEnvironment ($testSuffix)
{
	$params = Get-SqlDataMaskingTestEnvironmentParameters $testSuffix
	$password = $params.pwd
	$secureString = ($password | ConvertTo-SecureString -asPlainText -Force)
	$credentials = new-object System.Management.Automation.PSCredential($params.loginName, $secureString)
	New-AzureRmResourceGroup -Name $params.rgname -Location "West Central US"
	New-AzureRmSqlServer -ResourceGroupName  $params.rgname -ServerName $params.serverName -ServerVersion "12.0" -Location "West Central US" -SqlAdministratorCredentials $credentials
	New-AzureRmSqlServerFirewallRule -ResourceGroupName  $params.rgname -ServerName $params.serverName -StartIpAddress 0.0.0.0 -EndIpAddress 255.255.255.255 -FirewallRuleName "ddmRule"
	New-AzureRmSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	$fullServerName = $params.serverName + ".database.windows.net"

	$uid = $params.userName
	$login = $params.loginName
	$pwd = $params.pwd

	# create new login and user
	$connectionString = "Server=$fullServerName;uid=$login;pwd=$pwd;Database=master;Integrated Security=False;"

	$connection = New-Object System.Data.SqlClient.SqlConnection
	$connection.ConnectionString = $connectionString
	try
	{
		$connection.Open()

		$query = "CREATE LOGIN $uid WITH PASSWORD = '$pwd';"
		$command = $connection.CreateCommand()
		$command.CommandText = $query
		$command.ExecuteReader()
	}
	catch
	{
		# We catch the exceptions not to fail the tests in playback mode
	}
	finally
	{
		$connection.Close()
	}

	# create new user and create table in the database
	$databaseName=$params.databaseName
	$connectionString = "Server=$fullServerName;uid=$login;pwd=$pwd;Database=$databaseName;Integrated Security=False;"

	$connection = New-Object System.Data.SqlClient.SqlConnection
	$connection.ConnectionString = $connectionString
	try
	{
		$connection.Open()

		$table1 = $params.table1
		$column1 = $params.column1
		$columnInt = $params.columnInt

		$table2 = $params.table2
		$column2 = $params.column2
		$columnFloat = $params.columnFloat

		$query = "CREATE TABLE $table1 ($column1 NVARCHAR(20)NOT NULL, $columnInt INT);CREATE TABLE $table2 ($column2 NVARCHAR(20)NOT NULL, $columnFloat DECIMAL(6,3));CREATE USER $uid FOR LOGIN $uid;"
		$command = $connection.CreateCommand()
		$command.CommandText = $query
		$command.ExecuteReader()
	}
	catch
	{
		# We catch the exceptions not to fail the tests in playback mode
	}
	finally
	{
		$connection.Close()
	}
}

<#
.SYNOPSIS
Gets the values of the parameters used in the Server Key Vault Key tests
#>
function Get-SqlServerKeyVaultKeyTestEnvironmentParameters ()
{
	return @{ rgName = Get-ResourceGroupName;
			  serverName = Get-ServerName;
			  databaseName = Get-DatabaseName;
			  keyId = "https://akvtdekeyvault.vault.azure.net/keys/key1/51c2fab9ff3c4a17aab4cd51b932b106";
			  serverKeyName = "akvtdekeyvault_key1_51c2fab9ff3c4a17aab4cd51b932b106";
			  vaultName = "akvtdekeyvault";
			  keyName = "key1"
			  location = "southeastasia";
			  }
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Server Key Vault Key tests
#>
function Create-ServerKeyVaultKeyTestEnvironment ($params)
{
	# Create Resource Group
	$rg = New-AzureRmResourceGroup -Name $params.rgname -Location $params.location -Force

	# Create Server
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$server = New-AzureRmSqlServer -ResourceGroupName  $rg.ResourceGroupName -ServerName $params.serverName -Location $params.location -ServerVersion "12.0" -SqlAdministratorCredentials $credentials
	Assert-AreEqual $server.ServerName $params.serverName

	# Create database
	$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $params.databaseName
	Assert-AreEqual $db.DatabaseName $params.databaseName

	# Return the created resource group
	return $rg
}

<#
.SYNOPSIS
Gets valid resource group name
#>
function Get-ResourceGroupName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid server name
#>
function Get-ServerName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid user name
#>
function Get-UserName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid database name
#>
function Get-DatabaseName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid elastic pool name
#>
function Get-ElasticPoolName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid shard map name
#>
function Get-ShardMapName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid agent name
#>
function Get-AgentName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid target group name
#>
function Get-TargetGroupName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid job credential name
#>
function Get-JobCredentialName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid job name
#>
function Get-JobName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid job step name
#>
function Get-JobStepName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid subscription id
#>
function Get-SubscriptionId
{
	return [guid]::NewGuid().ToString()
}

<#
.SYNOPSIS
Gets valid schema name
#>
function Get-SchemaName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid table name
#>
function Get-TableName
{
	return getAssetname
}

<#
.SYNOPSIS
Gets valid failover group name
#>
function Get-FailoverGroupName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid virtual network rule name
#>
function Get-VirtualNetworkRuleName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid server dns alias name
#>
function Get-ServerDnsAliasName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid managed instance name
#>
function Get-ManagedInstanceName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid managed database name
#>
function Get-ManagedDatabaseName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets test mode - 'Record' or 'Playback'
#>
function Get-SqlTestMode {
	try {
		$testMode = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode;
		$testMode = $testMode.ToString();
	} catch {
		if ($PSItem.Exception.Message -like '*Unable to find type*') {
			$testMode = 'Record';
		} else {
			throw;
		}
	}

	return $testMode
}

<#
.SYNOPSIS
Gets the location for a provider, if not found return East US
#>
function Get-ProviderLocation($provider)
{
	if ((Get-SqlTestMode) -ne 'Playback')
	{
		$namespace = $provider.Split("/")[0]
		if($provider.Contains("/"))
		{
			$type = $provider.Substring($namespace.Length + 1)
			$location = Get-AzureRmResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

			if ($location -eq $null)
			{
				return "East US"
			}
			else
			{
				return $location.Locations[0]
			}
		}

		return "East US"
	}

	return "East US"
}

<#
	.SYNOPSIS
	Creates a resource group for tests
#>
function Create-ResourceGroupForTest ($location = "westcentralus")
{
	$rgName = Get-ResourceGroupName

	$rg = New-AzureRmResourceGroup -Name $rgName -Location $location

	return $rg
}

<#
	.SYNOPSIS
	removes a resource group that was used for testing
#>
function Remove-ResourceGroupForTest ($rg)
{
	Remove-AzureRmResourceGroup -Name $rg.ResourceGroupName -Force
}

<#
	.SYNOPSIS
	Gets the server credential
#>
function Get-ServerCredential
{
	return Get-Credential
}

<#
	.SYNOPSIS
	Gets a random credential
#>
function Get-Credential
{
	$serverLogin = Get-UserName
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	return $credentials
}

<#
	.SYNOPSIS
	Gets a random credential
#>
function Get-Credential
{
	$serverLogin = Get-UserName
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	return $credentials
}

<#
	.SYNOPSIS
	Creates the test environment needed to perform the Sql server CRUD tests
#>
function Create-ServerForTest ($resourceGroup, $location = "Japan East")
{
	$serverName = Get-ServerName
	$credentials = Get-ServerCredential

	$server = New-AzureRmSqlServer -ResourceGroupName  $resourceGroup.ResourceGroupName -ServerName $serverName -Location $location -SqlAdministratorCredentials $credentials
	return $server
}

<#
	.SYNOPSIS
	Creates the test environment needed to perform the Sql elastic pool CRUD tests
#>
function Create-ElasticPoolForTest ($server)
{
	$epName = Get-ElasticPoolName

	$ep = New-AzureRmSqlElasticPool -ResourceGroupName  $server.ResourceGroupName -ServerName $server.ServerName -ElasticPoolName $epName
	return $ep
}

<#
	.SYNOPSIS
	Creates a database with test params
#>
function Create-DatabaseForTest ($server)
{
	$dbName = Get-DatabaseName
	$db = New-AzureRmSqlDatabase -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dbName -Edition Standard -MaxSizeBytes 250GB -RequestedServiceObjectiveName S0
	return $db
}

<#
	.SYNOPSIS
	Creates a sql elastic job agent with test params
#>
function Create-AgentForTest ($db)
{
	$agentName = Get-AgentName
	return New-AzureRmSqlElasticJobAgent -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName -AgentName $agentName
}

<#
	.SYNOPSIS
	Creates a elastic job credential with test params
#>
function Create-JobCredentialForTest ($a)
{
	$credentialName = Get-JobCredentialName
	$credential = Get-ServerCredential

	$jobCredential = New-AzureRmSqlElasticJobCredential -ResourceGroupName $a.ResourceGroupName -ServerName $a.ServerName -AgentName $a.AgentName -CredentialName $credentialName -Credential $credential
	return $jobCredential
}

<#
	.SYNOPSIS
	Creates a elastic job target group with test params
#>
function Create-TargetGroupForTest ($a)
{
	$targetGroupName = Get-TargetGroupName
	$tg = New-AzureRmSqlElasticJobTargetGroup -ResourceGroupName $a.ResourceGroupName -ServerName $a.ServerName -AgentName $a.AgentName -TargetGroupName $targetGroupName
	return $tg
}

<#
	.SYNOPSIS
	Creates a elastic job with test params
#>
function Create-JobForTest ($a, $enabled = $false)
{
	$jobName = Get-JobName
	$job = New-AzureRmSqlElasticJob -ResourceGroupName $a.ResourceGroupName -ServerName $a.ServerName -AgentName $a.AgentName -Name $jobName
	return $job
}

<#
	.SYNOPSIS
	Creates a elastic job step with test params
#>
function Create-JobStepForTest ($j, $tg, $c, $ct)
{
	$jobStepName = Get-JobStepName
	$jobStep = Add-AzureRmSqlElasticJobStep -ResourceGroupName $j.ResourceGroupName -ServerName $j.ServerName -AgentName $j.AgentName -JobName $j.jobName -Name $jobStepName -TargetGroupName $tg.TargetGroupName -CredentialName $c.CredentialName -CommandText $ct
	return $jobStep
}

<#
	.SYNOPSIS
	Remove a server that is no longer needed for tests
#>
function Remove-ServerForTest ($server)
{
	$server | Remove-AzureRmSqlServer -Force
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the Sql threat detection tests
#>
function Remove-ThreatDetectionTestEnvironment ($testSuffix)
{
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix
	Remove-AzureRmResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the Sql auditing tests
#>
function Remove-AuditingTestEnvironment ($testSuffix)
{
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	Remove-AzureRmResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the Sql blob auditing tests
#>
function Remove-BlobAuditingTestEnvironment ($testSuffix)
{
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	Remove-AzureRmResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the Sql data masking tests
#>
function Remove-DataMaskingTestEnvironment ($testSuffix)
{
	$params = Get-SqlDataMaskingTestEnvironmentParameters $testSuffix
	Remove-AzureRmResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Gets the parameters for import/export tests
#>
function Get-SqlDatabaseImportExportTestEnvironmentParameters ($testSuffix)
{
	$databaseName = "sql-ie-cmdlet-db" + $testSuffix;
	$password = [Microsoft.Azure.Test.TestUtilities]::GenerateName("IEp@ssw0rd");
	#Fake storage account data. Used for playback mode
	$exportBacpacUri = "http://test.blob.core.windows.net/bacpacs"
	$importBacpacUri = "http://test.blob.core.windows.net/bacpacs/test.bacpac"
	$storageKey = "StorageKey"

	$testMode = [System.Environment]::GetEnvironmentVariable("AZURE_TEST_MODE")
	if($testMode -eq "Record"){
		$exportBacpacUri = [System.Environment]::GetEnvironmentVariable("TEST_EXPORT_BACPAC")
		$importBacpacUri = [System.Environment]::GetEnvironmentVariable("TEST_IMPORT_BACPAC")
		$storageKey = [System.Environment]::GetEnvironmentVariable("TEST_STORAGE_KEY")

	   if ([System.string]::IsNullOrEmpty($exportBacpacUri)){
		  throw "The TEST_EXPORT_BACPAC environment variable should point to a bacpac that has been uploaded to Azure blob storage ('e.g.' https://test.blob.core.windows.net/bacpacs/empty.bacpac)"
	   }
	   if ([System.string]::IsNullOrEmpty($importBacpacUri)){
		  throw "The  TEST_IMPORT_BACPAC environment variable should point to an Azure blob storage ('e.g.' https://test.blob.core.windows.net/bacpacs)"
	   }
	   if ([System.string]::IsNullOrEmpty($storageKey)){
		  throw "The  TEST_STORAGE_KEY environment variable should point to a valid storage key for an existing Azure storage account"
	   }
	}

	return @{
			  rgname = "sql-ie-cmdlet-test-rg" +$testSuffix;
			  serverName = "sql-ie-cmdlet-server" +$testSuffix;
			  databaseName = $databaseName;
			  userName = "testuser";
			  firewallRuleName = "sql-ie-fwrule" +$testSuffix;
			  password = $password;
			  storageKeyType = "StorageAccessKey";
			  storageKey = $storageKey;
			  exportBacpacUri = $exportBacpacUri + "/" + $databaseName + ".bacpac";
			  importBacpacUri = $importBacpacUri;
			  location = "Australia East";
			  version = "12.0";
			  databaseEdition = "Standard";
			  serviceObjectiveName = "S0";
			  databaseMaxSizeBytes = "5000000";
			  authType = "Sql";
			 }
}

<#
.SYNOPSIS
Gets valid sync group name
#>
function Get-SyncGroupName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid sync member name
#>
function Get-SyncMemberName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid sync agent name
#>
function Get-SyncAgentName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets the values of the parameters used by the sync group tests
#>
function Get-SqlSyncGroupTestEnvironmentParameters ()
{
	return @{ intervalInSeconds = 300;
			  conflictResolutionPolicy = "HubWin";
			  }
}

<#
.SYNOPSIS
Gets the values of the parameters used by the sync member tests
#>
function Get-SqlSyncMemberTestEnvironmentParameters ()
{
	 return @{ syncDirection = "Bidirectional";
			   databaseType = "AzureSqlDatabase";
			   }
}

<#
.SYNOPSIS
Gets dns name according to environment
#>
function Get-DNSNameBasedOnEnvironment ()
{
     $connectingString = [System.Environment]::GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION")
     $parsedString = [Microsoft.Azure.Test.TestUtilities]::ParseConnectionString($connectingString)
     $environment = $parsedString[[Microsoft.Azure.Test.TestEnvironment]::EnvironmentKey]
     if ($environment -eq "Dogfood"){
         return ".sqltest-eg1.mscds.com"
     }
     return ".database.windows.net"
}

<#
	.SYNOPSIS
	Creates the test environment needed to perform the Sql managed instance CRUD tests
#>
function Create-ManagedInstanceForTest ($resourceGroup)
{
	$managedInstanceName = Get-ManagedInstanceName
	$credentials = Get-ServerCredential
	$subnetId = "/subscriptions/ee5ea899-0791-418f-9270-77cd8273794b/resourceGroups/cl_one/providers/Microsoft.Network/virtualNetworks/cl_initial/subnets/CooL"
 	$licenseType = "BasePrice"
  	$storageSizeInGB = 32
 	$vCore = 16
 	$skuName = "GP_Gen4"

	$managedInstance = New-AzureRmSqlManagedInstance -ResourceGroupName $resourceGroup.ResourceGroupName -Name $managedInstanceName `
 			-Location $resourceGroup.Location -AdministratorCredential $credentials -SubnetId $subnetId `
  			-LicenseType $licenseType -StorageSizeInGB $storageSizeInGB -Vcore $vCore -SkuName $skuName

	return $managedInstance
}