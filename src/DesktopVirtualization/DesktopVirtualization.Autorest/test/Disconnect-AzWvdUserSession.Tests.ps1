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
        # User session will not be found when the session host hasn't been connected with.
        $userSessions = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroupPersistent `
                                -HostPoolName $env.HostPoolPersistent `
                                -SessionHostName $env.SessionHostName
        
        $userSessionToDisconnectParts = $userSessions[0].Id -split '/'
        
        $userSessionIdToDisconnect = $userSessionToDisconnectParts[-1]
        
        Disconnect-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroupPersistent `
                                -HostPoolName $env.HostPoolPersistent `
                                -SessionHostName $env.SessionHostName `
                                -Id $userSessionIdToDisconnect

        $userSession = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroupPersistent `
                                -HostPoolName $env.HostPoolPersistent `
                                -SessionHostName $env.SessionHostName `
                                -Id $userSessionIdToDisconnect
        $userSession.Name | Should -Be $userSessions[0].Name
        $userSession.SessionState | Should -Be 'Disconnected'
    }
}
