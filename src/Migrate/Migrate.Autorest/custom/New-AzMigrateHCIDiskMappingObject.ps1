
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
Creates a new disk mapping
.Description
The New-AzMigrateHCIDiskMappingObject cmdlet creates a mapping of the source disk attached to the server to be migrated
.Link
https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratehcidiskmappingobject
#>
function New-AzMigrateHCIDiskMappingObject {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PreviewMessageAttribute("This cmdlet is using a preview API version and is subject to breaking change in a future release.")]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.AzStackHCIDiskInput])]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the disk ID of the disk attached to the discovered server to be migrated.
        ${DiskID},
        
        [Parameter(Mandatory)]
        [ValidateSet("true" , "false")]
        [ArgumentCompleter( { "true" , "false" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies whether the disk contains the Operating System for the source server to be migrated.
        ${IsOSDisk},

        [Parameter(Mandatory)]
        [ValidateSet("true" , "false")]
        [ArgumentCompleter( { "true" , "false" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies whether the disk is dynamic.
        ${IsDynamic},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Int64]
        # Specifies the disk size in GB.
        ${Size},

        [Parameter(Mandatory)]
        [ValidateSet("VHD", "VHDX")]
        [ArgumentCompleter( { "VHD", "VHDX" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the disk format.
        ${Format},

        [Parameter()]
        [ValidateSet("512", "4096")]
        [ArgumentCompleter( { "512", "4096" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Int64]
        # Specifies the disk physical sector size in bytes.
        ${PhysicalSectorSize},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [string]
        # Specifies the storage path ARM ID where the disk will be stored.
        ${TargetStoragePathId}
    )
    
    process {
        $isDynamicDisk = [System.Convert]::ToBoolean($IsDynamic)
        $osDisk = [System.Convert]::ToBoolean($IsOSDisk)

        $DiskObject = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.AzStackHCIDiskInput]::new(
            $DiskID, 
            $isDynamicDisk, 
            $Size, 
            $Format, 
            $osDisk,
            $PhysicalSectorSize,
            $TargetStoragePathId
        )

        return $DiskObject 
    }
}   