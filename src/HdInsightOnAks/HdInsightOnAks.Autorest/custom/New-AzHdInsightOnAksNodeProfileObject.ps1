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
Create a node profile with SKU and worker count.
.Description
Create a node profile with SKU and worker count.
.Example
$vmSize="Standard_E8ads_v5";
$workerCount=5;
$nodeProfile = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count $workerCount -VMSize $vmSize
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.INodeProfile
.Link
https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksNodeProfileObject
#>
function New-AzHdInsightOnAksNodeProfileObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.INodeProfile])]
    [CmdletBinding(DefaultParameterSetName = 'Create', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [System.String]
        [ValidateSet("Head", "Worker")]
        # The node type.
        ${Type},

        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [System.Int32]
        # The virtual machine SKU.
        ${Count},
        
        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [System.String]
        # The number of virtual machines.
        ${VMSize}
    )
    process {
        try {
            $nodeProfile = New-Object Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.NodeProfile -Property `
            @{Type     = $Type;
                Count  = $Count;
                VMSize = $VMSize
            }
            return $nodeProfile
        }
        catch {
            throw
        }
    }
}