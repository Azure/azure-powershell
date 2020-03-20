$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzMariaDBServerWithGeo.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$mariaDbParam01 = @{SkuName='GP_Gen5_4'}
$mariadbTest01 = GetOrCreateMariaDb -mariaDb $mariaDbParam01 -ResourceGroup $env.resourceGroup

Describe 'Restore-AzMariaDBServerWithGeo' {
    It 'SourceServerId' {
        # The basic mariadb not support replication feature. 
        $repMariadbName = $mariadbTest01.Name + '-rep01'
        Restore-AzMariaDBServerWithGeo -Name $repMariadbName -SourceServerId $mariadbTest01.Id -Location $mariadbTest01.Location
        $repMariadb = Get-AzMariaDbServer -Name $repMariadbName -ResourceGroupName $env.ResourceGroup
        $repMariadb.Name | Should -Be $repMariadbName
    }
    It 'ServerObject' {
        $repMariadbName = $mariadbTest01.Name + '-rep02' 
        Restore-AzMariaDBServerWithGeo -Name $repMariadbName -InputObject $mariadbTest01
        $repMariadb = Get-AzMariaDbServer -Name $repMariadbName -ResourceGroupName $env.ResourceGroup
        $repMariadb.Name | Should -Be $repMariadbName
    }
}
