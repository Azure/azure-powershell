$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdUserSession.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdUserSession' {
    It 'Get' {
        $userSession = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -HostPoolName 'HostPoolPowershell1' `
                                -SessionHostName 'PowershellVM-1.wvdarmtest1.net' `
                                -Id 2
            $userSession.Name | Should -Be 'HostPoolPowershell1/PowershellVM-1.wvdarmtest1.net/2'
    }

    It 'List' {
        $userSessions = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -HostPoolName 'HostPoolPowershell1' `
                                -SessionHostName 'PowershellVM-1.wvdarmtest1.net' `
                                | Sort-Object -Property Name
            $userSessions[0].Name | Should -Be 'HostPoolPowershell1/PowershellVM-1.wvdarmtest1.net/2'
            $userSessions[1].Name | Should -Be 'HostPoolPowershell1/PowershellVM-1.wvdarmtest1.net/3'
    }

    It 'List host pool Level' {
        $userSessions = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -HostPoolName 'HostPoolPowershell1' `
                                | Sort-Object -Property Name
            $userSessions[0].Name | Should -Be 'HostPoolPowershell1/PowershellVM-1.wvdarmtest1.net/2'
            $userSessions[1].Name | Should -Be 'HostPoolPowershell1/PowershellVM-1.wvdarmtest1.net/3'
            $userSessions[2].Name | Should -Be 'HostPoolPowershell1/PowershellVM-1.wvdarmtest1.net/4'
    }
}
