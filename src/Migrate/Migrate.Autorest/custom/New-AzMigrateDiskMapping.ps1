
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
The New-AzMigrateDiskMapping cmdlet creates a mapping of the source disk attached to the server to be migrated
.Link
https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratediskmapping
#>
function New-AzMigrateDiskMapping {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IVMwareCbtDiskInput])]
    [CmdletBinding(DefaultParameterSetName = 'VMwareCbt', PositionalBinding = $false)]
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
        [ValidateSet("Standard_LRS", "Premium_LRS", "StandardSSD_LRS", "PremiumV2_LRS")]
        [ArgumentCompleter( { "Standard_LRS", "Premium_LRS", "StandardSSD_LRS", "PremiumV2_LRS"})]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the type of disks to be used for the Azure VM.
        ${DiskType},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the disk encyption set to be used.
        ${DiskEncryptionSetID}
    )
    
    process {
        $DiskObject = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.VMwareCbtDiskInput]::new()
        $DiskObject.DiskId = $DiskID

        $validDiskTypeSpellings = @{ 
            Standard_LRS    = "Standard_LRS";
            Premium_LRS     = "Premium_LRS";
            StandardSSD_LRS = "StandardSSD_LRS";
            PremiumV2_LRS   = "PremiumV2_LRS";
        }
        $DiskObject.DiskType = $validDiskTypeSpellings[$DiskType]

        $validBooleanSpellings = @{ 
            true  = "true";
            false = "false"
        }
        $DiskObject.IsOSDisk = $validBooleanSpellings[$IsOSDisk]
        if ($PSBoundParameters.ContainsKey('DiskEncryptionSetID')) {
            $DiskObject.DiskEncryptionSetId = $DiskEncryptionSetID
        }

        if ($DiskObject.IsOSDisk -eq "true" -and $DiskObject.DiskType -eq $validDiskTypeSpellings["PremiumV2_LRS"]) {
            throw "Premium SSD V2 disk is not supported as an OS Disk in Azure."
        }

        return $DiskObject 
    }

}   