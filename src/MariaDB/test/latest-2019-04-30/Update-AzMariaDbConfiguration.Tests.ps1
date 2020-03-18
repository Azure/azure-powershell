$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
$helperPath = Join-Path $PSScriptRoot '..\helper.ps1'
. ($loadEnvPath)
. ($helperPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMariaDbConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName
$rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
$administratorLoginPassword =  ConvertTo-SecureString $env.AdminLoginPassword -AsPlainText -Force 
$mariadb = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroup -AdministratorLogin $env.AdminLogin -AdministratorLoginPassword $administratorLoginPassword -Location $env.Location

Describe 'Update-AzMariaDbConfiguration' {
    It 'ServerId' {
        $confName = 'wait_timeout'
        $mariadbConf = Get-AzMariaDbConfiguration -Name $confName -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroup
        $newConfValue = $mariadbConf.Value + 200
        Update-AzMariaDbConfiguration -Name $confName -ServerId $mariadb.Id -Value $newConfValue
        $mariadbConf = Get-AzMariaDbConfiguration -Name $confName -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroup
        $mariadbConf.Value | Should -Be $newConfValue
    }
    It 'ServerName' {
        $confName = 'wait_timeout'
        $mariadbConf = Get-AzMariaDbConfiguration -Name $confName -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroup
        $newConfValue = $mariadbConf.Value - 100
        Update-AzMariaDbConfiguration -Name $confName -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroup -Value $newConfValue
        $mariadbConf = Get-AzMariaDbConfiguration -Name $confName -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroup
        $mariadbConf.Value | Should -Be $newConfValue
    }
}
