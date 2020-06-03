
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
Returns the details about a location to which you can ship the disks associated with an import or export job.
A location is an Azure region.
.Description
Returns the details about a location to which you can ship the disks associated with an import or export job.
A location is an Azure region.
.Example
PS C:\> Get-AzImportExportLocation
Name                 Type
----                 ----
Australia East       Microsoft.ImportExport/locations
Australia Southeast  Microsoft.ImportExport/locations
Brazil South         Microsoft.ImportExport/locations
Canada Central       Microsoft.ImportExport/locations
Canada East          Microsoft.ImportExport/locations
...
West Central US      Microsoft.ImportExport/locations
West Europe          Microsoft.ImportExport/locations
West India           Microsoft.ImportExport/locations
West US              Microsoft.ImportExport/locations
West US 2            Microsoft.ImportExport/locations
.Example
PS C:\> Get-AzImportExportLocation -Name eastus
Name    Type
----    ----
East US Microsoft.ImportExport/locations
.Example
PS C:\> $Id = "/providers/Microsoft.ImportExport/locations/eastus"
PS C:\> Get-AzImportExportLocation -InputObject $Id
Name    Type
----    ----
East US Microsoft.ImportExport/locations

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IImportExportIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [JobName <String>]: The name of the import/export job.
  [LocationName <String>]: The name of the location. For example, West US or westus.
  [ResourceGroupName <String>]: The resource group name uniquely identifies the resource group within the user subscription.
  [SubscriptionId <String>]: The subscription ID for the Azure user.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.importexport/get-azimportexportlocation
