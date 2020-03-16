$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$utilsPath = Join-Path $PSScriptRoot '..\utils.ps1'
. ($loadEnvPath)
. ($utilsPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzMariaDBServerReplica.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$skuCapacity = 4
$skuFamily = 'Gen5'
$skuName = 'GP_Gen5_4'
$skuTier = 'GeneralPurpose'
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -SkuName $skuName -Location eastus

Describe 'Add-AzMariaDBServerReplica' {
    It 'SourceServerId' {
        # The basic mariadb not support replication feature. 
        $repMariadbName = $mariadb.Name + 'rep01' 
        $repMariadbPipein = Add-AzMariaDBServerReplica -Name $repMariadbName -ResourceGroupName $env.ResourceGroup -SourceServerId $mariadb.Id -Location eastus
        $repMariaDb = Get-AzMariaDbServer -InputObject $repMariadbPipein
        $repMariaDb.Name | Should -Be $repMariadbName
    }
    It 'ServerObject' {
        $repMariadbName = $mariadb.Name + + 'rep02' 
        $repMariadbPipein = Add-AzMariaDBServerReplica -Name $repMariadbName -ResourceGroupName $env.ResourceGroup -InputObject $mariadb -Location eastus
        $repMariaDb = Get-AzMariaDbServer -InputObject $repMariadbPipein
        $repMariaDb.Name | Should -Be $repMariadbName
    }
}
