$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDatabricksVNetPeering.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDatabricksVNetPeering' {
    It 'List' {
       $vetPeeringList = Get-AzDatabricksVNetPeering -WorkspaceName $env.testWorkspace1 -ResourceGroupName $env.resourceGroup
       $vetPeeringList.Count | Should -Be 1
    }

    It 'Get'{
        $vetPeering = Get-AzDatabricksVNetPeering -WorkspaceName $env.testWorkspace1 -ResourceGroupName $env.resourceGroup -Name $env.vnetpeeringname01
        $vetPeering.Name | Should -Be $env.vnetpeeringname01
    }

    It 'GetViaIdentity' {
        $vetPeering = Get-AzDatabricksVNetPeering -WorkspaceName $env.testWorkspace1 -ResourceGroupName $env.resourceGroup -Name $env.vnetpeeringname01
        $vetPeering = Get-AzDatabricksVNetPeering -InputObject  $vetPeering
        $vetPeering.Name | Should -Be $env.vnetpeeringname01
    }
}
