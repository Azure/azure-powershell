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
API to register a new machine and thereby create a tracked resource in ARM
.Description
API to register a new machine and thereby create a tracked resource in ARM

.Link
https://docs.microsoft.com/en-us/powershell/module/az.connectedkubernetes/new-azconnectedkubernetes
#>
function New-AzConnectedMachine {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Path')]
        [System.String]
        # The name of the resource group to which the kubernetes cluster is registered.
        ${ResourceGroupName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the subscription to which the kubernetes cluster is registered.
        ${SubscriptionId},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
        [System.String]
        # Location of the cluster
        ${Location},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Path')]
        [System.String]
        ${Name},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Alias('Session')]
        [ValidateNotNull()]
        [System.Management.Automation.Runspaces.PSSession]
        ${PSSession},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api201912.IUpdateResourceTags]))]
        [System.Collections.Hashtable]
        # Resource tags.
        ${Tag},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    try {
        $Account = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Account
        $Env = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments[[Microsoft.Azure.Commands.Common.Authentication.Abstractions.EnvironmentName]::AzureCloud]
        $TenantId = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Tenant.Id
        $PromptBehavior = [Microsoft.Azure.Commands.Common.Authentication.ShowDialog]::Never
        $Token = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory.Authenticate($account, $env, $tenantId, $null, $promptBehavior, $null)
        $AccessToken = $Token.AccessToken
    } catch {
        throw 'Error retrieving access token. Are you logged in? (Run Connect-AzAccount)'
    }

    if (!$AccessToken) {
        throw 'Error retrieving access token. Are you logged in? (Run Connect-AzAccount)'
    }

    $azcmagentArgs = [System.Collections.Generic.List[string]]@(
        'connect'
        '--access-token'
        $AccessToken
        '--tenant-id'
        $TenantId
        '--subscription-id'
        $SubscriptionId
        '--resource-group'
        $ResourceGroupName
        '--location'
        $Location
    )

    if ($Name) {
        $azcmagentArgs.Add('--resource-name')
        $azcmagentArgs.Add($Name)
    }

    if ($Tag) {
        $azcmagentArgs.Add('--tags')
        $azcmagentArgs.Add((ConvertTagHashtableToString -TagHashtable $Tag))
    }

    $script = {
        $azcmagentArgs = $using:azcmagentArgs
        $proxyUrl = $using:Proxy
        
        if ($IsMacOS) {
            throw "Registration doesn't work on macOS. Only Linux and Windows are supported."
        }

        if ($IsLinux) {
            # Download the installation package
            Invoke-RestMethod -Uri https://aka.ms/azcmagent -OutFile ~/install_linux_azcmagent.sh -UseBasicParsing

            # Install the hybrid agent
            $installArgs = if ($proxyUrl) {
                '--proxy', $proxyUrl.ToString()
            } else {
                @()
            }
            bash ~/install_linux_azcmagent.sh @installArgs | ForEach-Object {
                Write-Host $_
            }

            # Set executable path
            $azcmagentPath = "azcmagent"
        } else {
            Invoke-RestMethod -Uri https://aka.ms/AzureConnectedMachineAgent -OutFile AzureConnectedMachineAgent.msi -UseBasicParsing
    
            # Install the package
            msiexec /i AzureConnectedMachineAgent.msi /l*v installationlog.txt /qn | ForEach-Object {
                Write-Host $_
            }

            [System.Environment]::SetEnvironmentVariable("https_proxy", $proxyUrl.ToString(), "Machine")

            # Set executable path
            $azcmagentPath = "$env:ProgramFiles\AzureConnectedMachineAgent\azcmagent.exe"
        }

        # Run connect command
        & $azcmagentPath @args | ForEach-Object {
            Write-Host $_
        }

        if ($LASTEXITCODE -ne 0) {
            throw "azcmagent exited with a non-zero exit code: $LASTEXITCODE"
        }

        & $azcmagentPath show
    }

    if ($PSSession) {
        $showResult = Invoke-Command -ScriptBlock $script -Session $PSSession -ArgumentList $azcmagentArgs
    } else {
        $showResult = & $script $azcmagentArgs
    }

    # Get name of machine registered
    $selectStrResult = $showResult | Select-String -Pattern "^Resource Name\s+:(?<resourceName>.*)$"
    $Name = $selectStrResult.Matches.Groups |
        Where-Object Name -EQ resourceName |
        Select-Object -ExpandProperty Value

    $selectStrResult = $showResult | Select-String -Pattern "^VM ID\s+:(?<vmId>.*)$"
    $vmId = $selectStrResult.Matches.Groups |
        Where-Object Name -EQ vmId |
        Select-Object -ExpandProperty Value

    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.ConnectedMachineIdentity]::DeserializeFromPSObject(
        [pscustomobject]@{
            Id = $vmId
            Name = $Name
            ResourceGroupName = $ResourceGroupName
            SubscriptionId = $SubscriptionId
        })
}

function ConvertTagHashtableToString {
    param (
        [hashtable]
        [ValidateNotNull]
        $TagHashtable
    )

    $keys = $TagHashtable.Keys
    $tagStrings = foreach ($key in $keys) {
        $tag = $key
        if ($TagHashtable[$key] -and $TagHashtable[$key].GetType() -eq [string]) {
            $tag += "=$($TagHashtable[$key])"
        }
        $tag
    }

    return [string]::Join(',', $tagStrings)
}
