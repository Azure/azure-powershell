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
Tests changes of the privileged logins property of a data masking policy 
#>
function Test-DatabaseDataMaskingPrivilegedUsersChanges
{

	# Setup
	$testSuffix = 30379
	$params = Create-DataMaskingTestEnvironment $testSuffix

	try
	{
		# Defualt policy should be in disabled state
		$policy = Get-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual "Disabled" $policy.DataMaskingState


		# Test adding a privileged login
		Set-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -PrivilegedUsers "public" -DataMaskingState "Enabled"
		$policy = Get-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual "public;" $policy.PrivilegedUsers
		Assert-AreEqual "Enabled" $policy.DataMaskingState

		# Test removing a privileged login while having enabled policy
		Set-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -PrivilegedUsers "" 
		$policy = Get-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
	    Assert-AreEqual "" $policy.PrivilegedUsers

		# Test disabling a policy
		Set-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -DataMaskingState "Disabled" 
		$policy = Get-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
	    Assert-AreEqual "" $policy.PrivilegedUsers

		# Test adding a privileged login while being disabled
		Set-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -PrivilegedUsers "public" 
		$policy = Get-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual "" $policy.PrivilegedUsers

		# Test removing a privileged login while being disabled
		Set-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -PrivilegedUsers ""  
		$policy = Get-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual "" $policy.PrivilegedUsers
	}
	finally
	{
		# Cleanup
	}
}

<#
.SYNOPSIS
Tests the lifecycle of a data masking rule with basic masking function 
#>
function Test-DatabaseDataMaskingBasicRuleLifecycle
{

	# Setup
	$testSuffix = 40225
	$params = Create-DataMaskingTestEnvironment $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName

		$ruleCountBefore = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		New-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingFunction "Default" -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1
		$ruleCountAfter = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}

		# Assert
		Assert-AreEqual ($ruleCountBefore + 1) $ruleCountAfter
		$rule = Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.MaskingFunction "Default"
		Assert-AreEqual $rule.SchemaName "dbo"
		Assert-AreEqual $rule.TableName $params.table1
		Assert-AreEqual $rule.ColumnName $params.column1

		Set-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName  -MaskingFunction "Email" -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1
		$rule = Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.MaskingFunction "Email"
		Assert-AreEqual $rule.SchemaName "dbo"
		Assert-AreEqual $rule.TableName $params.table1
		Assert-AreEqual $rule.ColumnName $params.column1

		Set-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1 -MaskingFunction "Default"
		$rule = Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName

			# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.MaskingFunction "Default"
		Assert-AreEqual $rule.SchemaName "dbo"
		Assert-AreEqual $rule.TableName $params.table1
		Assert-AreEqual $rule.ColumnName $params.column1

		$ruleCountBefore = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		Remove-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1 -Force
		$ruleCountAfter = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}		
	}
	finally
	{
		# Cleanup
	}
}

<#
.SYNOPSIS
Tests the lifecycle of a data masking rule with numerical masking function 
#>
function Test-DatabaseDataMaskingNumberRuleLifecycle
{

	# Setup
	$testSuffix = 51792
	$params = Create-DataMaskingTestEnvironment $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName

		$ruleCountBefore = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		New-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingFunction "Number" -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.columnInt -NumberFrom 12 -NumberTo 56
		$ruleCountAfter = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}

		# Assert
		Assert-AreEqual ($ruleCountBefore + 1) $ruleCountAfter

		$rule = Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.columnInt

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.MaskingFunction "Number"
		Assert-AreEqual $rule.SchemaName "dbo"
		Assert-AreEqual $rule.TableName $params.table1
		Assert-AreEqual $rule.ColumnName $params.columnInt
		Assert-AreEqual $rule.NumberFrom 12
		Assert-AreEqual $rule.NumberTo 56
		

		Set-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.columnInt -NumberFrom 15 -NumberTo 34
		$rule = Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.columnInt

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.MaskingFunction "Number"
		Assert-AreEqual $rule.SchemaName "dbo"
		Assert-AreEqual $rule.TableName $params.table1
		Assert-AreEqual $rule.ColumnName $params.columnInt
		Assert-AreEqual $rule.NumberFrom 15
		Assert-AreEqual $rule.NumberTo 34


		$ruleCountBefore = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		Remove-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1 -Force
		$ruleCountAfter = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}

		# Assert
		Assert-AreEqual ($ruleCountBefore - 1) $ruleCountAfter

	}
	finally
	{
		# Cleanup
	}
}

