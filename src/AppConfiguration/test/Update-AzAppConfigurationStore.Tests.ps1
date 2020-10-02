$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAppConfigurationStore.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzAppConfigurationStore' {
    It 'UpdateExpanded' {
        # Update app configuration that identity type is user assigned.
        $appConf = Update-AzAppConfigurationStore -Name $env.appconfName00 -ResourceGroupName $env.resourceGroup -Sku 'Standard'
        $appConf.SkuName | Should -Be 'Standard'

        $appConf = Update-AzAppConfigurationStore -Name $env.appconfName00 -ResourceGroupName $env.resourceGroup `
        -Tag @{'key1'= 1;'key2' = 2} `
        -EncryptionKeyIdentifier $env.encryptionKeyIdentifier `
        -KeyVaultIdentityClientId $env.assignedIdentityClinetId
        
        $appConf.KeyVaultPropertyKeyIdentifier | Should -Be $env.encryptionKeyIdentifier
        $appConf.Tag.Count | Should -Be 2

        # Update app configuration that identity type is system assigned.
        $appConf = Update-AzAppConfigurationStore -Name $env.appconfName01 -ResourceGroupName $env.resourceGroup `
        -Tag @{'key1'= 1;'key2' = 2} `
        -EncryptionKeyIdentifier $env.encryptionKeyIdentifier

        $appConf.KeyVaultPropertyKeyIdentifier | Should -Be $env.encryptionKeyIdentifier
        $appConf.Tag.Count | Should -Be 2
    }

    It 'UpdateViaIdentityExpanded' {
        $appConf = Get-AzAppConfigurationStore -Name $env.appconfName00 -ResourceGroupName $env.resourceGroup 
        $appConf = Update-AzAppConfigurationStore -InputObject $appConf -EncryptionKeyIdentifier $null
        $appConf.EncryptionKeyIdentifier | Should -BeFalse
    }
}
