
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
Updates a Bot Service
.Description
Updates a Bot Service
.Example
PS C:\> Update-AzBotService -Name 'youri-apptest' -ResourceGroupName 'youriBotTest' -kind Bot

Etag                                   Kind Location Name            SkuName SkuTier Type
----                                   ---- -------- ----            ------- ------- ----
"0700e71b-0000-1800-0000-5fd73ed80000" Bot  global   youri-apptest                 Microsoft.BotService/botServices
.Example
PS C:\> $getAzbot = Get-AzBotService -Name 'youri-apptest' -ResourceGroupName 'youriBotTest'
Update-AzBotService -InputObject $getAzbot -kind sdk

Etag                                   Kind Location Name            SkuName SkuTier Type
----                                   ---- -------- ----            ------- ------- ----
"07008b1c-0000-1800-0000-5fd73f9e0000" sdk  global   youri-apptest                 Microsoft.BotService/botServices

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IBotServiceIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IBotServiceIdentity>: Identity Parameter
  [ChannelName <ChannelName?>]: The name of the Channel resource.
  [ConnectionName <String>]: The name of the Bot Service Connection Setting resource
  [Id <String>]: Resource identity path
  [ResourceGroupName <String>]: The name of the Bot resource group in the user subscription.
  [ResourceName <String>]: The name of the Bot resource.
  [SubscriptionId <String>]: Azure Subscription ID.
.Link
https://docs.microsoft.com/powershell/module/az.botservice/update-azbotservice
#>
function Update-AzBotService {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('BotName')]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
    [System.String]
    # The name of the Bot resource.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
    [System.String]
    # The name of the Bot resource group in the user subscription.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Azure Subscription ID.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IBotServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # The description of the bot
    ${Description},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # The Application Insights key
    ${DeveloperAppInsightKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # The Application Insights Api Key
    ${DeveloperAppInsightsApiKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # The Application Insights App Id
    ${DeveloperAppInsightsApplicationId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # The Name of the bot
    ${DisplayName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # The bot's endpoint
    ${Endpoint},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # Entity Tag
    ${Etag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # The Icon Url of the bot
    ${IconUrl},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.Kind])]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.Kind]
    # Required.
    # Gets or sets the Kind of the resource.
    ${Kind},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # Specifies the location of the resource.
    ${Location},

    [Parameter()]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String[]]
    # Collection of LUIS App Ids
    ${LuisAppId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # The LUIS Key
    ${LuisKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [System.String]
    # Microsoft App Id for the bot
    ${MsaAppId},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName])]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName]
    # The sku name
    ${SkuName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceTags]))]
    [System.Collections.Hashtable]
    # Contains resource tags defined as key/value pairs.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Runtime')]
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
            UpdateExpanded = 'Az.BotService.private\Update-AzBotService_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.BotService.private\Update-AzBotService_UpdateViaIdentityExpanded';
        }
        if (('UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
