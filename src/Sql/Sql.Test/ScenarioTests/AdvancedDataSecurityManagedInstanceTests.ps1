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
function Test-AdvancedDataSecurityPolicyManagedInstanceTest
{
	# Setup
	$testSuffix = getAssetName
	Create-AdvancedDataSecurityManagedInstanceTestEnvironment $testSuffix
	$params = Get-SqlAdvancedDataSecurityManagedInstanceTestEnvironmentParameters $testSuffix

	try
	{
		# Get Advanced Threat Protection Policy
		$policy = Get-AzSqlInstanceAdvancedDataSecurityPolicy -ResourceGroupName $params.rgname -InstanceName $params.serverName 
				
		# Validate the policy
		Assert-AreEqual $params.rgname $policy.ResourceGroupName
		Assert-AreEqual $params.serverName $policy.ManagedInstanceName
		Assert-False { $policy.IsEnabled }

		# Enabled Advanced Threat Protection Policy
		Enable-AzSqlInstanceAdvancedDataSecurity -ResourceGroupName $params.rgname -InstanceName $params.serverName -DoNotConfigureVulnerabilityAssessment
		$policy = Get-AzSqlInstanceAdvancedDataSecurityPolicy -ResourceGroupName $params.rgname -InstanceName $params.serverName 
				
		# Validate the policy
		Assert-AreEqual $params.rgname $policy.ResourceGroupName
		Assert-AreEqual $params.serverName $policy.ManagedInstanceName
		Assert-True { $policy.IsEnabled }

		# Disable Advanced Threat Protection Policy
		Disable-AzSqlInstanceAdvancedDataSecurity -ResourceGroupName $params.rgname -InstanceName $params.serverName 
		$policy = Get-AzSqlInstanceAdvancedDataSecurityPolicy -ResourceGroupName $params.rgname -InstanceName $params.serverName 
				
		# Validate the policy
		Assert-AreEqual $params.rgname $policy.ResourceGroupName
		Assert-AreEqual $params.serverName $policy.ManagedInstanceName
		Assert-False { $policy.IsEnabled }
	}
	finally
	{
		# Cleanup
		Remove-AdvancedDataSecurityManagedInstanceTestEnvironment $testSuffix
	}
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-AdvancedDataSecurityManagedInstanceTestEnvironment ($testSuffix, $location = "West Central US")
{
	$params = Get-SqlAdvancedDataSecurityManagedInstanceTestEnvironmentParameters $testSuffix
	Create-BasicManagedTestEnvironmentWithParams $params $location
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-SqlAdvancedDataSecurityManagedInstanceTestEnvironmentParameters ($testSuffix)
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
function Remove-AdvancedDataSecurityManagedInstanceTestEnvironment ($testSuffix)
{
	$params = Get-SqlAdvancedDataSecurityManagedInstanceTestEnvironmentParameters $testSuffix
	Remove-AzureRmResourceGroup -Name $params.rgname -Force
}