#>
function Get-AzImportExportLocation {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ILocation])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('LocationName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [System.String]
    # The name of the location.
    # For example, West US or westus.
    ${Name},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Header')]
    [System.String]
    # Specifies the preferred language for the response.
    ${AcceptLanguage},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Az.ImportExport.private\Get-AzImportExportLocation_Get';
            GetViaIdentity = 'Az.ImportExport.private\Get-AzImportExportLocation_GetViaIdentity';
            List = 'Az.ImportExport.private\Get-AzImportExportLocation_List';
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
Gets information about an existing job.
.Description
Gets information about an existing job.
.Example
PS C:\> Get-AzImportExport
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
.Example
PS C:\> Get-AzImportExport -Name test-job -ResourceGroupName ImportTestRG
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
.Example
PS C:\> Get-AzImportExport -ResourceGroupName ImportTestRG
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
.Example
PS C:\> $Id = "/subscriptions/<SubscriptionId>/resourceGroups/ImportTestRG/providers/Microsoft.ImportExport/jobs/test-job"
PS C:\> Get-AzImportExport -InputObject $Id
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IImportExportIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [JobName <String>]: The name of the import/export job.
  [LocationName <String>]: The name of the location. For example, West US or westus.
  [ResourceGroupName <String>]: The resource group name uniquely identifies the resource group within the user subscription.
  [SubscriptionId <String>]: The subscription ID for the Azure user.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.importexport/get-azimportexport
#>
function Get-AzImportExport {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('JobName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [System.String]
    # The name of the import/export job.
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [System.String]
    # The resource group name uniquely identifies the resource group within the user subscription.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Parameter(ParameterSetName='List1')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription ID for the Azure user.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='List')]
    [Parameter(ParameterSetName='List1')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Query')]
    [System.String]
    # Can be used to restrict the results to certain conditions.
    ${Filter},

    [Parameter(ParameterSetName='List')]
    [Parameter(ParameterSetName='List1')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Query')]
    [System.Int32]
    # An integer value that specifies how many jobs at most should be returned.
    # The value cannot exceed 100.
    ${Top},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Header')]
    [System.String]
    # Specifies the preferred language for the response.
    ${AcceptLanguage},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Az.ImportExport.private\Get-AzImportExport_Get';
            GetViaIdentity = 'Az.ImportExport.private\Get-AzImportExport_GetViaIdentity';
            List = 'Az.ImportExport.private\Get-AzImportExport_List';
            List1 = 'Az.ImportExport.private\Get-AzImportExport_List1';
        }
        if (('Get', 'List', 'List1') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
Creates a new job or updates an existing job in the specified subscription.
.Description
Creates a new job or updates an existing job in the specified subscription.
.Example
PS C:\> $driveList = @( @{ DriveId = "9CA995BA"; BitLockerKey = "238810-662376-448998-450120-652806-203390-606320-483076"; ManifestFile = "\\DriveManifest.xml"; ManifestHash = "109B21108597EF36D5785F08303F3638"; DriveHeaderHash = "" })
PS C:\> New-AzImportExport -Name test-job -ResourceGroupName ImportTestRG -Location eastus -StorageAccountId "/subscriptions/<SubscriptionId>/resourcegroups/ImportTestRG/providers/Microsoft.Storage/storageAccounts/teststorageforimport" -JobType Import -ReturnAddressRecipientName "Some name" -ReturnAddressStreetAddress1 "Street1" -ReturnAddressCity "Redmond" -ReturnAddressStateOrProvince "WA" -ReturnAddressPostalCode "98008" -ReturnAddressCountryOrRegion "USA" -ReturnAddressPhone "4250000000" -ReturnAddressEmail test@contoso.com -DiagnosticsPath "waimportexport" -BackupDriveManifest -DriveList $driveList
Location Name     Type
-------- ----     ----
eastus   test-job Microsoft.ImportExport/jobs

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DRIVELIST <IDriveStatus[]>: List of up to ten drives that comprise the job. The drive list is a required element for an import job; it is not specified for export jobs.
  [BitLockerKey <String>]: The BitLocker key used to encrypt the drive.
  [BytesSucceeded <Int64?>]: Bytes successfully transferred for the drive.
  [CopyStatus <String>]: Detailed status about the data transfer process. This field is not returned in the response until the drive is in the Transferring state.
  [DriveHeaderHash <String>]: The drive header hash value.
  [DriveId <String>]: The drive's hardware serial number, without spaces.
  [ErrorLogUri <String>]: A URI that points to the blob containing the error log for the data transfer operation.
  [ManifestFile <String>]: The relative path of the manifest file on the drive. 
  [ManifestHash <String>]: The Base16-encoded MD5 hash of the manifest file on the drive.
  [ManifestUri <String>]: A URI that points to the blob containing the drive manifest file. 
  [PercentComplete <Int32?>]: Percentage completed for the drive. 
  [State <DriveState?>]: The drive's current state. 
  [VerboseLogUri <String>]: A URI that points to the blob containing the verbose log for the data transfer operation. 
.Link
https://docs.microsoft.com/en-us/powershell/module/az.importexport/new-azimportexport
#>
function New-AzImportExport {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('JobName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [System.String]
    # The name of the import/export job.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [System.String]
    # The resource group name uniquely identifies the resource group within the user subscription.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID for the Azure user.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Header')]
    [System.String]
    # Specifies the preferred language for the response.
    ${AcceptLanguage},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Header')]
    [System.String]
    # The tenant ID of the client making the request.
    ${ClientTenantId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Default value is false.
    # Indicates whether the manifest files on the drives should be copied to block blobs.
    ${BackupDriveManifest},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String[]]
    # A collection of blob-path strings.
    ${BlobListBlobPath},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String[]]
    # A collection of blob-prefix strings.
    ${BlobListBlobPathPrefix},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Indicates whether a request has been submitted to cancel the job.
    ${CancelRequested},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The name of the carrier that is used to ship the import or export drives.
    ${DeliveryPackageCarrierName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.Int32]
    # The number of drives included in the package.
    ${DeliveryPackageDriveCount},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The date when the package is shipped.
    ${DeliveryPackageShipDate},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The tracking number of the package.
    ${DeliveryPackageTrackingNumber},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The virtual blob directory to which the copy logs and backups of drive manifest files (if enabled) will be stored.
    ${DiagnosticsPath},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[]]
    # List of up to ten drives that comprise the job.
    # The drive list is a required element for an import job; it is not specified for export jobs.
    # To construct, see NOTES section for DRIVELIST properties and create a hash table.
    ${DriveList},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The relative URI to the block blob that contains the list of blob paths or blob path prefixes as defined above, beginning with the container name.
    # If the blob is in root container, the URI must begin with $root.
    ${ExportBlobListblobPath},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # A blob path that points to a block blob containing a list of blob names that were not exported due to insufficient drive space.
    # If all blobs were exported successfully, then this element is not included in the response.
    ${IncompleteBlobListUri},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The type of job
    ${JobType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # Specifies the supported Azure location where the job should be created
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # Default value is Error.
    # Indicates whether error logging or verbose logging will be enabled.
    ${LogLevel},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.Int32]
    # Overall percentage completed for the job.
    ${PercentComplete},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # Specifies the provisioning state of the job.
    ${ProvisioningState},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The city name to use when returning the drives.
    ${ReturnAddressCity},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The country or region to use when returning the drives.
    ${ReturnAddressCountryOrRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # Email address of the recipient of the returned drives.
    ${ReturnAddressEmail},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # Phone number of the recipient of the returned drives.
    ${ReturnAddressPhone},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The postal code to use when returning the drives.
    ${ReturnAddressPostalCode},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The name of the recipient who will receive the hard drives when they are returned.
    ${ReturnAddressRecipientName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The state or province to use when returning the drives.
    ${ReturnAddressStateOrProvince},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The first line of the street address to use when returning the drives.
    ${ReturnAddressStreetAddress1},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The second line of the street address to use when returning the drives.
    ${ReturnAddressStreetAddress2},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The name of the carrier that is used to ship the import or export drives.
    ${ReturnPackageCarrierName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.Int32]
    # The number of drives included in the package.
    ${ReturnPackageDriveCount},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The date when the package is shipped.
    ${ReturnPackageShipDate},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The tracking number of the package.
    ${ReturnPackageTrackingNumber},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The customer's account number with the carrier.
    ${ReturnShippingCarrierAccountNumber},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The carrier's name.
    ${ReturnShippingCarrierName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The city name to use when returning the drives.
    ${ShippingInformationCity},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The country or region to use when returning the drives.
    ${ShippingInformationCountryOrRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # Phone number of the recipient of the returned drives.
    ${ShippingInformationPhone},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The postal code to use when returning the drives.
    ${ShippingInformationPostalCode},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The name of the recipient who will receive the hard drives when they are returned.
    ${ShippingInformationRecipientName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The state or province to use when returning the drives.
    ${ShippingInformationStateOrProvince},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The first line of the street address to use when returning the drives.
    ${ShippingInformationStreetAddress1},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The second line of the street address to use when returning the drives.
    ${ShippingInformationStreetAddress2},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # Current state of the job.
    ${State},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The resource identifier of the storage account where data will be imported to or exported from.
    ${StorageAccountId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IPutJobParametersTags]
    # Specifies the tags that will be assigned to the job.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            CreateExpanded = 'Az.ImportExport.private\New-AzImportExport_CreateExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
Deletes an existing job.
Only jobs in the Creating or Completed states can be deleted.
.Description
Deletes an existing job.
Only jobs in the Creating or Completed states can be deleted.
.Example
PS C:\> Remove-AzImportExport -Name test-job -ResourceGroupName ImportTestRG
.Example
PS C:\> Get-AzImportExport -Name test-job -ResourceGroupName ImportTestRG | Remove-AzImportExport
 

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IImportExportIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [JobName <String>]: The name of the import/export job.
  [LocationName <String>]: The name of the location. For example, West US or westus.
  [ResourceGroupName <String>]: The resource group name uniquely identifies the resource group within the user subscription.
  [SubscriptionId <String>]: The subscription ID for the Azure user.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.importexport/remove-azimportexport
#>
function Remove-AzImportExport {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Alias('JobName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [System.String]
    # The name of the import/export job.
    ${Name},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [System.String]
    # The resource group name uniquely identifies the resource group within the user subscription.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID for the Azure user.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Header')]
    [System.String]
    # Specifies the preferred language for the response.
    ${AcceptLanguage},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Delete = 'Az.ImportExport.private\Remove-AzImportExport_Delete';
            DeleteViaIdentity = 'Az.ImportExport.private\Remove-AzImportExport_DeleteViaIdentity';
        }
        if (('Delete') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
Updates specific properties of a job.
You can call this operation to notify the Import/Export service that the hard drives comprising the import or export job have been shipped to the Microsoft data center.
It can also be used to cancel an existing job.
.Description
Updates specific properties of a job.
You can call this operation to notify the Import/Export service that the hard drives comprising the import or export job have been shipped to the Microsoft data center.
It can also be used to cancel an existing job.
.Example
PS C:\> Update-AzImportExport -Name test-job -ResourceGroupName ImportTestRG -DeliveryPackageCarrierName pwsh -DeliveryPackageTrackingNumber pwsh20200000
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
.Example
PS C:\> Get-AzImportExport -Name test-job -ResourceGroupName ImportTestRG | Update-AzImportExport -CancelRequested
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DRIVELIST <IDriveStatus[]>: List of drives that comprise the job.
  [BitLockerKey <String>]: The BitLocker key used to encrypt the drive.
  [BytesSucceeded <Int64?>]: Bytes successfully transferred for the drive.
  [CopyStatus <String>]: Detailed status about the data transfer process. This field is not returned in the response until the drive is in the Transferring state.
  [DriveHeaderHash <String>]: The drive header hash value.
  [DriveId <String>]: The drive's hardware serial number, without spaces.
  [ErrorLogUri <String>]: A URI that points to the blob containing the error log for the data transfer operation.
  [ManifestFile <String>]: The relative path of the manifest file on the drive. 
  [ManifestHash <String>]: The Base16-encoded MD5 hash of the manifest file on the drive.
  [ManifestUri <String>]: A URI that points to the blob containing the drive manifest file. 
  [PercentComplete <Int32?>]: Percentage completed for the drive. 
  [State <DriveState?>]: The drive's current state. 
  [VerboseLogUri <String>]: A URI that points to the blob containing the verbose log for the data transfer operation. 

INPUTOBJECT <IImportExportIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [JobName <String>]: The name of the import/export job.
  [LocationName <String>]: The name of the location. For example, West US or westus.
  [ResourceGroupName <String>]: The resource group name uniquely identifies the resource group within the user subscription.
  [SubscriptionId <String>]: The subscription ID for the Azure user.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.importexport/update-azimportexport
#>
function Update-AzImportExport {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IJobResponse])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('JobName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [System.String]
    # The name of the import/export job.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [System.String]
    # The resource group name uniquely identifies the resource group within the user subscription.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID for the Azure user.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Header')]
    [System.String]
    # Specifies the preferred language for the response.
    ${AcceptLanguage},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Indicates whether the manifest files on the drives should be copied to block blobs.
    ${BackupDriveManifest},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # If specified, the value must be true.
    # The service will attempt to cancel the job.
    ${CancelRequested},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The name of the carrier that is used to ship the import or export drives.
    ${DeliveryPackageCarrierName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.Int32]
    # The number of drives included in the package.
    ${DeliveryPackageDriveCount},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The date when the package is shipped.
    ${DeliveryPackageShipDate},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The tracking number of the package.
    ${DeliveryPackageTrackingNumber},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus[]]
    # List of drives that comprise the job.
    # To construct, see NOTES section for DRIVELIST properties and create a hash table.
    ${DriveList},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # Indicates whether error logging or verbose logging is enabled.
    ${LogLevel},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The city name to use when returning the drives.
    ${ReturnAddressCity},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The country or region to use when returning the drives.
    ${ReturnAddressCountryOrRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # Email address of the recipient of the returned drives.
    ${ReturnAddressEmail},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # Phone number of the recipient of the returned drives.
    ${ReturnAddressPhone},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The postal code to use when returning the drives.
    ${ReturnAddressPostalCode},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The name of the recipient who will receive the hard drives when they are returned.
    ${ReturnAddressRecipientName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The state or province to use when returning the drives.
    ${ReturnAddressStateOrProvince},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The first line of the street address to use when returning the drives.
    ${ReturnAddressStreetAddress1},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The second line of the street address to use when returning the drives.
    ${ReturnAddressStreetAddress2},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The customer's account number with the carrier.
    ${ReturnShippingCarrierAccountNumber},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # The carrier's name.
    ${ReturnShippingCarrierName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [System.String]
    # If specified, the value must be Shipping, which tells the Import/Export service that the package for the job has been shipped.
    # The ReturnAddress and DeliveryPackage properties must have been set either in this request or in a previous request, otherwise the request will fail.
    ${State},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IUpdateJobParametersTags]
    # Specifies the tags that will be assigned to the job
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            UpdateExpanded = 'Az.ImportExport.private\Update-AzImportExport_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.ImportExport.private\Update-AzImportExport_UpdateViaIdentityExpanded';
        }
        if (('UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
Returns the BitLocker Keys for all drives in the specified job.
.Description
Returns the BitLocker Keys for all drives in the specified job.
.Example
PS C:\> Get-AzImportExportBitLockerKey -JobName test-job -ResourceGroupName ImportTestRG 
BitLockerKey                                            DriveId
------------                                            -------
238810-662376-448998-450120-652806-203390-606320-483076 9CA995BA

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveBitLockerKey
.Link
https://docs.microsoft.com/en-us/powershell/module/az.importexport/get-azimportexportbitlockerkey
#>
function Get-AzImportExportBitLockerKey {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveBitLockerKey])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [System.String]
    # The name of the import/export job.
    ${JobName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [System.String]
    # The resource group name uniquely identifies the resource group within the user subscription.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription ID for the Azure user.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Header')]
    [System.String]
    # Specifies the preferred language for the response.
    ${AcceptLanguage},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            List = 'Az.ImportExport.custom\Get-AzImportExportBitLockerKey';
        }
        if (('List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
