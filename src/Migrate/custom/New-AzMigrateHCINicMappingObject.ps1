
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
Creates an object to update NIC properties of a replicating server.
.Description
The New-AzMigrateHCINicMappingObject cmdlet creates a mapping of the source NIC attached to the server to be migrated. This object is provided as an input to the Set-AzMigrateServerReplication cmdlet to update the NIC and its properties for a replicating server.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratehcinicmappingobject
#>
function New-AzMigrateHCINicMappingObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.AzStackHCINicInput])]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the ID of the NIC to be updated.
        ${NicID},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the logical network ARM ID that the VMs will use.
        ${TargetVirtualSwitchId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the test logical network ARM ID that the VMs will use.
        ${TargetTestVirtualSwitchId},

        [Parameter()]
        [ValidateSet("true" , "false")]
        [ArgumentCompleter( { "true" , "false" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies whether the this Nic should be created at target.
        ${CreateAtTarget} = "true"
    )
    
    process {
        if (!$PSBoundParameters.ContainsKey('TargetTestVirtualSwitchId')) {
            $TargetTestVirtualSwitchId = $TargetVirtualSwitchId
        }

        $selectionTypeForFailover = if ($CreateAtTarget -eq "true") { "SelectedByUser" } else { "NotSelected" }

        $NicObject = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.AzStackHCINicInput]::new(
            $NicID,
            $TargetVirtualSwitchId,
            $TargetTestVirtualSwitchId,
            $selectionTypeForFailover
        )
        
        return $NicObject
    }
} 