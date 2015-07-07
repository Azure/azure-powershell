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
Application gateway tests
#>
function Test-ApplicationGatewayCRUD
{
    # Setup	
    $rgname = "kagarg"        
	$vnetName = "kagavnet"
	$appGwName = "kagagw"
    $location = "NorthCentral US"
    
    try 
	{
		$vnet = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$subnet = Get-AzureVirtualNetworkSubnetConfig -Name "GatewaySubnet" -VirtualNetwork $vnet
		$appgw = Get-AzureApplicationGateway -ResourceGroupName $rgname -Name $appGwName		
	}
     finally
     {
        # Cleanup
        Clean-ResourceGroup $rgname
     }
}