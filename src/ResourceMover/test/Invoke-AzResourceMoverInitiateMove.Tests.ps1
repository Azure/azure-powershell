$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzResourceMoverInitiateMove.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzResourceMoverInitiateMove' {
    It 'InitiateExpanded' {            
         $moveResponse = Invoke-AzResourceMoverInitiateMove -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.moveCollectionMetadataRG -MoveCollectionName $env.moveCollectionName -MoveResource "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/rms-sRg" -MoveResourceInputType "MoveResourceSourceId"
         $moveResponse.Status | Should -Be "Succeeded"
    }
}

