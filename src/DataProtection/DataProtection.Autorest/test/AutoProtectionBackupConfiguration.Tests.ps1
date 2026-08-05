$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AutoProtectionBackupConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AutoProtectionBackupConfiguration' {

    It 'BlobAutoProtectionBasic' {
        $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureBlob -AutoProtection

        ($backupConfig -ne $null) | Should Be $true
        $backupConfig.ObjectType | Should Be "BlobBackupDatasourceParametersForAutoProtection"
        $backupConfig.AutoProtectionSettingEnabled | Should Be $true
        $backupConfig.AutoProtectionSettingObjectType | Should Be "BlobBackupRuleBasedAutoProtectionSettings"
    }

    It 'AdlsAutoProtectionBasic' {
        $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureDataLakeStorage -AutoProtection

        ($backupConfig -ne $null) | Should Be $true
        $backupConfig.ObjectType | Should Be "AdlsBlobBackupDatasourceParametersForAutoProtection"
        $backupConfig.AutoProtectionSettingEnabled | Should Be $true
        $backupConfig.AutoProtectionSettingObjectType | Should Be "BlobBackupRuleBasedAutoProtectionSettings"
    }

    It 'BlobAutoProtectionWithExclusionRules' {
        $rule = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.BlobBackupAutoProtectionRule]::new()
        $rule.ObjectType = "BlobBackupAutoProtectionRule"
        $rule.Pattern = "logs-"

        $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureBlob -AutoProtection -AutoProtectionExclusionRule @($rule)

        ($backupConfig -ne $null) | Should Be $true
        $backupConfig.ObjectType | Should Be "BlobBackupDatasourceParametersForAutoProtection"
        $backupConfig.AutoProtectionSettingEnabled | Should Be $true
        ($backupConfig.AutoProtectionSettingRule -ne $null) | Should Be $true
        $backupConfig.AutoProtectionSettingRule.Count | Should Be 1
        $backupConfig.AutoProtectionSettingRule[0].Pattern | Should Be "logs-"
    }

    It 'AdlsAutoProtectionWithExclusionRules' {
        $rule1 = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.BlobBackupAutoProtectionRule]::new()
        $rule1.ObjectType = "BlobBackupAutoProtectionRule"
        $rule1.Pattern = "logs-"

        $rule2 = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.BlobBackupAutoProtectionRule]::new()
        $rule2.ObjectType = "BlobBackupAutoProtectionRule"
        $rule2.Pattern = "temp-"

        $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureDataLakeStorage -AutoProtection -AutoProtectionExclusionRule @($rule1, $rule2)

        ($backupConfig -ne $null) | Should Be $true
        $backupConfig.ObjectType | Should Be "AdlsBlobBackupDatasourceParametersForAutoProtection"
        $backupConfig.AutoProtectionSettingRule.Count | Should Be 2
        $backupConfig.AutoProtectionSettingRule[0].Pattern | Should Be "logs-"
        $backupConfig.AutoProtectionSettingRule[1].Pattern | Should Be "temp-"
    }

    It 'AutoProtectionNoRulesHasNullRules' {
        $backupConfig = New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureBlob -AutoProtection

        $backupConfig.AutoProtectionSettingRule | Should Be $null
    }
}
