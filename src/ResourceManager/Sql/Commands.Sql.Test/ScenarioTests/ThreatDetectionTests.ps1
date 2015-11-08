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

# In the cmdlets, we use the alias:
#    "Set-AzureRmSqlDatabaseThreatDetectionPolicy" = "Set-AzureRmSqlDatabaseAuditingPolicy";
#    "Get-AzureRmSqlDatabaseThreatDetectionPolicy" = "Get-AzureRmSqlDatabaseAuditingPolicy";

<#
.SYNOPSIS
Tests the default values of database's threat detection policy
#>
function Test-ThreatDetectionDatabaseGetDefualtPolicy
{
	# Setup
	$testSuffix = 5000
	Create-ThreatDetectionTestEnvironmentWithStorageV2 $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try 
	{
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
        # Assert
		Assert-AreEqual $params.storageAccount $policy.StorageAccountName 
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.ThreatDetectionState "New"
		Assert-AreEqual $policy.EmailAddresses ""
        Assert-True {$policy.EmailServiceAndAccountAdmins}
		Assert-AreEqual $policy.FilterDetectionTypes ""
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
	$testSuffix = 5001
	Create-ThreatDetectionTestEnvironmentWithStorageV2 $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -ThreatDetectionState "Enabled" -EmailAddresses "koko@gmail.com;koko1@gmail.com" -EmailServiceAndAccountAdmins $false -FilterDetectionTypes "type1,type2"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.EmailAddresses "koko@gmail.com;koko1@gmail.com"
        Assert-False {$policy.EmailServiceAndAccountAdmins}
		Assert-AreEqual $policy.FilterDetectionTypes "type1,type2"

        # Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -ThreatDetectionState "Disabled" -EmailAddresses "koko@gmail.com;koko1@gmail.com" -EmailServiceAndAccountAdmins $false -FilterDetectionTypes "type1,type2"
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"
		Assert-AreEqual $policy.EmailAddresses "koko@gmail.com;koko1@gmail.com"
        Assert-False {$policy.EmailServiceAndAccountAdmins}
		Assert-AreEqual $policy.FilterDetectionTypes "type1,type2"
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
	$testSuffix = 5002
	Create-ThreatDetectionTestEnvironmentWithStorageV2 $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -ThreatDetectionState "Enabled" 
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Enabled"
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"

        # Test
        Remove-AzureRmSqlDatabaseAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
        $policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.AuditState "Disabled"
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"

        # Test
        Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -ThreatDetectionState "Enabled" 
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

        Assert-AreEqual $policy.ThreatDetectionState "Enabled"
        
        Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		Use-AzureRmSqlServerAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $policy.UseServerDefault "Enabled"
        Assert-AreEqual $policy.ThreatDetectionState "Disabled"

        # Test
        Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -ThreatDetectionState "Enabled" 
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName

        Assert-AreEqual $policy.ThreatDetectionState "Enabled"

        Remove-AzureRmSqlDatabaseThreatDetection -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName 
		$policy = Get-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
        
        # Assert
        Assert-AreEqual $policy.ThreatDetectionState "Disabled"
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
	$testSuffix = 5003
	Create-ThreatDetectionTestEnvironmentWithStorageV2 $testSuffix
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		 #  Check that EmailAddresses are in correct format 
		 Assert-Throws {Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -ThreatDetectionState "Enabled" -EmailAddresses "kokogmail.com"} 

         #  Check that EmailServiceAndAccountAdmins is not False and EmailAddresses is not empty 
         Assert-Throws {Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -ThreatDetectionState "Enabled" -EmailServiceAndAccountAdmins $false} 
         Assert-Throws {Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -ThreatDetectionState "Enabled" -EmailServiceAndAccountAdmins $false -EmailAddresses ""} 
	}
	finally
	{
		# Cleanup
		Remove-ThreatDetectionTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Tests that thread detection doesn't work on Sawa servers
#>
function Test-ThreatDetectionOnSawaServer
{
	# Setup
	$testSuffix = 5004
	Create-ThreatDetectionTestEnvironmentWithStorageV2 $testSuffix "0.2"
	$params = Get-SqlThreatDetectionTestEnvironmentParameters $testSuffix

	try
	{
		 #  Check that EmailAddresses are in correct format 
		 Assert-Throws {Set-AzureRmSqlDatabaseAuditingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount -ThreatDetectionState "Enabled" -EmailAddresses "kokogmail.com"} 
	}
	finally
	{
		# Cleanup
		Remove-ThreatDetectionTestEnvironment $testSuffix
	}
}