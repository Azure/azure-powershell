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
Tests adding an alert rule.
#>
function Test-AddAlertRule
{
    try 
    {
        # Test
        $actual = Add-AlertRule -ruletype metric -Name chiricutin -Location "East US" -ResourceGroup Default-Web-EastUS -Operator GreaterThan -Threshold 2 -WindowSize 00:05:00 -ResourceId /subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo -MetricName Requests -Description "Pura Vida" -TimeAggre Total

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
function Test-GetAlertRule
{
    # Setup
    $rgname = 'Default-Web-EastUS'

    try 
    {
	    $actual = Get-AlertRule -ResourceGroup $rgname -detailedOutput

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
function Test-RemoveAlertRule
{
    # Setup
    $rgname = 'Default-Web-EastUS'

    try 
    {
		$actual = Remove-AlertRule -ResourceGroup $rgname -name chiricutin

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
function Test-GetAlertHistory
{
    try 
    {
		$actual = Get-AlertHistory -endTime 2015-02-11T12:00:00 -detailedOutput

        # Assert
		Assert-AreEqual $actual.Count 2
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}
