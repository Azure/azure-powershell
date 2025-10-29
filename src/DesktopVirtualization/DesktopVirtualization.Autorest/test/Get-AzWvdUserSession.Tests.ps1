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
    # User session will not be found when the session host hasn't been connected with.
    BeforeAll {
        # Get user sessions list first. Use one from the results as the input parameter in the Get test
        $userSessions = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroupPersistent `
                                -HostPoolName $env.HostPoolPersistent `
                                -SessionHostName $env.SessionHostName `
                                | Sort-Object -Property Name
    }

    It 'List' {
        $userSessions.Count | Should -BeGreaterThan 0
    }
    
    It 'Get' {
        $tempUserSessionId = ($userSessions[0].Id -split '/')[-1]
        $tempUserSessionName = $userSessions[0].Name
        $userSession = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroupPersistent `
                                -HostPoolName $env.HostPoolPersistent `
                                -SessionHostName $env.SessionHostName `
                                -Id $tempUserSessionId
            $userSession.Name | Should -Be $tempUserSessionName
    }

    It 'List HostPool Level' {
        $userSessions = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                -ResourceGroupName $env.ResourceGroupPersistent `
                                -HostPoolName $env.HostPoolPersistent
        $userSessions.Count | Should -BeGreaterThan 0
    }
}
