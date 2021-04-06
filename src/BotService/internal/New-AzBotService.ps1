
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
Creates a Bot Service.
Bot Service is a resource group wide resource type.
.Description
Creates a Bot Service.
Bot Service is a resource group wide resource type.
.Example
PS C:\> New-AzBotService -resourcegroupname youriBotTest -name youri-bot1 -ApplicationId "af5fce4d-ee68-4b25-be09-f3222582e133"-Location eastus -Sku F0 -Description "123134" -Registration

Etag                                   Kind Location Name       SkuName SkuTier Type
----                                   ---- -------- ----       ------- ------- ----
"060085fb-0000-1800-0000-5fd71d7c0000" bot  global   youri-bot1 F0              Microsoft.BotService/botServices
.Example
PS C:\> New-AzBotService -resourcegroupname youriBotTest -name youri-apptest14 -ApplicationId "b1ab1727-0465-4255-a1bb-976210af972c" -Location eastus -Sku F0 -Description "123134" -Webapp

Etag                                   Kind Location Name            SkuName SkuTier Type
----                                   ---- -------- ----            ------- ------- ----
"06008351-0000-0200-0000-5fd732870000" sdk  global   youri-apptest14 F0              Microsoft.BotService/botServices

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot
.Link
https://docs.microsoft.com/powershell/module/az.botservice/new-azbotservice
#>
function New-AzBotService {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('BotName')]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
    [System.String]
    # The name of the Bot resource.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
    [System.String]
    # The name of the Bot resource group in the user subscription.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Azure Subscription ID.
    ${SubscriptionId},

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
            CreateExpanded = 'Az.BotService.private\New-AzBotService_CreateExpanded';
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
