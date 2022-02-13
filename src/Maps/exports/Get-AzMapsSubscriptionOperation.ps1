
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
List operations available for the Maps Resource Provider
.Description
List operations available for the Maps Resource Provider
.Example
PS C:\> Get-AzMapsSubscriptionOperation

IsDataAction Name                                                                          Origin
------------ ----                                                                          ------
             Microsoft.Maps/resourceTypes/read
             Microsoft.Maps/unregister/action
             Microsoft.Maps/operations/read
             Microsoft.Maps/register/action
             Microsoft.Maps/accounts/write
             Microsoft.Maps/accounts/read
             Microsoft.Maps/accounts/delete
             Microsoft.Maps/accounts/listKeys/action
             Microsoft.Maps/accounts/regenerateKey/action
             Microsoft.Maps/accounts/eventGridFilters/delete
             Microsoft.Maps/accounts/eventGridFilters/read
             Microsoft.Maps/accounts/eventGridFilters/write
             Microsoft.Maps/accounts/providers/Microsoft.Insights/metricDefinitions/read   system
             Microsoft.Maps/accounts/providers/Microsoft.Insights/diagnosticSettings/read  system
             Microsoft.Maps/accounts/providers/Microsoft.Insights/diagnosticSettings/write system
True         Microsoft.Maps/accounts/services/render/read
True         Microsoft.Maps/accounts/services/geolocation/read
True         Microsoft.Maps/accounts/services/mobility/read
True         Microsoft.Maps/accounts/services/route/read
True         Microsoft.Maps/accounts/services/search/read
True         Microsoft.Maps/accounts/services/timezone/read
True         Microsoft.Maps/accounts/services/traffic/read
True         Microsoft.Maps/accounts/services/weather/read
True         Microsoft.Maps/accounts/services/data/read
True         Microsoft.Maps/accounts/services/data/delete
True         Microsoft.Maps/accounts/services/data/write
True         Microsoft.Maps/accounts/services/spatial/read
True         Microsoft.Maps/accounts/services/spatial/write
True         Microsoft.Maps/accounts/services/turnbyturn/read
True         Microsoft.Maps/accounts/services/elevation/read
True         Microsoft.Maps/accounts/services/dataordering/read
True         Microsoft.Maps/accounts/services/dataordering/write
True         Microsoft.Maps/accounts/services/analytics/read
True         Microsoft.Maps/accounts/services/analytics/delete
True         Microsoft.Maps/accounts/services/analytics/write
             Microsoft.Maps/accounts/creators/write
             Microsoft.Maps/accounts/creators/read
             Microsoft.Maps/accounts/creators/delete

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail
.Link
https://docs.microsoft.com/powershell/module/az.maps/get-azmapssubscriptionoperation
#>
function Get-AzMapsSubscriptionOperation {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Runtime')]
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
            List = 'Az.Maps.private\Get-AzMapsSubscriptionOperation_List';
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
