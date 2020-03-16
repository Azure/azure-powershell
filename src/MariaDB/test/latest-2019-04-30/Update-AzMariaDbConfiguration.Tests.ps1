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
$mariadb = Get-AzMariaDbServer -Name $env.rstr02 -ResourceGroupName $env.ResourceGroupGet
Describe 'Update-AzMariaDbConfiguration' {
    It 'UpdateExpanded' {
        {Update-AzMariaDbConfiguration} | Should -Not -Throw
    }
    It 'ServerId' {
        $confName = 'wait_timeout'
        $mariadbConf = Get-AzMariaDbConfiguration -Name $confName -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroupGet
        $newConfValue = $mariadbConf.Value + 100
        Update-AzMariaDbConfiguration -Name $confName -ServerId $mariadb.Id -Value $newConfValue
        $mariadbConf = Get-AzMariaDbConfiguration -Name $confName -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroupGet
        $mariadbConf.Value | Should -Be $newConfValue
    }
    It 'ServerName' {
        $confName = 'wait_timeout'
        $mariadbConf = Get-AzMariaDbConfiguration -Name $confName -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroupGet
        $newConfValue = $mariadbConf.Value - 100
        Update-AzMariaDbConfiguration -Name $confName -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroupGet -Value $newConfValue
        $mariadbConf = Get-AzMariaDbConfiguration -Name $confName -ServerName $mariadb.Name -ResourceGroupName $env.ResourceGroupGet
        $mariadbConf.Value | Should -Be $newConfValue
    }
}
