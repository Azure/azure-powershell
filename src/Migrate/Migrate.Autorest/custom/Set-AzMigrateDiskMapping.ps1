
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
Updates disk mapping
.Description
The Set-AzMigrateDiskMapping cmdlet updates a mapping of the source disk attached to the server to be migrated
.Link
https://learn.microsoft.com/powershell/module/az.migrate/set-azmigratediskmapping
#>
function Set-AzMigrateDiskMapping {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.IVMwareCbtUpdateDiskInput])]
    [CmdletBinding(DefaultParameterSetName = 'VMwareCbt', PositionalBinding = $false)]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the disk ID of the disk attached to the discovered server to be migrated.
        ${DiskID},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the name of the managed disk to be created.
        ${DiskName},

        [Parameter()]
        [ValidateSet("true" , "false")]
        [ArgumentCompleter( { "true" , "false" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies whether the disk contains the Operating System for the source server to be migrated.
        ${IsOSDisk}
    )
    
    process {
        $DiskObject = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.VMwareCbtUpdateDiskInput]::new()
        $DiskObject.DiskId = $DiskID

        if ($DiskName -and (($DiskName.length -gt 80) -or ($DiskName.length -eq 0))) {
            throw "The disk name must be between 1 and 80 characters long."
        }

        if ($DiskName -and $DiskName -notmatch "^[^_\W][a-zA-Z0-9_\-\.]{0,79}(?<![-.])$") {
            throw "The disk name must begin with a letter or number, end with a letter, number or underscore, and may contain only letters, numbers, underscores, periods, or hyphens."
        }

        $DiskObject.TargetDiskName = $DiskName
        $DiskObject.IsOSDisk = $IsOSDisk

        return $DiskObject 
    }

}   