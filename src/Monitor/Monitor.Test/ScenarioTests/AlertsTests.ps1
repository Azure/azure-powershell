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
	$sub = Get-AzContext
    $subscription = $sub.subscription.subscriptionId
	$rgname = Get-ResourceGroupName
	$location =Get-ProviderLocation ResourceManagement
	$resourceName = Get-ResourceName
	$ruleName = Get-ResourceName
	$actionGroupName = Get-ResourceName
	$targetResourceId = '/subscriptions/'+$subscription+'/resourceGroups/'+$rgname+'/providers/Microsoft.Storage/storageAccounts/'+$resourceName
	New-AzResourceGroup -Name $rgname -Location $location -Force
	New-AzStorageAccount -ResourceGroupName $rgname -Name $resourceName -Location $location -Type Standard_GRS
	$email = New-AzActionGroupReceiver -Name 'user1' -EmailReceiver -EmailAddress 'user1@example.com'
	$NewActionGroup =  Set-AzureRmActionGroup -Name $actionGroupName -ResourceGroup $rgname -ShortName ASTG -Receiver $email
	$actionGroup = New-AzActionGroup -ActionGroupId $NewActionGroup.Id
	$condition = New-AzMetricAlertRuleV2Criteria -MetricName "UsedCapacity" -Operator GreaterThan -Threshold 8 -TimeAggregation Average
	Add-AzMetricAlertRuleV2 -Name $ruleName -ResourceGroupName $rgname -WindowSize 01:00:00 -Frequency 00:01:00 -TargetResourceId $targetResourceId -Condition $condition -ActionGroup $actionGroup -Severity 3 

    try
    {
        $actual = Get-AzMetricAlertRuleV2 -ResourceGroupName $rgname -Name $ruleName
		Assert-NotNull $actual
    }
    finally
    {
        # Cleanup
        Remove-AzMetricAlertRuleV2 -ResourceGroupName $rgname -Name $ruleName
		Remove-AzActionGroup -ResourceGroupName $rgname -Name $actionGroupName
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $resourceName 
		Remove-AzResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests removing a GenV2 metric alert rule.
#>
function Test-RemoveAzureRmAlertRuleV2
{
    # Setup
	$sub = Get-AzContext
    $subscription = $sub.subscription.subscriptionId
	$rgname = Get-ResourceGroupName
	$location =Get-ProviderLocation ResourceManagement
	$resourceName = Get-ResourceName
	$ruleName = Get-ResourceName
	$actionGroupName = Get-ResourceName
	$targetResourceId = '/subscriptions/'+$subscription+'/resourceGroups/'+$rgname+'/providers/Microsoft.Storage/storageAccounts/'+$resourceName
	New-AzResourceGroup -Name $rgname -Location $location -Force
	New-AzStorageAccount -ResourceGroupName $rgname -Name $resourceName -Location $location -Type Standard_GRS
	$email = New-AzActionGroupReceiver -Name 'user1' -EmailReceiver -EmailAddress 'user1@example.com'
	$NewActionGroup =  Set-AzureRmActionGroup -Name $actionGroupName -ResourceGroup $rgname -ShortName ASTG -Receiver $email
	$actionGroup = New-AzActionGroup -ActionGroupId $NewActionGroup.Id
	$condition = New-AzMetricAlertRuleV2Criteria -MetricName "UsedCapacity" -Operator GreaterThan -Threshold 8 -TimeAggregation Average
	Add-AzMetricAlertRuleV2 -Name $ruleName -ResourceGroupName $rgname -WindowSize 01:00:00 -Frequency 00:01:00 -TargetResourceId $targetResourceId -Condition $condition -ActionGroup $actionGroup -Severity 3 
    try
    {
		$job = Remove-AzMetricAlertRuleV2 -ResourceGroupName $rgname -Name $ruleName -AsJob
		$job|Wait-Job
		$actual = $job | Receive-Job
    }
    finally
    {
        # Cleanup
      Remove-AzActionGroup -ResourceGroupName $rgname -Name $actionGroupName
	  Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $resourceName 
	  Remove-AzResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Tests adding a GenV2 metric alert rule.
#>
function Test-AddAzureRmMetricAlertRuleV2
{
	# Setup
	$sub = Get-AzContext
    $subscription = $sub.subscription.subscriptionId
	$rgname = Get-ResourceGroupName
	$location =Get-ProviderLocation ResourceManagement
	$resourceName = Get-ResourceName
	$ruleName = Get-ResourceName
	$actionGroupName = Get-ResourceName
	$targetResourceId = '/subscriptions/'+$subscription+'/resourceGroups/'+$rgname+'/providers/Microsoft.Storage/storageAccounts/'+$resourceName
	New-AzResourceGroup -Name $rgname -Location $location -Force
	New-AzStorageAccount -ResourceGroupName $rgname -Name $resourceName -Location $location -Type Standard_GRS
	$email = New-AzActionGroupReceiver -Name 'user1' -EmailReceiver -EmailAddress 'user1@example.com'
	$NewActionGroup =  Set-AzureRmActionGroup -Name $actionGroupName -ResourceGroup $rgname -ShortName ASTG -Receiver $email
	$actionGroup = New-AzActionGroup -ActionGroupId $NewActionGroup.Id
	$condition = New-AzMetricAlertRuleV2Criteria -MetricName "UsedCapacity" -Operator GreaterThan -Threshold 8 -TimeAggregation Average
    try
    {
        # Test
        $actual = Add-AzMetricAlertRuleV2 -Name $ruleName -ResourceGroupName $rgname -WindowSize 01:00:00 -Frequency 00:01:00 -TargetResourceId $targetResourceId -Condition $condition -ActionGroup $actionGroup -Severity 3 
		Assert-AreEqual $actual.Name $ruleName
    }
    finally
    {
        # Cleanup
        Remove-AzMetricAlertRuleV2 -ResourceGroupName $rgname -Name $ruleName
		Remove-AzActionGroup -ResourceGroupName $rgname -Name $actionGroupName
		Remove-AzureRmStorageAccount -ResourceGroupName $rgName -Name $resourceName
		Remove-AzResourceGroup -Name $rgname -Force
    }
}