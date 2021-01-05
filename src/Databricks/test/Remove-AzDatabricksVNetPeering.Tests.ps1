$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDatabricksVNetPeering.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDatabricksVNetPeering' {
    It 'Delete' {
        Remove-AzDatabricksVNetPeering -Name $env.vnetpeeringname01 -WorkspaceName $env.testWorkspace2 -ResourceGroupName $env.resourceGroup
        $vnetPeeringList = Get-AzDatabricksVNetPeering -WorkspaceName $env.testWorkspace2 -ResourceGroupName $env.resourceGroup
        $vnetPeeringList.Name | Should -Not -Contain $env.vnetpeeringname01
    }

    It 'DeleteViaIdentity' {
        $ventPeering = New-AzDatabricksVNetPeering -Name $env.vnetpeeringname02 -WorkspaceName $env.testWorkspace2 -ResourceGroupName $env.resourceGroup -RemoteVirtualNetworkId $env.virtualNetwork
        Remove-AzDatabricksVNetPeering -InputObject $ventPeering
        $vnetPeeringList = Get-AzDatabricksVNetPeering -WorkspaceName $env.testWorkspace2 -ResourceGroupName $env.resourceGroup
        $vnetPeeringList.Name | Should -Not -Contain $env.vnetpeeringname02
    }
}
