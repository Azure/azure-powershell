﻿# ----------------------------------------------------------------------------------
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
function Create-TestEnvironment ($testSuffix)
{
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	Create-TestEnvironmentWithParams ($params)
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql auditing tests
#>
function Create-TestEnvironmentWithParams ($params)
{
	New-AzureRmResourceGroup -Name $params.rgname -Location "West US" -Force
	New-AzureRmResourceGroupDeployment -ResourceGroupName $params.rgname -TemplateFile ".\Templates\sql-audit-test-env-setup-classic-storage.json" -serverName $params.serverName -databaseName $params.databaseName -storageName $params.storageAccount  -Force
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql auditing tests, while using storage  V2 as the used storage account
#>
function Create-TestEnvironmentWithStorageV2 ($testSuffix)
{
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	New-AzureRmResourceGroup -Name $params.rgname -Location "West US" -Force
	New-AzureRmResourceGroupDeployment -ResourceGroupName $params.rgname -TemplateFile ".\Templates\sql-audit-test-env-setup-storageV2.json" -serverName $params.serverName -databaseName $params.databaseName -storageName $params.storageAccount  -Force
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql threat detection tests, while using storage  V2 as the used storage account
#>
function Create-ThreatDetectionTestEnvironmentWithStorageV2 ($testSuffix, $serverVersion = "12.0")
{
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix
	New-AzureRmResourceGroup -Name $params.rgname -Location "Australia East" -Force
    New-AzureRmResourceGroupDeployment -ResourceGroupName $params.rgname -TemplateFile ".\Templates\sql-td-test-env-setup.json" -serverName $params.serverName -version $serverVersion -databaseName $params.databaseName  -storageName $params.storageAccount -Force
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql data masking tests
#>
function Create-DataMaskingTestEnvironment ($testSuffix)
{
	$params = Get-SqlDataMaskingTestEnvironmentParameters $testSuffix
	New-AzureRmResourceGroup -Name $params.rgname -Location "Australia East" -Force
	New-AzureRmResourceGroupDeployment -ResourceGroupName $params.rgname -TemplateFile ".\Templates\sql-ddm-test-env-setup.json" -serverName $params.serverName -databaseName $params.databaseName -EnvLocation "Australia East" -administratorLogin $params.userName -Force
	$fullServerName = $params.serverName + ".database.windows.net"
	
	$uid = $params.userName
	$pwd = $params.pwd
		
	$databaseName=$params.databaseName
	$connectionString = "Server=$fullServerName;uid=$uid; pwd=$pwd;Database=$databaseName;Integrated Security=False;"

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
	}
	finally
	{
		$connection.Close()
	}
	return $params
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
	Creates a resource group for tests
#>
function Create-ResourceGroupForTest ($location = "Japan East")
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
	Creates the test environment needed to perform the Sql server CRUD tests
#>
function Create-ServerForTest ($resourceGroup, $serverVersion = "12.0", $location = "Japan East")
{
	$serverName = Get-ServerName
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force)) 
	
	$server = New-AzureRmSqlServer -ResourceGroupName  $resourceGroup.ResourceGroupName -ServerName $serverName -Location $location -ServerVersion $serverVersion -SqlAdministratorCredentials $credentials
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
Removes the test environment that was needed to perform the Sql auditing tests
#>
function Remove-TestEnvironment ($testSuffix)
{
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the Sql threat detection tests
#>
function Remove-ThreatDetectionTestEnvironment ($testSuffix)
{
	try
	{
	    $params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix
	    Azure\Remove-AzureRmStorageAccount -StorageAccountName $params.storageAccount
	}
	catch
	{
	}
}