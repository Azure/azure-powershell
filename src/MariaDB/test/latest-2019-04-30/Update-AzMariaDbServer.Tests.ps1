$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMariaDbServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$mariaDbParam01 = @{SkuName='B_Gen5_1'}
$mariadbTest01 = GetOrCreateMariaDb -mariaDb $mariaDbParam01 -ResourceGroup $env.resourceGroup

Describe 'Update-AzMariaDbServer' {
    It 'UpdateExpanded' {
        $newStorageProfileStorageMb = $mariadbTest01.StorageProfileStorageMb + 1024
        $mariadb = Update-AzMariaDbServer -Name $mariadbTest01.Name -ResourceGroupName $env.ResourceGroup  -StorageProfileStorageMb $newStorageProfileStorageMb 
        $mariadb.StorageProfileStorageMb | Should -Be $newStorageProfileStorageMb
    }
    It 'UpdateViaIdentity' {
        $mariadb = Get-AzMariaDbServer -Name $mariadbTest01.Name -ResourceGroupName $env.ResourceGroup
        $newStorageProfileStorageMb = $mariadb.StorageProfileStorageMb + 1024
        $mariadb = Update-AzMariaDbServer -InputObject $mariadb -StorageProfileStorageMb $newStorageProfileStorageMb 
        $mariadb.StorageProfileStorageMb | Should -Be $newStorageProfileStorageMb
    }
}
