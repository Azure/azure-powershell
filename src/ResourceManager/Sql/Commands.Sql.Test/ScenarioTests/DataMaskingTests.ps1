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
Tests  toggling of the enablement property of a data masking policy 
#>
function Test-DatabaseDataMaskingPolicyEnablementToggling 
{
	# Setup
	$testSuffix = 777
	 $params = Create-DataMaskingTestEnvironment $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -DataMaskingState "Enabled" 
		$policy = Get-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.DataMaskingState  "Enabled"

		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -DataMaskingState "Disabled" 
		$policy = Get-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.DataMaskingState  "Disabled"

		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -DataMaskingState "Enabled" 
		$policy = Get-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.DataMaskingState  "Enabled"
	}
	finally
	{
		# Cleanup
	}
}


<#
.SYNOPSIS
Tests changes of the masking level property of a data masking policy 
#>
function Test-DatabaseDataMaskingLevelChanges
{

	# Setup
	$testSuffix = 20777
	 $params = Create-DataMaskingTestEnvironment $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingLevel "Standard" 
		$policy = Get-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.MaskingLevel  "Standard"

		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -DataMaskingState "Enabled" 
		$policy = Get-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.MaskingLevel  "Standard"


		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingLevel "Extended" 
		$policy = Get-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.MaskingLevel  "Extended"

		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingLevel "Standard" 
		$policy = Get-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.MaskingLevel  "Standard"
	}
	finally
	{
		# Cleanup
	}
}


