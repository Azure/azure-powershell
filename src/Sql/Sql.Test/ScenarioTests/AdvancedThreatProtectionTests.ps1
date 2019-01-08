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
Tests the Advanced Threat Protection Policy cmdlets
#>
function Test-AdvancedThreatProtectionPolicyTest
{
	# Setup
	$testSuffix = getAssetName
	Create-AdvancedThreatProtectionTestEnvironment $testSuffix
	$params = Get-SqlAdvancedThreatProtectionTestEnvironmentParameters $testSuffix

	try
	{
		# Get Advanced Threat Protection Policy
		$policy = Get-AzureRmSqlServerAdvancedThreatProtectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
				
		# Validate the policy
		Assert-AreEqual $params.rgname $policy.ResourceGroupName
		Assert-AreEqual $params.serverName $policy.ServerName
		Assert-False { $policy.IsEnabled }

		# Enabled Advanced Threat Protection Policy
		Enable-AzureRmSqlServerAdvancedThreatProtection -ResourceGroupName $params.rgname -ServerName $params.serverName 
		$policy = Get-AzureRmSqlServerAdvancedThreatProtectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
				
		# Validate the policy
		Assert-AreEqual $params.rgname $policy.ResourceGroupName
		Assert-AreEqual $params.serverName $policy.ServerName
		Assert-True { $policy.IsEnabled }

		# Disable Advanced Threat Protection Policy
		Disable-AzureRmSqlServerAdvancedThreatProtection -ResourceGroupName $params.rgname -ServerName $params.serverName 
		$policy = Get-AzureRmSqlServerAdvancedThreatProtectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
				
		# Validate the policy
		Assert-AreEqual $params.rgname $policy.ResourceGroupName
		Assert-AreEqual $params.serverName $policy.ServerName
		Assert-False { $policy.IsEnabled }

		# See that ATP cmdlets don't mess up the Threat Detection policy
		Set-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com" -EmailAdmins $false -ExcludedDetectionType Sql_Injection_Vulnerability

		Disable-AzureRmSqlServerAdvancedThreatProtection -ResourceGroupName $params.rgname -ServerName $params.serverName 

		# Assert
		$policy = Get-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 1
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}

		Enable-AzureRmSqlServerAdvancedThreatProtection -ResourceGroupName $params.rgname -ServerName $params.serverName 

		# Assert
		$policy = Get-AzureRmSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 1
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}
	}
	finally
	{
		# Cleanup
		Remove-AdvancedThreatProtectionTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-AdvancedThreatProtectionTestEnvironment ($testSuffix, $location = "West Central US", $serverVersion = "12.0")
{
	$params = Get-SqlAdvancedThreatProtectionTestEnvironmentParameters $testSuffix
	Create-BasicTestEnvironmentWithParams $params $location $serverVersion
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-SqlAdvancedThreatProtectionTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "sql-atp-cmdlet-test-rg" +$testSuffix;
			  serverName = "sql-atp-cmdlet-server" +$testSuffix;
			  databaseName = "sql-atp-cmdlet-db" + $testSuffix;
			  }
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-AdvancedThreatProtectionTestEnvironment ($testSuffix)
{
	$params = Get-SqlAdvancedThreatProtectionTestEnvironmentParameters $testSuffix
	Remove-AzureRmResourceGroup -Name $params.rgname -Force
}
