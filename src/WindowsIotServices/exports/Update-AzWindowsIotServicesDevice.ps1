
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
Updates the metadata of a Windows IoT Device Service.
The usual pattern to modify a property is to retrieve the Windows IoT Device Service metadata and security metadata, and then combine them with the modified values in a new body to update the Windows IoT Device Service.
.Description
Updates the metadata of a Windows IoT Device Service.
The usual pattern to modify a property is to retrieve the Windows IoT Device Service metadata and security metadata, and then combine them with the modified values in a new body to update the Windows IoT Device Service.
.Example
PS C:\> Update-AzWindowsIotServicesDevice -Name wsi-t03 -ResourceGroupName azure-rg-test -Quantity 10

Location Name    Type                                Etag
-------- ----    ----                                ----
eastus   wsi-t03 Microsoft.WindowsIoT/DeviceServices "5d006a5c-0000-0700-0000-5faa46760000"
.Example
PS C:\> Get-AzWindowsIotServicesDevice -Name wsi-t03 -ResourceGroupName azure-rg-test | Update-AzWindowsIotServicesDevice-Quantity 100 -Tag @{'oper'='update'}

Location Name    Type                                Etag
-------- ----    ----                                ----
West US  wsi-t01 Microsoft.WindowsIoT/DeviceServices "5d005f5f-0000-0700-0000-5faa46ae0000"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.IWindowsIotServicesIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceService
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IWindowsIotServicesIdentity>: Identity Parameter
  [DeviceName <String>]: The name of the Windows IoT Device Service.
  [Id <String>]: Resource identity path
  [ResourceGroupName <String>]: The name of the resource group that contains the Windows IoT Device Service.
  [SubscriptionId <String>]: The subscription identifier.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.windowsiotservices/update-azwindowsiotservicesdevice
#>
function Update-AzWindowsIotServicesDevice {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceService])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Path')]
    [System.String]
    # The name of the Windows IoT Device Service.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Path')]
    [System.String]
    # The name of the resource group that contains the Windows IoT Device Service.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription identifier.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.IWindowsIotServicesIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Header')]
    [System.String]
    # ETag of the Windows IoT Device Service.
    # Do not specify for creating a brand new Windows IoT Device Service.
    # Required to update an existing Windows IoT Device Service.
    ${IfMatch},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Body')]
    [System.String]
    # Windows IoT Device Service OEM AAD domain
    ${AdminDomainName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Body')]
    [System.String]
    # Windows IoT Device Service ODM AAD domain
    ${BillingDomainName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Body')]
    [System.String]
    # The Etag field is *not* required.
    # If it is provided in the response body, it must also be provided as a header per the normal ETag convention.
    ${Etag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Body')]
    [System.String]
    # The Azure Region where the resource lives
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Body')]
    [System.String]
    # Windows IoT Device Service notes.
    ${Note},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Body')]
    [System.Int64]
    # Windows IoT Device Service device allocation,
    ${Quantity},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Category('Runtime')]
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
            UpdateExpanded = 'Az.WindowsIotServices.private\Update-AzWindowsIotServicesDevice_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.WindowsIotServices.private\Update-AzWindowsIotServicesDevice_UpdateViaIdentityExpanded';
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
