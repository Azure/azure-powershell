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
Tests the creation of an alert rule webhook action.
#>
function Test-NewAzureRmAlertRuleWebhook
{
    try 
    {
        # Test
        Assert-Throws { New-AzureRmAlertRuleWebhook } "Cannot process command because of one or more missing mandatory parameters: ServiceUri."

		$actual = New-AzureRmAlertRuleWebhook 'http://hello.com'
		Assert-AreEqual $actual.ServiceUri 'http://hello.com'
		Assert-NotNull $actual.Properties
		Assert-AreEqual 0 $actual.Properties.Count

		$actual = New-AzureRmAlertRuleWebhook 'http://hello.com' @{prop1 = 'value1'}
		Assert-AreEqual $actual.ServiceUri 'http://hello.com'
		Assert-NotNull $actual.Properties
		Assert-AreEqual 1 $actual.Properties.Count
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests the creation of an alert rule e-mail action.
#>
function Test-NewAzureRmAlertRuleEmail
{
    try 
    {
        # Test
		Assert-Throws { New-AzureRmAlertRuleEmail } "Either SendToServiceOwners must be set or at least one custom email must be present"

        $actual = New-AzureRmAlertRuleEmail -SendToServiceOwners
		Assert-NotNull $actual "Result is null 1"
		Assert-Null $actual.CustomEmails "Result is not null 1"
		Assert-True { $actual.SendToServiceOwners } "a1"

		$actual = New-AzureRmAlertRuleEmail gu@macrosoft.com
		Assert-NotNull $actual "Result is null #4"
		Assert-NotNull $actual.CustomEmails "Result is null #5"
		Assert-False { $actual.SendToServiceOwners } "a2"

		$actual = New-AzureRmAlertRuleEmail gu@macrosoft.com, hu@megasoft.net
		Assert-NotNull $actual "Result is null #6"
		Assert-NotNull $actual.CustomEmails "Result is null #7"
		Assert-False { $actual.SendToServiceOwners } "a3"

		$actual = New-AzureRmAlertRuleEmail hu@megasoft.net -SendToServiceOwners
		Assert-NotNull $actual "Result is null #8"
		Assert-NotNull $actual.CustomEmails "Result is null #9"
		Assert-True { $actual.SendToServiceOwners } "a4"

		$actual = New-AzureRmAlertRuleEmail gu@macrosoft.com, hu@megasoft.net -SendToServiceOwners
		Assert-NotNull $actual "Result is null #11"
		Assert-NotNull $actual.CustomEmails "Result is null #12"
		Assert-True { $actual.SendToServiceOwners } "a5"
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests adding an alert rule.
#>
function Test-AddAzureRmMetricAlertRule
{
    try 
    {
        # Test
        $actual = Add-AzureRmMetricAlertRule -Name chiricutin -Location "East US" -ResourceGroup Default-Web-EastUS -Operator GreaterThan -Threshold 2 -WindowSize 00:05:00 -TargetResourceId /subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo -MetricName Requests -Description "Pura Vida" -TimeAggre Total

        # Assert TODO add more asserts
		Assert-AreEqual $actual.RequestId '47af504c-88a1-49c5-9766-e397d54e490b'
		Assert-AreEqual $actual.StatusCode 'Created'
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests adding an alert rule.
#>
function Test-AddAzureRmLogAlertRule
{
    try 
    {
        # Test
        $actual = Add-AzureRmLogAlertRule -Name "chiricutin" -Location "East US" -ResourceGroup "Default-Web-EastUS" -OperationName "Create" -TargetResourceId "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo" -Description "Pura Vida"

        # Assert TODO add more asserts
		Assert-AreEqual $actual.RequestId '47af504c-88a1-49c5-9766-e397d54e490b'
		Assert-AreEqual $actual.StatusCode 'Created'
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests adding an alert rule.
#>
function Test-AddAzureRmWebtestAlertRule
{
    try 
    {
        # Test
        $actual = Add-AzureRmWebtestAlertRule -Name chiricutin -Location "East US" -ResourceGroup Default-Web-EastUS -WindowSize 00:05:00 -Failed 3 -MetricName Requests -TargetResourceUri /subscriptions/b67f7fec-69fc-4974-9099-a26bd6ffeda3/resourceGroups/Default-Web-EastUS/providers/Microsoft.Insights/components/misitiooeltuyo -Description "Pura Vida" 

        # Assert TODO add more asserts
		Assert-AreEqual $actual.RequestId '47af504c-88a1-49c5-9766-e397d54e490b'
		Assert-AreEqual $actual.StatusCode 'Created'
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting the alert rules associated to a resource group.
#>
function Test-GetAzureRmAlertRule
{
    # Setup
    $rgname = 'Default-Web-EastUS'

    try 
    {
	    $actual = Get-AzureRmAlertRule -ResourceGroup $rgname -detailedOutput

        # Assert TODO add more asserts
		Assert-AreEqual $actual.Count 1
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests removing an alert rule.
#>
function Test-RemoveAzureRmAlertRule
{
    # Setup
    $rgname = 'Default-Web-EastUS'

    try 
    {
		$actual = Remove-AzureRmAlertRule -ResourceGroup $rgname -name chiricutin

        # Assert TODO add more asserts
		Assert-AreEqual $actual.RequestId '93550c06-54b2-4e11-8c29-a3bd7b37b1dc'
		Assert-AreEqual $actual.StatusCode 'OK'
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting the logs associated to a alerts in a subscription.
#>
function Test-GetAzureRmAlertHistory
{
    try 
    {
		$actual = Get-AzureRmAlertHistory -endTime 2015-02-11T12:00:00 -detailedOutput

        # Assert
		Assert-AreEqual $actual.Count 2
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}
