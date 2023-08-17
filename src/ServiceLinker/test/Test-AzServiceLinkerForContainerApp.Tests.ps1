$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzServiceLinkerForContainerApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzServiceLinkerForContainerApp' {
    It 'Validate' {
        $result = Test-AzServiceLinkerForContainerApp -ResourceGroupName $env.resourceGroup -ContainerApp $env.containerApp -LinkerName $env.preparedLinker
    }

    It 'ValidateViaIdentity' {
        $identity = @{
            ResourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.App/containerApps/$($env.containerApp)"
            LinkerName = $env.preparedLinker
        }
        $result = $identity | Test-AzServiceLinkerForContainerApp
    }
}
