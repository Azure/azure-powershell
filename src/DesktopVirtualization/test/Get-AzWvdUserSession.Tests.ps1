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
$userName5 = $env.HostPoolPersistent + '/' + $env.SessionHostName + '/5'
$userName6 = $env.HostPoolPersistent + '/' + $env.SessionHostName + '/6'
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdUserSession' {
    It 'Get' {
        $userSession = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroupPersistent `
                                -HostPoolName $env.HostPoolPersistent `
                                -SessionHostName $env.SessionHostName `
                                -Id 3
            $userSession.Name | Should -Be $userName3
    }

    It 'List' {
        $userSessions = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroupPersistent `
                                -HostPoolName $env.HostPoolPersistent `
                                -SessionHostName $env.SessionHostName `
                                | Sort-Object -Property Name
            $userSessions[0].Name | Should -Be $userName3
            $userSessions[1].Name | Should -Be $userName5
    }

    It 'List host pool Level' {
        $userSessions = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroupPersistent `
                                -HostPoolName $env.HostPoolPersistent `
                                | Sort-Object -Property Name
            $userSessions[0].Name | Should -Be $userName3
            $userSessions[1].Name | Should -Be $userName5
            $userSessions[2].Name | Should -Be $userName6
    }
}
