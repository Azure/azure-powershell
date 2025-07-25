function Get-AzAccessToken {
    if ($script:AZ_ACCESS_TOKEN) {
        return $script:AZ_ACCESS_TOKEN
    }

    $Account = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Account
    $AzureEnv = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments[[Microsoft.Azure.Commands.Common.Authentication.Abstractions.EnvironmentName]::AzureCloud]
    $TenantId = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Tenant.Id
    $PromptBehavior = [Microsoft.Azure.Commands.Common.Authentication.ShowDialog]::Never
    $Token = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory.Authenticate($account, $AzureEnv, $tenantId, $null, $promptBehavior, $null)
    $script:AZ_ACCESS_TOKEN = $Token.AccessToken
    return $script:AZ_ACCESS_TOKEN
}

function Start-ExtensionPopulate {
    [CmdletBinding()]
    param (
        # Machine name
        [Parameter(Mandatory)]
        [string]
        $MachineName,

        [Parameter(Mandatory)]
        $Env
    )

    $splat = @{
        MachineName = $machineName
        ResourceGroupName = $env.ResourceGroupName
        Location = $env.location
    }

    if ($IsLinux) {
        $splat.ExtensionType = "CustomScript"
        $splat.Publisher = "Microsoft.Azure.Extensions"
        $splat.TypeHandlerVersion = "2.1"
        $splat.Settings = @{
            commandToExecute = "ls"
        }
    } elseif ($IsWindows) {
        $splat.ExtensionType = "NetworkWatcherAgentWindows"
        $splat.Publisher = "Microsoft.Azure.NetworkWatcher"
        $splat.TypeHandlerVersion = "1.4.2798.3"
        $splat.Settings = @{
            CommandToExecute = "dir"
        }
    }

    Write-Host "Setting CustomScript extension..." -ForegroundColor Cyan
    Set-AzConnectedMachineExtension @splat -Name custom1

    if ($IsLinux) {
        $splat.ExtensionType = "DependencyAgentLinux"
    } elseif ($IsWindows) {
        $splat.ExtensionType = "DependencyAgentWindows"
    }
    $splat.Publisher = "Microsoft.Azure.Monitoring.DependencyAgent"
    $splat.Remove("TypeHandlerVersion")
    $splat.Settings = @{}

    Write-Host "Setting DependencyAgent extension..." -ForegroundColor Cyan
    Set-AzConnectedMachineExtension @splat -Name custom2
}

function Start-ExtensionRemoval {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory)]
        [string]
        $ResourceGroupName,

        [Parameter(Mandatory)]
        [string]
        $MachineName
    )

    # Tests include -SubscriptionId automatically but it causes
    # piping to fail. This temporarily removes that default value for
    # this test.
    $before = $PSDefaultParameterValues["*:SubscriptionId"]
    $PSDefaultParameterValues.Remove("*:SubscriptionId")
    try {
        Get-AzConnectedMachineExtension -ResourceGroupName $ResourceGroupName -MachineName $MachineName | Remove-AzConnectedMachineExtension
    } finally {
        $PSDefaultParameterValues["*:SubscriptionId"] = $before
    }
}

function Start-Agent {
    [CmdletBinding()]
    param (
        # Machine name
        [Parameter(Mandatory)]
        [string]
        $MachineName,

        # Env
        [Parameter(Mandatory)]
        $Env
    )
    
    $azcmagentArgs = @(
        'connect'
        '--resource-group'
        $env.ResourceGroupName
        '--tenant-id'
        $env.Tenant
        '--location'
        $env.location
        '--subscription-id'
        $env.SubscriptionId
        '--access-token'
        (Get-AzAccessToken)
        '--resource-name'
        $MachineName
    )

    Write-Host "Starting Agent..." -ForegroundColor Cyan
    if ($IsLinux) {
        return sudo $env.azcmagentPath @azcmagentArgs 
    }
    & $env.azcmagentPath @azcmagentArgs
}

function Stop-Agent {
    [CmdletBinding()]
    param (
        # Path to agent
        [Parameter(Mandatory)]
        [string]
        $AgentPath
    )

    Write-Host "Stopping Agent..." -ForegroundColor Cyan
    if ($IsLinux) {
        return sudo $env.azcmagentPath disconnect --access-token (Get-AzAccessToken)
    }
    & $env.azcmagentPath disconnect --access-token (Get-AzAccessToken)
}