$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdSessionHost.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzWvdSessionHost' {
    It 'Update' {
        $sessionHost = Update-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -HostPoolName 'HostPoolPowershell1' `
                            -Name 'PowershellVM-0.wvdarmtest1.net' `
                            -AllowNewSession:$false

        $sessionHost = Get-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -HostPoolName 'HostPoolPowershell1' `
                            -Name 'PowershellVM-0.wvdarmtest1.net'
            $sessionHost.Name | Should -Be 'HostPoolPowershell1/PowershellVM-0.wvdarmtest1.net'
            $sessionHost.AllowNewSession | Should -Be $false

        $sessionHost = Update-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -HostPoolName 'HostPoolPowershell1' `
                            -Name 'PowershellVM-0.wvdarmtest1.net' `
                            -AllowNewSession:$true

        $sessionHost = Get-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -HostPoolName 'HostPoolPowershell1' `
                            -Name 'PowershellVM-0.wvdarmtest1.net'
            $sessionHost.Name | Should -Be 'HostPoolPowershell1/PowershellVM-0.wvdarmtest1.net'
            $sessionHost.AllowNewSession | Should -Be $true
    }
}
