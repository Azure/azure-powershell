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
    Tests CRUD on disaster recovery configuration
#>
function Test-ServerDisasterRecoveryConfiguration
{
    Test-ServerDisasterRecoveryConfigurationInternal
}

<#
    .SYNOPSIS
    Tests creating 2 servers, a disaster recovery configuration, failing over, then deleting
#>
function Test-ServerDisasterRecoveryConfigurationInternal ($location1 = "North Europe", $location2 = "Southeast Asia")
{
    # Setup
    $rg1 = Create-ResourceGroupForTest $location1
    $rg2 = Create-ResourceGroupForTest $location2
    
    try
    {
        $server1 = Create-ServerForTest $rg1 "12.0" $location1
        $server2 = Create-ServerForTest $rg2 "12.0" $location2
        $failoverPolicy = "Off"
        $sdrcName = "test-sdrc-alias"

        # Create and validate
        #
        $sdrc = New-AzureRmSqlServerDisasterRecoveryConfiguration -ResourceGroupName $rg1.ResourceGroupName -ServerName $server1.ServerName -VirtualEndpointName $sdrcName -PartnerResourceGroupName $rg2.ResourceGroupName -PartnerServerName $server2.ServerName  

        GetSdrcCheck $rg1 $server1 $sdrcName $rg2 $server2 $failoverPolicy "Primary"
        GetSdrcCheck $rg2 $server2 $sdrcName $rg1 $server1 $failoverPolicy "Secondary"

        # Failover and check
        #
        Set-AzureRmSqlServerDisasterRecoveryConfiguration -ResourceGroupName $rg2.ResourceGroupName -ServerName $server2.ServerName -VirtualEndpointName $sdrcName -Failover

        GetSdrcCheck $rg2 $server2 $sdrcName $rg1 $server1 $failoverPolicy "Primary"
        GetSdrcCheck $rg1 $server1 $sdrcName $rg2 $server2 $failoverPolicy "Secondary"

        # Fail back and check
        #
        Set-AzureRmSqlServerDisasterRecoveryConfiguration -ResourceGroupName $rg1.ResourceGroupName -ServerName $server1.ServerName -VirtualEndpointName $sdrcName -Failover

        GetSdrcCheck $rg1 $server1 $sdrcName $rg2 $server2 $failoverPolicy "Primary"
        GetSdrcCheck $rg2 $server2 $sdrcName $rg1 $server1 $failoverPolicy "Secondary"

        # Delete
        #
        Remove-AzureRmSqlServerDisasterRecoveryConfiguration  -ResourceGroupName $rg1.ResourceGroupName -ServerName $server1.ServerName -VirtualEndpointName $sdrcName -Force
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
        Remove-ResourceGroupForTest $rg2
    }
}

function GetSdrcCheck ($resourceGroup, $server, $virtualEndpointName, $partnerResourceGroup, $partnerServer, $failoverPolicy, $role)
{
    $sdrcGet = Get-AzureRmSqlServerDisasterRecoveryConfiguration -ResourceGroupName $resourceGroup.ResourceGroupName -ServerName $server.ServerName -VirtualEndpointName $virtualEndpointName

    Assert-AreEqual $resourceGroup.ResourceGroupName $sdrcGet.ResourceGroupName
    Assert-AreEqual $server.ServerName $sdrcGet.ServerName
    Assert-AreEqual $virtualEndpointName $sdrcGet.VirtualEndpointName
    Assert-AreEqual $partnerServer.ServerName $sdrcGet.PartnerServerName
    Assert-AreEqual $failoverPolicy $sdrcGet.FailoverPolicy
    Assert-AreEqual $role $sdrcGet.Role
}