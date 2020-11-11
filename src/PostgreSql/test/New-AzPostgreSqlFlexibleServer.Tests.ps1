$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPostgreSqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzPostgreSqlFlexibleServer' {
    It 'CreateExpanded' {
        {
            $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force
            $server = New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -AdministratorUserName mysql_test -AdministratorLoginPassword $password -Sku Standard_B1ms -SkuTier Burstable -BackupRetentionDay 12 -StorageInMb 65536 -Location eastus2
            $server.SkuName | Should -Be "Standard_B1ms"
            $server.SkuTier | Should -Be "Burstable"
            $server.StorageProfileStorageMb | Should -Be 65536
            $server.StorageProfileBackupRetentionDays | Should -Be 12
        } | Should -Not -Throw
    }
}
