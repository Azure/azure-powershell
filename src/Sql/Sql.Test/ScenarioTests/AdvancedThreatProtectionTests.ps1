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
Tests the default values of database's Advanced Threat Protection settings
#>
function Test-AdvancedThreatProtectionGetDefaultSettings
{
	# Setup
	$testSuffix = getAssetName
	Create-AdvancedThreatProtectionTestEnvironment $testSuffix
	$params = Get-SqlAdvancedThreatProtectionTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		$settings = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $settings.AdvancedThreatProtectionState "Disabled"

		# Test
		$settings = Get-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName

		# Assert
		Assert-AreEqual $settings.AdvancedThreatProtectionState "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-AdvancedThreatProtectionTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying the properties of a databases's Advanced Threat Protection Settings, they are later fetched properly
#>
function Test-AdvancedThreatProtectionDatabaseUpdateSettings
{
	# Setup
	$testSuffix = getAssetName
	Create-AdvancedThreatProtectionTestEnvironment $testSuffix
	$params = Get-SqlAdvancedThreatProtectionTestEnvironmentParameters $testSuffix

	try
	{
		# Test upsert of ATP settings
		Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -Enable $true
		$settings = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $settings.AdvancedThreatProtectionState "Enabled"

		# Test
		Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -Enable $false
		$settings = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $settings.AdvancedThreatProtectionState "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-AdvancedThreatProtectionTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying the properties of a server's Advanced Threat Protection Settings, they are later fetched properly
#>
function Test-AdvancedThreatProtectionServerUpdateSettings
{
	# Setup
	$testSuffix = getAssetName
	Create-AdvancedThreatProtectionTestEnvironment $testSuffix
	$params = Get-SqlAdvancedThreatProtectionTestEnvironmentParameters $testSuffix

	try
	{
		# Test upsert of ATP settings
		Update-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -Enable $true
		$settings = Get-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $settings.AdvancedThreatProtectionState "Enabled"

		# Test
		Update-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -Enable $false
		$settings = Get-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $settings.AdvancedThreatProtectionState "Disabled"
	}
	finally
	{
		# Cleanup
		Remove-AdvancedThreatProtectionTestEnvironment $testSuffix
	}
}
