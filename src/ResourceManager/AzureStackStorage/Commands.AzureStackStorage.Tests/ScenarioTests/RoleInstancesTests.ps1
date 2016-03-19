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
Tests getting a single role instance for a resource group with admin subscription id.
#>
function Test-GetRoleInstance
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '3c62b865-d397-47fe-99ed-6dda536a1a69'
    $roleInstanceId = 'D11180COL0'

    try 
    {
        $result = Get-ACSRoleInstance `
        -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName `
        -RoleType TableServer `
        -InstanceId $roleInstanceId

        Assert-AreEqual $result.HealthStatus "Healthy"
        Assert-AreEqual $result.NodeUri "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourcegroups/Default-Web-EastUS/providers/Microsoft.Storage.Admin/farms/3c62b865-d397-47fe-99ed-6dda536a1a69/nodes/D11180COL0"
        Assert-AreEqual $result.InstanceId $roleInstanceId
        Assert-AreEqual $result.Status "Active"

        $settings = $result.settings
        Assert-AreEqual $settings.TableServerMaxConnections 100
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests listing role instances in a resource group with admin subscription id.
#>
function Test-ListRoleInstances
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '3c62b865-d397-47fe-99ed-6dda536a1a69'

    try 
    {
        $results = Get-ACSRoleInstance `
        -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName `
        -RoleType TableServer

        # Assert TODO add more asserts
        Assert-AreEqual $results.Count 6
        Assert-AreEqual $results[0].HealthStatus "Healthy"
        Assert-AreEqual $results[0].NodeUri "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourcegroups/Default-Web-EastUS/providers/Microsoft.Storage.Admin/farms/3c62b865-d397-47fe-99ed-6dda536a1a69/nodes/D11180COL0"
        Assert-AreEqual $results[0].InstanceId "D11180COL0"
        Assert-AreEqual $results[0].Status "Active"

        $settings = $results[0].settings
        Assert-AreEqual $settings.TableServerMaxConnections 100
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

<#
.SYNOPSIS
Tests restarting a role instance in cluster in a resource group with admin subscription id.
#>
function Test-RestartRoleInstance
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '3c62b865-d397-47fe-99ed-6dda536a1a69'
    $roleInstanceId = 'D11180COL0'

    try 
    {
        $actual = Restart-ACSRoleInstance `
        -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName `
        -RoleType TableServer `
        -InstanceId $roleInstanceId

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
Tests starting a role instance in cluster in a resource group with admin subscription id.
#>
function Test-StartRoleInstance
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '3c62b865-d397-47fe-99ed-6dda536a1a69'
    $roleInstanceId = 'D11180COL0'

    try 
    {
         $actual = Start-ACSBlobServerRoleInstance `
        -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName `
        -InstanceId $roleInstanceId

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
Tests stop a role instance in cluster in a resource group with admin subscription id.
#>
function Test-StopRoleInstance
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '3c62b865-d397-47fe-99ed-6dda536a1a69'
    $roleInstanceId = 'D11180COL0'

    try 
    {
         $actual = Stop-ACSBlobServerRoleInstance `
        -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName `
        -InstanceId $roleInstanceId

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
Tests role instance pipeline. Get a roleinstance, then restart it thru pipeline.
#>
function Test-RoleInstancePipeline
{
    # Setup
    $rgname = 'Default-Web-EastUS'
    $subscriptionId = 'a93fb07c-6c93-40be-bf3b-4f0deba10f4b'
    $farmName = '3c62b865-d397-47fe-99ed-6dda536a1a69'

    try 
    {
        $results = Get-ACSRoleInstance `
        -ResourceGroupName $rgname -SubscriptionId $subscriptionId -FarmName $farmName `
        -RoleType TableServer | Select-Object -First 1 | Restart-ACSRoleInstance
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}