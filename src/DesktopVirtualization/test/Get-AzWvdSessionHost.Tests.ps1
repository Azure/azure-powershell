$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdSessionHost.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdSessionHost' {
    It 'Get' {
        $sessionHost = Get-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -HostPoolName 'HostPoolPowershell1' `
                            -Name 'PowershellVM-0.wvdarmtest1.net'
            $sessionHost.Name | Should -Be 'HostPoolPowershell1/PowershellVM-0.wvdarmtest1.net'
    }

    It 'List' {
        $sessionHosts = Get-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -HostPoolName 'HostPoolPowershell1' `
                            | Sort-Object -Property Name 
        
            $sessionHosts[0].Name | Should -Be 'HostPoolPowershell1/PowershellVM-0.wvdarmtest1.net'
            $sessionHosts[1].Name | Should -Be 'HostPoolPowershell1/PowershellVM-1.wvdarmtest1.net'
    }
}
