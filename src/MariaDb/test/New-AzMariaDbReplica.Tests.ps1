$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMariaDbReplica.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMariaDbReplica' {
    It 'ServerName' {
        $repMariaDbName = $env.rstr02
        New-AzMariaDbReplica -Name $repMariaDbName -ServerName $env.rstrgp02 -ResourceGroupName $env.ResourceGroup
        $repMariaDb = Get-AzMariaDBServer -Name $repMariaDbName -ResourceGroup $env.ResourceGroup
        $repMariaDb.Name | Should -Be $repMariaDbName
    }

    It 'ServerObject' {
        $repMariaDbName = $env.rstr03
        $mariadb = Get-AzMariaDBServer -Name $env.rstrgp02 -ResourceGroup $env.ResourceGroup
        New-AzMariaDbReplica -Name $repMariaDbName -InputObject $mariadb
        $repMariaDb = Get-AzMariaDBServer -Name $repMariaDbName -ResourceGroup $env.ResourceGroup
        $repMariaDb.Name | Should -Be $repMariaDbName
    }
}
