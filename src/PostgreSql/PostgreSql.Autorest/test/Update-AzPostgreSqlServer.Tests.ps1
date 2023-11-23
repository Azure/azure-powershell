$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPostgreSqlServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzPostgreSqlServer' {
    It 'UpdateExpanded' {
        $server = Update-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName -SslEnforcement Disabled 
        $server.SslEnforcement | Should -Be Disabled
    }

    It 'UpdateViaIdentityExpanded' {
        $server = Get-AzPostgreSqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName
        $updated = Update-AzPostgreSqlServer -BackupRetentionDay 23 -InputObject $server
        $updated.StorageProfileBackupRetentionDay | Should -Be 23
    }
}
