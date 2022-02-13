$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzResourceMoverMoveResource.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzResourceMoverMoveResource' {
    It 'Delete' {
       $response = Remove-AzResourceMoverMoveResource -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.moveCollectionMetadataRG -MoveCollectionName $env.moveCollectionName -Name "rms-sRg"
       $response.Status | Should -Be "Succeeded"
    }
}
