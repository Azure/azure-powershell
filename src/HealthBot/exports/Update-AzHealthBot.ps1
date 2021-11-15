
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
Patch a HealthBot.
.Description
Patch a HealthBot.
.Example
PS C:\> update-AzHealthBot -ResourceGroupName youriTest -Name yourihealthbot -Sku S1

Location Name           SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type
-------- ----           ------------------- -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----
eastus   yourihealthbot 2020/12/29 8:19:10  test@microsoft.com User                    2020/12/30 6:12:33       test@microsoft.com    User                         Microsoft.HealthBot/health…
.Example
PS C:\> $getHealth = Get-AzHealthBot -ResourceGroupName youriTest -Name yourihealthbot
Update-AzHealthBot -InputObject $getHealth -Sku F0

Location Name           SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type
-------- ----           ------------------- -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----
eastus   yourihealthbot 2020/12/29 8:19:10  test@microsoft.com User                    2020/12/30 6:12:33       test@microsoft.com    User                         Microsoft.HealthBot/health…

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.IHealthBotIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBot
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IHealthBotIdentity>: Identity Parameter
  [BotName <String>]: The name of the Bot resource.
  [Id <String>]: Resource identity path
  [ResourceGroupName <String>]: The name of the Bot resource group in the user subscription.
  [SubscriptionId <String>]: Azure Subscription ID.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.healthbot/update-azhealthbot
#>
function Update-AzHealthBot {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBot])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('BotName')]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Path')]
    [System.String]
    # The name of the Bot resource.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Path')]
    [System.String]
    # The name of the Bot resource group in the user subscription.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Azure Subscription ID.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.IHealthBotIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName])]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName]
    # The name of the HealthBot SKU
    ${Sku},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotUpdateParametersTags]))]
    [System.Collections.Hashtable]
    # Tags for a HealthBot.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Category('Runtime')]
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
            UpdateExpanded = 'Az.HealthBot.private\Update-AzHealthBot_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.HealthBot.private\Update-AzHealthBot_UpdateViaIdentityExpanded';
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
