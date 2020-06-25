
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
.Example
PS C:\> New-AzImportExportDriveListObject -DriveId "9CA995BA" -BitLockerKey "238810-662376-448998-450120-652806-203390-606320-483076" -ManifestFile "\\DriveManifest.xml" -ManifestHash "109B21108597EF36D5785F08303F3638"

BitLockerKey                                            BytesSucceeded CopyStatus DriveHeaderHash DriveId  ErrorLogUri ManifestFile        ManifestHash                     ManifestUri PercentComplete State VerboseLogUri  
------------                                            -------------- ---------- --------------- -------  ----------- ------------        ------------                     ----------- --------------- ----- ------- 
238810-662376-448998-450120-652806-203390-606320-483076 0                                         9CA995BA             \\DriveManifest.xml 109B21108597EF36D5785F08303F3638             0

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus
.Link
https://docs.microsoft.com/en-us/powershell/module/az.importexport/new-AzImportExportDriveListObject
#>
function New-AzImportExportDriveListObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The BitLocker key used to encrypt the drive.
    ${BitLockerKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.Int64]
    # Bytes successfully transferred for the drive.
    ${BytesSucceeded},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # Detailed status about the data transfer process.
    # This field is not returned in the response until the drive is in the Transferring state.
    ${CopyStatus},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The drive header hash value.
    ${DriveHeaderHash},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The drive's hardware serial number, without spaces.
    ${DriveId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # A URI that points to the blob containing the error log for the data transfer operation.
    ${ErrorLogUri},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The relative path of the manifest file on the drive.
    ${ManifestFile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The Base16-encoded MD5 hash of the manifest file on the drive.
    ${ManifestHash},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # A URI that points to the blob containing the drive manifest file.
    ${ManifestUri},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.Int32]
    # Percentage completed for the drive.
    ${PercentComplete},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Support.DriveState]
    # The drive's current state.
    ${State},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # A URI that points to the blob containing the verbose log for the data transfer operation.
    ${VerboseLogUri}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.ImportExport.custom\New-AzImportExportDriveListObject';
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
