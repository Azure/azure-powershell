$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResourceMoverMoveCollection.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzResourceMoverMoveCollection' {
    It 'List' {
        $tempSubscriptionId = "d43336d5-9b49-4b53-a3e5-1b07465f4bd6"
        $moveCollection = Get-AzResourceMoverMoveCollection  -SubscriptionId $tempSubscriptionId
        $moveCollection.Length | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $moveCollection = Get-AzResourceMoverMoveCollection  -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.moveCollectionMetadataRG -Name $env.moveCollectionName
        $moveCollection.Name | Should -Be $env.moveCollectionName
    }

    It 'List1' {
        $moveCollection = Get-AzResourceMoverMoveCollection  -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.moveCollectionMetadataRG
        $moveCollection.Length | Should -BeGreaterOrEqual 1
    }
}
