
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
Expands and Lists MSIX packages in an Image, given the Image Path.
.Description
Expands and Lists MSIX packages in an Image, given the Image Path.
.Example
PS C:\> Expand-AzWvdMsixImage -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -SubscriptionId SubscriptionId `
          -Uri ImagePathURI

Name                          Type
----                          ----
HostPoolName/extractmsiximage Microsoft.DesktopVirtualization/hostpools/extractmsiximage

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixImageUri
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IExpandMsixImage
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IDesktopVirtualizationIdentity>: Identity Parameter
  [ApplicationGroupName <String>]: The name of the application group
  [ApplicationName <String>]: The name of the application within the specified application group
  [DesktopName <String>]: The name of the desktop within the specified desktop group
  [HostPoolName <String>]: The name of the host pool within the specified resource group
  [Id <String>]: Resource identity path
  [MsixPackageFullName <String>]: The version specific package full name of the MSIX package within specified hostpool
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [SessionHostName <String>]: The name of the session host within the specified host pool
  [SubscriptionId <String>]: The ID of the target subscription.
  [UserSessionId <String>]: The name of the user session within the specified session host
  [WorkspaceName <String>]: The name of the workspace

MSIXIMAGEURI <IMsixImageUri>: Represents URI referring to MSIX Image
  [Uri <String>]: URI to Image
.Link
https://docs.microsoft.com/en-us/powershell/module/az.desktopvirtualization/expand-azwvdmsiximage
#>
function Expand-AzWvdMsixImage {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IExpandMsixImage])]
[CmdletBinding(DefaultParameterSetName='ExpandExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Expand', Mandatory)]
    [Parameter(ParameterSetName='ExpandExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
    [System.String]
    # The name of the host pool within the specified resource group
    ${HostPoolName},

    [Parameter(ParameterSetName='Expand', Mandatory)]
    [Parameter(ParameterSetName='ExpandExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Expand')]
    [Parameter(ParameterSetName='ExpandExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ExpandViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='ExpandViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Expand', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='ExpandViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixImageUri]
    # Represents URI referring to MSIX Image
    # To construct, see NOTES section for MSIXIMAGEURI properties and create a hash table.
    ${MsixImageUri},

    [Parameter(ParameterSetName='ExpandExpanded')]
    [Parameter(ParameterSetName='ExpandViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Body')]
    [System.String]
    # URI to Image
    ${Uri},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
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
            Expand = 'Az.DesktopVirtualization.private\Expand-AzWvdMsixImage_Expand';
            ExpandExpanded = 'Az.DesktopVirtualization.private\Expand-AzWvdMsixImage_ExpandExpanded';
            ExpandViaIdentity = 'Az.DesktopVirtualization.private\Expand-AzWvdMsixImage_ExpandViaIdentity';
            ExpandViaIdentityExpanded = 'Az.DesktopVirtualization.private\Expand-AzWvdMsixImage_ExpandViaIdentityExpanded';
        }
        if (('Expand', 'ExpandExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
