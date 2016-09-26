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
Tests adding an autoscale setting.
#>
function Test-AddAzureRmAutoscaleSetting
{
	# Setup
	$resourceId = "/subscriptions/b67f7fec-69fc-4974-9099-a26bd6ffeda3/resourceGroups/TestingMetricsScaleSet/providers/Microsoft.Compute/virtualMachineScaleSets/testingsc"
	$resourceGroup = "TestingMetricsScaleSet"

    #$webhook1 = New-AzureRmAutoscaleWebhook -ServiceUri "http://myservice.com"
    #$notification1 = New-AzureRmAutoscaleNotification -Cust gu@ms.com, ge@ns.net -SendEmailToSubscriptionAdministrator -SendEmailToSubscriptionCoAdministrators -webhooks $webhook1
  
	$rule1 = New-AzureRmAutoscaleRule -MetricName Requests -MetricResourceId $resourceId -Operator GreaterThan -MetricStatistic Average -Threshold 10 -TimeGrain 00:01:00 -ScaleActionCooldown 00:05:00 -ScaleActionDirection Increase -ScaleActionValue "1" 
	$rule2 = New-AzureRmAutoscaleRule -MetricName Requests -MetricResourceId $resourceId -Operator GreaterThan -MetricStatistic Average -Threshold 15 -TimeGrain 00:02:00 -ScaleActionCooldown 00:06:00 -ScaleActionDirection Decrease -ScaleActionValue "2"
	$profile1 = New-AzureRmAutoscaleProfile -DefaultCapacity "1" -MaximumCapacity "10" -MinimumCapacity "1" -StartTimeWindow 2015-03-05T14:00:00 -EndTimeWindow 2015-03-05T14:30:00 -TimeWindowTimeZone GMT -Rules $rule1, $rule2 -Name "adios"
	$profile2 = New-AzureRmAutoscaleProfile -DefaultCapacity "1" -MaximumCapacity "10" -MinimumCapacity "1" -Rules $rule1, $rule2 -Name "saludos" -RecurrenceFrequency Week -ScheduleDays "1" -ScheduleHours 5 -ScheduleMinutes 15 -ScheduleTimeZone UTC

    try 
    {
        # Test
		Add-AzureRmAutoscaleSetting -Location "East US" -Name MySetting -ResourceGroup $resourceGroup -TargetResourceId $resourceId -AutoscaleProfiles $profile1, $profile2
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting the autoscale setting associated to a resource group.
#>
function Test-GetAzureRmAutoscaleSetting
{
    # Setup
    $rgname = 'TestingMetricsScaleSet'

    try 
    {
		$actual = Get-AzureRmAutoscaleSetting -ResourceGroup $rgname -Name "MySetting" -detailedOutput

		# Assert TODO add more asserts
		Assert-NotNull $actual "Result is null"

	    $actual = Get-AzureRmAutoscaleSetting -ResourceGroup $rgname -detailedOutput

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
Tests removing an autoscale setting
#>
function Test-RemoveAzureRmAutoscaleSetting
{
    # Setup
    $rgname = 'Default-Web-EastUS'

    try 
    {
		Remove-AzureRmAutoscaleSetting -ResourceGroup $rgname -name DefaultServerFarm-Default-Web-EastUS
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests getting the logs associated to an autoscale setting in a subscription.
#>
function Test-GetAzureRmAutoscaleHistory
{
    try 
    {
		$actual = Get-AzureRmAutoscaleHistory -StartTime 2015-02-09T18:35:00 -endTime 2015-02-09T18:40:00 -detailedOutput

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
Tests creating a new Autoscale notification.
#>
function Test-NewAzureRmAutoscaleNotification
{
    try 
    {
		Assert-Throws { New-AzureRmAutoscaleNotification } "At least one Webhook or one CustomeEmail must be present, or the notification must be sent to the admin or co-admin"

		$actual = New-AzureRmAutoscaleNotification -CustomEmails gu@ms.com, fu@net.net

        # Assert
		Assert-Null $actual.Webhooks "webhooks"
		Assert-NotNull $actual.Email "email"
		Assert-NotNull $actual.Email.CustomEmails "custom emails"
		Assert-AreEqual 2 $actual.Email.CustomEmails.Length "length"
		Assert-False { $actual.Email.SendToSubscriptionAdministrator } "SendToSubscriptionAdministrator"
		Assert-False { $actual.Email.SendToSubscriptionCoAdministrators } "SendToSubscriptionCoAdministrators"

		$actual = New-AzureRmAutoscaleNotification -SendEmailToSubscriptionAdministrator

        # Assert
		Assert-Null $actual.Webhooks
		Assert-NotNull $actual.Email
		Assert-Null $actual.Email.CustomeEmails
		Assert-True { $actual.Email.SendToSubscriptionAdministrator } "SendToSubscriptionAdministrator"
		Assert-False { $actual.Email.SendToSubscriptionCoAdministrators } "SendToSubscriptionCoAdministrators"

		$actual = New-AzureRmAutoscaleNotification -SendEmailToSubscriptionCoAdministrators

        # Assert
		Assert-Null $actual.Webhooks
		Assert-NotNull $actual.Email
		Assert-Null $actual.Email.CustomeEmails
		Assert-False { $actual.Email.SendToSubscriptionAdministrator } "SendToSubscriptionAdministrator"
		Assert-True { $actual.Email.SendToSubscriptionCoAdministrators } "SendToSubscriptionCoAdministrators"
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests creating a new Autoscale webhook.
#>
function Test-NewAzureRmAutoscaleWebhook
{
    try 
    {
		$actual = New-AzureRmAutoscaleWebhook -ServiceUri "http://myservice.com"

        # Assert
		Assert-AreEqual "http://myservice.com" $actual.ServiceUri
		Assert-AreEqual 0 $actual.Properties.Count
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}
