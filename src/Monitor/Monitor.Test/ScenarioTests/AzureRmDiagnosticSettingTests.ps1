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
        $actual = Get-AzDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2 -name service

		Assert-NotNull $actual "Null result #1"

		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470" $actual.StorageAccountId
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.EventHubName
		Assert-AreEqual 1            $actual.Metrics.Count
		Assert-AreEqual $true        $actual.Metrics[0].Enabled
		Assert-AreEqual "00:01:00"   $actual.Metrics[0].Timegrain
		Assert-AreEqual 2            $actual.Logs.Count
		Assert-AreEqual $true        $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"   $actual.Logs[0].Category
		Assert-AreEqual $true        $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"   $actual.Logs[1].Category
		Assert-AreEqual "workspace1" $actual.WorkspaceId
		Assert-Null $actual.ServiceBusRuleId
		Assert-AreEqual "service"    $actual.Name

        $actual = Get-AzDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2

		Assert-NotNull $actual "Null result #2"
		$actual = $actual[0]

		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470" $actual.StorageAccountId
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.EventHubName
		Assert-AreEqual 1            $actual.Metrics.Count
		Assert-AreEqual $true        $actual.Metrics[0].Enabled
		Assert-AreEqual "00:01:00"   $actual.Metrics[0].Timegrain
		Assert-AreEqual 2            $actual.Logs.Count
		Assert-AreEqual $true        $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"   $actual.Logs[0].Category
		Assert-AreEqual $true        $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"   $actual.Logs[1].Category
		Assert-AreEqual "workspace1" $actual.WorkspaceId
		Assert-Null $actual.ServiceBusRuleId
		Assert-AreEqual "service"    $actual.Name
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
function Test-SetAzureRmDiagnosticSettingUpdate
{
    try 
    {
	    $actual = Set-AzDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2 -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470 -Enabled $true

		Assert-AreEqual $actual.StorageAccountId "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470"
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.EventHubName
		Assert-AreEqual 1           $actual.Metrics.Count
		Assert-AreEqual $true       $actual.Metrics[0].Enabled
		Assert-AreEqual "00:01:00"  $actual.Metrics[0].Timegrain
		Assert-AreEqual 2           $actual.Logs.Count
		Assert-AreEqual $true       $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"  $actual.Logs[0].Category
		Assert-AreEqual $true       $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"  $actual.Logs[1].Category
		Assert-Null $actual.ServiceBusRuleId
		Assert-AreEqual "service"   $actual.Name
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
function Test-SetAzureRmDiagnosticSettingCreate
{
    try 
    {
	    # assumes there is no diagnostic settting called service for the given resource
	    $actual = Set-AzDiagnosticSetting -ResourceId /subscriptions/9cf7cc0a-0ba1-4624-bc82-97e1ee25dc45/resourceGroups/system-sas-test/providers/Microsoft.KeyVault/vaults/myCanaryKeyVaultCUSEAUP -StorageAccountId /subscriptions/9cf7cc0a-0ba1-4624-bc82-97e1ee25dc45/resourceGroups/vnet-east-test/providers/Microsoft.Storage/storageAccounts/vnetcnarytestcuseuap2 -Enabled $true

		Assert-AreEqual $actual.StorageAccountId "/subscriptions/9cf7cc0a-0ba1-4624-bc82-97e1ee25dc45/resourceGroups/vnet-east-test/providers/Microsoft.Storage/storageAccounts/vnetcnarytestcuseuap2"
		Assert-AreEqual 1            $actual.Metrics.Count
		Assert-AreEqual $true        $actual.Metrics[0].Enabled
		Assert-AreEqual "AllMetrics" $actual.Metrics[0].Category
		Assert-AreEqual 1            $actual.Logs.Count
		Assert-AreEqual $true        $actual.Logs[0].Enabled
		Assert-AreEqual "AuditEvent" $actual.Logs[0].Category
		Assert-AreEqual "service"   $actual.Name
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
	    $actual = Set-AzDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2 -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470 -Enabled $true -RetentionEnabled $true -RetentionInDays 90

		Assert-AreEqual $actual.StorageAccountId "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470"
		Assert-AreEqual "workspace1" $actual.WorkspaceId
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.EventHubName
		Assert-AreEqual 1           $actual.Metrics.Count
		Assert-AreEqual $true       $actual.Metrics[0].Enabled "Metrics[0]"
		Assert-AreEqual "00:01:00"  $actual.Metrics[0].Timegrain
		Assert-AreEqual $true       $actual.Metrics[0].RetentionPolicy.Enabled "Metric[0].RetentionPolicy"
		Assert-AreEqual 90          $actual.Metrics[0].RetentionPolicy.Days
		Assert-AreEqual 2           $actual.Logs.Count
		Assert-AreEqual $true       $actual.Logs[0].Enabled "Logs[0]"
		Assert-AreEqual "TestLog1"  $actual.Logs[0].Category
		Assert-AreEqual $true       $actual.Logs[0].RetentionPolicy.Enabled "Logs[0].RetentionPolicy"
		Assert-AreEqual 90          $actual.Logs[0].RetentionPolicy.Days
		Assert-AreEqual $true       $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"  $actual.Logs[1].Category
		Assert-AreEqual $true       $actual.Logs[1].RetentionPolicy.Enabled
		Assert-AreEqual 90          $actual.Logs[1].RetentionPolicy.Days
		Assert-Null $actual.ServiceBusRuleId
		Assert-AreEqual "service"   $actual.Name
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
	    $actual = Set-AzDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2 -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470 -Enabled $true -Category TestLog2

		Assert-AreEqual $actual.StorageAccountId "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470"
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.EventHubName
		Assert-AreEqual 1            $actual.Metrics.Count
		Assert-AreEqual $false       $actual.Metrics[0].Enabled
		Assert-AreEqual "00:01:00"   $actual.Metrics[0].Timegrain
		Assert-AreEqual 2            $actual.Logs.Count
		Assert-AreEqual $false       $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"   $actual.Logs[0].Category
		Assert-AreEqual $true        $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"   $actual.Logs[1].Category
		Assert-AreEqual "workspace1" $actual.WorkspaceId
		Assert-Null $actual.ServiceBusRuleId
		Assert-AreEqual "service"    $actual.Name
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
	    $actual = Set-AzDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2 -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470 -Enabled $true -Timegrain PT1M

		Assert-AreEqual $actual.StorageAccountId "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470"
		Assert-AreEqual "workspace1" $actual.WorkspaceId
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.EventHubName
		Assert-AreEqual 1            $actual.Metrics.Count
		Assert-AreEqual $true        $actual.Metrics[0].Enabled
		Assert-AreEqual "00:01:00"   $actual.Metrics[0].Timegrain
		Assert-AreEqual 2            $actual.Logs.Count
		Assert-AreEqual $false       $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"   $actual.Logs[0].Category
		Assert-AreEqual $false       $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"   $actual.Logs[1].Category
		Assert-Null $actual.ServiceBusRuleId
		Assert-AreEqual "service"    $actual.Name
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests setting diagnostics exporting to EventHub
#>
function Test-SetAzureRmDiagnosticSetting-EventHub
{
    try 
    {
	    $actual = Set-AzDiagnosticSetting -ResourceId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourcegroups/insights-integration/providers/test.shoebox/testresources2/pstest0000eastusR2 -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.Storage/storageAccounts/montest3470 -Enabled $true -Category TestLog2

		Assert-Null $actual.StorageAccountId
		Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/montest/providers/Microsoft.ServiceBus/namespaces/ns1/authorizationrules/ar1" $actual.EventHubName
		Assert-AreEqual 1            $actual.Metrics.Count
		Assert-AreEqual $false       $actual.Metrics[0].Enabled
		Assert-AreEqual "00:01:00"   $actual.Metrics[0].Timegrain
		Assert-AreEqual 2            $actual.Logs.Count
		Assert-AreEqual $false       $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"   $actual.Logs[0].Category
		Assert-AreEqual $true        $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"   $actual.Logs[1].Category
		Assert-Null $actual.WorkspaceId
		Assert-Null $actual.ServiceBusRuleId
		Assert-AreEqual "service"    $actual.Name
		Assert-Null $actual.LogAnalyticsDestinationType
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests setting diagnostics Log Analytics
#>
function Test-SetAzureRmDiagnosticSetting-LogAnalytics
{
    try 
    {
	    $actual = Set-AzDiagnosticSetting -ResourceId /subscriptions/9cf7cc0a-0ba1-4624-bc82-97e1ee25dc45/resourceGroups/system-sas-test/providers/Microsoft.KeyVault/vaults/myCanaryKeyVaultCUSEAUP -WorkspaceId 99385489-e1d1-48b0-a1b6-df5a9f258fbf -Enabled $true -Category TestLog2

		Assert-Null $actual.StorageAccountId
		Assert-AreEqual 1            $actual.Metrics.Count
		Assert-AreEqual $false       $actual.Metrics[0].Enabled
		Assert-AreEqual "00:01:00"   $actual.Metrics[0].Timegrain
		Assert-AreEqual 2            $actual.Logs.Count
		Assert-AreEqual $false       $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"   $actual.Logs[0].Category
		Assert-AreEqual $true        $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"   $actual.Logs[1].Category
		Assert-AreEqual "/subscriptions/9cf7cc0a-0ba1-4624-bc82-97e1ee25dc45/resourcegroups/appendblobtest/providers/microsoft.operationalinsights/workspaces/appendblob" $actual.WorkspaceId
		Assert-Null $actual.ServiceBusRuleId
		Assert-AreEqual "service"    $actual.Name
		Assert-Null $actual.LogAnalyticsDestinationType

	    $actual = Set-AzDiagnosticSetting -ResourceId /subscriptions/9cf7cc0a-0ba1-4624-bc82-97e1ee25dc45/resourceGroups/system-sas-test/providers/Microsoft.KeyVault/vaults/myCanaryKeyVaultCUSEAUP -WorkspaceId 99385489-e1d1-48b0-a1b6-df5a9f258fbf -Enabled $true -Category TestLog2 -ExportToResourceSpecific

		Assert-Null $actual.StorageAccountId
		Assert-AreEqual 1            $actual.Metrics.Count
		Assert-AreEqual $false       $actual.Metrics[0].Enabled
		Assert-AreEqual "00:01:00"   $actual.Metrics[0].Timegrain
		Assert-AreEqual 2            $actual.Logs.Count
		Assert-AreEqual $false       $actual.Logs[0].Enabled
		Assert-AreEqual "TestLog1"   $actual.Logs[0].Category
		Assert-AreEqual $true        $actual.Logs[1].Enabled
		Assert-AreEqual "TestLog2"   $actual.Logs[1].Category
		Assert-AreEqual "/subscriptions/9cf7cc0a-0ba1-4624-bc82-97e1ee25dc45/resourcegroups/appendblobtest/providers/microsoft.operationalinsights/workspaces/appendblob" $actual.WorkspaceId
		Assert-Null $actual.ServiceBusRuleId
		Assert-AreEqual "service"    $actual.Name
		Assert-AreEqual "Dedicated"  $actual.LogAnalyticsDestinationType
	}
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}




# TODO add more complicated scenarios after we have a definitive subscription