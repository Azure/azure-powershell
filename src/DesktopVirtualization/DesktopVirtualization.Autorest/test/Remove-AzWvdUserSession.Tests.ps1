$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWvdUserSession.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzWvdUserSession' {
    It 'Delete' {
        $userSessions = @(Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                    -ResourceGroupName $env.ResourceGroupPersistent `
                                    -HostPoolName $env.HostPoolPersistent `
                                    -SessionHostName $env.SessionHostName `
                                    -ErrorAction Stop)
        $userSessions.Count | Should -BeGreaterThan 0
        $userSessionId = ($userSessions[0].Id -split '/')[-1]

        Remove-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                    -ResourceGroupName $env.ResourceGroupPersistent `
                                    -HostPoolName $env.HostPoolPersistent `
                                    -SessionHostName $env.SessionHostName `
                                    -Id $userSessionId `
                                    -ErrorAction Stop

        for ($attempt = 0; $attempt -lt 60; $attempt++) {
            $remainingSessions = @(Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                    -ResourceGroupName $env.ResourceGroupPersistent `
                                    -HostPoolName $env.HostPoolPersistent `
                                    -SessionHostName $env.SessionHostName `
                                    -ErrorAction Stop `
                                    | Where-Object { ($_.Id -split '/')[-1] -eq $userSessionId })
            if ($remainingSessions.Count -eq 0) { break }
        }
        $remainingSessions.Count | Should -Be 0
    }
}
