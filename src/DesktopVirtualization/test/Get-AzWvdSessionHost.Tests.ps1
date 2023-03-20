$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdSessionHost.Recording.json'
$currentPath = $PSScriptRoot
$sessionHostPath = $env.HostPoolPersistent + "/pwsh-0"
$sessionHostPath2 = $env.HostPoolPersistent + "/userSess-sh-0"
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdSessionHost' {
    It 'Get' {
        $sessionHost = Get-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroupPersistent `
                            -HostPoolName $env.HostPoolPersistent `
                            -Name $env.SessionHostName
            $sessionHost.Name | Should -Be $sessionHostPath
    }

    It 'List' {
        $sessionHosts = Get-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroupPersistent `
                            -HostPoolName $env.HostPoolPersistent `
                            | Sort-Object -Property Name 
        
            $sessionHosts[0].Name | Should -Be $sessionHostPath
            $sessionHosts[1].Name | Should -Be $sessionHostPath2
    }
}
