$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($helperPath)
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMariaDbServerReplica.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$skuName = 'GP_Gen5_4'
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -SkuName $skuName  -Location $env.Location

Describe 'New-AzMariaDbServerReplica' {
    It 'SourceServerId' {
        $repMariaDbName = $rstr01 + '-rep01'
        New-AzMariaDbServerReplica -Name $repMariadb -SourceServerId $mariadb.Id -ResourceGroupName $env.ResourceGroup
        $repMariaDb = Get-AzMariaDBServer -Name $repMariaDbName -ResourceGroup $env.ResourceGroup
        $repMariaDb.Name | Should -Be $repMariaDbName
    }

    It 'ServerObject' {
        $repMariaDbName = $rstr01 + '-rep02'
        New-AzMariaDbServerReplica -Name $repMariadb -InputObject $mariadb
        $repMariaDb = Get-AzMariaDBServer -Name $repMariaDbName -ResourceGroup $env.ResourceGroup
        $repMariaDb.Name | Should -Be $repMariaDbName
    }
}
