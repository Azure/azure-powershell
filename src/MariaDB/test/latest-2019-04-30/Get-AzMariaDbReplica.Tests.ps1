$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
. ($helperPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbReplica.Recording.json'
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
$repMariadbName01 = $mariadb.Name + '-rep01' 
$repMariadbName02 = $mariadb.Name + '-rep02'
Restore-AzMariaDBServerWithGeo -Name $repMariadbName01 -ResourceGroupName $env.ResourceGroup -SourceServerId $mariadb.Id -Location $env.Location
#Restore-AzMariaDBServerWithGeo -Name $repMariadbName02 -ResourceGroupName $env.ResourceGroup -SourceServerId $mariadb.Id -Location $env.Location
Describe 'Get-AzMariaDbReplica' {
    It 'List' {
        $repmariadb = Get-AzMariaDbReplica -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroup
        $repmariadb.Count | Should -Be 1
    }
}
