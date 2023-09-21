$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResourceMoverRequiredForResources.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzResourceMoverRequiredForResources' {
    It 'List' {
       $requiredStatus = Get-AzResourceMoverRequiredForResources -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.moveCollectionMetadataRG -MoveCollectionName $env.moveCollectionName -SourceId "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/rms-sRg"
       $requiredStatus.Length | Should -Be 0
    }
}
