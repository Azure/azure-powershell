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
        $mariaDbConf = Get-AzMariaDbConfiguration -ResourceGroup $env.ResourceGroupGet -ServerName $env.rstr01 
        $mariaDbConf.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $mariaDbConf = Get-AzMariaDbConfiguration -Name max_connections -ResourceGroup $env.ResourceGroupGet -ServerName $env.rstr01 
        $mariaDbConf.Value | Should -Not -BeNullOrEmpty 
    }

    It 'GetViaIdentity' -Skip {
        $mariaDb = Get-AzMariaDbServer -Name $env.rstr01 -ResourceGroupName $env.ResourceGroupGet
        $mariaDbConf = Get-AzMariaDbConfiguration -InputObject $mariaDb
        $mariaDbConf.Count | Should -BeGreaterOrEqual 1
    }
}
