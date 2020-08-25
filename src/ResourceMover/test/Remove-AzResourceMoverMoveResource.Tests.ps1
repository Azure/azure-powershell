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
        Add-AzResourceMoverMoveResource -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.moveCollectionMetadataRG -MoveCollectionName $env.moveCollectionName -SourceId "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/ps-sRgplb1/providers/Microsoft.Network/virtualNetworks/ps-sRgplb1-vnet" -Name my-sRgVm1-vnet -ResourceSettingResourceType "Microsoft.Network/virtualNetworks" -ResourceSettingTargetResourceName my-sRgVm1-vnet
        $response = Remove-AzResourceMoverMoveResource -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.moveCollectionMetadataRG -MoveCollectionName $env.moveCollectionName -Name my-sRgVm1-vnet
        $response.Status | Should -Be "Succeeded"
    }
}
