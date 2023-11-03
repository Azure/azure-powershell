$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzMariaDbServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restart-AzMariaDbServer' {
    It 'Restart' {
        Restart-AzMariaDbServer -Name $env.rstrbc01 -ResourceGroupName $env.ResourceGroup
        $mariadbRestart =  Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup -Name $env.rstrbc01
        $mariadbRestart.UserVisibleState | Should -BeExactly  'Ready'       
    }
    It 'RestartViaIdentity' {
        $mariadb = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup -Name $env.rstrbc02
        Restart-AzMariaDbServer -InputObject $mariadb
        $mariadbRestart = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup -Name $env.rstrbc02
        $mariadbRestart.UserVisibleState | Should -BeExactly  'Ready'       
    }
}
