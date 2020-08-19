$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedMachineExtension.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzConnectedMachineExtension' {
    BeforeAll {
        $machineName = $env.MachineName1

        if ($TestMode -ne 'playback' -and $IsMacOS) {
            Write-Host "Live Get-AzConnectedMachine tests can only be run on Windows and Linux. Skipping..."
            $SkipAll = $true
            # All `It` calls will have -Skip:$true
            $PSDefaultParameterValues["It:Skip"] = $true
        }

        if ($TestMode -eq 'playback') {
            # Skip starting azcmagent
            return
        }

        $Account = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Account
        $AzureEnv = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments[[Microsoft.Azure.Commands.Common.Authentication.Abstractions.EnvironmentName]::AzureCloud]
        $TenantId = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Tenant.Id
        $PromptBehavior = [Microsoft.Azure.Commands.Common.Authentication.ShowDialog]::Never
        $Token = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory.Authenticate($account, $AzureEnv, $tenantId, $null, $promptBehavior, $null)
        $AccessToken = $Token.AccessToken

        $azcmagentArgs = @(
            'connect'
            '--resource-group'
            $env.ResourceGroupName
            '--tenant-id'
            $TenantId
            '--location'
            $env.location
            '--subscription-id'
            $env.SubscriptionId
            '--access-token'
            $AccessToken
            '--resource-name'
            $machineName
        )

        if ($IsLinux) {
            return sudo $env.azcmagentPath @azcmagentArgs 
        }
        & $env.azcmagentPath @azcmagentArgs

        $splat = @{
            
        }
    }

    AfterAll {
        # Reset PSDefaultParameterValues
        if ($PSDefaultParameterValues["It:Skip"]) {
            $PSDefaultParameterValues.Remove("It:Skip")
            return
        }

        if ($TestMode -eq 'playback') {
            # Skip stopping azcmagent
            return
        }

        if ($IsLinux) {
            return sudo $env.azcmagentPath disconnect --access-token $AccessToken
        }
        & $env.azcmagentPath disconnect --access-token $AccessToken
    }

    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
