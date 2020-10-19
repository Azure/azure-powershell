
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
Creates vNet Peering for workspace.
.Description
Creates vNet Peering for workspace.
.Example
PS C:\> New-AzDatabricksVNetPeering -Name vnetpeering-t01 -WorkspaceName databricks-test01 -ResourceGroupName lucas-manual-test -RemoteVirtualNetworkId '/subscriptions/xxxxxx-xxxx-xxx-xxx/resourceGroups/azure-manual-test/providers/Microsoft.Network/virtualNetworks/vnet-test01'

Name            Type
----            ----
vnetpeering-t01

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeering
.Link
https://docs.microsoft.com/en-us/powershell/module/az.databricks/new-azdatabricksvnetpeering
#>
function New-AzDatabricksVNetPeering {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeering])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
    [System.String]
    # The name of the workspace vNet peering.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
    [System.String]
    # The name of the workspace.
    ${WorkspaceName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
    ${AllowForwardedTraffic},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # If gateway links can be used in remote virtual networking to link to this virtual network.
    ${AllowGatewayTransit},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
    ${AllowVirtualNetworkAccess},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String[]]
    # A list of address blocks reserved for this virtual network in CIDR notation.
    ${DatabricksAddressSpacePrefix},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The Id of the databricks virtual network.
    ${DatabricksVirtualNetworkId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String[]]
    # A list of address blocks reserved for this virtual network in CIDR notation.
    ${RemoteAddressSpacePrefix},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.String]
    # The Id of the remote virtual network.
    ${RemoteVirtualNetworkId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # If remote gateways can be used on this virtual network.
    # If the flag is set to true, and allowGatewayTransit on remote peering is also true, virtual network will use gateways of remote virtual network for transit.
    # Only one peering can have this flag set to true.
    # This flag cannot be set if virtual network already has a gateway.
    ${UseRemoteGateway},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Runtime')]
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
            CreateExpanded = 'Az.Databricks.private\New-AzDatabricksVNetPeering_CreateExpanded';
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
