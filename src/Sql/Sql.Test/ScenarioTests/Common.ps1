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
	$subscriptionId = (Get-AzContext).Subscription.Id
	return @{ rgname = "audit-cmdlet-test-rg" + $testSuffix;
			  serverName = "audit-cmdlet-server" + $testSuffix;
			  databaseName = "audit-cmdlet-db" + $testSuffix;
			  storageAccount = "blobaudit" + $testSuffix
			  eventHubNamespace = "audit-cmdlet-event-hub-ns" + $testSuffix
			  workspaceName = "audit-cmdlet-workspace" +$testSuffix
			  storageAccountResourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + "audit-cmdlet-test-rg" + $testSuffix + "/providers/Microsoft.Storage/storageAccounts/" + "blobaudit" + $testSuffix
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
Creates the test environment needed to perform the Sql blob auditing tests
#>
function Create-BlobAuditingTestEnvironment ($testSuffix, $location = "West Central US", $serverVersion = "12.0", $denyAsNetworkRuleDefaultAction = $False)
{
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	Create-TestEnvironmentWithParams $params $location $serverVersion $denyAsNetworkRuleDefaultAction
	New-AzOperationalInsightsWorkspace -ResourceGroupName $params.rgname -Name $params.workspaceName -Sku "Standard" -Location "eastus"
	New-AzEventHubNamespace -ResourceGroupName $params.rgname -NamespaceName $params.eventHubNamespace -Location $location
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
function Create-TestEnvironmentWithParams ($params, $location, $serverVersion, $denyAsNetworkRuleDefaultAction = $False)
{
	Create-BasicTestEnvironmentWithParams $params $location $serverVersion
	New-AzStorageAccount -StorageAccountName $params.storageAccount -ResourceGroupName $params.rgname -Location $location -Type Standard_GRS -DenyAsNetworkRuleDefaultAction $denyAsNetworkRuleDefaultAction
	Wait-Seconds 10
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql vulnerability assessment tests on managed instance
#>
function Create-InstanceTestEnvironmentWithParams ($params, $location)
{
	Create-BasicManagedTestEnvironmentWithParams $params $location

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
		New-AzResource -ResourceName $params.storageAccount -ResourceGroupName $params.rgname -ResourceType "Microsoft.ClassicStorage/StorageAccounts" -Location $location -Properties @{ AccountType = "Standard_GRS" } -ApiVersion "2014-06-01" -Force
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
	New-AzResourceGroup -Name $params.rgname -Location $location
	$serverName = $params.serverName
	$serverLogin = "testusername"
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
	$serverPassword = "t357ingP@s5w0rd!Sec"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	New-AzSqlServer -ResourceGroupName $params.rgname -ServerName $params.serverName -Location $location -ServerVersion $serverVersion -SqlAdministratorCredentials $credentials
	New-AzSqlDatabase -DatabaseName $params.databaseName -ResourceGroupName $params.rgname -ServerName $params.serverName -Edition Basic
}

<#
.SYNOPSIS
Creates the basic test environment needed to perform the Sql data security tests - resource group, managed instance and managed database
#>
function Create-BasicManagedTestEnvironmentWithParams ($params, $location)
{
	New-AzureRmResourceGroup -Name $params.rgname -Location $location

	# Setup VNET
	$vnetName = "cl_initial"
	$subnetName = "Cool"
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id
	$credentials = Get-ServerCredential
 	$licenseType = "BasePrice"
  	$storageSizeInGB = 32
 	$vCore = 16
 	$skuName = "GP_Gen5"
	$collation = "SQL_Latin1_General_CP1_CI_AS"

	$managedInstance = New-AzureRmSqlInstance -ResourceGroupName $params.rgname -Name $params.serverName `
 			-Location $location -AdministratorCredential $credentials -SubnetId $subnetId `
  			-Vcore $vCore -SkuName $skuName

	New-AzureRmSqlInstanceDatabase -ResourceGroupName $params.rgname -InstanceName $params.serverName -Name $params.databaseName -Collation $collation
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
	New-AzResourceGroup -Name $params.rgname -Location "West Central US"
    New-AzSqlServer -ResourceGroupName  $params.rgname -ServerName $params.serverName -ServerVersion "12.0" -Location "West Central US" -SqlAdministratorCredentials $credentials
	New-AzSqlServerFirewallRule -ResourceGroupName  $params.rgname -ServerName $params.serverName -StartIpAddress 0.0.0.0 -EndIpAddress 255.255.255.255 -FirewallRuleName "ddmRule"
	New-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record")
	{
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
}

<#
Creates the basic test environment needed to perform the Elastic Job agent tests
#>
function Create-ElasticJobAgentTestEnvironment ()
{
	$location = Get-Location "Microsoft.Sql" "operations" "West US 2"
	$rg1 = Create-ResourceGroupForTest
	$s1 = Create-ServerForTest $rg1 $location
	$s1fw = $s1 | New-AzSqlServerFirewallRule -AllowAllAzureIPs # allow azure ips
	$db1 = Create-DatabaseForTest $s1
	$agent = Create-AgentForTest $db1
	return $agent
}

<#
	.SYNOPSIS
	Creates the test environment needed to perform the Sql elastic pool CRUD tests
#>
function Create-ElasticPoolForTest ($server)
{
	$epName = Get-ElasticPoolName
	$ep = New-AzSqlElasticPool -ResourceGroupName  $server.ResourceGroupName -ServerName $server.ServerName -ElasticPoolName $epName
	return $ep
}


<#
.SYNOPSIS
Gets the values of the parameters used in the Server Key Vault Key tests
#>
function Get-SqlServerKeyVaultKeyTestEnvironmentParameters ()
{
	# Create a key vault with soft delete.configured
	return @{ rgName = Get-ResourceGroupName;
			  serverName = Get-ServerName;
			  databaseName = Get-DatabaseName;
			  keyId = "https://akvtdekeyvaultcl.vault.azure.net/keys/key1/738a177a3b0d45e98d366fdf738840e8";
			  serverKeyName = "akvtdekeyvaultcl_key1_738a177a3b0d45e98d366fdf738840e8";
			  vaultName = "akvtdekeyvaultcl";
			  keyName = "key1"
			  location = "westcentralus";
			  }
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Server Key Vault Key tests
#>
function Create-ServerKeyVaultKeyTestEnvironment ($params)
{
	# Create Resource Group
	$rg = New-AzResourceGroup -Name $params.rgname -Location $params.location -Force

	# Create Server
	$serverLogin = "testusername"
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	$server = New-AzSqlServer -ResourceGroupName  $rg.ResourceGroupName -ServerName $params.serverName -Location $params.location -ServerVersion "12.0" -SqlAdministratorCredentials $credentials -AssignIdentity
	Assert-AreEqual $server.ServerName $params.serverName

	# Create database
	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $params.databaseName
	Assert-AreEqual $db.DatabaseName $params.databaseName

	#Set permissions on key Vault
	Set-AzKeyVaultAccessPolicy -VaultName $params.vaultName -ObjectId $server.Identity.PrincipalId -PermissionsToKeys get, list, wrapKey, unwrapKey

	# Return the created resource group
	return $rg
}


<#
.SYNOPSIS
Creates test managed instance
#>
function Get-ManagedInstanceForTdeTest ($params)
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$vnetName = "cl_initial"
	$subnetName = "Cool"

	# Setup VNET
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId
	Set-AzKeyVaultAccessPolicy -VaultName $params.vaultName -ObjectId $managedInstance.Identity.PrincipalId -PermissionsToKeys get, list, wrapKey, unwrapKey

	return $managedInstance
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
Gets valid shard map name
#>
function Get-ShardMapName
{
	return getAssetName
}

<#
.SYNOPSIS
Gets valid shard agent name
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
Gets valid elastic pool name
#>
function Get-ElasticPoolName
{
    return getAssetName
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
Gets valid vnet name
#>
function Get-VNetName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid managed instance operation name
#>
function Get-ManagedInstanceOperationName
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
			$location = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

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

	$rg = New-AzResourceGroup -Name $rgName -Location $location

	return $rg
}

<#
	.SYNOPSIS
	removes a resource group that was used for testing
#>
function Remove-ResourceGroupForTest ($rg)
{
	Remove-AzResourceGroup -Name $rg.ResourceGroupName -Force
}

<#
	.SYNOPSIS
	Gets the server credential
#>
function Get-ServerCredential
{
	$serverLogin = "testusername"
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force))
	return $credentials
}

<#
	.SYNOPSIS
	Gets a random credential
#>
function Get-Credential ($serverLogin)
{
	if ($serverLogin -eq $null)
	{
		$serverLogin = Get-UserName
	}
	<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]#>
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

	$server = New-AzSqlServer -ResourceGroupName  $resourceGroup.ResourceGroupName -ServerName $serverName -Location $location -SqlAdministratorCredentials $credentials
	return $server
}

<#
	.SYNOPSIS
	Remove a server that is no longer needed for tests
#>
function Remove-ServerForTest ($server)
{
	$server | Remove-AzSqlServer -Force
}

<#
	.SYNOPSIS
	Creates a database with test params
#>
function Create-DatabaseForTest ($server)
{
	$dbName = Get-DatabaseName
	$db = New-AzSqlDatabase -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dbName -Edition Standard -MaxSizeBytes 250GB -RequestedServiceObjectiveName S0
	return $db
}

<#
	.SYNOPSIS
	Creates a sql elastic job agent with test params
#>
function Create-AgentForTest ($db)
{
	$agentName = Get-AgentName
	return New-AzSqlElasticJobAgent -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName -AgentName $agentName
}

<#
	.SYNOPSIS
	Creates a elastic job credential with test params
#>
function Create-JobCredentialForTest ($a)
{
	$credentialName = Get-JobCredentialName
	$credential = Get-ServerCredential

	$jobCredential = New-AzSqlElasticJobCredential -ResourceGroupName $a.ResourceGroupName -ServerName $a.ServerName -AgentName $a.AgentName -CredentialName $credentialName -Credential $credential
	return $jobCredential
}

<#
	.SYNOPSIS
	Creates a elastic job target group with test params
#>
function Create-TargetGroupForTest ($a)
{
	$targetGroupName = Get-TargetGroupName
	$tg = New-AzSqlElasticJobTargetGroup -ResourceGroupName $a.ResourceGroupName -ServerName $a.ServerName -AgentName $a.AgentName -TargetGroupName $targetGroupName
	return $tg
}

<#
	.SYNOPSIS
	Creates a elastic job with test params
#>
function Create-JobForTest ($a, $enabled = $false)
{
	$jobName = Get-JobName
	$job = New-AzSqlElasticJob -ResourceGroupName $a.ResourceGroupName -ServerName $a.ServerName -AgentName $a.AgentName -Name $jobName
	return $job
}

<#
	.SYNOPSIS
	Creates a elastic job step with test params
#>
function Create-JobStepForTest ($j, $tg, $c, $ct)
{
	$jobStepName = Get-JobStepName
	$jobStep = Add-AzSqlElasticJobStep -ResourceGroupName $j.ResourceGroupName -ServerName $j.ServerName -AgentName $j.AgentName -JobName $j.jobName -Name $jobStepName -TargetGroupName $tg.TargetGroupName -CredentialName $c.CredentialName -CommandText $ct
	return $jobStep
}


<#
.SYNOPSIS
Removes the test environment that was needed to perform the Sql threat detection tests
#>
function Remove-ThreatDetectionTestEnvironment ($testSuffix)
{
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the Sql auditing tests
#>
function Remove-AuditingTestEnvironment ($testSuffix)
{
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the Sql blob auditing tests
#>
function Remove-BlobAuditingTestEnvironment ($testSuffix)
{
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the Sql data masking tests
#>
function Remove-DataMaskingTestEnvironment ($testSuffix)
{
	$params = Get-SqlDataMaskingTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Gets the parameters for import/export tests
#>
function Get-SqlDatabaseImportExportTestEnvironmentParameters ($testSuffix)
{
    $databaseName = "sql-ie-cmdlet-db" + $testSuffix;
    # TODO: Remove "CallSite.Target" when re-recording ImportExportTests
    $password = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::GenerateName("IEp@ssw0rd");
    #Fake storage account data. Used for playback mode
    $exportBacpacUri = "http://test.blob.core.windows.net/bacpacs"
    $importBacpacUri = "http://test.blob.core.windows.net/bacpacs/test.bacpac"
    $storageKey = "StorageKey"
    $storageResourceId = "/subscriptions/xys/resourcegroups/default/providers/Microsoft.Storage/test"

    $testMode = [System.Environment]::GetEnvironmentVariable("AZURE_TEST_MODE")
    if($testMode -eq "Record"){
        $exportBacpacUri = [System.Environment]::GetEnvironmentVariable("TEST_EXPORT_BACPAC")
        $importBacpacUri = [System.Environment]::GetEnvironmentVariable("TEST_IMPORT_BACPAC")
        $storageKey = [System.Environment]::GetEnvironmentVariable("TEST_STORAGE_KEY")
        $storageResourceId = [System.Environment]::GetEnvironmentVariable("TEST_STORAGE_RESOURCE_ID")

       if ([System.string]::IsNullOrEmpty($exportBacpacUri)){
          throw "The TEST_EXPORT_BACPAC environment variable should point to a bacpac that has been uploaded to Azure blob storage ('e.g.' https://test.blob.core.windows.net/bacpacs/empty.bacpac)"
       }
       if ([System.string]::IsNullOrEmpty($importBacpacUri)){
          throw "The  TEST_IMPORT_BACPAC environment variable should point to an Azure blob storage ('e.g.' https://test.blob.core.windows.net/bacpacs)"
       }
       if ([System.string]::IsNullOrEmpty($storageKey)){
          throw "The  TEST_STORAGE_KEY environment variable should point to a valid storage key for an existing Azure storage account"
       }
       if ([System.string]::IsNullOrEmpty($storageResourceId)){
          throw "The  TEST_STORAGE_RESOURCE_ID environment variable should point to the resource id for the storage account"
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
              location = "West Central US";
              version = "12.0";
              databaseEdition = "GeneralPurpose";
              serviceObjectiveName = "GP_Gen5_2";
              databaseMaxSizeBytes = "1073741824";
              authType = "Sql";
              storageResourceId = $storageResourceId;
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
     $parsedString = [Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::ParseConnectionString($connectingString)
     $environment = $parsedString[[Microsoft.Rest.ClientRuntime.Azure.TestFramework.ConnectionStringKeys]::EnvironmentKey]
     if ($environment -eq "Dogfood"){
         return ".sqltest-eg1.mscds.com"
     }
     return ".database.windows.net"
}

<#
	.SYNOPSIS
	Creates the test environment needed to perform the Sql managed instance CRUD tests
#>
function Create-ManagedInstanceForTest ($resourceGroup, $subnetId)
{
	$managedInstanceName = Get-ManagedInstanceName
	$credentials = Get-ServerCredential
 	$vCore = 16
 	$skuName = "GP_Gen5"

	$managedInstance = New-AzSqlInstance -ResourceGroupName $resourceGroup.ResourceGroupName -Name $managedInstanceName `
 			-Location $resourceGroup.Location -AdministratorCredential $credentials -SubnetId $subnetId `
  			-Vcore $vCore -SkuName $skuName -AssignIdentity

	return $managedInstance
}

<#
	.SYNOPSIS
	Asyn update of hardware generation on Sql managed instance
#>
function Update-ManagedInstanceGenerationForTest ($resourceGroup, $managedInstance)
{
 	$computeGeneration = "Gen5"

	$managedInstance = Set-AzSqlInstance -ResourceGroupName $resourceGroup.ResourceGroupName -Name $managedInstance.ManagedInstanceName `
 			 -ComputeGeneration $computeGeneration -Force -AsJob

	return $managedInstance
}

<#
	.SYNOPSIS
	Sync update of storage on Sql managed instance
#>
function Update-ManagedInstanceStorageForTest ($resourceGroup, $managedInstance)
{
	$storageSize = 928

	$managedInstance = Set-AzSqlInstance -ResourceGroupName $resourceGroup.ResourceGroupName -Name $managedInstance.ManagedInstanceName `
 			-StorageSizeInGb $storageSize -Force

	return $managedInstance
}

<#
	.SYNOPSIS
	Creates a managed instance in an instance pool
#>
function Create-ManagedInstanceInInstancePoolForTest ($instancePool)
{
    $managedInstanceName = Get-ManagedInstanceName
    $credentials = Get-ServerCredential
    $vCore = 2
    $managedInstance = $instancePool | New-AzSqlInstance -Name $managedInstanceName -VCore $vCore -AdministratorCredential $credentials -StorageSizeInGb 32 -PublicDataEndpointEnabled
    return $managedInstance
}

function Remove-ManagedInstancesInInstancePool($instancePool)
{
    $instancePool | Get-AzSqlInstance | Remove-AzSqlInstance -Force
}


function Get-InstancePoolTestProperties()
{
    $tags = @{ instance="Pools" };

    $instancePoolTestProperties = @{
        resourceGroup = "ps3995"
        name = "myinstancepool1"
        subnetName = "ManagedInsanceSubnet"
        vnetName = "MIVirtualNetwork"
        tags = $tags
        computeGen = "Gen5"
        edition = "GeneralPurpose"
        location = "westeurope"
        licenseType = "LicenseIncluded"
        vCores = 16
    }
    return $instancePoolTestProperties
}

<#
	.SYNOPSIS
	Creates an instance pool for Sql instance pool CRUD tests
#>
function Create-InstancePoolForTest()
{
    $props = Get-InstancePoolTestProperties
    $virtualNetwork = CreateAndGetVirtualNetworkForManagedInstance $props.vnetName $props.subnetName $props.location "v-urmila"
    $subnetId = $virtualNetwork.Subnets.where({ $_.Name -eq $props.subnetName })[0].Id
    $instancePool = New-AzSqlInstancePool -ResourceGroupName $props.resourceGroup -Name $props.name `
                -Location $props.location -SubnetId $subnetId -VCore $props.vCores `
                -Edition $props.Edition -ComputeGeneration $props.computeGen `
                -LicenseType $props.licenseType -Tag $props.tags
    return $instancePool
}

<#
	.SYNOPSIS
	Create a virtual network

	If resource group $resourceGroupName does not exist, then please create it before running the test.
	We deliberately do not create it, because if we did then ResourceGroupCleaner (inside MockContext) would delete it
	at the end of the test, which prevents us from reusing the subnet and therefore massively slows down
	managed instance scenario tests.
#>
function CreateAndGetVirtualNetworkForManagedInstance ($vnetName, $subnetName, $location = "westcentralus", $resourceGroupName = "cl_one")
{
	$vNetAddressPrefix = "10.0.0.0/16"
	$defaultSubnetAddressPrefix = "10.0.0.0/24"

	try {
		$getVnet = DelegateSubnetToSQLMIAndGetVnet $vnetName $subnetName $resourceGroupName
		return $getVnet
	} catch {
		$virtualNetwork = New-AzVirtualNetwork `
							-ResourceGroupName $resourceGroupName `
							-Location $location `
							-Name $vNetName `
							-AddressPrefix $vNetAddressPrefix
 		$subnetConfig = Add-AzVirtualNetworkSubnetConfig `
								-Name $subnetName `
								-AddressPrefix $defaultSubnetAddressPrefix `
								-VirtualNetwork $virtualNetwork
 		$virtualNetwork | Set-AzVirtualNetwork
 		$routeTableMiManagementService = New-AzRouteTable `
								-Name 'myRouteTableMiManagementService' `
								-ResourceGroupName $resourceGroupName `
								-location $location
 		Set-AzVirtualNetworkSubnetConfig `
								-VirtualNetwork $virtualNetwork `
								-Name $subnetName `
								-AddressPrefix $defaultSubnetAddressPrefix `
								-RouteTable $routeTableMiManagementService | `
							Set-AzVirtualNetwork
 		Get-AzRouteTable `
								-ResourceGroupName $resourceGroupName `
								-Name "myRouteTableMiManagementService" `
								| Add-AzRouteConfig `
								-Name "ToManagedInstanceManagementService" `
								-AddressPrefix 0.0.0.0/0 `
								-NextHopType "Internet" `
								| Set-AzRouteTable

		$getVnet = DelegateSubnetToSQLMIAndGetVnet $vnetName $subnetName $resourceGroupName
		return $getVnet
	}
}

<#
	.SYNOPSIS
	Delegate subnet to SQL MI service if not already delegated.
#>
function DelegateSubnetToSQLMIAndGetVnet ($vnetName, $subnetName, $resourceGroupName)
{
	$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName
	$subnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet

	$delegations = Get-AzDelegation -Subnet $subnet | ? {$_.ServiceName -eq "Microsoft.Sql/managedInstances"}

	# Condition (Get-SqlTestMode) -eq 'Record' is addedd in order to skip this path in Playback mode
	if ($delegations -eq $null -and (Get-SqlTestMode) -eq 'Record'){
		$subnet = Add-AzDelegation -Name "test-delegation-sqlmi" -ServiceName "Microsoft.Sql/managedInstances" -Subnet $subnet
		Set-AzVirtualNetwork -VirtualNetwork $vnet
		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName
        $subnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
	}

	if ($subnet.NetworkSecurityGroup -eq $null -and (Get-SqlTestMode) -eq 'Record'){
		$inboundAllowAllRule = New-AzNetworkSecurityRuleConfig -Name allow-all-inbound -Description "Allow all inbound" `
					-Access Allow -Protocol * -Direction Inbound -Priority 100 -SourceAddressPrefix * `
					-SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange *

		$outboundAllowAllRule = New-AzNetworkSecurityRuleConfig -Name allow-all-outbound -Description "Allow all outbound" `
					-Access Allow -Protocol * -Direction Outbound -Priority 100 -SourceAddressPrefix * `
					-SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange *

		$nsg = New-AzNetworkSecurityGroup `
			-Name "$vnetName-$subnetName-nsg-allow-all" `
			-ResourceGroupName $resourceGroupName `
			-location $vnet.Location `
			-SecurityRules $inboundAllowAllRule, $outboundAllowAllRule `
            -Force

        $subnet.NetworkSecurityGroup += $nsg

		Set-AzVirtualNetwork -VirtualNetwork $vnet

		$vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroupName
    }

	return $vnet
}

<#
	.SYNOPSIS
	Generates default public maintenance configuration id for specified location
#>
function Get-DefaultPublicMaintenanceConfigurationId($location)
{
	$subscriptionId = (Get-AzContext).Subscription.Id

	return "/subscriptions/${subscriptionId}/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_Default";
}

<#
	.SYNOPSIS
	Generates public maintenance configuration id for specified location and schedule name
#>
function Get-PublicMaintenanceConfigurationName($location, $scheduleName)
{
	$shortLocation = $location -replace '\s',''

	return "SQL_${shortLocation}_${scheduleName}";
}

<#
	.SYNOPSIS
	Generates public maintenance configuration id for specified location and schedule name
#>
function Get-PublicMaintenanceConfigurationId($location, $scheduleName)
{
	$subscriptionId = (Get-AzContext).Subscription.Id
	$configName = Get-PublicMaintenanceConfigurationName $location $scheduleName

	return "/subscriptions/${subscriptionId}/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/${configName}";
}
