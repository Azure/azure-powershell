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

$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -Location $env.Location

Describe 'Get-AzMariaDbConfiguration' {
    It 'List' {
        $mariaDbConf = Get-AzMariaDbConfiguration -ResourceGroup $env.ResourceGroup -ServerName $rstr01
        $mariaDbConf.Count | Should -BeGreaterOrEqual 1
    }
    It 'Get' {
        $mariaDbConf = Get-AzMariaDbConfiguration -Name max_connections -ResourceGroup $env.ResourceGroup -ServerName $rstr01 
        $mariaDbConf.Value | Should -Not -BeNullOrEmpty 
    }
}
