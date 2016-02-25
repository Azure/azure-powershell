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
Tests getting a single farm for a resource group with admin subscription id.
#>
function Test-GetFarm
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
	$farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'

    try 
    {
	    $orgin = Get-ACSFarm -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName
		Assert-AreEqual $orgin.HealthStatus "Warning"
		Assert-AreEqual $orgin.SettingsStore "anypath"	
		Assert-AreEqual $orgin.FarmName "farm_01"	
		Assert-AreEqual $orgin.Id "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/Microsoft.Storage.Admin/farms/farm_01"	
		Assert-AreEqual $orgin.Location "west us"	
		Assert-AreEqual $orgin.Name "farm_01"	
		Assert-AreEqual $orgin.Type "Microsoft.Storage.Admin/farms"	

		Assert-AreEqual $orgin.Settings.HostStyleHttpPort "80"	
		Assert-AreEqual $orgin.Settings.HostStyleHttpsPort "443"	
		Assert-AreEqual $orgin.Settings.SettingsPollingIntervalInSecond "60"		
		Assert-AreEqual $orgin.Settings.CorsAllowedOriginsList "http://manage.wossportal.com;http://www.example.com"	
        Assert-AreEqual $orgin.Settings.DataCenterUriHostSuffixes "contoso.com"

		$corsAllowedOriginsList = 'http://manage.wossportal.com;http://www.example.com'
	    $settingsPullingInterval = 90

		$actual = $orgin | Set-ACSFarm -SettingsPollingIntervalInSecond $settingsPullingInterval -CorsAllowedOriginsList $corsAllowedOriginsList
		Assert-AreEqual $actual.Settings.SettingsPollingIntervalInSecond $settingsPullingInterval
		Assert-AreEqual $actual.Settings.CorsAllowedOriginsList $corsAllowedOriginsList
	}
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests listing farms in a resource group with admin subscription id.
#>
function Test-ListFarms
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'	

    try 
    {
	    $actual = Get-ACSFarm -ResourceGroupName $rgname -SubscriptionId $subscriptionId

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
Tests set farm settings in a resource group with admin subscription id.
#>
function Test-SetFarm
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
	$corsAllowedOriginsList = 'http://manage.wossportal.com;http://www.example.com'
	$settingsPullingInterval = 90
	$farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'

    try 
    {
	    $actual = Set-ACSFarm -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName -SettingsPollingIntervalInSecond $settingsPullingInterval -CorsAllowedOriginsList $corsAllowedOriginsList
        Assert-AreEqual $actual.HealthStatus "Unknown"		
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}
