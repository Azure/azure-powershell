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
function Test-GetTableService
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
	$farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'

    try 
    {
	    $orgin = Get-ACSTableService -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName
		Assert-AreEqual $orgin.HealthStatus "Unknown"
		Assert-AreEqual $orgin.FarmName "82ba752f-0fac-47e2-8477-5731f9f5db34"	
		Assert-AreEqual $orgin.Id "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/Microsoft.Storage.Admin/farms/82ba752f-0fac-47e2-8477-5731f9f5db34/tableservices/default"	
		Assert-AreEqual $orgin.Location "redmond"	
		Assert-AreEqual $orgin.Name "82ba752f-0fac-47e2-8477-5731f9f5db34/default"	
		Assert-AreEqual $orgin.Type "Microsoft.Storage.Admin/farms/tableservices"	
		Assert-AreEqual $orgin.version "1.0"
	
		Assert-AreEqual $orgin.Settings.frontEndHttpListenPort "11002"	
		Assert-AreEqual $orgin.Settings.frontEndHttpsListenPort "11102"	
		Assert-AreEqual $orgin.Settings.frontEndCallbackThreadsCount "1800"		
		Assert-AreEqual $orgin.Settings.frontEndCpuBasedKeepAliveThrottlingEnabled "true"	
        Assert-AreEqual $orgin.Settings.frontEndCpuBasedKeepAliveThrottlingPercentCpuThreshold "100"
		Assert-AreEqual $orgin.Settings.frontEndCpuBasedKeepAliveThrottlingPercentRequestsToThrottle "10"
		Assert-AreEqual $orgin.Settings.frontEndCpuBasedKeepAliveThrottlingCpuMonitorIntervalInSeconds "20"
		Assert-AreEqual $orgin.Settings.frontEndMemoryThrottlingEnabled "true"
		Assert-AreEqual $orgin.Settings.frontEndMaxMillisecondsBetweenMemorySamples "10000"
		Assert-AreEqual $orgin.Settings.frontEndMemoryThrottleThresholdSettings "5,100,0;7,50,0;10,25,0;15,0,25;"
		#Assert-AreEqual $orgin.Settings.frontEndMinThreadPoolThreads "1600"
		Assert-AreEqual $orgin.Settings.frontEndThreadPoolBasedKeepAliveIOCompletionThreshold "1500"
		Assert-AreEqual $orgin.Settings.frontEndThreadPoolBasedKeepAliveWorkerThreadThreshold "1500"
		Assert-AreEqual $orgin.Settings.frontEndThreadPoolBasedKeepAliveMonitorIntervalInSeconds "30"
		Assert-AreEqual $orgin.Settings.frontEndThreadPoolBasedKeepAlivePercentage "10"
		Assert-AreEqual $orgin.Settings.frontEndUseSlaTimeInAvailability "true"
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
function Test-SetTableService
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'	
	$farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'

    try 
    {
	    $actual = Set-ACSTableService -FarmName $farmName `
		-SubscriptionId $subscriptionId -ResourceGroupName $rgname -SkipCertificateValidation `
		-FrontEndCpuBasedKeepAliveThrottlingEnabled $true `
		-FrontEndMemoryThrottlingEnabled $true
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

