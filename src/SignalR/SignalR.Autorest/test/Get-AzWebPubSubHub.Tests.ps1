$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath))
{
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebPubSubHub.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath)
{
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWebPubSubHub' {
    It 'List' {
        $hubList = Get-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1
        $hubList.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $hub = Get-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1 -Name $env.Hub1
        $hub.Name | Should -Be $env.Hub1
        $hub.AnonymousConnectPolicy | Should -Be 'deny'
    }

    It 'GetViaIdentity' {
        $oldHub = Get-AzWebPubSubHub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1 -Name $env.Hub1
        $hub = Get-AzWebPubSubHub -InputObject $oldHub
        $hub.Name | Should -Be $env.Hub1
    }
}
