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
Gets the values of the parameters used at the data masking tests
#>
function Get-SqlDataMaskingTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "sql-dm-cmdlet-test-rg" +$testSuffix;
			  serverName = "sql-dm-cmdlet-server" +$testSuffix;
			  databaseName = "sql-dm-cmdlet-db" + $testSuffix
			  }
}

<#
.SYNOPSIS
Gets the values of the parameters used in the s
#>
function Get-SqlDataMaskingTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "sql-dm-cmdlet-test-rg" +$testSuffix;
			  serverName = "sql-dm-cmdlet-server" +$testSuffix;
			  databaseName = "sql-dm-cmdlet-db" + $testSuffix
			  }
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql auditing tests
#>
function Create-TestEnvironment ($testSuffix)
{
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	Azure\New-AzureStorageAccount -StorageAccountName $params.storageAccount -Location "West US" 
	New-AzureResourceGroup -Name $params.rgname -Location "West US" -TemplateFile ".\Templates\sql-audit-test-env-setup.json" -serverName $params.serverName -databaseName $params.databaseName -EnvLocation "West US" -Force
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql data masking tests
#>
function Create-DataMaskingTestEnvironment ($testSuffix)
{
	$params = Get-SqlDataMaskingTestEnvironmentParameters $testSuffix
	New-AzureResourceGroup -Name $params.rgname -Location "West US" -TemplateFile ".\Templates\sql-audit-test-env-setup.json" -serverName $params.serverName -databaseName $params.databaseName -EnvLocation "West US" -Force
	return $params
}

<#
	.SYNOPSIS
	Creates a resource group for tests
#>
function Create-ResourceGroupForTest ()
{
	$guid = [System.Guid]::NewGuid().ToString()
	$location = "Japan East"
	$rgName = "sql-ps-test-rg-" + $guid
	$rg = New-AzureResourceGroup -Name $rgName -Location $location

	return $rg
}


<#
	.SYNOPSIS 
	removes a resource group that was used for testing
	#>
function Remove-ResourceGroupForTest ($rg)
{
	Remove-AzureResourceGroup -Name $rg.ResourceGroupName -Force
}

<#
	.SYNOPSIS
	Creates the test environment needed to perform the Sql server CRUD tests
#>
function Create-ServerForTest ($resourceGroup)
{
	$guid = [System.Guid]::NewGuid().ToString()
	
	$serverName = "sql-ps-test-server-" + $guid
	$version = "12.0"
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force)) 

	$server = New-AzureSqlDatabaseServer -ResourceGroupName  $resourceGroup.Name -ServerName $serverName -Location $resourceGroup.location -ServerVersion $version -SqlAdminCredentials $credentials
	return $server
}

<#
	.SYNOPSIS
	Remove a server that is no longer needed for tests
#>
function Remove-ServerForTest ($server)
{
	$server | Remove-AzureSqlDatabaseServer -Force
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the Sql auditing tests
#>
function Remove-TestEnvironment ($testSuffix)
{
	try
	{
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix
	Azure\Remove-AzureStorageAccount -StorageAccountName $params.storageAccount
	}
	catch
	{
	}
}