$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzMariaDBServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName
$mariaDbParam01 = @{SkuName='B_Gen5_1'}
$mariadbTest01 = GetOrCreateMariaDb -mariaDb $mariaDbParam01 -ResourceGroup $env.resourceGroup
Describe 'Restore-AzMariaDBServer' {
    It 'RestoreExpanded' {
        $restoreMariaDbName = $mariadbTest01.Name + '-rst01'
        $restorePointInTime = (Get-Date).AddHours(-8)
        #$restoreMode = 'PointInTimeRestore'
        Restore-AzMariaDBServer -Name $restoreMariaDbName -ResourceGroup $env.ResourceGroup -SourceServerId $mariadbTest01.Id -RestorePointInTime $restorePointInTime
        $restoreMariadb = Get-AzMariaDBServer -Name $restoreMariaDbName -ResourceGroup $env.ResourceGroup
        $restoreMariadb.Name | Should -Be $restoreMariaDbName
    }
    It 'RestoreViaIdentity' {
        $restoreMariaDbName = $mariadbTest01.Name + '-rst01'
        $restorePointInTime = (Get-Date).AddHours(-8)
        #$restoreMode = 'PointInTimeRestore'
        Restore-AzMariaDBServer -Name $restoreMariaDbName -InputObject $mariadbTest01 -RestorePointInTime $restorePointInTime
        $restoreMariadb = Get-AzMariaDBServer -Name $restoreMariaDbName -ResourceGroup $env.ResourceGroup
        $restoreMariadb.Name | Should -Be $restoreMariaDbName
    }
}
