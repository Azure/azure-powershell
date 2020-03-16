$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$utilsPath = Join-Path $PSScriptRoot '..\utils.ps1'
. ($loadEnvPath)
. ($utilsPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzMariaDBServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -Location eastus
Describe 'Restore-AzMariaDBServer' {
    It 'RestoreExpanded' {
        $restoreMariaDbName = 'restore01-' + $mariadb.Name
        $restorePointInTime = (Get-Date).AddHours(-8)
        $restoreMode = 'PointInTimeRestore'
        $restoreMariadb = Restore-AzMariaDBServer -Name $restoreMariaDbName -ResourceGroup $env.ResourceGroup -SourceServerId $mariadb.Id
        -RestoreMode $restoreMode -RestorePointInTime $restorePointInTime
        $restoreMariadb.Name | Should -Be $restoreMariaDbName
    }
    It 'RestoreExpanded' {
        $restoreMariaDbName = 'restore02-' + $mariadb.Name
        $restorePointInTime = (Get-Date).AddHours(-8)
        $restoreMode = 'PointInTimeRestore'
        $restoreMariadb = Restore-AzMariaDBServer -Name $restoreMariaDbName -InputObject $mariadb
        -RestoreMode $restoreMode -RestorePointInTime $restorePointInTime
        $restoreMariadb.Name | Should -Be $restoreMariaDbName
    }
}
