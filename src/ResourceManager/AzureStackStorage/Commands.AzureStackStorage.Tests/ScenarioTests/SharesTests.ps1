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
Tests getting a single share for a resource group with admin subscription id.
#>
function Test-GetShare
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'
    $shareName = '||smb|share1'

    try 
    {
        $actual = Get-ACSShare -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName -ShareName $shareName

        Assert-AreEqual $actual.Count 1
        Assert-AreEqual $actual.FreeCapacity 460
        Assert-AreEqual $actual.HealthStatus 'Warning'
        Assert-AreEqual $actual.ShareName $shareName
        Assert-AreEqual $actual.TotalCapacity 500
        Assert-AreEqual $actual.UncPath $shareName
        Assert-AreEqual $actual.UsedCapacity 40
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
Tests listing shares in a resource group with admin subscription id.
#>
function Test-ListShares
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'

    try 
    {
        $actual = Get-ACSShare -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName

        Assert-AreEqual $actual.Count 1
        Assert-AreEqual $actual[0].FreeCapacity 460
        Assert-AreEqual $actual[0].HealthStatus 'Warning'
        Assert-AreEqual $actual[0].ShareName '||smb|share1'
        Assert-AreEqual $actual[0].TotalCapacity 500
        Assert-AreEqual $actual[0].UncPath '||smb|share1'
        Assert-AreEqual $actual[0].UsedCapacity 40
        Assert-AreEqual $actual[0].FarmName $farmName
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}