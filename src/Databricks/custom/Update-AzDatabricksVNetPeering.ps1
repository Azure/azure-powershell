
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
Update vNet Peering for workspace.
.Description
Update vNet Peering for workspace.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20230201.IVirtualNetworkPeering
.Link
https://learn.microsoft.com/powershell/module/az.databricks/update-azdatabricksvnetpeering
#>
function Update-AzDatabricksVNetPeering {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20230201.IVirtualNetworkPeering])]
    [CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory, HelpMessage = "The name of the VNetPeering.")]
        [Alias('PeeringName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
        [System.String]
        # The name of the workspace vNet peering.
        ${Name},
    
        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory, HelpMessage = "The name of the workspace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
        [System.String]
        # The name of the workspace.
        ${WorkspaceName},
    
        [Parameter(ParameterSetName = 'UpdateExpanded', HelpMessage = "The ID of the target subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline, HelpMessage = "Identity parameter. To construct, see NOTES section for INPUTOBJECT properties and create a hash table.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IDatabricksIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        # [System.Management.Automation.SwitchParameter]
        [System.Boolean]
        # Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
        ${AllowForwardedTraffic},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.Boolean]
        # [System.Management.Automation.SwitchParameter]
        # If gateway links can be used in remote virtual networking to link to this virtual network.
        ${AllowGatewayTransit},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.Boolean]
        # [System.Management.Automation.SwitchParameter]
        # Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
        ${AllowVirtualNetworkAccess},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Category('Body')]
        [System.Boolean]
        # [System.Management.Automation.SwitchParameter]
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
    
    process {
        try {
            # 1.Get
            $hasAllowForwardedTraffic = $PSBoundParameters.Remove('AllowForwardedTraffic')
            $hasAllowGatewayTransit = $PSBoundParameters.Remove('AllowGatewayTransit')
            $hasAllowVirtualNetworkAccess = $PSBoundParameters.Remove('AllowVirtualNetworkAccess')
            $hasUseRemoteGateway = $PSBoundParameters.Remove('UseRemoteGateway')
            $hasAsJob = $PSBoundParameters.Remove('AsJob')
            $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')

            $vnetPeering = Get-AzDatabricksVNetPeering @PSBoundParameters
            # 2. PUT
            $null = $PSBoundParameters.Remove('InputObject')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('Name')
            $null = $PSBoundParameters.Remove('WorkspaceName')
            $null = $PSBoundParameters.Remove('SubscriptionId')
            
            if ($hasAllowForwardedTraffic) {
                $vnetPeering.AllowForwardedTraffic = $AllowForwardedTraffic
            }
            if ($hasAllowGatewayTransit) {
                $vnetPeering.AllowGatewayTransit = $AllowGatewayTransit
            }
            if ($hasAllowVirtualNetworkAccess) {
                $vnetPeering.AllowVirtualNetworkAccess = $AllowVirtualNetworkAccess
            }
            if ($hasUseRemoteGateway) {
                $vnetPeering.UseRemoteGateway = $UseRemoteGateway
            }
            if ($hasAsJob) {
                $PSBoundParameters.Add('AsJob', $true)
            }

            if ($PSCmdlet.ShouldProcess("Databricks vnet peering $($vnetPeering.Name)", "Update")) {
                Az.Databricks.private\New-AzDatabricksVNetPeering_CreateViaIdentity -InputObject $vnetPeering -VirtualNetworkPeeringParameter $vnetPeering @PSBoundParameters
            }
        } catch {
            throw
        }
    }
}
    