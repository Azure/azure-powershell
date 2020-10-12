
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
Create or Update a dedicated HSM in the specified subscription.
.Description
Create or Update a dedicated HSM in the specified subscription.
.Example
PS C:\> New-AzDedicatedHsm -Name  hsm-n7wfxi -ResourceGroupName dedicatedhsm-rg-n359cz -Location eastus -Sku "SafeNet Luna Network HSM A790" -StampId stamp1 -SubnetId "/subscriptions/xxxx-xxxx-xxx-xxx/resourceGroups/dedicatedhsm-rg-n359cz/providers/Microsoft.Network/virtualNetworks/vnetq30la9/subnets/hsmsubnet" -NetworkInterface @{PrivateIPAddress = '10.2.1.120' }

Name       Provisioning State SKU                           Location
----       ------------------ ---                           --------
hsm-n7wfxi Succeeded          SafeNet Luna Network HSM A790 eastus

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsm
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

NETWORKINTERFACE <INetworkInterface[]>: Specifies the list of resource Ids for the network interfaces associated with the dedicated HSM.
  [PrivateIPAddress <String>]: Private Ip address of the interface
.Link
https://docs.microsoft.com/en-us/powershell/module/az.dedicatedhsm/new-azdedicatedhsm
#>
function New-AzDedicatedHsm {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsm])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Path')]
    [System.String]
    # Name of the dedicated Hsm
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Path')]
    [System.String]
    # The name of the Resource Group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Body')]
    [System.String]
    # The supported Azure location where the dedicated HSM should be created.
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkInterface[]]
    # Specifies the list of resource Ids for the network interfaces associated with the dedicated HSM.
    # To construct, see NOTES section for NETWORKINTERFACE properties and create a hash table.
    ${NetworkInterface},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Body')]
    [System.String]
    # SKU of the dedicated HSM
    ${Sku},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Body')]
    [System.String]
    # This field will be used when RP does not support Availability zones.
    ${StampId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Body')]
    [System.String]
    # The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
    ${SubnetId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Body')]
    [System.String[]]
    # The Dedicated Hsm zones.
    ${Zone},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Category('Runtime')]
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
            CreateExpanded = 'Az.DedicatedHsm.private\New-AzDedicatedHsm_CreateExpanded';
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
