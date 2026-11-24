# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Generates placement scores for regular Compute VM SKUs.
.Description
Generates placement scores for regular Compute VM SKUs in the requested regions and availability zones.
.Example
$desiredSizes = @(@{ sku = 'Standard_D2_v3' }, @{ sku = 'Standard_D4_v3' })
Invoke-AzComputePlacementScore -Location eastus -DesiredSize $desiredSizes -DesiredLocation @('eastus2', 'westus')
.Example
$desiredSizes = @(@{ sku = 'Standard_D2_v3' })
Invoke-AzComputePlacementScore -Location eastus -DesiredSize $desiredSizes -DesiredCount 2 -AvailabilityZone
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IResourceSize[]
.Outputs
System.Management.Automation.PSObject
.Link
https://learn.microsoft.com/powershell/module/az.compute/invoke-azcomputeplacementscore
#>
function Invoke-AzComputePlacementScore {
[OutputType([System.Management.Automation.PSObject])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Path')]
    [System.String]
    # The name of the Azure region.
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IResourceSize[]]
    # The desired virtual machine SKU sizes.
    ${DesiredSize},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Defines if the scope is zonal or regional.
    ${AvailabilityZone},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Body')]
    [System.Int32]
    # Desired instance count per region or zone based on the scope.
    ${DesiredCount},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Body')]
    [System.String[]]
    # The desired regions.
    ${DesiredLocation},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach.
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.SendAsyncStep[]]
    # SendAsync pipeline steps to append.
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.SendAsyncStep[]]
    # SendAsync pipeline steps to prepend.
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
    [System.Uri]
    # URI of the proxy server.
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for the proxy server.
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy.
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
            __AllParameterSets = 'Az.Compute.custom\Invoke-AzComputePlacementScore';
        }
        if (-not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
