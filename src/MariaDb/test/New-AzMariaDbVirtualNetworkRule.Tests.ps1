$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMariaDbVirtualNetworkRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMariaDbVirtualNetworkRule' {
    It 'CreateExpanded' {
        $vnetRuleName = 'vnetrule-001' 
        $serverName = $env.rstrgp01
        New-AzMariaDbVirtualNetworkRule -ServerName $serverName -ResourceGroupName $env.ResourceGroup -Name $vnetRuleName -SubnetId $env.subnet01 -IgnoreMissingVnetServiceEndpoint
        $mariaDbVnet = Get-AzMariaDbVirtualNetworkRule -Name $vnetRuleName -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariaDbVnet.Name | Should -Be $vnetRuleName
    }
}

