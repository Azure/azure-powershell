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
Tests the default values of database's threat detection policy
#>
function Test-ThreatDetectionGetDefaultPolicy
{
	# Setup
	$testSuffix = getAssetName
	Create-ThreatDetectionTestEnvironment $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		$policy = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails ""
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 0

		# Test
		$policy = Get-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName

		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails ""
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 0
	}
	finally
	{
		# Cleanup
		Remove-ThreatDetectionTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying the properties of a databases's threat detection policy , they are later fetched properly
#>
function Test-ThreatDetectionDatabaseUpdatePolicy
{
	# Setup
	$testSuffix = getAssetName
	Create-ThreatDetectionTestEnvironment $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		# Test upsert of TD policy without admins or an email accoun
		Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails ""
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 0
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount

		# Test
		Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com" -EmailAdmins $false -ExcludedDetectionType "Sql_Injection_Vulnerability" -StorageAccountName $params.storageAccount
		$policy = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 1
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}

		# Test
		Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -ExcludedDetectionType "Sql_Injection_Vulnerability", "Unsafe_Action", "Brute_Force"
		$policy = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 3
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Unsafe_Action)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Brute_Force)}
        
		# Test
		Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -ExcludedDetectionType "Sql_Injection", "Sql_Injection_Vulnerability", "Access_Anomaly", "Data_Exfiltration", "Unsafe_Action", "Brute_Force"
		$policy = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 6
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Access_Anomaly)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Data_Exfiltration)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Unsafe_Action)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Brute_Force)}

		# Test
		Clear-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 6
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Access_Anomaly)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Data_Exfiltration)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Unsafe_Action)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Brute_Force)}
	
		# Test
		Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -ExcludedDetectionType "None"
		$policy = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 0	
	}
	finally
	{
		# Cleanup
		Remove-ThreatDetectionTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when modifying the properties of a server's threat detection policy , they are later fetched properly
#>
function Test-ThreatDetectionServerUpdatePolicy
{
	# Setup
	$testSuffix = getAssetName
	Create-ThreatDetectionTestEnvironment $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		# Test upsert of TD policy without admins or an email account
		Update-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -EmailAdmins $false
		$policy = Get-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails ""
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 0

		# Test
		Update-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com" -EmailAdmins $false -ExcludedDetectionType Sql_Injection_Vulnerability -StorageAccountName $params.storageAccount
		$policy = Get-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 1
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}

		# Test
		Update-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -ExcludedDetectionType Sql_Injection, Sql_Injection_Vulnerability, Access_Anomaly, Data_Exfiltration, Unsafe_Action, Brute_Force -StorageAccountName $params.storageAccount
		$policy = Get-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 6
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Access_Anomaly)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Data_Exfiltration)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Unsafe_Action)}
   		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Brute_Force)}

		# Test
		Clear-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 6
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Access_Anomaly)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Data_Exfiltration)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Unsafe_Action)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Brute_Force)}
	
		# Test
		Update-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName  -ExcludedDetectionType None -StorageAccountName $params.storageAccount
		$policy = Get-AzSqlServerAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 0	
	}
	finally
	{
		# Cleanup
		Remove-ThreatDetectionTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that when turning off auditing or marking it as "use server default" , threat detection is disabled
#>
function Test-DisablingThreatDetection
{
	# Setup
	$testSuffix = getAssetName
	Create-ThreatDetectionTestEnvironment $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		# 1. Test
		Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EmailAdmins $true
		$policy = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"

		# 2. Test
		Clear-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName 
		$policy = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"

		# 3. Test - that no exception is thrown
		Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -EmailAdmins $true
		$policy = Get-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	}
	finally
	{
		# Cleanup
		Remove-ThreatDetectionTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests sending invalid arguments in database's threat detection
#>
function Test-InvalidArgumentsThreatDetection
{
	# Setup
	$testSuffix = getAssetName
	Create-ThreatDetectionTestEnvironment $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		# turning on threat detection without storage account
		Assert-Throws {Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName} 

		#  Check that NotificationRecipientsEmails are in correct format 
		Assert-Throws {Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -NotificationRecipientsEmails "kokogmail.com"} 

		#  Check that EmailAdmins is not False and NotificationRecipientsEmails is not empty 
		Assert-Throws {Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -EmailAdmins $false -StorageAccountName $params.storageAccount -StoragEndPoint $params.storageEndpoint} 
		Assert-Throws {Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -EmailAdmins $false -NotificationRecipientsEmails "" -StorageAccountName $params.storageAccount -StoragEndPoint $params.storageEndpoint} 

		#  Check that ExcludedDetectionType doesn't hold None and any other type 
		Assert-Throws {Update-AzSqlDatabaseAdvancedThreatProtectionSetting -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -EmailAdmins $true -ExcludedDetectionType "None", "Sql_Injection_Vulnerability" -StorageAccountName $params.storageAccount} 
	}
	finally
	{
		# Cleanup
		Remove-ThreatDetectionTestEnvironment $testSuffix
	}
}
