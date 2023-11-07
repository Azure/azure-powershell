$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Find-AzDataProtectionRestorableTimeRange.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Find-AzDataProtectionRestorableTimeRange' {
    It 'PostExpanded' {
        $sub = $env.TestBlobsRestore.SubscriptionId
        $rgName = $env.TestBlobsRestore.ResourceGroupName
        $vaultName = $env.TestBlobsRestore.VaultName
        
        $instances  = Get-AzDataProtectionBackupInstance -Subscription $sub -ResourceGroup $rgName -Vault $vaultName | Where-Object {($_.Property.DataSourceInfo.Type -eq "Microsoft.Storage/storageAccounts/blobServices") -and ($_.Property.CurrentProtectionState -eq "ProtectionConfigured")}
        
        if($instances.Count -gt 0){
            
            $pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instances[0].BackupInstanceName -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName -SourceDataStoreType OperationalStore -StartTime (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z") -EndTime (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")

            $assert = $pointInTimeRange.RestorableTimeRange.Count -gt 0
            $assert | Should be $true
        }
        
    }
}
 