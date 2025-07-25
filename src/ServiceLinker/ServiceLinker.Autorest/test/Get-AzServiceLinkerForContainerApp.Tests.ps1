$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceLinkerForContainerApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzServiceLinkerForContainerApp' {
    It 'List' {
        $linkers = Get-AzServiceLinkerForContainerApp -ResourceGroupName $env.resourceGroup -ContainerApp $env.containerApp
        $linkers.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $linker = Get-AzServiceLinkerForContainerApp -ResourceGroupName $env.resourceGroup -ContainerApp $env.containerApp -LinkerName $env.preparedLinker
        $linker.Name | Should -Be $env.preparedLinker
    }

    It 'GetViaIdentity' {
        $identity = @{
            ResourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.App/containerApps/$($env.containerApp)"
            LinkerName = $env.preparedLinker
        }
        $linker = $identity | Get-AzServiceLinkerForContainerApp
        $linker.Name | Should -Be $env.preparedLinker
    }
}
