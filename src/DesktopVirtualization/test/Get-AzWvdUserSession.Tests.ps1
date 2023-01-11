$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdUserSession.Recording.json'
$currentPath = $PSScriptRoot
$userName2 = $env.HostPoolPersistent + '/' + $env.SessionHostName + '/2'
$userName3 = $env.HostPoolPersistent + '/' + $env.SessionHostName + '/3'
$userName4 = $env.HostPoolPersistent + '/' + $env.SessionHostName + '/4'
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdUserSession' {
    It 'Get' {
        $userSession = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -HostPoolName $env.HostPoolPersistent `
                                -SessionHostName $env.SessionHostName `
                                -Id 2
            $userSession.Name | Should -Be $userName2
    }

    It 'List' {
        $userSessions = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -HostPoolName $env.HostPoolPersistent `
                                -SessionHostName $env.SessionHostName `
                                | Sort-Object -Property Name
            $userSessions[0].Name | Should -Be $userName2
            $userSessions[1].Name | Should -Be $userName3
    }

    It 'List host pool Level' {
        $userSessions = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroup `
                                -HostPoolName $env.HostPoolPersistent `
                                | Sort-Object -Property Name
            $userSessions[0].Name | Should -Be $userName2
            $userSessions[1].Name | Should -Be $userName3
            $userSessions[2].Name | Should -Be $userName4
    }
}
