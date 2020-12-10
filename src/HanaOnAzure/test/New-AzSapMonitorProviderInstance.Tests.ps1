$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSapMonitorProviderInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzSapMonitorProviderInstance' {
    It 'CreateExpandedByString' {
        #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
        $sapIns = New-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -Name $env.sapIns03 -SapMonitorName $env.sapMonitor02 -ProviderType SapHana -HanaHostname $env.hostName -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort $env.port -HanaDatabaseUsername SYSTEM -HanaDatabasePassword (ConvertTo-SecureString "Manager1" -AsPlainText -Force)
        $sapIns.ProvisioningState | Should -Be 'Succeeded'
    }
    It 'ByKeyVault' {
        New-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -Name $env.sapIns04 -SapMonitorName $env.sapMonitor02 -ProviderType SapHana -HanaHostname $env.hostName -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort $env.port -HanaDatabaseUsername SYSTEM -HanaDatabasePasswordSecretId $env.hanaDbPasswordSecretId -HanaDatabasePasswordKeyVaultResourceId $env.hanaDbPasswordKvResourceId  -AsJob | Wait-Job
        $sapIns = Get-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -Name $env.sapIns04 -SapMonitorName $env.sapMonitor02
        $sapIns.ProvisioningState | Should -Be 'Succeeded'
    }
    It 'ByDict' {
        $sapIns = New-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -Name $env.sapIns05 -SapMonitorName $env.sapMonitor02 -ProviderType PrometheusOS -InstanceProperty @{prometheusUrl=$env.prometheusUrl}
        $sapIns.ProvisioningState | Should -Be 'Succeeded'
    }
}
