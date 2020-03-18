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

$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$skuName = 'GP_Gen5_4'
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -SkuName $skuName -Location $env.Location
$rstMariadbName = $mariadb.Name + '-rep01' 
Restore-AzMariaDBServerWithGeo -Name $rstMariadbName -ResourceGroupName $env.ResourceGroup -SourceServerId $mariadb.Id -Location $env.Location

Describe 'Restore-AzMariaDBServerWithGeo' {
    It 'SourceServerId' {
        # The basic mariadb not support replication feature. 
        $rstMariadbName = $mariadb.Name + '-rep01' 
        Restore-AzMariaDBServerWithGeo -Name $rstMariadbName -ResourceGroupName $env.ResourceGroup -SourceServerId $mariadb.Id -Location $env.Location
        $rstMariadb = Get-AzMariaDbServer -Name $rstMariadbName -ResourceGroupName $env.ResourceGroup
        $rstMariadb.Name | Should -Be $rstMariadbName
    }
    It 'ServerObject' {
        $rstMariadbName = $mariadb.Name + '-rep02' 
        Restore-AzMariaDBServerWithGeo -Name $rstMariadbName -InputObject $mariadb -Location $env.Location
        $rstMariadb = Get-AzMariaDbServer -Name $rstMariadbName -ResourceGroupName $env.ResourceGroup
        $rstMariadb.Name | Should -Be $rstMariadbName
    }
}
