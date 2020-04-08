$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMySqlServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzMySqlServer' {
    It 'UpdateExpanded' -skip {
        $server = Update-AzMySqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SslEnforcement Disabled 
        $server.Count | Should -Be 1
    }

    It 'UpdateViaIdentityExpanded' -skip {
        $server = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $updated = Update-AzMySqlServer -StorageProfileBackupRetentionDay 23 -InputObject $server
        $updated.Count | Should -Be 1
    }
}
