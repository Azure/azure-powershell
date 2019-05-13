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
Tests the Advanced Data Security Policy cmdlets
#>
function Test-AdvancedDataSecurityPolicyTest
{
	# Setup
	$testSuffix = getAssetName
	Create-AdvancedDataSecurityTestEnvironment $testSuffix
	$params = Get-SqlAdvancedDataSecurityTestEnvironmentParameters $testSuffix

	try
	{
		# Get Advanced Data Security Policy
		$policy = Get-AzSqlServerAdvancedDataSecurityPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
				
		# Validate the policy
		Assert-AreEqual $params.rgname $policy.ResourceGroupName
		Assert-AreEqual $params.serverName $policy.ServerName
		Assert-False { $policy.IsEnabled }

		# Enabled Advanced Data Security Policy
		Enable-AzSqlServerAdvancedDataSecurity -ResourceGroupName $params.rgname -ServerName $params.serverName -DoNotConfigureVulnerabilityAssessment
		$policy = Get-AzSqlServerAdvancedDataSecurityPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
				
		# Validate the policy
		Assert-AreEqual $params.rgname $policy.ResourceGroupName
		Assert-AreEqual $params.serverName $policy.ServerName
		Assert-True { $policy.IsEnabled }

		# Disable Advanced Threat Protection Policy
		Disable-AzSqlServerAdvancedDataSecurity -ResourceGroupName $params.rgname -ServerName $params.serverName 
		$policy = Get-AzSqlServerAdvancedDataSecurityPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
				
		# Validate the policy
		Assert-AreEqual $params.rgname $policy.ResourceGroupName
		Assert-AreEqual $params.serverName $policy.ServerName
		Assert-False { $policy.IsEnabled }

		# See that ATP cmdlets don't mess up the Threat Detection policy
		Set-AzSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName -NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com" -EmailAdmins $false -ExcludedDetectionType Sql_Injection_Vulnerability

		Disable-AzSqlServerAdvancedDataSecurity -ResourceGroupName $params.rgname -ServerName $params.serverName 

		# Assert
		$policy = Get-AzSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual $policy.ThreatDetectionState "Disabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 1
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}

		Enable-AzSqlServerAdvancedDataSecurity -ResourceGroupName $params.rgname -ServerName $params.serverName -DoNotConfigureVulnerabilityAssessment

		# Assert
		$policy = Get-AzSqlServerThreatDetectionPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName
		Assert-AreEqual $policy.ThreatDetectionState "Enabled"
		Assert-AreEqual $policy.NotificationRecipientsEmails "koko@mailTest.com;koko1@mailTest.com"
		Assert-False {$policy.EmailAdmins}
		Assert-AreEqual $policy.ExcludedDetectionTypes.Count 1
		Assert-True {$policy.ExcludedDetectionTypes.Contains([Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DetectionType]::Sql_Injection_Vulnerability)}

		# Check enabling ADS with VA
		Disable-AzSqlServerAdvancedDataSecurity -ResourceGroupName $params.rgname -ServerName $params.serverName 
		Enable-AzSqlServerAdvancedDataSecurity -ResourceGroupName $params.rgname -ServerName $params.serverName -DeploymentName "EnableADS_sql-ads-cmdlet-test-srv"

		# Validate the ADS policy
		$policy = Get-AzSqlServerAdvancedDataSecurityPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName 
		Assert-AreEqual $params.rgname $policy.ResourceGroupName
		Assert-AreEqual $params.serverName $policy.ServerName
		Assert-True { $policy.IsEnabled }

		# Validate the VA policy
		$settings = Get-AzSqlServerVulnerabilityAssessmentSettings -ResourceGroupName $params.rgname -ServerName $params.serverName 
		Assert-AreEqual $params.rgname $settings.ResourceGroupName
		Assert-AreEqual $params.serverName $settings.ServerName
		Assert-AreEqual "vulnerability-assessment" $settings.ScanResultsContainerName
		Assert-AreNotEqual "" $settings.StorageAccountName	
		Assert-AreEqual Weekly $settings.RecurringScansInterval
		Assert-AreEqual $true $settings.EmailAdmins
		Assert-AreEqualArray @() $settings.NotificationEmail
	}
	finally
	{
		# Cleanup
		Remove-AdvancedDataSecurityTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-AdvancedDataSecurityTestEnvironment ($testSuffix, $location = "West Central US", $serverVersion = "12.0")
{
	$params = Get-SqlAdvancedDataSecurityTestEnvironmentParameters $testSuffix
	Create-BasicTestEnvironmentWithParams $params $location $serverVersion
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-SqlAdvancedDataSecurityTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "sql-ads-cmdlet-test-rg" +$testSuffix;
			  serverName = "sql-ads-cmdlet-server" +$testSuffix;
			  databaseName = "sql-ads-cmdlet-db" + $testSuffix;
			  }
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-AdvancedDataSecurityTestEnvironment ($testSuffix)
{
	$params = Get-SqlAdvancedDataSecurityTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}
