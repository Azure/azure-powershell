
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/new-azstackhcivmvirtualnetworksubnetconfig
#>
function New-AzStackHciVMVirtualNetworkSubnetConfig {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String[]]
    ${AddressPrefixes},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    ${IpAllocationMethod},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    ${IpPoolEnd},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    ${IpPoolStart},

    [Parameter(Position=4)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    ${IpPoolType},

    [Parameter(Position=5)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Collections.Hashtable[]]
    ${IpPools},

    [Parameter(Position=6)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Collections.Hashtable[]]
    ${Routes},

    [Parameter(Position=7)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    ${SubnetName},

    [Parameter(Position=8)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Int32]
    ${Vlan}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.StackHCIVm.custom\New-AzStackHciVMVirtualNetworkSubnetConfig';
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
