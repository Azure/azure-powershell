$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWvdSessionHost.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzWvdSessionHost' {
    It 'Delete' {
         # This will fail when there's no existed session host
        Remove-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroupPersistent `
                            -HostPoolName $env.SHMHostPoolPersistent `
                            -Name $env.SHMSessionHostNameRemove `
                            -Force

        try {
            Get-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroupPersistent `
                            -HostPoolName $env.SHMHostPoolPersistent `
                            -Name $env.SHMSessionHostNameRemove
            throw "Get should have failed."
        } catch {

        }
    }
}
