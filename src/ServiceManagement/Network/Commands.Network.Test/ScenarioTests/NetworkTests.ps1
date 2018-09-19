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

$VirtualNetworkName = "VirtualNetworkSiteName"
$SubnetName = "FrontEndSubnet"
$locations = Get-AzureLocation
#$Location = $locations[0].Name
$Location = "usnorth"
$ResourcePrefix = "onesdk";

<#
.SYNOPSIS
Initialize the networking tests by setting an empty NETCFG.
#>
function Initialize-NetworkTest
{
    Get-AzureService | Where-Object { $_.Name.StartsWith($ResourcePrefix) } | Remove-AzureService -DeleteAll -Force
    Set-AzureVNetConfig ($(Get-Location).Path +  "\TestData\EmptyNetworkConfiguration.xml")
}
