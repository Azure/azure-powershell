if (($null -eq $TestName) -or ($TestName -contains 'Sync-AzDevCenterAdminCatalog')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Sync-AzDevCenterAdminCatalog.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Sync-AzDevCenterAdminCatalog' {
    It 'Sync' {
        Sync-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogName -ResourceGroupName $env.resourceGroup
    }

    It 'SyncViaIdentity' {
        Sync-AzDevCenterAdminCatalog -InputObject @{"CatalogName" = $env.catalogName; "DevCenterName" = $env.devCenterName; "ResourceGroupName" = $env.resourceGroup; "SubscriptionId" = $env.SubscriptionId}
    }
}
