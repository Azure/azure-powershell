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
function Test-AddAutoscaleSetting
{
	# Setup
	$rule1 = new-autoscaleRule -MetricName Requests -MetricResourceId "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo" -Operator GreaterThan -MetricStatistic Average -Threshold 10 -TimeGrain 00:01:00 -ScaleActionCooldown 00:05:00 -ScaleActionDirection Increase -ScaleActionScaleType ChangeCount -ScaleActionValue "1" 
    $rule2 = new-autoscaleRule -MetricName Requests -MetricResourceId "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo" -Operator GreaterThan -MetricStatistic Average -Threshold 10 -TimeGrain 00:01:00 -ScaleActionCooldown 00:10:00 -ScaleActionDirection Increase -ScaleActionScaleType ChangeCount -ScaleActionValue "2"
	$profile1 = new-autoscaleprofile -DefaultCapacity "1" -MaximumCapacity "10" -MinimumCapacity "1" -StartTimeWindow 2015-03-05T14:00:00 -EndTimeWindow 2015-03-05T14:30:00 -TimeWindowTimeZone GMT -Rules $rule1, $rule2 -Name "adios"
	$profile2 = new-autoscaleprofile -DefaultCapacity "1" -MaximumCapacity "10" -MinimumCapacity "1" -Rules $rule1, $rule2 -Name "saludos" -RecurrenceFrequency Minute -ScheduleDays "1", "2", "3" -ScheduleHours 5, 10, 15 -ScheduleMinutes 15, 30, 45 -ScheduleTimeZone GMT

    try 
    {
        # Test
		$actual = add-autoscalesetting -Location "East US" -Name MySetting -ResourceGroup Default-Web-EastUS -TargetResourceId /subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/serverFarms/DefaultServerFarm -AutoscaleProfiles $profile1, $profile2

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
Tests getting the autoscale setting associated to a resource group.
#>
function Test-GetAutoscaleSetting
{
    # Setup
    $rgname = 'Default-Web-EastUS'

    try 
    {
	    $actual = Get-AutoscaleSetting -ResourceGroup $rgname -detailedOutput

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
function Test-RemoveAutoscaleSetting
{
    # Setup
    $rgname = 'Default-Web-EastUS'

    try 
    {
		$actual = Remove-AutoscaleSetting -ResourceGroup $rgname -name DefaultServerFarm-Default-Web-EastUS

        # Assert TODO add more asserts
		Assert-AreEqual $actual.RequestId 'db74e798-b011-4311-bba4-08cf31cb6a3b'
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
Tests getting the logs associated to an autoscale setting in a subscription.
#>
function Test-GetAutoscaleHistory
{
    try 
    {
		$actual = Get-AutoscaleHistory -StartTime 2015-02-09T18:35:00 -endTime 2015-02-09T18:40:00 -detailedOutput

        # Assert
		Assert-AreEqual $actual.Count 2
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}
