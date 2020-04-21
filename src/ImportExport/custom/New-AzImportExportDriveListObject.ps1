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
Create a DriverList Object for ImportExport.
.Description
Create a DriverList Object for ImportExport.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatus
.Link
https://docs.microsoft.com/en-us/powershell/module/az.importexport/new-AzImportExportDriveListObject
#>
function New-AzImportExportDriveListObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(
        [Parameter(HelpMessage="The BitLocker key used to encrypt the drive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [string]
        ${BitLockerKey},
        [Parameter(HelpMessage="Bytes successfully transferred for the drive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [Int64]
        ${BytesSucceeded},
        [Parameter(HelpMessage="Detailed status about the data transfer process. This field is not returned in the response until the drive is in the Transferring state.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [string]
        ${CopyStatus},
        [Parameter(HelpMessage="The drive header hash value.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [string]
        ${DriveHeaderHash},
        [Parameter(HelpMessage="The drive's hardware serial number, without spaces.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [string]
        ${DriveId},
        [Parameter(HelpMessage="A URI that points to the blob containing the error log for the data transfer operation.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [string]
        ${ErrorLogUri},
        [Parameter(HelpMessage="The relative path of the manifest file on the drive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [string]
        ${ManifestFile},
        [Parameter(HelpMessage="The Base16-encoded MD5 hash of the manifest file on the drive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [string]
        ${ManifestHash},
        [Parameter(HelpMessage="A URI that points to the blob containing the drive manifest file.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [string]
        ${ManifestUri},
        [Parameter(HelpMessage="Percentage completed for the drive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [int]
        ${PercentComplete},
        [Parameter(HelpMessage="The drive's current state.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Support.DriveState]
        ${State},
        [Parameter(HelpMessage="A URI that points to the blob containing the verbose log for the data transfer operation.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
        [string]
        ${VerboseLogUri}
    )

    process {
        $DriveStatus = [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatus]::New()
        $DriveStatus.BitLockerKey = $BitLockerKey
        $DriveStatus.BytesSucceeded = $BytesSucceeded
        $DriveStatus.CopyStatus = $CopyStatus
        $DriveStatus.DriveHeaderHash = $DriveHeaderHash
        $DriveStatus.DriveId = $DriveId
        $DriveStatus.ErrorLogUri = $ErrorLogUri
        $DriveStatus.ManifestFile = $ManifestFile
        $DriveStatus.ManifestHash = $ManifestHash
        $DriveStatus.ManifestUri = $ManifestUri
        $DriveStatus.PercentComplete = $PercentComplete
        $DriveStatus.State = $State
        $DriveStatus.VerboseLogUri = $VerboseLogUri

        return $DriveStatus
    }
}