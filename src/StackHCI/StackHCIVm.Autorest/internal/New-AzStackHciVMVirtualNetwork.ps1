
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
The operation to create or update a virtual network.
Please note some properties can be set only during virtual network creation.
.Description
The operation to create or update a virtual network.
Please note some properties can be set only during virtual network creation.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworks
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

SUBNET <IVirtualNetworkPropertiesSubnetsItem[]>: Subnet - list of subnets under the virtual network
  [AddressPrefix <String>]: Cidr for this subnet - IPv4, IPv6
  [AddressPrefixes <String[]>]: AddressPrefixes - List of address prefixes for the subnet.
  [IPAllocationMethod <IPAllocationMethodEnum?>]: IPAllocationMethod - The IP address allocation method. Possible values include: 'Static', 'Dynamic'
  [IPConfigurationReference <IComponentsCr63WSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesIpconfigurationreferencesItems[]>]: IPConfigurationReferences - list of IPConfigurationReferences
    [Id <String>]: IPConfigurationID
  [IPPool <IIPPool[]>]: network associated pool of IP Addresses
    [End <String>]: end of the ip address pool
    [Name <String>]: Name of the IP-Pool
    [Start <String>]: start of the ip address pool
    [Type <IPPoolTypeEnum?>]: ip pool type
  [Name <String>]: Name - The name of the resource that is unique within a resource group. This name can be used to access the resource.
  [Route <IVirtualNetworkPropertiesSubnetsPropertiesItemsItem[]>]: Routes - Collection of routes contained within a route table.
    [AddressPrefix <String>]: AddressPrefix - The destination CIDR to which the route applies.
    [Name <String>]: Name - name of the subnet
    [NextHopIPAddress <String>]: NextHopIPAddress - The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.
  [RouteTableId <String>]: Etag - Gets a unique read-only string that changes whenever the resource is updated.
  [RouteTableName <String>]: Name - READ-ONLY; Resource name.
  [RouteTableType <String>]: Type - READ-ONLY; Resource type.
  [Vlan <Int32?>]: Vlan to use for the subnet
.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/new-azstackhcivmvirtualnetwork
#>
function New-AzStackHciVMVirtualNetwork {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworks])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('VirtualNetworkName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
    [System.String]
    # Name of the virtual network
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # The name of the extended location.
    ${CustomLocationId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String[]]
    # The list of DNS servers IP addresses.
    ${DnsServers},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.DefaultInfo(Script='"CustomLocation"')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes]
    # The type of the extended location.
    ${ExtendedLocationType},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.NetworkTypeEnum])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.NetworkTypeEnum]
    # Type of the network
    ${NetworkType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsItem[]]
    # Subnet - list of subnets under the virtual network
    # To construct, see NOTES section for SUBNET properties and create a hash table.
    ${Subnet},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.DateTime]
    # The timestamp of resource creation (UTC).
    ${SystemDataCreatedAt},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # The identity that created the resource.
    ${SystemDataCreatedBy},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType]
    # The type of identity that created the resource.
    ${SystemDataCreatedByType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.DateTime]
    # The timestamp of resource last modification (UTC)
    ${SystemDataLastModifiedAt},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # The identity that last modified the resource.
    ${SystemDataLastModifiedBy},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType]
    # The type of identity that last modified the resource.
    ${SystemDataLastModifiedByType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tags},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # name of the network switch to be used for VMs
    ${VMSwitchName},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
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
            CreateExpanded = 'Az.StackHCIVm.private\New-AzStackHciVMVirtualNetwork_CreateExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('ExtendedLocationType')) {
            $PSBoundParameters['ExtendedLocationType'] = "CustomLocation"
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
