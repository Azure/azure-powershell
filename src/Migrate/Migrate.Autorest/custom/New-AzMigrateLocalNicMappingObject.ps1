
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
The New-AzMigrateLocalNicMappingObject cmdlet creates a mapping of the source NIC attached to the server to be migrated. This object is provided as an input to the Set-AzMigrateServerReplication cmdlet to update the NIC and its properties for a replicating server.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratelocalnicmappingobject
#>
function New-AzMigrateLocalNicMappingObject {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PreviewMessageAttribute("This cmdlet is using a preview API version and is subject to breaking change in a future release.")]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.AzLocalNicInput])]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the ID of the NIC to be updated.
        ${NicID},

        [Parameter()]
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
        # Specifies whether this Nic should be created at target.
        ${CreateAtTarget} = "true"
    )
    
    process {
        if ($CreateAtTarget -eq "true") {
            if (!$PSBoundParameters.ContainsKey('TargetVirtualSwitchId') -or
                [string]::IsNullOrEmpty($TargetVirtualSwitchId)) {
                throw "The TargetVirtualSwitchId parameter is required when the CreateAtTarget flag is set to 'true'."
            }

            if (!$PSBoundParameters.ContainsKey('TargetTestVirtualSwitchId')) {
                $TargetTestVirtualSwitchId = $TargetVirtualSwitchId
            }

            $selectionTypeForFailover = $VMNicSelection.SelectedByUser
        }
        else {
            $selectionTypeForFailover = $VMNicSelection.NotSelected
        }

        $NicObject = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.AzLocalNicInput]::new(
            $NicID,
            $TargetVirtualSwitchId,
            $TargetTestVirtualSwitchId,
            $selectionTypeForFailover
        )
        
        return $NicObject
    }
} 