
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
https://docs.microsoft.com/powershell/module/az.botservice/initialize-azbotservicepreparedeploy
#>
function Initialize-AzBotServicePrepareDeploy {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        # The name of the Bot resource group in the user subscription.
        ${CodeDir},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        ${ProjFileName},
    
        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [ValidateSet('C#', 'JavaScript', 'TypeScript')]
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Category('Path')]
        [System.String]
        ${Language} = 'C#',
    
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
            if ($Null -eq $CodeDir) {
                $CodeDir = Resolve-Path -Path .
                Write-Host "CodeDir not provided, defaulting to current working directory: $CodeDir."
            }
            if (-not (Test-Path -Path $CodeDir)) {
                throw "Provided CodeDir value $CodeDir does not exist."
            }
            if (("JavaScript" -eq $Language) -or ("TypeScript" -eq $Language)) {
                if ($PSBoundParameters.ContainsKey("ProjFileName")) {
                    throw "ProjectFilePath should not be passed in if language is not Csharp."
                }
                $DestWebConfig = [System.IO.Path]::Combine($CodeDir, 'web.config')
                if (Test-Path -Path $DestWebConfig) {
                    throw "web.config is found in $CodeDir.Please delete it first."
                }
                if (-not (Test-Path -Path ([System.IO.Path]::Combine($CodePath, "package.json")))) {
                    Write-Warning "WARNING: This command should normally be run in the same folder as the package.json for Node.js bots. Package.json and web.config are usually in the same folder and at the root level of the .zip file."
                }
                if ("JavaScript" -eq $Language) {
                    $SourceWebConfig = [System.IO.Path]::Combine($PSScriptRoot, 'web.config')
                }
                else {
                    $SourceWebConfig = [System.IO.Path]::Combine($PSScriptRoot, 'typescript.web.config')
                }
                Copy-Item -Path $SourceWebConfig -Destination $DestWebConfig
            }
            else {
                if (-not $PSBoundParameters.ContainsKey("ProjFileName")) {
                    throw "ProjectFilePath must be provided if language is Csharp."
                }
                if (-not $ProjFileName.EndsWith('.csproj')) {
                    $ProjFileName = "$ProjFileName.csproj"
                }
                $DestWebConfig = [System.IO.Path]::Combine($CodeDir, '.deployment')
                if (Test-Path -Path $DestWebConfig) {
                    throw ".deployment is found in $CodeDir.Please delete it first."
                }
                $CsprojFile = [System.IO.Path]::Combine($CodeDir, $ProjFileName)
                if (-not (Test-Path -Path $CsprojFile)) {
                    throw "$ProjFileName file not found.Please verify the relative path to the .csproj file from the $CodeDir"
                }
                $DeploymentContent = "[config]{0}SCM_SCRIPT_GENERATOR_ARGS=--aspNetCore '$ProjFileName{1}'" -f @([environment]::NewLine, [environment]::NewLine)
                Set-Content -Path $DestWebConfig -Value $DeploymentContent
            }
        } catch {
            throw
        }
    }
}

