$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdSessionHost.Recording.json'
$currentPath = $PSScriptRoot
$sessionHostPath = $env.SHMHostPoolPersistent + '/' + $env.SHMSessionHostReprovisioning
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzWvdSessionHost' {
    It 'Update' {
        $sessionHost = Update-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroupPersistent `
                            -HostPoolName $env.SHMHostPoolPersistent `
                            -Name $env.SHMSessionHostReprovisioning `
                            -AllowNewSession:$false

        $sessionHost = Get-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroupPersistent `
                            -HostPoolName $env.SHMHostPoolPersistent `
                            -Name $env.SHMSessionHostReprovisioning
            $sessionHost.Name | Should -Be $sessionHostPath
            $sessionHost.AllowNewSession | Should -Be $false

        $sessionHost = Update-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroupPersistent `
                            -HostPoolName $env.SHMHostPoolPersistent `
                            -Name $env.SHMSessionHostReprovisioning `
                            -AllowNewSession:$true

        $sessionHost = Get-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroupPersistent `
                            -HostPoolName $env.SHMHostPoolPersistent `
                            -Name $env.SHMSessionHostReprovisioning
            $sessionHost.Name | Should -Be $sessionHostPath
            $sessionHost.AllowNewSession | Should -Be $true
    }
}