<#
.SYNOPSIS
Tests changes of the masking level property of a data masking policy 
#>
function Test-DatabaseDataMaskingPrivilegedLoginsChanges
{

	# Setup
	$testSuffix = 30777
	 $params = Create-DataMaskingTestEnvironment $testSuffix

	try
	{
		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -PrivilegedLogins "A;B;C" 
		$policy = Get-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.PrivilegedLogins  "A;B;C"

		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingLevel "Extended" 
		$policy = Get-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.PrivilegedLogins  "A;B;C"

		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -PrivilegedLogins ""  
		$policy = Get-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
	
		# Assert
		Assert-AreEqual $policy.PrivilegedLogins ""
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
	$testSuffix = 40222
	 $params = Create-DataMaskingTestEnvironment $testSuffix
	 $ruleId = "rule1"
	try
	{
		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName

		$ruleCountBefore = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Default" -TableName "Table1" -ColumnName "Column1"
		$ruleCountAfter = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}

		# Assert
		Assert-AreEqual ($ruleCountBefore + 1) $ruleCountAfter
		$rule = Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.RuleId $ruleId
		Assert-AreEqual $rule.MaskingFunction "Default"
		Assert-AreEqual $rule.TableName "Table1"
		Assert-AreEqual $rule.ColumnName "Column1"

		Set-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Email" -TableName "Table2" -ColumnName "Column2"
		$rule = Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.RuleId $ruleId
		Assert-AreEqual $rule.MaskingFunction "Email"
		Assert-AreEqual $rule.TableName "Table2"
		Assert-AreEqual $rule.ColumnName "Column2"

		$ruleCountBefore = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		Remove-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -Force
		$ruleCountAfter = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}
		
		# Assert
		Assert-Throws {Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId}
		Assert-AreEqual ($ruleCountBefore - 1) $ruleCountAfter
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
	$testSuffix = 50222
	$params = Create-DataMaskingTestEnvironment $testSuffix
	$ruleId = "rule2"

	try
	{
		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName

		$ruleCountBefore = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Number" -TableName "TableNumber" -ColumnName "ColumnNumber" -NumberFrom 12 -NumberTo 56
		$ruleCountAfter = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}

		# Assert
		Assert-AreEqual ($ruleCountBefore + 1) $ruleCountAfter

		$rule = Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.RuleId $ruleId
		Assert-AreEqual $rule.MaskingFunction "Number"
		Assert-AreEqual $rule.TableName "TableNumber"
		Assert-AreEqual $rule.ColumnName "ColumnNumber"
		Assert-AreEqual $rule.NumberFrom 12
		Assert-AreEqual $rule.NumberTo 56
		

		Set-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId  -TableName "TableNumber1" -ColumnName "ColumnNumber1" -NumberFrom 67.26 -NumberTo 78.91
		$rule = Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.RuleId $ruleId
		Assert-AreEqual $rule.MaskingFunction "Number"
		Assert-AreEqual $rule.TableName "TableNumber1"
		Assert-AreEqual $rule.ColumnName "ColumnNumber1"
		Assert-AreEqual $rule.NumberFrom 67.26
		Assert-AreEqual $rule.NumberTo 78.91


		$ruleCountBefore = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		Remove-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -Force
		$ruleCountAfter = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}

		# Assert
		Assert-Throws {Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId}
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
	$ruleId = "rule3"

	try
	{
		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName

		$ruleCountBefore = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Text" -TableName "TableText" -ColumnName "ColumnText" -PrefixSize 1 -ReplacementString "AAA" -SuffixSize 3
		$ruleCountAfter = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}

		# Assert
		Assert-AreEqual ($ruleCountBefore + 1) $ruleCountAfter

		$rule = Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.RuleId $ruleId
		Assert-AreEqual $rule.MaskingFunction "Text"
		Assert-AreEqual $rule.TableName "TableText"
		Assert-AreEqual $rule.ColumnName "ColumnText"
		Assert-AreEqual $rule.PrefixSize 1
		Assert-AreEqual $rule.ReplacementString "AAA"
		Assert-AreEqual $rule.SuffixSize 3
	
		Set-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -TableName "TableText1" -ColumnName "ColumnText1" -PrefixSize 4 -ReplacementString "BBB" -SuffixSize 2
		$rule = Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId

		# Assert
		Assert-AreEqual $rule.ResourceGroupName $params.rgname
		Assert-AreEqual $rule.ServerName $params.serverName
		Assert-AreEqual $rule.DatabaseName $params.databaseName
		Assert-AreEqual $rule.RuleId $ruleId
		Assert-AreEqual $rule.MaskingFunction "Text"
		Assert-AreEqual $rule.TableName "TableText1"
		Assert-AreEqual $rule.ColumnName "ColumnText1"
		Assert-AreEqual $rule.PrefixSize 4
		Assert-AreEqual $rule.ReplacementString "BBB"
		Assert-AreEqual $rule.SuffixSize 2


		$ruleCountBefore = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountBefore = if ( !$ruleCountBefore ) {0} else {$ruleCountBefore}
		Remove-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -Force
		$ruleCountAfter = (Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName).Count
		$ruleCountAfter = if ( !$ruleCountAfter ) {0} else {$ruleCountAfter}

		# Assert
		Assert-Throws {Get-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId}
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
	$testSuffix = 70222
	$params = Create-DataMaskingTestEnvironment $testSuffix
	$ruleId = "rule4"

	try
	{
		# Test
		Set-AzureSqlDatabaseDataMaskingPolicy -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName
		# Assert
		Assert-Throws { New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName "NONEXISTING" -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Default" -TableName "T1" -ColumnName "C1"} 
		Assert-Throws { New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName "NONEXISTING"  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Default" -TableName "T1" -ColumnName "C1"} 
		Assert-Throws { New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName "NONEXISTING" -RuleId $ruleId -MaskingFunction "Default" -TableName "T1" -ColumnName "C1"} 
		Assert-Throws { New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -MaskingFunction "Default" -TableName "T1" -ColumnName "C1"} 
		Assert-Throws { New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "NONEXISTING" -TableName "T1" -ColumnName "C1"} 
		Assert-Throws { New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Default"} 
		Assert-Throws { New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Default" -ColumnName "C1"} 
		Assert-Throws { New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Default" -TableName "T1"}
		Assert-Throws { New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Number" -TableName "T1" -ColumnName "C1" -NumberFrom 2 -NumberTo 1}

		New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Default" -TableName "TT1" -ColumnName "CC1"
		Assert-Throws { New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -MaskingFunction "Default" -TableName "TT2" -ColumnName "CC2" }
		Assert-Throws { New-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId "SHOULD-FAIL" -MaskingFunction "Default" -TableName "TT1" -ColumnName "CC1"}

		Remove-AzureSqlDatabaseDataMaskingRule -ResourceGroupName $params.rgname -ServerName $params.serverName  -DatabaseName $params.databaseName -RuleId $ruleId -Force
	}
	finally
	{
		# Cleanup
	}
}



