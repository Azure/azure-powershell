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
Tests setting and getting threat detection policy with classic storage
#>
function Test-ThreatDetectionUpdatePolicyWithClassicStorage
{
	# Setup
	$testSuffix = 4996
	Create-ThreatDetectionClassicTestEnvironment $testSuffix
	$params = Get-SqlAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test - database poloicy
		Set-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -NotificationRecipientsEmails "koko1@mailTest.com" -EmailAdmins $false -ExcludedDetectionType "Sql_Injection_Vulnerability" -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko1@mailTest.com"
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 1
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}


		# Test - server poloicy
		Set-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -NotificationRecipientsEmails "koko2@mailTest.com" -EmailAdmins $false -ExcludedDetectionType Sql_Injection_Vulnerability -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko2@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 1
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}
	}
	finally
	{
		# Cleanup
		Remove-ThreatDetectionTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests the default values of database's threat detection policy
#>
function Test-ThreatDetectionGetDefualtPolicy
{
	# Setup
	$testSuffix = 4006
	Create-ThreatDetectionTestEnvironment $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		$policy = Get-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "New"
		Assert-AreEqual $policy.NotificationRecipientsEmails ""
		Assert-True {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 1

		# Test
		$policy = Get-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName

		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "New"
		Assert-AreEqual $policy.NotificationRecipientsEmails ""
		Assert-True {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 1
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
	$testSuffix = 6002
	Create-ThreatDetectionTestEnvironment $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com" -EmailAdmins $false -ExcludedDetectionType "Sql_Injection_Vulnerability" -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 1
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}

		# Test
		Set-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -ExcludedDetectionType "Sql_Injection", "Sql_Injection_Vulnerability", "Access_Anomaly", "Usage_Anomaly"
		$policy = Get-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 4
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Access_Anomaly)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Usage_Anomaly)}
        
		# Test
		Remove-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 4
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Access_Anomaly)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Usage_Anomaly)}
	
		# Test
		Set-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -ExcludedDetectionType "None"
		$policy = Get-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 0	
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
	$testSuffix = 6027
	Create-ThreatDetectionTestEnvironment $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		Set-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com" -EmailAdmins $false -ExcludedDetectionType Sql_Injection_Vulnerability -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 1
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}

		# Test
		Set-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -ExcludedDetectionType Sql_Injection, Sql_Injection_Vulnerability, Access_Anomaly, Usage_Anomaly -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 4
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Access_Anomaly)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Usage_Anomaly)}
        
		# Test
		Remove-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
		$policy = Get-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 4
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Access_Anomaly)}
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Usage_Anomaly)}
	
		# Test
		Set-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -ExcludedDetectionType None -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Length 0	
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
	$testSuffix = 7079
	Create-ThreatDetectionTestEnvironment $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		# 1. Test
		Set-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"

		# 2. Test
		Remove-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName 
		$policy = Get-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"

		# 3. Test - that no exception is thrown
		Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		Use-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		Set-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
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
	$testSuffix = 8027
	Create-ThreatDetectionTestEnvironment $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		# turning on threat detection without storage account
		Assert-Throws {Set-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName} 

		#  Check that NotificationRecipientsEmails are in correct format 
		Assert-Throws {Set-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -NotificationRecipientsEmails "kokogmail.com"} 

		#  Check that EmailAdmins is not False and NotificationRecipientsEmails is not empty 
		Assert-Throws {Set-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -EmailAdmins $false -StorageAccountName $params.storageAccount} 
		Assert-Throws {Set-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -EmailAdmins $false -NotificationRecipientsEmails "" -StorageAccountName $params.storageAccount} 

		#  Check that ExcludedDetectionType doesn't hold None and any other type 
		Assert-Throws {Set-AzureRmSqlDatabaseThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -EmailAdmins $true -ExcludedDetectionType "None", "Sql_Injection_Vulnerability" -StorageAccountName $params.storageAccount} 
	}
	finally
	{
		# Cleanup
		Remove-ThreatDetectionTestEnvironment $testSuffix
	}
}
