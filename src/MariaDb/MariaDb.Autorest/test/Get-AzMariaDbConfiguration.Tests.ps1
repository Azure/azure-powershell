$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMariaDbConfiguration' {
    It 'List' {
        $mariaDbConf = Get-AzMariaDbConfiguration -ResourceGroup $env.ResourceGroup -ServerName $env.rstrbc01
        $mariaDbConf.Count | Should -BeGreaterOrEqual 1
    }
    It 'Get' {
        $mariaDbConf = Get-AzMariaDbConfiguration -Name max_connections -ResourceGroup $env.ResourceGroup -ServerName $env.rstrbc01 
        $mariaDbConf.Value | Should -Not -BeNullOrEmpty 
    }
}
