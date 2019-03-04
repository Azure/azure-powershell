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
Tests end to end scenario of Data Classification on a SQL database.
#>
function Test-DataClassificationOnSqlDatabase
{
	# Setup
	# $testSuffix = getAssetName
	# Create-SqlDataClassificationTestEnvironment $testSuffix
	# $params = Get-DataClassificationTestEnvironmentParameters $testSuffix

	try
	{
		# $recommendations = Get-AzSqlDatabaseSensitivityRecommendations -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		# Assert-AreEqual $params.rgname $recommendations.ResourceGroupName
		# Assert-AreEqual $params.serverName $recommendations.ServerName
		# Assert-AreEqual $params.databaseName $recommendations.DatabaseName
		# Assert-AreEqual 4 ($recommendations.SensitivityLabels).count
	}
	finally
	{
		# Cleanup
		# Remove-DataClassificationTestEnvironmentParameters $testSuffix
	}
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-DataClassificationTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "dc-cmdlet-test-rg" +$testSuffix;
			  serverName = "dc-cmdlet-server" +$testSuffix;
			  databaseName = "dc-cmdlet-db" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
		}
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-ManagedDataClassificationTestEnvironment ($testSuffix, $location = "West Central US")
{
	$params = Get-DataClassificationTestEnvironmentParameters $testSuffix
	Create-BasicManagedTestEnvironmentWithParams $params $location
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-DataClassificationTestEnvironmentParameters ($testSuffix)
{
	$params = Get-DataClassificationTestEnvironmentParameters $testSuffix
	Remove-AzureRmResourceGroup -Name $params.rgname -Force
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-SqlDataClassificationTestEnvironment ($testSuffix, $location = "West Central US", $serverVersion = "12.0")
{
	$params = Get-DataClassificationTestEnvironmentParameters $testSuffix
	
	New-AzResourceGroup -Name $params.rgname -Location $location

	$password = $params.pwd
    $secureString = ($password | ConvertTo-SecureString -asPlainText -Force)
    $credentials = new-object System.Management.Automation.PSCredential($params.loginName, $secureString)
    New-AzSqlServer -ResourceGroupName  $params.rgname -ServerName $params.serverName -ServerVersion $serverVersion -Location $location -SqlAdministratorCredentials $credentials
	New-AzSqlServerFirewallRule -ResourceGroupName  $params.rgname -ServerName $params.serverName -StartIpAddress 0.0.0.0 -EndIpAddress 255.255.255.255 -FirewallRuleName "dcRule"


	New-AzSqlDatabase -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq "Record")
	{
		$fullServerName = $params.serverName + ".database.windows.net"
		$login = $params.loginName
		$databaseName = $params.databaseName

		$connection = New-Object System.Data.SqlClient.SqlConnection
		$connection.ConnectionString = "Server=$fullServerName;uid=$login;pwd=$password;Database=$databaseName;Integrated Security=False;"
		try
		{
			$connection.Open()

			$command = $connection.CreateCommand()
			$command.CommandText = "CREATE TABLE Persons (PersonID int, LastName varchar(255), FirstName varchar(255), Address varchar(255), City varchar(255));"
			$command.ExecuteReader()
		}
		finally
		{
			$connection.Close()
		}
	}
}