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
Tests getting a single fault for a resource group with admin subscription id.
#>
function Test-GetFault
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'
    $faultId = 'D64F6195-93FE-40AF-B0A7-D8EA10506028'

    try 
    {
        $actual = Get-ACSFault -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName -FaultId $faultId

        Assert-AreEqual $actual.Count 1
        Assert-AreEqual $actual.ActivatedTime.ToString("yyyy-MM-dd HH:mm:ss") "2015-05-18 18:02:00"
        Assert-AreEqual $actual.AssociatedDataType 'Metrics'
        Assert-AreEqual $actual.AssociatedEventQuery $null
        Assert-AreEqual $actual.AssociatedMetricsName 'MetricsName'
        Assert-AreEqual $actual.Description 'TBD'
        Assert-AreEqual $actual.FaultId 'D64F6195-93FE-40AF-B0A7-D8EA10506028'
        Assert-AreEqual $actual.FaultRuleName 'faultRule1'
        Assert-AreEqual $actual.ResolutionText 'TBD'
        Assert-AreEqual $actual.ResolvedTime $null
        Assert-AreEqual $actual.ResourceUri '/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/Microsoft.Storage.Admin/farms/03768357-B4F2-4C3C-AA75-574209B03D49/tableserverinstances/woss-node1'
        Assert-AreEqual $actual.Severity 'Critical'
        Assert-AreEqual $actual.ResourceGroupName $rgname
        Assert-AreEqual $actual.FarmName $farmName
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Dismiss a fault for a resource group with admin subscription id.
#>
function Test-ResolveFault
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'
    $faultId = 'D64F6195-93FE-40AF-B0A7-D8EA10506028'

    try 
    {
        $actual = Resolve-ACSFault -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName -FaultId $faultId -Force

    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}


<#
.SYNOPSIS
Tests get historic faults within a time period in a resource group with admin subscription id.
#>
function Test-GetHistoricFaults
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'

    try 
    {
        $startTime = [DateTime]'1/1/2015'
        $endTime = [DateTime]'1/2/2015' 

        $actual = Get-ACSFault `
        -FarmName $farmName -SubscriptionId $subscriptionId -ResourceGroupName $rgname -SkipCertificateValidation `
        -StartTime $startTime -EndTime $endTime

        Assert-AreEqual $actual.Count 1
        Assert-AreEqual $actual.ActivatedTime.ToString("yyyy-MM-dd HH:mm:ss") "2015-05-18 18:02:00"
        Assert-AreEqual $actual.AssociatedDataType 'Metrics'
        Assert-AreEqual $actual.AssociatedEventQuery $null
        Assert-AreEqual $actual.AssociatedMetricsName 'MetricsName'
        Assert-AreEqual $actual.Description 'TBD'
        Assert-AreEqual $actual.FaultId 'D64F6195-93FE-40AF-B0A7-D8EA10506028'
        Assert-AreEqual $actual.FaultRuleName 'faultRule1'
        Assert-AreEqual $actual.ResolutionText 'TBD'
        Assert-AreEqual $actual.ResolvedTime $null
        Assert-AreEqual $actual.ResourceUri '/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/Microsoft.Storage.Admin/farms/03768357-B4F2-4C3C-AA75-574209B03D49/tableserverinstances/woss-node1'
        Assert-AreEqual $actual.Severity 'Critical'
        Assert-AreEqual $actual.ResourceGroupName $rgname
        Assert-AreEqual $actual.FarmName $farmName
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests get current faults for a specific resource in a resource group with admin subscription id.
#>
function Test-GetCurrentFaults
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'

    try 
    {
        $resourceUri = '/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourcegroups/Default-Web-EastUS/farms/03768357-B4F2-4C3C-AA75-574209B03D49'
        $actual = Get-ACSFault `
        -FarmName $farmName -SubscriptionId $subscriptionId -ResourceGroupName $rgname -SkipCertificateValidation `
        -ResourceUri $resourceUri

        Assert-AreEqual $actual.Count 1
        Assert-AreEqual $actual.ActivatedTime.ToString("yyyy-MM-dd HH:mm:ss") "2015-05-18 18:02:00"
        Assert-AreEqual $actual.AssociatedDataType 'Metrics'
        Assert-AreEqual $actual.AssociatedEventQuery $null
        Assert-AreEqual $actual.AssociatedMetricsName 'MetricsName'
        Assert-AreEqual $actual.Description 'TBD'
        Assert-AreEqual $actual.FaultId 'D64F6195-93FE-40AF-B0A7-D8EA10506028'
        Assert-AreEqual $actual.FaultRuleName 'faultRule1'
        Assert-AreEqual $actual.ResolutionText 'TBD'
        Assert-AreEqual $actual.ResolvedTime $null
        Assert-AreEqual $actual.ResourceUri '/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/Microsoft.Storage.Admin/farms/03768357-B4F2-4C3C-AA75-574209B03D49/tableserverinstances/woss-node1'
        Assert-AreEqual $actual.Severity 'Critical'
        Assert-AreEqual $actual.ResourceGroupName $rgname
        Assert-AreEqual $actual.FarmName $farmName
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}