$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbVNetRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMariaDbVNetRule' {
    # The basic mariadb not support vnet feature. 
    It 'List' {
        $serverName = $env.str03
        $mariaDbVnet = Get-AzMariaDbVNetRule -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariaDbVnet.Count | Should -Be 2
    }

    It 'Get' {
        $serverName = $env.str03
        $vnetRuleName = $env.vnetRule01
        $mariaDbVnet = Get-AzMariaDbVNetRule -Name $vnetRuleName -ResourceGroupName $env.ResourceGroup -ServerName $serverName
        $mariaDbVnet.Name | Should -Be $vnetName
    }

    It 'GetViaIdentity' -skip {
        $serverName = $env.str03
        $mariaDb = Get-AzMariaDbServer -Name $serverName -ResourceGroupName $env.ResourceGroup
        $mariaDbVnet = Get-AzMariaDbVNetRule -InputObject $mariaDb
        $mariaDbVnet.Count | Should -Be 2
    }
}
