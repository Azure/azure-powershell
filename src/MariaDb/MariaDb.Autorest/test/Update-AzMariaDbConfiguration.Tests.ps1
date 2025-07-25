$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMariaDbConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzMariaDbConfiguration' {
    It 'ServerName' {
        $confName = 'delayed_insert_timeout'
        $mariadbConf = Get-AzMariaDbConfiguration -Name $confName -ServerName $env.rstrbc01 -ResourceGroupName $env.ResourceGroup
        $newConfValue = $mariadbConf.Value - 50
        $mariadbConf = Update-AzMariaDbConfiguration -Name $confName -ServerName $env.rstrbc01 -ResourceGroupName $env.ResourceGroup -Value $newConfValue
        $mariadbConf.Value | Should -Be $newConfValue
    }
}
