$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMariaDbServerReplica.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$mariaDbParam01 = @{SkuName='GP_Gen5_4'}
$mariadbTest01 = GetOrCreateMariaDb -mariaDb $mariaDbParam01 -ResourceGroup $env.resourceGroup
#$name = $mariadbTest01.Name
#Write-Host -ForegroundColor Green "mariadb name: $name"
Describe 'New-AzMariaDbServerReplica' {
    It 'ServerName' {
        $repMariaDbName = $rstr01 + '-rep01'
        New-AzMariaDbServerReplica -Name $repMariaDbName -ServerName $mariadbTest01.Name -ResourceGroupName $env.ResourceGroup -SkuName $mariadbTest01.SkuName
        $repMariaDb = Get-AzMariaDBServer -Name $repMariaDbName -ResourceGroup $env.ResourceGroup
        $repMariaDb.Name | Should -Be $repMariaDbName
    }

    It 'ServerObject' {
        $repMariaDbName = $rstr01 + '-rep02'
        New-AzMariaDbServerReplica -Name $repMariaDbName -InputObject $mariadbTest01 -SkuName $mariadbTest01.SkuName
        $repMariaDb = Get-AzMariaDBServer -Name $repMariaDbName -ResourceGroup $env.ResourceGroup
        $repMariaDb.Name | Should -Be $repMariaDbName
    }
}
