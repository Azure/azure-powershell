$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzResourceMoverMoveResource.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Add-AzResourceMoverMoveResource' {
    It 'AddExpanded' {
        Remove-AzResourceMoverMoveResource -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.moveCollectionMetadataRG -MoveCollectionName $env.moveCollectionName -Name "mr-nsg"
        $trs = New-Object Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.NetworkSecurityGroupResourceSettings
        $trs.ResourceType = "Microsoft.Network/networkSecurityGroups"
        $trs.TargetResourceName = "demo-NSG-rms-centralus"
        $moveResource = Add-AzResourceMoverMoveResource -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.moveCollectionMetadataRG -MoveCollectionName $env.moveCollectionName -SourceId "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourcegroups/demo-RG-rms/providers/Microsoft.Network/networkSecurityGroups/demo-NSG-rms" -Name "mr-nsg" -ResourceSetting $trs
        $moveResource.Name | Should -Be "mr-nsg"
    }
}
