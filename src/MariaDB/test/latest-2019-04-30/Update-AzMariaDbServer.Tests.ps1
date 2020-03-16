$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$utilsPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
. ($loadEnvPath)
. ($utilsPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMariaDbServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

<#
$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$passwordSecure =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$mariadbTest01 = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $passwordSecure -Location eastus
#>
Describe 'Update-AzMariaDbServer' {
    It 'UpdateExpanded' {
        $mariadb = Get-AzMariaDbServer -Name $env.rstr01 -ResourceGroupName $env.ResourceGroupGet
        $newStorageProfileStorageMb = $mariadb.StorageProfileStorageMb + 10240
        $mariadb = Update-AzMariaDbServer -Name $mariadb.Name -ResourceGroupName $env.ResourceGroup  -StorageProfileStorageMb $newStorageProfileStorageMb 
        $mariadb.StorageProfileStorageMb | Should -Be $newStorageProfileStorageMb
    }
}
