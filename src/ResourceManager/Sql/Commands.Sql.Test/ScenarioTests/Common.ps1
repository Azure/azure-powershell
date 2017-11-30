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
			  location = "centraluseuap";
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
	$serverLogin = "testusername"
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