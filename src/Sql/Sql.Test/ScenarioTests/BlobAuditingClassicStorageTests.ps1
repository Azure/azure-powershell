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
Tests setting and getting blob auditing policy with classic storage
#>
function Test-BlobAuditingUpdatePolicyWithClassicStorage
{
	# Setup
	$testSuffix = getAssetName
	Create-BlobAuditingClassicTestEnvironment $testSuffix
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix

	try 
	{
		# Test - Blob database Auditing
		Set-AzureRmSqlDatabaseAuditing -State Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlDatabaseAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-AreEqual $policy.AuditState "Enabled"  

		# Test - Blob server Auditing
		Set-AzureRmSqlServerAuditing -State Enabled -ResourceGroupName $params.rgname -ServerName $params.serverName -StorageAccountName $params.storageAccount
		$policy = Get-AzureRmSqlServerAuditing -ResourceGroupName $params.rgname -ServerName $params.serverName
	
		# Assert
		Assert-AreEqual $policy.StorageAccountName $params.storageAccount
		Assert-AreEqual $policy.AuditState "Enabled" 
	}
	finally
	{
		# Cleanup
		Remove-BlobAuditingTestEnvironment $testSuffix
	}
}
