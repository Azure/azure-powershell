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
Tests getting diagnostic settings
#>
function Test-GetAzureRmDiagnosticSetting
{
    try 
    {
        # Test
        $actual = Get-AzureRmDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2

		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470" $actual.StorageAccountId
		Assert-AreEqual montest3470 $actual.StorageAccountName 
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.ServiceBusRuleId
		Assert-AreEqual 1           $actual.Metrics.Count 
		Assert-AreEqual $true       $actual.Metrics[0].Enabled 
		Assert-AreEqual "PT1M"      $actual.Metrics[0].Timegrain 
		Assert-AreEqual 2           $actual.Logs.Count
		Assert-AreEqual $true       $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"  $actual.Logs[0].Category
		Assert-AreEqual $true       $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"  $actual.Logs[1].Category
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests setting diagnostics
#>
function Test-SetAzureRmDiagnosticSetting
{
    try 
    {
	    $actual = Set-AzureRmDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2 -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470 -Enable $true

		Assert-AreEqual $actual.StorageAccountId "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470"
		Assert-AreEqual montest3470 $actual.StorageAccountName
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.ServiceBusRuleId
		Assert-AreEqual 1           $actual.Metrics.Count
		Assert-AreEqual $true       $actual.Metrics[0].Enabled
		Assert-AreEqual "PT1M"      $actual.Metrics[0].Timegrain
		Assert-AreEqual 2           $actual.Logs.Count
		Assert-AreEqual $true       $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"  $actual.Logs[0].Category
		Assert-AreEqual $true       $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"  $actual.Logs[1].Category
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests setting diagnostics
#>
function Test-SetAzureRmDiagnosticSettingWithRetention
{
    try 
    {
	    $actual = Set-AzureRmDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2 -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470 -Enable $true -RetentionEnabled $true -RetentionInDays 90

		Assert-AreEqual $actual.StorageAccountId "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470"
		Assert-AreEqual montest3470 $actual.StorageAccountName
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.ServiceBusRuleId
		Assert-AreEqual 1           $actual.Metrics.Count
		Assert-AreEqual $true       $actual.Metrics[0].Enabled
		Assert-AreEqual "PT1M"      $actual.Metrics[0].Timegrain
		Assert-AreEqual $true       $actual.Metrics[0].RetentionPolicy.Enabled
		Assert-AreEqual 90          $actual.Metrics[0].RetentionPolicy.Days
		Assert-AreEqual 2           $actual.Logs.Count
		Assert-AreEqual $true       $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"  $actual.Logs[0].Category
		Assert-AreEqual $true       $actual.Logs[0].RetentionPolicy.Enabled
		Assert-AreEqual 90          $actual.Logs[0].RetentionPolicy.Days
		Assert-AreEqual $true       $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"  $actual.Logs[1].Category
		Assert-AreEqual $true       $actual.Logs[1].RetentionPolicy.Enabled
		Assert-AreEqual 90          $actual.Logs[1].RetentionPolicy.Days
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests setting diagnostics for categories only
#>
function Test-SetAzureRmDiagnosticSetting-CategoriesOnly
{
    try 
    {
	    $actual = Set-AzureRmDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2 -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470 -Enable $true -Categories TestLog2

		Assert-AreEqual $actual.StorageAccountId "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470"
		Assert-AreEqual montest3470 $actual.StorageAccountName
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.ServiceBusRuleId
		Assert-AreEqual 1           $actual.Metrics.Count
		Assert-AreEqual $false       $actual.Metrics[0].Enabled
		Assert-AreEqual "PT1M"      $actual.Metrics[0].Timegrain
		Assert-AreEqual 2           $actual.Logs.Count
		Assert-AreEqual $false       $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"  $actual.Logs[0].Category
		Assert-AreEqual $true       $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"  $actual.Logs[1].Category
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests setting diagnostics for categories only
#>
function Test-SetAzureRmDiagnosticSetting-TimegrainsOnly
{
    try 
    {
	    $actual = Set-AzureRmDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2 -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470 -Enable $true -Timegrains PT1M

		Assert-AreEqual $actual.StorageAccountId "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470"
		Assert-AreEqual montest3470 $actual.StorageAccountName
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.ServiceBusRuleId
		Assert-AreEqual 1           $actual.Metrics.Count
		Assert-AreEqual $true       $actual.Metrics[0].Enabled
		Assert-AreEqual "PT1M"      $actual.Metrics[0].Timegrain
		Assert-AreEqual 2           $actual.Logs.Count
		Assert-AreEqual $false       $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"  $actual.Logs[0].Category
		Assert-AreEqual $false       $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"  $actual.Logs[1].Category
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

# TODO add more complicated scenarios after we have a definitive subscription