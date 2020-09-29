$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDatabricksVNetPeering.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDatabricksVNetPeering' {
    It 'CreateExpanded' {
        $ventPeering = New-AzDatabricksVNetPeering -Name $env.vnetpeeringname01 -WorkspaceName $env.testWorkspace2 -ResourceGroupName $env.resourceGroup -RemoteVirtualNetworkId $env.virtualNetwork
        $ventPeering.ProvisioningState | Should -Be 'Updating'
    }
}
