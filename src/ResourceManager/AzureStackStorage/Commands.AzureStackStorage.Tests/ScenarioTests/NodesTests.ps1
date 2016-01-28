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
Tests getting a single node for a resource group with admin subscription id.
#>
function Test-GetNode
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
	$farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'
	$nodeName = 'woss-node-1'

    try 
    {
	    $orgin = Get-ACSNode -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName -NodeName $nodeName
		Assert-AreEqual $orgin.HealthState "Critical"
		Assert-AreEqual $orgin.FarmName "03768357-B4F2-4C3C-AA75-574209B03D49"	
		Assert-AreEqual $orgin.Id "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourcegroups/Default-Web-EastUS/providers/Microsoft.Storage.Admin/farms/03768357-B4F2-4C3C-AA75-574209B03D49/nodes/woss-node-1"	
		Assert-AreEqual $orgin.Location "West_US"	
		Assert-AreEqual $orgin.Name "03768357-B4F2-4C3C-AA75-574209B03D49/woss-node-1"	
		Assert-AreEqual $orgin.Type "Microsoft.Storage.Admin/farms/nodes"	
		Assert-AreEqual $orgin.codeVersion "3.0.1414.9492"	
		Assert-AreEqual $orgin.configVersion "1.0"	
		Assert-AreEqual $orgin.faultDomain "fd:/woss-node-1"	
		Assert-AreEqual $orgin.configVersion "1.0"	
		Assert-AreEqual $orgin.upgradeDomain "WOSS_U1"	
		Assert-AreEqual $orgin.runningInstanceUris.count 2
		Assert-AreEqual $orgin.runningInstanceUris[0] "subscriptions/serviceAdmin/resourcegroups/system/providers/Microsoft.Storage.Admin/farms/WEST_US_1/tableserverinstances/woss-node-1"
		Assert-AreEqual $orgin.runningInstanceUris[1] "subscriptions/serviceAdmin/resourcegroups/system/providers/Microsoft.Storage.Admin/farms/WEST_US_1/accountcontainerserverinstances/woss-node-1"
	
		$actual = $orgin | Disable-ACSNode
	}
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests listing nodes in a resource group with admin subscription id.
#>
function Test-ListNodes
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'	
	$farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'

    try 
    {
	    $actual = Get-ACSNode -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName

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
Tests disabling a single node in cluster in a resource group with admin subscription id.
#>
function Test-EnableNode
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'	
	$farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'

    try 
    {
	    $actual = Enable-ACSNode -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName 

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
Tests disabling a single node in cluster in a resource group with admin subscription id.
#>
function Test-DisableNode
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'	
	$farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'
	$nodeName = 'woss-node-1'

    try 
    {
	    $actual = Disable-ACSNode -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName -NodeName $nodeName

        # Assert TODO add more asserts		
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests enabling a single node in cluster in a resource group with admin subscription id.
#>
function Test-EnableNode
{
    # Setup
    $rgname = 'Default-Web-EastUS'
	$subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'	
	$farmName = '03768357-B4F2-4C3C-AA75-574209B03D49'
	$nodeName = 'woss-node-1'

    try 
    {
	    $actual = Enable-ACSNode -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName -NodeName $nodeName

        # Assert TODO add more asserts		
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}