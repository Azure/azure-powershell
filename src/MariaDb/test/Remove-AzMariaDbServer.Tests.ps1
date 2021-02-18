$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMariaDbServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzMariaDbServer' {
    It 'Delete' {
        Remove-AzMariaDbServer -Name $env.rstrdel01 -ResourceGroupName $env.ResourceGroup
        $mariadbs = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup
        $mariadbs.Name | Should -Not -Contain $env.rstrdel01
    }

    It 'DeleteViaIdentity' {
        $mariadb = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup -Name $env.rstrdel02
        Remove-AzMariaDbServer -InputObject $mariadb
        $mariadbs = Get-AzMariaDbServer -ResourceGroupName $env.ResourceGroup
        $mariadbs.Name | Should -Not -Contain $mariadb.Name
    }
}
