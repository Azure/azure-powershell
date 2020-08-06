$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedMachine.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzConnectedMachine' {
    BeforeAll {
        $Account = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Account
        $AzureEnv = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments[[Microsoft.Azure.Commands.Common.Authentication.Abstractions.EnvironmentName]::AzureCloud]
        $TenantId = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext.Tenant.Id
        $PromptBehavior = [Microsoft.Azure.Commands.Common.Authentication.ShowDialog]::Never
        $Token = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory.Authenticate($account, $AzureEnv, $tenantId, $null, $promptBehavior, $null)
        $AccessToken = $Token.AccessToken

        $machineName = (New-Guid).Guid

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
    }

    AfterAll {
        if ($IsLinux) {
            return sudo $env.azcmagentPath disconnect --access-token $AccessToken
        }
        & $env.azcmagentPath disconnect --access-token $AccessToken
    }

    It 'Get all connected machines in a subscription' {
        $machines = Get-AzConnectedMachine
        $machines.Count | Should -Be 1
    }

    It 'Get all connected machines in a resource group' {
        $machines = Get-AzConnectedMachine -ResourceGroupName $env.ResourceGroupName
        $machines.Count | Should -Be 1
    }

    It 'Get a connected machine by machine name' {
        $machine = Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName
        $machine | Should -Not -Be $null
        $machine.Location | Should -MatchExactly $env.location
    }
}