<#
.SYNOPSIS
Tests the lifecycle of a data masking rule with text masking function 
#>
function Test-DatabaseDataMaskingTextRuleLifecycle
{

	# Setup
	$testSuffix = 60222
	$params = Create-DataMaskingTestEnvironment $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName

		$ruleCountBefore = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		New-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingFunction "Text" -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1 -PrefixSize 1 -ReplacementString "AAA" -SuffixSize 3
		$ruleCountAfter = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}

		# Assert
		Assert-AreEqual ($ruleCountBefore + 1) $ruleCountAfter

		$rule = Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.MaskingFunction "Text"
		Assert-AreEqual $rule.SchemaName "dbo"
		Assert-AreEqual $rule.TableName $params.table1
		Assert-AreEqual $rule.ColumnName $params.column1
		Assert-AreEqual $rule.PrefixSize 1
		Assert-AreEqual $rule.ReplacementString "AAA"
		Assert-AreEqual $rule.SuffixSize 3
	
		Set-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1 -PrefixSize 4 -ReplacementString "BBB" -SuffixSize 2
		$rule = Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.MaskingFunction "Text"
		Assert-AreEqual $rule.SchemaName "dbo"
		Assert-AreEqual $rule.TableName $params.table1
		Assert-AreEqual $rule.ColumnName $params.column1
		Assert-AreEqual $rule.PrefixSize 4
		Assert-AreEqual $rule.ReplacementString "BBB"
		Assert-AreEqual $rule.SuffixSize 2


		$ruleCountBefore = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		Remove-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1 -Force
		$ruleCountAfter = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}

		# Assert
		Assert-AreEqual ($ruleCountBefore - 1) $ruleCountAfter
	}
	finally
	{
		# Cleanup
	}
}

<#
.SYNOPSIS
Tests that ilegal values prevent creation of rules 
#>
function Test-DatabaseDataMaskingRuleCreationFailures
{

	# Setup
	$testSuffix = 70232
	$params = Create-DataMaskingTestEnvironment $testSuffix

	try
	{
		# Test
		Set-AzureRmSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
		# Assert
		Assert-Throws { New-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName "NONEXISTING" -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingFunction "Default" -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1} 
		Assert-Throws { New-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName "NONEXISTING"  -DatabaseName $params.databaseName -MaskingFunction "Default" -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1} 
		Assert-Throws { New-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName "NONEXISTING" -MaskingFunction "Default" -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1} 
		Assert-Throws { New-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingFunction "Default" -SchemaName "NONEXISTING" -TableName  $params.table1 -ColumnName $params.column1} 
		Assert-Throws { New-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingFunction "Default" -SchemaName "dbo" -TableName  "NONEXISTING" -ColumnName $params.column1} 
		Assert-Throws { New-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingFunction "Default" -SchemaName "dbo" -TableName  $params.table1 "NONEXISTING"} 
	}
	finally
	{
		# Cleanup
	}
}

<#
.SYNOPSIS
Tests the lifecycle of a data masking rule with basic masking function 
#>
function Test-DatabaseDataMaskingRuleCreationWithoutPolicy
{

	# Setup
	$testSuffix = 457822
	 $params = Create-DataMaskingTestEnvironment $testSuffix
	try
	{
		# Test
		$ruleCountBefore = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		New-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingFunction "Default" -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1
		$ruleCountAfter = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}

		# Assert
		Assert-AreEqual ($ruleCountBefore + 1) $ruleCountAfter
		$rule = Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.MaskingFunction "Default"
		Assert-AreEqual $rule.SchemaName "dbo"
		Assert-AreEqual $rule.TableName $params.table1
		Assert-AreEqual $rule.ColumnName $params.column1

		$ruleCountBefore = $ruleCountAfter
		Remove-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -SchemaName "dbo" -TableName  $params.table1 -ColumnName $params.column1 -Force
		$ruleCountAfter = (Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}
		
		# Assert
		Assert-Throws {Get-AzureRmSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId}
		Assert-AreEqual ($ruleCountBefore - 1) $ruleCountAfter
	}
	finally
	{
		# Cleanup
	}
}

