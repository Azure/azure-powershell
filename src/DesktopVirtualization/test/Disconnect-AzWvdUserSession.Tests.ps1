$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Disconnect-AzWvdUserSession.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Disconnect-AzWvdUserSession' {
    It 'Disconnect' {
        Disconnect-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -HostPoolName 'HostPoolPowershell1' `
                                -SessionHostName 'PowershellVM-1.wvdarmtest1.net' `
                                -Id 2
        
        $userSession = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -HostPoolName 'HostPoolPowershell1' `
                                -SessionHostName 'PowershellVM-1.wvdarmtest1.net' `
                                -Id 2
            $userSession.Name | Should -Be 'HostPoolPowershell1/PowershellVM-1.wvdarmtest1.net/2'
            $userSession.SessionState | Should -Be 'Disconnected'
    }
}
