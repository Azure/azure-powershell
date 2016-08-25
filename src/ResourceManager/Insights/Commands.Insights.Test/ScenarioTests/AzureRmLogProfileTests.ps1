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
Tests getting log profiles
#>
function Test-GetAzureRmLogProfile
{
    try 
    {
        # Test
        $actual = Get-AzureRmLogProfile -Name default

        Assert-AreEqual /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/providers/microsoft.insights/logprofiles/default $actual.Id 
        Assert-AreEqual default        $actual.Name
        Assert-AreEqual "/subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/insights-integration/providers/Microsoft.Storage/storageAccounts/insightsintegration7777" $actual.StorageAccountId
        Assert-AreEqual $null          $actual.ServiceBusRuleId
        Assert-AreEqual 1              $actual.Locations.Count
        Assert-AreEqual global         $actual.Locations
        Assert-AreEqual 3              $actual.Categories.Count
        Assert-AreEqual Delete         $actual.Categories[0]
        Assert-AreEqual Write          $actual.Categories[1]
        Assert-AreEqual Action         $actual.Categories[2]
        Assert-AreEqual $false         $actual.RetentionPolicy.Enabled
        Assert-AreEqual 0              $actual.RetentionPolicy.Days
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests adding log profile
#>
function Test-AddAzureRmLogProfile
{
    try 
    {
        $actual = Add-AzureRmLogProfile -Name default -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/insights-integration/providers/Microsoft.Storage/storageAccounts/insightsintegration7777 -Locations global -Categories Delete,Write,Action

        Assert-AreEqual $true $actual 
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests adding log profile
#>
function Test-AddAzureRmLogProfileWithRetention
{
    try 
    {
        $actual = Add-AzureRmLogProfile -Name default -StorageAccountId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/insights-integration/providers/Microsoft.Storage/storageAccounts/insightsintegration7777 -Locations global -Categories Delete,Write,Action -RetentionInDays 90

        Assert-AreEqual $true $actual 
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}