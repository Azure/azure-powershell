
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
https://docs.microsoft.com/powershell/module/az.botservice/export-azbotserviceapp
#>
function Export-AzBotServiceApp {
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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        ${SavePath},
    
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
            $BotService = Get-AzBotService -ResourceGroupName $ResourceGroupName -Name $Name @EnvPSBoundParameters
            if ('bot' -eq $BotService.Kind)
            {
                throw "Source download is not supported for registration only bots."
            }
            if (-not $PSBoundParameters.ContainsKey('SavePath'))
            {
                $SavePath = '.'
                Write-Host 'Parameter $SavePath not provided, defaulting to current working directory.'
            }
            $SavePath = Resolve-Path -Path $SavePath
            if (-not (Get-Item $SavePath) -is [System.IO.DirectoryInfo])
            {
                throw "SavePath is not a valid directory."
            }
            DownloadBotZip -ResourceGroupName $ResourceGroupName -Name $Name -SavePath $SavePath -EnvParameters $EnvPSBoundParameters

        } catch {
            throw
        }
    }
}

function DownloadBotZip
{
    [Microsoft.Azure.PowerShell.Cmdlets.BotService.DoNotExportAttribute()]
    param(
        [Parameter()]
        [System.String]
        ${ResourceGroupName},
        [Parameter()]
        [System.String]
        ${Name},
        [Parameter()]
        [System.String]
        ${SavePath},
        [Parameter()]
        [hashtable]
        ${EnvParameters}
    )
    process {
        $WebApp = Get-AzWebApp -ResourceGroupName $ResourceGroupName -Name $Name @EnvParameters
        foreach ($HostNameSslState in $WebApp.HostNameSslStates)
        {
            if ('Repository' -eq $HostNameSslState.HostType)
            {
                $HostName = $HostNameSslState.Name
                $ScmUrl = "https://$HostName"
                $PublishingProfileInfo = [xml](Get-AzWebAppPublishingProfile -ResourceGroupName $ResourceGroupName -Name $Name @EnvParameters)
                foreach ($publishProfile in $PublishingProfileInfo.publishData.publishProfile)
                {
                    if ('MSDeploy' -eq $publishProfile.publishMethod)
                    {
                        $Username = $publishProfile.userName
                        $UserPWD = $publishProfile.userPWD
                        $JWT = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes("${Username}:${UserPWD}"))
                        $OctetHeader = @{'content-type' = 'application/octet-stream'; 'authorization' = "Basic $JWT"}
                        $NeedToPackSourceCode = $False
                        try {
                            $Response = Invoke-WebRequest -Method Get -Headers $OctetHeader -Uri "$ScmUrl/api/zip/site/clirepo/"
                            
                            if (200 -ne $Response.StatusCode)
                            {
                                $NeedToPackSourceCode = $True
                            }
                        }
                        catch {
                            $NeedToPackSourceCode = $True
                        }
                        if ($NeedToPackSourceCode)
                        {
                            $Payload = @{
                                "command" = "PostDeployScripts\\prepareSrc.cmd $userPWD";
                                "dir" = "site\wwwroot"
                            }
                            $Body = ConvertTo-Json $Payload
                            $JsonHeader = @{'content-type' = 'application/json'; 'authorization' = "Basic $JWT"}
                            $PrepareSrcResponse = Invoke-WebRequest -Method Post -Headers $JsonHeader -Uri "$ScmUrl/api/command" -Body $Body
                            if (200 -ne $PrepareSrcResponse.StatusCode)
                            {
                                throw "Fail to pack the source code into bot-src.zip."
                            }
                        }
                        $DownloadPath = [System.IO.Path]::Combine($SavePath, $Name)
                        if (Test-Path -Path $DownloadPath)
                        {
                            throw "The path $DownloadPath already exists. Please delete this folder or specify an alternate path."
                        }
                        New-Item -Path $DownloadPath -ItemType Directory
                        $ZipPath = [System.IO.Path]::Combine($SavePath, 'download.zip')
                        $Response = Invoke-WebRequest -Method Get -Headers $OctetHeader -Uri "$ScmUrl/api/vfs/site/bot-src.zip" -OutFile $ZipPath
                        Expand-Archive -Path $ZipPath -DestinationPath $DownloadPath
                        Remove-Item -Path $ZipPath
                        return
                    }
                }
                throw "Cannot find web deploy profile for $Name."
            }
        }
        throw 'Failed to retrieve Scm Uri'
    }
}