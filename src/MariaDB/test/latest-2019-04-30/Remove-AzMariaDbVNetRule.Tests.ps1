$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMariaDbVNetRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Delete' {
    It 'Delete' -skip {
        $serverName = $env.rstr03
        $vnetRuleName = $env.VnetRule03
        Remove-AzMariaDbVNetRule -ServerName $serverName -ResourceGroupName $env.ResourceGroupGet -Name $vnetRuleName
        $mariaDbVnet = Get-AzMariaDbVNetRule -ResourceGroupName $env.ResourceGroupGet -ServerName $serverName
        $mariaDbVnet.Name | Should -Not -Contain $vnetRuleName
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
