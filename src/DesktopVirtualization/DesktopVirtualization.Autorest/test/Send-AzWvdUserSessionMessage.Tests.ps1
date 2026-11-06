$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Send-AzWvdUserSessionMessage.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Send-AzWvdUserSessionMessage' {
    It 'Send' {
        $userSession = Get-AzWvdUserSession -SubscriptionId $env.SubscriptionId `
                                     -ResourceGroupName $env.ResourceGroupPersistent `
                                     -HostPoolName $env.HostPoolPersistent `
                                     -SessionHostName $env.SessionHostName `
                                     -ErrorAction Stop `
                                     | Where-Object SessionState -eq 'Active' | Select-Object -First 1
        $userSession | Should -Not -BeNullOrEmpty
        $userSessionId = ($userSession.Id -split '/')[-1]

        Send-AzWvdUserSessionMessage -SubscriptionId $env.SubscriptionId `
                                     -ResourceGroupName $env.ResourceGroupPersistent `
                                     -HostPoolName $env.HostPoolPersistent `
                                     -SessionHostName $env.SessionHostName `
                                     -UserSessionId $userSessionId `
                                     -MessageBody 'apple' `
                                     -MessageTitle 'title' `
                                     -ErrorAction Stop
    }
}
