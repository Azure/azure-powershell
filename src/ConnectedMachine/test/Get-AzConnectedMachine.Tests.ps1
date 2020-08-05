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
        $machineName = (New-Guid).Guid

        $azcmagentArgs = @(
            'connect'
            '--resource-group'
            $env.ResourceGroupName
            '--tenant-id'
            $env.TenantId
            '--location'
            $env.location
            '--subscription-id'
            $env.SubscriptionId
            '--access-token'
            $env.AccessToken
            '--resource-name'
            $machineName
        )

        if ($IsLinux) {
            return sudo $env.azcmagentPath @azcmagentArgs 
        }
        & $env.azcmagentPath @azcmagentArgs
    }

    AfterAll {
        # Remove-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName
        if ($IsLinux) {
            return sudo $env.azcmagentPath disconnect --access-token $env.AccessToken
        }
        & $env.azcmagentPath disconnect --access-token $env.AccessToken
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
