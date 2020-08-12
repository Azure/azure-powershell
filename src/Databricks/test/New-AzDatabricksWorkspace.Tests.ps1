$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDatabricksWorkspace.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDatabricksWorkspace' {
    It 'CreateExpanded' {
        $name = "databricks-test-" + $env.rstr4
        $res = New-AzDatabricksWorkspace -Name $name -ResourceGroupName $env.resourceGroup -Location eastus -VirtualNetworkId $env.virtualNetwork -PrivateSubnetName priv -PublicSubnetName pub -Sku standard
        $res.Name | Should -Be $name
        { Remove-AzDatabricksWorkspace -Name $name -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }
    It 'CreateExpandedWithEncryption' {
        $name = "databricks-test01-" + $env.rstr4
        $res = New-AzDatabricksWorkspace -Name $name -ResourceGroupName $env.resourceGroup -Location eastus -VirtualNetworkId $env.virtualNetwork -PrivateSubnetName priv -PublicSubnetName pub -Sku premium -RequireInfrastructureEncryption
        $res.RequireInfrastructureEncryption | Should -Be $True
        { Remove-AzDatabricksWorkspace -Name $name -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }
}
