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
        Send-AzWvdUserSessionMessage -SubscriptionId $env.SubscriptionId `
                                     -ResourceGroupName $env.ResourceGroup `
                                     -HostPoolName 'HostPoolPowershell1' `
                                     -SessionHostName 'PowershellVM-1.wvdarmtest1.net' `
                                     -UserSessionId 4 `
                                     -MessageBody 'apple' `
                                     -MessageTitle 'title'
    }
}
