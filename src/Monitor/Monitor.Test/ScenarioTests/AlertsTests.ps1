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
        Assert-Throws { New-AzAlertRuleWebhook } "Cannot process command because of one or more missing mandatory parameters: ServiceUri."

		$actual = New-AzAlertRuleWebhook 'http://hello.com'
		Assert-AreEqual $actual.ServiceUri 'http://hello.com'
		Assert-NotNull $actual.Properties
		Assert-AreEqual 0 $actual.Properties.Count

		$actual = New-AzAlertRuleWebhook 'http://hello.com' @{prop1 = 'value1'}
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
		Assert-Throws { New-AzAlertRuleEmail } "Either SendToServiceOwners must be set or at least one custom email must be present"

        $actual = New-AzAlertRuleEmail -SendToServiceOwner
		Assert-NotNull $actual "Result is null 1"
		Assert-Null $actual.CustomEmails "Result is not null 1"
		Assert-True { $actual.SendToServiceOwners } "a1"

		$actual = New-AzAlertRuleEmail gu@macrosoft.com
		Assert-NotNull $actual "Result is null #4"
		Assert-NotNull $actual.CustomEmails "Result is null #5"
		Assert-False { $actual.SendToServiceOwners } "a2"

		$actual = New-AzAlertRuleEmail gu@macrosoft.com, hu@megasoft.net
		Assert-NotNull $actual "Result is null #6"
		Assert-NotNull $actual.CustomEmails "Result is null #7"
		Assert-False { $actual.SendToServiceOwners } "a3"

		$actual = New-AzAlertRuleEmail hu@megasoft.net -SendToServiceOwner
		Assert-NotNull $actual "Result is null #8"
		Assert-NotNull $actual.CustomEmails "Result is null #9"
		Assert-True { $actual.SendToServiceOwners } "a4"

		$actual = New-AzAlertRuleEmail gu@macrosoft.com, hu@megasoft.net -SendToServiceOwner
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
        $actual = Add-AzMetricAlertRule -Name chiricutin -Location "East US" -ResourceGroup Default-Web-EastUS -Operator GreaterThan -Threshold 2 -WindowSize 00:05:00 -TargetResourceId /subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo -MetricName Requests -Description "Pura Vida" -TimeAggre Total

        # Assert TODO add more asserts
		Assert-AreEqual $actual.RequestId '47af504c-88a1-49c5-9766-e397d54e490b'
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
        $actual = Add-AzWebtestAlertRule -Name chiricutin -Location "East US" -ResourceGroup Default-Web-EastUS -WindowSize 00:05:00 -Failed 3 -MetricName Requests -TargetResourceUri /subscriptions/b67f7fec-69fc-4974-9099-a26bd6ffeda3/resourceGroups/Default-Web-EastUS/providers/Microsoft.Insights/components/misitiooeltuyo -Description "Pura Vida"

        # Assert TODO add more asserts
		Assert-AreEqual $actual.RequestId '47af504c-88a1-49c5-9766-e397d54e490b'
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
	    $actual = Get-AzAlertRule -ResourceGroup $rgname
		Assert-NotNull $actual
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
Tests getting the alert rules associated to a resource group.
#>
function Test-GetAzureRmAlertRuleByName
{
    # Setup
    $rgname = 'Default-Web-EastUS'

    try
    {
        $actual = Get-AzAlertRule -ResourceGroup $rgname -Name 'MyruleName'
		Assert-NotNull $actual
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
		Remove-AzAlertRule -ResourceGroup $rgname -name chiricutin
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
		$actual = Get-AzAlertHistory -endTime 2015-02-11T20:00:00Z -detailedOutput

        # Assert
		Assert-AreEqual $actual.Count 2
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
function Test-GetAzureRmMetricAlertRuleV2
{
    # Setup
    $rgname = 'gd-test-ResourceGroup'

    try
    {
        $actual = Get-AzMetricAlertRuleV2 -ResourceGroupName $rgname -Name '2112019'
		Assert-NotNull $actual
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests creation of Dimension.
#>
function Test-NewAzureRmMetricAlertRuleV2DimensionSelection
{

    try
    {
        $actual = New-AzMetricAlertRuleV2DimensionSelection -DimensionName 'Run location' -ValuesToInclude 1,2,3
		Assert-NotNull $actual
		Assert-AreEqual $actual.Dimension 'Run location'
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests creation of Metric Criteria for GenV2 metric alert rule
#>
function Test-NewAzureRmMetricAlertRuleV2Criteria
{

    try
    {
        $actual = New-AzMetricAlertRuleV2Criteria -MetricName 'Percentage CPU' -TimeAggregation Total -Operator GreaterThan -Threshold 2
		Assert-NotNull $actual
		Assert-AreEqual $actual.MetricName 'Percentage CPU'
		Assert-AreEqual $actual.Threshold 2
		Assert-AreEqual $actual.TimeAggregation Total
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests removing a GenV2 metric alert rule.
#>
function Test-RemoveAzureRmAlertRuleV2
{
    # Setup
    $rgname = 'gd-test-ResourceGroup'

    try
    {
		Remove-AzMetricAlertRuleV2 -ResourceGroupName $rgname -Name 'temp'
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests adding a GenV2 metric alert rule.
#>
function Test-AddAzureRmMetricAlertRuleV2
{
	#Setup
	$scope = "/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/gd-test-ResourceGroup/providers/Microsoft.Compute/virtualMachines/gd-mr-vm1","/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/gd-rg-test-2/providers/Microsoft.Compute/virtualMachines/gd-mr-vm2","/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourceGroups/alertstest/providers/Microsoft.Compute/virtualMachines/sr-mr-vm1"
	$condition = New-AzMetricAlertRuleV2Criteria -MetricName 'Percentage CPU' -TimeAggregation Total -Operator GreaterThan -Threshold 2
	$actionGroup = New-AzActionGroup -ActionGroupID '/subscriptions/80430018-24ee-4b28-a7bd-fb23b5a221d6/resourcegroups/default-activitylogalerts/providers/microsoft.insights/actiongroups/anashah'
    try
    {
        # Test
        $actual = Add-AzMetricAlertRuleV2 -Name 'GenV2MetricAlertRule' -ResourceGroupName 'gd-test-ResourceGroup' -WindowSize 00:05:00 -Frequency 00:05:00 -TargetResourceScope $scope -TargetResourceType 'Microsoft.Compute/virtualMachines' -TargetResourceRegion 'southcentralus' -Condition $condition -ActionGroup $actionGroup -Severity 3

    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}