$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName


$mariaDbParam01 = @{SkuName='B_Gen5_1'}
$mariadbTest01 = GetOrCreateMariaDb -mariaDb $mariaDbParam01 -ResourceGroup $env.resourceGroup

Describe 'Get-AzMariaDbConfiguration' {
    It 'List' {
        $mariaDbConf = Get-AzMariaDbConfiguration -ResourceGroup $env.ResourceGroup -ServerName $mariadbTest01.Name
        $mariaDbConf.Count | Should -BeGreaterOrEqual 1
    }
    It 'Get' {
        $mariaDbConf = Get-AzMariaDbConfiguration -Name max_connections -ResourceGroup $env.ResourceGroup -ServerName $mariadbTest01.Name 
        $mariaDbConf.Value | Should -Not -BeNullOrEmpty 
    }
}
