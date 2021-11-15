
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
Regenerate either the primary or secondary key for use with the Maps APIs.
The old key will stop working immediately.
.Description
Regenerate either the primary or secondary key for use with the Maps APIs.
The old key will stop working immediately.
.Example
PS C:\> New-AzMapsAccountKey -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 -KeyType primary

PrimaryKey                                  PrimaryKeyLastUpdated        SecondaryKey                                SecondaryKeyLastUpdated
----------                                  ---------------------        ------------                                -----------------------
W5VYcbrpyt4urV2-4C-lXepnHoy6EIOHnoLL_wjEtaw 2021-05-20T05:50:27.1509422Z zi6W1bw4zIYLjDj_DRRrC3jBkX-APgBebwx4cZBKJOU 2021-05-20T05:41:03.452571Z
.Example
PS C:\> Get-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 | New-AzMapsAccountKey -KeyType primary

PrimaryKey                                  PrimaryKeyLastUpdated        SecondaryKey                                SecondaryKeyLastUpdated
----------                                  ---------------------        ------------                                -----------------------
xoGsuTFWuG6xq0re7EdA7nCbDhvRoisZfLHvKfdzIhQ 2021-05-20T05:55:21.7797268Z zi6W1bw4zIYLjDj_DRRrC3jBkX-APgBebwx4cZBKJOU 2021-05-20T05:41:03.452571Z

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.IMapsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeys
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMapsIdentity>: Identity Parameter
  [AccountName <String>]: The name of the Maps Account.
  [CreatorName <String>]: The name of the Maps Creator instance.
  [Id <String>]: Resource identity path
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [SubscriptionId <String>]: The ID of the target subscription.
.Link
https://docs.microsoft.com/powershell/module/az.maps/new-azmapsaccountkey
#>
function New-AzMapsAccountKey {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountKeys])]
[CmdletBinding(DefaultParameterSetName='RegenerateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='RegenerateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Path')]
    [System.String]
    # The name of the Maps Account.
    ${Name},

    [Parameter(ParameterSetName='RegenerateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='RegenerateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='RegenerateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.IMapsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.KeyType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.KeyType]
    # Whether the operation refers to the primary or secondary key.
    ${KeyType},

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
            RegenerateExpanded = 'Az.Maps.private\New-AzMapsAccountKey_RegenerateExpanded';
            RegenerateViaIdentityExpanded = 'Az.Maps.private\New-AzMapsAccountKey_RegenerateViaIdentityExpanded';
        }
        if (('RegenerateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
