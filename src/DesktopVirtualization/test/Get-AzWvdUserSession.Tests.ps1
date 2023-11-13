$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdUserSession.Recording.json'
$currentPath = $PSScriptRoot
$userName3 = $env.HostPoolPersistent + '/' + $env.SessionHostName + '/3'
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
        $userSessions.Count | Should -Be 3
    }

    It 'List HostPool Level' {
        $userSessions = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroupPersistent `
                                -HostPoolName $env.HostPoolPersistent
        $userSessions.Count | Should -Be 3
    }
}
