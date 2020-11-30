$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMySqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMySqlFlexibleServer' {
    It 'CreateExpanded' {
        {
            #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force
            $server = New-AzMySqlFlexibleServer -Name $env.serverName2 -ResourceGroupName $env.resourceGroup -AdministratorUserName mysql_test -AdministratorLoginPassword $password -Sku Standard_D2ds_v4 -SkuTier GeneralPurpose -BackupRetentionDay 12 -StorageInMb 102400 -Location eastus2
            $server.SkuName | Should -Be "Standard_D2ds_v4"
            $server.SkuTier | Should -Be "GeneralPurpose"
            $server.StorageProfileStorageMb | Should -Be 102400
            $server.StorageProfileBackupRetentionDay | Should -Be 12

        } | Should -Not -Throw
    }
}
