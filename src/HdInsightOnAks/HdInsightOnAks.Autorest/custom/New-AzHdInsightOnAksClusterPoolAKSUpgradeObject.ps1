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
Create an object to hold the cluster pool upgrade parameters.
.Description
Create an object to hold the cluster pool upgrade parameters.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ClusterPoolUpgrade
.Link
https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksClusterPoolAKSUpgradeObject
#>
function New-AzHdInsightOnAksClusterPoolAKSUpgradeObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgrade])]
    [CmdletBinding(DefaultParameterSetName = 'Create', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'Create')]
        [System.String]
        # Target AKS version. When it's not set, latest version will be used. When upgradeClusterPool is true and upgradeAllClusterNodes is false, target version should be greater or equal to current version. When upgradeClusterPool is false and upgradeAllClusterNodes is true, target version should be equal to AKS version of cluster pool.
        ${TargetAksVersion},

        [Parameter(ParameterSetName = 'Create')]
        [System.String]
        # whether upgrade all clusters' nodes. If it's true, upgradeClusterPool should be false.
        ${UpgradeAllClusterNode},
        
        [Parameter(ParameterSetName = 'Create')]
        [System.String]
        # whether upgrade cluster pool or not. If it's true, upgradeAllClusterNodes should be false.
        ${UpgradeClusterPool}
    )
    process {
        try {
            $aksPatchProperty = New-Object Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ClusterPoolAksPatchVersionUpgradeProperties -Property `
            @{TargetAksVersion        = $TargetAksVersion;
                UpgradeAllClusterNode = $UpgradeAllClusterNode;
                UpgradeClusterPool    = $UpgradeClusterPool;
            }

            $AKSPatchatchObject = New-Object Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ClusterPoolUpgrade -Property `
            @{Property = $aksPatchProperty }

            return $AKSPatchatchObject
        }
        catch {
            throw
        }
    }
}