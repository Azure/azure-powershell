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

$ErrorActionPreference = "Stop"

$ProfileNamePrefix = "onesdk";

#TODO: Make the domain name suffix environment dependent
$TrafficManagerDomain = ".trafficmanager.net";

<#
.SYNOPSIS
Gets valid profile name.
#>
function Get-ProfileName
{
    $name = getAssetName
    Write-Debug "Using profile with name: $name"
    return $name
}

<#
.SYNOPSIS
Creates a profile.
#>
function New-Profile
{
    param([string] $profileName)

    #TODO: Make the domain name suffix environment dependent
    $domainName = $profileName  + $TrafficManagerDomain

    New-AzureTrafficManagerProfile -Name $profileName -DomainName $domainName -LoadBalancingMethod RoundRobin -MonitorPort 80 -MonitorProtocol Http -MonitorRelativePath "/" -Ttl 300
}

<#
.SYNOPSIS
Removes all profiles from the $profileNames list from the current subscription.
#>
function Initialize-TrafficManagerTest
{
    Get-AzureTrafficManagerProfile | Where-Object { $_.Name.StartsWith($ProfileNamePrefix) } | Remove-AzureTrafficManagerProfile -Force
}
