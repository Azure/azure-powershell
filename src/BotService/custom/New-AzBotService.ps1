
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
Returns a BotService specified by the parameters.
.Description
Returns a BotService specified by the parameters.
.Link
https://docs.microsoft.com/powershell/module/az.botservice/new-azbotservice
#>
function New-AzBotService {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        # The name of the Bot resource group in the user subscription.
        ${ResourceGroupName},
    
        [Alias('BotName')]
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        # The name of the Bot resource.
        ${Name},

        [Parameter(ParameterSetName='Registration')]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        ${DisplayName},

        [Parameter(ParameterSetName='Registration')]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        ${Endpoint},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        ${Description},
    
        [Parameter(ParameterSetName='Registration')]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [Switch]
        ${Registration},
    
        [Parameter(ParameterSetName='WebApp')]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [Switch]
        ${Webapp},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        ${ApplicationId},
    
        [Parameter(ParameterSetName='WebApp', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [Security.SecureString]
        ${ApplicationSecret},
    
        [Parameter(ParameterSetName='WebApp')]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        ${ExistingServerFarmId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        ${Location} = 'global',

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [ValidateSet('F0', 'S1')]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Body')]
        [System.String]
        # The sku name
        ${Sku},
    
        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [ValidateSet('C#', 'JavaScript')]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        ${Language} = 'C#',
    
        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [ValidateSet('echo')]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        ${BotTemplateType} = 'echo',
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # Azure Subscription ID.
        ${SubscriptionId},
    
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
    
    process {
        try {
            $EnvPSBoundParameters = @{}
            if ($PSBoundParameters.ContainsKey('Debug')) {
                $EnvPSBoundParameters['Debug'] = $Debug
            }
            if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) {
                $EnvPSBoundParameters['HttpPipelineAppend'] = $HttpPipelineAppend
            }
            if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) {
                $EnvPSBoundParameters['HttpPipelinePrepend'] = $HttpPipelinePrepend
            }
            if ($PSBoundParameters.ContainsKey('Proxy')) {
                $EnvPSBoundParameters['Proxy'] = $Proxy
            }
            if ($PSBoundParameters.ContainsKey('ProxyCredential')) {
                $EnvPSBoundParameters['ProxyCredential'] = $ProxyCredential
            }
            if ($PSBoundParameters.ContainsKey('ProxyUseDefaultCredentials')) {
                $EnvPSBoundParameters['ProxyUseDefaultCredentials'] = $ProxyUseDefaultCredentials
            }
            $BotKind = 'bot'
            If ($PSBoundParameters.ContainsKey('Registration'))
            {
                $Kind = $BotKind
            }
            else
            {
                $Kind = 'sdk'
            }
            $NameAvailabilityResponse = Az.BotService.internal\Get-AzBotCheckNameAvailability -Name $Name -Type $Kind @EnvPSBoundParameters
            If (-not $NameAvailabilityResponse.valid)
            {
                Write-Error $NameAvailabilityResponse.Message
                throw
            }
            if ($BotKind -eq $Kind)
            {
                if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                    $EnvPSBoundParameters['SubscriptionId'] = [System.String]$SubscriptionId
                }
                if (-not $PSBoundParameters.ContainsKey('DisplayName'))
                {
                    $DisplayName = $Name
                }
                return Az.BotService.internal\New-AzBotService -Location $Location -Sku $Sku -Kind $Kind -DisplayName $Name -MsaAppId $ApplicationId `
                    -ResourceGroupName $ResourceGroupName -Name $Name -Endpoint $Endpoint @EnvPSBoundParameters
            }
            else
            {
                $SiteName = $Name.Substring(0, [Math]::Min(40, $Name.Length)).Trim('-')
                $ZipUrl = RetrieveBotTemplateLink -Language $Language -BotTemplateType $BotTemplateType
                if ($PSBoundParameters.ContainsKey('ExistingServerFarmId'))
                {
                    $ServerFarmId = $ExistingServerFarmId
                    $CreateServerFarm = $false
                }
                else
                {
                    $ServerFarmId = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Web/serverfarms/$Name"
                    $CreateServerFarm = $true
                }
                $TemplateFile = [System.IO.Path]::Combine($PSScriptRoot, 'webappv4.template.json')
                $AppSecret = . "$PSScriptRoot/../utils/Unprotect-SecureString.ps1" $ApplicationSecret
                $Parameter = @{
                    'location' = $Location;
                    'kind' = $Kind;
                    'sku' = $Sku;
                    'siteName' = $SiteName;
                    'appId' = $ApplicationId;
                    'appSecret' = $AppSecret;
                    'serverFarmId' = $ServerFarmId;
                    'zipUrl' = $ZipUrl;
                    'botEnv' = 'prod';
                    'createServerFarm' = $CreateServerFarm;
                    'serverFarmLocation' = $Location;
                    'botId' = $Name;
                    'description' = $Description
                }
                $Null = New-AzResourceGroupDeployment -ResourceGroupName $ResourceGroupName -TemplateParameterObject $Parameter `
                            -TemplateFile $TemplateFile @EnvPSBoundParameters
                
                return Get-AzBotService -ResourceGroupName $ResourceGroupName -Name $Name @EnvPSBoundParameters
            }
        } catch {
            throw
        }
    }
}

function RetrieveBotTemplateLink
{
    [OutputType([System.String])]
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.DoNotExportAttribute()]
    param(
        [Parameter()]
        [System.String]
        ${Language},
        [Parameter()]
        [System.String]
        ${BotTemplateType}
    )

    process {
        $Response = Invoke-WebRequest -Method Get -Uri 'https://dev.botframework.com/api/misc/bottemplateroot'
        if (200 -ne $Response.StatusCode)
        {
            Write-Error "Unable to get bot code template from CDN. Please file an issue on https://github.com/microsoft/botframework-sdk."
            throw
        }
        $CDNLink = $Response.Content.Replace('"', '')
        if (('C#' -eq $Language) -and ('echo' -eq $BotTemplateType))
        {
            return $CDNLink + 'csharp-abs-webapp-v4_echobot_precompiled.zip'
        } elseif (('Javascript' -eq $Language) -and ('echo' -eq $BotTemplateType))
        {
            return $CDNLink + 'node.js-abs-webapp-v4_echobot.zip'
        }
    }
}