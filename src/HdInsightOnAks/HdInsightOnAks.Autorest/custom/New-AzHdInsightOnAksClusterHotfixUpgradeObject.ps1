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
.Synopsis
Create an object to hold the cluster upgrade parameters.
.Description
Create an object to hold the cluster upgrade parameters.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ClusterUpgrade
.Link
https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksClusterHotfixUpgradeObject
#>
function New-AzHdInsightOnAksClusterHotfixUpgradeObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterUpgrade])]
    [CmdletBinding(DefaultParameterSetName = 'Create', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'Create')]
        [System.String]
        # Name of component to be upgraded.
        ${ComponentName},

        [Parameter(ParameterSetName = 'Create')]
        [System.String]
        # Target build number of component to be upgraded.
        ${TargetBuildNumber},
        
        [Parameter(ParameterSetName = 'Create')]
        [System.String]
        # Target cluster version of component to be upgraded.
        ${TargetClusterVersion},

        [Parameter(ParameterSetName = 'Create')]
        [System.String]
        # Target OSS version of component to be upgraded.
        ${TargetOssVersion}
    )
    process {
        try {
            $hotfixProperty = New-Object Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ClusterHotfixUpgradeProperties -Property `
            @{ComponentName          = $ComponentName;
                TargetBuildNumber    = $TargetBuildNumber;
                TargetClusterVersion = $TargetClusterVersion;
                TargetOssVersion     = $TargetOssVersion;
            }

            $hotfixObject = New-Object Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ClusterUpgrade -Property `
            @{Property = $hotfixProperty }

            return $hotfixObject
        }
        catch {
            throw
        }
    }
}